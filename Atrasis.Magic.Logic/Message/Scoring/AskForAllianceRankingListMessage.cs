using System;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Scoring
{
	// Token: 0x0200002E RID: 46
	public class AskForAllianceRankingListMessage : PiranhaMessage
	{
		// Token: 0x060001FE RID: 510 RVA: 0x0000340E File Offset: 0x0000160E
		public AskForAllianceRankingListMessage() : this(0)
		{
		}

		// Token: 0x060001FF RID: 511 RVA: 0x0000328C File Offset: 0x0000148C
		public AskForAllianceRankingListMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000200 RID: 512 RVA: 0x0001AAF4 File Offset: 0x00018CF4
		public override void Decode()
		{
			base.Decode();
			if (this.m_stream.ReadBoolean())
			{
				this.logicLong_0 = this.m_stream.ReadLong();
			}
			this.bool_0 = this.m_stream.ReadBoolean();
			this.int_0 = this.m_stream.ReadInt();
		}

		// Token: 0x06000201 RID: 513 RVA: 0x0001AB48 File Offset: 0x00018D48
		public override void Encode()
		{
			base.Encode();
			if (this.logicLong_0 != null)
			{
				this.m_stream.WriteBoolean(true);
				this.m_stream.WriteLong(this.logicLong_0);
			}
			else
			{
				this.m_stream.WriteBoolean(false);
			}
			this.bool_0 = this.m_stream.ReadBoolean();
			this.int_0 = this.m_stream.ReadInt();
		}

		// Token: 0x06000202 RID: 514 RVA: 0x00003417 File Offset: 0x00001617
		public override short GetMessageType()
		{
			return 14401;
		}

		// Token: 0x06000203 RID: 515 RVA: 0x0000329C File Offset: 0x0000149C
		public override int GetServiceNodeType()
		{
			return 28;
		}

		// Token: 0x06000204 RID: 516 RVA: 0x0000341E File Offset: 0x0000161E
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06000205 RID: 517 RVA: 0x00003426 File Offset: 0x00001626
		public LogicLong RemoveAllianceId()
		{
			LogicLong result = this.logicLong_0;
			this.logicLong_0 = null;
			return result;
		}

		// Token: 0x06000206 RID: 518 RVA: 0x00003435 File Offset: 0x00001635
		public void SetAllianceId(LogicLong id)
		{
			this.logicLong_0 = id;
		}

		// Token: 0x06000207 RID: 519 RVA: 0x0000343E File Offset: 0x0000163E
		public bool GetLocalRanking()
		{
			return this.bool_0;
		}

		// Token: 0x06000208 RID: 520 RVA: 0x00003446 File Offset: 0x00001646
		public void SetLocalRanking(bool value)
		{
			this.bool_0 = value;
		}

		// Token: 0x06000209 RID: 521 RVA: 0x0000344F File Offset: 0x0000164F
		public int GetVillageType()
		{
			return this.int_0;
		}

		// Token: 0x0600020A RID: 522 RVA: 0x00003457 File Offset: 0x00001657
		public void SetVillageType(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x040000B9 RID: 185
		public const int MESSAGE_TYPE = 14401;

		// Token: 0x040000BA RID: 186
		private LogicLong logicLong_0;

		// Token: 0x040000BB RID: 187
		private int int_0;

		// Token: 0x040000BC RID: 188
		private bool bool_0;
	}
}
