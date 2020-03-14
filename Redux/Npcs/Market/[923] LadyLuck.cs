using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redux.Packets.Game;

namespace Redux.Npcs
{

    /// <summary>
    /// Handles NPC usage for [923] LadyLuck
    /// </summary>
    public class NPC_923 : INpc
    {

        public NPC_923(Game_Server.Player _client)
            : base(_client)
        {
            ID = 923;
            Face = 3;
        }

        public override void Run(Game_Server.Player _client, ushort _linkback)
        {
            Responses = new List<NpcDialogPacket>();
            AddAvatar();
            switch (_linkback)
            {
                case 0:
                    {
                        AddText("I always have the worst luck...");
                        AddOption("Sorry to hear that.", 255);
                        AddOption("Let me try my luck..", 2);
                        break;
                    }
                case 2:
                    {
                        if (_client.CP >= 27)
                        {
                            AddText("Are you sure you want to go to the Lottery Land?");
                            AddOption("Yes send me please!", 3);
                            AddOption("No this is a mistake", 255);
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                case 3:
                    {
                        if (_client.CP >= 27)
                        {
                            _client.ChangeMap(700, 50, 50);
                            _client.CreateItem(710212, 1);
                            _client.CP -= 27;
                        }
                        break;
                    }
            }

            AddFinish();
            Send();

        }
    }
}
