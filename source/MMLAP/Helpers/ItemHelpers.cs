using Archipelago.Core.Models;
using Archipelago.Core.Util;
using MMLAP.Models;
using System.Collections.Generic;

namespace MMLAP.Helpers
{
    public class ItemHelpers
    {
        public static void ReceiveNothing(Item item)
        {
            return;
        }
        public static void ReceiveZenny(Item item)
        {
            uint oldZenny = Memory.ReadUInt(Addresses.CurrentZenny);
            uint amountReceived = uint.Parse(item.Name.Split(' ')[0]);
            uint newZenny = ((oldZenny + amountReceived) < oldZenny) ? uint.MaxValue : oldZenny + amountReceived;
            _ = Memory.Write(Addresses.CurrentZenny, newZenny);
            return;
        }
        public static void ReceiveBusterPart(Item item)
        {
            Dictionary<long, ItemData> itemDataDict = LocationHelpers.GetItemDataDict();
            ItemData itemData = itemDataDict[item.Id];
            ulong busterInv = Addresses.UnequippedBusterInvStart;
            for (uint i = 0; i < 34; i++)
            {
                ulong busterInvSlot = busterInv + i;
                byte invSlotVal = Memory.ReadByte(busterInvSlot);
                if (invSlotVal == 0)
                {
                    // Offset of 1 is intended for buster part code conversion
                    Memory.Write(busterInvSlot, (itemData.ItemCode ?? -1) + 1);
                    return;
                }
            }
            // If buster inventory is full then do nothing
            return;
        }
        public static void ReceiveSpecialItem(Item item)
        {
            Dictionary<long, ItemData> itemDataDict = LocationHelpers.GetItemDataDict();
            ItemData itemData = itemDataDict[item.Id];
            _ = Memory.WriteBit(itemData.InventoryAddress ?? 0, itemData.InventoryAddressBitNumber ?? 0, true);
            return;
        }
        public static void ReceiveNormalItem(Item item)
        {
            Dictionary<long, ItemData> itemDataDict = LocationHelpers.GetItemDataDict();
            ItemData itemData = itemDataDict[item.Id];
            _ = Memory.WriteBit(itemData.InventoryAddress ?? 0, itemData.InventoryAddressBitNumber ?? 0, true);
            return;
        }
    }
}
