using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Redux.Managers;
using Redux.Events;



namespace Redux.Threading
{
    public class WorldThread:ThreadBase 
    {

        private const int TIMER_OFFSET_LIMIT = 10;
        private const int THREAD_SPEED = 1000;
        private const int INTERVAL_EVENT = 60; 
        
        private long _nextTrigger;
        protected override void OnInit()
        {
            _nextTrigger = Common.Clock + THREAD_SPEED;
        }
        protected override bool OnProcess()
        {
            var curr = Common.Clock;
            if (curr >= _nextTrigger)
            {
                _nextTrigger += THREAD_SPEED;

                var offset = (curr - _nextTrigger) / Common.MS_PER_SECOND;
                if (Math.Abs(offset) > TIMER_OFFSET_LIMIT)
                {
                    _nextTrigger = curr + THREAD_SPEED;
                }

                //Run managers
                PlayerManager.PlayerManager_Tick();

                MapManager.MapManager_Tick();

                GuildWar.GuildWar_Tick();
                PlayerManager.PlayerManager_Tick();

                /*if (DateTime.UtcNow.Second == 10 || DateTime.UtcNow.Second == 40)
                {

                    foreach (var user in PlayerManager.Players.Values)
                    {
                        


                        if (user != null)
                        {

                            
                            user.Save();
                            Console.WriteLine("Quartarly Save! {0} accounts saved", PlayerManager.Players.Count);

                        }
                    }


                }*/
                if (DateTime.UtcNow.Second == 00 && (DateTime.UtcNow.Minute == 15 || DateTime.UtcNow.Minute == 30 || DateTime.UtcNow.Minute == 45 || DateTime.UtcNow.Minute == 60))
                {

                    foreach (var user in PlayerManager.Players.Values)
                    {


                        if (user != null)
                        {


                            user.Save();
                            Console.WriteLine("Quartarly Save! {0} accounts saved", PlayerManager.Players.Count);

                        }
                    }


                }


                if (DateTime.UtcNow.Minute == 30 && DateTime.UtcNow.Second == 00)
                {
                    FreeForAll.StartEvent();
                }
                else if (DateTime.UtcNow.Minute == 32 && DateTime.UtcNow.Second == 00)
                {
                    foreach (var user in PlayerManager.Players.Values)
                    {
                        user.SendMessage("1 Min until event start. You can sign up at the Events Manager at Twin City!");
                    }
                    FreeForAll.Send();
                }
                else if (DateTime.UtcNow.Minute == 33 && DateTime.UtcNow.Second == 00)
                {
                    foreach (var user in PlayerManager.Players.Values)
                    {
                        user.SendMessage("3 Mins left... ");

                    }
                }
                else if (DateTime.UtcNow.Minute == 36 && DateTime.UtcNow.Second == 00)
                {
                    foreach (var user in PlayerManager.Players.Values)
                    {
                        user.SendMessage("Event has ended thank you for participation!");

                    }

                    FreeForAll.EndEvent();
                }
            }

            return true;
        }
        protected override void OnDestroy()
        {
        }
    }
}
