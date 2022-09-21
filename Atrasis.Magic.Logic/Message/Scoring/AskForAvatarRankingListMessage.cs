using System;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Scoring
{
	// Token: 0x02000032 RID: 50
	public class AskForAvatarRankingListMessage : PiranhaMessage
	{
		// Token: 0x06000228 RID: 552 RVA: 0x0000360D File Offset: 0x0000180D
		public AskForAvatarRankingListMessage() : this(0)
		{
		}

		// Token: 0x06000229 RID: 553 RVA: 0x0000328C File Offset: 0x0000148C
		public AskForAvatarRankingListMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x0600022A RID: 554 RVA: 0x00003616 File Offset: 0x00001816
		public override void Decode()
		{
			base.Decode();
			if (this.m_stream.ReadBoolean())
			{
				this.logicLong_0 = this.m_stream.ReadLong();
			}
			this.int_0 = this.m_stream.ReadInt();
		}

		// Token: 0x0600022B RID: 555 RVA: 0x0001AC08 File Offset: 0x00018E08
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

		// Token: 0x0600022C RID: 556 RVA: 0x0000364D File Offset: 0x0000184D
		public override short GetMessageType()
		{
			return 14403;
		}

		// Token: 0x0600022D RID: 557 RVA: 0x0000329C File Offset: 0x0000149C
		public override int GetServiceNodeType()
		{
			return 28;
		}

		// Token: 0x0600022E RID: 558 RVA: 0x00003654 File Offset: 0x00001854
		public override void Destruct()
		{
			base.Destruct();
			this.logicLong_0 = null;
		}

		// Token: 0x0600022F RID: 559 RVA: 0x00003663 File Offset: 0x00001863
		public LogicLong RemoveAvatarId()
		{
			LogicLong result = this.logicLong_0;
			this.logicLong_0 = null;
			return result;
		}

		// Token: 0x06000230 RID: 560 RVA: 0x00003672 File Offset: 0x00001872
		public void SetAvatarId(LogicLong id)
		{
			this.logicLong_0 = id;
		}

		// Token: 0x06000231 RID: 561 RVA: 0x0000367B File Offset: 0x0000187B
		public int GetVillageType()
		{
			return this.int_0;
		}

		// Token: 0x06000232 RID: 562 RVA: 0x00003683 File Offset: 0x00001883
		public void SetVillageType(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x040000C4 RID: 196
		public const int MESSAGE_TYPE = 14403;

		// Token: 0x040000C5 RID: 197
		private LogicLong logicLong_0;

		// Token: 0x040000C6 RID: 198
		private int int_0;
	}
}
