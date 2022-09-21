using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Account
{
	// Token: 0x020000B5 RID: 181
	public class AllianceUnitDonateResponseMessage : ServerAccountMessage
	{
		// Token: 0x17000135 RID: 309
		// (get) Token: 0x06000512 RID: 1298 RVA: 0x000079E1 File Offset: 0x00005BE1
		// (set) Token: 0x06000513 RID: 1299 RVA: 0x000079E9 File Offset: 0x00005BE9
		public LogicLong MemberId { get; set; }

		// Token: 0x17000136 RID: 310
		// (get) Token: 0x06000514 RID: 1300 RVA: 0x000079F2 File Offset: 0x00005BF2
		// (set) Token: 0x06000515 RID: 1301 RVA: 0x000079FA File Offset: 0x00005BFA
		public LogicLong StreamId { get; set; }

		// Token: 0x17000137 RID: 311
		// (get) Token: 0x06000516 RID: 1302 RVA: 0x00007A03 File Offset: 0x00005C03
		// (set) Token: 0x06000517 RID: 1303 RVA: 0x00007A0B File Offset: 0x00005C0B
		public LogicCombatItemData Data { get; set; }

		// Token: 0x17000138 RID: 312
		// (get) Token: 0x06000518 RID: 1304 RVA: 0x00007A14 File Offset: 0x00005C14
		// (set) Token: 0x06000519 RID: 1305 RVA: 0x00007A1C File Offset: 0x00005C1C
		public int UpgradeLevel { get; set; }

		// Token: 0x17000139 RID: 313
		// (get) Token: 0x0600051A RID: 1306 RVA: 0x00007A25 File Offset: 0x00005C25
		// (set) Token: 0x0600051B RID: 1307 RVA: 0x00007A2D File Offset: 0x00005C2D
		public bool QuickDonate { get; set; }

		// Token: 0x1700013A RID: 314
		// (get) Token: 0x0600051C RID: 1308 RVA: 0x00007A36 File Offset: 0x00005C36
		// (set) Token: 0x0600051D RID: 1309 RVA: 0x00007A3E File Offset: 0x00005C3E
		public bool Success { get; set; }

		// Token: 0x1700013B RID: 315
		// (get) Token: 0x0600051E RID: 1310 RVA: 0x00007A47 File Offset: 0x00005C47
		// (set) Token: 0x0600051F RID: 1311 RVA: 0x00007A4F File Offset: 0x00005C4F
		public string MemberName { get; set; }

		// Token: 0x06000520 RID: 1312 RVA: 0x0000D2CC File Offset: 0x0000B4CC
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.MemberId);
			stream.WriteLong(this.StreamId);
			ByteStreamHelper.WriteDataReference(stream, this.Data);
			stream.WriteVInt(this.UpgradeLevel);
			stream.WriteBoolean(this.QuickDonate);
			stream.WriteBoolean(this.Success);
			stream.WriteString(this.MemberName);
		}

		// Token: 0x06000521 RID: 1313 RVA: 0x0000D330 File Offset: 0x0000B530
		public override void Decode(ByteStream stream)
		{
			this.MemberId = stream.ReadLong();
			this.StreamId = stream.ReadLong();
			this.Data = (LogicCombatItemData)ByteStreamHelper.ReadDataReference(stream);
			this.UpgradeLevel = stream.ReadVInt();
			this.QuickDonate = stream.ReadBoolean();
			this.Success = stream.ReadBoolean();
			this.MemberName = stream.ReadString(900000);
		}

		// Token: 0x06000522 RID: 1314 RVA: 0x00007A58 File Offset: 0x00005C58
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.ALLIANCE_UNIT_DONATE_RESPONSE;
		}

		// Token: 0x0400021C RID: 540
		[CompilerGenerated]
		private LogicLong logicLong_1;

		// Token: 0x0400021D RID: 541
		[CompilerGenerated]
		private LogicLong logicLong_2;

		// Token: 0x0400021E RID: 542
		[CompilerGenerated]
		private LogicCombatItemData logicCombatItemData_0;

		// Token: 0x0400021F RID: 543
		[CompilerGenerated]
		private int int_2;

		// Token: 0x04000220 RID: 544
		[CompilerGenerated]
		private bool bool_0;

		// Token: 0x04000221 RID: 545
		[CompilerGenerated]
		private bool bool_1;

		// Token: 0x04000222 RID: 546
		[CompilerGenerated]
		private string string_0;
	}
}
