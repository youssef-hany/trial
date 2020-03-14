using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redux.Packets.Game;
using Redux.Events;

namespace Redux.Npcs
{
    /// <summary>
    /// Handles NPC usage for [600077] Tournament Master
    /// </summary>
    public class NPC_600077 : INpc
    {

        public NPC_600077(Game_Server.Player _client)
            : base(_client)
        {
            ID = 600077;
            Face = 1;
        }

        public override void Run(Game_Server.Player _client, ushort _linkback)
        {
            Responses = new List<NpcDialogPacket>();
            AddAvatar();
            switch (_linkback)
            {
                case 0:
                    {

                        AddText("Do you want to Sign-up for a tournament?");
                        AddOption("I want to know more", 1);
                        AddOption("Sign-up", 16);
                        AddOption("Just passing by", 255);
                        break;
                    }
                case 1:
                    {
                        AddText("Which tournament would you like to know about?");
                        AddOption("Free For All", 2);
                        AddOption("Comming Soon!", 255);
                        break;
                    }
                #region Explain Events
                case 2:
                    {
                        AddText("Free for All tournament is simple only FastBlade/ScentSword will do damage, " +
                            "once a player reaches a maximum score of 25 he is the winner and is" +
                            " awarded great rewards. Keep in mind that as long as " +
                            "you participate you will get rewards you do not have to win!");
                        AddOption("I see..", 255);
                        break;
                    }
                #endregion
                #region  Free For All
                case 16:
                    {
                        
                       
                        if (FreeForAll.Running == true && FreeForAll.signup == true)
                        {
                            if (_client.FFA_Signed == false)
                            {
                                FreeForAll.Countingsigns++;
                                _client.FFA_Signed = true;
                                AddText("You have been signed up for <Free For Fall> Event");
                                AddOption("Okay", 255);
                            }
                        }
                        else { AddText("The Event isnt running"); }
                        #endregion
                      /*  else if (Events.DailyPK.DailyRunning == true)
                        {
                        }
                        else
                        {
                            if (DailyPK.DailyRunning == false || FreeForAll.Running == false)
                            {
                                AddText("Sorry But there is no Tournament open");
                                AddOption("Ahh I see", 255);
                            }
                            else
                            {
                                AddText("You are already sign up for this tournament");
                                AddOption("Ahh I see", 255);
                            }
                        }*/
                        break;

                    }
            }
            AddFinish();
            Send();
        }
    }
}