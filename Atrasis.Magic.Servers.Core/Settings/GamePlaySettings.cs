using System;
using Atrasis.Magic.Titan.Json;

namespace Atrasis.Magic.Servers.Core.Settings
{
	// Token: 0x0200001B RID: 27
	public static class GamePlaySettings
	{
		// Token: 0x06000082 RID: 130 RVA: 0x00004AAF File Offset: 0x00002CAF
		internal static void smethod_0()
		{
			GamePlaySettings.smethod_1(ServerHttpClient.DownloadJSON("gameplay.json"));
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00004631 File Offset: 0x00002831
		private static void smethod_1(LogicJSONObject logicJSONObject_0)
		{
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00004AC0 File Offset: 0x00002CC0
		public static LogicJSONObject Save()
		{
			return new LogicJSONObject();
		}
	}
}
