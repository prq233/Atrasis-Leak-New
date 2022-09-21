using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Atrasis.Magic.Servers.Core.Util;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;
using Couchbase.N1QL;
using Couchbase.Views;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json.Linq;
using StackExchange.Redis;

namespace Atrasis.Magic.Servers.Admin.Logic
{
	// Token: 0x02000017 RID: 23
	public static class DashboardManager
	{
		// Token: 0x1700003A RID: 58
		// (get) Token: 0x0600009B RID: 155 RVA: 0x00002534 File Offset: 0x00000734
		// (set) Token: 0x0600009C RID: 156 RVA: 0x0000253B File Offset: 0x0000073B
		public static int[] TotalUsers { get; private set; }

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x0600009D RID: 157 RVA: 0x00002543 File Offset: 0x00000743
		// (set) Token: 0x0600009E RID: 158 RVA: 0x0000254A File Offset: 0x0000074A
		public static int[] DailyActiveUsers { get; private set; }

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x0600009F RID: 159 RVA: 0x00002552 File Offset: 0x00000752
		// (set) Token: 0x060000A0 RID: 160 RVA: 0x00002559 File Offset: 0x00000759
		public static int[] NewUsers { get; private set; }

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060000A1 RID: 161 RVA: 0x00002561 File Offset: 0x00000761
		// (set) Token: 0x060000A2 RID: 162 RVA: 0x00002568 File Offset: 0x00000768
		public static int[] MaxOnlineUsers { get; private set; }

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060000A3 RID: 163 RVA: 0x00002570 File Offset: 0x00000770
		// (set) Token: 0x060000A4 RID: 164 RVA: 0x00002577 File Offset: 0x00000777
		public static Dictionary<string, int> UsersByCountry { get; private set; }

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060000A5 RID: 165 RVA: 0x0000257F File Offset: 0x0000077F
		// (set) Token: 0x060000A6 RID: 166 RVA: 0x00002586 File Offset: 0x00000786
		public static DateTime LastUpdate { get; private set; }

		// Token: 0x060000A7 RID: 167 RVA: 0x000031E4 File Offset: 0x000013E4
		public static void Init()
		{
			DashboardManager.TotalUsers = new int[7];
			DashboardManager.DailyActiveUsers = new int[7];
			DashboardManager.NewUsers = new int[7];
			DashboardManager.MaxOnlineUsers = new int[7];
			DashboardManager.UsersByCountry = new Dictionary<string, int>();
			DashboardManager.m_thread = new Thread(new ThreadStart(DashboardManager.Update));
			DashboardManager.Load();
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x0000258E File Offset: 0x0000078E
		public static void Start()
		{
			DashboardManager.m_thread.Start();
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00003244 File Offset: 0x00001444
		private static void Load()
		{
			RedisValue result = ServerAdmin.AdminDatabase.Get("dashboard").Result;
			if (!result.IsNullOrEmpty)
			{
				LogicJSONObject logicJSONObject = LogicJSONParser.ParseObject(result);
				LogicJSONArray jsonarray = logicJSONObject.GetJSONArray("totalUsers");
				LogicJSONArray jsonarray2 = logicJSONObject.GetJSONArray("dailyActiveUsers");
				LogicJSONArray jsonarray3 = logicJSONObject.GetJSONArray("newUsers");
				LogicJSONArray jsonarray4 = logicJSONObject.GetJSONArray("maxOnlineUsers");
				for (int i = 0; i < 7; i++)
				{
					DashboardManager.TotalUsers[i] = jsonarray.GetJSONNumber(i).GetIntValue();
					DashboardManager.DailyActiveUsers[i] = jsonarray2.GetJSONNumber(i).GetIntValue();
					DashboardManager.NewUsers[i] = jsonarray3.GetJSONNumber(i).GetIntValue();
					DashboardManager.MaxOnlineUsers[i] = jsonarray4.GetJSONNumber(i).GetIntValue();
				}
				DashboardManager.m_tempMaxOnlineUsers = DashboardManager.MaxOnlineUsers[6];
				DashboardManager.LastUpdate = TimeUtil.GetDateTimeFromTimestamp(logicJSONObject.GetJSONNumber("time").GetIntValue());
				while (DateTime.UtcNow.Date > DashboardManager.LastUpdate)
				{
					Array.Copy(DashboardManager.TotalUsers, 1, DashboardManager.TotalUsers, 0, 6);
					Array.Copy(DashboardManager.DailyActiveUsers, 1, DashboardManager.DailyActiveUsers, 0, 6);
					Array.Copy(DashboardManager.NewUsers, 1, DashboardManager.NewUsers, 0, 6);
					Array.Copy(DashboardManager.MaxOnlineUsers, 1, DashboardManager.MaxOnlineUsers, 0, 6);
					DashboardManager.LastUpdate = DashboardManager.LastUpdate.AddDays(1.0);
				}
				return;
			}
			DashboardManager.LastUpdate = DateTime.UtcNow;
		}

		// Token: 0x060000AA RID: 170 RVA: 0x0000259A File Offset: 0x0000079A
		public static void OnOnlineUsersChanged(int count)
		{
			if (count > DashboardManager.m_tempMaxOnlineUsers)
			{
				DashboardManager.m_tempMaxOnlineUsers = count;
			}
		}

		// Token: 0x060000AB RID: 171 RVA: 0x000033C8 File Offset: 0x000015C8
		private static void Save()
		{
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			LogicJSONArray logicJSONArray = new LogicJSONArray(7);
			LogicJSONArray logicJSONArray2 = new LogicJSONArray(7);
			LogicJSONArray logicJSONArray3 = new LogicJSONArray(7);
			LogicJSONArray logicJSONArray4 = new LogicJSONArray(7);
			for (int i = 0; i < 7; i++)
			{
				logicJSONArray.Add(new LogicJSONNumber(DashboardManager.TotalUsers[i]));
				logicJSONArray2.Add(new LogicJSONNumber(DashboardManager.DailyActiveUsers[i]));
				logicJSONArray3.Add(new LogicJSONNumber(DashboardManager.NewUsers[i]));
				logicJSONArray4.Add(new LogicJSONNumber(DashboardManager.MaxOnlineUsers[i]));
			}
			logicJSONObject.Put("totalUsers", logicJSONArray);
			logicJSONObject.Put("dailyActiveUsers", logicJSONArray2);
			logicJSONObject.Put("newUsers", logicJSONArray3);
			logicJSONObject.Put("maxOnlineUsers", logicJSONArray4);
			logicJSONObject.Put("time", new LogicJSONNumber(TimeUtil.GetTimestamp(DashboardManager.LastUpdate)));
			ServerAdmin.AdminDatabase.Set("dashboard", LogicJSONParser.CreateJSONString(logicJSONObject, 20));
		}

		// Token: 0x060000AC RID: 172 RVA: 0x000034B8 File Offset: 0x000016B8
		private static void Update()
		{
			for (;;)
			{
				DateTime utcNow = DateTime.UtcNow;
				if (utcNow.Date > DashboardManager.LastUpdate.Date)
				{
					Array.Copy(DashboardManager.TotalUsers, 1, DashboardManager.TotalUsers, 0, 6);
					Array.Copy(DashboardManager.DailyActiveUsers, 1, DashboardManager.DailyActiveUsers, 0, 6);
					Array.Copy(DashboardManager.NewUsers, 1, DashboardManager.NewUsers, 0, 6);
					Array.Copy(DashboardManager.MaxOnlineUsers, 1, DashboardManager.MaxOnlineUsers, 0, 6);
					DashboardManager.m_tempMaxOnlineUsers = ServerManager.OnlineUsers;
				}
				DashboardManager.LastUpdate = utcNow;
				int timestamp = TimeUtil.GetTimestamp(utcNow.Date);
				int num = timestamp + 86400;
				IQueryResult<JObject> result = ServerAdmin.AccountDatabase.ExecuteCommand<JObject>("SELECT COUNT(*) FROM `%BUCKET%` WHERE meta().id LIKE \"%KEY_PREFIX%%\"").Result;
				IQueryResult<JObject> result2 = ServerAdmin.AccountDatabase.ExecuteCommand<JObject>(string.Concat(new object[]
				{
					"SELECT COUNT(*) FROM `%BUCKET%` WHERE meta().id LIKE \"%KEY_PREFIX%%\" AND lastSessionTime BETWEEN ",
					timestamp,
					" AND ",
					num
				})).Result;
				IQueryResult<JObject> result3 = ServerAdmin.AccountDatabase.ExecuteCommand<JObject>("SELECT COUNT(*) FROM `%BUCKET%` WHERE meta().id LIKE \"%KEY_PREFIX%%\" AND createTime >= " + timestamp).Result;
				IViewResult<JValue> result4 = ServerAdmin.AccountDatabase.ExecuteCommand<JValue>(new ViewQuery().From("players", "count_by_country").Group(true)).Result;
				if (result.Success)
				{
					DashboardManager.TotalUsers[6] = (int)result.Rows[0]["$1"];
				}
				if (result2.Success)
				{
					DashboardManager.DailyActiveUsers[6] = (int)result2.Rows[0]["$1"];
				}
				if (result3.Success)
				{
					DashboardManager.NewUsers[6] = (int)result3.Rows[0]["$1"];
				}
				if (result4.Success)
				{
					LogicArrayList<string> logicArrayList = new LogicArrayList<string>();
					LogicArrayList<int> logicArrayList2 = new LogicArrayList<int>();
					Dictionary<string, int> dictionary = new Dictionary<string, int>();
					using (IEnumerator<ViewRow<JValue>> enumerator = result4.Rows.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							ViewRow<JValue> viewRow = enumerator.Current;
							LogicArrayList<string> logicArrayList3 = logicArrayList;
							if (DashboardManager.<>o__31.<>p__0 == null)
							{
								DashboardManager.<>o__31.<>p__0 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(string), typeof(DashboardManager)));
							}
							logicArrayList3.Add(DashboardManager.<>o__31.<>p__0.Target(DashboardManager.<>o__31.<>p__0, viewRow.Key));
							logicArrayList2.Add((int)viewRow.Value);
						}
						goto IL_3BF;
					}
					goto IL_217;
					IL_295:
					int num2;
					int num3;
					if (num2 >= num3 - 1)
					{
						for (int i = 0; i < num3; i++)
						{
							if (i >= 5)
							{
								if (i == 5)
								{
									dictionary.Add("Others", 0);
								}
								Dictionary<string, int> dictionary2 = dictionary;
								dictionary2["Others"] = dictionary2["Others"] + logicArrayList2[i];
							}
							else
							{
								dictionary.Add(logicArrayList[i], logicArrayList2[i]);
							}
						}
						DashboardManager.UsersByCountry = dictionary;
						goto IL_310;
					}
					goto IL_217;
					IL_3BF:
					num3 = logicArrayList.Size();
					num2 = 0;
					goto IL_295;
					IL_217:
					for (int j = num2 + 1; j < num3; j++)
					{
						if (logicArrayList2[num2] < logicArrayList2[j])
						{
							int value = logicArrayList2[num2];
							logicArrayList2[num2] = logicArrayList2[j];
							logicArrayList2[j] = value;
							string value2 = logicArrayList[num2];
							logicArrayList[num2] = logicArrayList[j];
							logicArrayList[j] = value2;
						}
					}
					num2++;
					goto IL_295;
				}
				IL_310:
				DashboardManager.MaxOnlineUsers[6] = DashboardManager.m_tempMaxOnlineUsers;
				DashboardManager.Save();
				Thread.Sleep(LogicMath.Min((int)utcNow.Date.AddDays(1.0).Subtract(utcNow).TotalMilliseconds + 1000, 30000));
			}
		}

		// Token: 0x04000039 RID: 57
		private static int m_tempMaxOnlineUsers;

		// Token: 0x0400003A RID: 58
		private static Thread m_thread;
	}
}
