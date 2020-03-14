/*
 * User: 0din
 * Date: 7/20/2013
 * Time: 11:42 AM
 */
using System;
using Redux.Game_Server;
using Redux.Structures;
using System.Linq;
using System.Linq.Expressions;

namespace Redux.Items
{
    /// <summary>s
    /// Handles item usage for [1060031] WindSpell #1
    /// </summary>
    public class Item_1060031: IItem
	{
        public override void Run(Player _client, ConquerItem _item)
        {
            if (_client.Map.IsNoScrollEnabled)
                return;
            _client.ChangeMap(1020, 824,601);
            _client.DeleteItem(_item);
            _client.Save();
        }
	}
}
