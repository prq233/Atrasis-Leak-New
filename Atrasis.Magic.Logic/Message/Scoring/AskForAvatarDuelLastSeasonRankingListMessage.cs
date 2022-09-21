using System;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Scoring
{
	// Token: 0x0200002F RID: 47
	public class AskForAvatarDuelLastSeasonRankingListMessage : PiranhaMessage
	{
		// Token: 0x0600020B RID: 523 RVA: 0x00003460 File Offset: 0x00001660
		public AskForAvatarDuelLastSeasonRankingListMessage() : this(0)
		{
		}

		// Token: 0x0600020C RID: 524 RVA: 0x0000328C File Offset: 0x0000148C
		public AskForAvatarDuelLastSeasonRankingListMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x0600020D RID: 525 RVA: 0x00003469 File Offset: 0x00001669
		public override void Decode()
		{
			base.Decode();
			if (this.m_stream.ReadBoolean())
			{
				this.logicLong_0 = this.m_stream.ReadLong();
			}
		}

		// Token: 0x0600020E RID: 526 RVA: 0x0000348F File Offset: 0x0000168F
		public override void Encode()
		{
			base.Encode();
			if (this.logicLong_0 != null)
			{
				this.m_stream.WriteBoolean(true);
				this.m_stream.WriteLong(this.logicLong_0);
				return;
			}
			this.m_stream.WriteBoolean(false);
		}

		// Token: 0x0600020F RID: 527 RVA: 0x000034C9 File Offset: 0x000016C9
		public override short GetMessageType()
		{
			return 14408;
		}

		// Token: 0x06000210 RID: 528 RVA: 0x0000329C File Offset: 0x0000149C
		public override int GetServiceNodeType()
		{
			return 28;
		}

		// Token: 0x06000211 RID: 529 RVA: 0x000034D0 File Offset: 0x000016D0
		public override void Destruct()
		{
			base.Destruct();
			this.logicLong_0 = null;
		}

		// Token: 0x06000212 RID: 530 RVA: 0x000034DF File Offset: 0x000016DF
		public LogicLong RemoveAvatarId()
		{
			LogicLong result = this.logicLong_0;
			this.logicLong_0 = null;
			return result;
		}

		// Token: 0x06000213 RID: 531 RVA: 0x000034EE File Offset: 0x000016EE
		public void SetAvatarId(LogicLong id)
		{
			this.logicLong_0 = id;
		}

		// Token: 0x040000BD RID: 189
		public const int MESSAGE_TYPE = 14408;

		// Token: 0x040000BE RID: 190
		private LogicLong logicLong_0;
	}
}
