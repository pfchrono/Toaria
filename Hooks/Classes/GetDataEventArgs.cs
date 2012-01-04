using System;
using System.ComponentModel;
using Toaria;
namespace Hooks
{
	public class GetDataEventArgs : HandledEventArgs
	{
		public PacketTypes MsgID
		{
			get;
			set;
		}
		public messageBuffer Msg
		{
			get;
			set;
		}
		public int Index
		{
			get;
			set;
		}
		public int Length
		{
			get;
			set;
		}
	}
}
