using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Account
{
	// Token: 0x020000B2 RID: 178
	public class AllianceRequestAllianceUnitsMessage : ServerAccountMessage
	{
		// Token: 0x17000129 RID: 297
		// (get) Token: 0x060004EE RID: 1262 RVA: 0x0000787B File Offset: 0x00005A7B
		// (set) Token: 0x060004EF RID: 1263 RVA: 0x00007883 File Offset: 0x00005A83
		public LogicLong MemberId { get; set; }

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x060004F0 RID: 1264 RVA: 0x0000788C File Offset: 0x00005A8C
		// (set) Token: 0x060004F1 RID: 1265 RVA: 0x00007894 File Offset: 0x00005A94
		public string Message { get; set; }

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x060004F2 RID: 1266 RVA: 0x0000789D File Offset: 0x00005A9D
		// (set) Token: 0x060004F3 RID: 1267 RVA: 0x000078A5 File Offset: 0x00005AA5
		public int CastleUpgradeLevel { get; set; }

		// Token: 0x1700012C RID: 300
		// (get) Token: 0x060004F4 RID: 1268 RVA: 0x000078AE File Offset: 0x00005AAE
		// (set) Token: 0x060004F5 RID: 1269 RVA: 0x000078B6 File Offset: 0x00005AB6
		public int CastleUsedCapacity { get; set; }

		// Token: 0x1700012D RID: 301
		// (get) Token: 0x060004F6 RID: 1270 RVA: 0x000078BF File Offset: 0x00005ABF
		// (set) Token: 0x060004F7 RID: 1271 RVA: 0x000078C7 File Offset: 0x00005AC7
		public int CastleTotalCapacity { get; set; }

		// Token: 0x1700012E RID: 302
		// (get) Token: 0x060004F8 RID: 1272 RVA: 0x000078D0 File Offset: 0x00005AD0
		// (set) Token: 0x060004F9 RID: 1273 RVA: 0x000078D8 File Offset: 0x00005AD8
		public int CastleSpellUsedCapacity { get; set; }

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x060004FA RID: 1274 RVA: 0x000078E1 File Offset: 0x00005AE1
		// (set) Token: 0x060004FB RID: 1275 RVA: 0x000078E9 File Offset: 0x00005AE9
		public int CastleSpellTotalCapacity { get; set; }

		// Token: 0x060004FC RID: 1276 RVA: 0x0000D200 File Offset: 0x0000B400
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.MemberId);
			stream.WriteString(this.Message);
			stream.WriteVInt(this.CastleUpgradeLevel);
			stream.WriteVInt(this.CastleUsedCapacity);
			stream.WriteVInt(this.CastleTotalCapacity);
			stream.WriteVInt(this.CastleSpellUsedCapacity);
			stream.WriteVInt(this.CastleSpellTotalCapacity);
		}

		// Token: 0x060004FD RID: 1277 RVA: 0x0000D264 File Offset: 0x0000B464
		public override void Decode(ByteStream stream)
		{
			this.MemberId = stream.ReadLong();
			this.Message = stream.ReadString(900000);
			this.CastleUpgradeLevel = stream.ReadVInt();
			this.CastleUsedCapacity = stream.ReadVInt();
			this.CastleTotalCapacity = stream.ReadVInt();
			this.CastleSpellUsedCapacity = stream.ReadVInt();
			this.CastleSpellTotalCapacity = stream.ReadVInt();
		}

		// Token: 0x060004FE RID: 1278 RVA: 0x000078F2 File Offset: 0x00005AF2
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.ALLIANCE_REQUEST_ALLIANCE_UNITS;
		}

		// Token: 0x04000210 RID: 528
		[CompilerGenerated]
		private LogicLong logicLong_1;

		// Token: 0x04000211 RID: 529
		[CompilerGenerated]
		private string string_0;

		// Token: 0x04000212 RID: 530
		[CompilerGenerated]
		private int int_2;

		// Token: 0x04000213 RID: 531
		[CompilerGenerated]
		private int int_3;

		// Token: 0x04000214 RID: 532
		[CompilerGenerated]
		private int int_4;

		// Token: 0x04000215 RID: 533
		[CompilerGenerated]
		private int int_5;

		// Token: 0x04000216 RID: 534
		[CompilerGenerated]
		private int int_6;
	}
}
