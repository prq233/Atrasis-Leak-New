using System;
using System.Text;

namespace Atrasis.Magic.Titan.Json
{
	// Token: 0x02000019 RID: 25
	public class LogicJSONBoolean : LogicJSONNode
	{
		// Token: 0x060000D7 RID: 215 RVA: 0x00004B79 File Offset: 0x00002D79
		public LogicJSONBoolean(bool value)
		{
			this.bool_0 = value;
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x00004B88 File Offset: 0x00002D88
		public bool IsTrue()
		{
			return this.bool_0;
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x00004B90 File Offset: 0x00002D90
		public override LogicJSONNodeType GetJSONNodeType()
		{
			return LogicJSONNodeType.BOOLEAN;
		}

		// Token: 0x060000DA RID: 218 RVA: 0x00004B93 File Offset: 0x00002D93
		public override void WriteToString(StringBuilder builder)
		{
			builder.Append(this.bool_0 ? "true" : "false");
		}

		// Token: 0x0400002E RID: 46
		private readonly bool bool_0;
	}
}
