using System;
using System.Collections.Generic;
using System.Threading;
using Atrasis.Magic.Servers.Core;
using Atrasis.Magic.Servers.Core.Network;
using Atrasis.Magic.Servers.Core.Network.Message;
using Atrasis.Magic.Servers.Core.Network.Message.Core;
using Atrasis.Magic.Servers.Core.Util;
using Couchbase.N1QL;
using Newtonsoft.Json.Linq;

namespace Atrasis.Magic.Servers.Admin.Logic
{
	// Token: 0x0200001E RID: 30
	public static class ServerManager
	{
		// Token: 0x17000052 RID: 82
		// (get) Token: 0x060000CA RID: 202 RVA: 0x000038A4 File Offset: 0x00001AA4
		public static int OnlineUsers
		{
			get
			{
				int num = 0;
				ServerPerformance[] array = ServerManager.m_entry[1];
				for (int i = 0; i < array.Length; i++)
				{
					num += array[i].SessionCount;
				}
				return num;
			}
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x060000CB RID: 203 RVA: 0x00002784 File Offset: 0x00000984
		public static ServerPerformance[][] Servers
		{
			get
			{
				return ServerManager.m_entry;
			}
		}

		// Token: 0x060000CC RID: 204 RVA: 0x000038D8 File Offset: 0x00001AD8
		public static void Init()
		{
			ServerManager.m_entry = new ServerPerformance[30][];
			for (int i = 0; i < 30; i++)
			{
				ServerPerformance[] array = new ServerPerformance[ServerManager.GetServerCount(i)];
				for (int j = 0; j < array.Length; j++)
				{
					array[j] = new ServerPerformance(ServerManager.GetSocket(i, j));
				}
				ServerManager.m_entry[i] = array;
			}
			ServerManager.m_warningIPList = new List<string>();
			ServerManager.m_thread = new Thread(new ThreadStart(ServerManager.Update));
			ServerManager.m_thread.Start();
		}

		// Token: 0x060000CD RID: 205 RVA: 0x0000395C File Offset: 0x00001B5C
		private static void Update()
		{
			Thread.Sleep(5000);
			int num = 0;
			int num2 = TimeUtil.GetTimestamp();
			for (;;)
			{
				if (ServerStatus.Status == ServerStatusType.SHUTDOWN_STARTED && ServerStatus.Time - TimeUtil.GetTimestamp() < 0)
				{
					ServerStatus.SetStatus(ServerStatusType.MAINTENANCE, ServerStatus.NextTime + TimeUtil.GetTimestamp(), 0);
				}
				if (ServerStatus.Status == ServerStatusType.COOLDOWN_AFTER_MAINTENANCE && ServerStatus.Time - TimeUtil.GetTimestamp() < 0)
				{
					ServerStatus.SetStatus(ServerStatusType.NORMAL, 0, 0);
				}
				if (num++ % 20 == 0)
				{
					for (int i = 0; i < 30; i++)
					{
						ServerPerformance[] array = ServerManager.m_entry[i];
						for (int j = 0; j < array.Length; j++)
						{
							array[j].SendPingMessage();
						}
					}
					for (int k = 0; k < 30; k++)
					{
						ServerPerformance[] array2 = ServerManager.m_entry[k];
						for (int l = 0; l < array2.Length; l++)
						{
							ServerMessageManager.SendMessage(new ServerPerformanceMessage(), array2[l].Socket);
						}
					}
					int timestamp = TimeUtil.GetTimestamp();
					ServerManager.CheckAccountIP(timestamp - (timestamp - num2));
					num2 = timestamp;
					if (num == 20)
					{
						num = 1;
					}
				}
				Thread.Sleep(500);
			}
		}

		// Token: 0x060000CE RID: 206 RVA: 0x00003A7C File Offset: 0x00001C7C
		private static void CheckAccountIP(int timestamp)
		{
			IQueryResult<JObject> result = ServerAdmin.AccountDatabase.ExecuteCommand<JObject>(string.Format("SELECT createIpAddr FROM `%BUCKET%` WHERE meta().id LIKE \"%KEY_PREFIX%%\" AND createTime >= {0}", timestamp)).Result;
			if (result.Success)
			{
				Dictionary<string, int> dictionary = new Dictionary<string, int>();
				foreach (JObject jobject in result.Rows)
				{
					JToken value;
					if (jobject.TryGetValue("createIpAddr", out value))
					{
						string text = (string)value;
						if (!dictionary.TryAdd(text, 1))
						{
							Dictionary<string, int> dictionary2 = dictionary;
							string key = text;
							dictionary2[key]++;
						}
					}
				}
				foreach (KeyValuePair<string, int> keyValuePair in dictionary)
				{
					if (keyValuePair.Value >= 10 && ServerManager.m_warningIPList.IndexOf(keyValuePair.Key) == -1)
					{
						Logging.Error(string.Format("Malicious action detected. Several accounts ({0}) have been created from this ip address: {1}", keyValuePair.Value, keyValuePair.Key));
						ServerManager.m_warningIPList.Add(keyValuePair.Key);
					}
				}
			}
		}

		// Token: 0x060000CF RID: 207 RVA: 0x0000278B File Offset: 0x0000098B
		public static void OnPongMessageReceived(PongMessage message)
		{
			ServerManager.m_entry[message.SenderType][message.SenderId].OnPongMessageReceived();
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x000027A5 File Offset: 0x000009A5
		public static void OnServerPerformanceDataMessageReceived(ServerPerformanceDataMessage message)
		{
			ServerManager.m_entry[message.SenderType][message.SenderId].OnServerPerformanceDataMessageReceived(message);
			if (message.SenderType == 1)
			{
				DashboardManager.OnOnlineUsersChanged(ServerManager.OnlineUsers);
			}
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x000027D3 File Offset: 0x000009D3
		public static void OnClusterPerformanceDataMessageReceived(ClusterPerformanceDataMessage message)
		{
			ServerManager.m_entry[message.SenderType][message.SenderId].OnClusterPerformanceDataMessageReceived(message);
		}

		// Token: 0x04000057 RID: 87
		private static ServerPerformance[][] m_entry;

		// Token: 0x04000058 RID: 88
		private static Thread m_thread;

		// Token: 0x04000059 RID: 89
		private static List<string> m_warningIPList;
	}
}
