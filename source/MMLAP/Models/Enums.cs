namespace S2AP.Models
{
    public class Enums
    {
        public enum GameStatus
        {
            InGame = 0,
            Talking = 1,
            Spawning = 3,
            Paused = 4,
            Loading = 5,
            Cutscene = 6,
            LoadingWorld = 7,
            TitleScreen = 11
        }

        public enum CompletionGoal
        {
            Ripto = 0,
            FourteenTali = 1,
            FortyOrb = 2,
            SixtyFourOrb = 3,
            HundredPercent = 4,
            TenTokens = 5,
            AllSkillpoints = 6,
            Epilogue = 7
        }

        public enum SpyroColor : short
        {
            SpyroColorDefault = 0,
            SpyroColorRed = 1,
            SpyroColorBlue = 2,
            SpyroColorPink = 3,
            SpyroColorGreen = 4,
            SpyroColorYellow = 5,
            SpyroColorBlack = 6
        }

        public enum MoneybagsOptions
        {
            Vanilla = 0,
            PriceShuffle = 1,
            Moneybagssanity = 2
        }

        public enum GemsanityOptions
        {
            Off = 0,
            Partial = 1,
            Full = 2,
            FullGlobal = 3
        }

        public enum ProgressiveSparxHealthOptions
        {
            Off = 0,
            Blue = 1,
            Green = 2,
            Sparxless = 3,
            TrueSparxless = 4
        }

        public enum AbilityOptions
        {
            Vanilla = 0,
            InPool = 1,
            AlwaysOff = 2,
            StartWith = 3
        }

        public enum BomboOptions
        {
            Vanilla = 0,
            ThirdOnly = 1,
            FirstOnly = 2,
            FirstOnlyNoAttack = 3
        }

        public enum PortalTextColor
        {
            Default = 0,
            Red = 1,
            Green = 2,
            Blue = 3,
            Pink = 4,
            White = 5
        }

        public enum ImportantLocationIDs : int
        {
            RiptoDefeated = 1258000
        }

        // NOTE: This corresponds specifically to 0x00066f54.
        // Other addresses use a different set of non-incremental values, starting at 0x0a.
        public enum LevelInGameIDs : byte
        {
            SummerForest = 0,
            Glimmer = 1,
            IdolSprings = 2,
            Colossus = 3,
            Hurricos = 4,
            AquariaTowers = 5,
            SunnyBeach = 6,
            OceanSpeedway = 7,
            CrushsDungeon = 8,
            AutumnPlains = 9,
            SkelosBadlands = 10,
            CrystalGlacier = 11,
            BreezeHarbor = 12,
            Zephyr = 13,
            MetroSpeedway = 14,
            Scorch = 15,
            ShadyOasis = 16,
            MagmaCone = 17,
            FractureHills = 18,
            IcySpeedway = 19,
            GulpsOverlook = 20,
            WinterTundra = 21,
            MysticMarsh = 22,
            CloudTemples = 23,
            CanyonSpeedway = 24,
            RoboticaFarms = 25,
            Metropolis = 26,
            DragonShores = 27,
            RiptosArena = 28
        }

        public enum SpyroStates : byte
        {
            Flop = 6,
            Bonk = 13,
            DeathDrowning = 30,
            DeathPirouette = 31,
            DeathSquash = 32,
            DeathBurn = 58,
        }

        public enum LevelLockOptions : int
        {
            Vanilla = 0,
            Keys = 1,
            Orbs = 2,
        }
    }
}
