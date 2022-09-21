using System;
using System.Text;

namespace Atrasis.Magic.Titan.Json
{
	// Token: 0x0200001A RID: 26
	public abstract class LogicJSONNode
	{
		// Token: 0x060000DB RID: 219
		public abstract LogicJSONNodeType GetJSONNodeType();

		// Token: 0x060000DC RID: 220
		public abstract void WriteToString(StringBuilder builder);
	}
}
