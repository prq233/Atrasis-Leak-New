using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Home;
using Atrasis.Magic.Servers.Core.Helper;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Util;

namespace ns0
{
	// Token: 0x02000004 RID: 4
	public static class GClass1
	{
		// Token: 0x06000004 RID: 4 RVA: 0x0000273C File Offset: 0x0000093C
		public static void smethod_0(LogicClientAvatar logicClientAvatar_0, LogicClientHome logicClientHome_0)
		{
			CompressibleStringHelper.Uncompress(logicClientHome_0.GetCompressibleHomeJSON());
			LogicJSONObject logicJSONObject = LogicJSONParser.ParseObject(logicClientHome_0.GetCompressibleHomeJSON().Get());
			logicClientAvatar_0.SaveToDirect(logicJSONObject);
			logicClientHome_0.SetHomeJSON(LogicJSONParser.CreateJSONString(logicJSONObject, 512));
			CompressibleStringHelper.Compress(logicClientHome_0.GetCompressibleHomeJSON());
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002788 File Offset: 0x00000988
		public static LogicClientHome smethod_1(LogicClientHome logicClientHome_0)
		{
			LogicClientHome logicClientHome = new LogicClientHome();
			ByteStream byteStream = new ByteStream(512);
			logicClientHome_0.Encode(byteStream);
			logicClientHome.Decode(byteStream);
			return logicClientHome;
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000027B4 File Offset: 0x000009B4
		public static LogicClientAvatar smethod_2(LogicClientHome logicClientHome_0)
		{
			string text = logicClientHome_0.GetCompressibleHomeJSON().Get();
			if (text == null)
			{
				byte[] array;
				ZLibHelper.DecompressInMySQLFormat(logicClientHome_0.GetCompressibleHomeJSON().GetCompressed(), out array);
				text = LogicStringUtil.CreateString(array, 0, array.Length);
			}
			LogicClientAvatar logicClientAvatar = new LogicClientAvatar();
			logicClientAvatar.LoadForReplay(LogicJSONParser.ParseObject(text), false);
			return logicClientAvatar;
		}
	}
}
