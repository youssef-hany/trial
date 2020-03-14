/*
 * User: cookc
 * Date: 27/11/2013
 * Time: 4:10 PM 
 */
using System;
using Redux.Game_Server;
using Redux.Structures;
using Redux.Enum;
using Redux.Database;
using Redux.Database.Domain;

namespace Redux.Items
{
	/// <summary>
    /// Handles item usage for [729904] CloudSaint`sLet
	/// </summary>
    public class Item_750000 : IItem
	{
        public override void Run(Player _client, ConquerItem _item)
        {
            
            _client.HasItem(Constants.CloudSaintsJar_ID, 1);
        }
	}
}
