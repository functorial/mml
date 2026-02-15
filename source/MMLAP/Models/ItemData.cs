namespace MMLAP.Models
{
    public class ItemData
    {
        public Enums.ItemCategory Category { get; set; }
        public string Name { get; set; }
        public uint? Quantity { get; set; }
        public byte? ItemCode { get; set; }
        public ulong? InventoryAddress { get; set; }
        public int? InventoryAddressBitNumber { get; set; }
        //public bool IsSellable { get; set; }

        public ItemData(
            Enums.ItemCategory category,
            string name,
            uint? quantity = null,
            byte? code = null,
            ulong? address = null,
            int? addressBit = null
            ///bool isSellable = false
        )
        {
            Category = category;
            Name = name;
            Quantity = quantity;
            ItemCode = code;
            InventoryAddress = address;
            InventoryAddressBitNumber = addressBit;
            //IsSellable = isSellable;
        }
    }
}
