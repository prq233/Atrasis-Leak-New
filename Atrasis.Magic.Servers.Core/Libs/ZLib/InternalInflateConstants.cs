﻿using System;

namespace Atrasis.Magic.Servers.Core.Libs.ZLib
{
	// Token: 0x020000D5 RID: 213
	internal static class InternalInflateConstants
	{
		// Token: 0x040002D4 RID: 724
		internal static readonly int[] InflateMask = new int[]
		{
			0,
			1,
			3,
			7,
			15,
			31,
			63,
			127,
			255,
			511,
			1023,
			2047,
			4095,
			8191,
			16383,
			32767,
			65535
		};
	}
}
