using System;

namespace Atrasis.Magic.Servers.Core.Libs.ZLib
{
	// Token: 0x020000EB RID: 235
	public static class ZLibConstants
	{
		// Token: 0x040003C0 RID: 960
		public const int WindowBitsMax = 15;

		// Token: 0x040003C1 RID: 961
		public const int WindowBitsDefault = 15;

		// Token: 0x040003C2 RID: 962
		public const int Z_OK = 0;

		// Token: 0x040003C3 RID: 963
		public const int Z_STREAM_END = 1;

		// Token: 0x040003C4 RID: 964
		public const int Z_NEED_DICT = 2;

		// Token: 0x040003C5 RID: 965
		public const int Z_STREAM_ERROR = -2;

		// Token: 0x040003C6 RID: 966
		public const int Z_DATA_ERROR = -3;

		// Token: 0x040003C7 RID: 967
		public const int Z_BUF_ERROR = -5;

		// Token: 0x040003C8 RID: 968
		public const int WorkingBufferSizeDefault = 16384;

		// Token: 0x040003C9 RID: 969
		public const int WorkingBufferSizeMin = 1024;
	}
}
