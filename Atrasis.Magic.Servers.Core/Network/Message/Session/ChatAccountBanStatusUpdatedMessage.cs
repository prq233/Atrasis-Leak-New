using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session
{
	// Token: 0x02000032 RID: 50
	public class ChatAccountBanStatusUpdatedMessage : ServerSessionMessage
	{
		// Token: 0x17000041 RID: 65
		// (get) Token: 0x0600011A RID: 282 RVA: 0x0000505F File Offset: 0x0000325F
		// (set) Token: 0x0600011B RID: 283 RVA: 0x00005067 File Offset: 0x00003267
		public int EndTime { get; set; }

		// Token: 0x0600011C RID: 284 RVA: 0x00005070 File Offset: 0x00003270
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt(this.EndTime);
		}

		// Token: 0x0600011D RID: 285 RVA: 0x0000507E File Offset: 0x0000327E
		public override void Decode(ByteStream stream)
		{
			this.EndTime = stream.ReadVInt();
		}

		// Token: 0x0600011E RID: 286 RVA: 0x0000508C File Offset: 0x0000328C
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.CHAT_ACCOUNT_BAN_STATUS_UPDATED;
		}

		// Token: 0x040000DE RID: 222
		[CompilerGenerated]
		private int int_2;
	}
}
