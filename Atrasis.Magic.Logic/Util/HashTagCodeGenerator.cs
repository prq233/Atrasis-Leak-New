using System;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Util
{
	// Token: 0x02000007 RID: 7
	public class HashTagCodeGenerator
	{
		// Token: 0x06000026 RID: 38 RVA: 0x000021E4 File Offset: 0x000003E4
		private HashTagCodeGenerator()
		{
			this.logicLongToCodeConverterUtil_0 = new LogicLongToCodeConverterUtil("#", "0289PYLQGRJCUV");
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00002201 File Offset: 0x00000401
		public string ToCode(LogicLong logicLong)
		{
			return this.logicLongToCodeConverterUtil_0.ToCode(logicLong);
		}

		// Token: 0x06000028 RID: 40 RVA: 0x000124C8 File Offset: 0x000106C8
		public LogicLong ToId(string value)
		{
			LogicLong logicLong = this.logicLongToCodeConverterUtil_0.ToId(value);
			if (this.IsIdValid(logicLong))
			{
				return logicLong;
			}
			return null;
		}

		// Token: 0x06000029 RID: 41 RVA: 0x0000220F File Offset: 0x0000040F
		public bool IsIdValid(LogicLong id)
		{
			return id.GetHigherInt() != -1 && id.GetHigherInt() != -1;
		}

		// Token: 0x04000022 RID: 34
		public static readonly HashTagCodeGenerator m_instance = new HashTagCodeGenerator();

		// Token: 0x04000023 RID: 35
		public const string CONVERSION_TAG = "#";

		// Token: 0x04000024 RID: 36
		public const string CONVERSION_CHARS = "0289PYLQGRJCUV";

		// Token: 0x04000025 RID: 37
		private readonly LogicLongToCodeConverterUtil logicLongToCodeConverterUtil_0;
	}
}
