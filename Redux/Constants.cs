using System.Collections.Generic;
namespace Redux
{
    public static class Constants
    {

        #region Items ID's
        public const uint
            EXEMPTION_TOKEN_ID = 723701,
            Emerald_ID = 1080001,
            DragonBall_Scroll_ID = 720028,
            DragonBall_ID = 1088000,
            Meteor_Scroll_ID = 720027,
            Meteor_ID = 1088001,
            Meteor_Tear_ID = 1088002,
            MoonBox_ID = 721020,
            Celestial_Stone_ID = 721259,
            StoneOne_ID = 730001,
            StoneTWO_ID = 730002,
            StoneThree_ID = 730003,
            StoneFour_ID = 730004,
            StoneFive_ID = 730005,
            StoneSix_ID = 730006,
            StoneSeven_ID = 730007,
            StoneEight_ID = 730008,
            Plus1StonePack_ID = 723712,
            BeginnerPackLv1_ID = 723753,
            BeginnerPackLv5_ID = 723754,
            BeginnerPackLv10_ID = 723755,
            BeginnerPackLv15_ID = 723756,
            BeginnerPackLv20_ID = 723757,
            BeginnerPackLv25_ID = 723758,
            BeginnerPackLv30_ID = 723759,
            BeginnerPackLv35_ID = 723760,
            BeginnerPackLv40_ID = 723761,
            BeginnerPackLv45_ID = 723762,
            BeginnerPackLv50_ID = 723763,
            BeginnerPackLv55_ID = 723764,
            BeginnerPackLv60_ID = 723765,
            BeginnerPackLv65_ID = 723766,
            BeginnerPackLv70_ID = 723767,
            BeginnerPackLv75_ID = 723768,
            BeginnerPackLv80_ID = 723769,
            BeginnerPackLv90_ID = 723770,
            BeginnerPackLv95_ID = 723771,
            BeginnerPackLv100_ID = 723772,
            BeginnerPackLv105_ID = 723773,
            BeginnerPackLv110_ID = 723774,
            BeginnerPackLv115_ID = 723775,
            BeginnerPackLv120_ID = 723776,
            Class1MoneyBag_ID = 723713,
            Class2MoneyBag_ID = 723714,
            Class3MoneyBag_ID = 723715,
            Class4MoneyBag_ID = 723716,
            Class5MoneyBag_ID = 723717,
            Class6MoneyBag_ID = 723718,
            Class7MoneyBag_ID = 723719,
            Class8MoneyBag_ID = 723720,
            Class9MoneyBag_ID = 723721,
            Class10MoneyBag_ID = 723722,
            CPMiniBag_ID = 729910,
            CPBag_ID = 729911,
            CPBackpack_ID = 729912,
            TopMoneyBag_ID = 723723,
            ExpPotion_ID = 723017,
            ExpBall_ID = 723700,
            DefensePot_15m_ID = 721624,
            AttackPot_30m_ID = 721625,
            DefensePot_30m_ID = 721626,
            AttackPot_45m_ID = 721627,
            DefensePot_45m_ID = 721628,
            CloudSaintsLet_ID = 729904,
            CloudSaintsJar_ID = 750000;
        #endregion
        public static readonly List<ulong>

              FBSSMap = new List<ulong>()
              {
                1509,
                1505

              };
        public const int EXP_BALL_LIMIT = 10;
        public const uint EMERALD_ID = 1080001, DB_SCROLL_ID = 720028, DRAGONBALL_ID = 1088000, METEOR_SCROLL_ID = 720027, METEOR_ID = 1088001, METEOR_TEAR_ID = 1088002, MOONBOX_ID = 721020, CELESTIAL_STONE_ID = 721259;
        public const bool IsSameSexMarriageAllowed = false;
        public const int EXP_RATE = 9,
                              PROF_RATE = 7,
                              SKILL_RATE = 7,
                              GOLD_RATE = 6;

        public const double SOCKET_RATE = .4,
             CHANCE_PLUS = 2.0,
            CHANCE_METEOR = 0.72,
            CHANCE_DRAGONBALL = 0.0556,
            CHANCE_POTION = 4;


        public static bool DEBUG_MODE;
        public const byte RESPONSE_INVALID = 1,
                          RESPONSE_VALID = 2,
                          RESPONSE_BANNED = 12,
                          RESPONSE_INVALID_ACCOUNT = 57;
        public const int IPSTR_SIZE = 16,
                            MACSTR_SIZE = 12,
                            MAX_NAMESIZE = 16,
                            MAX_BROADCASTSIZE = 80,
                            MAX_USERFRIENDSIZE = 50,
                            MAX_ENEMYSIZE = 10,
                            MAX_TRADEITEMS = 20,
                            MAX_TRADEMONEY = 100000000,
                            MAX_TEAMAMOUNT = 5,
                            MAX_ADDITION = 12,
                            MAX_GUILDALLYSIZE = 5,
                            MAX_GUILDENEMYSIZE = 5;
        public const ushort BOOTH_LOOK = 407;
        public const ushort
            MSG_REGISTER = 1001,
            MSG_TALK = 1004,
            MSG_WALK = 1005,
            MSG_HERO_INFORMATION = 1006,
            MSG_ITEM_INFORMATION = 1008,
            MSG_ITEM_ACTION = 1009,
            MSG_ACTION = 1010,
            MSG_STRINGS = 1015,
            MSG_UPDATE = 1017,
            MSG_ASSOCIATE = 1019,
            MSG_INTERACT = 1022,
            MSG_TEAM_INTERACT = 1023,
            MSG_ASSIGN_ATTRIBUTES = 1024,
            MSG_PROFICIENCY = 1025,
            MSG_TEAMMEMBER_INFO = 1026,
            MSG_SOCKET_GEM = 1027,
            MSG_DATE_TIME = 1033,
            MSG_CONNECT = 1052,
            MSG_TRADE = 1056,
            MSG_GROUND_ITEM = 1101,
            MSG_WAREHOUSE_ACTION = 1102,
            MSG_CONQUER_SKILL = 1103,
            MSG_SKILL_EFFECT = 1105,
            MSG_GUILD_REQUEST = 1107,
            MSG_EXAMINE_ITEM = 1108,
            MSG_MESSAGE_BOARD = 1111,
            MSG_NPC_SPAWN = 2030,
            MSG_NPC_INITIAL = 2031,
            MSG_NPC_DIALOG = 2032,
            MSG_ASSOCIATE_INFO = 2033,
            MSG_COMPOSE = 2036,
            MSG_OFFLINETG = 2044,
            MSG_BROADCAST = 2050,
            MSG_GUILDMEMBERINFO = 1112,
            MSG_NOBILITY = 2064,
            MSG_MENTORACTION = 2065,
            MSG_MENTORINFO = 2066,
            MSG_MENTORPRIZE = 2067;

        public const int TIME_ADJUST_HOUR = -5,
            TIME_ADJUST_MIN = 0,
            TIME_ADJUST_SEC = 0;

        public static int LOGIN_PORT = 9959;
        public static int GAME_PORT = 5816;
        public static uint MINUTES_BANNED_BRUTEFORCE = 30;
        public static uint MAX_CONNECTIONS_PER_MINUTE = 10;

        public static string GAME_IP = "0.0.0.0",
                             SERVER_NAME = "Redux_Beta";

        public const string SYSTEM_NAME = "SYSTEM",
                            ALLUSERS_NAME = "ALLUSERS",
                            REPLY_OK_STR = "ANSWER_OK",
                            REPLAY_AGAIN_STR = "ANSWER_AGAIN",
                            NEW_ROLE_STR = "NEW_ROLE",
                            DEFAULT_MATE = "None";

        public const int STAT_MAXLIFE_STR = 3, STAT_MAXLIFE_AGI = 3, STAT_MAXLIFE_VIT = 24, STAT_MAXLIFE_SPI = 3; 
        public const int STAT_MAXMANA_STR = 0, STAT_MAXMANA_AGI = 0, STAT_MAXMANA_VIT = 0, STAT_MAXMANA_SPI = 5;

        public static readonly byte[] RC5_PASSWORDKEY = new byte[]
                                                            {
                                                                0x3c, 0xdc, 0xfe, 0xe8, 0xc4, 0x54, 0xd6, 0x7e,
                                                                0x16, 0xa6, 0xf8, 0x1a, 0xe8, 0xd0, 0x38, 0xbe
                                                            };
        public const int RC5_32 = 32,
                         RC5_12 = 12,
                         RC5_SUB = RC5_12 * 2 + 2,
                         RC5_16 = 16,
                         RC5_KEY = RC5_16 / 4;

        public const uint RC5_PW32 = 0xb7e15163, RC5_QW32 = 0x9e3779b9; 
        public const char COMMAND_PREFIX = '/';

        public const string GM_ID = "GM",
                            PM_ID = "PM",
                            GM_TAG = "[" + GM_ID + "]",
                            PM_TAG = "[" + PM_ID + "]";
  
        public static readonly uint[] ProficiencyLevelExperience = new uint[] { 0, 1200, 68000, 250000, 640000, 1600000, 4000000, 10000000, 22000000, 40000000, 90000000, 95000000, 142500000, 213750000, 320625000, 480937500, 721406250, 1082109375, 1623164063, 2100000000, 0 };
        public static readonly string[] GemEffectsByID = new string[] { "phoenix", "goldendragon", "lounder1", "rainbow", "goldenkylin", "purpleray", "moon", "recovery", };
    }
}
