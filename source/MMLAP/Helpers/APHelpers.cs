using Archipelago.Core;
using Archipelago.Core.Models;
using MMLAP.Models;
using static MMLAP.Models.Enums;
using Newtonsoft.Json;
using Serilog;
using System;

namespace MMLAP.Helpers
{
    public class APHelpers
    {
        public static void OnConnected(object sender, EventArgs args, ArchipelagoClient client)
        {
            Log.Logger.Information("Connected to Archipelago");
            Log.Logger.Information($"Playing {client.CurrentSession.ConnectionInfo.Game} as {client.CurrentSession.Players.GetPlayerName(client.CurrentSession.ConnectionInfo.Slot)}");

        }
        public static void OnDisconnected(object sender, EventArgs args)
        {
            Log.Logger.Information("Disconnected from Archipelago");
        }
        public async void ItemReceived(object sender, ItemReceivedEventArgs args, ArchipelagoClient client)
        {
            if (client.CurrentSession == null) return;
            switch (args.Item)
            {
                case var x when Enum.TryParse<ItemCategory>(x.Category, out var category) && (category == ItemCategory.Nothing):
                    ItemHelpers.ReceiveNothing(x); break;
                case var x when Enum.TryParse<ItemCategory>(x.Category, out var category) && (category == ItemCategory.Zenny):
                    ItemHelpers.ReceiveZenny(x); break;
                case var x when Enum.TryParse<ItemCategory>(x.Category, out var category) && (category == ItemCategory.Buster):
                    ItemHelpers.ReceiveBusterPart(x); break;
                case var x when Enum.TryParse<ItemCategory>(x.Category, out var category) && (category == ItemCategory.Special):
                    ItemHelpers.ReceiveSpecialItem(x); break;
                case var x when Enum.TryParse<ItemCategory>(x.Category, out var category) && (category == ItemCategory.Normal):
                    ItemHelpers.ReceiveNormalItem(x); break;
                default:
                    Console.WriteLine($"Item not recognised. ({args.Item.Name}) Skipping"); break;
            };
            Log.Logger.Debug($"Item Received: {JsonConvert.SerializeObject(args.Item)}");
        }
    }
}
