using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Account
{
	// Token: 0x020000B0 RID: 176
	public class AllianceKickMemberMessage : ServerAccountMessage
	{
		// Token: 0x17000125 RID: 293
		// (get) Token: 0x060004DE RID: 1246 RVA: 0x000077BC File Offset: 0x000059BC
		// (set) Token: 0x060004DF RID: 1247 RVA: 0x000077C4 File Offset: 0x000059C4
		public LogicLong MemberId { get; set; }

		// Token: 0x17000126 RID: 294
		// (get) Token: 0x060004E0 RID: 1248 RVA: 0x000077CD File Offset: 0x000059CD
		// (set) Token: 0x060004E1 RID: 1249 RVA: 0x000077D5 File Offset: 0x000059D5
		public LogicLong KickMemberId { get; set; }

		// Token: 0x17000127 RID: 295
		// (get) Token: 0x060004E2 RID: 1250 RVA: 0x000077DE File Offset: 0x000059DE
		// (set) Token: 0x060004E3 RID: 1251 RVA: 0x000077E6 File Offset: 0x000059E6
		public string Message { get; set; }

		// Token: 0x060004E4 RID: 1252 RVA: 0x000077EF File Offset: 0x000059EF
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.MemberId);
			stream.WriteLong(this.KickMemberId);
			stream.WriteString(this.Message);
		}

		// Token: 0x060004E5 RID: 1253 RVA: 0x00007815 File Offset: 0x00005A15
		public override void Decode(ByteStream stream)
		{
			this.MemberId = stream.ReadLong();
			this.KickMemberId = stream.ReadLong();
			this.Message = stream.ReadString(900000);
		}

		// Token: 0x060004E6 RID: 1254 RVA: 0x00007840 File Offset: 0x00005A40
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.ALLIANCE_KICK_MEMBER;
		}

		// Token: 0x0400020C RID: 524
		[CompilerGenerated]
		private LogicLong logicLong_1;

		// Token: 0x0400020D RID: 525
		[CompilerGenerated]
		private LogicLong logicLong_2;

		// Token: 0x0400020E RID: 526
		[CompilerGenerated]
		private string string_0;
	}
}
