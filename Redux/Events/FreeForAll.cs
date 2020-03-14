using Redux.Enum;
using Redux.Packets.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redux.Events
{
    public static class FreeForAll
    {
        public static uint Countingsigns = 0;
        public static bool Running = false;
        public static uint totalP = 0;
        public static bool signup = false;
        public static uint howmanyinmap = 0;
        //public static bool Send = false;

       /* public static void SendTimer()
        {
            Console.Write("FreeForAll Timer started! \n");
            System.Timers.Timer TimerA = new System.Timers.Timer(1000.0);
            TimerA.Start();
            TimerA.Elapsed += delegate { StartEvent(); };

            System.Timers.Timer TimerB = new System.Timers.Timer(1000.0);
            TimerB.Start();
            TimerB.Elapsed += delegate { Send(); };

            System.Timers.Timer TimerC = new System.Timers.Timer(1000.0);
            TimerC.Start();
            TimerC.Elapsed += delegate { CheckAlive(); };

            System.Timers.Timer TimerD = new System.Timers.Timer(1000.0);
            TimerD.Start();
            TimerD.Elapsed += delegate { EndEvent(); };
        } */
        public static void StartEvent()
        {
            if (/*DateTime.Now.Minute == 30 && DateTime.UtcNow.Second == 00 &&*/ signup == false)
            {
                foreach (var player in Managers.PlayerManager.Players.Values)
                {
                    signup = true;
                    Running = true;
                    Managers.PlayerManager.SendToServer(new TalkPacket(ChatType.Broadcast, " Free For All Tournament has started! Players may now Sign-Up to Events Manager in Twin City. You only have 2 minutes To Signup the event. Hurry Up!"));
                }
            }

        }

        public static void Send()
        {
            if (/*DateTime.UtcNow.Minute == 32 && DateTime.UtcNow.Second == 00 &&*/Running == true)
            {
                Managers.PlayerManager.SendToServer(new TalkPacket(ChatType.Broadcast, "Kill! First perosn with 10 kills Win!"));
                CheckAlive();
                foreach (var player in Managers.PlayerManager.Players.Values)
                {
                    
                    if (player.FFA_Signed == true)
                    {
                        howmanyinmap++;
                        player.ToTalkills = 0;
                        player.ChangeMap(1505, 150, 150);
                        player.PkMode = PKMode.PK;
                    }
                }
            }

        }
        public static void CheckAlive()
        {
          
           
            var loopCounter = 0;
            foreach (var player in Managers.PlayerManager.Players.Values)
            {
                loopCounter++;
                Managers.PlayerManager.SendToServer(new Packets.Game.TalkPacket(ChatType.SynWarNext, "Event Title: Free For All "));
                Managers.PlayerManager.SendToServer(new Packets.Game.TalkPacket(ChatType.SynWarNext, "Signed Up players: " + loopCounter));
                Managers.PlayerManager.SendToServer(new Packets.Game.TalkPacket(ChatType.SynWarNext, "Total Player: " + howmanyinmap));
                Managers.PlayerManager.SendToServer(new Packets.Game.TalkPacket(ChatType.SynWarNext, "My Kills: " + player.DailyPK_Kills + player.ToTalkills));
                

            }
        }
        public static void EndEvent()
        {
            foreach (var player in Managers.PlayerManager.Players.Values)
            {
                if (player.ToTalkills < 10 /*&& DateTime.UtcNow.Minute == 37 && DateTime.UtcNow.Second == 00*/)
                {
                    if (player.MapID == 1505)
                    {
                        player.SendSysMessage("What a shame, None of you got 10 kills in the event! - Better luck next time");
                        player.ChangeMap(1002, 400, 400);
                        player.CP += 15;
                        player.FFA_Signed = false;
                    }
                    Running = false;
                    signup = false;
                    Countingsigns = 0;

                }

                else if (player.ToTalkills > 10)
                {
                    if (player.MapID == 1505)
                    {
                        player.ChangeMap(1002, 400, 400);
                        player.CP += 100;
                        player.FFA_Signed = false;
                    }
                    Running = false;
                    signup = false;
                    Countingsigns = 0;
                }

            }
        }
    }
}