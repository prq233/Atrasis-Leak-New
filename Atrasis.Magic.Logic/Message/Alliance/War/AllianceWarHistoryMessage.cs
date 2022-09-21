using System;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Message;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Message.Alliance.War
{
	// Token: 0x020000CF RID: 207
	public class AllianceWarHistoryMessage : PiranhaMessage
	{
		// Token: 0x06000901 RID: 2305 RVA: 0x00007250 File Offset: 0x00005450
		public AllianceWarHistoryMessage() : this(0)
		{
		}

		// Token: 0x06000902 RID: 2306 RVA: 0x0000328C File Offset: 0x0000148C
		public AllianceWarHistoryMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000903 RID: 2307 RVA: 0x000216D4 File Offset: 0x0001F8D4
		public override void Decode()
		{
			base.Decode();
			int num = this.m_stream.ReadInt();
			if (num >= 0)
			{
				Debugger.DoAssert(num < 1000, "Too many entries for alliance war history message");
				this.logicArrayList_0 = new LogicArrayList<AllianceWarHistoryEntry>(num);
				for (int i = 0; i < num; i++)
				{
					AllianceWarHistoryEntry allianceWarHistoryEntry = new AllianceWarHistoryEntry();
					allianceWarHistoryEntry.Decode(this.m_stream);
					this.logicArrayList_0.Add(allianceWarHistoryEntry);
				}
			}
		}

		// Token: 0x06000904 RID: 2308 RVA: 0x00021740 File Offset: 0x0001F940
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
				return;
			}
			this.m_stream.WriteInt(-1);
		}

		// Token: 0x06000905 RID: 2309 RVA: 0x0000700D File Offset: 0x0000520D
		public override short GetMessageType()
		{
			return 24337;
		}

		// Token: 0x06000906 RID: 2310 RVA: 0x000046E0 File Offset: 0x000028E0
		public override int GetServiceNodeType()
		{
			return 11;
		}

		// Token: 0x06000907 RID: 2311 RVA: 0x0000341E File Offset: 0x0000161E
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06000908 RID: 2312 RVA: 0x00007259 File Offset: 0x00005459
		public LogicArrayList<AllianceWarHistoryEntry> GetAllianceWarHistoryList()
		{
			return this.logicArrayList_0;
		}

		// Token: 0x06000909 RID: 2313 RVA: 0x00007261 File Offset: 0x00005461
		public void SetAllianceWarHistoryList(LogicArrayList<AllianceWarHistoryEntry> list)
		{
			this.logicArrayList_0 = list;
		}

		// Token: 0x0400037C RID: 892
		public const int MESSAGE_TYPE = 24338;

		// Token: 0x0400037D RID: 893
		private LogicArrayList<AllianceWarHistoryEntry> logicArrayList_0;
	}
}
