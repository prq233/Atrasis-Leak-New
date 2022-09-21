using System;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Scoring
{
	// Token: 0x02000031 RID: 49
	public class AskForAvatarLocalRankingListMessage : PiranhaMessage
	{
		// Token: 0x0600021D RID: 541 RVA: 0x0000358E File Offset: 0x0000178E
		public AskForAvatarLocalRankingListMessage() : this(0)
		{
		}

		// Token: 0x0600021E RID: 542 RVA: 0x0000328C File Offset: 0x0000148C
		public AskForAvatarLocalRankingListMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x0600021F RID: 543 RVA: 0x00003597 File Offset: 0x00001797
		public override void Decode()
		{
			base.Decode();
			if (this.m_stream.ReadBoolean())
			{
				this.logicLong_0 = this.m_stream.ReadLong();
			}
			this.int_0 = this.m_stream.ReadInt();
		}

		// Token: 0x06000220 RID: 544 RVA: 0x0001ABB0 File Offset: 0x00018DB0
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
			this.int_0 = this.m_stream.ReadInt();
		}

		// Token: 0x06000221 RID: 545 RVA: 0x000035CE File Offset: 0x000017CE
		public override short GetMessageType()
		{
			return 14404;
		}

		// Token: 0x06000222 RID: 546 RVA: 0x0000329C File Offset: 0x0000149C
		public override int GetServiceNodeType()
		{
			return 28;
		}

		// Token: 0x06000223 RID: 547 RVA: 0x000035D5 File Offset: 0x000017D5
		public override void Destruct()
		{
			base.Destruct();
			this.logicLong_0 = null;
		}

		// Token: 0x06000224 RID: 548 RVA: 0x000035E4 File Offset: 0x000017E4
		public LogicLong RemoveAvatarId()
		{
			LogicLong result = this.logicLong_0;
			this.logicLong_0 = null;
			return result;
		}

		// Token: 0x06000225 RID: 549 RVA: 0x000035F3 File Offset: 0x000017F3
		public void SetAvatarId(LogicLong id)
		{
			this.logicLong_0 = id;
		}

		// Token: 0x06000226 RID: 550 RVA: 0x000035FC File Offset: 0x000017FC
		public int GetVillageType()
		{
			return this.int_0;
		}

		// Token: 0x06000227 RID: 551 RVA: 0x00003604 File Offset: 0x00001804
		public void SetVillageType(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x040000C1 RID: 193
		public const int MESSAGE_TYPE = 14404;

		// Token: 0x040000C2 RID: 194
		private LogicLong logicLong_0;

		// Token: 0x040000C3 RID: 195
		private int int_0;
	}
}
