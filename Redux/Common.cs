using System;
using System.Linq;
using System.Text;
using Redux.Enum;
using Redux.Structures;
using Redux.Utility;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TinyMap;


namespace Redux
{
    public static class Common
    {
        static Common()
        {
            UnixEpoch = new DateTime(1970, 1, 1);
            Random = new ThreadSafeRandom();
            _clock = Stopwatch.StartNew();
            ENCRYPTION_KEY = Encoding.ASCII.GetBytes("DR654dt34trg4UI6");
            SERVER_SEAL = Encoding.ASCII.GetBytes("TQServer");
            ValidChars = new Regex("^[a-zA-Z0-9]{4,16}$");
            DeltaX = new sbyte[] { 0, -1, -1, -1, 0, 1, 1, 1, 0 };
            DeltaY = new sbyte[] { 1, 1, 0, -1, -1, -1, 0, 1, 0 };
            _trojanLifeBonus = new[] { 100, 105, 108, 110, 112, 115 };
            _taoistManaBonus = new[] { 100, 100, 300, 400, 500, 600 };
            MapService = new TinyMapServer
            {
                ConquerDirectory = "",
                ExtractDMaps = false,
                LoadPortals = true,
                LoadHeight = true,
                Threading = true,
            };
            MapService.Load();
            LotteryItemsList = new List<Tuple<uint, LotteryItemType, string, LotteryInternalOdds>>()
            {
                #region All LOTTERY ITEMS !
                // 5% 5
                #region Elite1Socket
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(142028, LotteryItemType.Elite1Socket,
                    "VioletPlume", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(141058, LotteryItemType.Elite1Socket,
                    "FiresilkBand", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(133048, LotteryItemType.Elite1Socket,
                    "ApeCoat", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(134058, LotteryItemType.Elite1Socket,
                    "PowerGown", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(160098, LotteryItemType.Elite1Socket,
                    "LightBoots", LotteryInternalOdds.low),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(152108, LotteryItemType.Elite1Socket,
                    "VioletBracelet", LotteryInternalOdds.low),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(151098, LotteryItemType.Elite1Socket,
                    "BoneHeavyRing", LotteryInternalOdds.low),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(150098, LotteryItemType.Elite1Socket,
                    "IvoryRing", LotteryInternalOdds.low),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(480098, LotteryItemType.Elite1Socket,
                    "WarClub", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(460098, LotteryItemType.Elite1Socket,
                    "MelonHammer", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(450098, LotteryItemType.Elite1Socket,
                    "PeaceAxe", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(440098, LotteryItemType.Elite1Socket,
                    "TwinWhip", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(430098, LotteryItemType.Elite1Socket,
                    "AntlerHook", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(421088, LotteryItemType.Elite1Socket,
                    "IronBacksword", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(420098, LotteryItemType.Elite1Socket,
                    "FangSword", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(410098, LotteryItemType.Elite1Socket,
                    "MoonBlade", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(900018, LotteryItemType.Elite1Socket,
                    "RattanShield", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(561098, LotteryItemType.Elite1Socket,
                    "ShaolinWand", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(560098, LotteryItemType.Elite1Socket,
                    "LuckSpear", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(540108, LotteryItemType.Elite1Socket,
                    "GiantLongHammer", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(530098, LotteryItemType.Elite1Socket,
                    "TwinPoleaxe", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(510098, LotteryItemType.Elite1Socket,
                    "UnionGlaive", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(490098, LotteryItemType.Elite1Socket,
                    "CaoDagger", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(481098, LotteryItemType.Elite1Socket,
                    "WishScepter", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(113038, LotteryItemType.Elite1Socket,
                    "LeopardHat", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(114058, LotteryItemType.Elite1Socket,
                    "LotusCap", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(117048, LotteryItemType.Elite1Socket,
                    "TasselEarring", LotteryInternalOdds.low),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(118058, LotteryItemType.Elite1Socket,
                    "GoldCoronet", LotteryInternalOdds.low),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(120098, LotteryItemType.Elite1Socket,
                    "GoldNecklace", LotteryInternalOdds.low),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(121128, LotteryItemType.Elite1Socket,
                    "AmbergrisBag", LotteryInternalOdds.low),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(130058, LotteryItemType.Elite1Socket,
                    "DemonArmor", LotteryInternalOdds.low),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(131058, LotteryItemType.Elite1Socket,
                    "ChainedArmor", LotteryInternalOdds.low),

                #endregion
                // 4% 9
                #region Elite2Socket
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(142028, LotteryItemType.Elite2Socket,
                    "VioletPlume", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(141058, LotteryItemType.Elite2Socket,
                    "FiresilkBand", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(133048, LotteryItemType.Elite2Socket,
                    "ApeCoat", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(134058, LotteryItemType.Elite2Socket,
                    "PowerGown", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(160098, LotteryItemType.Elite2Socket,
                    "LightBoots", LotteryInternalOdds.low),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(152108, LotteryItemType.Elite2Socket,
                    "VioletBracelet", LotteryInternalOdds.low),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(151098, LotteryItemType.Elite2Socket,
                    "BoneHeavyRing", LotteryInternalOdds.low),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(150098, LotteryItemType.Elite2Socket,
                    "IvoryRing", LotteryInternalOdds.low),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(480098, LotteryItemType.Elite2Socket,
                    "WarClub", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(460098, LotteryItemType.Elite2Socket,
                    "MelonHammer", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(450098, LotteryItemType.Elite2Socket,
                    "PeaceAxe", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(440098, LotteryItemType.Elite2Socket,
                    "TwinWhip", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(430098, LotteryItemType.Elite2Socket,
                    "AntlerHook", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(421088, LotteryItemType.Elite2Socket,
                    "IronBacksword", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(420098, LotteryItemType.Elite2Socket,
                    "FangSword", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(410098, LotteryItemType.Elite2Socket,
                    "MoonBlade", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(900018, LotteryItemType.Elite2Socket,
                    "RattanShield", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(561098, LotteryItemType.Elite2Socket,
                    "ShaolinWand", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(560098, LotteryItemType.Elite2Socket,
                    "LuckSpear", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(540108, LotteryItemType.Elite2Socket,
                    "GiantLongHammer", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(530098, LotteryItemType.Elite2Socket,
                    "TwinPoleaxe", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(510098, LotteryItemType.Elite2Socket,
                    "UnionGlaive", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(490098, LotteryItemType.Elite2Socket,
                    "CaoDagger", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(481098, LotteryItemType.Elite2Socket,
                    "WishScepter", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(113038, LotteryItemType.Elite2Socket,
                    "LeopardHat", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(114058, LotteryItemType.Elite2Socket,
                    "LotusCap", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(117048, LotteryItemType.Elite2Socket,
                    "TasselEarring", LotteryInternalOdds.low),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(118058, LotteryItemType.Elite2Socket,
                    "GoldCoronet", LotteryInternalOdds.low),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(120098, LotteryItemType.Elite2Socket,
                    "GoldNecklace", LotteryInternalOdds.low),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(121128, LotteryItemType.Elite2Socket,
                    "AmbergrisBag", LotteryInternalOdds.low),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(130058, LotteryItemType.Elite2Socket,
                    "DemonArmor", LotteryInternalOdds.low),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(131058, LotteryItemType.Elite2Socket,
                    "ChainedArmor", LotteryInternalOdds.low),

                #endregion
                // 1% 10
                #region Elite+8
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(142028, LotteryItemType.ElitePlus8,
                    "VioletPlume", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(141058, LotteryItemType.ElitePlus8,
                    "FiresilkBand", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(133048, LotteryItemType.ElitePlus8,
                    "ApeCoat", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(134058, LotteryItemType.ElitePlus8,
                    "PowerGown", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(160098, LotteryItemType.ElitePlus8,
                    "LightBoots", LotteryInternalOdds.low),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(152108, LotteryItemType.ElitePlus8,
                    "VioletBracelet", LotteryInternalOdds.low),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(151098, LotteryItemType.ElitePlus8,
                    "BoneHeavyRing", LotteryInternalOdds.low),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(150098, LotteryItemType.ElitePlus8,
                    "IvoryRing", LotteryInternalOdds.low),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(480098, LotteryItemType.ElitePlus8,
                    "WarClub", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(460098, LotteryItemType.ElitePlus8,
                    "MelonHammer", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(450098, LotteryItemType.ElitePlus8,
                    "PeaceAxe", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(440098, LotteryItemType.ElitePlus8,
                    "TwinWhip", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(430098, LotteryItemType.ElitePlus8,
                    "AntlerHook", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(421088, LotteryItemType.ElitePlus8,
                    "IronBacksword", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(420098, LotteryItemType.ElitePlus8,
                    "FangSword", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(410098, LotteryItemType.ElitePlus8,
                    "MoonBlade", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(900018, LotteryItemType.ElitePlus8,
                    "RattanShield", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(561098, LotteryItemType.ElitePlus8,
                    "ShaolinWand", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(560098, LotteryItemType.ElitePlus8,
                    "LuckSpear", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(540108, LotteryItemType.ElitePlus8,
                    "GiantLongHammer", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(530098, LotteryItemType.ElitePlus8,
                    "TwinPoleaxe", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(510098, LotteryItemType.ElitePlus8,
                    "UnionGlaive", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(490098, LotteryItemType.ElitePlus8,
                    "CaoDagger", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(481098, LotteryItemType.ElitePlus8,
                    "WishScepter", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(113038, LotteryItemType.ElitePlus8,
                    "LeopardHat", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(114058, LotteryItemType.ElitePlus8,
                    "LotusCap", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(117048, LotteryItemType.ElitePlus8,
                    "TasselEarring", LotteryInternalOdds.low),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(118058, LotteryItemType.ElitePlus8,
                    "GoldCoronet", LotteryInternalOdds.low),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(120098, LotteryItemType.ElitePlus8,
                    "GoldNecklace", LotteryInternalOdds.low),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(121128, LotteryItemType.ElitePlus8,
                    "AmbergrisBag", LotteryInternalOdds.low),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(130058, LotteryItemType.ElitePlus8,
                    "DemonArmor", LotteryInternalOdds.low),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(131058, LotteryItemType.ElitePlus8,
                    "ChainedArmor", LotteryInternalOdds.low),

                #endregion
                // 4% 14
                #region Super1Socket
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(900089, LotteryItemType.Super1Socket,
                    "ThornShield", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(410199, LotteryItemType.Super1Socket,
                    "RainbowBlade", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(420199, LotteryItemType.Super1Socket,
                    "LoyalSword", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(421199, LotteryItemType.Super1Socket,
                    "CloudBacksword", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(430199, LotteryItemType.Super1Socket,
                    "DemonHook", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(440199, LotteryItemType.Super1Socket,
                    "LightningWhip", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(450199, LotteryItemType.Super1Socket,
                    "GoldAxe", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(460199, LotteryItemType.Super1Socket,
                    "ShiningHammer", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(480199, LotteryItemType.Super1Socket,
                    "SnakeClub", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(490199, LotteryItemType.Super1Socket,
                    "RainbowDagger", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(580199, LotteryItemType.Super1Socket,
                    "SilverHalbert", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(561199, LotteryItemType.Super1Socket,
                    "CopperWand", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(560199, LotteryItemType.Super1Socket,
                    "Lance", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(540199, LotteryItemType.Super1Socket,
                    "PetalLongHammer", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(530199, LotteryItemType.Super1Socket,
                    "GrimPoleaxe", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(510199, LotteryItemType.Super1Socket,
                    "TigerGlaive", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(500189, LotteryItemType.Super1Socket,
                    "RosewoodBow", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(500089, LotteryItemType.Super1Socket,
                    "QinBow", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(481199, LotteryItemType.Super1Socket,
                    "ThunderScepter", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(160199, LotteryItemType.Super1Socket,
                    "KylinBoots", LotteryInternalOdds.low),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(152209, LotteryItemType.Super1Socket,
                    "DarkBracelet", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(151199, LotteryItemType.Super1Socket,
                    "AgateHeavyRing", LotteryInternalOdds.low),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(150199, LotteryItemType.Super1Socket,
                    "DiamondRing", LotteryInternalOdds.low),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(142069, LotteryItemType.Super1Socket,
                    "SwanPlume", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(141089, LotteryItemType.Super1Socket,
                    "FrostHeadband", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(134089, LotteryItemType.Super1Socket,
                    "RoyalGown", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(133079, LotteryItemType.Super1Socket,
                    "RhinoCoat", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(131089, LotteryItemType.Super1Socket,
                    "BasaltArmor", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(130089, LotteryItemType.Super1Socket,
                    "WarArmor", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(121189, LotteryItemType.Super1Socket,
                    "GoldBag", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(120189, LotteryItemType.Super1Socket,
                    "DragonNecklace", LotteryInternalOdds.low),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(118089, LotteryItemType.Super1Socket,
                    "MonkCoronet", LotteryInternalOdds.low),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(117089, LotteryItemType.Super1Socket,
                    "JadeEarring", LotteryInternalOdds.low),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(114089, LotteryItemType.Super1Socket,
                    "CraneCap", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(113069, LotteryItemType.Super1Socket,
                    "AntlerHat", LotteryInternalOdds.normal),

                #endregion
                // 5% 19
                #region SuperNoSocket
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(900089, LotteryItemType.SuperNoSocket,
                    "ThornShield", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(410199, LotteryItemType.SuperNoSocket,
                    "RainbowBlade", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(420199, LotteryItemType.SuperNoSocket,
                    "LoyalSword", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(421199, LotteryItemType.SuperNoSocket,
                    "CloudBacksword", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(430199, LotteryItemType.SuperNoSocket,
                    "DemonHook", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(440199, LotteryItemType.SuperNoSocket,
                    "LightningWhip", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(450199, LotteryItemType.SuperNoSocket,
                    "GoldAxe", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(460199, LotteryItemType.SuperNoSocket,
                    "ShiningHammer", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(480199, LotteryItemType.SuperNoSocket,
                    "SnakeClub", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(490199, LotteryItemType.SuperNoSocket,
                    "RainbowDagger", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(580199, LotteryItemType.SuperNoSocket,
                    "SilverHalbert", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(561199, LotteryItemType.SuperNoSocket,
                    "CopperWand", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(560199, LotteryItemType.SuperNoSocket,
                    "Lance", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(540199, LotteryItemType.SuperNoSocket,
                    "PetalLongHammer", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(530199, LotteryItemType.SuperNoSocket,
                    "GrimPoleaxe", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(510199, LotteryItemType.SuperNoSocket,
                    "TigerGlaive", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(500189, LotteryItemType.SuperNoSocket,
                    "RosewoodBow", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(500089, LotteryItemType.SuperNoSocket,
                    "QinBow", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(481199, LotteryItemType.SuperNoSocket,
                    "ThunderScepter", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(160199, LotteryItemType.SuperNoSocket,
                    "KylinBoots", LotteryInternalOdds.low),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(152209, LotteryItemType.SuperNoSocket,
                    "DarkBracelet", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(151199, LotteryItemType.SuperNoSocket,
                    "AgateHeavyRing", LotteryInternalOdds.low),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(150199, LotteryItemType.SuperNoSocket,
                    "DiamondRing", LotteryInternalOdds.low),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(142069, LotteryItemType.SuperNoSocket,
                    "SwanPlume", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(141089, LotteryItemType.SuperNoSocket,
                    "FrostHeadband", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(134089, LotteryItemType.SuperNoSocket,
                    "RoyalGown", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(133079, LotteryItemType.SuperNoSocket,
                    "RhinoCoat", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(131089, LotteryItemType.SuperNoSocket,
                    "BasaltArmor", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(130089, LotteryItemType.SuperNoSocket,
                    "WarArmor", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(121189, LotteryItemType.SuperNoSocket,
                    "GoldBag", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(120189, LotteryItemType.SuperNoSocket,
                    "DragonNecklace", LotteryInternalOdds.low),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(118089, LotteryItemType.SuperNoSocket,
                    "MonkCoronet", LotteryInternalOdds.low),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(117089, LotteryItemType.SuperNoSocket,
                    "JadeEarring", LotteryInternalOdds.low),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(114089, LotteryItemType.SuperNoSocket,
                    "CraneCap", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(113069, LotteryItemType.SuperNoSocket,
                    "AntlerHat", LotteryInternalOdds.normal),

                #endregion
                // 46% 65
                #region MISC
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    2100045, LotteryItemType.Misc,
                    "MagicalBottle", LotteryInternalOdds.low),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    1200001, LotteryItemType.Misc,
                    "PrayingStone(M)", LotteryInternalOdds.low),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    1200000, LotteryItemType.Misc,
                    "PrayingStone(S)", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    1100006, LotteryItemType.Misc,
                    "Sash(M)", LotteryInternalOdds.low),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    1100003, LotteryItemType.Misc,
                    "Sash(S)", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    1088002, LotteryItemType.Misc,
                    "MeteorTear", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    1088001, LotteryItemType.Misc,
                    "Meteor", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    1088000, LotteryItemType.Misc,
                    "DragonBall", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    730004, LotteryItemType.Misc,
                    "+4Stone", LotteryInternalOdds.low),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    730003, LotteryItemType.Misc,
                    "+3Stone", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    730002, LotteryItemType.Misc,
                    "+2Stone", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    730001, LotteryItemType.Misc,
                    "+1Stone", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    725024, LotteryItemType.Misc,
                    "Dance8", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    725023, LotteryItemType.Misc,
                    "Dance7", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    725022, LotteryItemType.Misc,
                    "Dance6", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    725021, LotteryItemType.Misc,
                    "Dance5", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    725020, LotteryItemType.Misc,
                    "Dance4", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    725019, LotteryItemType.Misc,
                    "Dance3", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    725018, LotteryItemType.Misc,
                    "Dance2", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    725016, LotteryItemType.Misc,
                    "NightDevil", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    723727, LotteryItemType.Misc,
                    "PenitenceAmulet", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    723726, LotteryItemType.Misc,
                    "LifeFruit", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    723725, LotteryItemType.Misc,
                    "LifeFruitBasket", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    723724, LotteryItemType.Misc,
                    "DisguiseAmulet", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    723718, LotteryItemType.Misc,
                    "Class6MoneyBag", LotteryInternalOdds.low),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    723717, LotteryItemType.Misc,
                    "Class5MoneyBag", LotteryInternalOdds.low),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    723716, LotteryItemType.Misc,
                    "Class4MoneyBag", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    723715, LotteryItemType.Misc,
                    "Class3MoneyBag", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    723714, LotteryItemType.Misc,
                    "Class2MoneyBag", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    723713, LotteryItemType.Misc,
                    "Class1MoneyBag", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    723712, LotteryItemType.Misc,
                    "+1StonePack", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    723711, LotteryItemType.Misc,
                    "MeteorTearPack", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    723700, LotteryItemType.Misc,
                    "ExpBall", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    723584, LotteryItemType.Misc,
                    "BlackTulip", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    723583, LotteryItemType.Misc,
                    "NinjaAmulet", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    723017, LotteryItemType.Misc,
                    "ExpPotion", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    720027, LotteryItemType.Misc,
                    "MeteorScroll", LotteryInternalOdds.high),

                #endregion
                // 4% 69
                #region SUPERMISC
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    700073, LotteryItemType.SuperMisc,
                    "SuperTortoiseGem", LotteryInternalOdds.low),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    700003, LotteryItemType.SuperMisc,
                    "SuperPhoenixGem", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    700063, LotteryItemType.SuperMisc,
                    "SuperMoonGem", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    700053, LotteryItemType.SuperMisc,
                    "SuperVioletGem", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    700043, LotteryItemType.SuperMisc,
                    "SuperKylinGem", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    700033, LotteryItemType.SuperMisc,
                    "SuperRainbowGem", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    700023, LotteryItemType.SuperMisc,
                    "SuperFuryGem", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    700013, LotteryItemType.SuperMisc,
                    "SuperDragonGem", LotteryInternalOdds.low),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    720028, LotteryItemType.SuperMisc,
                    "DBScroll", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    723701, LotteryItemType.SuperMisc,
                    "ExemptionToken", LotteryInternalOdds.low),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    723723, LotteryItemType.SuperMisc,
                    "TopMoneyBag", LotteryInternalOdds.low),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    723722, LotteryItemType.SuperMisc,
                    "Class10MoneyBag", LotteryInternalOdds.low),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    723721, LotteryItemType.SuperMisc,
                    "Class9MoneyBag", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    723720, LotteryItemType.SuperMisc,
                    "Class8MoneyBag", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    723719, LotteryItemType.SuperMisc,
                    "Class7MoneyBag", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    730006, LotteryItemType.SuperMisc,
                    "+6Stone", LotteryInternalOdds.low),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    730005, LotteryItemType.SuperMisc,
                    "+5Stone", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    1100009, LotteryItemType.SuperMisc,
                    "Sash(L)", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    1200002, LotteryItemType.SuperMisc,
                    "PrayingStone(L)", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    2100025, LotteryItemType.SuperMisc,
                    "MiraculousGourd", LotteryInternalOdds.low),

                #endregion
                // 21% 90
                #region GERMANT
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    182805, LotteryItemType.Garment,
                    "SouthofCloud", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    182765, LotteryItemType.Garment,
                    "HeavenScent", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    182745, LotteryItemType.Garment,
                    "MoonOrchid", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    182735, LotteryItemType.Garment,
                    "BlueDream", LotteryInternalOdds.low),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    182725, LotteryItemType.Garment,
                    "AngelicalDress", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    182715, LotteryItemType.Garment,
                    "BonfireNight", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    182805, LotteryItemType.Garment,
                    "SouthofCloud", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    182785, LotteryItemType.Garment,
                    "DreaminFlowers", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    182765, LotteryItemType.Garment,
                    "HeavenScent", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    182745, LotteryItemType.Garment,
                    "MoonOrchid", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    182725, LotteryItemType.Garment,
                    "AngelicalDress", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    181605, LotteryItemType.Garment,
                    "RedPhoenix", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    181545, LotteryItemType.Garment,
                    "ColorfulDress", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    181525, LotteryItemType.Garment,
                    "BlackCelestial", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    181515, LotteryItemType.Garment,
                    "BlackElegance", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    181505, LotteryItemType.Garment,
                    "BlackPhoenix", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    181425, LotteryItemType.Garment,
                    "BrownCelestial", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    181415, LotteryItemType.Garment,
                    "BrownElegance", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    181405, LotteryItemType.Garment,
                    "BrownPhoenix", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    181385, LotteryItemType.Garment,
                    "RoyalDignity", LotteryInternalOdds.low),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    181375, LotteryItemType.Garment,
                    "SongofTianshan", LotteryInternalOdds.low),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    181365, LotteryItemType.Garment,
                    "PrairieWind", LotteryInternalOdds.low),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    181355, LotteryItemType.Garment,
                    "DarkWizard", LotteryInternalOdds.low),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    181335, LotteryItemType.Garment,
                    "WeddingGown", LotteryInternalOdds.low),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    181325, LotteryItemType.Garment,
                    "WhiteCelestial", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    181315, LotteryItemType.Garment,
                    "WhiteElegance", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    181305, LotteryItemType.Garment,
                    "WhitePhoenix", LotteryInternalOdds.high),
                #endregion
                // 10%
                #region Refined GEM
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    700072, LotteryItemType.Gem,
                    "RefindTortoiseGem", LotteryInternalOdds.low),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    700062, LotteryItemType.Gem,
                    "RefindMoonGem", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    700052, LotteryItemType.Gem,
                    "RefindVioletGem", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    700042, LotteryItemType.Gem,
                    "RefindKylinGem", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    700032, LotteryItemType.Gem,
                    "RefindRainbowGem", LotteryInternalOdds.normal),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    700022, LotteryItemType.Gem,
                    "RefindFuryGem", LotteryInternalOdds.high),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    700012, LotteryItemType.Gem,
                    "RefindDragonGem", LotteryInternalOdds.low),
                new Tuple<uint, LotteryItemType, string, LotteryInternalOdds>(
                    700002, LotteryItemType.Gem,
                    "RefindPhoenixGem", LotteryInternalOdds.normal)
                #endregion

                #endregion
            };

            StoneValue = new List<int>()
            {
                1,3,9,27,81,243,729,2187
            };
            ComposeRequiredValue = new List<int>()
            {
                2,6,18,54,162,486,1458,4374,13122,39366,118098,354294
            };
            SuperMiscList = LotteryItemsList.Where(item => item.Item2 == LotteryItemType.SuperMisc).ToList();
            SuperMiscLow = SuperMiscList.Where(item => item.Item4 == LotteryInternalOdds.high).ToList();
            SuperMiscMedium = SuperMiscList.Where(item => item.Item4 == LotteryInternalOdds.normal).ToList();
            SuperMiscHigh = SuperMiscList.Where(item => item.Item4 == LotteryInternalOdds.low).ToList();


        }


        #region Variables

        public static List<Tuple<uint, LotteryItemType, string, LotteryInternalOdds>> SuperMiscList;
        public static List<Tuple<uint, LotteryItemType, string, LotteryInternalOdds>> SuperMiscLow;
        public static List<Tuple<uint, LotteryItemType, string, LotteryInternalOdds>> SuperMiscMedium;
        public static List<Tuple<uint, LotteryItemType, string, LotteryInternalOdds>> SuperMiscHigh;
        public static List<int> StoneValue;
        public static List<int> ComposeRequiredValue;

        public static List<KeyValuePair<uint, string>> DailyRandomRareItems;
        public static List<Tuple<uint, LotteryItemType, string, LotteryInternalOdds>> LotteryItemsList;
        public static ThreadSafeCounter ItemGenerator;
        public static int offset = 40;
        public static int value = 5;
        public static TinyMapServer MapService;
        public static List<ushort> ValidCharacterMeshes = new List<ushort> { 1003, 1004, 2001, 2002 };
        public static List<ushort> ValidBaseProfessions = new List<ushort> { 10, 20, 30, 40, 100};
        public static Dictionary<ushort, ushort> WeaponSkills = new Dictionary<ushort, ushort>
        { 
            {420,5030},
            {421,5030},
            {430,7000},
            {440,7040},
            {450,7010},
            {460,5040},
            {480,7020},
            {481,7030},
            {490,1290},
            {500,5000},
            {510,1250},
            {530,5050},
            {540,1300},
            {560,1260},
            {561,5010},
            {580,5020},
        };
        public static Dictionary<ushort, ushort> TGScarecrows = new Dictionary<ushort, ushort>
        { 
            {437,20},//Crow
            {467,25},
            {497,30},
            {527,35},
            {557,40},
            {587,45},
            {617,50},
            {647,55},
            {677,60},
            {707,65},
            {737,70},
            {767,75},
            {797,80},
            {827,85},
            {857,90},
            {887,95},
            {917,100},
            {947,105},
            {977,110},
            {1007,115},
            {1037,120},
            {1527,125},
        };
        public static Dictionary<ushort, ushort> TGStakes = new Dictionary<ushort, ushort>
        { 
            {427,20},//Stake
            {457,25},
            {487,30},
            {517,35},
            {547,40},
            {577,45},
            {607,50},
            {637,55},
            {667,60},
            {697,65},
            {727,70},
            {757,75},
            {787,80},
            {817,85},
            {847,90},
            {877,95},
            {907,100},
            {937,105},
            {967,110},
            {997,115},
            {1027,120},
            {1507,125},
        };
        public static readonly sbyte[] DeltaX, DeltaY;
        private static readonly int[] _trojanLifeBonus;
        private static readonly int[] _taoistManaBonus;
        public static Regex ValidChars;
        public const int MINIMUM_THREAD_SLEEP_MS = 1;
        public const int MS_PER_SECOND = 1000;
        public const int MS_PER_MINUTE = 60000;
        public const int MS_PER_HOUR = 3600000;
        public static readonly DateTime UnixEpoch;
        public static ThreadSafeRandom Random;
        public static readonly byte[] ENCRYPTION_KEY;
        public static readonly byte[] SERVER_SEAL;
        private static readonly Stopwatch _clock;
        
       




        #endregion
        #region Helper Methods
        /// <summary>
        /// Returns MS since the server has loaded. Use for all timing needs.
        /// </summary>
        /// 
        public static Tuple<ConquerItem, string, LotteryItemType> QurryLotteryItem()
        {
            var CategoryRandomness = Random.Next(1000);
            var CategoryInternalRandomness = Random.Next(100);
            var ItemType = LotteryItemType.Gem;
            var itemInternalOdds = LotteryInternalOdds.high;
            if (CategoryRandomness < 50)
                ItemType = LotteryItemType.Elite1Socket;
            else if (CategoryRandomness < 90)
                ItemType = LotteryItemType.Elite2Socket;
            else if (CategoryRandomness < 95)
                ItemType = LotteryItemType.ElitePlus8;
            else if (CategoryRandomness < 145)
                ItemType = LotteryItemType.Super1Socket;
            else if (CategoryRandomness < 190)
                ItemType = LotteryItemType.SuperNoSocket;
            else if (CategoryRandomness < 650)
                ItemType = LotteryItemType.Misc;
            else if (CategoryRandomness < 690)
                ItemType = LotteryItemType.SuperMisc;
            else if (CategoryRandomness < 900)
                ItemType = LotteryItemType.Garment;
            if (CategoryInternalRandomness < 10)
                itemInternalOdds = LotteryInternalOdds.low;
            else if (CategoryInternalRandomness < 40)
                itemInternalOdds = LotteryInternalOdds.normal;

            var items = LotteryItemsList.Where(i => i.Item2 == ItemType && i.Item4 == itemInternalOdds).ToList();
            var iteminfo = items[Random.Next(0, items.Count - 1)];
            //GetIteminfo(iteminfo.Item1);


            var Item = new ConquerItem((uint)(ItemGenerator.Counter), iteminfo.Item1, ItemType == LotteryItemType.ElitePlus8 ? (byte)8 : (byte)0, 0, 0, ItemType == LotteryItemType.Elite1Socket || ItemType == LotteryItemType.Elite2Socket || ItemType == LotteryItemType.Super1Socket ? (byte)255 : (byte)0, ItemType == LotteryItemType.Elite2Socket ? (byte)255 : (byte)0);
            uint ItemId = iteminfo.Item1;
            return new Tuple<ConquerItem, string, LotteryItemType>(Item, iteminfo.Item3, ItemType);


        }

        

        public static Tuple<uint, LotteryItemType, string, LotteryInternalOdds> GetIteminfo(Tuple<uint, LotteryItemType, string, LotteryInternalOdds> iteminfo)
        {
            return iteminfo;
        }

        public static long Clock
        {
            get
            {
                lock (_clock)
                    return _clock.ElapsedMilliseconds;
            }
        }
        public static uint SecondsServerOnline
        {
            get { return (uint)(_clock.ElapsedMilliseconds / MS_PER_SECOND); }
        }
        public static uint MinutesServerOnline
        {
            get { return (uint)(_clock.ElapsedMilliseconds / MS_PER_MINUTE); }
        }
        public static uint HoursServerOnline
        {
            get { return (uint)(_clock.ElapsedMilliseconds / MS_PER_HOUR); }
        }

        public static long SecondsFromNow(DateTime end)
        {
            long remaining = 0;
            if (end < DateTime.Now)
                return remaining;
            var diff = end.Subtract(DateTime.Now);
            remaining += diff.Seconds;
            remaining += diff.Minutes * 60;
            remaining += diff.Hours * 3600;
            remaining += diff.Days * 86400;
            return remaining;
        }
        public static long MsFromNow(DateTime end)
        {
            long remaining = 0;
            if (end < DateTime.Now)
                return remaining;
            var diff = end.Subtract(DateTime.Now);
            remaining += diff.Seconds * 1000;
            remaining += diff.Minutes * 60000;
            remaining += diff.Hours * 3600000;
            return remaining;
        }

        public static int MulDiv(int number, int numerator, int denominator)
        {
            if (denominator < 1)
                denominator = 1;
            return number * numerator / denominator;
        }

        public static uint MulDiv(uint number, uint numerator, uint denominator)
        {
            if (denominator < 1)
                denominator = 1;
            return number * numerator / denominator;
        }

        public static long MulDiv(long number, long numerator, long denominator)
        {
            if (denominator < 1)
                denominator = 1;
            return number * numerator / denominator;
        }
        public static double GetRadian(int sourceX, int sourceY, int targetX, int targetY)
        {
            if (!(sourceX != targetX || sourceY != targetY)) return 0f;

            var deltaX = targetX - sourceX;
            var deltaY = targetY - sourceY;
            var distance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);

            if (!(deltaX <= distance && distance > 0)) return 0f;
            var radian = Math.Asin(deltaX / distance);

            return deltaY > 0 ? (Math.PI / 2 - radian) : (Math.PI + radian + Math.PI / 2);
        }
        public static int GetTrojanLifeBonus(int index)
        {
            return index < 0 || index > _trojanLifeBonus.Length ? _trojanLifeBonus[0] : _trojanLifeBonus[index];
        }

        public static int GetTaoistManaBonus(int index)
        {
            return index < 0 || index > _taoistManaBonus.Length ? _taoistManaBonus[0] : _taoistManaBonus[index];
        }
        public static byte ExchangeBits(byte data, int bits)
        {
            return (byte)((data << bits) | (data >> bits));
        }

        public static uint ExchangeShortBits(uint data, int bits)
        {
            data &= 0xffff;
            return ((data >> bits) | (data << (16 - bits))) & 0xffff;
        }

        public static uint ExchangeLongBits(uint data, int bits)
        {
            return (data >> bits) | (data << (32 - bits));
        }
        public static bool PercentSuccess(double _chance)
        {
            return Random.NextDouble() * 100 < _chance;
        }
        public static bool PercentSuccess(int _chance)
        {
            return Random.NextDouble() * 100 < _chance;
        }
        #endregion

    }
}
