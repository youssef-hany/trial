using System;
using Redux.Game_Server;
using Redux.Structures;

namespace Redux.Items
{
    /// <summary>
    /// Handles item usage for [723713] Class1MoneyBag
    /// </summary>
    public class Item_723713:IItem
    {
        public override void Run(Player _client, ConquerItem _Item)
        {
            _client.DeleteItem(_Item);
            _client.Money += 300000;
            _client.SendMessage("Congratulations! You have got 300,000 silvers.");
        }
    }
    /// <summary>
    /// Handles item usage for [723714] Class2MoneyBag
    /// </summary>
    public class Item_723714:IItem
    {
        public override void Run(Player _client, ConquerItem _Item)
        {
            _client.DeleteItem(_Item);
            _client.Money += 800000;
            _client.SendMessage("Congratulations! You have got 800,000 silvers.");
        }
    }
    /// <summary>
    /// Handles item usage for [723715] Class3MoneyBag
    /// </summary>
    public class Item_723715:IItem
    {
        public override void Run(Player _client, ConquerItem _Item)
        {
            _client.DeleteItem(_Item);
            _client.Money += 1200000;
            _client.SendMessage("Congratulations! You have got 1,200,000 silvers.");
        }
    }
    /// <summary>
    /// Handles item usage for [723716] Class4MoneyBag
    /// </summary>
    public class Item_723716:IItem
    {
        public override void Run(Player _client, ConquerItem _Item)
        {
            _client.DeleteItem(_Item);
            _client.Money += 1800000;
            _client.SendMessage("Congratulations! You have got 1,800,000 silvers.");
        }
    }
    /// <summary>
    /// Handles item usage for [723717] Class5MoneyBag
    /// </summary>
    public class Item_723717:IItem
    {
        public override void Run(Player _client, ConquerItem _Item)
        {
            _client.DeleteItem(_Item);
            _client.Money += 5000000;
            _client.SendMessage("Congratulations! You have got 5,000,000 silvers.");
        }
    }
    /// <summary>
    /// Handles item usage for [723718] Class6MoneyBag
    /// </summary>
    public class Item_723718:IItem
    {
        public override void Run(Player _client, ConquerItem _Item)
        {
            _client.DeleteItem(_Item);
            _client.Money += 20000000;
            _client.SendMessage("Congratulations! You have got 20,000,000 silvers.");
        }
    }
    /// <summary>
    /// Handles item usage for [723719] Class7MoneyBag
    /// </summary>
    public class Item_723719:IItem
    {
        public override void Run(Player _client, ConquerItem _Item)
        {
            _client.DeleteItem(_Item);
            _client.Money += 25000000;
            _client.SendMessage("Congratulations! You have got 25,000,000 silvers.");
        }
    }
    /// <summary>
    /// Handles item usage for [723720] Class8MoneyBag
    /// </summary>
    public class Item_723720:IItem
    {
        public override void Run(Player _client, ConquerItem _Item)
        {
            _client.DeleteItem(_Item);
            _client.Money += 80000000;
            _client.SendMessage("Congratulations! You have got 80,000,000 silvers.");
        }
    }
    /// <summary>
    /// Handles item usage for [723721] Class9MoneyBag
    /// </summary>
    public class Item_723721:IItem
    {
        public override void Run(Player _client, ConquerItem _Item)
        {
            _client.DeleteItem(_Item);
            _client.Money += 100000000;
            _client.SendMessage("Congratulations! You have got 100,000,000 silvers.");
        }
    }
    /// <summary>
    /// Handles item usage for [723722] Class10MoneyBag
    /// </summary>
    public class Item_723722:IItem
    {
        public override void Run(Player _client, ConquerItem _Item)
        {
            _client.DeleteItem(_Item);
            _client.Money += 300000000;
            _client.SendMessage("Congratulations! You have got 300,000,000 silvers.");
        }
    }
    /// <summary>
    /// Handles item usage for [723723] TopMoneyBag
    /// </summary>
    public class Item_723723:IItem
    {
        public override void Run(Player _client, ConquerItem _Item)
        {
            _client.DeleteItem(_Item);
            _client.Money += 500000000;
            _client.SendMessage("Congratulations! You have got 500,000,000 silvers.");
        }
    }
}