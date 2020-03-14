using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redux.Packets.Game;

namespace Redux.Npcs
{                                             // [600079] Angela

    public class NPC_600079 : INpc
    {

        public NPC_600079(Game_Server.Player _client)
            : base(_client)
        {
            ID = 600079;
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
                        AddText("You can exchange 1 VigorFragment for 3 ImmortalStones or 1 ImpureVigor for 3 VigorFragments");
                        AddOption("VigorFragments", 1);
                        AddOption("ImpureVigor", 2);
                        AddOption("I will not trade anything.", 255);
                        
                        break;
                    }
                case 1:
                    {
                        if (_client.Inventory.Count <= 39 && _client.HasItem(722728, 3))
                        {
                            _client.DeleteItem(722728);
                            _client.CreateItem(722729);
                        }
                        else
                        {
                            AddText("Seems that you don't have enough space in inventory or you dont have required materials!");
                            AddOption("I see..", 255);
                          
                        }
                        break;
                    }
                case 2:
                    {
                        if (_client.Inventory.Count <= 39 && _client.HasItem(722729, 3))
                        {
                            _client.DeleteItem(722728);
                            _client.CreateItem(722730);
                            _client.Save();
                        }
                        else
                        {
                            AddText("You don't have enough space in inventory or you dont have required materials!");
                            AddOption("I see..", 255);
                          
                        }
                        break;
                    }

            }
            AddFinish();
            Send();

        }









      
        }
        }
    

