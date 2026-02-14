using Archipelago.Core;
using Archipelago.Core.Models;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
