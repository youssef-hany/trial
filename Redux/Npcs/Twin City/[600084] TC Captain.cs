using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redux.Packets.Game;
using Redux.Enum;
using Redux.Database.Domain;
using Redux.Structures;

namespace Redux.Npcs
{
    /// <summary>
    /// Handles NPC usage for [600084] TC Captain
    /// </summary>
    public class NPC_600084 : INpc
    {

        public NPC_600084(Game_Server.Player _client)
            : base(_client)
        {
            ID = 600084;
            Face = 111;
        }


        public override void Run(Game_Server.Player _client, ushort _linkback)
        {
            ushort Max1;
            Responses = new List<NpcDialogPacket>();
            AddAvatar();
            switch (_linkback)
            {
                case 0:
                    AddText("Hello, i can help you gain experience to level up easier");
                    AddOption("This is great..", 1);
                    AddOption("Just passing by.", 255);
                    break;

                case 1:
                    var Jar = _client.GetItemByID(750000);
                    Max1 = 100;                
                    if (Jar == null) {
                        AddText("To level up faster you need to collect the souls of 100 pheasants inside this Jar ");
                        AddOption("Looks easy, give me..", 2);
                        AddOption("Just passing by.", 255);
                    }
                    else if(Jar != null && Jar.MaximumDurability == 1)
                    {
                        AddText("You have not completed collection of the souls of the previous Jar please complete it then come back");
                        
                        AddOption("I see..", 255);

                    }
                    else if (Jar != null && Jar.MaximumDurability != 1)
                    {
                        AddText("You already have a Jar (from another captain) but i will give you another one and thats it..");
                        AddOption("thank you alot", 2);
                        AddOption("I see..", 255);

                    }
                    else if (Jar != null && Jar.Durability == Max1)
                    {
                        AddText("You have finished collecting souls and here is your reward");
                        AddOption("thank you alot", 2);
                        AddOption("I see..", 255);

                    }

                    break;

                case 2:
                    Max1 = 100;
                    DbTask task = new DbTask();

                    task = Database.ServerDatabase.Context.Tasks.GetTasksByPlayerUID(_client.UID, 1);
                    if (task == null)
                    {

                        _client.CreateJar(Max1, 1, 750000);
                        _client.Save();
                        

                        AddText("I gave you the item now go hunt pheasant");
                    }
                    else
                        AddText("I'm sorry");
                    AddOption("Thanks", 255);
                    break;
            }
            AddFinish();
            Send();

        }
    }

}
