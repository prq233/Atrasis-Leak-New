using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Servers.Core;
using Atrasis.Magic.Servers.Core.Helper;

namespace ns0
{
	// Token: 0x02000018 RID: 24
	public static class GClass11
	{
		// Token: 0x060000A0 RID: 160 RVA: 0x00002690 File Offset: 0x00000890
		[CompilerGenerated]
		public static byte[] smethod_0()
		{
			return GClass11.byte_0;
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00002697 File Offset: 0x00000897
		[CompilerGenerated]
		private static void smethod_1(byte[] byte_2)
		{
			GClass11.byte_0 = byte_2;
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x0000269F File Offset: 0x0000089F
		[CompilerGenerated]
		public static byte[][] smethod_2()
		{
			return GClass11.byte_1;
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x000026A6 File Offset: 0x000008A6
		[CompilerGenerated]
		private static void smethod_3(byte[][] byte_2)
		{
			GClass11.byte_1 = byte_2;
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x00006824 File Offset: 0x00004A24
		public static void smethod_4()
		{
			GClass11.smethod_1(GClass11.smethod_5(ServerHttpClient.DownloadBytes("data/level/starting_home.json")));
			GClass11.smethod_3(new byte[LogicDataTables.GetTable(LogicDataType.NPC).GetItemCount()][]);
			LogicDataTable table = LogicDataTables.GetTable(LogicDataType.NPC);
			for (int i = 0; i < table.GetItemCount(); i++)
			{
				LogicNpcData logicNpcData = (LogicNpcData)table.GetItemAt(i);
				GClass11.smethod_2()[i] = GClass11.smethod_5(ServerHttpClient.DownloadBytes("data/" + logicNpcData.GetLevelFile()));
			}
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x000068A4 File Offset: 0x00004AA4
		internal static byte[] smethod_5(byte[] byte_2)
		{
			byte[] result;
			ZLibHelper.CompressInZLibFormat(byte_2, out result);
			return result;
		}

		// Token: 0x04000034 RID: 52
		[CompilerGenerated]
		private static byte[] byte_0;

		// Token: 0x04000035 RID: 53
		[CompilerGenerated]
		private static byte[][] byte_1;
	}
}
