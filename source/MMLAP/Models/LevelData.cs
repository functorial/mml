using System.Collections.Generic;

namespace S2AP.Models
{
    public class LevelData
    {
        public string Name { get; set; }
        public int OrbCount { get; set; }
        public int LevelId { get; set; }
        public bool HasTalisman { get; set; }
        public bool IsBoss { get; set; }
        public uint[] MoneybagsAddresses { get; set; }
        public uint[] SkillPointAddresses { get; set; }
        public List<uint>[] LifeBottleAddresses { get; set; }
        public int SpiritParticles { get; set; }
        public uint GemMaskAddress { get; set; }
        public int TotalGemCount { get; set; }
        public int[] GemSkipIndices { get; set; }
        public LevelData(
            string name,
            int levelId,
            int orbCount,
            bool hasTalisman,
            bool isBoss,
            uint[] moneybagsAddresses,
            uint[] skillPointAddresses,
            List<uint>[] lifeBottleAddresses,
            int spiritParticles,
            uint gemMaskAddress = 0x0,
            int totalGemCount = 0,
            int[] gemSkipIndices = null
        )
        {
            Name = name;
            OrbCount = orbCount;
            LevelId = levelId;
            HasTalisman = hasTalisman;
            IsBoss = isBoss;
            MoneybagsAddresses = moneybagsAddresses;
            SkillPointAddresses = skillPointAddresses;
            LifeBottleAddresses = lifeBottleAddresses;
            SpiritParticles = spiritParticles;
            GemMaskAddress = gemMaskAddress;
            TotalGemCount = totalGemCount;
            if (gemSkipIndices == null)
            {
                gemSkipIndices = [];
            }
            GemSkipIndices = gemSkipIndices;
        }
    }
}
