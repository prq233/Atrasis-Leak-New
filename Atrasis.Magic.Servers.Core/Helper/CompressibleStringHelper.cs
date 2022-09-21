using System;
using System.Text;
using Atrasis.Magic.Logic.Util;

namespace Atrasis.Magic.Servers.Core.Helper
{
	// Token: 0x020000ED RID: 237
	public static class CompressibleStringHelper
	{
		// Token: 0x060006F0 RID: 1776 RVA: 0x00015E90 File Offset: 0x00014090
		public static void Uncompress(LogicCompressibleString str)
		{
			if (str.IsCompressed())
			{
				byte[] array;
				ZLibHelper.DecompressInMySQLFormat(str.RemoveCompressed(), out array);
				if (array != null)
				{
					str.Set(Encoding.UTF8.GetString(array), str.GetCompressed());
				}
			}
		}

		// Token: 0x060006F1 RID: 1777 RVA: 0x00015ED0 File Offset: 0x000140D0
		public static void Compress(LogicCompressibleString str)
		{
			if (!str.IsCompressed())
			{
				byte[] array;
				ZLibHelper.CompressInZLibFormat(Encoding.UTF8.GetBytes(str.Get()), out array);
				if (array != null)
				{
					str.Set(array);
				}
			}
		}
	}
}
