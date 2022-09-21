using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.Math;

namespace ns0
{
	// Token: 0x02000010 RID: 16
	public class GClass6
	{
		// Token: 0x06000078 RID: 120 RVA: 0x0000249C File Offset: 0x0000069C
		[CompilerGenerated]
		public LogicLong method_0()
		{
			return this.logicLong_0;
		}

		// Token: 0x06000079 RID: 121 RVA: 0x000024A4 File Offset: 0x000006A4
		[CompilerGenerated]
		public LogicLong method_1()
		{
			return this.logicLong_1;
		}

		// Token: 0x0600007A RID: 122 RVA: 0x000024AC File Offset: 0x000006AC
		[CompilerGenerated]
		public DateTime method_2()
		{
			return this.dateTime_0;
		}

		// Token: 0x0600007B RID: 123 RVA: 0x000024B4 File Offset: 0x000006B4
		public GClass6(LogicLong logicLong_2, LogicLong logicLong_3)
		{
			this.logicLong_0 = logicLong_2;
			this.logicLong_1 = logicLong_3;
			this.dateTime_0 = DateTime.UtcNow;
		}

		// Token: 0x0600007C RID: 124 RVA: 0x000053EC File Offset: 0x000035EC
		public bool method_3()
		{
			return DateTime.UtcNow.Subtract(this.method_2()).TotalSeconds >= 600.0;
		}

		// Token: 0x0400001D RID: 29
		[CompilerGenerated]
		private readonly LogicLong logicLong_0;

		// Token: 0x0400001E RID: 30
		[CompilerGenerated]
		private readonly LogicLong logicLong_1;

		// Token: 0x0400001F RID: 31
		[CompilerGenerated]
		private readonly DateTime dateTime_0;
	}
}
