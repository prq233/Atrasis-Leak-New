using System;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Message.Alliance.Stream
{
	// Token: 0x020000E3 RID: 227
	public class DuelReplayStreamEntry : StreamEntry
	{
		// Token: 0x06000A0B RID: 2571 RVA: 0x00007B00 File Offset: 0x00005D00
		public DuelReplayStreamEntry()
		{
			this.int_8 = -1;
			this.int_10 = -1;
		}

		// Token: 0x06000A0C RID: 2572 RVA: 0x00023B1C File Offset: 0x00021D1C
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
			this.int_3 = stream.ReadInt();
			this.int_4 = stream.ReadInt();
			this.int_5 = stream.ReadInt();
			this.int_6 = stream.ReadInt();
			stream.ReadInt();
			this.string_2 = stream.ReadString(900000);
			if (stream.ReadBoolean())
			{
				this.string_1 = stream.ReadString(900000);
				this.int_7 = stream.ReadInt();
				this.int_8 = stream.ReadInt();
			}
			if (stream.ReadBoolean())
			{
				this.string_3 = stream.ReadString(900000);
				this.int_9 = stream.ReadInt();
				this.int_10 = stream.ReadInt();
				this.logicLong_3 = stream.ReadLong();
			}
			if (stream.ReadBoolean())
			{
				this.logicLong_6 = stream.ReadLong();
				this.int_11 = stream.ReadInt();
				this.int_13 = stream.ReadInt();
				this.int_14 = stream.ReadInt();
				this.int_15 = stream.ReadInt();
			}
			if (stream.ReadBoolean())
			{
				this.logicLong_7 = stream.ReadLong();
				this.int_12 = stream.ReadInt();
				this.int_16 = stream.ReadInt();
				this.int_17 = stream.ReadInt();
				this.int_18 = stream.ReadInt();
				if (stream.ReadBoolean())
				{
					this.logicLong_5 = stream.ReadLong();
				}
				if (stream.ReadBoolean())
				{
					this.logicLong_4 = stream.ReadLong();
				}
			}
		}

		// Token: 0x06000A0D RID: 2573 RVA: 0x00023C98 File Offset: 0x00021E98
		public override void Encode(ByteStream stream)
		{
			base.Encode(stream);
			stream.WriteInt(this.int_3);
			stream.WriteInt(this.int_4);
			stream.WriteInt(this.int_5);
			stream.WriteInt(this.int_6);
			stream.WriteInt(-1);
			stream.WriteString(this.string_2);
			if (this.string_1 != null)
			{
				stream.WriteBoolean(true);
				stream.WriteString(this.string_1);
				stream.WriteInt(this.int_8);
				stream.WriteInt(this.int_7);
			}
			else
			{
				stream.WriteBoolean(false);
			}
			if (this.logicLong_3 != null)
			{
				stream.WriteBoolean(true);
				stream.WriteString(this.string_3);
				stream.WriteInt(this.int_10);
				stream.WriteInt(this.int_9);
				stream.WriteLong(this.logicLong_3);
			}
			else
			{
				stream.WriteBoolean(false);
			}
			if (this.logicLong_6 != null)
			{
				stream.WriteBoolean(true);
				stream.WriteLong(this.logicLong_6);
				stream.WriteInt(this.int_11);
				stream.WriteInt(this.int_13);
				stream.WriteInt(this.int_14);
				stream.WriteInt(this.int_15);
			}
			else
			{
				stream.WriteBoolean(false);
			}
			if (this.logicLong_7 == null)
			{
				stream.WriteBoolean(false);
				return;
			}
			stream.WriteBoolean(true);
			stream.WriteLong(this.logicLong_7);
			stream.WriteInt(this.int_12);
			stream.WriteInt(this.int_16);
			stream.WriteInt(this.int_17);
			stream.WriteInt(this.int_18);
			if (this.logicLong_5 != null)
			{
				stream.WriteBoolean(true);
				stream.WriteLong(this.logicLong_5);
			}
			else
			{
				stream.WriteBoolean(false);
			}
			if (this.logicLong_4 != null)
			{
				stream.WriteBoolean(true);
				stream.WriteLong(this.logicLong_4);
				return;
			}
			stream.WriteBoolean(false);
		}

		// Token: 0x06000A0E RID: 2574 RVA: 0x00007B16 File Offset: 0x00005D16
		public LogicLong GetOpponentAllianceId()
		{
			return this.logicLong_3;
		}

		// Token: 0x06000A0F RID: 2575 RVA: 0x00007B1E File Offset: 0x00005D1E
		public void SetOpponentAllianceId(LogicLong value)
		{
			this.logicLong_3 = value;
		}

		// Token: 0x06000A10 RID: 2576 RVA: 0x00007B27 File Offset: 0x00005D27
		public int GetAttackerStars()
		{
			return this.int_3;
		}

		// Token: 0x06000A11 RID: 2577 RVA: 0x00007B2F File Offset: 0x00005D2F
		public void SetAttackerStars(int value)
		{
			this.int_3 = value;
		}

		// Token: 0x06000A12 RID: 2578 RVA: 0x00007B38 File Offset: 0x00005D38
		public int GetAttackerDestructionPercentage()
		{
			return this.int_4;
		}

		// Token: 0x06000A13 RID: 2579 RVA: 0x00007B40 File Offset: 0x00005D40
		public void SetAttackerDestructionPercentage(int value)
		{
			this.int_4 = value;
		}

		// Token: 0x06000A14 RID: 2580 RVA: 0x00007B49 File Offset: 0x00005D49
		public int GetOpponentStars()
		{
			return this.int_5;
		}

		// Token: 0x06000A15 RID: 2581 RVA: 0x00007B51 File Offset: 0x00005D51
		public void SetOpponentStars(int value)
		{
			this.int_5 = value;
		}

		// Token: 0x06000A16 RID: 2582 RVA: 0x00007B5A File Offset: 0x00005D5A
		public int GetOpponentDestructionPercentage()
		{
			return this.int_6;
		}

		// Token: 0x06000A17 RID: 2583 RVA: 0x00007B62 File Offset: 0x00005D62
		public void SetOpponentDestructionPercentage(int value)
		{
			this.int_6 = value;
		}

		// Token: 0x06000A18 RID: 2584 RVA: 0x00007B6B File Offset: 0x00005D6B
		public string GetAttackerAllianceName()
		{
			return this.string_1;
		}

		// Token: 0x06000A19 RID: 2585 RVA: 0x00007B73 File Offset: 0x00005D73
		public void SetAttackerAllianceName(string value)
		{
			this.string_1 = value;
		}

		// Token: 0x06000A1A RID: 2586 RVA: 0x00007B7C File Offset: 0x00005D7C
		public string GetOpponentName()
		{
			return this.string_2;
		}

		// Token: 0x06000A1B RID: 2587 RVA: 0x00007B84 File Offset: 0x00005D84
		public void SetOpponentName(string value)
		{
			this.string_2 = value;
		}

		// Token: 0x06000A1C RID: 2588 RVA: 0x00007B8D File Offset: 0x00005D8D
		public string GetOpponentAllianceName()
		{
			return this.string_3;
		}

		// Token: 0x06000A1D RID: 2589 RVA: 0x00007B95 File Offset: 0x00005D95
		public void SetOpponentAllianceName(string value)
		{
			this.string_3 = value;
		}

		// Token: 0x06000A1E RID: 2590 RVA: 0x00007B9E File Offset: 0x00005D9E
		public int GetAttackerAllianceLevel()
		{
			return this.int_7;
		}

		// Token: 0x06000A1F RID: 2591 RVA: 0x00007BA6 File Offset: 0x00005DA6
		public void SetAttackerAllianceLevel(int value)
		{
			this.int_7 = value;
		}

		// Token: 0x06000A20 RID: 2592 RVA: 0x00007BAF File Offset: 0x00005DAF
		public int GetAttackerAllianceBadgeId()
		{
			return this.int_8;
		}

		// Token: 0x06000A21 RID: 2593 RVA: 0x00007BB7 File Offset: 0x00005DB7
		public void SetAttackerAllianceBadgeId(int value)
		{
			this.int_8 = value;
		}

		// Token: 0x06000A22 RID: 2594 RVA: 0x00007BC0 File Offset: 0x00005DC0
		public int GetOpponentAllianceLevel()
		{
			return this.int_9;
		}

		// Token: 0x06000A23 RID: 2595 RVA: 0x00007BC8 File Offset: 0x00005DC8
		public void SetOpponentAllianceLevel(int value)
		{
			this.int_9 = value;
		}

		// Token: 0x06000A24 RID: 2596 RVA: 0x00007BD1 File Offset: 0x00005DD1
		public int GetOpponentAllianceBadgeId()
		{
			return this.int_10;
		}

		// Token: 0x06000A25 RID: 2597 RVA: 0x00007BD9 File Offset: 0x00005DD9
		public void SetOpponentAllianceBadgeId(int value)
		{
			this.int_10 = value;
		}

		// Token: 0x06000A26 RID: 2598 RVA: 0x00007BE2 File Offset: 0x00005DE2
		public int GetAttackerReplayShardId()
		{
			return this.int_11;
		}

		// Token: 0x06000A27 RID: 2599 RVA: 0x00007BEA File Offset: 0x00005DEA
		public void SetAttackerReplayShardId(int value)
		{
			this.int_11 = value;
		}

		// Token: 0x06000A28 RID: 2600 RVA: 0x00007BF3 File Offset: 0x00005DF3
		public int GetOpponentReplayShardId()
		{
			return this.int_12;
		}

		// Token: 0x06000A29 RID: 2601 RVA: 0x00007BFB File Offset: 0x00005DFB
		public void SetOpponentReplayShardId(int value)
		{
			this.int_12 = value;
		}

		// Token: 0x06000A2A RID: 2602 RVA: 0x00007C04 File Offset: 0x00005E04
		public int GetAttackerReplayMajorVersion()
		{
			return this.int_13;
		}

		// Token: 0x06000A2B RID: 2603 RVA: 0x00007C0C File Offset: 0x00005E0C
		public void SetAttackerReplayMajorVersion(int value)
		{
			this.int_13 = value;
		}

		// Token: 0x06000A2C RID: 2604 RVA: 0x00007C15 File Offset: 0x00005E15
		public int GetAttackerReplayBuildVersion()
		{
			return this.int_14;
		}

		// Token: 0x06000A2D RID: 2605 RVA: 0x00007C1D File Offset: 0x00005E1D
		public void SetAttackerReplayBuildVersion(int value)
		{
			this.int_14 = value;
		}

		// Token: 0x06000A2E RID: 2606 RVA: 0x00007C26 File Offset: 0x00005E26
		public int GetAttackerReplayContentVersion()
		{
			return this.int_15;
		}

		// Token: 0x06000A2F RID: 2607 RVA: 0x00007C2E File Offset: 0x00005E2E
		public void SetAttackerReplayContentVersion(int value)
		{
			this.int_15 = value;
		}

		// Token: 0x06000A30 RID: 2608 RVA: 0x00007C37 File Offset: 0x00005E37
		public int GetOpponentReplayMajorVersion()
		{
			return this.int_16;
		}

		// Token: 0x06000A31 RID: 2609 RVA: 0x00007C3F File Offset: 0x00005E3F
		public void SetOpponentReplayMajorVersion(int value)
		{
			this.int_16 = value;
		}

		// Token: 0x06000A32 RID: 2610 RVA: 0x00007C48 File Offset: 0x00005E48
		public int GetOpponentReplayBuildVersion()
		{
			return this.int_17;
		}

		// Token: 0x06000A33 RID: 2611 RVA: 0x00007C50 File Offset: 0x00005E50
		public void SetOpponentReplayBuildVersion(int value)
		{
			this.int_17 = value;
		}

		// Token: 0x06000A34 RID: 2612 RVA: 0x00007C59 File Offset: 0x00005E59
		public int GetOpponentReplayContentVersion()
		{
			return this.int_18;
		}

		// Token: 0x06000A35 RID: 2613 RVA: 0x00007C61 File Offset: 0x00005E61
		public void SetOpponentReplayContentVersion(int value)
		{
			this.int_18 = value;
		}

		// Token: 0x06000A36 RID: 2614 RVA: 0x00007C6A File Offset: 0x00005E6A
		public LogicLong GetAttackerReplayId()
		{
			return this.logicLong_6;
		}

		// Token: 0x06000A37 RID: 2615 RVA: 0x00007C72 File Offset: 0x00005E72
		public void SetAttackerReplayId(LogicLong value)
		{
			this.logicLong_6 = value;
		}

		// Token: 0x06000A38 RID: 2616 RVA: 0x00007C7B File Offset: 0x00005E7B
		public LogicLong GetOpponentReplayId()
		{
			return this.logicLong_7;
		}

		// Token: 0x06000A39 RID: 2617 RVA: 0x00007C83 File Offset: 0x00005E83
		public void SetOpponentReplayId(LogicLong value)
		{
			this.logicLong_7 = value;
		}

		// Token: 0x06000A3A RID: 2618 RVA: 0x00007C8C File Offset: 0x00005E8C
		public LogicLong GetOpponentAvatarId()
		{
			return this.logicLong_4;
		}

		// Token: 0x06000A3B RID: 2619 RVA: 0x00007C94 File Offset: 0x00005E94
		public void SetOpponentAvatarId(LogicLong value)
		{
			this.logicLong_4 = value;
		}

		// Token: 0x06000A3C RID: 2620 RVA: 0x00007C9D File Offset: 0x00005E9D
		public LogicLong GetOpponentHomeId()
		{
			return this.logicLong_5;
		}

		// Token: 0x06000A3D RID: 2621 RVA: 0x00007CA5 File Offset: 0x00005EA5
		public void SetOpponentHomeId(LogicLong value)
		{
			this.logicLong_5 = value;
		}

		// Token: 0x06000A3E RID: 2622 RVA: 0x00007CAE File Offset: 0x00005EAE
		public override StreamEntryType GetStreamEntryType()
		{
			return StreamEntryType.DUEL_REPLAY;
		}

		// Token: 0x06000A3F RID: 2623 RVA: 0x00023E64 File Offset: 0x00022064
		public override void Load(LogicJSONObject jsonObject)
		{
			LogicJSONObject jsonobject = jsonObject.GetJSONObject("base");
			if (jsonobject == null)
			{
				Debugger.Error("ReplayBattleReplayStreamEntry::load base is NULL");
			}
			base.Load(jsonobject);
			this.int_3 = jsonObject.GetJSONNumber("attacker_stars").GetIntValue();
			this.int_4 = jsonObject.GetJSONNumber("attacker_destruction_percentage").GetIntValue();
			this.int_5 = jsonObject.GetJSONNumber("opponent_stars").GetIntValue();
			this.int_6 = jsonObject.GetJSONNumber("opponent_destruction_percentage").GetIntValue();
			this.string_2 = jsonObject.GetJSONString("opponent_name").GetStringValue();
			LogicJSONObject jsonobject2 = jsonObject.GetJSONObject("attacker_alliance");
			if (jsonobject2 != null)
			{
				this.string_1 = jsonobject2.GetJSONString("name").GetStringValue();
				this.int_7 = jsonobject2.GetJSONNumber("level").GetIntValue();
				this.int_8 = jsonobject2.GetJSONNumber("badge_id").GetIntValue();
			}
			LogicJSONObject jsonobject3 = jsonObject.GetJSONObject("opponent_alliance");
			if (jsonobject3 != null)
			{
				this.logicLong_3 = new LogicLong(jsonobject3.GetJSONNumber("id_hi").GetIntValue(), jsonobject3.GetJSONNumber("id_lo").GetIntValue());
				this.string_3 = jsonobject3.GetJSONString("name").GetStringValue();
				this.int_9 = jsonobject3.GetJSONNumber("level").GetIntValue();
				this.int_10 = jsonobject3.GetJSONNumber("badge_id").GetIntValue();
			}
			LogicJSONNumber jsonnumber = jsonObject.GetJSONNumber("attacker_replay_id_hi");
			if (jsonnumber != null)
			{
				this.logicLong_6 = new LogicLong(jsonnumber.GetIntValue(), jsonObject.GetJSONNumber("attacker_replay_id_lo").GetIntValue());
				this.int_11 = jsonObject.GetJSONNumber("attacker_replay_shard_id").GetIntValue();
				this.int_13 = jsonObject.GetJSONNumber("attacker_replay_major_v").GetIntValue();
				this.int_14 = jsonObject.GetJSONNumber("attacker_replay_build_v").GetIntValue();
				this.int_15 = jsonObject.GetJSONNumber("attacker_replay_content_v").GetIntValue();
			}
			LogicJSONNumber jsonnumber2 = jsonObject.GetJSONNumber("opponent_replay_id_hi");
			if (jsonnumber2 != null)
			{
				this.logicLong_7 = new LogicLong(jsonnumber2.GetIntValue(), jsonObject.GetJSONNumber("opponent_replay_id_lo").GetIntValue());
				this.int_12 = jsonObject.GetJSONNumber("opponent_replay_shard_id").GetIntValue();
				this.int_16 = jsonObject.GetJSONNumber("opponent_replay_major_v").GetIntValue();
				this.int_17 = jsonObject.GetJSONNumber("opponent_replay_build_v").GetIntValue();
				this.int_18 = jsonObject.GetJSONNumber("opponent_replay_content_v").GetIntValue();
				this.logicLong_5 = new LogicLong(jsonObject.GetJSONNumber("opponent_home_id_high").GetIntValue(), jsonObject.GetJSONNumber("opponent_home_id_low").GetIntValue());
				this.logicLong_4 = new LogicLong(jsonObject.GetJSONNumber("opponent_avatar_id_high").GetIntValue(), jsonObject.GetJSONNumber("opponent_avatar_id_low").GetIntValue());
			}
		}

		// Token: 0x06000A40 RID: 2624 RVA: 0x00024138 File Offset: 0x00022338
		public override void Save(LogicJSONObject jsonObject)
		{
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			base.Save(logicJSONObject);
			jsonObject.Put("base", logicJSONObject);
			jsonObject.Put("attacker_stars", new LogicJSONNumber(this.int_3));
			jsonObject.Put("attacker_destruction_percentage", new LogicJSONNumber(this.int_4));
			jsonObject.Put("opponent_stars", new LogicJSONNumber(this.int_5));
			jsonObject.Put("opponent_destruction_percentage", new LogicJSONNumber(this.int_6));
			jsonObject.Put("opponent_name", new LogicJSONString(this.string_2));
			if (this.string_1 != null)
			{
				LogicJSONObject logicJSONObject2 = new LogicJSONObject(3);
				logicJSONObject2.Put("name", new LogicJSONString(this.string_1));
				logicJSONObject2.Put("level", new LogicJSONNumber(this.int_7));
				logicJSONObject2.Put("badge_id", new LogicJSONNumber(this.int_8));
				jsonObject.Put("attacker_alliance", logicJSONObject2);
			}
			if (this.logicLong_3 != null)
			{
				LogicJSONObject logicJSONObject3 = new LogicJSONObject(5);
				logicJSONObject3.Put("id_hi", new LogicJSONNumber(this.logicLong_3.GetHigherInt()));
				logicJSONObject3.Put("id_lo", new LogicJSONNumber(this.logicLong_3.GetLowerInt()));
				logicJSONObject3.Put("name", new LogicJSONString(this.string_3));
				logicJSONObject3.Put("level", new LogicJSONNumber(this.int_9));
				logicJSONObject3.Put("badge_id", new LogicJSONNumber(this.int_10));
				jsonObject.Put("opponent_alliance", logicJSONObject3);
			}
			if (this.logicLong_6 != null)
			{
				jsonObject.Put("attacker_replay_id_hi", new LogicJSONNumber(this.logicLong_6.GetHigherInt()));
				jsonObject.Put("attacker_replay_id_lo", new LogicJSONNumber(this.logicLong_6.GetLowerInt()));
				jsonObject.Put("attacker_replay_shard_id", new LogicJSONNumber(this.int_11));
				jsonObject.Put("attacker_replay_major_v", new LogicJSONNumber(this.int_13));
				jsonObject.Put("attacker_replay_build_v", new LogicJSONNumber(this.int_14));
				jsonObject.Put("attacker_replay_content_v", new LogicJSONNumber(this.int_15));
			}
			if (this.logicLong_7 != null)
			{
				jsonObject.Put("opponent_replay_id_hi", new LogicJSONNumber(this.logicLong_7.GetHigherInt()));
				jsonObject.Put("opponent_replay_id_lo", new LogicJSONNumber(this.logicLong_7.GetLowerInt()));
				jsonObject.Put("opponent_replay_shard_id", new LogicJSONNumber(this.int_12));
				jsonObject.Put("opponent_replay_major_v", new LogicJSONNumber(this.int_16));
				jsonObject.Put("opponent_replay_build_v", new LogicJSONNumber(this.int_17));
				jsonObject.Put("opponent_replay_content_v", new LogicJSONNumber(this.int_18));
				jsonObject.Put("opponent_home_id_high", new LogicJSONNumber(this.logicLong_5.GetHigherInt()));
				jsonObject.Put("opponent_home_id_low", new LogicJSONNumber(this.logicLong_5.GetLowerInt()));
				jsonObject.Put("opponent_avatar_id_high", new LogicJSONNumber(this.logicLong_4.GetHigherInt()));
				jsonObject.Put("opponent_avatar_id_low", new LogicJSONNumber(this.logicLong_4.GetLowerInt()));
			}
		}

		// Token: 0x040003E3 RID: 995
		private LogicLong logicLong_3;

		// Token: 0x040003E4 RID: 996
		private LogicLong logicLong_4;

		// Token: 0x040003E5 RID: 997
		private LogicLong logicLong_5;

		// Token: 0x040003E6 RID: 998
		private int int_3;

		// Token: 0x040003E7 RID: 999
		private int int_4;

		// Token: 0x040003E8 RID: 1000
		private int int_5;

		// Token: 0x040003E9 RID: 1001
		private int int_6;

		// Token: 0x040003EA RID: 1002
		private string string_1;

		// Token: 0x040003EB RID: 1003
		private string string_2;

		// Token: 0x040003EC RID: 1004
		private string string_3;

		// Token: 0x040003ED RID: 1005
		private int int_7;

		// Token: 0x040003EE RID: 1006
		private int int_8;

		// Token: 0x040003EF RID: 1007
		private int int_9;

		// Token: 0x040003F0 RID: 1008
		private int int_10;

		// Token: 0x040003F1 RID: 1009
		private int int_11;

		// Token: 0x040003F2 RID: 1010
		private int int_12;

		// Token: 0x040003F3 RID: 1011
		private int int_13;

		// Token: 0x040003F4 RID: 1012
		private int int_14;

		// Token: 0x040003F5 RID: 1013
		private int int_15;

		// Token: 0x040003F6 RID: 1014
		private int int_16;

		// Token: 0x040003F7 RID: 1015
		private int int_17;

		// Token: 0x040003F8 RID: 1016
		private int int_18;

		// Token: 0x040003F9 RID: 1017
		private LogicLong logicLong_6;

		// Token: 0x040003FA RID: 1018
		private LogicLong logicLong_7;
	}
}
