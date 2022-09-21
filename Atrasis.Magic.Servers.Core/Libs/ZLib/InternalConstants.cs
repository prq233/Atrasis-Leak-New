using System;

namespace Atrasis.Magic.Servers.Core.Libs.ZLib
{
	// Token: 0x020000E4 RID: 228
	internal static class InternalConstants
	{
		// Token: 0x04000381 RID: 897
		internal static readonly int MAX_BITS = 15;

		// Token: 0x04000382 RID: 898
		internal static readonly int BL_CODES = 19;

		// Token: 0x04000383 RID: 899
		internal static readonly int D_CODES = 30;

		// Token: 0x04000384 RID: 900
		internal static readonly int LITERALS = 256;

		// Token: 0x04000385 RID: 901
		internal static readonly int LENGTH_CODES = 29;

		// Token: 0x04000386 RID: 902
		internal static readonly int L_CODES = InternalConstants.LITERALS + 1 + InternalConstants.LENGTH_CODES;

		// Token: 0x04000387 RID: 903
		internal static readonly int MAX_BL_BITS = 7;

		// Token: 0x04000388 RID: 904
		internal static readonly int REP_3_6 = 16;

		// Token: 0x04000389 RID: 905
		internal static readonly int REPZ_3_10 = 17;

		// Token: 0x0400038A RID: 906
		internal static readonly int REPZ_11_138 = 18;
	}
}
