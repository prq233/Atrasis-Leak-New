using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace Atrasis.Magic.Servers.Admin.Logic
{
	// Token: 0x02000014 RID: 20
	public static class AuthManager
	{
		// Token: 0x06000077 RID: 119 RVA: 0x00003094 File Offset: 0x00001294
		public static async Task<string> OpenSession(string user, string password)
		{
			TaskAwaiter<UserEntry> taskAwaiter = AuthManager.GetUser(user, password).GetAwaiter();
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				TaskAwaiter<UserEntry> taskAwaiter2;
				taskAwaiter = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter<UserEntry>);
			}
			UserEntry result = taskAwaiter.GetResult();
			UserEntry userEntry = result;
			string result2;
			if (userEntry == null)
			{
				result2 = null;
			}
			else
			{
				SessionEntry sessionEntry = new SessionEntry(userEntry.User, AuthManager.GenerateToken());
				TaskAwaiter<bool> taskAwaiter3 = AuthManager.SaveSession(sessionEntry).GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					await taskAwaiter3;
					TaskAwaiter<bool> taskAwaiter4;
					taskAwaiter3 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter<bool>);
				}
				if (!taskAwaiter3.GetResult())
				{
					result2 = null;
				}
				else
				{
					result2 = sessionEntry.Token;
				}
			}
			return result2;
		}

		// Token: 0x06000078 RID: 120 RVA: 0x000023E8 File Offset: 0x000005E8
		private static Task<bool> SaveSession(SessionEntry sessionEntry)
		{
			return ServerAdmin.AdminDatabase.Set("session-" + sessionEntry.Token, SessionEntry.Save(sessionEntry), TimeSpan.FromHours(1.0));
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00002418 File Offset: 0x00000618
		public static Task<bool> CloseSession(string token)
		{
			return ServerAdmin.AdminDatabase.Delete("session-" + token);
		}

		// Token: 0x0600007A RID: 122 RVA: 0x000030E4 File Offset: 0x000012E4
		public static async Task<SessionEntry> GetSession(string session)
		{
			RedisValue redisValue = await ServerAdmin.AdminDatabase.Get("session-" + session);
			RedisValue value = redisValue;
			SessionEntry result;
			if (value.IsNullOrEmpty)
			{
				result = null;
			}
			else
			{
				result = SessionEntry.Load(value);
			}
			return result;
		}

		// Token: 0x0600007B RID: 123 RVA: 0x0000312C File Offset: 0x0000132C
		public static async Task<UserEntry> GetUser(string user)
		{
			RedisValue redisValue = await ServerAdmin.AdminDatabase.Get("user-" + user);
			RedisValue value = redisValue;
			UserEntry result;
			if (value.IsNullOrEmpty)
			{
				result = null;
			}
			else
			{
				result = UserEntry.Load(value);
			}
			return result;
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00003174 File Offset: 0x00001374
		public static async Task<UserEntry> GetUser(string user, string password)
		{
			UserEntry userEntry = await AuthManager.GetUser(user);
			UserEntry userEntry2 = userEntry;
			UserEntry result;
			if (userEntry2 == null)
			{
				result = null;
			}
			else if (!string.Equals(userEntry2.Password, password))
			{
				result = null;
			}
			else
			{
				result = userEntry2;
			}
			return result;
		}

		// Token: 0x0600007D RID: 125 RVA: 0x000031C4 File Offset: 0x000013C4
		private static string GenerateToken()
		{
			return Guid.NewGuid().ToString("N");
		}
	}
}
