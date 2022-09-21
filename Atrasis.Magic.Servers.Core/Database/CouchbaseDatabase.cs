using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Atrasis.Magic.Servers.Core.Settings;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;
using Couchbase;
using Couchbase.Configuration.Client;
using Couchbase.Core;
using Couchbase.IO;
using Couchbase.N1QL;
using Couchbase.Views;
using Newtonsoft.Json.Linq;

namespace Atrasis.Magic.Servers.Core.Database
{
	// Token: 0x020000EF RID: 239
	public class CouchbaseDatabase
	{
		// Token: 0x060006F4 RID: 1780 RVA: 0x00015FB4 File Offset: 0x000141B4
		public CouchbaseDatabase(string type, string keyPrefix)
		{
			EnvironmentSettings.CouchbaseServerEntry couchbaseServerEntry;
			EnvironmentSettings.CouchbaseBucketEntry couchbaseBucketEntry;
			if (EnvironmentSettings.Couchbase.TryGetBucketData(type, out couchbaseServerEntry, out couchbaseBucketEntry))
			{
				this.icluster_0 = new Cluster(new ClientConfiguration
				{
					Servers = new List<Uri>(couchbaseServerEntry.Hosts)
				});
				this.icluster_0.Authenticate(couchbaseServerEntry.Username, couchbaseServerEntry.Password);
				this.ibucket_0 = this.icluster_0.OpenBucket(couchbaseBucketEntry.BucketName);
				this.string_1 = couchbaseBucketEntry.BucketName;
				this.string_2 = keyPrefix + "-";
				return;
			}
			Logging.Error("CouchbaseDatabase::ctor: no database available for type " + type);
		}

		// Token: 0x060006F5 RID: 1781 RVA: 0x00008C7F File Offset: 0x00006E7F
		public void CreateIndex(string indexName, params string[] args)
		{
			this.ExecuteCommand<object>(string.Format("CREATE INDEX {0} ON `%BUCKET%` ({1})", indexName, string.Join(",", args))).Wait();
		}

		// Token: 0x060006F6 RID: 1782 RVA: 0x00008CA2 File Offset: 0x00006EA2
		public void CreateIndexWithFilter(string indexName, string filter, params string[] args)
		{
			this.ExecuteCommand<object>(string.Format("CREATE INDEX {0} ON `%BUCKET%` ({1}) WHERE {2}", indexName, string.Join(",", args), filter)).Wait();
		}

		// Token: 0x060006F7 RID: 1783 RVA: 0x00016058 File Offset: 0x00014258
		public long GetDocumentHigherID()
		{
			this.CreateIndexWithFilter("higherId", "meta().id LIKE '%KEY_PREFIX%%'", new string[]
			{
				"meta().id"
			});
			IQueryResult<JObject> result = this.ExecuteCommand<JObject>("SELECT MAX(BITOR(BITSHIFT(id_hi, 32), id_lo)) FROM `%BUCKET%` WHERE meta().id LIKE '%KEY_PREFIX%%'").Result;
			if (!result.Success)
			{
				throw new Exception("Query failed!");
			}
			JToken jtoken = result.Rows[0]["$1"];
			if (jtoken.Type == JTokenType.Integer)
			{
				return (long)jtoken;
			}
			return 0L;
		}

		// Token: 0x060006F8 RID: 1784 RVA: 0x000160D8 File Offset: 0x000142D8
		public int[] GetCounterHigherIDs()
		{
			int higherIdCounterSize = EnvironmentSettings.HigherIdCounterSize;
			int[] array = new int[higherIdCounterSize];
			for (int i = 0; i < higherIdCounterSize; i++)
			{
				IOperationResult<string> operationResult = this.ibucket_0.Get<string>("counter_" + i);
				if (operationResult.Status != ResponseStatus.Success && operationResult.Status != ResponseStatus.KeyNotFound)
				{
					throw new Exception("Db in loading state!");
				}
				if (operationResult.Value != null)
				{
					array[i] = (int)ulong.Parse(operationResult.Value);
				}
			}
			return array;
		}

		// Token: 0x060006F9 RID: 1785 RVA: 0x00008CC6 File Offset: 0x00006EC6
		public void Destruct()
		{
			this.ibucket_0.Dispose();
			this.icluster_0.Dispose();
		}

		// Token: 0x060006FA RID: 1786 RVA: 0x00008CDE File Offset: 0x00006EDE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string BuildKeyName(long id)
		{
			return this.string_2 + id;
		}

		// Token: 0x060006FB RID: 1787 RVA: 0x00008CF1 File Offset: 0x00006EF1
		public Task<IQueryResult<T>> ExecuteCommand<T>(string query)
		{
			return this.ibucket_0.QueryAsync<T>(query.Replace("%BUCKET%", this.string_1).Replace("%KEY_PREFIX%", this.string_2));
		}

		// Token: 0x060006FC RID: 1788 RVA: 0x00008D1F File Offset: 0x00006F1F
		public Task<IViewResult<T>> ExecuteCommand<T>(IViewQuery query)
		{
			return this.ibucket_0.QueryAsync<T>(query);
		}

		// Token: 0x060006FD RID: 1789 RVA: 0x00008D2D File Offset: 0x00006F2D
		public Task<IOperationResult<string>> Get(long key)
		{
			return this.ibucket_0.GetAsync<string>(this.BuildKeyName(key));
		}

		// Token: 0x060006FE RID: 1790 RVA: 0x00008D41 File Offset: 0x00006F41
		public Task<IDocumentResult<string>[]> Get(IEnumerable<string> ids)
		{
			return this.ibucket_0.GetDocumentsAsync<string>(ids);
		}

		// Token: 0x060006FF RID: 1791 RVA: 0x00016154 File Offset: 0x00014354
		public Task<IDocumentResult<string>[]> Get(LogicArrayList<LogicLong> ids)
		{
			string[] array = new string[ids.Size()];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = this.BuildKeyName(ids[i]);
			}
			return this.ibucket_0.GetDocumentsAsync<string>(array);
		}

		// Token: 0x06000700 RID: 1792 RVA: 0x00008D4F File Offset: 0x00006F4F
		public Task<IOperationResult<string>> Insert(long key, string json)
		{
			return this.ibucket_0.InsertAsync<string>(this.BuildKeyName(key), json);
		}

		// Token: 0x06000701 RID: 1793 RVA: 0x00008D64 File Offset: 0x00006F64
		public Task<IOperationResult<string>> InsertOrUpdate(long key, string json)
		{
			return this.ibucket_0.UpsertAsync<string>(this.BuildKeyName(key), json);
		}

		// Token: 0x06000702 RID: 1794 RVA: 0x00008D79 File Offset: 0x00006F79
		public Task<IOperationResult<string>> Update(long key, string json)
		{
			return this.ibucket_0.ReplaceAsync<string>(this.BuildKeyName(key), json);
		}

		// Token: 0x06000703 RID: 1795 RVA: 0x00008D8E File Offset: 0x00006F8E
		public Task<IOperationResult<string>> Update(long key, string json, ulong cas)
		{
			return this.ibucket_0.ReplaceAsync<string>(this.BuildKeyName(key), json, cas);
		}

		// Token: 0x06000704 RID: 1796 RVA: 0x00008DA4 File Offset: 0x00006FA4
		public Task<IOperationResult> Remove(long key)
		{
			return this.ibucket_0.RemoveAsync(this.BuildKeyName(key));
		}

		// Token: 0x06000705 RID: 1797 RVA: 0x0001619C File Offset: 0x0001439C
		public Task<IOperationResult<ulong>> IncrementSeed()
		{
			int num = this.int_0;
			this.int_0 = num + 1;
			int num2 = num % EnvironmentSettings.HigherIdCounterSize;
			return this.ibucket_0.IncrementAsync("counter_" + num2, 1UL, (ulong)((long)num2 << 32 | 1L));
		}

		// Token: 0x040003CC RID: 972
		private const string string_0 = "SELECT MAX(BITOR(BITSHIFT(id_hi, 32), id_lo)) FROM `%BUCKET%` WHERE meta().id LIKE '%KEY_PREFIX%%'";

		// Token: 0x040003CD RID: 973
		private readonly string string_1;

		// Token: 0x040003CE RID: 974
		private readonly string string_2;

		// Token: 0x040003CF RID: 975
		private readonly ICluster icluster_0;

		// Token: 0x040003D0 RID: 976
		private readonly IBucket ibucket_0;

		// Token: 0x040003D1 RID: 977
		private int int_0;
	}
}
