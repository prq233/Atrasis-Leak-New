using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Message.Alliance.Stream;
using Atrasis.Magic.Logic.Message.Avatar.Attack;
using Atrasis.Magic.Logic.Message.Avatar.Stream;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Database.Document
{
	// Token: 0x020000FB RID: 251
	public class StreamDocument : CouchbaseDocument
	{
		// Token: 0x170001CC RID: 460
		// (get) Token: 0x060007A2 RID: 1954 RVA: 0x00009339 File Offset: 0x00007539
		// (set) Token: 0x060007A3 RID: 1955 RVA: 0x00009341 File Offset: 0x00007541
		public DateTime CreateTime { get; set; }

		// Token: 0x170001CD RID: 461
		// (get) Token: 0x060007A4 RID: 1956 RVA: 0x0000934A File Offset: 0x0000754A
		// (set) Token: 0x060007A5 RID: 1957 RVA: 0x00009352 File Offset: 0x00007552
		public StreamType Type { get; set; }

		// Token: 0x170001CE RID: 462
		// (get) Token: 0x060007A6 RID: 1958 RVA: 0x0000935B File Offset: 0x0000755B
		// (set) Token: 0x060007A7 RID: 1959 RVA: 0x00009363 File Offset: 0x00007563
		public LogicLong OwnerId { get; set; }

		// Token: 0x170001CF RID: 463
		// (get) Token: 0x060007A8 RID: 1960 RVA: 0x0000936C File Offset: 0x0000756C
		// (set) Token: 0x060007A9 RID: 1961 RVA: 0x00009374 File Offset: 0x00007574
		public object Entry { get; set; }

		// Token: 0x060007AA RID: 1962 RVA: 0x0000937D File Offset: 0x0000757D
		public StreamDocument()
		{
		}

		// Token: 0x060007AB RID: 1963 RVA: 0x00009385 File Offset: 0x00007585
		public StreamDocument(LogicLong id, LogicLong ownerId, StreamEntry entry) : base(id)
		{
			this.CreateTime = DateTime.UtcNow;
			this.OwnerId = ownerId;
			this.Type = StreamType.ALLIANCE;
			this.Entry = entry;
			entry.SetId(id);
		}

		// Token: 0x060007AC RID: 1964 RVA: 0x000093B5 File Offset: 0x000075B5
		public StreamDocument(LogicLong id, LogicLong ownerId, AvatarStreamEntry entry) : base(id)
		{
			this.CreateTime = DateTime.UtcNow;
			this.OwnerId = ownerId;
			this.Type = StreamType.AVATAR;
			this.Entry = entry;
			entry.SetId(id);
		}

		// Token: 0x060007AD RID: 1965 RVA: 0x000093E5 File Offset: 0x000075E5
		public StreamDocument(LogicLong id, LogicLong ownerId, Village2AttackEntry entry) : base(id)
		{
			this.CreateTime = DateTime.UtcNow;
			this.OwnerId = ownerId;
			this.Type = StreamType.ATTACK_ENTRY;
			this.Entry = entry;
			entry.SetId(id);
		}

		// Token: 0x060007AE RID: 1966 RVA: 0x00009415 File Offset: 0x00007615
		public StreamDocument(LogicLong id, ReplayStreamEntry entry) : base(id)
		{
			this.CreateTime = DateTime.UtcNow;
			this.OwnerId = new LogicLong();
			this.Type = StreamType.REPLAY;
			this.Entry = entry;
		}

		// Token: 0x060007AF RID: 1967 RVA: 0x00004631 File Offset: 0x00002831
		protected sealed override void Encode(ByteStream stream)
		{
		}

		// Token: 0x060007B0 RID: 1968 RVA: 0x00004631 File Offset: 0x00002831
		protected sealed override void Decode(ByteStream stream)
		{
		}

		// Token: 0x060007B1 RID: 1969 RVA: 0x00018380 File Offset: 0x00016580
		protected sealed override void Save(LogicJSONObject jsonObject)
		{
			LogicJSONArray logicJSONArray = new LogicJSONArray(2);
			logicJSONArray.Add(new LogicJSONNumber(this.OwnerId.GetHigherInt()));
			logicJSONArray.Add(new LogicJSONNumber(this.OwnerId.GetLowerInt()));
			jsonObject.Put("ownerId", logicJSONArray);
			jsonObject.Put("createT", new LogicJSONString(this.CreateTime.ToString("O")));
			jsonObject.Put("type", new LogicJSONNumber((int)this.Type));
			switch (this.Type)
			{
			case StreamType.ALLIANCE:
			{
				LogicJSONObject logicJSONObject = new LogicJSONObject();
				StreamEntry streamEntry = (StreamEntry)this.Entry;
				jsonObject.Put("entryT", new LogicJSONNumber((int)streamEntry.GetStreamEntryType()));
				jsonObject.Put("entry", logicJSONObject);
				streamEntry.Save(logicJSONObject);
				return;
			}
			case StreamType.AVATAR:
			{
				LogicJSONObject logicJSONObject2 = new LogicJSONObject();
				AvatarStreamEntry avatarStreamEntry = (AvatarStreamEntry)this.Entry;
				jsonObject.Put("entryT", new LogicJSONNumber((int)avatarStreamEntry.GetAvatarStreamEntryType()));
				jsonObject.Put("entry", logicJSONObject2);
				avatarStreamEntry.Save(logicJSONObject2);
				return;
			}
			case StreamType.REPLAY:
			{
				LogicJSONObject logicJSONObject3 = new LogicJSONObject();
				ReplayStreamEntry replayStreamEntry = (ReplayStreamEntry)this.Entry;
				jsonObject.Put("entry", logicJSONObject3);
				replayStreamEntry.Save(logicJSONObject3);
				return;
			}
			case StreamType.ATTACK_ENTRY:
			{
				LogicJSONObject logicJSONObject4 = new LogicJSONObject();
				Village2AttackEntry village2AttackEntry = (Village2AttackEntry)this.Entry;
				jsonObject.Put("entryT", new LogicJSONNumber((int)village2AttackEntry.GetAttackEntryType()));
				jsonObject.Put("entry", logicJSONObject4);
				village2AttackEntry.Save(logicJSONObject4);
				return;
			}
			default:
				return;
			}
		}

		// Token: 0x060007B2 RID: 1970 RVA: 0x0001850C File Offset: 0x0001670C
		protected sealed override void Load(LogicJSONObject jsonObject)
		{
			LogicJSONArray jsonarray = jsonObject.GetJSONArray("ownerId");
			this.OwnerId = new LogicLong(jsonarray.GetJSONNumber(0).GetIntValue(), jsonarray.GetJSONNumber(1).GetIntValue());
			this.CreateTime = DateTime.Parse(jsonObject.GetJSONString("createT").GetStringValue());
			this.Type = (StreamType)jsonObject.GetJSONNumber("type").GetIntValue();
			switch (this.Type)
			{
			case StreamType.ALLIANCE:
			{
				StreamEntry streamEntry = StreamEntryFactory.CreateStreamEntryByType((StreamEntryType)jsonObject.GetJSONNumber("entryT").GetIntValue());
				streamEntry.Load(jsonObject.GetJSONObject("entry"));
				streamEntry.SetId(base.Id);
				this.Entry = streamEntry;
				return;
			}
			case StreamType.AVATAR:
			{
				AvatarStreamEntry avatarStreamEntry = AvatarStreamEntryFactory.CreateStreamEntryByType((AvatarStreamEntryType)jsonObject.GetJSONNumber("entryT").GetIntValue());
				avatarStreamEntry.Load(jsonObject.GetJSONObject("entry"));
				avatarStreamEntry.SetId(base.Id);
				this.Entry = avatarStreamEntry;
				return;
			}
			case StreamType.REPLAY:
			{
				ReplayStreamEntry replayStreamEntry = new ReplayStreamEntry();
				replayStreamEntry.Load(jsonObject.GetJSONObject("entry"));
				this.Entry = replayStreamEntry;
				return;
			}
			case StreamType.ATTACK_ENTRY:
			{
				Village2AttackEntry village2AttackEntry = Village2AttackEntryFactory.CreateAttackEntryByType((Village2AttackEntryType)jsonObject.GetJSONNumber("entryT").GetIntValue());
				village2AttackEntry.Load(jsonObject.GetJSONObject("entry"));
				village2AttackEntry.SetId(base.Id);
				this.Entry = village2AttackEntry;
				return;
			}
			default:
				return;
			}
		}

		// Token: 0x060007B3 RID: 1971 RVA: 0x00018670 File Offset: 0x00016870
		public void Update()
		{
			StreamType type = this.Type;
			if (type == StreamType.ALLIANCE)
			{
				((StreamEntry)this.Entry).SetAgeSeconds((int)DateTime.UtcNow.Subtract(this.CreateTime).TotalSeconds);
				return;
			}
			if (type != StreamType.AVATAR)
			{
				return;
			}
			((AvatarStreamEntry)this.Entry).SetAgeSeconds((int)DateTime.UtcNow.Subtract(this.CreateTime).TotalSeconds);
		}

		// Token: 0x04000449 RID: 1097
		private const string string_0 = "ownerId";

		// Token: 0x0400044A RID: 1098
		private const string string_1 = "type";

		// Token: 0x0400044B RID: 1099
		private const string string_2 = "createT";

		// Token: 0x0400044C RID: 1100
		private const string string_3 = "entry";

		// Token: 0x0400044D RID: 1101
		private const string string_4 = "entryT";

		// Token: 0x0400044E RID: 1102
		[CompilerGenerated]
		private DateTime dateTime_0;

		// Token: 0x0400044F RID: 1103
		[CompilerGenerated]
		private StreamType streamType_0;

		// Token: 0x04000450 RID: 1104
		[CompilerGenerated]
		private LogicLong logicLong_1;

		// Token: 0x04000451 RID: 1105
		[CompilerGenerated]
		private object object_0;
	}
}
