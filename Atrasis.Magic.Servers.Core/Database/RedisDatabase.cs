using System;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Atrasis.Magic.Servers.Core.Settings;
using StackExchange.Redis;

namespace Atrasis.Magic.Servers.Core.Database
{
	// Token: 0x020000F0 RID: 240
	public class RedisDatabase
	{
		// Token: 0x06000706 RID: 1798 RVA: 0x000161F4 File Offset: 0x000143F4
		public RedisDatabase(string name, int idx = -1)
		{
			EnvironmentSettings.RedisSettings.RedisDatabaseEntry redisDatabaseEntry;
			if (!EnvironmentSettings.Redis.TryGetDatabase(name, out redisDatabaseEntry))
			{
				throw new Exception("Unknown redis database: " + name);
			}
			this.connectionMultiplexer_0 = ConnectionMultiplexer.Connect(redisDatabaseEntry.ConnectionString, null);
			this.idatabase_0 = this.connectionMultiplexer_0.GetDatabase(idx, null);
			EndPoint[] endPoints = this.connectionMultiplexer_0.GetEndPoints(false);
			LuaScript luaScript = LuaScript.Prepare("\r\n                local value = redis.call('GET', KEYS[1])\r\n                if value == ARGV[1] then\r\n                    return redis.call('DEL', KEYS[1]);\r\n                end\r\n                return false;");
			for (int i = 0; i < endPoints.Length; i++)
			{
				byte[] hash = luaScript.Load(this.connectionMultiplexer_0.GetServer(endPoints[i], null), CommandFlags.None).Hash;
				if (hash.Length != 20)
				{
					throw new Exception("RedisDatabase.ctor: hash length != 20");
				}
				if (this.byte_0 != null)
				{
					for (int j = 0; j < 20; j++)
					{
						if (this.byte_0[j] != hash[j])
						{
							throw new Exception("RedisDatabase.ctor: hash mismatch");
						}
					}
				}
				else
				{
					this.byte_0 = hash;
				}
			}
		}

		// Token: 0x06000707 RID: 1799 RVA: 0x00008DB8 File Offset: 0x00006FB8
		public Task<bool> Exists(long id)
		{
			return this.idatabase_0.KeyExistsAsync(id.ToString(), CommandFlags.None);
		}

		// Token: 0x06000708 RID: 1800 RVA: 0x00008DD2 File Offset: 0x00006FD2
		public Task<bool> Exists(string id)
		{
			return this.idatabase_0.KeyExistsAsync(id, CommandFlags.None);
		}

		// Token: 0x06000709 RID: 1801 RVA: 0x00008DE6 File Offset: 0x00006FE6
		public Task<bool> Delete(long id)
		{
			return this.idatabase_0.KeyDeleteAsync(id.ToString(), CommandFlags.None);
		}

		// Token: 0x0600070A RID: 1802 RVA: 0x00008E00 File Offset: 0x00007000
		public Task<bool> Delete(string id)
		{
			return this.idatabase_0.KeyDeleteAsync(id, CommandFlags.None);
		}

		// Token: 0x0600070B RID: 1803 RVA: 0x000162F0 File Offset: 0x000144F0
		public Task<bool> Set(long id, string value)
		{
			return this.idatabase_0.StringSetAsync(id.ToString(), value, null, When.Always, CommandFlags.None);
		}

		// Token: 0x0600070C RID: 1804 RVA: 0x00016328 File Offset: 0x00014528
		public Task<bool> Set(string id, string value)
		{
			return this.idatabase_0.StringSetAsync(id, value, null, When.Always, CommandFlags.None);
		}

		// Token: 0x0600070D RID: 1805 RVA: 0x00008E14 File Offset: 0x00007014
		public Task<bool> Set(string id, string value, TimeSpan expireDelay)
		{
			return this.idatabase_0.StringSetAsync(id, value, new TimeSpan?(expireDelay), When.Always, CommandFlags.None);
		}

		// Token: 0x0600070E RID: 1806 RVA: 0x00008E35 File Offset: 0x00007035
		public Task<RedisValue> GetSet(long id, string value)
		{
			return this.idatabase_0.StringGetSetAsync(id.ToString(), value, CommandFlags.None);
		}

		// Token: 0x0600070F RID: 1807 RVA: 0x00008E55 File Offset: 0x00007055
		public Task<RedisValue> Get(long id)
		{
			return this.idatabase_0.StringGetAsync(id.ToString(), CommandFlags.None);
		}

		// Token: 0x06000710 RID: 1808 RVA: 0x00008E6F File Offset: 0x0000706F
		public Task<RedisValue> Get(string id)
		{
			return this.idatabase_0.StringGetAsync(id, CommandFlags.None);
		}

		// Token: 0x06000711 RID: 1809 RVA: 0x00008E83 File Offset: 0x00007083
		public Task<RedisValue[]> Get(RedisKey[] ids)
		{
			return this.idatabase_0.StringGetAsync(ids, CommandFlags.None);
		}

		// Token: 0x06000712 RID: 1810 RVA: 0x00016358 File Offset: 0x00014558
		public void DeleteIfEquals(long id, string value)
		{
			RedisDatabase.Struct1 @struct;
			@struct.redisDatabase_0 = this;
			@struct.long_0 = id;
			@struct.string_0 = value;
			@struct.asyncVoidMethodBuilder_0 = AsyncVoidMethodBuilder.Create();
			@struct.int_0 = -1;
			AsyncVoidMethodBuilder asyncVoidMethodBuilder_ = @struct.asyncVoidMethodBuilder_0;
			asyncVoidMethodBuilder_.Start<RedisDatabase.Struct1>(ref @struct);
		}

		// Token: 0x040003D2 RID: 978
		private readonly IDatabase idatabase_0;

		// Token: 0x040003D3 RID: 979
		private readonly ConnectionMultiplexer connectionMultiplexer_0;

		// Token: 0x040003D4 RID: 980
		private readonly byte[] byte_0;
	}
}
