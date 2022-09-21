using System;
using System.Text;

namespace Atrasis.Magic.Titan.Json
{
	// Token: 0x0200001D RID: 29
	public class LogicJSONNumber : LogicJSONNode
	{
		// Token: 0x060000E1 RID: 225 RVA: 0x00004BC9 File Offset: 0x00002DC9
		public LogicJSONNumber()
		{
			this.int_0 = 0;
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x00004BD8 File Offset: 0x00002DD8
		public LogicJSONNumber(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x00004BE7 File Offset: 0x00002DE7
		public int GetIntValue()
		{
			return this.int_0;
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x00004BEF File Offset: 0x00002DEF
		public void SetIntValue(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x00004BF8 File Offset: 0x00002DF8
		public override LogicJSONNodeType GetJSONNodeType()
		{
			return LogicJSONNodeType.NUMBER;
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x00004BFB File Offset: 0x00002DFB
		public override void WriteToString(StringBuilder builder)
		{
			builder.Append(this.int_0);
		}

		// Token: 0x04000036 RID: 54
		private int int_0;
	}
}
