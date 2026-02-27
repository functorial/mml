namespace MMLAP.Models
{
    public class ItemData(
        MMLEnums.ItemCategory category,
        string name,
        uint quantity = 1,
        byte? itemCode = null,
        AddressData? inventoryAddressData = null,
        bool isFiller = false
    )
    {
        public MMLEnums.ItemCategory Category { get; set; } = category;
        public string Name { get; set; } = name;
        public uint Quantity { get; set; } = quantity;
        public byte? ItemCode { get; set; } = itemCode;
        public AddressData? InventoryAddressData { get; set; } = inventoryAddressData;
        public bool IsFiller { get; set; } = isFiller;
    }
}
