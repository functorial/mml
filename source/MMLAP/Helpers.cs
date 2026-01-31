using Archipelago.Core.Models;
using Archipelago.Core.Util;
using Archipelago.MultiClient.Net.Models;
using Avalonia.Logging;
using S2AP.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using static S2AP.Models.Enums;
using Location = Archipelago.Core.Models.Location;
namespace MMLAP
{
    public class Helpers
    {
        private static GameStatus lastNonZeroStatus = GameStatus.Spawning;
        public static string gameVersion = "";
        public static string OpenEmbeddedResource(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string jsonFile = reader.ReadToEnd();
                return jsonFile;
            }
        }
        public static bool IsInDemoMode()
        {
            return Memory.ReadByte(Addresses.IsInDemoMode) == 1;
        }
        public static bool IsInGame()
        {
            var status = GetGameStatus();
            bool isCorrectGameVersion = IsCorrectVersion();
            return !IsInDemoMode() &&
                status != GameStatus.TitleScreen &&
                status != GameStatus.Loading && // Handle loading into and out of demo mode.
                isCorrectGameVersion &&
                Memory.ReadInt(Addresses.ResetCheckAddress) != 0; // Handle status being 0 on console reset.
        }
        public static bool IsCorrectVersion()
        {
            // Handle case where user resets Duckstation or loads a new ROM.
            // Certain versions of the BIOS are incompatible with Addresses.ResetCheckAddress.
            /*if (gameVersion == "NTSC-U")
            {
                return true;
            }*/
            if (Memory.ReadString(Addresses.GuidebookText, 9) == "Guidebook")
            {
                gameVersion = "NTSC-U";
                return true;
            } // TODO: Check for PAL, NTSC-J.
            return false;
        }
        public static GameStatus GetGameStatus()
        {
            var status = Memory.ReadByte(Addresses.GameStatus);
            var result = (GameStatus)status;
            if (result != GameStatus.InGame)
            {
                lastNonZeroStatus = result;
            }
            return result;
        }
        public static List<ILocation> BuildLocationList(bool easyFracture=false, bool includeGemsanity=false, List<int> gemsanityIDs = null)
        {
            if (gemsanityIDs == null)
            {
                gemsanityIDs = new List<int>();
            }
            int baseId = 1230000;
            int levelOffset = 1000;
            int processedSkillPoints = 0;
            List<ILocation> locations = new List<ILocation>();
            var currentTalismanAddress = Addresses.TalismanStartAddress;
            var currentOrbAddress = Addresses.OrbStartAddress;
            var currentGemAddress = Addresses.LevelGemsAddress;
            List<LevelData> levels = GetLevelData();
            foreach (var level in levels)
            {
                int locationOffset = 0;
                if (level.HasTalisman)
                {
                    Location location = new Location()
                    {
                        Name = $"{level.Name} Talisman",
                        Id = baseId + levelOffset * level.LevelId + locationOffset,
                        AddressBit = 0,
                        CheckType = LocationCheckType.Bit,
                        Address = currentTalismanAddress,
                        Category = "Talisman"
                    };
                    locations.Add(location);
                    locationOffset++;
                }
                for (int i = 0; i < level.OrbCount; i++)
                {
                    Location location = new Location()
                    {
                        Name = $"{level.Name} Orb {i + 1}",
                        Id = baseId + levelOffset * level.LevelId + locationOffset,
                        AddressBit = i,
                        CheckType = LocationCheckType.Bit,
                        Address = currentOrbAddress,
                        Category = "Orb"
                    };
                    locations.Add(location);
                    locationOffset++;
                }
                if (level.IsBoss)
                {
                    string bossName = level.Name.Split("'")[0];
                    Location location = new Location()
                    {
                        Name = $"{bossName} Defeated",
                        Id = baseId + levelOffset * level.LevelId + locationOffset,
                        AddressBit = 0,
                        CheckType = LocationCheckType.Bit,
                        Address = currentTalismanAddress,
                        Category = "Boss"
                    };
                    locations.Add(location);
                    locationOffset++;
                }
                for (int i = 0; i < level.MoneybagsAddresses.Length; i++)
                {
                    Location moneybagsLocation = new Location()
                    {
                        Name = $"{level.Name}: Moneybags Payment {i}",
                        Id = baseId + levelOffset * level.LevelId + locationOffset,
                        Address = level.MoneybagsAddresses[i] + 2,  // First 2 bytes are price.
                        CheckType = LocationCheckType.Byte,
                        CompareType = LocationCheckCompareType.GreaterThan,
                        CheckValue = "0",
                        Category = "Moneybags"
                    };
                    locations.Add(moneybagsLocation);
                    locationOffset++;
                }
                for (int i = 0; i < level.SkillPointAddresses.Length; i++)
                {
                    Location skillLocation = new Location()
                    {
                        Name = $"{level.Name}: Skill Point {i} (Check)",
                        Id = baseId + levelOffset * level.LevelId + locationOffset,
                        Address = level.SkillPointAddresses[i],
                        CheckType = LocationCheckType.Byte,
                        CompareType = LocationCheckCompareType.GreaterThan,
                        CheckValue = "0",
                        Category = "Skill Point"
                    };
                    locations.Add(skillLocation);
                    locationOffset++;

                    Location skillGoalLocation = new Location()
                    {
                        Name = $"{level.Name}: Skill Point {i} (Goal)",
                        Id = baseId + levelOffset * level.LevelId + locationOffset,
                        Address = level.SkillPointAddresses[i],
                        CheckType = LocationCheckType.Byte,
                        CompareType = LocationCheckCompareType.GreaterThan,
                        CheckValue = "0",
                        Category = "Skill Point"
                    };
                    locations.Add(skillGoalLocation);
                    locationOffset++;
                }
                for (int i = 0; i < level.LifeBottleAddresses.Length; i++)
                {
                    Location lifeBottleLocation = new Location()
                    {
                        Name = $"{level.Name}: Life Bottle {i}",
                        Id = baseId + levelOffset * level.LevelId + locationOffset,
                        Address = level.LifeBottleAddresses[i][0],
                        AddressBit = (int)level.LifeBottleAddresses[i][1],
                        CheckType = LocationCheckType.Bit,
                        Category = "Life Bottle"
                    };
                    locations.Add(lifeBottleLocation);
                    locationOffset++;
                }
                int gemIndex = 1;
                for (int i = 0; i < level.TotalGemCount + level.GemSkipIndices.Length; i++)
                {
                    if (!level.GemSkipIndices.Contains(i + 1))
                    {
                        Location gemsLocation = new Location()
                        {
                            Name = $"{level.Name}: Gem {gemIndex}",
                            Id = baseId + levelOffset * level.LevelId + locationOffset,
                            Address = level.GemMaskAddress + (uint)(i / 8),
                            AddressBit = i % 8,
                            CheckType = LocationCheckType.Bit,
                            Category = "Gemsanity"
                        };
                        if (includeGemsanity && (gemsanityIDs.Count == 0 || gemsanityIDs.Contains(baseId + levelOffset * level.LevelId + locationOffset)))
                        {
                            locations.Add(gemsLocation);
                        }
                        locationOffset++;
                        gemIndex++;
                    }
                }
                if (level.SpiritParticles > 0)
                {
                    if (easyFracture && level.Name == "Fracture Hills")
                    {
                        level.SpiritParticles = level.SpiritParticles - 7;
                    }
                    List<ILocation> conditionsList = new List<ILocation>();
                    Location spiritLocation = new Location()
                    {
                        Name = $"{level.Name}: All Spirit Particles count check",
                        Id = -1,
                        Address = Addresses.SpiritParticlesAddress,
                        CheckType = LocationCheckType.Byte,
                        CompareType = LocationCheckCompareType.GreaterThan,
                        CheckValue = $"{level.SpiritParticles - 1}"
                    };
                    Location levelLocation = new Location()
                    {
                        Name = $"{level.Name}: All Spirit Particles level check",
                        Id = -1,
                        CheckType = LocationCheckType.Byte,
                        Address = Addresses.CurrentLevelAddress,
                        CompareType = LocationCheckCompareType.Match,
                        CheckValue = $"{level.LevelId}",
                    };
                    conditionsList.Add(spiritLocation);
                    conditionsList.Add(levelLocation);

                    CompositeLocation spiritParticlesLocation = new CompositeLocation()
                    {
                        Name = $"{level.Name}: All Spirit Particles",
                        Id = baseId + levelOffset * level.LevelId + locationOffset,
                        CheckType = LocationCheckType.AND,
                        Conditions = conditionsList,
                        Category = "Spirit Particles"
                    };
                    locations.Add(spiritParticlesLocation);
                    locationOffset++;
                }
                if (level.Name == "Dragon Shores")
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Location tokenLocation = new Location()
                        {
                            Name = $"Dragon Shores Token {i}",
                            Id = baseId + levelOffset * level.LevelId + i,
                            Address = Addresses.TokenAddress + (uint)(4 * i),
                            CheckType = LocationCheckType.Byte,
                            CompareType = LocationCheckCompareType.GreaterThan,
                            CheckValue = "0",
                            Category = "Token"
                        };
                        locations.Add(tokenLocation);
                        locationOffset++;
                    }
                }
                currentTalismanAddress++;
                currentOrbAddress++;
            }
            baseId = 1259000;
            for (int i = 0; i < 20; i++)
            {
                Location totalGemLocation = new Location()
                {
                    Name = $"{500 * (i + 1)} Total Gems",
                    Id = baseId + i,
                    CheckType = LocationCheckType.Int,
                    Address = Addresses.TotalGemAddress,
                    CompareType = LocationCheckCompareType.GreaterThan,
                    CheckValue = $"{500 * (i + 1) - 1}",
                    Category = "Total Gems"
                };
                locations.Add(totalGemLocation);
            }
            int offset = 20;
            foreach (var level in levels)
            {
                if (!level.IsBoss)
                {
                    Location gem25Location = new Location()
                    {
                        Name = $"{level.Name}: 25% Gems",
                        Id = baseId + offset,
                        Address = currentGemAddress,
                        CheckType = LocationCheckType.Int,
                        CompareType = LocationCheckCompareType.GreaterThan,
                        CheckValue = "99",
                        Category = "Gem25"
                    };
                    locations.Add(gem25Location);
                    offset++;

                    Location gem50Location = new Location()
                    {
                        Name = $"{level.Name}: 50% Gems",
                        Id = baseId + offset,
                        Address = currentGemAddress,
                        CheckType = LocationCheckType.Int,
                        CompareType = LocationCheckCompareType.GreaterThan,
                        CheckValue = "199",
                        Category = "Gem50"
                    };
                    locations.Add(gem50Location);
                    offset++;

                    Location gem75Location = new Location()
                    {
                        Name = $"{level.Name}: 75% Gems",
                        Id = baseId + offset,
                        Address = currentGemAddress,
                        CheckType = LocationCheckType.Int,
                        CompareType = LocationCheckCompareType.GreaterThan,
                        CheckValue = "299",
                        Category = "Gem75"
                    };
                    locations.Add(gem75Location);
                    offset++;

                    Location gem100Location = new Location()
                    {
                        Name = $"{level.Name}: All Gems",
                        Id = baseId + offset,
                        Address = currentGemAddress,
                        CheckType = LocationCheckType.Int,
                        CompareType = LocationCheckCompareType.GreaterThan,
                        CheckValue = "399",
                        Category = "Gem100"
                    };
                    locations.Add(gem100Location);
                    offset++;
                }
                currentGemAddress += 4;
            }
            return locations;
        }

        public static List<LevelData> GetLevelData()
        {
            List<LevelData> levels = new List<LevelData>()
            {
                new LevelData("Summer Forest", (int)LevelInGameIDs.SummerForest, 4, false, false, [Addresses.SwimUnlock, Addresses.WallToAquariaUnlock], [], [Addresses.SummerLifeBottle1Address, Addresses.SummerLifeBottle2Address, Addresses.SummerLifeBottle3Address], 0, Addresses.SummerGemMask, 138, [27, 39, 41, 42, 43, 44, 45, 46, 47, 61, 62, 72, 73, 81, 82, 95, 96, 97, 98, 99, 100, 108, 126, 127, 128]),
                // Removed Moneybags as a location in Glimmer because it leads to an overly restrictive start.
                new LevelData("Glimmer", (int)LevelInGameIDs.Glimmer, 3, true, false, [], [], [], 14, Addresses.GlimmerGemMask, 133, [1, 2, 3, 4, 5, 6, 126, 127, 128, 129, 130, 131, 132, 133, 134, 135, 136, 137, 138, 152]),
                new LevelData("Idol Springs", (int)LevelInGameIDs.IdolSprings, 2, true, false, [], [Addresses.IdolTikiSkillPoint], [Addresses.IdolLifeBottleAddress], 11, Addresses.IdolGemMask, 149, [63, 88, 90, 122, 127, 134, 135, 136, 137, 138, 139, 140, 141, 142, 143, 144, 145]),
                new LevelData("Colossus", (int)LevelInGameIDs.Colossus, 3, true, false, [], [Addresses.ColossusHockeySkillPoint], [Addresses.ColossusLifeBottleAddress], 13, Addresses.ColossusGemMask, 137, [1, 2, 3, 4, 5, 6, 7, 25, 32, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 71, 117, 118, 119, 127, 162, 163, 164, 165, 166, 167, 168, 169, 170, 171, 172, 173, 174, 175, 176, 177, 178]),
                new LevelData("Hurricos", (int)LevelInGameIDs.Hurricos, 3, true, false, [], [Addresses.HurricosWindmillSkillPoint], [Addresses.HurricosLifeBottleAddress], 22, Addresses.HurricosGemMask, 114, [42, 43, 44, 45, 46, 83, 85, 86, 87, 94, 116, 123, 126, 127, 128, 129, 130, 131]),
                new LevelData("Aquaria Towers", (int)LevelInGameIDs.AquariaTowers, 3, true, false, [Addresses.AquariaSubUnlock], [Addresses.AquariaSeaweedSkillPoint], [Addresses.AquariaLifeBottleAddress], 29, Addresses.AquariaGemMask, 137, [85, 86, 87, 88, 89, 90, 91, 92, 94, 95, 96, 97, 98, 99, 100, 109, 136, 137, 138, 139, 140, 141, 142, 143, 144, 145, 146, 147, 148, 149, 150, 151, 152, 153, 154, 155, 156, 157, 158, 159, 160, 161, 162, 163, 164, 167]),
                new LevelData("Sunny Beach", (int)LevelInGameIDs.SunnyBeach, 3, true, false, [], [], [], 17, Addresses.SunnyGemMask, 118, [1, 2, 3, 4, 5, 6, 53, 91, 105, 106, 107, 109]),
                new LevelData("Ocean Speedway", (int)LevelInGameIDs.OceanSpeedway, 1, false, false, [], [Addresses.OceanTimeAttackSkillPoint], [], 0),
                new LevelData("Crush's Dungeon", (int)LevelInGameIDs.CrushsDungeon, 0, false, true, [], [Addresses.CrushPerfectSkillPoint], [], 0),
                new LevelData("Autumn Plains", (int)LevelInGameIDs.AutumnPlains, 2, false, false, [Addresses.ZephyrPortalUnlock, Addresses.ClimbUnlock, Addresses.ShadyPortalUnlock, Addresses.IcyPortalUnlock], [], [Addresses.AutumnLifeBottleAddress], 0, Addresses.AutumnGemMask, 106, [1, 2, 3, 4, 5, 6, 102, 103, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 123, 124, 125, 126, 127, 128, 129, 130, 131, 132, 133]),
                new LevelData("Skelos Badlands", (int)LevelInGameIDs.SkelosBadlands, 3, true, false, [], [Addresses.SkelosCactiSkillPoint, Addresses.SkelosCatbatSkillPoint], [Addresses.SkelosLifeBottleAddress], 28, Addresses.SkelosGemMask, 95, [1, 2, 3, 48, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122, 123, 124, 125, 126, 127, 128, 129, 130, 131, 132, 133, 134, 135, 136, 138, 139, 140, 141, 142, 143, 144, 155, 156, 157, 158, 159, 160, 161]),
                new LevelData("Crystal Glacier", (int)LevelInGameIDs.CrystalGlacier, 2, true, false, [Addresses.CrystalBridgeUnlock], [], [Addresses.CrystalLifeBottleAddress], 38, Addresses.CrystalGemMask, 105, [1, 2, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71]),
                new LevelData("Breeze Harbor", (int)LevelInGameIDs.BreezeHarbor, 2, true, false, [], [], [Addresses.BreezeLifeBottle1Address, Addresses.BreezeLifeBottle2Address], 16, Addresses.BreezeGemMask, 97, [1, 2, 3, 4, 5, 6, 7, 15, 16, 17, 18, 19, 85, 90, 100, 111, 112]),
                new LevelData("Zephyr", (int)LevelInGameIDs.Zephyr, 4, true, false, [], [], [Addresses.ZephyrLifeBottleAddress], 30, Addresses.ZephyrGemMask, 135, [1, 2, 8, 9, 10, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 105, 107, 117, 135, 136, 137, 138, 139, 140, 141, 142, 143, 144, 149, 150, 151, 153, 167, 168]),
                new LevelData("Metro Speedway", (int)LevelInGameIDs.MetroSpeedway, 1, false, false, [], [Addresses.MetroTimeAttackSkillPoint], [], 0),
                new LevelData("Scorch", (int)LevelInGameIDs.Scorch, 2, true, false, [], [Addresses.ScorchTreesSkillPoint], [Addresses.ScorchLifeBottleAddress], 28, Addresses.ScorchGemMask, 125, [1, 2, 3, 4, 5, 93, 94, 95, 96, 97, 98, 99, 100, 101, 106, 115, 134, 135, 136, 137, 142, 143, 144, 148]),
                new LevelData("Shady Oasis", (int)LevelInGameIDs.ShadyOasis, 2, true, false, [], [], [Addresses.ShadyLifeBottleAddress], 21, Addresses.ShadyGemMask, 119, [1, 2, 3, 4, 5, 6, 7, 28, 29, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122, 123, 124, 138, 140, 141, 142, 143, 148, 155, 168, 169]),
                new LevelData("Magma Cone", (int)LevelInGameIDs.MagmaCone, 3, true, false, [Addresses.MagmaElevatorUnlock], [], [Addresses.MagmaLifeBottle1Address, Addresses.MagmaLifeBottle2Address, Addresses.MagmaLifeBottle3Address, Addresses.MagmaLifeBottle4Address], 19, Addresses.MagmaGemMask, 119, [1, 2, 48, 78, 121, 122, 123]),
                new LevelData("Fracture Hills", (int)LevelInGameIDs.FractureHills, 3, true, false, [], [Addresses.FractureSuperchargeSkillPoint], [Addresses.FractureLifeBottleAddress], 29, Addresses.FractureGemMask, 115, [1, 2, 3, 20, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 141]),
                new LevelData("Icy Speedway", (int)LevelInGameIDs.IcySpeedway, 1, false, false, [], [Addresses.IcyTimeAttackSkillPoint], [], 0),
                new LevelData("Gulp's Overlook", (int)LevelInGameIDs.GulpsOverlook, 0, false, true, [], [Addresses.GulpPerfectSkillPoint, Addresses.GulpRiptoSkillPoint], [], 0),
                new LevelData("Winter Tundra", (int)LevelInGameIDs.WinterTundra, 3, false, false, [Addresses.CanyonPortalUnlock, Addresses.HeadbashUnlock], [], [], 0, Addresses.WinterGemMask, 101, [1, 2, 3, 4, 5, 6, 7, 13, 14, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122, 123, 124, 125, 126, 127, 128, 129, 130, 131, 132, 133, 134, 135, 136, 137, 138, 139, 140, 141, 142, 143]),
                new LevelData("Mystic Marsh", (int)LevelInGameIDs.MysticMarsh, 3, false, false, [], [], [Addresses.MysticLifeBottle1Address, Addresses.MysticLifeBottle2Address], 36, Addresses.MysticGemMask, 139, [1, 112, 113, 114, 115, 143, 144, 145, 146, 147, 148, 149, 150, 151, 152, 153, 154, 155, 156, 157]),
                new LevelData("Cloud Temples", (int)LevelInGameIDs.CloudTemples, 3, false, false, [], [], [Addresses.CloudLifeBottleAddress], 23, Addresses.CloudGemMask, 111, [1, 34, 54, 55, 101, 102, 103]),
                new LevelData("Canyon Speedway", (int)LevelInGameIDs.CanyonSpeedway, 1, false, false, [], [Addresses.CanyonTimeAttackSkillPoint], [], 0),
                new LevelData("Robotica Farms", (int)LevelInGameIDs.RoboticaFarms, 3, false, false, [], [], [], 20, Addresses.RoboticaGemMask, 127, [1, 2, 3, 4, 5, 6, 7, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 107, 108, 130, 138, 139, 147, 148, 149, 150, 151, 152, 179, 180, 181, 182, 183]),
                new LevelData("Metropolis", (int)LevelInGameIDs.Metropolis, 4, false, false, [], [], [], 22, Addresses.MetropolisGemMask, 126, [38, 45, 65, 91, 97, 105, 129, 130, 131, 132]),
                new LevelData("Dragon Shores", (int)LevelInGameIDs.DragonShores, 0, false, false, [], [], [], 0),
                new LevelData("Ripto's Arena", (int)LevelInGameIDs.RiptosArena, 0, false, true, [], [Addresses.RiptoPerfectSkillPoint], [], 0),
            };
            return levels;
        }
    }
}
