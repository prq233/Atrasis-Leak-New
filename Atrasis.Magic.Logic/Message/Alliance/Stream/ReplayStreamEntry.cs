using System;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Message.Alliance.Stream
{
	// Token: 0x020000E5 RID: 229
	public class ReplayStreamEntry : StreamEntry
	{
		// Token: 0x06000A4D RID: 2637 RVA: 0x00007D58 File Offset: 0x00005F58
		public ReplayStreamEntry()
		{
			this.string_1 = string.Empty;
		}

		// Token: 0x06000A4E RID: 2638 RVA: 0x0002454C File Offset: 0x0002274C
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
			this.int_6 = stream.ReadInt();
			this.logicLong_3 = stream.ReadLong();
			this.bool_1 = stream.ReadBoolean();
			this.string_1 = stream.ReadString(900000);
			this.string_2 = stream.ReadString(900000);
			this.string_3 = stream.ReadString(900000);
			this.int_3 = stream.ReadInt();
			this.int_4 = stream.ReadInt();
			this.int_5 = stream.ReadInt();
		}

		// Token: 0x06000A4F RID: 2639 RVA: 0x000245DC File Offset: 0x000227DC
		public override void Encode(ByteStream stream)
		{
			base.Encode(stream);
			stream.WriteInt(this.int_6);
			stream.WriteLong(this.logicLong_3);
			stream.WriteBoolean(this.bool_1);
			stream.WriteString(this.string_1);
			stream.WriteString(this.string_2);
			stream.WriteString(this.string_3);
			stream.WriteInt(this.int_3);
			stream.WriteInt(this.int_4);
			stream.WriteInt(this.int_5);
		}

		// Token: 0x06000A50 RID: 2640 RVA: 0x00007D6B File Offset: 0x00005F6B
		public string GetMessage()
		{
			return this.string_1;
		}

		// Token: 0x06000A51 RID: 2641 RVA: 0x00007D73 File Offset: 0x00005F73
		public void SetMessage(string value)
		{
			this.string_1 = value;
		}

		// Token: 0x06000A52 RID: 2642 RVA: 0x00007D7C File Offset: 0x00005F7C
		public string GetOpponentName()
		{
			return this.string_2;
		}

		// Token: 0x06000A53 RID: 2643 RVA: 0x00007D84 File Offset: 0x00005F84
		public void SetOpponentName(string value)
		{
			this.string_2 = value;
		}

		// Token: 0x06000A54 RID: 2644 RVA: 0x00007D8D File Offset: 0x00005F8D
		public string GetBattleLogJSON()
		{
			return this.string_3;
		}

		// Token: 0x06000A55 RID: 2645 RVA: 0x00007D95 File Offset: 0x00005F95
		public void SetBattleLogJSON(string value)
		{
			this.string_3 = value;
		}

		// Token: 0x06000A56 RID: 2646 RVA: 0x00007D9E File Offset: 0x00005F9E
		public int GetMajorVersion()
		{
			return this.int_3;
		}

		// Token: 0x06000A57 RID: 2647 RVA: 0x00007DA6 File Offset: 0x00005FA6
		public void SetMajorVersion(int value)
		{
			this.int_3 = value;
		}

		// Token: 0x06000A58 RID: 2648 RVA: 0x00007DAF File Offset: 0x00005FAF
		public int GetBuildVersion()
		{
			return this.int_4;
		}

		// Token: 0x06000A59 RID: 2649 RVA: 0x00007DB7 File Offset: 0x00005FB7
		public void SetBuildVersion(int value)
		{
			this.int_4 = value;
		}

		// Token: 0x06000A5A RID: 2650 RVA: 0x00007DC0 File Offset: 0x00005FC0
		public int GetContentVersion()
		{
			return this.int_5;
		}

		// Token: 0x06000A5B RID: 2651 RVA: 0x00007DC8 File Offset: 0x00005FC8
		public void SetContentVersion(int value)
		{
			this.int_5 = value;
		}

		// Token: 0x06000A5C RID: 2652 RVA: 0x00007DD1 File Offset: 0x00005FD1
		public int GetReplayShardId()
		{
			return this.int_6;
		}

		// Token: 0x06000A5D RID: 2653 RVA: 0x00007DD9 File Offset: 0x00005FD9
		public void SetReplayShardId(int value)
		{
			this.int_6 = value;
		}

		// Token: 0x06000A5E RID: 2654 RVA: 0x00007DE2 File Offset: 0x00005FE2
		public bool IsAttack()
		{
			return this.bool_1;
		}

		// Token: 0x06000A5F RID: 2655 RVA: 0x00007DEA File Offset: 0x00005FEA
		public void SetAttack(bool value)
		{
			this.bool_1 = value;
		}

		// Token: 0x06000A60 RID: 2656 RVA: 0x00007DF3 File Offset: 0x00005FF3
		public LogicLong GetReplayId()
		{
			return this.logicLong_3;
		}

		// Token: 0x06000A61 RID: 2657 RVA: 0x00007DFB File Offset: 0x00005FFB
		public void SetReplayId(LogicLong value)
		{
			this.logicLong_3 = value;
		}

		// Token: 0x06000A62 RID: 2658 RVA: 0x00002BCC File Offset: 0x00000DCC
		public override StreamEntryType GetStreamEntryType()
		{
			return StreamEntryType.REPLAY;
		}

		// Token: 0x06000A63 RID: 2659 RVA: 0x0002465C File Offset: 0x0002285C
		public override void Load(LogicJSONObject jsonObject)
		{
			LogicJSONObject jsonobject = jsonObject.GetJSONObject("base");
			if (jsonobject == null)
			{
				Debugger.Error("ReplayStreamEntry::load base is NULL");
			}
			base.Load(jsonobject);
			this.string_3 = jsonObject.GetJSONString("battleLog").GetStringValue();
			this.string_1 = jsonObject.GetJSONString("message").GetStringValue();
			this.string_2 = jsonObject.GetJSONString("opponent_name").GetStringValue();
			this.bool_1 = jsonObject.GetJSONBoolean("attack").IsTrue();
			this.int_3 = jsonObject.GetJSONNumber("replay_major_v").GetIntValue();
			this.int_4 = jsonObject.GetJSONNumber("replay_build_v").GetIntValue();
			this.int_5 = jsonObject.GetJSONNumber("replay_content_v").GetIntValue();
			LogicJSONNumber jsonnumber = jsonObject.GetJSONNumber("replay_shard_id");
			if (jsonnumber != null)
			{
				this.int_6 = jsonnumber.GetIntValue();
				this.logicLong_3 = new LogicLong(jsonObject.GetJSONNumber("replay_id_hi").GetIntValue(), jsonObject.GetJSONNumber("replay_id_lo").GetIntValue());
			}
		}

		// Token: 0x06000A64 RID: 2660 RVA: 0x0002476C File Offset: 0x0002296C
		public override void Save(LogicJSONObject jsonObject)
		{
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			base.Save(logicJSONObject);
			jsonObject.Put("base", logicJSONObject);
			jsonObject.Put("battleLog", new LogicJSONString(this.string_3));
			jsonObject.Put("message", new LogicJSONString(this.string_1));
			jsonObject.Put("opponent_name", new LogicJSONString(this.string_2));
			jsonObject.Put("attack", new LogicJSONBoolean(this.bool_1));
			jsonObject.Put("replay_major_v", new LogicJSONNumber(this.int_3));
			jsonObject.Put("replay_build_v", new LogicJSONNumber(this.int_4));
			jsonObject.Put("replay_content_v", new LogicJSONNumber(this.int_5));
			if (this.logicLong_3 != null)
			{
				jsonObject.Put("replay_shard_id", new LogicJSONNumber(this.int_6));
				jsonObject.Put("replay_id_hi", new LogicJSONNumber(this.logicLong_3.GetHigherInt()));
				jsonObject.Put("replay_id_lo", new LogicJSONNumber(this.logicLong_3.GetLowerInt()));
			}
		}

		// Token: 0x040003FE RID: 1022
		private string string_1;

		// Token: 0x040003FF RID: 1023
		private string string_2;

		// Token: 0x04000400 RID: 1024
		private string string_3;

		// Token: 0x04000401 RID: 1025
		private int int_3;

		// Token: 0x04000402 RID: 1026
		private int int_4;

		// Token: 0x04000403 RID: 1027
		private int int_5;

		// Token: 0x04000404 RID: 1028
		private int int_6;

		// Token: 0x04000405 RID: 1029
		private bool bool_1;

		// Token: 0x04000406 RID: 1030
		private LogicLong logicLong_3;
	}
}
