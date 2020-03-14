using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redux.Packets.Game;
using Redux.Database.Domain;

namespace Redux.Npcs
{

    public class NPC_1337 : INpc
    {
        /// <summary>
        /// Handles NPC usage for [1337] Welcomer
        /// </summary>
        public NPC_1337(Game_Server.Player _client)
            : base(_client)
        {
            ID = 1337;
            Face = 1;
            var v = _client;
        }

        public override void Run(Game_Server.Player _client, ushort _linkback)
        {
            Responses = new List<NpcDialogPacket>();
            AddAvatar();
            switch (_linkback)
            {   
                case 0:
                    AddText("Welcome to Requiem World, Do not Hesitate to Contact the [GM] if you have any questions ");
                    AddText("Please use the /report command to tell us about bugs. Enjoy your free starter pack! ");
                    AddOption("Thanks ", 2);
                    AddOption("Newbie Quest ", 3);
                    break;
                case 2:
                    
                    if (_client.Level <= 25) { 
                        if (_client.Inventory.Count < 33)
                        {
                            if (_client.ProfessionType == Enum.ProfessionType.Taoist)
                            {
                                _client.CreateItem(421009); //wep
                                _client.CreateItem(134009); // armor
                                _client.CreateItem(114009); // helmet
                                _client.CreateItem(152019); // ring
                                _client.CreateItem(121009); // necklace
                                _client.CreateItem(160019); // boots
                                AddText("Have Fun! ");
                                AddOption("I will", 255);
                                break;
                            }
                            if (_client.ProfessionType == Enum.ProfessionType.Trojan)
                            {
                                _client.CreateItem(480019); //wep
                                _client.CreateItem(130009); // armor
                                _client.CreateItem(118009); // helmet
                                _client.CreateItem(150019); // ring
                                _client.CreateItem(120009); // necklace
                                _client.CreateItem(160019); // boots
                                AddText("Have Fun! ");
                                AddOption("I will", 255);
                                break;
                            }
                            if (_client.ProfessionType == Enum.ProfessionType.Warrior)
                            {
                                _client.CreateItem(561019); //wep
                                _client.CreateItem(131009); // armor
                                _client.CreateItem(111009); // helmet
                                _client.CreateItem(150019); // ring
                                _client.CreateItem(120009); // necklace
                                _client.CreateItem(160019); // boots
                                AddText("Have Fun! ");
                                AddOption("I will", 255);
                                break;
                            }
                            if (_client.ProfessionType == Enum.ProfessionType.Archer)
                            {
                                _client.CreateItem(500009); //wep
                                _client.CreateItem(133009); // armor
                                _client.CreateItem(113009); // helmet
                                _client.CreateItem(150019); // ring
                                _client.CreateItem(120009); // necklace
                                _client.CreateItem(160019); // boots
                                _client.CreateItem(1050000); // arrows
                                AddText("Have Fun! ");
                                AddOption("I will.", 255);
                                break;
                            }

                            else
                            {
                                AddText("");
                               

                            }
                            break;




                        }
                        else
                        {
                            _client.SendMessage("You have no space in your inventory.");
                            AddText("Free some space in you bag before you can claim Requiem gift");

                        }
                    }
                    else
                    {
                        AddText("I am sorry i can only help new players under lvl 25. Maybe you can too!");
                        AddOption("got it!", 255);
                    }
                    break;

                case 3:
                    AddText("Do you really want to start the newbie quest?");
                    AddOption("Give it to me!", 4);
                    AddOption("Not for me!", 5);

                    break;
                case 4:
                    AddText("So you need to kill 10 Pheasants just outside of Twin City");
                    AddOption("This sounds pretty easy!", 5);
                    AddOption("I dont want to make any quests", 255);

                    break;
                case 5:
                    if (_client.Level <= 25)
                    {
                        _client.MonsterStart(1, 10);

                        break;
                    }
                    break;



            }

            AddFinish();
            Send();

        }
    }
}