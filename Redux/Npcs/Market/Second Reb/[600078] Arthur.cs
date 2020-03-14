using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redux.Packets.Game;

namespace Redux.Npcs
{
                                        // [600078] Arthur
    public class NPC_600078 : INpc
    {

        public NPC_600078(Game_Server.Player _client)
            : base(_client)
        {
            ID = 600078;
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
                        AddText("I can give you 1 Feather Stone if you find me one of each of these pieces of 3 ingredients Moss, DreamGrass, SoulAroma. ");
                        AddText("I can also give you one Immortal Stone for 3 FeatherStones");

                      AddOption("Feather Stone", 1);
                        AddOption("Immortal Stones", 2);
                        AddOption("This is so sad..", 255);
                        
                        break;
                    }
                case 1:
                    {
                        if (_client.Inventory.Count <= 39 && _client.HasItem(722723, 1) && _client.HasItem(722724, 1) && _client.HasItem(722725, 1))
                        {
                            _client.DeleteItem(722723);
                            _client.DeleteItem(722724);
                            _client.DeleteItem(722725);
                            _client.CreateItem(722726);
                            _client.Save();
                        }
                        else
                        {
                            AddText("Either you don't have enough space in inventory or you dont have required materials!");
                            AddOption("I see.", 255);
                            
                           
                        }
                        break;
                    }
                case 2:
                    {
                        if (_client.Inventory.Count <= 39 && _client.HasItem(722726, 3))
                        {
                            _client.DeleteItem(722726);
                            _client.DeleteItem(722726);
                            _client.DeleteItem(722726);
                            _client.CreateItem(722728);
                            _client.Save();

                        }

                        else
                        {
                            AddText("Either you don't have enough space in inventory or you dont have required materials!");
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
