using System;
using Atrasis.Magic.Titan.Message;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Message.Scoring
{
	// Token: 0x0200002D RID: 45
	public class AllianceRankingListMessage : PiranhaMessage
	{
		// Token: 0x060001EF RID: 495 RVA: 0x00003396 File Offset: 0x00001596
		public AllianceRankingListMessage() : this(0)
		{
		}

		// Token: 0x060001F0 RID: 496 RVA: 0x0000328C File Offset: 0x0000148C
		public AllianceRankingListMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x060001F1 RID: 497 RVA: 0x0001A968 File Offset: 0x00018B68
		public override void Decode()
		{
			base.Decode();
			int num = this.m_stream.ReadInt();
			if (num > -1)
			{
				this.logicArrayList_1 = new LogicArrayList<AllianceRankingEntry>(num);
				for (int i = 0; i < num; i++)
				{
					AllianceRankingEntry allianceRankingEntry = new AllianceRankingEntry();
					allianceRankingEntry.Decode(this.m_stream);
					this.logicArrayList_1.Add(allianceRankingEntry);
				}
			}
			this.int_1 = this.m_stream.ReadInt();
			this.logicArrayList_0 = new LogicArrayList<int>();
			int j = 0;
			int num2 = this.m_stream.ReadInt();
			while (j < num2)
			{
				this.logicArrayList_0.Add(this.m_stream.ReadInt());
				j++;
			}
			this.int_0 = this.m_stream.ReadInt();
		}

		// Token: 0x060001F2 RID: 498 RVA: 0x0001AA20 File Offset: 0x00018C20
		public override void Encode()
		{
			base.Encode();
			if (this.logicArrayList_1 != null)
			{
				this.m_stream.WriteInt(this.logicArrayList_1.Size());
				for (int i = 0; i < this.logicArrayList_1.Size(); i++)
				{
					this.logicArrayList_1[i].Encode(this.m_stream);
				}
			}
			else
			{
				this.m_stream.WriteInt(-1);
			}
			this.m_stream.WriteInt(this.int_1);
			this.m_stream.WriteInt(this.logicArrayList_0.Size());
			for (int j = 0; j < this.logicArrayList_0.Size(); j++)
			{
				this.m_stream.WriteInt(this.logicArrayList_0[j]);
			}
			this.m_stream.WriteInt(this.int_0);
		}

		// Token: 0x060001F3 RID: 499 RVA: 0x0000339F File Offset: 0x0000159F
		public override short GetMessageType()
		{
			return 24401;
		}

		// Token: 0x060001F4 RID: 500 RVA: 0x0000329C File Offset: 0x0000149C
		public override int GetServiceNodeType()
		{
			return 28;
		}

		// Token: 0x060001F5 RID: 501 RVA: 0x000033A6 File Offset: 0x000015A6
		public override void Destruct()
		{
			base.Destruct();
			this.logicArrayList_1 = null;
			this.logicArrayList_0 = null;
		}

		// Token: 0x060001F6 RID: 502 RVA: 0x000033BC File Offset: 0x000015BC
		public int GetVillageType()
		{
			return this.int_0;
		}

		// Token: 0x060001F7 RID: 503 RVA: 0x000033C4 File Offset: 0x000015C4
		public void SetVillageType(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x060001F8 RID: 504 RVA: 0x000033CD File Offset: 0x000015CD
		public LogicArrayList<AllianceRankingEntry> RemoveAllianceRankingList()
		{
			LogicArrayList<AllianceRankingEntry> result = this.logicArrayList_1;
			this.logicArrayList_1 = null;
			return result;
		}

		// Token: 0x060001F9 RID: 505 RVA: 0x000033DC File Offset: 0x000015DC
		public void SetAllianceRankingList(LogicArrayList<AllianceRankingEntry> list)
		{
			this.logicArrayList_1 = list;
		}

		// Token: 0x060001FA RID: 506 RVA: 0x000033E5 File Offset: 0x000015E5
		public LogicArrayList<int> RemoveDiamondPrizes()
		{
			LogicArrayList<int> result = this.logicArrayList_0;
			this.logicArrayList_0 = null;
			return result;
		}

		// Token: 0x060001FB RID: 507 RVA: 0x000033F4 File Offset: 0x000015F4
		public void SetDiamondPrizes(LogicArrayList<int> list)
		{
			this.logicArrayList_0 = list;
		}

		// Token: 0x060001FC RID: 508 RVA: 0x000033FD File Offset: 0x000015FD
		public int GetNextEndTimeSeconds()
		{
			return this.int_1;
		}

		// Token: 0x060001FD RID: 509 RVA: 0x00003405 File Offset: 0x00001605
		public void SetNextEndTimeSeconds(int value)
		{
			this.int_1 = value;
		}

		// Token: 0x040000B4 RID: 180
		public const int MESSAGE_TYPE = 24401;

		// Token: 0x040000B5 RID: 181
		private int int_0;

		// Token: 0x040000B6 RID: 182
		private int int_1;

		// Token: 0x040000B7 RID: 183
		private LogicArrayList<int> logicArrayList_0;

		// Token: 0x040000B8 RID: 184
		private LogicArrayList<AllianceRankingEntry> logicArrayList_1;
	}
}
