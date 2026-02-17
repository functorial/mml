using Archipelago.Core;
using Archipelago.Core.AvaloniaGUI.Models;
using Archipelago.Core.AvaloniaGUI.ViewModels;
using Archipelago.Core.AvaloniaGUI.Views;
using Archipelago.Core.GameClients;
using Archipelago.Core.Models;
using Archipelago.Core.Util;
using Archipelago.MultiClient.Net;
using Archipelago.MultiClient.Net.BounceFeatures.DeathLink;
using Archipelago.MultiClient.Net.MessageLog.Messages;
using Archipelago.MultiClient.Net.Models;
using Archipelago.MultiClient.Net.Packets;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls.Platform;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.OpenGL;
using MMLAP.Helpers;
using MMLAP.Models;
using Newtonsoft.Json;
using ReactiveUI;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reflection;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Timers;
using static MMLAP.Models.Enums;

namespace MMLAP;

public partial class App : Application
{
    // TODO: Remember to set this in MMLAP.Desktop as well.
    public static string Version = "0.0.1";
    public static List<string> SupportedVersions = ["0.0.1"];

    public static MainWindowViewModel Context;
    public static ArchipelagoClient Client { get; set; }
    private static string _playerName { get; set; }
    public static List<ILocation> GameLocations { get; set; }
    public static Dictionary<long, ItemData> scoutedLocationItemData {  get; set; }
    private static readonly object _lockObject = new object();
    private static bool _hasSubmittedGoal { get; set; }
    private static bool _useQuietHints { get; set; }
    private static int _unlockedLevels { get; set; }
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }
    private static bool IsRunningAsAdministrator()
    {
        WindowsIdentity identity = WindowsIdentity.GetCurrent();
        WindowsPrincipal principal = new(identity);
        return principal.IsInRole(WindowsBuiltInRole.Administrator);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        Start();
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = Context
            };
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainWindow
            {
                DataContext = Context
            };
        }
        base.OnFrameworkInitializationCompleted();
    }
    public void Start()
    {
        Context = new MainWindowViewModel("0.6.3 or later");
        Context.ClientVersion = Assembly.GetEntryAssembly().GetName().Version.ToString();
        Context.ConnectClicked += Context_ConnectClicked;
        Context.CommandReceived += (e, a) =>
        {
            if (string.IsNullOrWhiteSpace(a.Command)) return;
            Client?.SendMessage(a.Command);
            HandleCommand(a.Command);
        };
        Context.ConnectButtonEnabled = true;
        Context.AutoscrollEnabled = true;
        // TODO: Autopopulate based on last connection.
        //Context.Host = "Hello World";
        _hasSubmittedGoal = false;
        _useQuietHints = true;
        Log.Logger.Information("This Archipelago Client is compatible only with the USA release of Mega Man Legends.");
        Log.Logger.Information("Trying to play with a different version will not work as intended.");
        if (!IsRunningAsAdministrator())
        {
            Log.Logger.Warning("You do not appear to be running this client as an administrator.");
            Log.Logger.Warning("This may result in errors or crashes when trying to connect to Duckstation.");
        }
    }

    private void HandleCommand(string command)
    {
        if (Client == null || Client.ItemState == null || Client.CurrentSession == null) return;
        switch (command)
        {
            case "showGoal":
                CompletionGoal goal = (CompletionGoal)int.Parse(Client.Options?.GetValueOrDefault("goal", 0).ToString());
                string goalText = "";
                switch (goal)
                {
                    case CompletionGoal.Juno:
                        goalText = "Defeat Juno.";
                        break;
                    default:
                        goalText = "Unknown.";
                        break;
                }
                Log.Logger.Information($"Your goal is: {goalText}");
                break;
        }
    }
    private async void Context_ConnectClicked(object? sender, ConnectClickedEventArgs e)
    {
        if (Client != null)
        {
            Client.CancelMonitors();
            Client.Connected -= OnConnected;
            Client.Disconnected -= OnDisconnected;
            Client.ItemReceived -= ItemReceived;
            Client.MessageReceived -= Client_MessageReceived;
            Client.LocationCompleted -= Client_LocationCompleted;
            Client.CurrentSession.Locations.CheckedLocationsUpdated -= Locations_CheckedLocationsUpdated;
            _unlockedLevels = 0;
        }
        DuckstationClient? client = null;
        try
        {
            client = new DuckstationClient();
        }
        catch (ArgumentException ex)
        {
            Log.Logger.Warning("Duckstation not running, open Duckstation and launch the game before connecting!");
            return;
        }
        var DuckstationConnected = client.Connect();
        if (!DuckstationConnected)
        {
            Log.Logger.Warning("Duckstation not running, open Duckstation and launch the game before connecting!");
            return;
        }
        Client = new ArchipelagoClient(client);

        Memory.GlobalOffset = Memory.GetDuckstationOffset();

        Client.Connected += OnConnected;
        Client.Disconnected += OnDisconnected;

        await Client.Connect(e.Host, "Mega Man Legends", "save1");
        if (!Client.IsConnected)
        {
            Log.Logger.Error("Your host seems to be invalid.  Please confirm that you have entered it correctly.");
            return;
        }

        Client.LocationCompleted += Client_LocationCompleted;
        Client.CurrentSession.Locations.CheckedLocationsUpdated += Locations_CheckedLocationsUpdated;
        Client.MessageReceived += Client_MessageReceived;
        Client.ItemReceived += ItemReceived;
        Client.EnableLocationsCondition = () => Helpers.IsInGame();
        _playerName = e.Slot;
        await Client.Login(e.Slot, !string.IsNullOrWhiteSpace(e.Password) ? e.Password : null);
        if (Client.Options?.Count > 0)
        {
            // GemsanityOptions gemsanityOption = (GemsanityOptions)int.Parse(Client.Options?.GetValueOrDefault("enable_gemsanity", "0").ToString());
            int slot = Client.CurrentSession.ConnectionInfo.Slot;
            Dictionary<string, object> slotData = await Client.CurrentSession.DataStorage.GetSlotDataAsync(slot);
            List<int> gemsanityIDs = new List<int>();
            if (slotData.TryGetValue("gemsanity_ids", out var value))
            {
                if (value != null)
                {
                    gemsanityIDs = System.Text.Json.JsonSerializer.Deserialize<List<int>>(value.ToString());
                }
            }
            if (slotData.TryGetValue("apworldVersion", out var versionValue))
            {
                if (versionValue != null && SupportedVersions.Contains(versionValue.ToString().ToLower()))
                {
                    Log.Logger.Information($"The host's AP world version is {versionValue.ToString()} and the client version is {Version}.");
                    Log.Logger.Information("These versions are known to be compatible.");
                }
                else if (versionValue != null && versionValue.ToString().ToLower() != Version.ToLower())
                {
                    Log.Logger.Warning($"The host's AP world version is {versionValue.ToString()} but the client version is {Version}.");
                    Log.Logger.Warning("Please ensure these are compatible before proceeding.");
                }
                else if (versionValue == null)
                {
                    //Log.Logger.Error($"The host's AP world version predates 1.0.0, but the client version is {Version}.");
                    Log.Logger.Error("This will almost certainly result in errors.");
                }
            }
            else
            {
                //Log.Logger.Error($"The host's AP world version predates 1.0.0, but the client version is {Version}.");
                Log.Logger.Error("This will almost certainly result in errors.");
            }
            //_requiredOrbs = int.Parse(Client.Options?.GetValueOrDefault("ripto_door_orbs", 0).ToString());

            GameLocations = LocationHelpers.BuildLocationList();
            GameLocations = GameLocations.Where(x => x != null && !Client.CurrentSession.Locations.AllLocationsChecked.Contains(x.Id)).ToList();
            Client.MonitorLocations(GameLocations);

            Log.Logger.Information("Warnings and errors above are okay if this is your first time connecting to this multiworld server.");
        }
        else
        {
            Log.Logger.Error("Failed to login.  Please check your host, name, and password.");
        }
    }

    private void Client_LocationCompleted(object? sender, LocationCompletedEventArgs e)
    {
        if (Client.ItemState == null || Client.CurrentSession == null) return;

        // Use scouted location item to rewrite textbox

        CheckGoalCondition();
    }

    private async void ItemReceived(object? o, ItemReceivedEventArgs args)
    {
        if (Client.CurrentSession == null) return;
        Log.Logger.Debug($"Item Received: {JsonConvert.SerializeObject(args.Item)}");
        switch (args.Item)
        {
            case Item x when Enum.TryParse<ItemCategory>(x.Category, out ItemCategory category) && (category == ItemCategory.Nothing):
                ItemHelpers.ReceiveNothing(x); break;
            case Item x when Enum.TryParse<ItemCategory>(x.Category, out ItemCategory category) && (category == ItemCategory.Zenny):
                ItemHelpers.ReceiveZenny(x); break;
            case Item x when Enum.TryParse<ItemCategory>(x.Category, out ItemCategory category) && (category == ItemCategory.Buster):
                ItemHelpers.ReceiveBusterPart(x); break;
            case Item x when Enum.TryParse<ItemCategory>(x.Category, out ItemCategory category) && (category == ItemCategory.Special):
                ItemHelpers.ReceiveSpecialItem(x); break;
            case Item x when Enum.TryParse<ItemCategory>(x.Category, out ItemCategory category) && (category == ItemCategory.Normal):
                ItemHelpers.ReceiveNormalItem(x); break;
            default:
                Console.WriteLine($"Item not recognised. ({args.Item.Name}) Skipping"); break;
        };
    }
    
    private static void CheckGoalCondition()
    {
        if (
            Client == null ||
            Client.CurrentSession == null ||
            Client.CurrentSession.Locations == null ||
            Client.CurrentSession.Locations.AllLocationsChecked == null ||
            Client.ItemState == null ||
            GameLocations == null
        )
        {
            return;
        }
        if (_hasSubmittedGoal)
        {
            return;
        }
        
        int goal = int.Parse(Client.Options?.GetValueOrDefault("goal", 0).ToString());
        //switch ((CompletionGoal)goal)
        //{
        //    case CompletionGoal.Ripto:
        //        Client.SendGoalCompletion();
        //        _hasSubmittedGoal = true;
        //        break;
        //};
    }

    private static async void Client_MessageReceived(object? sender, MessageReceivedEventArgs e)
    {
        Log.Logger.Information(JsonConvert.SerializeObject(e.Message));
    }
    private static async void Locations_CheckedLocationsUpdated(System.Collections.ObjectModel.ReadOnlyCollection<long> newCheckedLocations)
    {
        if (Client.ItemState == null || Client.CurrentSession == null) return;
        if (!Helpers.IsInGame())
        {
            Log.Logger.Error("Check sent while not in game. Please report this in the Discord thread!");
        }
        CheckGoalCondition();
    }
    /**
     * Writes a block of text to memory. endAddress will generally be the null terminator and will not be written to.
     */

    private static async void OnConnected(object sender, EventArgs args)
    {
        // Load locations and start monitoring
        List<ILocation> locations = LocationHelpers.BuildLocationList();
        await Client.MonitorLocationsAsync(locations);

        // Scout locations for items
        long[] locationIds = locations.Select(loc => (long)loc.Id).ToArray();
        ArchipelagoSession session = Client.CurrentSession;
        Dictionary<long, ScoutedItemInfo> scoutedLocations = await session.Locations.ScoutLocationsAsync(locationIds);
        Dictionary<long, ItemData> itemDataDict = LocationHelpers.GetItemDataDict();
        scoutedLocationItemData = scoutedLocations.Keys.ToDictionary(locationId => locationId, locationId => itemDataDict[scoutedLocations[locationId].ItemId]);

        Log.Logger.Information("Connected to Archipelago");
        Log.Logger.Information($"Playing {Client.CurrentSession.ConnectionInfo.Game} as {Client.CurrentSession.Players.GetPlayerName(Client.CurrentSession.ConnectionInfo.Slot)}");
    }

    private static async void OnDisconnected(object sender, EventArgs args)
    {
        Log.Logger.Information("Disconnected from Archipelago");
        // Avoid ongoing timers affecting a new game.
        _hasSubmittedGoal = false;
        _useQuietHints = true;
        _unlockedLevels = 0;
        Log.Logger.Information("This Archipelago Client is compatible only with the USA release of Mega Man Legends.");
        Log.Logger.Information("Trying to play with a different version will not work as intended.");

        //if (_deathLinkService != null)
        //{
        //    _deathLinkService = null;
        //}
    }
}
