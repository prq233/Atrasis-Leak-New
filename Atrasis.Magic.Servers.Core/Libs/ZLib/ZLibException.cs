using System;
using System.Runtime.InteropServices;

namespace Atrasis.Magic.Servers.Core.Libs.ZLib
{
	// Token: 0x020000E2 RID: 226
	[Guid("ebc25cf6-9120-4283-b972-0e5520d0000E")]
	public class ZLibException : Exception
	{
		// Token: 0x06000699 RID: 1689 RVA: 0x00008805 File Offset: 0x00006A05
		public ZLibException()
		{
		}

		// Token: 0x0600069A RID: 1690 RVA: 0x0000461C File Offset: 0x0000281C
		public ZLibException(string s) : base(s)
		{
		}
	}
}
