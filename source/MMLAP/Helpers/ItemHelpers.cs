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
            uint oldZenny = Memory.ReadUInt(Addresses.CurrentZenny.Address);
            uint amountReceived = uint.Parse(item.Name.Split(' ')[0]);
            uint newZenny = ((oldZenny + amountReceived) < oldZenny) ? uint.MaxValue : oldZenny + amountReceived;
            _ = Memory.Write(Addresses.CurrentZenny.Address, newZenny, Archipelago.Core.Util.Enums.Endianness.Big);
            return;
        }

        public static void ReceiveBusterPart(Item item)
        {
            Dictionary<long, ItemData> itemDataDict = LocationHelpers.GetItemDataDict();
            if (itemDataDict.TryGetValue(item.Id, out ItemData? itemData))
            {
                ulong busterInv = Addresses.UnequippedBusterInvStart.Address;
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
            }
            // If buster inventory is full then do nothing
            return;
        }

        public static void ReceiveSpecialItem(Item item)
        {
            Dictionary<long, ItemData> itemDataDict = LocationHelpers.GetItemDataDict();
            if (itemDataDict.TryGetValue(item.Id, out ItemData? itemData) && itemData.InventoryAddressData != null)
            {
                _ = Memory.WriteBit(itemData.InventoryAddressData.Address, itemData.InventoryAddressData.BitNumber ?? 0, true);
            }
            return;
        }

        public static void ReceiveNormalItem(Item item)
        {
            Dictionary<long, ItemData> itemDataDict = LocationHelpers.GetItemDataDict();
            if (itemDataDict.TryGetValue(item.Id, out ItemData? itemData) && itemData.InventoryAddressData != null)
            {
                _ = Memory.WriteBit(itemData.InventoryAddressData.Address, itemData.InventoryAddressData.BitNumber ?? 0, true);
            }
            return;
        }
    }
}
