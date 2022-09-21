using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Account
{
	// Token: 0x020000AF RID: 175
	public class AllianceCreateMailMessage : ServerAccountMessage
	{
		// Token: 0x17000123 RID: 291
		// (get) Token: 0x060004D6 RID: 1238 RVA: 0x0000775A File Offset: 0x0000595A
		// (set) Token: 0x060004D7 RID: 1239 RVA: 0x00007762 File Offset: 0x00005962
		public LogicLong MemberId { get; set; }

		// Token: 0x17000124 RID: 292
		// (get) Token: 0x060004D8 RID: 1240 RVA: 0x0000776B File Offset: 0x0000596B
		// (set) Token: 0x060004D9 RID: 1241 RVA: 0x00007773 File Offset: 0x00005973
		public string Message { get; set; }

		// Token: 0x060004DA RID: 1242 RVA: 0x0000777C File Offset: 0x0000597C
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.MemberId);
			stream.WriteString(this.Message);
		}

		// Token: 0x060004DB RID: 1243 RVA: 0x00007796 File Offset: 0x00005996
		public override void Decode(ByteStream stream)
		{
			this.MemberId = stream.ReadLong();
			this.Message = stream.ReadString(900000);
		}

		// Token: 0x060004DC RID: 1244 RVA: 0x000077B5 File Offset: 0x000059B5
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.ALLIANCE_CREATE_MAIL;
		}

		// Token: 0x0400020A RID: 522
		[CompilerGenerated]
		private LogicLong logicLong_1;

		// Token: 0x0400020B RID: 523
		[CompilerGenerated]
		private string string_0;
	}
}
