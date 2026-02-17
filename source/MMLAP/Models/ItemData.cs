namespace MMLAP.Models
{
    public class ItemData
    {
        //public long Id { get; set; }
        public Enums.ItemCategory Category { get; set; }
        public string Name { get; set; }
        public short? Quantity { get; set; }
        public byte? ItemCode { get; set; }
        public ulong? InventoryAddress { get; set; }
        public int? InventoryAddressBitNumber { get; set; }
        public bool IsFiller { get; set; }

        public ItemData(
            //long id,
            Enums.ItemCategory category,
            string name,
            short? quantity = null,
            byte? code = null,
            ulong? address = null,
            int? addressBit = null,
            bool isFiller = false
        )
        {
            //Id = id;
            Category = category;
            Name = name;
            Quantity = quantity;
            ItemCode = code;
            InventoryAddress = address;
            InventoryAddressBitNumber = addressBit;
            IsFiller = IsFiller;
        }
    }
}
