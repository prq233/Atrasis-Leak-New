using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Atrasis.Magic.Logic.Message.Alliance.Stream;
using Atrasis.Magic.Logic.Message.Avatar.Attack;
using Atrasis.Magic.Logic.Message.Avatar.Stream;
using Atrasis.Magic.Servers.Core;
using Atrasis.Magic.Servers.Core.Database.Document;
using Atrasis.Magic.Servers.Core.Network;
using Atrasis.Magic.Titan.Math;

namespace ns0
{
	// Token: 0x02000012 RID: 18
	public static class GClass10
	{
		// Token: 0x06000080 RID: 128 RVA: 0x000062CC File Offset: 0x000044CC
		public static void smethod_0()
		{
			GClass10.dictionary_0 = new Dictionary<long, StreamDocument>();
			GClass10.dictionary_1 = new Dictionary<long, StreamDocument>();
			GClass10.dictionary_2 = new Dictionary<long, StreamDocument>();
			GClass10.dictionary_3 = new Dictionary<long, StreamDocument>();
			List<Task> list = new List<Task>();
			long num = 1L;
			long documentHigherID = GClass0.smethod_2().GetDocumentHigherID();
			while (num <= documentHigherID)
			{
				list.Add(GClass10.smethod_1(new LogicLong((int)(num >> 32), (int)num)));
				num += 1L;
			}
			Task.WaitAll(list.ToArray());
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00006350 File Offset: 0x00004550
		private static Task smethod_1(LogicLong logicLong_0)
		{
			GClass10.Struct1 @struct;
			@struct.logicLong_0 = logicLong_0;
			@struct.asyncTaskMethodBuilder_0 = AsyncTaskMethodBuilder.Create();
			@struct.int_0 = -1;
			AsyncTaskMethodBuilder asyncTaskMethodBuilder_ = @struct.asyncTaskMethodBuilder_0;
			asyncTaskMethodBuilder_.Start<GClass10.Struct1>(ref @struct);
			return @struct.asyncTaskMethodBuilder_0.Task;
		}

		// Token: 0x06000082 RID: 130 RVA: 0x0000236C File Offset: 0x0000056C
		private static LogicLong smethod_2()
		{
			if (GClass10.long_0 == 0L)
			{
				return GClass10.long_0 = (long)(ServerCore.Id + 1);
			}
			return GClass10.long_0 += (long)ServerManager.GetServerCount(11);
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00006398 File Offset: 0x00004598
		public static StreamEntry smethod_3(LogicLong logicLong_0)
		{
			StreamDocument streamDocument;
			if (GClass10.dictionary_0.TryGetValue(logicLong_0, out streamDocument))
			{
				streamDocument.Update();
				return (StreamEntry)streamDocument.Entry;
			}
			return null;
		}

		// Token: 0x06000084 RID: 132 RVA: 0x000063CC File Offset: 0x000045CC
		public static AvatarStreamEntry smethod_4(LogicLong logicLong_0)
		{
			StreamDocument streamDocument;
			if (GClass10.dictionary_1.TryGetValue(logicLong_0, out streamDocument))
			{
				streamDocument.Update();
				return (AvatarStreamEntry)streamDocument.Entry;
			}
			return null;
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00006400 File Offset: 0x00004600
		public static Atrasis.Magic.Servers.Core.Database.Document.ReplayStreamEntry smethod_5(LogicLong logicLong_0)
		{
			StreamDocument streamDocument;
			if (GClass10.dictionary_2.TryGetValue(logicLong_0, out streamDocument))
			{
				return (Atrasis.Magic.Servers.Core.Database.Document.ReplayStreamEntry)streamDocument.Entry;
			}
			return null;
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00006430 File Offset: 0x00004630
		public static Village2AttackEntry smethod_6(LogicLong logicLong_0)
		{
			StreamDocument streamDocument;
			if (GClass10.dictionary_3.TryGetValue(logicLong_0, out streamDocument))
			{
				return (Village2AttackEntry)streamDocument.Entry;
			}
			return null;
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00006460 File Offset: 0x00004660
		public static void smethod_7(LogicLong logicLong_0, StreamEntry streamEntry_0)
		{
			StreamDocument streamDocument = new StreamDocument(GClass10.smethod_2(), logicLong_0, streamEntry_0);
			GClass10.dictionary_0.Add(streamDocument.Id, streamDocument);
			GClass10.smethod_11(streamDocument);
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00006498 File Offset: 0x00004698
		public static void smethod_8(LogicLong logicLong_0, AvatarStreamEntry avatarStreamEntry_0)
		{
			StreamDocument streamDocument = new StreamDocument(GClass10.smethod_2(), logicLong_0, avatarStreamEntry_0);
			GClass10.dictionary_1.Add(streamDocument.Id, streamDocument);
			GClass10.smethod_11(streamDocument);
		}

		// Token: 0x06000089 RID: 137 RVA: 0x000064D0 File Offset: 0x000046D0
		public static void smethod_9(byte[] byte_0, out LogicLong logicLong_0)
		{
			StreamDocument streamDocument = new StreamDocument(GClass10.smethod_2(), new Atrasis.Magic.Servers.Core.Database.Document.ReplayStreamEntry(byte_0));
			GClass10.dictionary_2.Add(streamDocument.Id, streamDocument);
			GClass10.smethod_11(streamDocument);
			logicLong_0 = streamDocument.Id;
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00006514 File Offset: 0x00004714
		public static void smethod_10(LogicLong logicLong_0, Village2AttackEntry village2AttackEntry_0)
		{
			StreamDocument streamDocument = new StreamDocument(GClass10.smethod_2(), logicLong_0, village2AttackEntry_0);
			GClass10.dictionary_3.Add(streamDocument.Id, streamDocument);
			GClass10.smethod_11(streamDocument);
		}

		// Token: 0x0600008B RID: 139 RVA: 0x000023A2 File Offset: 0x000005A2
		private static void smethod_11(StreamDocument streamDocument_0)
		{
			GClass0.smethod_2().InsertOrUpdate(streamDocument_0.Id, CouchbaseDocument.Save(streamDocument_0));
		}

		// Token: 0x0600008C RID: 140 RVA: 0x0000654C File Offset: 0x0000474C
		public static void smethod_12(StreamEntry streamEntry_0)
		{
			StreamDocument streamDocument = GClass10.dictionary_0[streamEntry_0.GetId()];
			streamDocument.Entry = streamEntry_0;
			GClass0.smethod_2().InsertOrUpdate(streamDocument.Id, CouchbaseDocument.Save(streamDocument));
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00006594 File Offset: 0x00004794
		public static void smethod_13(AvatarStreamEntry avatarStreamEntry_0)
		{
			StreamDocument streamDocument = GClass10.dictionary_1[avatarStreamEntry_0.GetId()];
			streamDocument.Entry = avatarStreamEntry_0;
			GClass0.smethod_2().InsertOrUpdate(streamDocument.Id, CouchbaseDocument.Save(streamDocument));
		}

		// Token: 0x0600008E RID: 142 RVA: 0x000065DC File Offset: 0x000047DC
		public static void smethod_14(Village2AttackEntry village2AttackEntry_0)
		{
			StreamDocument streamDocument = GClass10.dictionary_3[village2AttackEntry_0.GetId()];
			streamDocument.Entry = village2AttackEntry_0;
			GClass0.smethod_2().InsertOrUpdate(streamDocument.Id, CouchbaseDocument.Save(streamDocument));
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00006624 File Offset: 0x00004824
		public static void smethod_15(LogicLong logicLong_0)
		{
			StreamDocument streamDocument;
			if (GClass10.dictionary_0.Remove(logicLong_0, out streamDocument))
			{
				GClass0.smethod_2().Remove(streamDocument.Id);
			}
		}

		// Token: 0x06000090 RID: 144 RVA: 0x0000665C File Offset: 0x0000485C
		public static void smethod_16(LogicLong logicLong_0)
		{
			StreamDocument streamDocument;
			if (GClass10.dictionary_1.Remove(logicLong_0, out streamDocument))
			{
				GClass0.smethod_2().Remove(streamDocument.Id);
			}
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00006694 File Offset: 0x00004894
		public static void smethod_17(LogicLong logicLong_0)
		{
			StreamDocument streamDocument;
			if (GClass10.dictionary_3.Remove(logicLong_0, out streamDocument))
			{
				GClass0.smethod_2().Remove(streamDocument.Id);
			}
		}

		// Token: 0x0400001B RID: 27
		private static Dictionary<long, StreamDocument> dictionary_0;

		// Token: 0x0400001C RID: 28
		private static Dictionary<long, StreamDocument> dictionary_1;

		// Token: 0x0400001D RID: 29
		private static Dictionary<long, StreamDocument> dictionary_2;

		// Token: 0x0400001E RID: 30
		private static Dictionary<long, StreamDocument> dictionary_3;

		// Token: 0x0400001F RID: 31
		private static long long_0;
	}
}
