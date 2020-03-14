/*
 * User: pro4never
 * Date: 10/26/2014
 * Time: 9:18 PM
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redux.Packets.Game;

namespace Redux.Npcs
{
    /// <summary>
    /// Handles NPC usage for [10037] Assistant
    /// </summary>
    public class NPC_10037 : INpc
    {

        public NPC_10037(Game_Server.Player _client)
            : base(_client)
        {
            ID = 10037;
            Face = 1;
        }

        public override void Run(Game_Server.Player _client, ushort _linkback)
        {
            Responses = new List<NpcDialogPacket>();
            AddAvatar();
            switch (_linkback)
            {
                case 0:
                    if (_client.ProfessionType == Enum.ProfessionType.WaterTaoist)
                    {
                        AddText("Hello Traveller, I can sell you a WindSpell to help you to get around this world");
                        AddOption("Show it to me!", 1);
                        AddOption("No Thanks", 255);
                    }
                    else
                    {
                        AddText("I am sorry i can only help Water Taoists");
                        AddOption("Okay!", 255);

                    }
                    break;
                case 1:
                    if (_client.ProfessionType == Enum.ProfessionType.WaterTaoist)
                    {
                        if (_client.Money >= 100)
                        {
                            _client.Money -= 100;
                            _client.CreateItem(1060031);
                            AddText("Take Care Traveller!");
                            AddOption("Thanks!", 255);
                        }
                        else
                        {
                            AddText("You do not have enough silver");
                            AddOption("Thanks", 255);

                        }
                    }
                    break;
            }
            AddFinish();
            Send();
        }
    }
}
