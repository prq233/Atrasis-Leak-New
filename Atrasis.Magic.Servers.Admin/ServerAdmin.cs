using System;
using Atrasis.Magic.Servers.Admin.Logic;
using Atrasis.Magic.Servers.Core;
using Atrasis.Magic.Servers.Core.Database;
using Atrasis.Magic.Servers.Core.Network;
using Atrasis.Magic.Servers.Core.Network.Message;
using Atrasis.Magic.Servers.Core.Network.Message.Core;

namespace Atrasis.Magic.Servers.Admin
{
	// Token: 0x02000004 RID: 4
	public static class ServerAdmin
	{
		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000009 RID: 9 RVA: 0x000020A7 File Offset: 0x000002A7
		// (set) Token: 0x0600000A RID: 10 RVA: 0x000020AE File Offset: 0x000002AE
		public static CouchbaseDatabase AccountDatabase { get; private set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600000B RID: 11 RVA: 0x000020B6 File Offset: 0x000002B6
		// (set) Token: 0x0600000C RID: 12 RVA: 0x000020BD File Offset: 0x000002BD
		public static CouchbaseDatabase GameDatabase { get; private set; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600000D RID: 13 RVA: 0x000020C5 File Offset: 0x000002C5
		// (set) Token: 0x0600000E RID: 14 RVA: 0x000020CC File Offset: 0x000002CC
		public static RedisDatabase SessionDatabase { get; private set; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600000F RID: 15 RVA: 0x000020D4 File Offset: 0x000002D4
		// (set) Token: 0x06000010 RID: 16 RVA: 0x000020DB File Offset: 0x000002DB
		public static RedisDatabase AdminDatabase { get; private set; }

		// Token: 0x06000011 RID: 17 RVA: 0x00002DD8 File Offset: 0x00000FD8
		public static void Init()
		{
			ServerAdmin.AccountDatabase = new CouchbaseDatabase("magic-players", "account");
			ServerAdmin.AccountDatabase.CreateIndexWithFilter("accountIndex", "meta().id LIKE '%KEY_PREFIX%%'", new string[]
			{
				"meta().id",
				"createTime",
				"lastSessionTime"
			});
			ServerAdmin.GameDatabase = new CouchbaseDatabase("magic-players", "game");
			ServerAdmin.GameDatabase.CreateIndexWithFilter("gameIndex", "meta().id LIKE '%KEY_PREFIX%%'", new string[]
			{
				"meta().id",
				"name",
				"xp_level",
				"score",
				"alliance_name"
			});
			ServerAdmin.SessionDatabase = new RedisDatabase("magic-session", -1);
			ServerAdmin.AdminDatabase = new RedisDatabase("magic-admin", 1);
			DashboardManager.Init();
			Atrasis.Magic.Servers.Admin.Logic.ServerManager.Init();
			UserManager.Init();
			LogManager.Init();
			ServerStatus.OnServerStatusChanged = new ServerStatus.ServerStatusChanged(ServerAdmin.OnServerStatusChanged);
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000020E3 File Offset: 0x000002E3
		public static void Start()
		{
			DashboardManager.Start();
			UserManager.Start();
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002EC8 File Offset: 0x000010C8
		private static void OnServerStatusChanged(ServerStatusType type, int time, int nextTime)
		{
			for (int i = 1; i < 30; i++)
			{
				int j = 0;
				int serverCount = Atrasis.Magic.Servers.Core.Network.ServerManager.GetServerCount(i);
				while (j < serverCount)
				{
					ServerMessageManager.SendMessage(new ServerStatusMessage
					{
						Type = type,
						Time = time,
						NextTime = nextTime
					}, i, j);
					j++;
				}
			}
		}
	}
}
