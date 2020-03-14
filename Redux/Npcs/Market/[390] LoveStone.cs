using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redux.Packets.Game;

namespace Redux.Npcs
{
    public class NPC_390 : INpc
    {
        public NPC_390(Game_Server.Player _client)
            : base(_client)
        {
            ID = 390;
            Face = 1;
        }

        public override void Run(Game_Server.Player _client, ushort _linkback)
        {
            Responses = new List<NpcDialogPacket>();
            AddAvatar();
            switch (_linkback)
            {
                case 0:
                    AddText("The fate brings lover together. I hope that all can get married and live happily with their lover. What can I do for you?");
                    AddOption("I would like to get married please.", 1);
                    AddOption("Just passing by.", 255);
                    break;
                case 1:
                    if (_client.Spouse == "None")
                    {
                        _client.Send(GeneralActionPacket.Create(_client.UID, Enum.DataAction.OpenCustom, 1067));
                    }
                    else
                    {
                        AddText("I am sorry i cannot allow more than one marriage...");
                        AddOption("I see", 255);
                    }
                    break;
            }
            AddFinish();
            Send();
        }
    }
}