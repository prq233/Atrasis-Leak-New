using System;
using System.IO;
using System.Net;
using System.Net.Http;
using Atrasis.Magic.Servers.Core.Settings;
using Atrasis.Magic.Titan.Json;

namespace ns0
{
	// Token: 0x02000002 RID: 2
	internal static class Class0
	{
		// Token: 0x06000001 RID: 1 RVA: 0x0000950C File Offset: 0x0000770C
		public static void smethod_0()
		{
			using (HttpClient httpClient = new HttpClient())
			{
				HttpResponseMessage result = httpClient.PostAsync("https://atrasis.net/server/license.php?name=atrasis&version=1.1.0", new ByteArrayContent(Class0.smethod_1())).Result;
				if (result.StatusCode != HttpStatusCode.OK)
				{
					string result2 = result.Content.ReadAsStringAsync().Result;
					if (result2 == null)
					{
						throw new Exception0("Unable to check your license.");
					}
					LogicJSONObject logicJSONObject = LogicJSONParser.ParseObject(result2);
					LogicJSONNumber jsonnumber = logicJSONObject.GetJSONNumber("errorCode");
					LogicJSONString jsonstring = logicJSONObject.GetJSONString("reason");
					switch (jsonnumber.GetIntValue())
					{
					case 1:
						throw new Exception0("The license is not valid.");
					case 2:
						throw new Exception0("Your license does not allow you to run this version of the program.");
					case 3:
						throw new Exception0("Your license has expired.");
					case 4:
						throw new Exception0("Impossible to verify the authenticity of this server.");
					default:
						throw new Exception0(string.Concat(new object[]
						{
							"Unable to check your license: ",
							jsonnumber.GetIntValue(),
							" (",
							jsonstring.GetStringValue(),
							")"
						}));
					}
				}
				else
				{
					int num = LogicJSONParser.ParseObject(result.Content.ReadAsStringAsync().Result).GetJSONNumber("sessionLimit").GetIntValue();
					if (num != -1)
					{
						int num2 = EnvironmentSettings.Servers[1].Length;
						if (num2 > 0)
						{
							num = num / num2 + ((num % num2 > 0) ? 1 : 0);
						}
					}
					else
					{
						num = 24000;
					}
					EnvironmentSettings.Settings.Proxy.SessionCapacity = num;
				}
			}
		}

		// Token: 0x06000002 RID: 2 RVA: 0x000096B0 File Offset: 0x000078B0
		private static byte[] smethod_1()
		{
			if (File.Exists("license.bin"))
			{
				return File.ReadAllBytes("license.bin");
			}
			if (File.Exists("C:\\Atrasis\\license.bin"))
			{
				return File.ReadAllBytes("C:\\Atrasis\\license.bin");
			}
			if (!File.Exists("/var/atrasis/license.bin"))
			{
				throw new Exception0("The license file does not exist.");
			}
			return File.ReadAllBytes("/var/atrasis/license.bin");
		}

		// Token: 0x04000001 RID: 1
		public const string string_0 = "license.bin";

		// Token: 0x04000002 RID: 2
		public const string string_1 = "atrasis";

		// Token: 0x04000003 RID: 3
		public const string string_2 = "1.1.0";

		// Token: 0x04000004 RID: 4
		public const string string_3 = "https://atrasis.net/server/license.php?name=atrasis&version=1.1.0";
	}
}
