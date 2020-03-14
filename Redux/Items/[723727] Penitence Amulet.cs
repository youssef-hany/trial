/*
 * User: cookc
 * Date: 27/11/2013
 * Time: 4:10 PM 
 * 
 *Coded By Odin
 */
using System;
using Redux.Game_Server;
using Redux.Structures;
using Redux.Enum;
namespace Redux.Items
{
    /// <summary>
    /// Handles item usage for [723727] Penitence Amulet
    /// </summary>
    public class Item_723727: IItem
	{		
        public override void Run(Player _client, ConquerItem _item) 
        {
            short PK = _client.Character.Pk;
            if (PK < 30)
                _client.SendMessage("You must have 30 PK points or more to use this item.");


            else if (_client.MapID == 6000)
            {
                _client.SendMessage("This Item cannot be used in Jail..");
            }
            else
            {
                _client.Character.Pk -= 30;
                _client.Send(Packets.Game.UpdatePacket.Create(_client.UID, UpdateType.Pk, (ulong)_client.PK));
       
                _client.DeleteItem(_item);
            }
            _client.Save();



        }
	}
}
