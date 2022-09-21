using System;
using Atrasis.Magic.Servers.Core.Settings;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network
{
	// Token: 0x02000022 RID: 34
	public static class ServerManager
	{
		// Token: 0x060000CC RID: 204 RVA: 0x0000B348 File Offset: 0x00009548
		public static void Init()
		{
			ServerManager.bool_0 = true;
			ServerManager.int_0 = new int[30];
			ServerManager.serverSocket_0 = new ServerSocket[30][];
			for (int i = 0; i < 30; i++)
			{
				EnvironmentSettings.ServerConnectionEntry[] array = EnvironmentSettings.Servers[i];
				ServerManager.serverSocket_0[i] = new ServerSocket[array.Length];
				for (int j = 0; j < array.Length; j++)
				{
					ServerManager.serverSocket_0[i][j] = new ServerSocket(i, j, array[j].ServerIP, array[j].ServerPort);
				}
			}
		}

		// Token: 0x060000CD RID: 205 RVA: 0x00004D44 File Offset: 0x00002F44
		public static bool IsInit()
		{
			return ServerManager.bool_0;
		}

		// Token: 0x060000CE RID: 206 RVA: 0x0000B3D0 File Offset: 0x000095D0
		public static void DeInit()
		{
			if (ServerManager.serverSocket_0 != null)
			{
				for (int i = 0; i < 30; i++)
				{
					ServerSocket[] array = ServerManager.serverSocket_0[i];
					for (int j = 0; j < array.Length; j++)
					{
						array[j].Destruct();
					}
				}
				ServerManager.serverSocket_0 = null;
			}
			ServerManager.int_0 = null;
		}

		// Token: 0x060000CF RID: 207 RVA: 0x00004D4B File Offset: 0x00002F4B
		public static ServerSocket GetSocket(int type, int id)
		{
			return ServerManager.serverSocket_0[type][id];
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x0000B41C File Offset: 0x0000961C
		public static ServerSocket GetNextSocket(int type)
		{
			if (ServerManager.serverSocket_0[type].Length != 0)
			{
				int num = ServerManager.int_0[type];
				ServerManager.int_0[type] = (ServerManager.int_0[type] + 1 & ServerManager.serverSocket_0[type].Length - 1);
				return ServerManager.serverSocket_0[type][num];
			}
			return null;
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x00004D56 File Offset: 0x00002F56
		public static ServerSocket GetDocumentSocket(int type, LogicLong id)
		{
			if (ServerManager.serverSocket_0[type].Length != 0 && id.GetLowerInt() > 0)
			{
				return ServerManager.serverSocket_0[type][(id.GetLowerInt() - 1) % ServerManager.serverSocket_0[type].Length];
			}
			return null;
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00004D87 File Offset: 0x00002F87
		public static ServerSocket GetProxySocket(long sessionId)
		{
			return ServerManager.serverSocket_0[1][(int)(sessionId >> 55)];
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x00004D96 File Offset: 0x00002F96
		public static int GetServerCount(int type)
		{
			return ServerManager.serverSocket_0[type].Length;
		}

		// Token: 0x04000050 RID: 80
		private static bool bool_0;

		// Token: 0x04000051 RID: 81
		private static int[] int_0;

		// Token: 0x04000052 RID: 82
		private static ServerSocket[][] serverSocket_0;
	}
}
