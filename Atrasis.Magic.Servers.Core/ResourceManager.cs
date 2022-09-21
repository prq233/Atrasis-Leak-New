using System;
using System.IO;
using System.Text;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Servers.Core.Helper;
using Atrasis.Magic.Servers.Core.Settings;
using Atrasis.Magic.Titan.CSV;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Util;
using ns0;
using SevenZip.Compression.LZMA;

namespace Atrasis.Magic.Servers.Core
{
	// Token: 0x02000006 RID: 6
	public static class ResourceManager
	{
		// Token: 0x06000010 RID: 16 RVA: 0x0000471A File Offset: 0x0000291A
		internal static void smethod_0()
		{
			ResourceManager.smethod_1();
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00004721 File Offset: 0x00002921
		private static void smethod_1()
		{
			ResourceManager.smethod_3();
			ResourceManager.smethod_4();
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00009764 File Offset: 0x00007964
		private static byte[] smethod_2(string string_0, byte[] byte_0)
		{
			if (byte_0 != null)
			{
				string extension = Path.GetExtension(string_0);
				if (extension != null && extension == ".csv")
				{
					using (MemoryStream memoryStream = new MemoryStream(byte_0))
					{
						using (MemoryStream memoryStream2 = new MemoryStream())
						{
							SevenZip.Compression.LZMA.Decoder decoder = new SevenZip.Compression.LZMA.Decoder();
							byte[] array = new byte[5];
							byte[] array2 = new byte[4];
							memoryStream.Read(array, 0, 5);
							memoryStream.Read(array2, 0, 4);
							int num = (int)array2[0] | (int)array2[1] << 8 | (int)array2[2] << 16 | (int)array2[3] << 24;
							decoder.SetDecoderProperties(array);
							decoder.Code(memoryStream, memoryStream2, memoryStream.Length, (long)num, null);
							byte_0 = memoryStream2.ToArray();
						}
					}
				}
				return byte_0;
			}
			return null;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x0000983C File Offset: 0x00007A3C
		private static void smethod_3()
		{
			ResourceManager.FINGERPRINT_JSON = ResourceManager.smethod_5("fingerprint.json");
			if (ResourceManager.FINGERPRINT_JSON == null)
			{
				throw new Exception1("fingerprint.json doesn't exists.");
			}
			LogicJSONObject jsonObject = (LogicJSONObject)LogicJSONParser.Parse(ResourceManager.FINGERPRINT_JSON);
			ResourceManager.FINGERPRINT_SHA = LogicJSONHelper.GetString(jsonObject, "sha");
			ResourceManager.FINGERPRINT_VERSION = LogicJSONHelper.GetString(jsonObject, "version");
			string[] array = ResourceManager.FINGERPRINT_VERSION.Split('.', StringSplitOptions.None);
			if (array.Length == 3)
			{
				ResourceManager.int_0 = new int[3];
				for (int i = 0; i < 3; i++)
				{
					ResourceManager.int_0[i] = int.Parse(array[i]);
				}
			}
			else
			{
				Logging.Error("ResourceManager.loadFingerprint: invalid fingerprint version: " + ResourceManager.FINGERPRINT_VERSION);
			}
			ZLibHelper.CompressInZLibFormat(LogicStringUtil.GetBytes(ResourceManager.FINGERPRINT_JSON), out ResourceManager.COMPRESSED_FINGERPRINT_DATA);
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00009900 File Offset: 0x00007B00
		private static void smethod_4()
		{
			string text = ServerHttpClient.DownloadString("/data/calendar.json");
			string text2 = ServerHttpClient.DownloadString("/data/globals.json");
			if (text == null)
			{
				throw new Exception1("/data/calendar.json doesn't exists.");
			}
			if (text2 == null)
			{
				throw new Exception1("/data/globals.json doesn't exists.");
			}
			ZLibHelper.CompressInZLibFormat(LogicStringUtil.GetBytes(text), out ResourceManager.SERVER_SAVE_FILE_CALENDAR);
			ZLibHelper.CompressInZLibFormat(LogicStringUtil.GetBytes(text2), out ResourceManager.SERVER_SAVE_FILE_GLOBAL);
			LogicDataTables.Init();
			LogicArrayList<LogicDataTableResource> logicArrayList = LogicResources.CreateDataTableResourcesArray();
			for (int i = 0; i < logicArrayList.Size(); i++)
			{
				string fileName = logicArrayList[i].GetFileName();
				string text3 = ResourceManager.smethod_5(fileName);
				if (text3 == null)
				{
					throw new Exception1(fileName + " doesn't exists.");
				}
				LogicResources.Load(logicArrayList, i, new CSVNode(text3.Split(new string[]
				{
					"\r\n",
					"\n"
				}, StringSplitOptions.None), fileName));
			}
		}

		// Token: 0x06000015 RID: 21 RVA: 0x000099D4 File Offset: 0x00007BD4
		private static string smethod_5(string string_0)
		{
			byte[] array = ResourceManager.smethod_6(string_0);
			if (array != null)
			{
				return Encoding.UTF8.GetString(array);
			}
			return null;
		}

		// Token: 0x06000016 RID: 22 RVA: 0x0000472D File Offset: 0x0000292D
		private static byte[] smethod_6(string string_0)
		{
			return ResourceManager.smethod_2(string_0, ServerHttpClient.DownloadAsset(ResourceSettings.ResourceSHA, string_0));
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00004740 File Offset: 0x00002940
		public static int GetContentVersion()
		{
			return ResourceManager.int_0[2];
		}

		// Token: 0x04000007 RID: 7
		public static byte[] SERVER_SAVE_FILE_CALENDAR;

		// Token: 0x04000008 RID: 8
		public static byte[] SERVER_SAVE_FILE_GLOBAL;

		// Token: 0x04000009 RID: 9
		public static byte[] COMPRESSED_FINGERPRINT_DATA;

		// Token: 0x0400000A RID: 10
		public static string FINGERPRINT_VERSION;

		// Token: 0x0400000B RID: 11
		public static string FINGERPRINT_JSON;

		// Token: 0x0400000C RID: 12
		public static string FINGERPRINT_SHA;

		// Token: 0x0400000D RID: 13
		private static int[] int_0;
	}
}
