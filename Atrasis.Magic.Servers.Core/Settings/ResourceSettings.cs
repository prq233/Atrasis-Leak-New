using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Servers.Core.Network.Message.Core;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Util;
using ns0;

namespace Atrasis.Magic.Servers.Core.Settings
{
	// Token: 0x0200001C RID: 28
	public static class ResourceSettings
	{
		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000085 RID: 133 RVA: 0x00004AC7 File Offset: 0x00002CC7
		// (set) Token: 0x06000086 RID: 134 RVA: 0x00004ACE File Offset: 0x00002CCE
		public static LogicArrayList<string> ContentUrlList { get; private set; }

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000087 RID: 135 RVA: 0x00004AD6 File Offset: 0x00002CD6
		// (set) Token: 0x06000088 RID: 136 RVA: 0x00004ADD File Offset: 0x00002CDD
		public static LogicArrayList<string> ChronosContentUrlList { get; private set; }

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000089 RID: 137 RVA: 0x00004AE5 File Offset: 0x00002CE5
		// (set) Token: 0x0600008A RID: 138 RVA: 0x00004AEC File Offset: 0x00002CEC
		public static Dictionary<int, string> AppStoreUrlList { get; private set; }

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x0600008B RID: 139 RVA: 0x00004AF4 File Offset: 0x00002CF4
		// (set) Token: 0x0600008C RID: 140 RVA: 0x00004AFB File Offset: 0x00002CFB
		public static string ResourceSHA { get; private set; }

		// Token: 0x0600008D RID: 141 RVA: 0x00004B03 File Offset: 0x00002D03
		internal static void smethod_0()
		{
			ResourceSettings.smethod_1(ServerHttpClient.DownloadJSON("resource.json"));
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00004B14 File Offset: 0x00002D14
		public static string GetContentUrl()
		{
			if (ResourceSettings.ContentUrlList.Size() > 1)
			{
				return ResourceSettings.ContentUrlList[1];
			}
			return null;
		}

		// Token: 0x0600008F RID: 143 RVA: 0x0000AA48 File Offset: 0x00008C48
		public static string GetAppStoreUrl(int appStore)
		{
			string result;
			if (!ResourceSettings.AppStoreUrlList.TryGetValue(appStore, out result))
			{
				result = ResourceSettings.AppStoreUrlList[2];
			}
			return result;
		}

		// Token: 0x06000090 RID: 144 RVA: 0x0000AA74 File Offset: 0x00008C74
		private static void smethod_1(LogicJSONObject logicJSONObject_0)
		{
			ResourceSettings.ContentUrlList = ResourceSettings.smethod_2(logicJSONObject_0.GetJSONArray("contentUrls"));
			ResourceSettings.ChronosContentUrlList = ResourceSettings.smethod_2(logicJSONObject_0.GetJSONArray("chronosContentUrls"));
			ResourceSettings.AppStoreUrlList = new Dictionary<int, string>();
			LogicJSONArray jsonarray = logicJSONObject_0.GetJSONArray("appstoreUrls");
			if (jsonarray != null)
			{
				for (int i = 0; i < jsonarray.Size(); i++)
				{
					LogicJSONObject jsonobject = jsonarray.GetJSONObject(i);
					if (!ResourceSettings.AppStoreUrlList.TryAdd(jsonobject.GetJSONNumber("id").GetIntValue(), jsonobject.GetJSONString("link").GetStringValue()))
					{
						throw new Exception1("ResourceSettings: app store already exists");
					}
				}
			}
			ResourceSettings.ResourceSHA = logicJSONObject_0.GetJSONString("resourceSHA").GetStringValue();
			ResourceSettings.Encryption.Load(logicJSONObject_0.GetJSONObject("encryption"));
			ResourceSettings.Environment.Load(logicJSONObject_0.GetJSONObject("environment"));
			ResourceSettings.Api.Load(logicJSONObject_0.GetJSONObject("api"));
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00004B30 File Offset: 0x00002D30
		public static void OnUpdateResourceSettingsMessageReceived(UpdateResourceSettingsMessage message)
		{
			ResourceSettings.Environment.SupportedCountries = message.SupportedCountries;
			ResourceSettings.Environment.SupportedAppVersions = message.SupportedAppVersions;
			ResourceSettings.Environment.DeveloperIPs = message.DeveloperIPs;
		}

		// Token: 0x06000092 RID: 146 RVA: 0x0000AB5C File Offset: 0x00008D5C
		private static LogicArrayList<string> smethod_2(LogicJSONArray logicJSONArray_0)
		{
			LogicArrayList<string> logicArrayList = new LogicArrayList<string>();
			if (logicJSONArray_0 != null)
			{
				for (int i = 0; i < logicJSONArray_0.Size(); i++)
				{
					logicArrayList.Add(logicJSONArray_0.GetJSONString(i).GetStringValue());
				}
			}
			return logicArrayList;
		}

		// Token: 0x06000093 RID: 147 RVA: 0x0000AB98 File Offset: 0x00008D98
		private static int[] smethod_3(LogicJSONArray logicJSONArray_0)
		{
			int[] array;
			if (logicJSONArray_0 != null)
			{
				array = new int[logicJSONArray_0.Size()];
				for (int i = 0; i < logicJSONArray_0.Size(); i++)
				{
					array[i] = logicJSONArray_0.GetJSONNumber(i).GetIntValue();
				}
			}
			else
			{
				array = null;
			}
			return array;
		}

		// Token: 0x06000094 RID: 148 RVA: 0x0000ABDC File Offset: 0x00008DDC
		private static string[] smethod_4(LogicJSONArray logicJSONArray_0)
		{
			string[] array;
			if (logicJSONArray_0 != null)
			{
				array = new string[logicJSONArray_0.Size()];
				for (int i = 0; i < logicJSONArray_0.Size(); i++)
				{
					array[i] = logicJSONArray_0.GetJSONString(i).GetStringValue();
				}
			}
			else
			{
				array = null;
			}
			return array;
		}

		// Token: 0x06000095 RID: 149 RVA: 0x0000AC20 File Offset: 0x00008E20
		public static LogicJSONObject Save()
		{
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			logicJSONObject.Put("contentUrls", ResourceSettings.smethod_5(ResourceSettings.ContentUrlList));
			logicJSONObject.Put("chronosContentUrls", ResourceSettings.smethod_5(ResourceSettings.ChronosContentUrlList));
			LogicJSONArray logicJSONArray = new LogicJSONArray();
			foreach (KeyValuePair<int, string> keyValuePair in ResourceSettings.AppStoreUrlList)
			{
				LogicJSONObject logicJSONObject2 = new LogicJSONObject();
				logicJSONObject2.Put("id", new LogicJSONNumber(keyValuePair.Key));
				logicJSONObject2.Put("link", new LogicJSONString(keyValuePair.Value));
				logicJSONArray.Add(logicJSONObject2);
			}
			logicJSONObject.Put("resourceSHA", new LogicJSONString(ResourceSettings.ResourceSHA));
			logicJSONObject.Put("encryption", ResourceSettings.Encryption.Save());
			logicJSONObject.Put("environment", ResourceSettings.Environment.Save());
			logicJSONObject.Put("api", ResourceSettings.Environment.Save());
			return logicJSONObject;
		}

		// Token: 0x06000096 RID: 150 RVA: 0x0000AD28 File Offset: 0x00008F28
		private static LogicJSONArray smethod_5(LogicArrayList<string> logicArrayList_2)
		{
			LogicJSONArray logicJSONArray = new LogicJSONArray();
			for (int i = 0; i < logicArrayList_2.Size(); i++)
			{
				logicJSONArray.Add(new LogicJSONString(logicArrayList_2[i]));
			}
			return logicJSONArray;
		}

		// Token: 0x06000097 RID: 151 RVA: 0x0000AD60 File Offset: 0x00008F60
		private static LogicJSONArray smethod_6(int[] int_0)
		{
			LogicJSONArray logicJSONArray = new LogicJSONArray();
			if (int_0 != null)
			{
				for (int i = 0; i < int_0.Length; i++)
				{
					logicJSONArray.Add(new LogicJSONNumber(int_0[i]));
				}
			}
			return logicJSONArray;
		}

		// Token: 0x06000098 RID: 152 RVA: 0x0000A454 File Offset: 0x00008654
		private static LogicJSONArray smethod_7(string[] string_1)
		{
			LogicJSONArray logicJSONArray = new LogicJSONArray();
			if (string_1 != null)
			{
				for (int i = 0; i < string_1.Length; i++)
				{
					logicJSONArray.Add(new LogicJSONString(string_1[i]));
				}
			}
			return logicJSONArray;
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00004B53 File Offset: 0x00002D53
		public static bool IsSupportedAppVersion(string appVersion)
		{
			return ResourceSettings.Environment.SupportedAppVersions == null || Array.IndexOf<string>(ResourceSettings.Environment.SupportedAppVersions, appVersion) != -1;
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00004B6F File Offset: 0x00002D6F
		public static bool IsSupportedCountry(string country)
		{
			return ResourceSettings.Environment.SupportedCountries == null || Array.IndexOf<string>(ResourceSettings.Environment.SupportedCountries, country) != -1;
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00004B8B File Offset: 0x00002D8B
		public static bool IsDeveloperIP(string ip)
		{
			return ResourceSettings.Environment.DeveloperIPs != null && Array.IndexOf<string>(ResourceSettings.Environment.DeveloperIPs, ip) != -1;
		}

		// Token: 0x04000037 RID: 55
		[CompilerGenerated]
		private static LogicArrayList<string> logicArrayList_0;

		// Token: 0x04000038 RID: 56
		[CompilerGenerated]
		private static LogicArrayList<string> logicArrayList_1;

		// Token: 0x04000039 RID: 57
		[CompilerGenerated]
		private static Dictionary<int, string> dictionary_0;

		// Token: 0x0400003A RID: 58
		[CompilerGenerated]
		private static string string_0;

		// Token: 0x0200001D RID: 29
		public static class Encryption
		{
			// Token: 0x17000026 RID: 38
			// (get) Token: 0x0600009C RID: 156 RVA: 0x00004BA7 File Offset: 0x00002DA7
			// (set) Token: 0x0600009D RID: 157 RVA: 0x00004BAE File Offset: 0x00002DAE
			public static bool Enabled { get; private set; }

			// Token: 0x17000027 RID: 39
			// (get) Token: 0x0600009E RID: 158 RVA: 0x00004BB6 File Offset: 0x00002DB6
			// (set) Token: 0x0600009F RID: 159 RVA: 0x00004BBD File Offset: 0x00002DBD
			public static byte[][] SecretPepperKey { get; private set; }

			// Token: 0x17000028 RID: 40
			// (get) Token: 0x060000A0 RID: 160 RVA: 0x00004BC5 File Offset: 0x00002DC5
			// (set) Token: 0x060000A1 RID: 161 RVA: 0x00004BCC File Offset: 0x00002DCC
			public static byte[][] PublicPepperKey { get; private set; }

			// Token: 0x060000A2 RID: 162 RVA: 0x0000AD94 File Offset: 0x00008F94
			public static void Load(LogicJSONObject jsonObject)
			{
				if (jsonObject != null)
				{
					LogicJSONArray jsonarray = jsonObject.GetJSONArray("pepperKeys");
					if (jsonarray != null)
					{
						byte[][] array = new byte[jsonarray.Size()][];
						byte[][] array2 = new byte[jsonarray.Size()][];
						for (int i = 0; i < jsonarray.Size(); i++)
						{
							LogicJSONObject jsonobject = jsonarray.GetJSONObject(i);
							LogicJSONString jsonstring = jsonobject.GetJSONString("secret");
							LogicJSONString jsonstring2 = jsonobject.GetJSONString("public");
							byte[] array3 = Convert.FromBase64String(jsonstring.GetStringValue());
							byte[] array4 = Convert.FromBase64String(jsonstring2.GetStringValue());
							Logging.Assert(array3.Length == 32, "ResourceSettings.load: invalid secret key size: " + array3.Length);
							Logging.Assert(array4.Length == 32, "ResourceSettings.load: invalid public key size: " + array4.Length);
							array2[i] = array3;
							array[i] = array4;
						}
						ResourceSettings.Encryption.SecretPepperKey = array2;
						ResourceSettings.Encryption.PublicPepperKey = array;
					}
					ResourceSettings.Encryption.Enabled = jsonObject.GetJSONBoolean("enabled").IsTrue();
				}
			}

			// Token: 0x060000A3 RID: 163 RVA: 0x0000AE8C File Offset: 0x0000908C
			public static LogicJSONObject Save()
			{
				LogicJSONObject logicJSONObject = new LogicJSONObject();
				if (ResourceSettings.Encryption.PublicPepperKey != null && ResourceSettings.Encryption.SecretPepperKey != null)
				{
					LogicJSONArray item = new LogicJSONArray(ResourceSettings.Encryption.SecretPepperKey.Length);
					for (int i = 0; i < ResourceSettings.Encryption.SecretPepperKey.Length; i++)
					{
						LogicJSONObject logicJSONObject2 = new LogicJSONObject(2);
						logicJSONObject2.Put("secret", new LogicJSONString(Convert.ToBase64String(ResourceSettings.Encryption.SecretPepperKey[i])));
						logicJSONObject2.Put("public", new LogicJSONString(Convert.ToBase64String(ResourceSettings.Encryption.PublicPepperKey[i])));
					}
					logicJSONObject.Put("pepperKeys", item);
				}
				return null;
			}

			// Token: 0x0400003B RID: 59
			[CompilerGenerated]
			private static bool bool_0;

			// Token: 0x0400003C RID: 60
			[CompilerGenerated]
			private static byte[][] byte_0;

			// Token: 0x0400003D RID: 61
			[CompilerGenerated]
			private static byte[][] byte_1;
		}

		// Token: 0x0200001E RID: 30
		public static class Environment
		{
			// Token: 0x17000029 RID: 41
			// (get) Token: 0x060000A4 RID: 164 RVA: 0x00004BD4 File Offset: 0x00002DD4
			// (set) Token: 0x060000A5 RID: 165 RVA: 0x00004BDB File Offset: 0x00002DDB
			public static string[] SupportedAppVersions { get; set; }

			// Token: 0x1700002A RID: 42
			// (get) Token: 0x060000A6 RID: 166 RVA: 0x00004BE3 File Offset: 0x00002DE3
			// (set) Token: 0x060000A7 RID: 167 RVA: 0x00004BEA File Offset: 0x00002DEA
			public static string[] SupportedCountries { get; set; }

			// Token: 0x1700002B RID: 43
			// (get) Token: 0x060000A8 RID: 168 RVA: 0x00004BF2 File Offset: 0x00002DF2
			// (set) Token: 0x060000A9 RID: 169 RVA: 0x00004BF9 File Offset: 0x00002DF9
			public static string[] DeveloperIPs { get; set; }

			// Token: 0x1700002C RID: 44
			// (get) Token: 0x060000AA RID: 170 RVA: 0x00004C01 File Offset: 0x00002E01
			// (set) Token: 0x060000AB RID: 171 RVA: 0x00004C08 File Offset: 0x00002E08
			public static string[] PresetLevelFiles { get; private set; }

			// Token: 0x1700002D RID: 45
			// (get) Token: 0x060000AC RID: 172 RVA: 0x00004C10 File Offset: 0x00002E10
			// (set) Token: 0x060000AD RID: 173 RVA: 0x00004C17 File Offset: 0x00002E17
			public static string[] PresetLevelJSON { get; private set; }

			// Token: 0x1700002E RID: 46
			// (get) Token: 0x060000AE RID: 174 RVA: 0x00004C1F File Offset: 0x00002E1F
			// (set) Token: 0x060000AF RID: 175 RVA: 0x00004C26 File Offset: 0x00002E26
			public static bool ContentValidationModeEnabled { get; private set; }

			// Token: 0x1700002F RID: 47
			// (get) Token: 0x060000B0 RID: 176 RVA: 0x00004C2E File Offset: 0x00002E2E
			// (set) Token: 0x060000B1 RID: 177 RVA: 0x00004C35 File Offset: 0x00002E35
			public static bool OPCommandAllowedInGlobalChat { get; private set; }

			// Token: 0x060000B2 RID: 178 RVA: 0x0000AF18 File Offset: 0x00009118
			public static void Load(LogicJSONObject jsonObject)
			{
				ResourceSettings.Environment.OPCommandAllowedInGlobalChat = jsonObject.GetJSONBoolean("opCommandAllowedInGlobalChat").IsTrue();
				ResourceSettings.Environment.ContentValidationModeEnabled = jsonObject.GetJSONBoolean("contentValidationModeEnabled").IsTrue();
				ResourceSettings.Environment.SupportedAppVersions = ResourceSettings.smethod_4(jsonObject.GetJSONArray("supportedAppVersions"));
				ResourceSettings.Environment.SupportedCountries = ResourceSettings.smethod_4(jsonObject.GetJSONArray("supportedCountries"));
				ResourceSettings.Environment.DeveloperIPs = ResourceSettings.smethod_4(jsonObject.GetJSONArray("developerIPs"));
				ResourceSettings.Environment.PresetLevelFiles = ResourceSettings.smethod_4(jsonObject.GetJSONArray("presetLevelFiles"));
				ResourceSettings.Environment.PresetLevelJSON = new string[ResourceSettings.Environment.PresetLevelFiles.Length];
				for (int i = 0; i < ResourceSettings.Environment.PresetLevelFiles.Length; i++)
				{
					ResourceSettings.Environment.PresetLevelJSON[i] = ServerHttpClient.DownloadString("data/" + ResourceSettings.Environment.PresetLevelFiles[i]);
				}
			}

			// Token: 0x060000B3 RID: 179 RVA: 0x0000AFE4 File Offset: 0x000091E4
			public static LogicJSONObject Save()
			{
				LogicJSONObject logicJSONObject = new LogicJSONObject();
				logicJSONObject.Put("opCommandAllowedInGlobalChat", new LogicJSONBoolean(ResourceSettings.Environment.OPCommandAllowedInGlobalChat));
				logicJSONObject.Put("contentValidationModeEnabled", new LogicJSONBoolean(ResourceSettings.Environment.ContentValidationModeEnabled));
				logicJSONObject.Put("supportedAppVersions", ResourceSettings.smethod_7(ResourceSettings.Environment.SupportedAppVersions));
				logicJSONObject.Put("supportedCountries", ResourceSettings.smethod_7(ResourceSettings.Environment.SupportedCountries));
				logicJSONObject.Put("developerIPs", ResourceSettings.smethod_7(ResourceSettings.Environment.DeveloperIPs));
				logicJSONObject.Put("presetLevelFiles", ResourceSettings.smethod_7(ResourceSettings.Environment.PresetLevelFiles));
				return logicJSONObject;
			}

			// Token: 0x0400003E RID: 62
			[CompilerGenerated]
			private static string[] string_0;

			// Token: 0x0400003F RID: 63
			[CompilerGenerated]
			private static string[] string_1;

			// Token: 0x04000040 RID: 64
			[CompilerGenerated]
			private static string[] string_2;

			// Token: 0x04000041 RID: 65
			[CompilerGenerated]
			private static string[] string_3;

			// Token: 0x04000042 RID: 66
			[CompilerGenerated]
			private static string[] string_4;

			// Token: 0x04000043 RID: 67
			[CompilerGenerated]
			private static bool bool_0;

			// Token: 0x04000044 RID: 68
			[CompilerGenerated]
			private static bool bool_1;
		}

		// Token: 0x0200001F RID: 31
		public static class Api
		{
			// Token: 0x17000030 RID: 48
			// (get) Token: 0x060000B4 RID: 180 RVA: 0x00004C3D File Offset: 0x00002E3D
			// (set) Token: 0x060000B5 RID: 181 RVA: 0x00004C44 File Offset: 0x00002E44
			public static string FacebookAppId { get; set; }

			// Token: 0x17000031 RID: 49
			// (get) Token: 0x060000B6 RID: 182 RVA: 0x00004C4C File Offset: 0x00002E4C
			// (set) Token: 0x060000B7 RID: 183 RVA: 0x00004C53 File Offset: 0x00002E53
			public static string GoogleClientId { get; set; }

			// Token: 0x17000032 RID: 50
			// (get) Token: 0x060000B8 RID: 184 RVA: 0x00004C5B File Offset: 0x00002E5B
			// (set) Token: 0x060000B9 RID: 185 RVA: 0x00004C62 File Offset: 0x00002E62
			public static string GoogleClientSecret { get; set; }

			// Token: 0x060000BA RID: 186 RVA: 0x0000B074 File Offset: 0x00009274
			public static void Load(LogicJSONObject jsonObject)
			{
				ResourceSettings.Api.FacebookAppId = jsonObject.GetJSONString("facebookAppId").GetStringValue();
				ResourceSettings.Api.GoogleClientId = jsonObject.GetJSONString("googleClientId").GetStringValue();
				ResourceSettings.Api.GoogleClientSecret = jsonObject.GetJSONString("googleClientSecret").GetStringValue();
			}

			// Token: 0x060000BB RID: 187 RVA: 0x0000B0C0 File Offset: 0x000092C0
			public static LogicJSONObject Save()
			{
				LogicJSONObject logicJSONObject = new LogicJSONObject();
				logicJSONObject.Put("facebookAppId", new LogicJSONString(ResourceSettings.Api.FacebookAppId));
				logicJSONObject.Put("googleClientId", new LogicJSONString(ResourceSettings.Api.GoogleClientId));
				logicJSONObject.Put("googleClientSecret", new LogicJSONString(ResourceSettings.Api.GoogleClientSecret));
				return logicJSONObject;
			}

			// Token: 0x04000045 RID: 69
			[CompilerGenerated]
			private static string string_0;

			// Token: 0x04000046 RID: 70
			[CompilerGenerated]
			private static string string_1;

			// Token: 0x04000047 RID: 71
			[CompilerGenerated]
			private static string string_2;
		}
	}
}
