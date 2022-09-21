using System;
using System.Collections.Generic;

namespace Atrasis.Magic.Servers.Core.Util
{
	// Token: 0x02000010 RID: 16
	public static class WordCensorUtil
	{
		// Token: 0x06000041 RID: 65 RVA: 0x00004848 File Offset: 0x00002A48
		public static void Init()
		{
			WordCensorUtil.hashSet_0 = new HashSet<string>(ServerHttpClient.DownloadString("data/badwords.txt").Split(new string[]
			{
				"\r\n",
				"\n"
			}, StringSplitOptions.None));
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00009F94 File Offset: 0x00008194
		public static string FilterMessage(string message)
		{
			string[] array = message.Split(' ', StringSplitOptions.None);
			for (int i = 0; i < array.Length; i++)
			{
				string item = array[i].ToLower();
				if (WordCensorUtil.hashSet_0.Contains(item))
				{
					array[i] = "***";
				}
			}
			return string.Join(" ", array);
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00009FE4 File Offset: 0x000081E4
		public static bool IsValidMessage(string message)
		{
			string[] array = message.Split(' ', StringSplitOptions.None);
			for (int i = 0; i < array.Length; i++)
			{
				string item = array[i].ToLower();
				if (WordCensorUtil.hashSet_0.Contains(item))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0400001D RID: 29
		private static HashSet<string> hashSet_0;
	}
}
