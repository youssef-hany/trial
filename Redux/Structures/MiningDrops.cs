using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Redux.Database;
using Redux.Game_Server;
using Redux.Packets.Game;
using Redux.Database.Domain;

namespace Redux.Structures
{

    public struct MineDrop
    {
        public uint ItemID;
        public short Chance;
        public short Type;
        public short Amount;

        public static MineDrop Create(DbDropRule dbmine)
        {
            MineDrop Drop = new MineDrop();
            Drop.ItemID = dbmine.RuleValue;
#pragma warning disable CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
            Drop.Chance = (short)((dbmine.RuleChance != null) ? dbmine.RuleChance:10);
#pragma warning restore CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
            Drop.Type = (short)dbmine.RuleType;
            Drop.Amount = (short)dbmine.RuleAmount;
            return Drop;
        }
    }
    /// <summary>
    /// Structure to hold the ore and gem drops for each mine.
    /// Each map needs to have entries in the DropRule database table.
    /// Type 1 = Ores. Type 2 = Gems, Type 3 = Misc (Ex Euxenite)
    /// MonsterID in table = MapID
    /// </summary>
    public class MiningDrops
    {
        public List<MineDrop> Ores;
        public List<MineDrop> Gems;
        public List<MineDrop> Misc;

        public uint MapId;

        public const Double Super_Rate = 0.02;
        public const Double Refined_Rate = 0.1;
        public const Double Regular_Rate = 0.2;

        public MiningDrops(ushort MapID)
        {
            MapId = MapID;
            Ores = new List<MineDrop>();
            Gems = new List<MineDrop>();
            Misc = new List<MineDrop>();

            var MineInfo = ServerDatabase.Context.DropRules.GetRulesByMonsterType(MapId);

            if (MineInfo.Count > 0)
            {
                foreach (var Drop in MineInfo)
                {
                    MineDrop ItemDrop = MineDrop.Create(Drop);
                    switch (ItemDrop.Type)
                    {
                            //Ores
                        case 1:
                            if(!Ores.Contains(ItemDrop))
                                Ores.Add(ItemDrop);
                            break;

                            //Gems
                        case 2:
                            if (!Gems.Contains(ItemDrop))
                                Gems.Add(ItemDrop);
                            break;

                            //Misc?
                        case 3:
                            if (!Misc.Contains(ItemDrop))
                                Misc.Add(ItemDrop);
                            break;
                    }
                }
            }
        }
        
        

    }
}
