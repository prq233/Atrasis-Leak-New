using System;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Home
{
	// Token: 0x02000060 RID: 96
	public class VisitHomeMessage : PiranhaMessage
	{
		// Token: 0x06000457 RID: 1111 RVA: 0x000048D3 File Offset: 0x00002AD3
		public VisitHomeMessage() : this(0)
		{
		}

		// Token: 0x06000458 RID: 1112 RVA: 0x0000328C File Offset: 0x0000148C
		public VisitHomeMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000459 RID: 1113 RVA: 0x000048DC File Offset: 0x00002ADC
		public override void Decode()
		{
			base.Decode();
			this.logicLong_0 = this.m_stream.ReadLong();
			this.int_0 = this.m_stream.ReadInt();
		}

		// Token: 0x0600045A RID: 1114 RVA: 0x00004906 File Offset: 0x00002B06
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteLong(this.logicLong_0);
			this.m_stream.WriteInt(this.int_0);
		}

		// Token: 0x0600045B RID: 1115 RVA: 0x00004930 File Offset: 0x00002B30
		public override short GetMessageType()
		{
			return 14113;
		}

		// Token: 0x0600045C RID: 1116 RVA: 0x00003D3D File Offset: 0x00001F3D
		public override int GetServiceNodeType()
		{
			return 10;
		}

		// Token: 0x0600045D RID: 1117 RVA: 0x00004937 File Offset: 0x00002B37
		public override void Destruct()
		{
			base.Destruct();
			this.logicLong_0 = null;
		}

		// Token: 0x0600045E RID: 1118 RVA: 0x00004946 File Offset: 0x00002B46
		public int GetVisitType()
		{
			return this.int_0;
		}

		// Token: 0x0600045F RID: 1119 RVA: 0x0000494E File Offset: 0x00002B4E
		public void SetVillageType(int villageType)
		{
			this.int_0 = villageType;
		}

		// Token: 0x06000460 RID: 1120 RVA: 0x00004957 File Offset: 0x00002B57
		public LogicLong RemoveHomeId()
		{
			LogicLong result = this.logicLong_0;
			this.logicLong_0 = null;
			return result;
		}

		// Token: 0x06000461 RID: 1121 RVA: 0x00004966 File Offset: 0x00002B66
		public void SetHomeId(LogicLong id)
		{
			this.logicLong_0 = id;
		}

		// Token: 0x040001A7 RID: 423
		public const int MESSAGE_TYPE = 14113;

		// Token: 0x040001A8 RID: 424
		private LogicLong logicLong_0;

		// Token: 0x040001A9 RID: 425
		private int int_0;
	}
}
