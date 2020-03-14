/*
 * User: M e n a
 * Date: 25/1/2015
 * Time: 3:26 AM
 * [723711] MeteorTearPack
 */
using System;
using Redux.Game_Server;
using Redux.Structures;

namespace Redux.Items
{
    /// <summary>
    /// Handles item usage for [723711] MeteorTearPack
    /// </summary>
    public class Item_723711 : IItem
    {
        public override void Run(Player _client, ConquerItem _item)
        {
            if (_client.Inventory.Count > 35)
                return;
            _client.DeleteItem(_item);
            for (var i = 0; i < 5; i++)
                _client.CreateItem(Constants.Meteor_Tear_ID);
        }
    }
}
