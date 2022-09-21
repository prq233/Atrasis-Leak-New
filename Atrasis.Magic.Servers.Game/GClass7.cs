using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Atrasis.Magic.Logic.Avatar.Change;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Mode;
using Atrasis.Magic.Servers.Core;
using Atrasis.Magic.Servers.Core.Database.Document;
using Atrasis.Magic.Servers.Core.Network;
using Atrasis.Magic.Servers.Core.Network.Message;
using Atrasis.Magic.Servers.Core.Network.Message.Account;
using Atrasis.Magic.Servers.Core.Network.Message.Session.Change;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;
using Couchbase;
using Couchbase.IO;

namespace ns0
{
	// Token: 0x02000011 RID: 17
	public static class GClass7
	{
		// Token: 0x0600007D RID: 125 RVA: 0x00005424 File Offset: 0x00003624
		public static void smethod_0()
		{
			GClass7.dictionary_0 = new Dictionary<long, GClass5>();
			GClass7.concurrentDictionary_0 = new ConcurrentDictionary<long, GClass5>();
			int[] counterHigherIDs = GClass0.smethod_0().GetCounterHigherIDs();
			for (int i = 0; i < counterHigherIDs.Length; i++)
			{
				GClass7.Class8 @class = new GClass7.Class8();
				@class.int_0 = i;
				Parallel.For(1, counterHigherIDs[i] + 1, new Action<int>(@class.method_0));
			}
			GClass7.thread_0 = new Thread(new ThreadStart(GClass7.smethod_1));
			GClass7.thread_0.Start();
		}

		// Token: 0x0600007E RID: 126 RVA: 0x000054A4 File Offset: 0x000036A4
		private static void smethod_1()
		{
			for (;;)
			{
				foreach (GClass5 gclass in GClass7.concurrentDictionary_0.Values)
				{
					if (gclass.method_0() == null && gclass.ServerCommands.Size() != 0 && DateTime.UtcNow.Subtract(gclass.method_6()).TotalMinutes >= 1.0 && (gclass.method_2() == null || gclass.method_2().method_3()))
					{
						GClass7.smethod_3(gclass);
						GClass7.smethod_7(gclass);
					}
				}
				Thread.Sleep(15000);
			}
		}

		// Token: 0x0600007F RID: 127 RVA: 0x000024D5 File Offset: 0x000006D5
		public static ConcurrentDictionary<long, GClass5> smethod_2()
		{
			return GClass7.concurrentDictionary_0;
		}

		// Token: 0x06000080 RID: 128 RVA: 0x0000555C File Offset: 0x0000375C
		private static void smethod_3(GClass5 gclass5_0)
		{
			if (gclass5_0.ServerCommands.Size() != 0)
			{
				LogicGameMode logicGameMode = new LogicGameMode();
				LogicLevel level = logicGameMode.GetLevel();
				GClass16 gclass = new GClass16(gclass5_0.LogicClientAvatar);
				LogicLong allianceId = gclass5_0.LogicClientAvatar.GetAllianceId();
				gclass5_0.LogicClientAvatar.SetChangeListener(gclass);
				level.SetVisitorAvatar(gclass5_0.LogicClientAvatar);
				level.SetHomeOwnerAvatar(gclass5_0.LogicClientAvatar);
				try
				{
					for (int i = 0; i < gclass5_0.ServerCommands.Size(); i++)
					{
						if (gclass5_0.ServerCommands[i].Execute(level) == 0)
						{
							gclass5_0.ServerCommands.Remove(i--);
						}
					}
				}
				catch (Exception arg)
				{
					Logging.Error("GameAvatarManager.executeServerCommandsInOfflineMode: server command execution in offline mode failed: " + arg);
					if (gclass5_0.ServerCommands.Size() > 0)
					{
						gclass5_0.ServerCommands.Remove(0);
					}
				}
				if (gclass.method_0())
				{
					LogicArrayList<AvatarChange> avatarChanges = gclass.method_1();
					if (allianceId != null)
					{
						ServerMessageManager.SendMessage(new AllianceAvatarChangesMessage
						{
							AccountId = allianceId,
							AvatarChanges = avatarChanges,
							MemberId = gclass5_0.Id
						}, 11);
					}
				}
				gclass5_0.LogicClientAvatar.SetChangeListener(new LogicAvatarChangeListener());
				logicGameMode.Destruct();
			}
		}

		// Token: 0x06000081 RID: 129 RVA: 0x000024DC File Offset: 0x000006DC
		public static bool smethod_4(LogicLong logicLong_0, out GClass5 gclass5_0)
		{
			return GClass7.dictionary_0.TryGetValue(logicLong_0, out gclass5_0);
		}

		// Token: 0x06000082 RID: 130 RVA: 0x000024EF File Offset: 0x000006EF
		public static GClass5 smethod_5(LogicLong logicLong_0)
		{
			return GClass7.dictionary_0[logicLong_0];
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00005694 File Offset: 0x00003894
		public static GClass5 smethod_6(LogicLong logicLong_0)
		{
			if (ServerManager.GetDocumentSocket(ServerCore.Type, logicLong_0) != ServerCore.Socket)
			{
				throw new Exception("GameAvatarManager.create - invalid document id");
			}
			GClass5 gclass = new GClass5(logicLong_0);
			gclass.HomeData = GClass11.smethod_0();
			GClass7.dictionary_0.Add(logicLong_0, gclass);
			return gclass;
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00002501 File Offset: 0x00000701
		public static void smethod_7(GClass5 gclass5_0)
		{
			GClass0.smethod_0().InsertOrUpdate(gclass5_0.Id, CouchbaseDocument.Save(gclass5_0));
		}

		// Token: 0x06000085 RID: 133 RVA: 0x0000251F File Offset: 0x0000071F
		public static void smethod_8(GClass5 gclass5_0)
		{
			GClass7.concurrentDictionary_0.TryAdd(gclass5_0.Id, gclass5_0);
		}

		// Token: 0x06000086 RID: 134 RVA: 0x000056E4 File Offset: 0x000038E4
		public static void smethod_9(GClass5 gclass5_0)
		{
			GClass5 gclass;
			GClass7.concurrentDictionary_0.TryRemove(gclass5_0.Id, out gclass);
		}

		// Token: 0x04000020 RID: 32
		private static Dictionary<long, GClass5> dictionary_0;

		// Token: 0x04000021 RID: 33
		private static ConcurrentDictionary<long, GClass5> concurrentDictionary_0;

		// Token: 0x04000022 RID: 34
		private static Thread thread_0;

		// Token: 0x02000012 RID: 18
		[CompilerGenerated]
		private sealed class Class8
		{
			// Token: 0x06000088 RID: 136 RVA: 0x0000570C File Offset: 0x0000390C
			internal void method_0(int int_1)
			{
				LogicLong logicLong = new LogicLong(this.int_0, int_1);
				if (ServerManager.GetDocumentSocket(ServerCore.Type, logicLong) == ServerCore.Socket)
				{
					IOperationResult<string> result = GClass0.smethod_0().Get(logicLong).Result;
					while (!result.Success)
					{
						if (result.Status == ResponseStatus.KeyNotFound)
						{
							break;
						}
						result = GClass0.smethod_0().Get(logicLong).Result;
					}
					if (result.Success)
					{
						Dictionary<long, GClass5> dictionary_ = GClass7.dictionary_0;
						lock (dictionary_)
						{
							GClass5 value = CouchbaseDocument.Load<GClass5>(result.Value);
							GClass7.dictionary_0.Add(logicLong, value);
							GClass7.concurrentDictionary_0.TryAdd(logicLong, value);
						}
					}
				}
			}

			// Token: 0x04000023 RID: 35
			public int int_0;
		}
	}
}
