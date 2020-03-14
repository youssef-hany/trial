using System;
using System.Collections.Generic;
using Redux.Enum;
using Redux.Managers;
using Redux.Packets.Game;
using Task = Redux.Structures.Task;

namespace Redux.Npcs
{
    public class NPC_5677 : INpc
    {

        public NPC_5677(Game_Server.Player _client)
            : base(_client)
        {
            ID = 5677;
            Face = 6;
        }

        public override void Run(Game_Server.Player _client, ushort _linkback)
        {
            Responses = new List<NpcDialogPacket>();
            AddAvatar();
            switch (_linkback)
            {
                case 0:
                    {
                        if (_client.Inventory.Count < 39)
                        {
                            if (!_client.Tasks.ContainsKey(TaskType.Lottery))
                                _client.Tasks.TryAdd(TaskType.Lottery, new Task(_client.UID, TaskType.Lottery,
                               DateTime.Now.AddHours(24)));
                            if (_client.Tasks[TaskType.Lottery].Count >= 10)
                            {
                                AddText("I'm afraid you already played the lottery 10 times today");
                                AddOption("i was just getting started!", 255);
                                break;
                            }
                            else if (!_client.HasItem(710212))
                            {
                                AddText("Sorry i can't help you unless you buy a ticket!");
                                AddOption("No thanks", 255);
                                break;
                            }
                            else
                            {
                                if (_client.HasItem(710212))
                                {

                                    var ItemInfo = Common.QurryLotteryItem();
                                    var ItemID = ItemInfo.Item1;
                                    var ItemName = ItemInfo.Item3;
                                    ItemID.SetOwner(_client);



                                    if (_client.HasItem(710212) && _client.AddItem(ItemID))
                                    {
                                        _client.Tasks[TaskType.Lottery].Count++;
                                        _client.DeleteItem(710212);
                                        _client.Send(ItemInformationPacket.Create(ItemID));
                                    }
                                    else
                                    {
                                        _client.SendMessage("Error adding item");
                                    }

                                    _client.Save();


                                    string pre = "";
                                    switch (ItemInfo.Item3)
                                    {
                                        case LotteryItemType.Elite1Socket:
                                            pre = " Elite 1 socket ";

                                            break;
                                        case LotteryItemType.Elite2Socket:
                                            pre = " Elite 2 socket ";
                                            break;
                                        case LotteryItemType.ElitePlus8:
                                            pre = " Elite +8 ";
                                            break;
                                        case LotteryItemType.Super1Socket:
                                            pre = " Super 1 socket ";
                                            break;
                                        case LotteryItemType.SuperNoSocket:
                                            pre = " Super ";
                                            break;
                                    }
                                    PlayerManager.SendToServer(new TalkPacket(ChatType.GM, _client.Name + " was so lucky and won a/an " + pre + ItemInfo.Item2 + " in the lottery"));
                                }
                            }

                        }
                        else
                        {
                            AddText("I'm afraid your Inventory is full, please free some space..");
                            AddOption("Thank you i will", 255);
                            break;
                        }
                        break;

                    }

            }
            AddFinish();
            Send();
            _client.Save();

        }
    }
}
