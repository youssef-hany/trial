using System;
using Redux.Game_Server;
using Redux.Enum;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace Redux.Managers
{
    /// <summary>
    /// Structure for each message on the message board.
    /// Written by Aceking 2-10-2014
    /// </summary>
    public struct MessageBoardMessage
    {
        public string Author;
        public string Message;
        public string Date; //yyyyMMddHHmmss
    }
    /// <summary>
    /// Manages the list of messages for each message board.
    /// Written by Aceking 2-10-2014
    /// </summary>
    /// 
    public static class MessageBoardManager
    {

        //Declare and Initialize all the message board lists.
        public static List<MessageBoardMessage> Trade = new List<MessageBoardMessage>();
        public static List<MessageBoardMessage> Friends = new List<MessageBoardMessage>();
        public static List<MessageBoardMessage> Team = new List<MessageBoardMessage>();
        public static List<MessageBoardMessage> Guild = new List<MessageBoardMessage>();
        public static List<MessageBoardMessage> Other = new List<MessageBoardMessage>();

        #region Add Message
        /// <summary>
        /// Adds the new message to the START of the list.
        /// We want to display new messages first, and inserting at Index 0 is more efficient than sorting the list.
        /// </summary>
        /// <param name="Author"></param>
        /// <param name="Message"></param>
        /// <param name="Date"></param>
        /// <param name="Channel"></param>
        /// <returns></returns>
        public static bool Add(string Author, string Message, string Date, uint Channel)
        {
            MessageBoardMessage Entry;
            Entry.Author = Author;
            Entry.Message = Message;
            Entry.Date = Date;

            switch (Channel)
            {
                //Trade
                case 2201:
                    Trade.Insert(0, Entry);
                    break;
                //Friends
                case 2202:
                    Friends.Insert(0, Entry);
                    break;
                //Team
                case 2203:
                    Team.Insert(0, Entry);
                    break;
                //Guild
                case 2204:
                    Guild.Insert(0, Entry);
                    break;
                //Other
                case 2205:
                    Other.Insert(0, Entry);
                    break;
            }
            return true;
        }
        #endregion
        #region Delete Message
        public static bool Delete(MessageBoardMessage Message, uint Channel)
        {
            switch (Channel)
            {
                //Trade
                case 2201:
                    if (Trade.Contains(Message))
                        Trade.Remove(Message);
                    break;
                //Friends
                case 2202:
                    if (Friends.Contains(Message))
                        Friends.Remove(Message);
                    break;
                //Team
                case 2203:
                    if (Team.Contains(Message))
                        Team.Remove(Message);
                    break;
                //Guild
                case 2204:
                    if (Guild.Contains(Message))
                        Guild.Remove(Message);
                    break;
                //Other
                case 2205:
                    if (Other.Contains(Message))
                        Other.Remove(Message);
                    break;
            }
            return true;
        }
        #endregion
        #region Find Message by Author
        public static MessageBoardMessage FindMessage(string Author, uint Channel)
        {
            List<MessageBoardMessage> Board = new System.Collections.Generic.List<MessageBoardMessage>();
            switch (Channel)
            {
                //Trade
                case 2201:
                    Board = Trade;
                    break;
                //Friends
                case 2202:
                    Board = Friends;
                    break;
                //Team
                case 2203:
                    Board = Team;
                    break;
                //Guild
                case 2204:
                    Board = Guild;
                    break;
                //Other
                case 2205:
                    Board = Other;
                    break;
            }

            foreach (var msg in Board)
            {
                if (msg.Author == Author)
                    return msg;
            }

            //Default
            return new MessageBoardMessage();
        }
        #endregion
        #region Get List by Channel
        public static List<MessageBoardMessage> GetList(uint Channel, uint Index)
        {
            List<MessageBoardMessage> Board = new System.Collections.Generic.List<MessageBoardMessage>();

            switch (Channel)
            {
                //Trade
                case 2201:
                    Board = Trade;
                    break;
                //Friends
                case 2202:
                    Board = Friends;
                    break;
                //Team
                case 2203:
                    Board = Team;
                    break;
                //Guild
                case 2204:
                    Board = Guild;
                    break;
                //Other
                case 2205:
                    Board = Other;
                    break;
            }

            ///Rather complicated. Checks the board to see if there is enough listings to display a new page.
            ///TQ sends the page # in increments of 8. Example: 0 = 1st Page, 8 = 2nd Page, 16 = 3rd Page etc etc
            ///So this checks to see if there is enough to send a full page (12 listings)
            ///If there isnt, it checks to see if there is enough to send a partial page.
            ///If there isnt, it sends a blank page.

            if (Board != null && Board.Count > 0)
            {
                switch (Index)
                {
                    case 0:
                        if (Board.Count >= 12)
                            return Board.GetRange(0, 12);
                        else
                            return Board.GetRange(0, Board.Count);
                    default:
                        if (Board.Count > (Index / 8) * 12)
                        {
                            if (Board.Count >= ((Index / 8) * 12) + 12)
                                return Board.GetRange((int)(((Index / 8) * 12)), 12);
                            else
                                return Board.GetRange((int)(((Index / 8) * 12)), Board.Count - (int)((Index / 8) * 12));
                        }
                        else
                            return new System.Collections.Generic.List<MessageBoardMessage>();

                }
            }
            else
                return new System.Collections.Generic.List<MessageBoardMessage>();
        }
        #endregion
        #region Create Message
        public static MessageBoardMessage Create(string Author, string Message, string Date)
        {
            MessageBoardMessage msg = new MessageBoardMessage();
            msg.Author = Author;
            msg.Message = Message;
            msg.Date = Date;

            return msg;
        }
        #endregion

    }
}