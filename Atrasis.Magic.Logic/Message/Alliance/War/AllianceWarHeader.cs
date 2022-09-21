using System;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Message.Alliance.War
{
	// Token: 0x020000CD RID: 205
	public class AllianceWarHeader
	{
		// Token: 0x060008F3 RID: 2291 RVA: 0x000071A3 File Offset: 0x000053A3
		public void Decode(ByteStream stream)
		{
			this.logicLong_0 = stream.ReadLong();
			this.string_0 = stream.ReadString(900000);
			this.int_0 = stream.ReadInt();
			this.int_1 = stream.ReadInt();
		}

		// Token: 0x060008F4 RID: 2292 RVA: 0x000071DA File Offset: 0x000053DA
		public void Encode(ByteStream encoder)
		{
			encoder.WriteLong(this.logicLong_0);
			encoder.WriteString(this.string_0);
			encoder.WriteInt(this.int_0);
			encoder.WriteInt(this.int_1);
		}

		// Token: 0x060008F5 RID: 2293 RVA: 0x0000720C File Offset: 0x0000540C
		public LogicLong GetAllianceId()
		{
			return this.logicLong_0;
		}

		// Token: 0x060008F6 RID: 2294 RVA: 0x00007214 File Offset: 0x00005414
		public void SetAllianceId(LogicLong value)
		{
			this.logicLong_0 = value;
		}

		// Token: 0x060008F7 RID: 2295 RVA: 0x0000721D File Offset: 0x0000541D
		public string GetAllianceName()
		{
			return this.string_0;
		}

		// Token: 0x060008F8 RID: 2296 RVA: 0x00007225 File Offset: 0x00005425
		public void SetAllianceName(string value)
		{
			this.string_0 = value;
		}

		// Token: 0x060008F9 RID: 2297 RVA: 0x0000722E File Offset: 0x0000542E
		public int GetAllianceBadgeId()
		{
			return this.int_0;
		}

		// Token: 0x060008FA RID: 2298 RVA: 0x00007236 File Offset: 0x00005436
		public void SetAllianceBadgeId(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x060008FB RID: 2299 RVA: 0x0000723F File Offset: 0x0000543F
		public int GetAllianceLevel()
		{
			return this.int_1;
		}

		// Token: 0x060008FC RID: 2300 RVA: 0x00007247 File Offset: 0x00005447
		public void SetAllianceLevel(int value)
		{
			this.int_1 = value;
		}

		// Token: 0x0400036C RID: 876
		private LogicLong logicLong_0;

		// Token: 0x0400036D RID: 877
		private string string_0;

		// Token: 0x0400036E RID: 878
		private int int_0;

		// Token: 0x0400036F RID: 879
		private int int_1;
	}
}
