using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redux.Game_Server;
using Redux.Packets.Game;

namespace Redux.Npcs
{                                             // [600082] Satan Sum

    public class NPC_600082 : INpc
    {
        public object ServerBase { get; private set; }
        public  Entity E { get; private set; }
        public uint UID { get; private set; }

        private static int _RebFlag = 0;
         





        public NPC_600082(Game_Server.Player _client)
            : base(_client)
        {
            ID = 600082;
            Face = 5;
        }

        public override void Run(Game_Server.Player _client, ushort _linkback)
        {
            Responses = new List<NpcDialogPacket>();
            AddAvatar();
            switch (_linkback)

            {
                case 0:
                    {
                        AddText("This is the final step in your quest to second reborn, defeat Satan and you shall be worthy of getting second reborn!You need and SquamaBead to call him into this world! ");
                        AddOption("Bring that devil here!", 1);
                        AddOption("No , I shall leave now.", 255);

                        break;
                    }
                case 1:
                    {
                        if (_client.HasItem(722727, 1))
                        {
                            if (_client.Character.SecondQuest != 0)
                            {
                                AddText("Already second");
                                AddOption("I see.", 255);
                            } else
                            {
                                _RebFlag = 1;

                               //_client.ChangeMap(1002, 430, 380);


                                 _client.DeleteItem(722727);


                                    Database.Domain.DbMonstertype monster = new Database.Domain.DbMonstertype();



                                    int K = 1500000;
                                    monster.Life = (ushort) K;
                                    monster.Level = 150;
                                    monster.Mesh = 166;
                                    monster.Name = "Satan";
                                    monster.AttackMax = 15000;
                                    monster.AttackMin = 10000;
                                    monster.AttackRange = 2;
                                    monster.AttackMode = 3;
                                    monster.AttackSpeed = 500;
                                    monster.ViewRange = 30;
                                    monster.MoveSpeed = 500;
                                    monster.MoveSpeed = 500;






                                    //entity.X = 314;
                                    //entity.Y = 324;

                                uint id = 3644;
                                ushort count = 2;
                                ushort freq = 1;



                                Database.Domain.DbMonstertype monsterType = Database.ServerDatabase.Context.Monstertype.GetById(id);
                                if (monsterType == null)
                                    _client.SendMessage("ERROR: No such monster ID: " + id);
                                else if (_client.MapID == 1700)
                                {

                                    var x1 = 313;
                                    var x2 = 314;
                                    var y1 = 323;
                                    var y2 = 324;

                                    Database.Domain.DbSpawn dbSpawn = new Database.Domain.DbSpawn();
                                    ushort radius = 1;
                                    dbSpawn.MonsterType = monsterType.ID;
                                    dbSpawn.X1 = (ushort)(x1- radius);
                                    dbSpawn.Y1 = (ushort)(y1 - radius);
                                    dbSpawn.X2 = (ushort)(x2 + radius);
                                    dbSpawn.Y2 = (ushort)(y2 + radius);
                                    dbSpawn.Map = _client.MapID;
                                    dbSpawn.AmountMax = count / 2;
                                    dbSpawn.AmountPer = count / 2;
                                    dbSpawn.Frequency = freq;
                                    freq = 3600;
                                    count = 1;
                                    id = 0;

                                   
                                    monster.Life = 0;
                                    Database.ServerDatabase.Context.Spawns.Add(dbSpawn);
                                    _client.Map.Spawns.Add(new Managers.SpawnManager(dbSpawn, _client.Map));
                                    Database.ServerDatabase.Context.Spawns.Remove(dbSpawn);
                                    
                                    }
                                if (_RebFlag == 1)
                                {
                                    _client.Character.SecondQuest = 1;
                                    //var SQ = _client = 1;
                                   // var updatePacket = UpdatePacket.Create(_client.UID, Enum.UpdateType.SecondQuest, SQ);
                                    //updatePacket.AddUpdate(Enum.UpdateType.SecondQuest, _client.Character.SecondQuest);
                                    _client.SendMessage("Congratulations! " + _client.Character.Name + " Has Summoned the Great Demon Wish them luck on their 2nd Rebirth", Enum.ChatType.GM, Enum.ChatColour.Red);
                                    _client.Save();
                                }
                                break;

                            }
                        }



                        else
                        {
                                AddText("You don't have  have required materials!");
                                AddOption("I see.", 255);

                            }
                            break;
                        }
                    }
            
                    AddFinish();
                    Send();
            

        }

        }
    }






            
        
    


