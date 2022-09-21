using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Servers.Core.Settings
{
	// Token: 0x02000011 RID: 17
	public static class EnvironmentSettings
	{
		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000044 RID: 68 RVA: 0x0000487A File Offset: 0x00002A7A
		// (set) Token: 0x06000045 RID: 69 RVA: 0x00004881 File Offset: 0x00002A81
		public static EnvironmentSettings.ServerConnectionEntry[][] Servers { get; private set; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000046 RID: 70 RVA: 0x00004889 File Offset: 0x00002A89
		// (set) Token: 0x06000047 RID: 71 RVA: 0x00004890 File Offset: 0x00002A90
		public static EnvironmentSettings.CouchbaseSettings Couchbase { get; private set; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000048 RID: 72 RVA: 0x00004898 File Offset: 0x00002A98
		// (set) Token: 0x06000049 RID: 73 RVA: 0x0000489F File Offset: 0x00002A9F
		public static EnvironmentSettings.RedisSettings Redis { get; private set; }

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600004A RID: 74 RVA: 0x000048A7 File Offset: 0x00002AA7
		// (set) Token: 0x0600004B RID: 75 RVA: 0x000048AE File Offset: 0x00002AAE
		public static EnvironmentSettings.ServerSettings Settings { get; private set; }

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600004C RID: 76 RVA: 0x000048B6 File Offset: 0x00002AB6
		// (set) Token: 0x0600004D RID: 77 RVA: 0x000048BD File Offset: 0x00002ABD
		public static string Environment { get; private set; }

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600004E RID: 78 RVA: 0x000048C5 File Offset: 0x00002AC5
		// (set) Token: 0x0600004F RID: 79 RVA: 0x000048CC File Offset: 0x00002ACC
		public static int HigherIdCounterSize { get; private set; }

		// Token: 0x06000050 RID: 80 RVA: 0x0000A024 File Offset: 0x00008224
		internal static void smethod_0()
		{
			EnvironmentSettings.Servers = new EnvironmentSettings.ServerConnectionEntry[30][];
			EnvironmentSettings.Couchbase = default(EnvironmentSettings.CouchbaseSettings);
			for (int i = 0; i < 30; i++)
			{
				EnvironmentSettings.Servers[i] = new EnvironmentSettings.ServerConnectionEntry[0];
			}
			EnvironmentSettings.smethod_1(ServerHttpClient.DownloadJSON("environment.json"));
		}

		// Token: 0x06000051 RID: 81 RVA: 0x000048D4 File Offset: 0x00002AD4
		public static bool IsStageServer()
		{
			return EnvironmentSettings.Environment.StartsWith("stage");
		}

		// Token: 0x06000052 RID: 82 RVA: 0x000048E5 File Offset: 0x00002AE5
		public static bool IsIntegrationServer()
		{
			return EnvironmentSettings.Environment.StartsWith("integration");
		}

		// Token: 0x06000053 RID: 83 RVA: 0x000048F6 File Offset: 0x00002AF6
		public static bool IsProductionServer()
		{
			return EnvironmentSettings.Environment.Equals("prod");
		}

		// Token: 0x06000054 RID: 84 RVA: 0x0000A074 File Offset: 0x00008274
		private static void smethod_1(LogicJSONObject logicJSONObject_0)
		{
			EnvironmentSettings.Environment = logicJSONObject_0.GetJSONString("environment").GetStringValue();
			LogicJSONObject jsonobject = logicJSONObject_0.GetJSONObject("servers");
			if (jsonobject != null)
			{
				EnvironmentSettings.Settings = new EnvironmentSettings.ServerSettings(jsonobject.GetJSONObject("settings"));
				EnvironmentSettings.smethod_2(jsonobject.GetJSONArray("admin"), 0);
				EnvironmentSettings.smethod_2(jsonobject.GetJSONArray("proxy"), 1);
				EnvironmentSettings.smethod_2(jsonobject.GetJSONArray("account"), 2);
				EnvironmentSettings.smethod_2(jsonobject.GetJSONArray("friend"), 3);
				EnvironmentSettings.smethod_2(jsonobject.GetJSONArray("chat"), 6);
				EnvironmentSettings.smethod_2(jsonobject.GetJSONArray("game"), 9);
				EnvironmentSettings.smethod_2(jsonobject.GetJSONArray("home"), 10);
				EnvironmentSettings.smethod_2(jsonobject.GetJSONArray("stream"), 11);
				EnvironmentSettings.smethod_2(jsonobject.GetJSONArray("league"), 13);
				EnvironmentSettings.smethod_2(jsonobject.GetJSONArray("war"), 25);
				EnvironmentSettings.smethod_2(jsonobject.GetJSONArray("battle"), 27);
				EnvironmentSettings.smethod_2(jsonobject.GetJSONArray("scoring"), 28);
				EnvironmentSettings.smethod_2(jsonobject.GetJSONArray("search"), 29);
			}
			LogicJSONObject jsonobject2 = logicJSONObject_0.GetJSONObject("database");
			if (jsonobject2 != null)
			{
				EnvironmentSettings.HigherIdCounterSize = jsonobject2.GetJSONNumber("higher_id_counter_size").GetIntValue();
				EnvironmentSettings.Couchbase = new EnvironmentSettings.CouchbaseSettings(jsonobject2.GetJSONObject("couchbase"));
				EnvironmentSettings.Redis = new EnvironmentSettings.RedisSettings(jsonobject2.GetJSONObject("redis"));
			}
		}

		// Token: 0x06000055 RID: 85 RVA: 0x0000A1F0 File Offset: 0x000083F0
		private static void smethod_2(LogicJSONArray logicJSONArray_0, int int_1)
		{
			EnvironmentSettings.ServerConnectionEntry[] array;
			if (logicJSONArray_0 != null)
			{
				array = new EnvironmentSettings.ServerConnectionEntry[logicJSONArray_0.Size()];
				for (int i = 0; i < logicJSONArray_0.Size(); i++)
				{
					array[i] = new EnvironmentSettings.ServerConnectionEntry(logicJSONArray_0.GetJSONString(i));
				}
			}
			else
			{
				array = new EnvironmentSettings.ServerConnectionEntry[0];
			}
			EnvironmentSettings.Servers[int_1] = array;
		}

		// Token: 0x06000056 RID: 86 RVA: 0x0000A244 File Offset: 0x00008444
		private static string[] smethod_3(LogicJSONArray logicJSONArray_0)
		{
			string[] array;
			if (logicJSONArray_0 != null)
			{
				array = new string[logicJSONArray_0.Size()];
				for (int i = 0; i < logicJSONArray_0.Size(); i++)
				{
					array[i] = logicJSONArray_0.GetJSONString(i).GetStringValue();
				}
			}
			else
			{
				array = new string[0];
			}
			return array;
		}

		// Token: 0x06000057 RID: 87 RVA: 0x0000A28C File Offset: 0x0000848C
		public static LogicJSONObject Save()
		{
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			logicJSONObject.Put("environment", new LogicJSONString(EnvironmentSettings.Environment));
			LogicJSONObject logicJSONObject2 = new LogicJSONObject();
			logicJSONObject2.Put("settings", EnvironmentSettings.Settings.Save());
			logicJSONObject2.Put("admin", EnvironmentSettings.smethod_4(0));
			logicJSONObject2.Put("proxy", EnvironmentSettings.smethod_4(1));
			logicJSONObject2.Put("account", EnvironmentSettings.smethod_4(2));
			logicJSONObject2.Put("friend", EnvironmentSettings.smethod_4(3));
			logicJSONObject2.Put("chat", EnvironmentSettings.smethod_4(6));
			logicJSONObject2.Put("avatar", EnvironmentSettings.smethod_4(9));
			logicJSONObject2.Put("home", EnvironmentSettings.smethod_4(10));
			logicJSONObject2.Put("stream", EnvironmentSettings.smethod_4(11));
			logicJSONObject2.Put("league", EnvironmentSettings.smethod_4(13));
			logicJSONObject2.Put("war", EnvironmentSettings.smethod_4(25));
			logicJSONObject2.Put("battle", EnvironmentSettings.smethod_4(27));
			logicJSONObject2.Put("scoring", EnvironmentSettings.smethod_4(28));
			logicJSONObject2.Put("search", EnvironmentSettings.smethod_4(29));
			logicJSONObject.Put("servers", logicJSONObject2);
			LogicJSONObject logicJSONObject3 = new LogicJSONObject();
			logicJSONObject3.Put("higher_id_counter_size", new LogicJSONNumber(EnvironmentSettings.HigherIdCounterSize));
			logicJSONObject3.Put("couchbase", EnvironmentSettings.Couchbase.Save());
			logicJSONObject3.Put("redis", EnvironmentSettings.Redis.Save());
			return logicJSONObject;
		}

		// Token: 0x06000058 RID: 88 RVA: 0x0000A40C File Offset: 0x0000860C
		private static LogicJSONArray smethod_4(int int_1)
		{
			LogicJSONArray logicJSONArray = new LogicJSONArray();
			if (EnvironmentSettings.Servers[int_1] != null)
			{
				EnvironmentSettings.ServerConnectionEntry[] array = EnvironmentSettings.Servers[int_1];
				for (int i = 0; i < array.Length; i++)
				{
					logicJSONArray.Add(array[i].Save());
				}
			}
			return logicJSONArray;
		}

		// Token: 0x06000059 RID: 89 RVA: 0x0000A454 File Offset: 0x00008654
		private static LogicJSONArray smethod_5(string[] string_1)
		{
			LogicJSONArray logicJSONArray = new LogicJSONArray();
			if (string_1 != null)
			{
				for (int i = 0; i < string_1.Length; i++)
				{
					logicJSONArray.Add(new LogicJSONString(string_1[i]));
				}
			}
			return logicJSONArray;
		}

		// Token: 0x0400001E RID: 30
		public const int SERVER_TYPE_COUNT = 30;

		// Token: 0x0400001F RID: 31
		[CompilerGenerated]
		private static EnvironmentSettings.ServerConnectionEntry[][] serverConnectionEntry_0;

		// Token: 0x04000020 RID: 32
		[CompilerGenerated]
		private static EnvironmentSettings.CouchbaseSettings couchbaseSettings_0;

		// Token: 0x04000021 RID: 33
		[CompilerGenerated]
		private static EnvironmentSettings.RedisSettings redisSettings_0;

		// Token: 0x04000022 RID: 34
		[CompilerGenerated]
		private static EnvironmentSettings.ServerSettings serverSettings_0;

		// Token: 0x04000023 RID: 35
		[CompilerGenerated]
		private static string string_0;

		// Token: 0x04000024 RID: 36
		[CompilerGenerated]
		private static int int_0;

		// Token: 0x02000012 RID: 18
		public struct RedisSettings
		{
			// Token: 0x17000010 RID: 16
			// (get) Token: 0x0600005A RID: 90 RVA: 0x00004907 File Offset: 0x00002B07
			public LogicArrayList<EnvironmentSettings.RedisSettings.RedisDatabaseEntry> Databases { get; }

			// Token: 0x0600005B RID: 91 RVA: 0x0000A488 File Offset: 0x00008688
			public RedisSettings(LogicJSONObject jsonObject)
			{
				LogicJSONArray jsonarray = jsonObject.GetJSONArray("databases");
				this.Databases = new LogicArrayList<EnvironmentSettings.RedisSettings.RedisDatabaseEntry>(jsonarray.Size());
				for (int i = 0; i < jsonarray.Size(); i++)
				{
					this.Databases.Add(new EnvironmentSettings.RedisSettings.RedisDatabaseEntry(jsonarray.GetJSONObject(i)));
				}
			}

			// Token: 0x0600005C RID: 92 RVA: 0x0000A4DC File Offset: 0x000086DC
			public LogicJSONObject Save()
			{
				LogicJSONObject logicJSONObject = new LogicJSONObject();
				LogicJSONArray logicJSONArray = new LogicJSONArray();
				for (int i = 0; i < this.Databases.Size(); i++)
				{
					logicJSONArray.Add(this.Databases[i].Save());
				}
				logicJSONObject.Put("databases", logicJSONArray);
				return logicJSONObject;
			}

			// Token: 0x0600005D RID: 93 RVA: 0x0000A530 File Offset: 0x00008730
			public bool TryGetDatabase(string name, out EnvironmentSettings.RedisSettings.RedisDatabaseEntry entry)
			{
				for (int i = 0; i < this.Databases.Size(); i++)
				{
					if (this.Databases[i].Name == name)
					{
						entry = this.Databases[i];
						return true;
					}
				}
				entry = null;
				return false;
			}

			// Token: 0x04000025 RID: 37
			[CompilerGenerated]
			private readonly LogicArrayList<EnvironmentSettings.RedisSettings.RedisDatabaseEntry> logicArrayList_0;

			// Token: 0x02000013 RID: 19
			public class RedisDatabaseEntry
			{
				// Token: 0x17000011 RID: 17
				// (get) Token: 0x0600005E RID: 94 RVA: 0x0000490F File Offset: 0x00002B0F
				public string Name { get; }

				// Token: 0x17000012 RID: 18
				// (get) Token: 0x0600005F RID: 95 RVA: 0x00004917 File Offset: 0x00002B17
				public string ConnectionString { get; }

				// Token: 0x06000060 RID: 96 RVA: 0x0000491F File Offset: 0x00002B1F
				public RedisDatabaseEntry(LogicJSONObject jsonObject)
				{
					this.Name = jsonObject.GetJSONString("name").GetStringValue();
					this.ConnectionString = jsonObject.GetJSONString("connectionString").GetStringValue();
				}

				// Token: 0x06000061 RID: 97 RVA: 0x00004953 File Offset: 0x00002B53
				public LogicJSONObject Save()
				{
					LogicJSONObject logicJSONObject = new LogicJSONObject();
					logicJSONObject.Put("name", new LogicJSONString(this.Name));
					logicJSONObject.Put("connectionString", new LogicJSONString(this.ConnectionString));
					return logicJSONObject;
				}

				// Token: 0x04000026 RID: 38
				[CompilerGenerated]
				private readonly string string_0;

				// Token: 0x04000027 RID: 39
				[CompilerGenerated]
				private readonly string string_1;
			}
		}

		// Token: 0x02000014 RID: 20
		public struct ServerSettings
		{
			// Token: 0x17000013 RID: 19
			// (get) Token: 0x06000062 RID: 98 RVA: 0x00004986 File Offset: 0x00002B86
			public EnvironmentSettings.ServerSettings.ProxySettings Proxy { get; }

			// Token: 0x17000014 RID: 20
			// (get) Token: 0x06000063 RID: 99 RVA: 0x0000498E File Offset: 0x00002B8E
			public byte[] ProtocolSecureKey { get; }

			// Token: 0x17000015 RID: 21
			// (get) Token: 0x06000064 RID: 100 RVA: 0x00004996 File Offset: 0x00002B96
			public bool StartInMaintenanceMode { get; }

			// Token: 0x06000065 RID: 101 RVA: 0x0000499E File Offset: 0x00002B9E
			public ServerSettings(LogicJSONObject jsonObject)
			{
				this.StartInMaintenanceMode = jsonObject.GetJSONBoolean("startInMaintenanceMode").IsTrue();
				this.ProtocolSecureKey = Convert.FromBase64String(jsonObject.GetJSONString("protocolSecureKey").GetStringValue());
				this.Proxy = new EnvironmentSettings.ServerSettings.ProxySettings();
			}

			// Token: 0x06000066 RID: 102 RVA: 0x000049DC File Offset: 0x00002BDC
			public LogicJSONObject Save()
			{
				LogicJSONObject logicJSONObject = new LogicJSONObject();
				logicJSONObject.Put("startInMaintenanceMode", new LogicJSONBoolean(this.StartInMaintenanceMode));
				logicJSONObject.Put("protocolSecureKey", new LogicJSONString(Convert.ToBase64String(this.ProtocolSecureKey)));
				return logicJSONObject;
			}

			// Token: 0x04000028 RID: 40
			[CompilerGenerated]
			private readonly EnvironmentSettings.ServerSettings.ProxySettings proxySettings_0;

			// Token: 0x04000029 RID: 41
			[CompilerGenerated]
			private readonly byte[] byte_0;

			// Token: 0x0400002A RID: 42
			[CompilerGenerated]
			private readonly bool bool_0;

			// Token: 0x02000015 RID: 21
			public class ProxySettings
			{
				// Token: 0x17000016 RID: 22
				// (get) Token: 0x06000067 RID: 103 RVA: 0x00004A14 File Offset: 0x00002C14
				// (set) Token: 0x06000068 RID: 104 RVA: 0x00004A1C File Offset: 0x00002C1C
				public int SessionCapacity { get; set; }

				// Token: 0x0400002B RID: 43
				[CompilerGenerated]
				private int int_0;
			}

			// Token: 0x02000016 RID: 22
			public class AdminSettings
			{
				// Token: 0x17000017 RID: 23
				// (get) Token: 0x0600006A RID: 106 RVA: 0x00004A25 File Offset: 0x00002C25
				public LogicArrayList<string> PresetLevelFiles { get; }

				// Token: 0x0600006B RID: 107 RVA: 0x0000A580 File Offset: 0x00008780
				public AdminSettings(LogicJSONObject jsonObject)
				{
					LogicJSONArray jsonarray = jsonObject.GetJSONArray("presetLevelFiles");
					if (jsonarray != null)
					{
						this.PresetLevelFiles = new LogicArrayList<string>(jsonarray.Size());
						for (int i = 0; i < jsonarray.Size(); i++)
						{
							this.PresetLevelFiles.Add(jsonarray.GetJSONString(i).GetStringValue());
						}
						return;
					}
					this.PresetLevelFiles = null;
				}

				// Token: 0x0600006C RID: 108 RVA: 0x0000A5E4 File Offset: 0x000087E4
				public LogicJSONObject Save()
				{
					LogicJSONObject logicJSONObject = new LogicJSONObject();
					if (this.PresetLevelFiles != null)
					{
						LogicJSONArray logicJSONArray = new LogicJSONArray();
						for (int i = 0; i < this.PresetLevelFiles.Size(); i++)
						{
							logicJSONArray.Add(new LogicJSONString(this.PresetLevelFiles[i]));
						}
						logicJSONObject.Put("presetLevelFiles", logicJSONArray);
					}
					return logicJSONObject;
				}

				// Token: 0x0400002C RID: 44
				[CompilerGenerated]
				private readonly LogicArrayList<string> logicArrayList_0;
			}
		}

		// Token: 0x02000017 RID: 23
		public struct ServerConnectionEntry
		{
			// Token: 0x17000018 RID: 24
			// (get) Token: 0x0600006D RID: 109 RVA: 0x00004A2D File Offset: 0x00002C2D
			public string ServerIP { get; }

			// Token: 0x17000019 RID: 25
			// (get) Token: 0x0600006E RID: 110 RVA: 0x00004A35 File Offset: 0x00002C35
			public int ServerPort { get; }

			// Token: 0x0600006F RID: 111 RVA: 0x0000A640 File Offset: 0x00008840
			public ServerConnectionEntry(LogicJSONString jsonString)
			{
				string[] array = jsonString.GetStringValue().Split(':', StringSplitOptions.None);
				Logging.Assert(array.Length == 2, "Malformed connection string!");
				this.ServerIP = array[0];
				this.ServerPort = int.Parse(array[1]);
			}

			// Token: 0x06000070 RID: 112 RVA: 0x00004A3D File Offset: 0x00002C3D
			public ServerConnectionEntry(string ip, int port)
			{
				this.ServerIP = ip;
				this.ServerPort = port;
			}

			// Token: 0x06000071 RID: 113 RVA: 0x00004A4D File Offset: 0x00002C4D
			public LogicJSONString Save()
			{
				return new LogicJSONString(string.Format("{0}:{1}", this.ServerIP, this.ServerPort));
			}

			// Token: 0x0400002D RID: 45
			[CompilerGenerated]
			private readonly string string_0;

			// Token: 0x0400002E RID: 46
			[CompilerGenerated]
			private readonly int int_0;
		}

		// Token: 0x02000018 RID: 24
		public struct CouchbaseSettings
		{
			// Token: 0x1700001A RID: 26
			// (get) Token: 0x06000072 RID: 114 RVA: 0x00004A6F File Offset: 0x00002C6F
			public LogicArrayList<EnvironmentSettings.CouchbaseServerEntry> Servers { get; }

			// Token: 0x1700001B RID: 27
			// (get) Token: 0x06000073 RID: 115 RVA: 0x00004A77 File Offset: 0x00002C77
			public LogicArrayList<EnvironmentSettings.CouchbaseBucketEntry> Buckets { get; }

			// Token: 0x06000074 RID: 116 RVA: 0x0000A684 File Offset: 0x00008884
			public CouchbaseSettings(LogicJSONObject jsonObject)
			{
				LogicJSONArray jsonarray = jsonObject.GetJSONArray("servers");
				LogicJSONArray jsonarray2 = jsonObject.GetJSONArray("buckets");
				this.Servers = new LogicArrayList<EnvironmentSettings.CouchbaseServerEntry>(jsonarray.Size());
				this.Buckets = new LogicArrayList<EnvironmentSettings.CouchbaseBucketEntry>(jsonarray2.Size());
				for (int i = 0; i < jsonarray.Size(); i++)
				{
					this.Servers.Add(new EnvironmentSettings.CouchbaseServerEntry(jsonarray.GetJSONObject(i)));
				}
				for (int j = 0; j < jsonarray2.Size(); j++)
				{
					EnvironmentSettings.CouchbaseBucketEntry couchbaseBucketEntry = new EnvironmentSettings.CouchbaseBucketEntry(jsonarray2.GetJSONObject(j));
					if (this.method_0(couchbaseBucketEntry.BucketType) != -1)
					{
						Logging.Warning("EnvironmentSettings::CouchbaseSettings.ctr: bucket with the same name already exists.");
					}
					else if ((ulong)couchbaseBucketEntry.ServerIndex >= (ulong)((long)this.Servers.Size()))
					{
						Logging.Warning(string.Format("EnvironmentSettings::CouchbaseSettings.ctr: server index is out of bounds (bucket name: {0})", couchbaseBucketEntry.ServerIndex));
					}
					else
					{
						this.Buckets.Add(couchbaseBucketEntry);
					}
				}
			}

			// Token: 0x06000075 RID: 117 RVA: 0x0000A770 File Offset: 0x00008970
			private int method_0(string string_0)
			{
				for (int i = 0; i < this.Buckets.Size(); i++)
				{
					if (this.Buckets[i].BucketType.Equals(string_0, StringComparison.InvariantCultureIgnoreCase))
					{
						return i;
					}
				}
				return -1;
			}

			// Token: 0x06000076 RID: 118 RVA: 0x0000A7B0 File Offset: 0x000089B0
			public bool TryGetBucketData(string type, out EnvironmentSettings.CouchbaseServerEntry serverEntry, out EnvironmentSettings.CouchbaseBucketEntry bucketEntry)
			{
				int num = this.method_0(type);
				if (num != -1)
				{
					bucketEntry = this.Buckets[num];
					serverEntry = this.Servers[bucketEntry.ServerIndex];
					return true;
				}
				serverEntry = null;
				bucketEntry = null;
				return false;
			}

			// Token: 0x06000077 RID: 119 RVA: 0x0000A7F4 File Offset: 0x000089F4
			public LogicJSONObject Save()
			{
				LogicJSONObject logicJSONObject = new LogicJSONObject();
				LogicJSONArray logicJSONArray = new LogicJSONArray();
				LogicJSONArray logicJSONArray2 = new LogicJSONArray();
				for (int i = 0; i < this.Servers.Size(); i++)
				{
					logicJSONArray.Add(this.Servers[i].Save());
				}
				for (int j = 0; j < this.Buckets.Size(); j++)
				{
					logicJSONArray2.Add(this.Buckets[j].Save());
				}
				logicJSONObject.Put("servers", logicJSONArray);
				logicJSONObject.Put("buckets", logicJSONArray2);
				return logicJSONObject;
			}

			// Token: 0x0400002F RID: 47
			[CompilerGenerated]
			private readonly LogicArrayList<EnvironmentSettings.CouchbaseServerEntry> logicArrayList_0;

			// Token: 0x04000030 RID: 48
			[CompilerGenerated]
			private readonly LogicArrayList<EnvironmentSettings.CouchbaseBucketEntry> logicArrayList_1;
		}

		// Token: 0x02000019 RID: 25
		public class CouchbaseServerEntry
		{
			// Token: 0x1700001C RID: 28
			// (get) Token: 0x06000078 RID: 120 RVA: 0x00004A7F File Offset: 0x00002C7F
			public Uri[] Hosts { get; }

			// Token: 0x1700001D RID: 29
			// (get) Token: 0x06000079 RID: 121 RVA: 0x00004A87 File Offset: 0x00002C87
			public string Username { get; }

			// Token: 0x1700001E RID: 30
			// (get) Token: 0x0600007A RID: 122 RVA: 0x00004A8F File Offset: 0x00002C8F
			public string Password { get; }

			// Token: 0x0600007B RID: 123 RVA: 0x0000A88C File Offset: 0x00008A8C
			public CouchbaseServerEntry(LogicJSONObject jsonObject)
			{
				LogicJSONArray jsonarray = jsonObject.GetJSONArray("hosts");
				this.Hosts = new Uri[jsonarray.Size()];
				for (int i = 0; i < jsonarray.Size(); i++)
				{
					this.Hosts[i] = new Uri("http://" + jsonarray.GetJSONString(i).GetStringValue());
				}
				this.Username = jsonObject.GetJSONString("username").GetStringValue();
				this.Password = jsonObject.GetJSONString("password").GetStringValue();
			}

			// Token: 0x0600007C RID: 124 RVA: 0x0000A91C File Offset: 0x00008B1C
			public LogicJSONObject Save()
			{
				LogicJSONObject logicJSONObject = new LogicJSONObject();
				LogicJSONArray logicJSONArray = new LogicJSONArray();
				for (int i = 0; i < this.Hosts.Length; i++)
				{
					logicJSONArray.Add(new LogicJSONString(this.Hosts[i].ToString()));
				}
				logicJSONObject.Put("hosts", logicJSONArray);
				logicJSONObject.Put("username", new LogicJSONString(this.Username));
				logicJSONObject.Put("password", new LogicJSONString(this.Password));
				return logicJSONObject;
			}

			// Token: 0x04000031 RID: 49
			[CompilerGenerated]
			private readonly Uri[] uri_0;

			// Token: 0x04000032 RID: 50
			[CompilerGenerated]
			private readonly string string_0;

			// Token: 0x04000033 RID: 51
			[CompilerGenerated]
			private readonly string string_1;
		}

		// Token: 0x0200001A RID: 26
		public class CouchbaseBucketEntry
		{
			// Token: 0x1700001F RID: 31
			// (get) Token: 0x0600007D RID: 125 RVA: 0x00004A97 File Offset: 0x00002C97
			public string BucketType { get; }

			// Token: 0x17000020 RID: 32
			// (get) Token: 0x0600007E RID: 126 RVA: 0x00004A9F File Offset: 0x00002C9F
			public string BucketName { get; }

			// Token: 0x17000021 RID: 33
			// (get) Token: 0x0600007F RID: 127 RVA: 0x00004AA7 File Offset: 0x00002CA7
			public int ServerIndex { get; }

			// Token: 0x06000080 RID: 128 RVA: 0x0000A99C File Offset: 0x00008B9C
			public CouchbaseBucketEntry(LogicJSONObject jsonObject)
			{
				this.BucketType = jsonObject.GetJSONString("type").GetStringValue();
				this.BucketName = jsonObject.GetJSONString("name").GetStringValue();
				this.ServerIndex = jsonObject.GetJSONNumber("serverIdx").GetIntValue();
			}

			// Token: 0x06000081 RID: 129 RVA: 0x0000A9F4 File Offset: 0x00008BF4
			public LogicJSONObject Save()
			{
				LogicJSONObject logicJSONObject = new LogicJSONObject();
				logicJSONObject.Put("type", new LogicJSONString(this.BucketType));
				logicJSONObject.Put("name", new LogicJSONString(this.BucketName));
				logicJSONObject.Put("serverIdx", new LogicJSONNumber(this.ServerIndex));
				return logicJSONObject;
			}

			// Token: 0x04000034 RID: 52
			[CompilerGenerated]
			private readonly string string_0;

			// Token: 0x04000035 RID: 53
			[CompilerGenerated]
			private readonly string string_1;

			// Token: 0x04000036 RID: 54
			[CompilerGenerated]
			private readonly int int_0;
		}
	}
}
