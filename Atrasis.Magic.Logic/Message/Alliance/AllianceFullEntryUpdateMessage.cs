using System;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Alliance
{
	// Token: 0x020000AA RID: 170
	public class AllianceFullEntryUpdateMessage : PiranhaMessage
	{
		// Token: 0x06000757 RID: 1879 RVA: 0x000063F1 File Offset: 0x000045F1
		public AllianceFullEntryUpdateMessage() : this(0)
		{
		}

		// Token: 0x06000758 RID: 1880 RVA: 0x0000328C File Offset: 0x0000148C
		public AllianceFullEntryUpdateMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000759 RID: 1881 RVA: 0x0001FC64 File Offset: 0x0001DE64
		public override void Decode()
		{
			base.Decode();
			this.string_0 = this.m_stream.ReadString(1000);
			this.m_stream.ReadInt();
			this.m_stream.ReadInt();
			if (this.m_stream.ReadBoolean())
			{
				this.logicLong_0 = this.m_stream.ReadLong();
			}
			this.m_stream.ReadInt();
			if (this.m_stream.ReadBoolean())
			{
				this.m_stream.ReadLong();
			}
			this.allianceHeaderEntry_0 = new AllianceHeaderEntry();
			this.allianceHeaderEntry_0.Decode(this.m_stream);
		}

		// Token: 0x0600075A RID: 1882 RVA: 0x0001FD04 File Offset: 0x0001DF04
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteString(this.string_0);
			this.m_stream.WriteInt(this.int_0);
			this.m_stream.WriteInt(50);
			if (this.logicLong_0 != null)
			{
				this.m_stream.WriteBoolean(true);
				this.m_stream.WriteLong(this.logicLong_0);
			}
			else
			{
				this.m_stream.WriteBoolean(false);
			}
			this.m_stream.WriteInt(0);
			this.m_stream.WriteBoolean(false);
			this.allianceHeaderEntry_0.Encode(this.m_stream);
		}

		// Token: 0x0600075B RID: 1883 RVA: 0x000063FA File Offset: 0x000045FA
		public override short GetMessageType()
		{
			return 24324;
		}

		// Token: 0x0600075C RID: 1884 RVA: 0x000046E0 File Offset: 0x000028E0
		public override int GetServiceNodeType()
		{
			return 11;
		}

		// Token: 0x0600075D RID: 1885 RVA: 0x00006401 File Offset: 0x00004601
		public override void Destruct()
		{
			base.Destruct();
			this.allianceHeaderEntry_0 = null;
		}

		// Token: 0x0600075E RID: 1886 RVA: 0x00006410 File Offset: 0x00004610
		public AllianceHeaderEntry RemoveAllianceHeaderEntry()
		{
			AllianceHeaderEntry result = this.allianceHeaderEntry_0;
			this.allianceHeaderEntry_0 = null;
			return result;
		}

		// Token: 0x0600075F RID: 1887 RVA: 0x0000641F File Offset: 0x0000461F
		public void SetAllianceHeaderEntry(AllianceHeaderEntry entry)
		{
			this.allianceHeaderEntry_0 = entry;
		}

		// Token: 0x06000760 RID: 1888 RVA: 0x00006428 File Offset: 0x00004628
		public string GetDescription()
		{
			return this.string_0;
		}

		// Token: 0x06000761 RID: 1889 RVA: 0x00006430 File Offset: 0x00004630
		public void SetDescription(string value)
		{
			this.string_0 = value;
		}

		// Token: 0x06000762 RID: 1890 RVA: 0x00006439 File Offset: 0x00004639
		public LogicLong GetCurrentWarId()
		{
			return this.logicLong_0;
		}

		// Token: 0x06000763 RID: 1891 RVA: 0x00006441 File Offset: 0x00004641
		public void SetCurrentWarId(LogicLong value)
		{
			this.logicLong_0 = value;
		}

		// Token: 0x06000764 RID: 1892 RVA: 0x0000644A File Offset: 0x0000464A
		public int GetWarState()
		{
			return this.int_0;
		}

		// Token: 0x06000765 RID: 1893 RVA: 0x00006452 File Offset: 0x00004652
		public void SetWarState(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x040002C3 RID: 707
		public const int MESSAGE_TYPE = 24324;

		// Token: 0x040002C4 RID: 708
		private int int_0;

		// Token: 0x040002C5 RID: 709
		private string string_0;

		// Token: 0x040002C6 RID: 710
		private LogicLong logicLong_0;

		// Token: 0x040002C7 RID: 711
		private AllianceHeaderEntry allianceHeaderEntry_0;
	}
}
