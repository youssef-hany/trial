using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Redux.Game_Server;
using Redux.Managers;
using Redux.Enum;

namespace Redux.Packets.Game
{
    /// <summary>
    /// MessageBoard packet structure.
    /// Written by Aceking 2-10-2014
    /// </summary>
    public unsafe struct MessageBoard
    {
        public ushort Index;
        public ushort BoardID;
        public MessageBoardAction Action;
        public ushort Size;
        public List<MessageBoardMessage> Board;
        #region Name
        private fixed sbyte _name[Constants.MAX_NAMESIZE];
        public string Name
        {
            get
            {
                fixed (sbyte* ptr = _name)
                {
                    return new string(ptr).TrimEnd('\0');
                }
            }
            set
            {
                fixed (sbyte* ptr = _name)
                {
                    MSVCRT.memset(ptr, 0, Constants.MAX_NAMESIZE);
                    value.CopyTo(ptr);
                }
            }
        }
        #endregion
        #region Message
        private fixed sbyte _message[80];
        public string Message
        {
            get
            {
                fixed (sbyte* ptr = _message)
                {
                    return new string(ptr).TrimEnd('\0');
                }
            }
            set
            {
                fixed (sbyte* ptr = _message)
                {
                    MSVCRT.memset(ptr, 0, 80);
                    value.CopyTo(ptr);
                }
            }
        }
        #endregion
        #region Date
        private fixed sbyte _date[Constants.MAX_NAMESIZE];
        public string Date
        {
            get
            {
                fixed (sbyte* ptr = _date)
                {
                    return new string(ptr).TrimEnd('\0');
                }
            }
            set
            {
                fixed (sbyte* ptr = _date)
                {
                    MSVCRT.memset(ptr, 0, Constants.MAX_NAMESIZE);
                    value.CopyTo(ptr);
                }
            }
        }
        #endregion


        public static MessageBoard Create()
        {
            MessageBoard packet = new MessageBoard();

            return packet;
        }

        public static implicit operator MessageBoard(byte* ptr)
        {
            var packet = new MessageBoard();
            packet.Index = *((ushort*)(ptr + 4));
            packet.BoardID = *((ushort*)(ptr + 6));
            packet.Action = *((MessageBoardAction*)(ptr + 8));
            packet.Size = *((ushort*)(ptr + 9));
            if (packet.Action == MessageBoardAction.Del || packet.Action == MessageBoardAction.GetWords)
            {
                byte len = *((byte*)(ptr + 10));
                Redux.MSVCRT.memcpy(packet._name, ptr + 11, (int)len);
            }
            return packet;
        }

        public static implicit operator byte[](MessageBoard packet)
        {
            uint PackSize = 40;
            if (packet.Board != null)
                foreach (var MSG in packet.Board)
                    PackSize += (uint)(MSG.Author.Length + MSG.Date.Length + MSG.Message.Length + 3);

            var buffer = new byte[PackSize];
            fixed (byte* ptr = buffer)
            {
                PacketBuilder.AppendHeader(ptr, buffer.Length, 1111);
                *((ushort*)(ptr + 4)) = packet.Index;
                *((ushort*)(ptr + 6)) = packet.BoardID;
                *((MessageBoardAction*)(ptr + 8)) = packet.Action;


                if (packet.Board != null)
                {
                    *((ushort*)(ptr + 9)) = (ushort)(Math.Min(packet.Board.Count * 3, 36));

                    int Offset = 0;
                    foreach (var msg in packet.Board)
                    {
                        packet.Name = msg.Author;
                        //Name
                        *((byte*)(ptr + 10 + Offset)) = (byte)packet.Name.Length;
                        Redux.MSVCRT.memcpy(ptr + 11 + Offset, packet._name, packet.Name.Length);

                        packet.Message = msg.Message;
                        //Message
                        *((byte*)(ptr + 11 + packet.Name.Length + Offset)) = (byte)packet.Message.Length;
                        Redux.MSVCRT.memcpy(ptr + 12 + packet.Name.Length + Offset, packet._message, packet.Message.Length);

                        packet.Date = msg.Date;
                        //Date
                        *((byte*)(ptr + 12 + packet.Name.Length + packet.Message.Length + Offset)) = (byte)packet.Date.Length;
                        Redux.MSVCRT.memcpy(ptr + 13 + packet.Name.Length + packet.Message.Length + Offset, packet._date, packet.Date.Length);

                        Offset += packet.Name.Length + packet.Message.Length + packet.Date.Length + 3;
                    }

                }


            }
            return buffer;
        }
    }
}
