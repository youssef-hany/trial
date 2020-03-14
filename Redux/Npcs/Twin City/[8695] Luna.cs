using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redux.Packets.Game;

namespace Redux.Npcs
{
    //[8695] Luna
    public class NPC_8695 : INpc
    {

        public NPC_8695(Game_Server.Player _client)
            : base(_client)
        {
    		ID = 8695;	
			Face = 5;    
    	}
    	
        public override void Run(Game_Server.Player _client, ushort _linkback)
        {
        	Responses = new List<NpcDialogPacket>();
        	AddAvatar();
        	switch(_linkback)
        	{
                case 0:
                    if (_client.Character.Spouse == "None") { 
                        AddText("Hello Traveller. Sometimes Life can be hard and you need to relax and forget about everything. ");
                        AddOption("Nothing Works", 3);
                        AddOption("Good Bye!", 255);
                    }
                    break;
                case 1:
                    AddText("The Lover's Land. It is said that this is the land where lovers bind their Love for eternity! On your mark..");
                    AddOption("Send me!", 2);
                    AddOption("Not now..", 255);
                    break;
                case 2:
                    _client.ChangeMap(1100, 90, 52);
                    AddText("Safe Travels");
                    AddOption("Thanks!", 255);


                    break;
                case 3:
                    if (_client.Character.Spouse == "None")
                    {
                        AddText("Dont worry traveller, everything will work just fine. Go see what the stars have to say..");
                        AddOption("Send me!", 2);
                        AddOption("No i have better thins to do!", 255);
                    }
                    break;
            }
            AddFinish();
            Send();
        }
    }
}
