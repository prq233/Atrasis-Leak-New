using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Atrasis.Magic.Logic.Message.Scoring;
using Atrasis.Magic.Logic.Util;
using Atrasis.Magic.Servers.Admin.Models;
using Atrasis.Magic.Servers.Core.Database.Document;
using Atrasis.Magic.Servers.Core.Network;
using Atrasis.Magic.Servers.Core.Network.Message.Request;
using Atrasis.Magic.Servers.Core.Network.Request;
using Atrasis.Magic.Servers.Core.Settings;
using Atrasis.Magic.Servers.Core.Util;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;
using Couchbase;
using Couchbase.N1QL;
using Newtonsoft.Json.Linq;

namespace Atrasis.Magic.Servers.Admin.Logic
{
	// Token: 0x02000022 RID: 34
	public static class UserManager
	{
		// Token: 0x1700005C RID: 92
		// (get) Token: 0x060000E7 RID: 231 RVA: 0x000028E5 File Offset: 0x00000AE5
		// (set) Token: 0x060000E8 RID: 232 RVA: 0x000028EC File Offset: 0x00000AEC
		public static LogicArrayList<AvatarRankingEntry> MainLeaderboard { get; private set; }

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x060000E9 RID: 233 RVA: 0x000028F4 File Offset: 0x00000AF4
		// (set) Token: 0x060000EA RID: 234 RVA: 0x000028FB File Offset: 0x00000AFB
		public static LogicArrayList<AvatarDuelRankingEntry> SecondaryLeaderboard { get; private set; }

		// Token: 0x060000EB RID: 235 RVA: 0x00002903 File Offset: 0x00000B03
		public static void Init()
		{
			UserManager.m_presetRandom = new LogicRandom(TimeUtil.GetTimestamp());
			UserManager.MainLeaderboard = new LogicArrayList<AvatarRankingEntry>();
			UserManager.SecondaryLeaderboard = new LogicArrayList<AvatarDuelRankingEntry>();
			UserManager.m_thread = new Thread(new ThreadStart(UserManager.Update));
		}

		// Token: 0x060000EC RID: 236 RVA: 0x0000293E File Offset: 0x00000B3E
		public static void Start()
		{
			UserManager.m_thread.Start();
		}

		// Token: 0x060000ED RID: 237 RVA: 0x00003C88 File Offset: 0x00001E88
		private static void Update()
		{
			for (;;)
			{
				ServerRequestArgs serverRequestArgs = ServerRequestManager.Create(new LeaderboardRequestMessage
				{
					Count = 10
				}, ServerManager.GetNextSocket(28), 30);
				ServerRequestArgs.CompleteHandler onComplete;
				if ((onComplete = UserManager.<>c.<>9__12_0) == null)
				{
					onComplete = (UserManager.<>c.<>9__12_0 = delegate(ServerRequestArgs args)
					{
						if (args.ErrorCode == ServerRequestError.Success && args.ResponseMessage.Success)
						{
							LeaderboardResponseMessage leaderboardResponseMessage = (LeaderboardResponseMessage)args.ResponseMessage;
							UserManager.MainLeaderboard = leaderboardResponseMessage.MainLeaderboard;
							UserManager.SecondaryLeaderboard = leaderboardResponseMessage.SecondaryLeaderboard;
						}
					});
				}
				serverRequestArgs.OnComplete = onComplete;
				Thread.Sleep(60000);
			}
		}

		// Token: 0x060000EE RID: 238 RVA: 0x00003CE4 File Offset: 0x00001EE4
		public static async Task<AccountDocument> GetAccount(long id)
		{
			IOperationResult<string> operationResult = await ServerAdmin.AccountDatabase.Get(id);
			IOperationResult<string> operationResult2 = operationResult;
			AccountDocument result;
			if (operationResult2.Success)
			{
				result = CouchbaseDocument.Load<AccountDocument>(operationResult2.Value);
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x060000EF RID: 239 RVA: 0x00003D2C File Offset: 0x00001F2C
		public static async Task<GameDocument> GetAvatar(long id)
		{
			IOperationResult<string> operationResult = await ServerAdmin.GameDatabase.Get(id);
			IOperationResult<string> operationResult2 = operationResult;
			GameDocument result;
			if (operationResult2.Success)
			{
				result = CouchbaseDocument.Load<GameDocument>(operationResult2.Value);
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x0000294A File Offset: 0x00000B4A
		public static string GetPresetLevel()
		{
			return ResourceSettings.Environment.PresetLevelJSON[UserManager.m_presetRandom.Rand(ResourceSettings.Environment.PresetLevelJSON.Length)];
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00002963 File Offset: 0x00000B63
		public static Task<IOperationResult<string>> SaveAccount(AccountDocument document)
		{
			return ServerAdmin.AccountDatabase.Update(document.Id, CouchbaseDocument.Save(document));
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x00003D74 File Offset: 0x00001F74
		public static async Task<LogicArrayList<GameUser>> Search(string name, int expLevel, int score, int duelScore, string allianceName, AccountState? status)
		{
			StringBuilder stringBuilder = new StringBuilder("SELECT id_hi,id_lo,name,xp_level,score,duel_score,alliance_name FROM `%BUCKET%` WHERE meta().id LIKE '%KEY_PREFIX%%'");
			if (!string.IsNullOrEmpty(name))
			{
				if (name.Length >= 16)
				{
					name = name.Substring(0, 15);
				}
				bool flag = false;
				if (name.StartsWith("#"))
				{
					LogicLong logicLong = HashTagCodeGenerator.m_instance.ToId(name.Trim().ToUpperInvariant());
					if (logicLong != null)
					{
						flag = true;
						stringBuilder.Append(" AND id_hi == ");
						stringBuilder.Append(logicLong.GetHigherInt());
						stringBuilder.Append(" AND id_lo == ");
						stringBuilder.Append(logicLong.GetLowerInt());
					}
				}
				if (!flag)
				{
					stringBuilder.Append(" AND LOWER(name) LIKE '%");
					stringBuilder.Append(name.ToLowerInvariant());
					stringBuilder.Append("%'");
				}
			}
			else
			{
				stringBuilder.Append(" AND name_set");
			}
			if (expLevel != 0)
			{
				stringBuilder.Append(" AND xp_level == " + expLevel);
			}
			if (score != 0)
			{
				stringBuilder.Append(" AND score == " + score);
			}
			if (duelScore != 0)
			{
				stringBuilder.Append(" AND duel_score == " + duelScore);
			}
			if (!string.IsNullOrEmpty(allianceName))
			{
				stringBuilder.Append(" AND LOWER(alliance_name) LIKE '%" + allianceName.ToLowerInvariant() + "%'");
			}
			stringBuilder.Append(" LIMIT 10");
			TaskAwaiter<IQueryResult<JObject>> taskAwaiter = ServerAdmin.GameDatabase.ExecuteCommand<JObject>(stringBuilder.ToString()).GetAwaiter();
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				TaskAwaiter<IQueryResult<JObject>> taskAwaiter2;
				taskAwaiter = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter<IQueryResult<JObject>>);
			}
			IQueryResult<JObject> result3 = taskAwaiter.GetResult();
			IQueryResult<JObject> result = result3;
			LogicArrayList<GameUser> result5;
			if (result.Success)
			{
				LogicArrayList<LogicLong> ids = new LogicArrayList<LogicLong>();
				LogicArrayList<AccountDocument> accounts = new LogicArrayList<AccountDocument>();
				for (int j = 0; j < result.Rows.Count; j++)
				{
					JObject jobject = result.Rows[j];
					ids.Add(new LogicLong((int)jobject["id_hi"], (int)jobject["id_lo"]));
				}
				List<Task<IOperationResult<string>>> result2 = new List<Task<IOperationResult<string>>>();
				for (int k = 0; k < ids.Size(); k++)
				{
					result2.Add(ServerAdmin.AccountDatabase.Get(ids[k]));
				}
				int i = 0;
				while (i < ids.Size())
				{
					TaskAwaiter<IOperationResult<string>> taskAwaiter3 = result2[i].GetAwaiter();
					if (!taskAwaiter3.IsCompleted)
					{
						await taskAwaiter3;
						TaskAwaiter<IOperationResult<string>> taskAwaiter4;
						taskAwaiter3 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter<IOperationResult<string>>);
					}
					IOperationResult<string> result4 = taskAwaiter3.GetResult();
					if (!result4.Success)
					{
						goto IL_390;
					}
					AccountDocument accountDocument = CouchbaseDocument.Load<AccountDocument>(result4.Value);
					if (status != null && status.Value != accountDocument.State)
					{
						goto IL_390;
					}
					accounts.Add(accountDocument);
					IL_3C5:
					i++;
					continue;
					IL_390:
					ids.Remove(i);
					result.Rows.RemoveAt(i--);
					goto IL_3C5;
				}
				LogicArrayList<GameUser> logicArrayList = new LogicArrayList<GameUser>(result.Rows.Count);
				for (int l = 0; l < result.Rows.Count; l++)
				{
					JObject jobject2 = result.Rows[l];
					LogicLong logicLong2 = new LogicLong((int)jobject2["id_hi"], (int)jobject2["id_lo"]);
					logicArrayList.Add(new GameUser
					{
						Id = logicLong2,
						Tag = HashTagCodeGenerator.m_instance.ToCode(logicLong2),
						Name = (string)jobject2["name"],
						ExpLevel = (int)jobject2["xp_level"],
						Score = (int)jobject2["score"],
						DuelScore = (int)jobject2["duel_score"],
						Alliance = (string)jobject2["alliance_name"],
						Status = accounts[l].State
					});
				}
				result5 = logicArrayList;
			}
			else
			{
				result5 = null;
			}
			return result5;
		}

		// Token: 0x04000069 RID: 105
		private static LogicRandom m_presetRandom;

		// Token: 0x0400006A RID: 106
		private static Thread m_thread;
	}
}
