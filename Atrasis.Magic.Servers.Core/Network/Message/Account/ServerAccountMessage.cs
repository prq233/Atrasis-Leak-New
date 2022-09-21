using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Account
{
	// Token: 0x020000C6 RID: 198
	public abstract class ServerAccountMessage : ServerMessage
	{
		// Token: 0x17000157 RID: 343
		// (get) Token: 0x0600059A RID: 1434 RVA: 0x00007E5E File Offset: 0x0000605E
		// (set) Token: 0x0600059B RID: 1435 RVA: 0x00007E66 File Offset: 0x00006066
		public LogicLong AccountId { get; set; }

		// Token: 0x0600059C RID: 1436 RVA: 0x00007E6F File Offset: 0x0000606F
		public sealed override void EncodeHeader(ByteStream stream)
		{
			base.EncodeHeader(stream);
			stream.WriteLong(this.AccountId);
		}

		// Token: 0x0600059D RID: 1437 RVA: 0x00007E84 File Offset: 0x00006084
		public sealed override void DecodeHeader(ByteStream stream)
		{
			base.DecodeHeader(stream);
			this.AccountId = stream.ReadLong();
		}

		// Token: 0x0600059E RID: 1438 RVA: 0x0000598D File Offset: 0x00003B8D
		public sealed override ServerMessageCategory GetMessageCategory()
		{
			return ServerMessageCategory.ACCOUNT;
		}

		// Token: 0x0400023E RID: 574
		[CompilerGenerated]
		private LogicLong logicLong_0;
	}
}
