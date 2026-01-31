using System.Collections.Generic;

namespace MMLAP
{
    public static class Addresses
    {
        public const uint TotalTalismanAddress = 0x00067108;
        public const uint TotalOrbAddress = 0x0006702c;
        public const uint TalismanStartAddress = 0x0006b264; // Starts with Summer Forest!
        public const uint OrbStartAddress = 0x00069fd0; // Includes bytes for levels with no orbs!
        public const uint CurrentLevelAddress = 0x00066f54;
        public const uint IsInDemoMode = 0x00067024; // 0x00067044 seems to behave similarly but is 0 on the Demo mode guidebook screen.
        public const uint GameStatus = 0x000681c8;
        // The values at this and the following 3 bytes seem to be 0 only on reset.
        public const uint ResetCheckAddress = 0x00066f14;
        public const uint PlayerLives = 0x0006712c;
        public const uint PlayerHealth = 0x0006a248;
        public const uint SpiritParticlesAddress = 0x00066fb0;

        public const uint PlayerZPos = 0x69FF8;
        public const uint PlayerAnimationLength = 0x6A04C;
        public const uint PlayerVelocityStatus = 0x6A044;

        public const uint RiptoDoorOrbRequirementAddress = 0x0007695c;
        public const uint RiptoDoorOrbDisplayAddress = 0x000769e0;

        public const uint TotalGemAddress = 0x000670cc; // 0x00067660 is the HUD display; may need to be edited if this value is modified.
        public const uint LevelGemsAddress = 0x0006ac04; // One entire word per level, including boss levels.

        public const uint SkelosCactiSkillPoint = 0x0006470c;
        public const uint HurricosWindmillSkillPoint = 0x0006470d;
        public const uint ColossusHockeySkillPoint = 0x0006470e;
        public const uint FractureSuperchargeSkillPoint = 0x0006470f;
        public const uint CrushPerfectSkillPoint = 0x00064711;
        public const uint GulpPerfectSkillPoint = 0x00064712;
        public const uint RiptoPerfectSkillPoint = 0x00064713;
        public const uint ScorchTreesSkillPoint = 0x00064714;
        public const uint OceanTimeAttackSkillPoint = 0x00064715;
        public const uint MetroTimeAttackSkillPoint = 0x00064716;
        public const uint IcyTimeAttackSkillPoint = 0x00064717;
        public const uint CanyonTimeAttackSkillPoint = 0x00064718;
        public const uint IdolTikiSkillPoint = 0x00064719;
        public const uint AquariaSeaweedSkillPoint = 0x0006471a;
        public const uint GulpRiptoSkillPoint = 0x0006471b;
        public const uint SkelosCatbatSkillPoint = 0x0006471c;

        public const uint TokenAddress = 0x000646be; // Each token gets 1 word, but a value of 1 on this byte determines if it's collected.

        public const uint SpyroStateAddress = 0x0006a040; // One byte, set to 31 in decimal to kill Spyro for Death Link.

        public const uint BigHeadMode = 0x0698be;
        public const uint FlatSpyroMode = 0x0698bf;
        public const uint SpyroWidth = 0x0698c1;
        public const uint SpyroHeight = 0x0698c5;
        public const uint SpyroLength = 0x0698c9;
        public const uint SpyroColorAddress = 0x0698cc;
        public const uint PortalTextRed = 0x00064468;
        public const uint PortalTextGreen = 0x00064469;
        public const uint PortalTextBlue = 0x0006446a;

        public const uint RedGemShadow = 0x00064450;
        public const uint RedGemColor = 0x00064454;
        public const uint GreenGemShadow = 0x00064460;
        public const uint GreenGemColor = 0x00064464;
        public const uint BlueGemShadow = 0x00064470;
        public const uint BlueGemColor = 0x00064474;
        public const uint GoldGemShadow = 0x00064480;
        public const uint GoldGemColor = 0x00064484;
        public const uint PinkGemShadow = 0x00064490;
        public const uint PinkGemColor = 0x00064494;

        public const uint PermanentFireballAddress = 0x000698bb;
        public const uint DoubleJumpAddress1 = 0x00035ba8;
        public const uint DoubleJumpAddress2 = 0x00035bb8;
        public const uint InvisibleAddress1 = 0x0004c584;
        public const uint InvisibleAddress2 = 0x0004c586;
        public const uint DestructiveSpyroAddress = 0x0006a12a;

        public const uint CrystalBridgeUnlock = 0x00064670;
        public const uint AquariaSubUnlock = 0x00064674;
        public const uint MagmaElevatorUnlock = 0x00064678;
        public const uint GlimmerBridgeUnlock = 0x0006467c;
        public const uint SwimUnlock = 0x00064680;
        public const uint ClimbUnlock = 0x00064684;
        public const uint HeadbashUnlock = 0x00064688;
        public const uint WallToAquariaUnlock = 0x0006468c;
        public const uint ZephyrPortalUnlock = 0x00064698;
        public const uint ShadyPortalUnlock = 0x0006469c;
        public const uint IcyPortalUnlock = 0x000646a0;
        public const uint CanyonPortalUnlock = 0x000646b8;

        public const uint SummerEloraStartText = 0x001818cb;
        public const uint SummerEloraEndText = 0x00181973;
        public const uint SummerEloraWarpStartText = 0x00181a70;
        public const uint SummerEloraWarpEndText = 0x00181abb;

        public const uint AutumnEloraStartText = 0x00191813;
        public const uint AutumnEloraEndText = 0x001918b8;
        public const uint AutumnEloraWarpStartText = 0x00191a84;
        public const uint AutumnEloraWarpEndText = 0x00191acf;

        public static readonly List<uint> SummerLifeBottle1Address = [0x0006ac8f, 7];
        public static readonly List<uint> SummerLifeBottle2Address = [0x0006ac90, 0];
        public static readonly List<uint> SummerLifeBottle3Address = [0x0006ac8b, 6];
        public static readonly List<uint> IdolLifeBottleAddress = [0x0006acd3, 1];
        public static readonly List<uint> ColossusLifeBottleAddress = [0x0006acfc, 6];
        public static readonly List<uint> HurricosLifeBottleAddress = [0x0006ad0f, 5];
        public static readonly List<uint> AquariaLifeBottleAddress = [0x0006ad2f, 5];
        public static readonly List<uint> AutumnLifeBottleAddress = [0x0006adb3, 6];
        public static readonly List<uint> SkelosLifeBottleAddress = [0x0006ade0, 3];
        public static readonly List<uint> CrystalLifeBottleAddress = [0x0006adff, 7];
        public static readonly List<uint> BreezeLifeBottle1Address = [0x0006ae21, 7];
        public static readonly List<uint> BreezeLifeBottle2Address = [0x0006ae22, 4];
        public static readonly List<uint> ZephyrLifeBottleAddress = [0x0006ae3c, 5];
        public static readonly List<uint> ScorchLifeBottleAddress = [0x0006ae78, 2];
        public static readonly List<uint> ShadyLifeBottleAddress = [0x0006ae93, 5];
        public static readonly List<uint> MagmaLifeBottle1Address = [0x0006aeb9, 0];
        public static readonly List<uint> MagmaLifeBottle2Address = [0x0006aeba, 0];
        public static readonly List<uint> MagmaLifeBottle3Address = [0x0006aeba, 1];
        public static readonly List<uint> MagmaLifeBottle4Address = [0x0006aeba, 2];
        public static readonly List<uint> FractureLifeBottleAddress = [0x0006aee1, 0];
        public static readonly List<uint> MysticLifeBottle1Address = [0x0006af61, 4];
        public static readonly List<uint> MysticLifeBottle2Address = [0x0006af61, 5];
        public static readonly List<uint> CloudLifeBottleAddress = [0x0006af72, 1];

        public const uint SummerGemMask = 0x0006ac84;
        public const uint GlimmerGemMask = 0x0006acaa;
        public const uint IdolGemMask = 0x0006acc4;
        public const uint ColossusGemMask = 0x0006ace7;
        public const uint HurricosGemMask = 0x0006ad04;
        public const uint AquariaGemMask = 0x0006ad24;
        public const uint SunnyGemMask = 0x0006ad4d;
        public const uint AutumnGemMask = 0x0006ada7;
        public const uint SkelosGemMask = 0x0006adcc;
        public const uint CrystalGemMask = 0x0006adf1;
        public const uint BreezeGemMask = 0x0006ae14;
        public const uint ZephyrGemMask = 0x0006ae2b;
        public const uint ScorchGemMask = 0x0006ae6c;
        public const uint ShadyGemMask = 0x0006ae88;
        public const uint MagmaGemMask = 0x0006aeaa;
        public const uint FractureGemMask = 0x0006aecf;
        public const uint WinterGemMask = 0x0006af25;
        public const uint MysticGemMask = 0x0006af4d;
        public const uint CloudGemMask = 0x0006af6e;
        public const uint RoboticaGemMask = 0x0006afac;
        public const uint MetropolisGemMask = 0x0006afca;

        public const uint localGemIncrementAddress = 0x000396C0;
        public const uint globalGemIncrementAddress = 0x000396d4;
        public const uint globalGemRespawnFixAddress = 0x0001d36c;
        public const uint localGemRespawnFixAddress = 0x0001d380;
        public const uint localGemLoadFixAddress = 0x00076B98;
        public const uint globalGemLoadFixAddress = 0x00076BA0;

        public const uint SummerPortalBlock = 0x000e2d34;
        public const uint AutumnPortalBlock = 0x000f5330;
        public const uint WinterPortalBlock = 0x000cf28c;

        public const uint CrushGuidebookUnlock = 0x0006B08C;
        public const uint AutumnGuidebookUnlock = 0x0006B08D;
        public const uint GulpGuidebookUnlock = 0x0006B098;
        public const uint WinterGuidebookUnlock = 0x0006B099;

        public const uint IdolPortalAddress = 0x001757C8;
        public const uint ColossusPortalAddress = 0x00175668;
        public const uint HurricosPortalAddress = 0x001756c0;
        public const uint AquariaPortalAddress = 0x00175770;
        public const uint SunnyPortalAddress = 0x00175718;
        public const uint OceanPortalAddress = 0x00179A20;

        public const uint IdolNameAddress = 0x000106d0;
        public const uint ColossusNameAddress = 0x000106c4;
        public const uint HurricosNameAddress = 0x000106b8;
        public const uint AquariaNameAddress = 0x000106a8;
        public const uint SunnyNameAddress = 0x0001069c;
        public const uint OceanNameAddress = 0x0001068c;
        public const uint SkelosNameAddress = 0x0001065c;
        public const uint CrystalNameAddress = 0x0001064c;
        public const uint BreezeNameAddress = 0x0001063c;
        public const uint ZephyrNameAddress = 0x00066e98;
        public const uint MetroNameAddress = 0x0001062c;
        public const uint ScorchNameAddress = 0x00066e90;
        public const uint ShadyNameAddress = 0x00010620;
        public const uint MagmaNameAddress = 0x00010614;
        public const uint FractureNameAddress = 0x00010604;
        public const uint IcyNameAddress = 0x000105f4;
        public const uint MysticNameAddress = 0x000105c4;
        public const uint CloudNameAddress = 0x000105b4;
        public const uint CanyonNameAddress = 0x000105a4;
        public const uint RoboticaNameAddress = 0x00010594;
        public const uint MetropolisNameAddress = 0x00010588;
        public const uint ShoresNameAddress = 0x00010578;

        public const uint ColossusSpyroHockeyScore = 0x00198ec5;
        public const uint ColossusOpponentHockeyScore = 0x00198cc9;
        public const uint IdolFishThrowUp = 0x00082010;
        public const uint IdolFishIncludeReds = 0x00082048;
        public const uint IdolFishIncludeRedsHUD = 0x0007efe0;
        public static readonly List<uint> HurricosLightningThiefStatuses = [
            0x18C8DC,
            0x18CB44,
            0x18CBF4,
            0x18CCA4,
            0x18CCFC,
            0x18CD54,
            0x18CDAC,
            0x18CE04,
            0x18CF0C,
            0x18CFBC
        ];
        public static readonly List<uint> HurricosLightningThiefZCoordinates = [
            0x18C8A8,
            0x18CB10,
            0x18CBC0,
            0x18CC70,
            0x18CCC8,
            0x18CD20,
            0x18CD78,
            0x18CDD0,
            0x18CED8,
            0x18CF88
        ];
        public const uint spyroHUDScore = 0x00066FEC;
        public const uint opponentHUDScore = 0x67084;
        public const uint firstBomboStatus = 0x189f3d;
        public const uint secondBomboStatus = 0x189b75;
        public const uint thirdBomboStatus = 0x189805;
        public const uint bomboAttackAddress = 0x79b34;
        public const uint fractureHeadbashCheck = 0x78a88;
        public const uint maxFractureSpiritParticles = 0x64826;
        public static readonly List<uint> FractureEarthshaperStatuses = [
            0x188DEC,
            0x188E44,
            0x188E9C,
            0x188EF4,
            0x188F4C,
            0x188FA4,
            0x188FFC
        ];
        public static readonly List<uint> FractureEarthshaperZCoordinates = [
            0x188DB8,
            0x188E10,
            0x188E68,
            0x188EC0,
            0x188F18,
            0x188F70,
            0x188FC8
        ];
        public static uint ShadyHeadbashCheck = 0x7d6c0;
        public static uint GulpDoubleDamage = 0x120c5e;

        public const uint GuidebookText = 0x00010308;

        public const uint AnalogReadAddressOne = 0x12320;
        public const uint AnalogReadAddressTwo = 0x12324;
        public const uint ControllerReadLeftHalf = 0x122fc;
        public const uint ControllerReadRightHalf = 0x12304;
    }
}
