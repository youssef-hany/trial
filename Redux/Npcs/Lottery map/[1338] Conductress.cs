using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redux.Packets.Game;

namespace Redux.Npcs
{

    /// <summary>
    /// Handles NPC usage for [4450] Market Controller
    /// </summary>
    public class NPC_1338 : INpc
    {

        public NPC_1338(Game_Server.Player _client)
            : base(_client)
        {
            ID = 1338;
            Face = 1;
        }

        public override void Run(Game_Server.Player _client, ushort _linkback)
        {
            Responses = new List<NpcDialogPacket>();
            AddAvatar();
            switch (_linkback)
            {
                case 0:
                    AddText("Do you want to leave this map? I can teleport you to back to Twin City.");
                    AddOption("Yeah. Thanks", 1);
                    AddOption("No. I shall stay here.", 255);
                    break;
                case 1:
                    _client.ChangeMap(1002);
                    break;
            }
            AddFinish();
            Send();

        }
    }
}
