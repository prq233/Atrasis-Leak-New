using System;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Message.Alliance.Stream
{
	// Token: 0x020000DB RID: 219
	public class BaseBuilderBattleReplayStreamEntry : StreamEntry
	{
		// Token: 0x0600095C RID: 2396 RVA: 0x000220B4 File Offset: 0x000202B4
		public override void Encode(ByteStream stream)
		{
			base.Encode(stream);
			stream.WriteInt(this.int_3);
			stream.WriteInt(this.int_5);
			stream.WriteInt(this.int_6);
			stream.WriteInt(this.int_4);
			stream.WriteInt(this.int_7);
			stream.WriteInt(this.int_8);
			stream.WriteString(this.string_3);
			if (this.logicLong_6 != null)
			{
				stream.WriteBoolean(true);
				stream.WriteLong(this.logicLong_6);
				stream.WriteInt(this.int_9);
				stream.WriteInt(this.int_11);
				stream.WriteInt(this.int_12);
				stream.WriteInt(this.int_13);
			}
			else
			{
				stream.WriteBoolean(false);
			}
			if (this.logicLong_7 != null)
			{
				stream.WriteBoolean(true);
				stream.WriteLong(this.logicLong_7);
				stream.WriteInt(this.int_10);
				stream.WriteInt(this.int_14);
				stream.WriteInt(this.int_15);
				stream.WriteInt(this.int_16);
			}
			else
			{
				stream.WriteBoolean(false);
			}
			stream.WriteLong(this.logicLong_3);
			stream.WriteString(this.string_1);
			stream.WriteString(this.string_2);
		}

		// Token: 0x0600095D RID: 2397 RVA: 0x000221E8 File Offset: 0x000203E8
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
			this.int_3 = stream.ReadInt();
			this.int_5 = stream.ReadInt();
			this.int_6 = stream.ReadInt();
			this.int_4 = stream.ReadInt();
			this.int_7 = stream.ReadInt();
			this.int_8 = stream.ReadInt();
			this.string_3 = stream.ReadString(900000);
			if (stream.ReadBoolean())
			{
				this.logicLong_6 = stream.ReadLong();
				this.int_9 = stream.ReadInt();
				this.int_11 = stream.ReadInt();
				this.int_12 = stream.ReadInt();
				this.int_13 = stream.ReadInt();
			}
			if (stream.ReadBoolean())
			{
				this.logicLong_7 = stream.ReadLong();
				this.int_10 = stream.ReadInt();
				this.int_14 = stream.ReadInt();
				this.int_15 = stream.ReadInt();
				this.int_16 = stream.ReadInt();
			}
			this.logicLong_3 = stream.ReadLong();
			this.string_1 = stream.ReadString(900000);
			this.string_2 = stream.ReadString(900000);
		}

		// Token: 0x0600095E RID: 2398 RVA: 0x0000759D File Offset: 0x0000579D
		public string GetOpponentName()
		{
			return this.string_3;
		}

		// Token: 0x0600095F RID: 2399 RVA: 0x000075A5 File Offset: 0x000057A5
		public void SetOpponentName(string value)
		{
			this.string_3 = value;
		}

		// Token: 0x06000960 RID: 2400 RVA: 0x000075AE File Offset: 0x000057AE
		public LogicLong GetMatchId()
		{
			return this.logicLong_3;
		}

		// Token: 0x06000961 RID: 2401 RVA: 0x000075B6 File Offset: 0x000057B6
		public void SetMatchId(LogicLong value)
		{
			this.logicLong_3 = value;
		}

		// Token: 0x06000962 RID: 2402 RVA: 0x000075BF File Offset: 0x000057BF
		public int GetAttackerBattleStatus()
		{
			return this.int_3;
		}

		// Token: 0x06000963 RID: 2403 RVA: 0x000075C7 File Offset: 0x000057C7
		public void SetAttackerBattleStatus(int value)
		{
			this.int_3 = value;
		}

		// Token: 0x06000964 RID: 2404 RVA: 0x000075D0 File Offset: 0x000057D0
		public int GetOpponentBattleStatus()
		{
			return this.int_4;
		}

		// Token: 0x06000965 RID: 2405 RVA: 0x000075D8 File Offset: 0x000057D8
		public void SetOpponentBattleStatus(int value)
		{
			this.int_4 = value;
		}

		// Token: 0x06000966 RID: 2406 RVA: 0x000075E1 File Offset: 0x000057E1
		public int GetAttackerStars()
		{
			return this.int_5;
		}

		// Token: 0x06000967 RID: 2407 RVA: 0x000075E9 File Offset: 0x000057E9
		public void SetAttackerStars(int value)
		{
			this.int_5 = value;
		}

		// Token: 0x06000968 RID: 2408 RVA: 0x000075F2 File Offset: 0x000057F2
		public int GetAttackerDestructionPercentage()
		{
			return this.int_6;
		}

		// Token: 0x06000969 RID: 2409 RVA: 0x000075FA File Offset: 0x000057FA
		public void SetAttackerDestructionPercentage(int value)
		{
			this.int_6 = value;
		}

		// Token: 0x0600096A RID: 2410 RVA: 0x00007603 File Offset: 0x00005803
		public int GetOpponentStars()
		{
			return this.int_7;
		}

		// Token: 0x0600096B RID: 2411 RVA: 0x0000760B File Offset: 0x0000580B
		public void SetOpponentStars(int value)
		{
			this.int_7 = value;
		}

		// Token: 0x0600096C RID: 2412 RVA: 0x00007614 File Offset: 0x00005814
		public int GetOpponentDestructionPercentage()
		{
			return this.int_8;
		}

		// Token: 0x0600096D RID: 2413 RVA: 0x0000761C File Offset: 0x0000581C
		public void SetOpponentDestructionPercentage(int value)
		{
			this.int_8 = value;
		}

		// Token: 0x0600096E RID: 2414 RVA: 0x00007625 File Offset: 0x00005825
		public int GetAttackerReplayShardId()
		{
			return this.int_9;
		}

		// Token: 0x0600096F RID: 2415 RVA: 0x0000762D File Offset: 0x0000582D
		public void SetAttackerReplayShardId(int value)
		{
			this.int_9 = value;
		}

		// Token: 0x06000970 RID: 2416 RVA: 0x00007636 File Offset: 0x00005836
		public int GetOpponentReplayShardId()
		{
			return this.int_10;
		}

		// Token: 0x06000971 RID: 2417 RVA: 0x0000763E File Offset: 0x0000583E
		public void SetOpponentReplayShardId(int value)
		{
			this.int_10 = value;
		}

		// Token: 0x06000972 RID: 2418 RVA: 0x00007647 File Offset: 0x00005847
		public int GetAttackerReplayMajorVersion()
		{
			return this.int_11;
		}

		// Token: 0x06000973 RID: 2419 RVA: 0x0000764F File Offset: 0x0000584F
		public void SetAttackerReplayMajorVersion(int value)
		{
			this.int_11 = value;
		}

		// Token: 0x06000974 RID: 2420 RVA: 0x00007658 File Offset: 0x00005858
		public int GetAttackerReplayBuildVersion()
		{
			return this.int_12;
		}

		// Token: 0x06000975 RID: 2421 RVA: 0x00007660 File Offset: 0x00005860
		public void SetAttackerReplayBuildVersion(int value)
		{
			this.int_12 = value;
		}

		// Token: 0x06000976 RID: 2422 RVA: 0x00007669 File Offset: 0x00005869
		public int GetAttackerReplayContentVersion()
		{
			return this.int_13;
		}

		// Token: 0x06000977 RID: 2423 RVA: 0x00007671 File Offset: 0x00005871
		public void SetAttackerReplayContentVersion(int value)
		{
			this.int_13 = value;
		}

		// Token: 0x06000978 RID: 2424 RVA: 0x0000767A File Offset: 0x0000587A
		public int GetOpponentReplayMajorVersion()
		{
			return this.int_14;
		}

		// Token: 0x06000979 RID: 2425 RVA: 0x00007682 File Offset: 0x00005882
		public void SetOpponentReplayMajorVersion(int value)
		{
			this.int_14 = value;
		}

		// Token: 0x0600097A RID: 2426 RVA: 0x0000768B File Offset: 0x0000588B
		public int GetOpponentReplayBuildVersion()
		{
			return this.int_15;
		}

		// Token: 0x0600097B RID: 2427 RVA: 0x00007693 File Offset: 0x00005893
		public void SetOpponentReplayBuildVersion(int value)
		{
			this.int_15 = value;
		}

		// Token: 0x0600097C RID: 2428 RVA: 0x0000769C File Offset: 0x0000589C
		public int GetOpponentReplayContentVersion()
		{
			return this.int_16;
		}

		// Token: 0x0600097D RID: 2429 RVA: 0x000076A4 File Offset: 0x000058A4
		public void SetOpponentReplayContentVersion(int value)
		{
			this.int_16 = value;
		}

		// Token: 0x0600097E RID: 2430 RVA: 0x000076AD File Offset: 0x000058AD
		public LogicLong GetAttackerReplayId()
		{
			return this.logicLong_6;
		}

		// Token: 0x0600097F RID: 2431 RVA: 0x000076B5 File Offset: 0x000058B5
		public void SetAttackerReplayId(LogicLong value)
		{
			this.logicLong_6 = value;
		}

		// Token: 0x06000980 RID: 2432 RVA: 0x000076BE File Offset: 0x000058BE
		public LogicLong GetOpponentReplayId()
		{
			return this.logicLong_7;
		}

		// Token: 0x06000981 RID: 2433 RVA: 0x000076C6 File Offset: 0x000058C6
		public void SetOpponentReplayId(LogicLong value)
		{
			this.logicLong_7 = value;
		}

		// Token: 0x06000982 RID: 2434 RVA: 0x000076CF File Offset: 0x000058CF
		public string GetAttackerBattleLog()
		{
			return this.string_1;
		}

		// Token: 0x06000983 RID: 2435 RVA: 0x000076D7 File Offset: 0x000058D7
		public void SetAttackerBattleLog(string value)
		{
			this.string_1 = value;
		}

		// Token: 0x06000984 RID: 2436 RVA: 0x000076E0 File Offset: 0x000058E0
		public string GetOpponentBattleLog()
		{
			return this.string_2;
		}

		// Token: 0x06000985 RID: 2437 RVA: 0x000076E8 File Offset: 0x000058E8
		public void SetOpponentBattleLog(string value)
		{
			this.string_2 = value;
		}

		// Token: 0x06000986 RID: 2438 RVA: 0x000076F1 File Offset: 0x000058F1
		public LogicLong GetAttackerLiveReplayId()
		{
			return this.logicLong_4;
		}

		// Token: 0x06000987 RID: 2439 RVA: 0x000076F9 File Offset: 0x000058F9
		public void SetAttackerLiveReplayId(LogicLong value)
		{
			this.logicLong_4 = value;
		}

		// Token: 0x06000988 RID: 2440 RVA: 0x00007702 File Offset: 0x00005902
		public LogicLong GetOpponentLiveReplayId()
		{
			return this.logicLong_5;
		}

		// Token: 0x06000989 RID: 2441 RVA: 0x0000770A File Offset: 0x0000590A
		public void SetOpponentLiveReplayId(LogicLong value)
		{
			this.logicLong_5 = value;
		}

		// Token: 0x0600098A RID: 2442 RVA: 0x00007713 File Offset: 0x00005913
		public override StreamEntryType GetStreamEntryType()
		{
			return StreamEntryType.BASE_BUILDER_BATTLE_REPLAY;
		}

		// Token: 0x0600098B RID: 2443 RVA: 0x0002230C File Offset: 0x0002050C
		public override void Load(LogicJSONObject jsonObject)
		{
			LogicJSONObject jsonobject = jsonObject.GetJSONObject("base");
			if (jsonobject == null)
			{
				Debugger.Error("BaseBuilderBattleReplayStreamEntry::load base is NULL");
			}
			base.Load(jsonobject);
			this.logicLong_3 = new LogicLong(jsonObject.GetJSONNumber("match_id_hi").GetIntValue(), jsonObject.GetJSONNumber("match_id_lo").GetIntValue());
			this.int_3 = jsonObject.GetJSONNumber("attacker_state").GetIntValue();
			this.int_5 = jsonObject.GetJSONNumber("attacker_stars").GetIntValue();
			this.int_6 = jsonObject.GetJSONNumber("attacker_destruction_percentage").GetIntValue();
			this.int_4 = jsonObject.GetJSONNumber("opponent_state").GetIntValue();
			this.int_7 = jsonObject.GetJSONNumber("opponent_stars").GetIntValue();
			this.int_8 = jsonObject.GetJSONNumber("opponent_destruction_percentage").GetIntValue();
			this.string_3 = jsonObject.GetJSONString("opponent_name").GetStringValue();
			LogicJSONNumber jsonnumber = jsonObject.GetJSONNumber("attacker_replay_id_hi");
			if (jsonnumber != null)
			{
				this.logicLong_6 = new LogicLong(jsonnumber.GetIntValue(), jsonObject.GetJSONNumber("attacker_replay_id_lo").GetIntValue());
				this.int_9 = jsonObject.GetJSONNumber("attacker_replay_shard_id").GetIntValue();
				this.int_11 = jsonObject.GetJSONNumber("attacker_replay_major_v").GetIntValue();
				this.int_12 = jsonObject.GetJSONNumber("attacker_replay_build_v").GetIntValue();
				this.int_13 = jsonObject.GetJSONNumber("attacker_replay_content_v").GetIntValue();
			}
			LogicJSONNumber jsonnumber2 = jsonObject.GetJSONNumber("opponent_replay_id_hi");
			if (jsonnumber2 != null)
			{
				this.logicLong_7 = new LogicLong(jsonnumber2.GetIntValue(), jsonObject.GetJSONNumber("opponent_replay_id_lo").GetIntValue());
				this.int_10 = jsonObject.GetJSONNumber("opponent_replay_shard_id").GetIntValue();
				this.int_14 = jsonObject.GetJSONNumber("opponent_replay_major_v").GetIntValue();
				this.int_15 = jsonObject.GetJSONNumber("opponent_replay_build_v").GetIntValue();
				this.int_16 = jsonObject.GetJSONNumber("opponent_replay_content_v").GetIntValue();
			}
			this.string_1 = jsonObject.GetJSONString("attacker_battleLog").GetStringValue();
			this.string_2 = jsonObject.GetJSONString("opponent_battleLog").GetStringValue();
		}

		// Token: 0x0600098C RID: 2444 RVA: 0x0002253C File Offset: 0x0002073C
		public override void Save(LogicJSONObject jsonObject)
		{
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			base.Save(logicJSONObject);
			jsonObject.Put("base", logicJSONObject);
			jsonObject.Put("match_id_hi", new LogicJSONNumber(this.logicLong_3.GetHigherInt()));
			jsonObject.Put("match_id_lo", new LogicJSONNumber(this.logicLong_3.GetLowerInt()));
			jsonObject.Put("attacker_state", new LogicJSONNumber(this.int_3));
			jsonObject.Put("attacker_stars", new LogicJSONNumber(this.int_5));
			jsonObject.Put("attacker_destruction_percentage", new LogicJSONNumber(this.int_6));
			jsonObject.Put("opponent_state", new LogicJSONNumber(this.int_4));
			jsonObject.Put("opponent_stars", new LogicJSONNumber(this.int_7));
			jsonObject.Put("opponent_destruction_percentage", new LogicJSONNumber(this.int_8));
			jsonObject.Put("opponent_name", new LogicJSONString(this.string_3));
			if (this.logicLong_6 != null)
			{
				jsonObject.Put("attacker_replay_id_hi", new LogicJSONNumber(this.logicLong_6.GetHigherInt()));
				jsonObject.Put("attacker_replay_id_lo", new LogicJSONNumber(this.logicLong_6.GetLowerInt()));
				jsonObject.Put("attacker_replay_shard_id", new LogicJSONNumber(this.int_9));
				jsonObject.Put("attacker_replay_major_v", new LogicJSONNumber(this.int_11));
				jsonObject.Put("attacker_replay_build_v", new LogicJSONNumber(this.int_12));
				jsonObject.Put("attacker_replay_content_v", new LogicJSONNumber(this.int_13));
			}
			if (this.logicLong_7 != null)
			{
				jsonObject.Put("opponent_replay_id_hi", new LogicJSONNumber(this.logicLong_7.GetHigherInt()));
				jsonObject.Put("opponent_replay_id_lo", new LogicJSONNumber(this.logicLong_7.GetLowerInt()));
				jsonObject.Put("opponent_replay_shard_id", new LogicJSONNumber(this.int_10));
				jsonObject.Put("opponent_replay_major_v", new LogicJSONNumber(this.int_14));
				jsonObject.Put("opponent_replay_build_v", new LogicJSONNumber(this.int_15));
				jsonObject.Put("opponent_replay_content_v", new LogicJSONNumber(this.int_16));
			}
			jsonObject.Put("attacker_battleLog", new LogicJSONString(this.string_1));
			jsonObject.Put("opponent_battleLog", new LogicJSONString(this.string_2));
		}

		// Token: 0x040003AC RID: 940
		private LogicLong logicLong_3;

		// Token: 0x040003AD RID: 941
		private LogicLong logicLong_4;

		// Token: 0x040003AE RID: 942
		private LogicLong logicLong_5;

		// Token: 0x040003AF RID: 943
		private int int_3;

		// Token: 0x040003B0 RID: 944
		private int int_4;

		// Token: 0x040003B1 RID: 945
		private int int_5;

		// Token: 0x040003B2 RID: 946
		private int int_6;

		// Token: 0x040003B3 RID: 947
		private int int_7;

		// Token: 0x040003B4 RID: 948
		private int int_8;

		// Token: 0x040003B5 RID: 949
		private int int_9;

		// Token: 0x040003B6 RID: 950
		private int int_10;

		// Token: 0x040003B7 RID: 951
		private int int_11;

		// Token: 0x040003B8 RID: 952
		private int int_12;

		// Token: 0x040003B9 RID: 953
		private int int_13;

		// Token: 0x040003BA RID: 954
		private int int_14;

		// Token: 0x040003BB RID: 955
		private int int_15;

		// Token: 0x040003BC RID: 956
		private int int_16;

		// Token: 0x040003BD RID: 957
		private LogicLong logicLong_6;

		// Token: 0x040003BE RID: 958
		private LogicLong logicLong_7;

		// Token: 0x040003BF RID: 959
		private string string_1;

		// Token: 0x040003C0 RID: 960
		private string string_2;

		// Token: 0x040003C1 RID: 961
		private string string_3;
	}
}
