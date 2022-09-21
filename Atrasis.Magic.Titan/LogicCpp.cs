using System;
using System.Runtime.InteropServices;

namespace Atrasis.Magic.Titan
{
	// Token: 0x02000002 RID: 2
	public static class LogicCpp
	{
		// Token: 0x06000001 RID: 1
		[DllImport("msvcrt.dll", CallingConvention = 2)]
		public unsafe static extern int* memset(int* dest, int c, int byteCount);
	}
}
