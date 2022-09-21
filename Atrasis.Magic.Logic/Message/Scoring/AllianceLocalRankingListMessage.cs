using System;
using Atrasis.Magic.Titan.Message;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Message.Scoring
{
	// Token: 0x0200002B RID: 43
	public class AllianceLocalRankingListMessage : PiranhaMessage
	{
		// Token: 0x060001D7 RID: 471 RVA: 0x00003283 File Offset: 0x00001483
		public AllianceLocalRankingListMessage() : this(0)
		{
		}

		// Token: 0x060001D8 RID: 472 RVA: 0x0000328C File Offset: 0x0000148C
		public AllianceLocalRankingListMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x060001D9 RID: 473 RVA: 0x0001A788 File Offset: 0x00018988
		public override void Decode()
		{
			base.Decode();
			int num = this.m_stream.ReadInt();
			if (num > -1)
			{
				this.logicArrayList_0 = new LogicArrayList<AllianceRankingEntry>(num);
				for (int i = 0; i < num; i++)
				{
					AllianceRankingEntry allianceRankingEntry = new AllianceRankingEntry();
					allianceRankingEntry.Decode(this.m_stream);
					this.logicArrayList_0.Add(allianceRankingEntry);
				}
			}
			this.int_0 = this.m_stream.ReadInt();
		}

		// Token: 0x060001DA RID: 474 RVA: 0x0001A7F4 File Offset: 0x000189F4
		public override void Encode()
		{
			base.Encode();
			if (this.logicArrayList_0 != null)
			{
				this.m_stream.WriteInt(this.logicArrayList_0.Size());
				for (int i = 0; i < this.logicArrayList_0.Size(); i++)
				{
					this.logicArrayList_0[i].Encode(this.m_stream);
				}
			}
			else
			{
				this.m_stream.WriteInt(-1);
			}
			this.m_stream.WriteInt(this.int_0);
		}

		// Token: 0x060001DB RID: 475 RVA: 0x00003295 File Offset: 0x00001495
		public override short GetMessageType()
		{
			return 24402;
		}

		// Token: 0x060001DC RID: 476 RVA: 0x0000329C File Offset: 0x0000149C
		public override int GetServiceNodeType()
		{
			return 28;
		}

		// Token: 0x060001DD RID: 477 RVA: 0x000032A0 File Offset: 0x000014A0
		public override void Destruct()
		{
			base.Destruct();
			this.logicArrayList_0 = null;
		}

		// Token: 0x060001DE RID: 478 RVA: 0x000032AF File Offset: 0x000014AF
		public LogicArrayList<AllianceRankingEntry> RemoveAllianceRankingList()
		{
			LogicArrayList<AllianceRankingEntry> result = this.logicArrayList_0;
			this.logicArrayList_0 = null;
			return result;
		}

		// Token: 0x060001DF RID: 479 RVA: 0x000032BE File Offset: 0x000014BE
		public void SetAllianceRankingList(LogicArrayList<AllianceRankingEntry> list)
		{
			this.logicArrayList_0 = list;
		}

		// Token: 0x060001E0 RID: 480 RVA: 0x000032C7 File Offset: 0x000014C7
		public int GetVillageType()
		{
			return this.int_0;
		}

		// Token: 0x060001E1 RID: 481 RVA: 0x000032CF File Offset: 0x000014CF
		public void SetVillageType(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x040000A9 RID: 169
		public const int MESSAGE_TYPE = 24402;

		// Token: 0x040000AA RID: 170
		private int int_0;

		// Token: 0x040000AB RID: 171
		private LogicArrayList<AllianceRankingEntry> logicArrayList_0;
	}
}
