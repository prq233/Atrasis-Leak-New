using System;
using System.Net;
using Atrasis.Magic.Servers.Core.Settings;
using Atrasis.Magic.Titan.Json;

namespace Atrasis.Magic.Servers.Core
{
	// Token: 0x0200000C RID: 12
	public static class ServerHttpClient
	{
		// Token: 0x06000033 RID: 51 RVA: 0x000047F8 File Offset: 0x000029F8
		private static WebClient smethod_0()
		{
			return new WebClient
			{
				Proxy = null
			};
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00009BF4 File Offset: 0x00007DF4
		public static byte[] DownloadBytes(string path)
		{
			try
			{
				using (WebClient webClient = ServerHttpClient.smethod_0())
				{
					return webClient.DownloadData(string.Format("{0}/{1}", ServerCore.ConfigurationServer, path));
				}
			}
			catch (Exception)
			{
				Logging.Warning(string.Format("ServerHttpClient: file {0} doesn't exist", path));
			}
			return null;
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00009C5C File Offset: 0x00007E5C
		public static string DownloadString(string path)
		{
			try
			{
				using (WebClient webClient = ServerHttpClient.smethod_0())
				{
					return webClient.DownloadString(string.Format("{0}/{1}", ServerCore.ConfigurationServer, path));
				}
			}
			catch (Exception)
			{
				Logging.Warning(string.Format("ServerHttpClient: file {0} doesn't exist", path));
			}
			return null;
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00009CC4 File Offset: 0x00007EC4
		public static LogicJSONObject DownloadJSON(string path)
		{
			try
			{
				using (WebClient webClient = ServerHttpClient.smethod_0())
				{
					return LogicJSONParser.ParseObject(webClient.DownloadString(string.Format("{0}/{1}", ServerCore.ConfigurationServer, path)));
				}
			}
			catch (Exception)
			{
				Logging.Warning(string.Format("ServerHttpClient: file {0} doesn't exist", path));
			}
			return null;
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00009D34 File Offset: 0x00007F34
		public static byte[] DownloadAsset(string resourceSha, string path)
		{
			try
			{
				using (WebClient webClient = ServerHttpClient.smethod_0())
				{
					return webClient.DownloadData(string.Format("{0}/{1}/{2}", ResourceSettings.GetContentUrl(), resourceSha, path));
				}
			}
			catch (Exception)
			{
				Logging.Warning(string.Format("ServerHttpClient: file {0} doesn't exist", path));
			}
			return null;
		}
	}
}
