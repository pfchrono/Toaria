﻿using System.ComponentModel;
using Toaria;

namespace TerrariaAPI.Hooks
{
    public class SendDataEventArgs : HandledEventArgs
    {
        public PacketTypes MsgID { get; set; }
        public int remoteClient { get; set; }
        public int ignoreClient { get; set; }
        public string text { get; set; }
        public int number { get; set; }
        public float number2 { get; set; }
        public float number3 { get; set; }
        public float number4 { get; set; }
    }

    public class GetDataEventArgs : HandledEventArgs
    {
        public PacketTypes MsgID { get; set; }
        public messageBuffer Msg { get; set; }
        public int Index { get; set; }
        public int Length { get; set; }
    }

    public static class NetHooks
    {
        public delegate void SendDataD(SendDataEventArgs e);
        public static event SendDataD SendData;

        public static bool OnSendData(ref int msgType, ref int remoteClient, ref int ignoreClient, ref string text, ref int number, ref float number2, ref float number3, ref float number4)
        {
            if (SendData == null)
                return false;

            var args = new SendDataEventArgs()
            {
                MsgID = (PacketTypes)msgType,
                remoteClient = remoteClient,
                ignoreClient = ignoreClient,
                text = text,
                number = number,
                number2 = number2,
                number3 = number3,
                number4 = number4,
            };

            SendData(args);

            msgType = (int)args.MsgID;
            remoteClient = args.remoteClient;
            ignoreClient = args.ignoreClient;
            text = args.text;
            number = args.number;
            number2 = args.number2;
            number3 = args.number3;
            number4 = args.number4;

            return args.Handled;
        }

        public delegate void GetDataD(GetDataEventArgs e);
        public static event GetDataD GetData;

        public static bool OnGetData(ref byte msgid, messageBuffer msg, ref int idx, ref int length)
        {
            if (GetData == null)
                return false;

            var args = new GetDataEventArgs()
            {
                MsgID = (PacketTypes)msgid,
                Msg = msg,
                Index = idx,
                Length = length
            };

            GetData(args);

            msgid = (byte)args.MsgID;
            idx = args.Index;
            length = args.Length;

            return args.Handled;
        }

        public delegate void GreetPlayerD(int who, HandledEventArgs e);
        public static event GreetPlayerD GreetPlayer;

        public static bool OnGreetPlayer(int who)
        {
            if (GreetPlayer == null)
                return false;

            var args = new HandledEventArgs();
            GreetPlayer(who, args);
            return args.Handled;
        }

        public delegate void SendBytesD(ServerSock socket, byte[] buffer, int offset, int count, HandledEventArgs e);
        /// <summary>
        /// Called before bytes are sent to a client. Handled stops bytes from being sent
        /// </summary>
        public static event SendBytesD SendBytes;
        public static bool OnSendBytes(ServerSock socket, byte[] buffer, int offset, int count)
        {
            if (SendBytes == null)
                return false;

            var args = new HandledEventArgs();
            SendBytes(socket, buffer, offset, count, args);
            return args.Handled;
        }

    }
}