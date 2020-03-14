using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redux.Packets.Game;
using Redux.Enum;

namespace Redux.Npcs
{
    //eternity 2nd reb npc 
    public class NPC_300500 : INpc
    {
        public NPC_300500(Game_Server.Player _client)
            : base(_client)
        {
            ID = 300500;
            Face = 35;
        }

        public override void Run(Game_Server.Player _client, ushort _linkback)
        {
            Responses = new List<NpcDialogPacket>();
            AddAvatar();
            switch (_linkback)
            {
                case 0:

                    if (_client.RebornCount != 0 && _client.Character.SecondQuest > 0 && _client.RebornCount < 2 && _client.Level >= (_client.ProfessionType == Enum.ProfessionType.WaterTaoist ? 110 : 120))
                    {


                        if (_client.Character.SecondQuest > 0 && _client.RebornCount < 2 && _client.Level >= (_client.ProfessionType == Enum.ProfessionType.WaterTaoist ? 110 : 120))
                        {
                            AddText("Even bold adventurers eventually grow tired of their journeys. I help these heroes by offering them life anew.");
                            AddOption("I wish to reborn.", 1);
                            AddOption("I'm not tired!", 255);
                            break;
                        }
                        else
                        {
                            AddText("Hello young one! I help people seek the ultimate goal of rebirth. ");
                            AddText("You are not yet experienced enough to undertake this adventure. ");
                            AddOption("I will.", 255);
                        }
                        break;

                    }
                    else
                    {
                        if (_client.RebornCount != 0 && _client.Character.SecondQuest == 0)
                        {
                            AddText("I cannot do the rebirth ritual if you do not open the gates of hell. Go talk to alex he will show you how..");
                            AddOption("Okay Thanks", 255);
                            break;
                        }
                        else
                        {

                            AddText("I have helped you as much as I can. Even heroes have their limits.");
                            AddOption("Thanks", 255);
                            break;
                        }
                    }
                case 1:
                    if (_client.RebornCount < 2 && _client.Character.SecondQuest > 0 && _client.Level >= (_client.ProfessionType == Enum.ProfessionType.WaterTaoist ? 110 : 120))
                    {
                        AddText("By accepting the gift of rebirth, you will start your life again. ");
                        AddText("You can unlock great strength as well as new skills in the process! ");
                        AddText("Are you sure you're ready to give up your current life? ");
                        AddOption("I'm ready.", 2);
                        AddOption("Not yet!", 255);
                        break;
                    }
                    else
                    {
                        AddText("Ooh my! Lets not get ahead of ourselves. You are not yet ready to become reborn.");
                        AddOption("Sorry.", 255);
                    }
                    break;
                case 2:
                    if (_client.HasItem(Constants.EXEMPTION_TOKEN_ID))
                    {
                        AddText("Are you sure you want to get second reborn and unlock new powers?");
                        AddOption("Yeah.", 5);
                        AddOption("I'm not sure...", 255);
                        break;
                    }
                    else
                    {
                        AddText("Rebirth requires the unlocking of great power. Please make sure you have a ExemptionToken before coming to me.");
                        AddOption("Sorry.", 255);

                    }
                    break;
                case 5:
                    AddText("What profession would you like in your new life?");
                    AddOption("Trojan", 11);
                    AddOption("Warrior", 12);
                    AddOption("Water Taoist", 13);
                    AddOption("Fire Taoist", 14);
                    AddOption("Archer", 15);
                    AddOption("I'm not sure...", 255);
                    break;
                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                    if (_client.RebornCount < 2 && _client.Character.SecondQuest > 0 && _client.Level >= (_client.ProfessionType == Enum.ProfessionType.WaterTaoist ? 110 : 120))
                    {
                        if (_client.HasItem(Constants.EXEMPTION_TOKEN_ID))
                        {
                            _client.DeleteItem(Constants.EXEMPTION_TOKEN_ID);

                            var path = (((uint)_client.Character.Profession1 -5)/10) * 100 + (((uint)_client.Character.Profession - 5))  + (uint)_linkback % 10;
                            foreach (var pathData in Database.ServerDatabase.Context.RebornPaths.GetRebornByPath(path))
                                if (pathData.IsForget)
                                    _client.CombatManager.TryRemoveSkill(pathData.SkillId);
                                else
                                    _client.CombatManager.AddOrUpdateSkill(pathData.SkillId, 0);
                            foreach (var skill in _client.CombatManager.skills.Values)
                            {
                                skill.Database.PreviousLevel = skill.Database.Level;
                                skill.Database.Level = 0;
                                skill.Database.Experience = 0;
                                skill.Save();
                                skill.Send(_client);
                            }
                            _client.CombatManager.AddOrUpdateSkill(9876, 0);
                            _client.Character.Profession2 = _client.Character.Profession;
                            switch (_linkback % 10)
                            {
                                case 1:
                                    _client.Character.Profession = 11;
                                    break;
                                case 2:
                                    _client.Character.Profession = 21;
                                    break;
                                case 3:
                                    _client.Character.Profession = 132;
                                    break;
                                case 4:
                                    _client.Character.Profession = 142;
                                    break;
                                case 5:
                                    _client.Character.Profession = 41;
                                    break;
                            }
                            
                            _client.RebornCount = 2;
                            _client.Send(new UpdatePacket(_client.UID, UpdateType.Profession, _client.Character.Profession));
                            _client.Send(new UpdatePacket(_client.UID, UpdateType.Reborn, _client.RebornCount));
                            _client.SpawnPacket.RebornCount = 1;
                            _client.SendToScreen(_client.SpawnPacket, true);

                            #region Down Level Items
                            for (ItemLocation location = ItemLocation.Helmet; location < ItemLocation.Garment; location++)
                            {
                                Structures.ConquerItem item;
                                item = _client.Equipment.GetItemBySlot(location);
                                if (item != null)
                                { item.DownLevelItem(); _client.Send(ItemInformationPacket.Create(item, ItemInfoAction.Update)); }
                            }
                            #endregion

                            #region Set Bonus Stats
                            _client.Character.Strength = 0;
                            _client.Character.Vitality = 8;
                            _client.Character.Agility = 2;
                            _client.Character.Spirit = 0;
                            switch (_client.Level)
                            {
                                case 120:
                                    _client.ExtraStats = (ushort)(20 + _client.ExtraStats);
                                    break;
                                case 121:
                                    _client.ExtraStats = (ushort)(21 + _client.ExtraStats);
                                    break;
                                case 122:
                                    _client.ExtraStats = (ushort)(23 + _client.ExtraStats);
                                    break;
                                case 123:
                                    _client.ExtraStats = (ushort)(26 + _client.ExtraStats);
                                    break;
                                case 124:
                                    _client.ExtraStats = (ushort)(30 + _client.ExtraStats);
                                    break;
                                case 125:
                                    _client.ExtraStats = (ushort)(35 + _client.ExtraStats);
                                    break;
                                case 126:
                                    _client.ExtraStats = (ushort)(41 + _client.ExtraStats);
                                    break;
                                case 127:
                                    _client.ExtraStats = (ushort)(48 + _client.ExtraStats);
                                    break;
                                case 128:
                                    _client.ExtraStats = (ushort)(56 + _client.ExtraStats);
                                    break;
                                case 129:
                                    _client.ExtraStats = (ushort)(65 + _client.ExtraStats);
                                    break;
                                case 130:
                                    _client.ExtraStats = (ushort)(75 + _client.ExtraStats);
                                    break;
                            }
                            #endregion

                            if (_client.Level > 120)
                                _client.Character.PreviousLevel = _client.Level;
                            _client.SetLevel(15);
                            _client.Experience = 0;
                            _client.Recalculate(true);
                            Managers.PlayerManager.SendToServer(new TalkPacket(ChatType.GM, _client.Name + " has been reborned successfully. Congratulations!"));
                            _client.Save();
                        }
                        else
                        {
                            AddText("Rebirth requires the unlocking of great power. Please make sure you have a ExemptionToken before coming to me.");
                            AddOption("Sorry.", 255);
                        }

                    }
                    else
                    {
                        AddText("Lets not get ahead of ourselves! You are not ready to achieve second rebirth. Please come back later.");
                        AddOption("Sorry.", 255);
                    }
                    break;

            }
            AddFinish();
            Send();
        }
    }
}