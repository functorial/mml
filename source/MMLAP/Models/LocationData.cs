using System.Diagnostics.CodeAnalysis;

namespace MMLAP.Models
{
    public class LocationData
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public ulong CheckAddress { get; set; }
        public int CheckAddressBit { get; set; }
        public LevelData LevelData { get; set; }
        public ItemData DefaultItemData { get; set; }
        public bool IsMissable { get; set; }
        public string? ChestItemSignatureAddress { get; set; }
        public string? TextBoxStartAddress { get; set; }
        public LocationData(
            string name,
            string category,
            ulong checkAddress,
            int checkAddressBit,
            LevelData levelData,
            ItemData defaultItemData,
            bool isMissable = false,
            string? chestItemSignatureAddress = null,
            string? textBoxStartAddress = null
        )
        {
            Name = name;
            Category = category;
            CheckAddress = checkAddress;
            CheckAddressBit = checkAddressBit;
            LevelData = levelData;
            DefaultItemData = defaultItemData;
            IsMissable = isMissable;
            ChestItemSignatureAddress = chestItemSignatureAddress;
            TextBoxStartAddress = textBoxStartAddress;
        }
    }
}
