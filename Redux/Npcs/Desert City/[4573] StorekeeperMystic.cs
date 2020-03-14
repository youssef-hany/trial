using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redux.Packets.Game;

namespace Redux.Npcs
{

    public class NPC_4573 : INpc
    {

        public NPC_4573(Game_Server.Player _client)
            : base(_client)
        {
    		ID = 4573;	
			Face = 5;    
    	}
    	
        public override void Run(Game_Server.Player _client, ushort _linkback)
        {
        	Responses = new List<NpcDialogPacket>();
        	AddAvatar();
        	switch(_linkback)
        	{
                case 0:
                    AddText("I am not available yet but thanks to Joe i will be in the future..");
                    AddOption("Thanks", 255);
                    break;
        		default:
        			break;
        	}
            AddFinish();
            Send();
        }
    }
}
