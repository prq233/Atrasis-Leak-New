using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Account
{
	// Token: 0x020000C7 RID: 199
	public class ServerUpdateLiveReplayMessage : ServerAccountMessage
	{
		// Token: 0x17000158 RID: 344
		// (get) Token: 0x060005A0 RID: 1440 RVA: 0x00007E99 File Offset: 0x00006099
		// (set) Token: 0x060005A1 RID: 1441 RVA: 0x00007EA1 File Offset: 0x000060A1
		public int Milliseconds { get; set; }

		// Token: 0x060005A2 RID: 1442 RVA: 0x00007EAA File Offset: 0x000060AA
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt(this.Milliseconds);
		}

		// Token: 0x060005A3 RID: 1443 RVA: 0x00007EB8 File Offset: 0x000060B8
		public override void Decode(ByteStream stream)
		{
			this.Milliseconds = stream.ReadVInt();
		}

		// Token: 0x060005A4 RID: 1444 RVA: 0x00007EC6 File Offset: 0x000060C6
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.SERVER_UPDATE_LIVE_REPLAY;
		}

		// Token: 0x0400023F RID: 575
		[CompilerGenerated]
		private int int_2;
	}
}
