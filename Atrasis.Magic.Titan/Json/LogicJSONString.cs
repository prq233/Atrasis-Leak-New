using System;
using System.Text;

namespace Atrasis.Magic.Titan.Json
{
	// Token: 0x02000021 RID: 33
	public class LogicJSONString : LogicJSONNode
	{
		// Token: 0x06000108 RID: 264 RVA: 0x00004D3B File Offset: 0x00002F3B
		public LogicJSONString(string value)
		{
			this.string_0 = value;
		}

		// Token: 0x06000109 RID: 265 RVA: 0x00004D4A File Offset: 0x00002F4A
		public string GetStringValue()
		{
			return this.string_0;
		}

		// Token: 0x0600010A RID: 266 RVA: 0x00004D52 File Offset: 0x00002F52
		public void SetStringValue(string value)
		{
			this.string_0 = value;
		}

		// Token: 0x0600010B RID: 267 RVA: 0x00004D5B File Offset: 0x00002F5B
		public override LogicJSONNodeType GetJSONNodeType()
		{
			return LogicJSONNodeType.STRING;
		}

		// Token: 0x0600010C RID: 268 RVA: 0x00004D5E File Offset: 0x00002F5E
		public override void WriteToString(StringBuilder builder)
		{
			LogicJSONParser.WriteString(this.string_0, builder);
		}

		// Token: 0x0400003B RID: 59
		private string string_0;
	}
}
