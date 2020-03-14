using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redux.Packets.Game;

namespace Redux.Npcs
{                                             // [600080] Bryan

    public class NPC_600080 : INpc
    {

        public NPC_600080(Game_Server.Player _client)
            : base(_client)
        {
            ID = 600080;
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
                        AddText("I can give you 1 PureVigor for 3 ImpureVigors or i give you one SquamaBead for 3 PureVigor");
                        AddOption("PureVigors", 1);
                        AddOption("SquamaBead", 2);
                        AddOption("This is messed up..", 255);

                        break;
                    }
                case 1:
                    {
                        if (_client.Inventory.Count <= 39 && _client.HasItem(722730, 3))
                        {
                            _client.DeleteItem(722730);
                            _client.CreateItem(722731);
                            _client.Save();
                        }
                        else
                        {
                            AddText("You either do not have enough required material or inventory space!");
                            AddOption("I see..", 255);

                        }
                        break;
                    }
                case 2:
                    {
                        if (_client.Inventory.Count <= 39 && _client.HasItem(722731, 3))
                        {
                            _client.DeleteItem(722731);
                            _client.CreateItem(722727);
                        }
                        else
                        {
                            AddText("You either do not have enough required material or inventory space!");
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
    


