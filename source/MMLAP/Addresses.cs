using MMLAP.Models;

namespace MMLAP
{
    public static class Addresses
    {
        // Player status
        public static readonly AddressData CurrentZenny = new(0xC1B2C, null, 4);
        public static readonly AddressData UnequippedBusterInvStart = new(0xB5604, null, 34);
        // Goals
        public static readonly AddressData GoalJunoFlag = new(0xBE385, 3, null);
        // Conditions for enabling locations
        public static readonly AddressData ScreenWipeFlag = new(0x1FF3E2, 0, null);
        public static readonly AddressData LoadingFlag = new(0x98A70, 0, null);
        public static readonly AddressData CutsceneFlag = new(0x98008, 0, null);
        public static readonly AddressData DungeonMapFlag = new(0x1B80AB, 3, null);
        public static readonly AddressData PauseMenuFlag = new(0x1B8017, 2, null);
        public static readonly AddressData SaveDataMenuFlag = new(0x98910, 0, null);
        public static readonly AddressData TitleScreen = new(0x98158, null, 1); // 0xA4 = Cutscenes and in-game
    }
}