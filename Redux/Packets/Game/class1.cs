using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redux.Game_Server;

namespace Redux.Packets.Game
{
    class CoolEffect
    {
        public static void ActiveCool(Player MyClient)
        {
            byte counter = 0;

            for (byte i = 1; i < 9; i++)
            {
                if (i == 7) i++;
                ItemInformationPacket I = MyClient.Equipment.GetEnumerator(i);
                if (I.ID != 0)
                {
                    Game.ItemIDManipulation Q = new NewestCOServer.Game.ItemIDManipulation(I.ID);
                    if (Q.Quality == Game.Item.ItemQuality.Super)
                        counter += 1;
                }
            }

            if (MyClient.MyChar.Job >= 100)
                if (counter == 6)
                    counter = 7;
            if (MyClient.MyChar.Job >= 40 && MyClient.MyChar.Job <= 45)
                if (counter == 6)
                {
                    Game.Item I = MyClient.MyChar.Equips.Get(5);
                    I.ID = MyClient.MyChar.Equips.LeftHand.ID;
                    if (I.ID == 0)
                        counter = 7;
                }
            if (counter == 7)
            {
                if (MyClient.MyChar.Job >= 10 && MyClient.MyChar.Job <= 15)
                    MyClient.AddSend(Packets.String(MyClient.MyChar.EntityID, 10, "warrior"));
                else if (MyClient.MyChar.Job >= 20 && MyClient.MyChar.Job <= 25)
                    MyClient.AddSend(Packets.String(MyClient.MyChar.EntityID, 10, "fighter"));
                else if (MyClient.MyChar.Job >= 100)
                    MyClient.AddSend(Packets.String(MyClient.MyChar.EntityID, 10, "taoist"));
                else if (MyClient.MyChar.Job >= 39 && MyClient.MyChar.Job <= 46)
                    MyClient.AddSend(Packets.String(MyClient.MyChar.EntityID, 10, "archer"));
            }
            else
            {
                if (MyClient.MyChar.Job >= 10 && MyClient.MyChar.Job <= 15)
                    MyClient.AddSend(Packets.String(MyClient.MyChar.EntityID, 10, "warrior-s"));
                else if (MyClient.MyChar.Job >= 20 && MyClient.MyChar.Job <= 25)
                    MyClient.AddSend(Packets.String(MyClient.MyChar.EntityID, 10, "fighter-s"));
                else if (MyClient.MyChar.Job >= 100)
                    MyClient.AddSend(Packets.String(MyClient.MyChar.EntityID, 10, "taoist-s"));
                else if (MyClient.MyChar.Job >= 39 && MyClient.MyChar.Job <= 46)
                    MyClient.AddSend(Packets.String(MyClient.MyChar.EntityID, 10, "archer-s"));
            }
            MyClient.MyChar.Action = 100;

        }
    }
}


