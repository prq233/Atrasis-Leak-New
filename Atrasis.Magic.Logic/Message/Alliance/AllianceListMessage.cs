using System;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Message.Alliance
{
	// Token: 0x020000B5 RID: 181
	public class AllianceListMessage : PiranhaMessage
	{
		// Token: 0x060007B2 RID: 1970 RVA: 0x0000668D File Offset: 0x0000488D
		public AllianceListMessage() : this(0)
		{
		}

		// Token: 0x060007B3 RID: 1971 RVA: 0x0000328C File Offset: 0x0000148C
		public AllianceListMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x060007B4 RID: 1972 RVA: 0x00020344 File Offset: 0x0001E544
		public override void Decode()
		{
			base.Decode();
			this.string_0 = this.m_stream.ReadString(900000);
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

		// Token: 0x060007B5 RID: 1973 RVA: 0x00020408 File Offset: 0x0001E608
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteString(this.string_0);
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

		// Token: 0x060007B6 RID: 1974 RVA: 0x00006696 File Offset: 0x00004896
		public override short GetMessageType()
		{
			return 24310;
		}

		// Token: 0x060007B7 RID: 1975 RVA: 0x000046E0 File Offset: 0x000028E0
		public override int GetServiceNodeType()
		{
			return 11;
		}

		// Token: 0x060007B8 RID: 1976 RVA: 0x0000669D File Offset: 0x0000489D
		public override void Destruct()
		{
			base.Destruct();
			this.string_0 = null;
			this.logicArrayList_1 = null;
			this.logicArrayList_0 = null;
		}

		// Token: 0x060007B9 RID: 1977 RVA: 0x000066BA File Offset: 0x000048BA
		public string RemoveSearchString()
		{
			string result = this.string_0;
			this.string_0 = null;
			return result;
		}

		// Token: 0x060007BA RID: 1978 RVA: 0x000066C9 File Offset: 0x000048C9
		public void SetSearchString(string value)
		{
			this.string_0 = value;
		}

		// Token: 0x060007BB RID: 1979 RVA: 0x000066D2 File Offset: 0x000048D2
		public LogicArrayList<AllianceHeaderEntry> RemoveAlliances()
		{
			LogicArrayList<AllianceHeaderEntry> result = this.logicArrayList_1;
			this.logicArrayList_1 = null;
			return result;
		}

		// Token: 0x060007BC RID: 1980 RVA: 0x000066E1 File Offset: 0x000048E1
		public void SetAlliances(LogicArrayList<AllianceHeaderEntry> alliances)
		{
			this.logicArrayList_1 = alliances;
		}

		// Token: 0x060007BD RID: 1981 RVA: 0x000066EA File Offset: 0x000048EA
		public void SetBookmarkList(LogicArrayList<LogicLong> list)
		{
			this.logicArrayList_0 = list;
		}

		// Token: 0x040002FF RID: 767
		public const int MESSAGE_TYPE = 24310;

		// Token: 0x04000300 RID: 768
		private string string_0;

		// Token: 0x04000301 RID: 769
		private LogicArrayList<LogicLong> logicArrayList_0;

		// Token: 0x04000302 RID: 770
		private LogicArrayList<AllianceHeaderEntry> logicArrayList_1;
	}
}
