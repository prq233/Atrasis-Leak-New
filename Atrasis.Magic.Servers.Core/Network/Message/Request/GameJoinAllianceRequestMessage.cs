using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request
{
	// Token: 0x02000080 RID: 128
	public class GameJoinAllianceRequestMessage : ServerRequestMessage
	{
		// Token: 0x170000DB RID: 219
		// (get) Token: 0x0600039C RID: 924 RVA: 0x00006A6F File Offset: 0x00004C6F
		// (set) Token: 0x0600039D RID: 925 RVA: 0x00006A77 File Offset: 0x00004C77
		public LogicLong AccountId { get; set; }

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x0600039E RID: 926 RVA: 0x00006A80 File Offset: 0x00004C80
		// (set) Token: 0x0600039F RID: 927 RVA: 0x00006A88 File Offset: 0x00004C88
		public LogicLong AllianceId { get; set; }

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x060003A0 RID: 928 RVA: 0x00006A91 File Offset: 0x00004C91
		// (set) Token: 0x060003A1 RID: 929 RVA: 0x00006A99 File Offset: 0x00004C99
		public LogicLong AvatarStreamId { get; set; }

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x060003A2 RID: 930 RVA: 0x00006AA2 File Offset: 0x00004CA2
		// (set) Token: 0x060003A3 RID: 931 RVA: 0x00006AAA File Offset: 0x00004CAA
		public bool Created { get; set; }

		// Token: 0x170000DF RID: 223
		// (get) Token: 0x060003A4 RID: 932 RVA: 0x00006AB3 File Offset: 0x00004CB3
		// (set) Token: 0x060003A5 RID: 933 RVA: 0x00006ABB File Offset: 0x00004CBB
		public bool Invited { get; set; }

		// Token: 0x060003A6 RID: 934 RVA: 0x0000CB7C File Offset: 0x0000AD7C
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.AccountId);
			stream.WriteLong(this.AllianceId);
			stream.WriteBoolean(this.Created);
			stream.WriteBoolean(this.Invited);
			stream.WriteBoolean(this.AvatarStreamId != null);
			if (this.AvatarStreamId != null)
			{
				stream.WriteLong(this.AvatarStreamId);
			}
		}

		// Token: 0x060003A7 RID: 935 RVA: 0x0000CBDC File Offset: 0x0000ADDC
		public override void Decode(ByteStream stream)
		{
			this.AccountId = stream.ReadLong();
			this.AllianceId = stream.ReadLong();
			this.Created = stream.ReadBoolean();
			this.Invited = stream.ReadBoolean();
			if (stream.ReadBoolean())
			{
				this.AvatarStreamId = stream.ReadLong();
			}
		}

		// Token: 0x060003A8 RID: 936 RVA: 0x00006AC4 File Offset: 0x00004CC4
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.GAME_JOIN_ALLIANCE_REQUEST;
		}

		// Token: 0x040001AC RID: 428
		[CompilerGenerated]
		private LogicLong logicLong_0;

		// Token: 0x040001AD RID: 429
		[CompilerGenerated]
		private LogicLong logicLong_1;

		// Token: 0x040001AE RID: 430
		[CompilerGenerated]
		private LogicLong logicLong_2;

		// Token: 0x040001AF RID: 431
		[CompilerGenerated]
		private bool bool_0;

		// Token: 0x040001B0 RID: 432
		[CompilerGenerated]
		private bool bool_1;
	}
}
