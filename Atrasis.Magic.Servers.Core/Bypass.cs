using System;
using Atrasis.Magic.Servers.Core.Settings;

namespace Atrasis.Magic.Servers.Core
{
	// Token: 0x0200010B RID: 267
	internal static class Bypass
	{
		// Token: 0x060007C7 RID: 1991 RVA: 0x000188F4 File Offset: 0x00016AF4
		public static void key()
		{
			int num = 9000000;
			int num2 = EnvironmentSettings.Servers[1].Length;
			if (num2 > 0)
			{
				num = num / num2 + ((num % num2 > 0) ? 1 : 0);
			}
			EnvironmentSettings.Settings.Proxy.SessionCapacity = num;
		}
	}
}
