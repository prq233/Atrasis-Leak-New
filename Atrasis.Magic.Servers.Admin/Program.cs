using System;
using Atrasis.Magic.Servers.Admin.Network.Message;
using Atrasis.Magic.Servers.Core;
using Atrasis.Magic.Servers.Core.Settings;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Atrasis.Magic.Servers.Admin
{
	// Token: 0x02000003 RID: 3
	public class Program
	{
		// Token: 0x06000006 RID: 6 RVA: 0x0000207F File Offset: 0x0000027F
		public static IWebHostBuilder CreateWebHostBuilder(string[] args)
		{
			return WebHost.CreateDefaultBuilder(args).UseUrls(new string[]
			{
				"http://0.0.0.0:5000"
			}).UseStartup<Startup>();
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002D88 File Offset: 0x00000F88
		public static void Main(string[] args)
		{
			ServerCore.Init(0, args);
			ServerAdmin.Init();
			ServerCore.Start(new AdminMessageManager());
			if (EnvironmentSettings.Settings.StartInMaintenanceMode)
			{
				ServerStatus.SetStatus(ServerStatusType.MAINTENANCE, 0, 0);
			}
			ServerAdmin.Start();
			Program.CreateWebHostBuilder(args).Build().Run();
		}
	}
}
