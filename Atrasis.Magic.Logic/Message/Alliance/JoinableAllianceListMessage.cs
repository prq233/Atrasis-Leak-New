using System;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Message.Alliance
{
	// Token: 0x020000C1 RID: 193
	public class JoinableAllianceListMessage : PiranhaMessage
	{
		// Token: 0x06000863 RID: 2147 RVA: 0x00006CBA File Offset: 0x00004EBA
		public JoinableAllianceListMessage() : this(0)
		{
		}

		// Token: 0x06000864 RID: 2148 RVA: 0x0000328C File Offset: 0x0000148C
		public JoinableAllianceListMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000865 RID: 2149 RVA: 0x00020D94 File Offset: 0x0001EF94
		public override void Decode()
		{
			base.Decode();
			int num = this.m_stream.ReadInt();
			if (num <= 10000 && num > -1)
			{
				this.logicArrayList_1 = new LogicArrayList<AllianceHeaderEntry>(num);
				for (int i = 0; i < num; i++)
				{
					AllianceHeaderEntry allianceHeaderEntry = new AllianceHeaderEntry();
					allianceHeaderEntry.Decode(this.m_stream);
					this.logicArrayList_1.Add(allianceHeaderEntry);
				}
			}
			int num2 = this.m_stream.ReadInt();
			if (num2 <= 10000 && num2 > -1)
			{
				this.logicArrayList_0 = new LogicArrayList<LogicLong>(num2);
				for (int j = 0; j < num2; j++)
				{
					this.logicArrayList_0.Add(this.m_stream.ReadLong());
				}
			}
		}

		// Token: 0x06000866 RID: 2150 RVA: 0x00020E40 File Offset: 0x0001F040
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
			if (this.logicArrayList_0 != null)
			{
				this.m_stream.WriteInt(this.logicArrayList_0.Size());
				for (int j = 0; j < this.logicArrayList_0.Size(); j++)
				{
					this.m_stream.WriteLong(this.logicArrayList_0[j]);
				}
				return;
			}
			this.m_stream.WriteInt(-1);
		}

		// Token: 0x06000867 RID: 2151 RVA: 0x00006CC3 File Offset: 0x00004EC3
		public override short GetMessageType()
		{
			return 24304;
		}

		// Token: 0x06000868 RID: 2152 RVA: 0x000046E0 File Offset: 0x000028E0
		public override int GetServiceNodeType()
		{
			return 11;
		}

		// Token: 0x06000869 RID: 2153 RVA: 0x00006CCA File Offset: 0x00004ECA
		public override void Destruct()
		{
			base.Destruct();
			this.logicArrayList_1 = null;
			this.logicArrayList_0 = null;
		}

		// Token: 0x0600086A RID: 2154 RVA: 0x00006CE0 File Offset: 0x00004EE0
		public LogicArrayList<AllianceHeaderEntry> RemoveAlliances()
		{
			LogicArrayList<AllianceHeaderEntry> result = this.logicArrayList_1;
			this.logicArrayList_1 = null;
			return result;
		}

		// Token: 0x0600086B RID: 2155 RVA: 0x00006CEF File Offset: 0x00004EEF
		public void SetAlliances(LogicArrayList<AllianceHeaderEntry> alliances)
		{
			this.logicArrayList_1 = alliances;
		}

		// Token: 0x0600086C RID: 2156 RVA: 0x00006CF8 File Offset: 0x00004EF8
		public void SetBookmarkList(LogicArrayList<LogicLong> list)
		{
			this.logicArrayList_0 = list;
		}

		// Token: 0x0400033B RID: 827
		public const int MESSAGE_TYPE = 24304;

		// Token: 0x0400033C RID: 828
		private LogicArrayList<LogicLong> logicArrayList_0;

		// Token: 0x0400033D RID: 829
		private LogicArrayList<AllianceHeaderEntry> logicArrayList_1;
	}
}
