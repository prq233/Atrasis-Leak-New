using System;

namespace Atrasis.Magic.Servers.Core.Util
{
	// Token: 0x0200000D RID: 13
	public static class ServerUtil
	{
		// Token: 0x06000038 RID: 56 RVA: 0x00009DA0 File Offset: 0x00007FA0
		public static string GetServerName(int type)
		{
			switch (type)
			{
			case 0:
				return "Admin";
			case 1:
				return "Proxy";
			case 2:
			case 4:
			case 5:
			case 7:
			case 8:
			case 12:
				break;
			case 3:
				return "Friend";
			case 6:
				return "Chat";
			case 9:
				return "Game";
			case 10:
				return "Home";
			case 11:
				return "Stream";
			case 13:
				return "League";
			default:
				switch (type)
				{
				case 25:
					return "War";
				case 27:
					return "Battle";
				case 28:
					return "Scoring";
				case 29:
					return "Search";
				}
				break;
			}
			return "(unk)";
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00004806 File Offset: 0x00002A06
		public static bool IsContainerServer(int type)
		{
			return type == 6 || type == 10 || type == 12 || type == 27 || type == 28 || type == 29;
		}
	}
}
