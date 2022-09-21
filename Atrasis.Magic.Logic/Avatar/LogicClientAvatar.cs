using System;
using Atrasis.Magic.Logic.Calendar;
using Atrasis.Magic.Logic.Command;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.League.Entry;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Util;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Avatar
{
	// Token: 0x02000200 RID: 512
	public sealed class LogicClientAvatar : LogicAvatar
	{
		// Token: 0x06001A96 RID: 6806 RVA: 0x000656E8 File Offset: 0x000638E8
		public LogicClientAvatar()
		{
			this.logicAvatarTournamentEntry_0 = new LogicAvatarTournamentEntry();
			this.logicAvatarTournamentEntry_1 = new LogicAvatarTournamentEntry();
			this.int_3 = 1;
			this.m_allianceBadgeId = -1;
			this.int_20 = -1;
			this.int_11 = 1200;
			this.int_12 = 60;
			this.int_10 = 1;
			this.InitBase();
		}

		// Token: 0x06001A97 RID: 6807 RVA: 0x00065748 File Offset: 0x00063948
		public override void Destruct()
		{
			base.Destruct();
			if (this.logicAvatarTournamentEntry_0 != null)
			{
				this.logicAvatarTournamentEntry_0.Destruct();
				this.logicAvatarTournamentEntry_0 = null;
			}
			if (this.logicAvatarTournamentEntry_1 != null)
			{
				this.logicAvatarTournamentEntry_1.Destruct();
				this.logicAvatarTournamentEntry_1 = null;
			}
			this.logicLong_0 = null;
			this.logicLong_1 = null;
			this.logicLong_3 = null;
			this.logicLong_2 = null;
			this.string_1 = null;
			this.string_0 = null;
			this.string_2 = null;
		}

		// Token: 0x06001A98 RID: 6808 RVA: 0x0001176B File Offset: 0x0000F96B
		public override void InitBase()
		{
			base.InitBase();
			this.string_2 = string.Empty;
			this.logicLong_0 = new LogicLong();
			this.logicLong_1 = new LogicLong();
			this.logicLong_5 = new LogicLong();
		}

		// Token: 0x06001A99 RID: 6809 RVA: 0x000657C0 File Offset: 0x000639C0
		public override void GetChecksum(ChecksumHelper checksumHelper)
		{
			checksumHelper.StartObject("LogicClientAvatar");
			base.GetChecksum(checksumHelper);
			checksumHelper.WriteValue("m_expPoints", this.int_4);
			checksumHelper.WriteValue("m_expLevel", this.int_3);
			checksumHelper.WriteValue("m_diamonds", this.int_5);
			checksumHelper.WriteValue("m_freeDiamonds", this.int_6);
			checksumHelper.WriteValue("m_score", this.int_8);
			checksumHelper.WriteValue("m_duelScore", this.int_9);
			if (this.IsInAlliance())
			{
				checksumHelper.WriteValue("isInAlliance", 13);
			}
			checksumHelper.EndObject();
		}

		// Token: 0x06001A9A RID: 6810 RVA: 0x00065860 File Offset: 0x00063A60
		public static LogicClientAvatar GetDefaultAvatar()
		{
			LogicClientAvatar logicClientAvatar = new LogicClientAvatar();
			LogicGlobals globals = LogicDataTables.GetGlobals();
			logicClientAvatar.int_5 = globals.GetStartingDiamonds();
			logicClientAvatar.int_6 = globals.GetStartingDiamonds();
			logicClientAvatar.SetResourceCount(LogicDataTables.GetGoldData(), globals.GetStartingGold());
			logicClientAvatar.SetResourceCount(LogicDataTables.GetGold2Data(), globals.GetStartingGold2());
			logicClientAvatar.SetResourceCount(LogicDataTables.GetElixirData(), globals.GetStartingElixir());
			logicClientAvatar.SetResourceCount(LogicDataTables.GetElixir2Data(), globals.GetStartingElixir2());
			return logicClientAvatar;
		}

		// Token: 0x06001A9B RID: 6811 RVA: 0x00002B36 File Offset: 0x00000D36
		public override bool IsClientAvatar()
		{
			return true;
		}

		// Token: 0x06001A9C RID: 6812 RVA: 0x0001179F File Offset: 0x0000F99F
		public override LogicLong GetAllianceId()
		{
			return this.logicLong_2;
		}

		// Token: 0x06001A9D RID: 6813 RVA: 0x000117A7 File Offset: 0x0000F9A7
		public void SetAllianceId(LogicLong value)
		{
			this.logicLong_2 = value;
		}

		// Token: 0x06001A9E RID: 6814 RVA: 0x000117B0 File Offset: 0x0000F9B0
		public override string GetAllianceName()
		{
			return this.string_1;
		}

		// Token: 0x06001A9F RID: 6815 RVA: 0x000117B8 File Offset: 0x0000F9B8
		public void SetAllianceName(string value)
		{
			this.string_1 = value;
		}

		// Token: 0x06001AA0 RID: 6816 RVA: 0x000117C1 File Offset: 0x0000F9C1
		public override LogicAvatarAllianceRole GetAllianceRole()
		{
			return this.logicAvatarAllianceRole_0;
		}

		// Token: 0x06001AA1 RID: 6817 RVA: 0x000117C9 File Offset: 0x0000F9C9
		public void SetAllianceRole(LogicAvatarAllianceRole value)
		{
			this.logicAvatarAllianceRole_0 = value;
		}

		// Token: 0x06001AA2 RID: 6818 RVA: 0x000117D2 File Offset: 0x0000F9D2
		public override int GetAllianceBadgeId()
		{
			return this.m_allianceBadgeId;
		}

		// Token: 0x06001AA3 RID: 6819 RVA: 0x000117DA File Offset: 0x0000F9DA
		public void SetAllianceBadgeId(int value)
		{
			this.m_allianceBadgeId = value;
		}

		// Token: 0x06001AA4 RID: 6820 RVA: 0x000117E3 File Offset: 0x0000F9E3
		public int GetAllianceLevel()
		{
			return this.int_0;
		}

		// Token: 0x06001AA5 RID: 6821 RVA: 0x000117EB File Offset: 0x0000F9EB
		public void SetAllianceLevel(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x06001AA6 RID: 6822 RVA: 0x000117F4 File Offset: 0x0000F9F4
		public int GetWarPreference()
		{
			return this.int_10;
		}

		// Token: 0x06001AA7 RID: 6823 RVA: 0x000117FC File Offset: 0x0000F9FC
		public void SetWarPreference(int preference)
		{
			this.int_10 = preference;
		}

		// Token: 0x06001AA8 RID: 6824 RVA: 0x00011805 File Offset: 0x0000FA05
		public override bool IsInAlliance()
		{
			return this.logicLong_2 != null;
		}

		// Token: 0x06001AA9 RID: 6825 RVA: 0x00011810 File Offset: 0x0000FA10
		public override int GetExpLevel()
		{
			return this.int_3;
		}

		// Token: 0x06001AAA RID: 6826 RVA: 0x00011818 File Offset: 0x0000FA18
		public void SetExpLevel(int expLevel)
		{
			this.int_3 = expLevel;
		}

		// Token: 0x06001AAB RID: 6827 RVA: 0x00011821 File Offset: 0x0000FA21
		public int GetExpPoints()
		{
			return this.int_4;
		}

		// Token: 0x06001AAC RID: 6828 RVA: 0x00011829 File Offset: 0x0000FA29
		public void SetExpPoints(int expPoints)
		{
			this.int_4 = expPoints;
		}

		// Token: 0x06001AAD RID: 6829 RVA: 0x00011832 File Offset: 0x0000FA32
		public LogicLong GetId()
		{
			return this.logicLong_0;
		}

		// Token: 0x06001AAE RID: 6830 RVA: 0x0001183A File Offset: 0x0000FA3A
		public void SetId(LogicLong id)
		{
			this.logicLong_0 = id;
		}

		// Token: 0x06001AAF RID: 6831 RVA: 0x00011843 File Offset: 0x0000FA43
		public LogicLong GetCurrentHomeId()
		{
			return this.logicLong_1;
		}

		// Token: 0x06001AB0 RID: 6832 RVA: 0x0001184B File Offset: 0x0000FA4B
		public void SetCurrentHomeId(LogicLong id)
		{
			this.logicLong_1 = id;
		}

		// Token: 0x06001AB1 RID: 6833 RVA: 0x00011854 File Offset: 0x0000FA54
		public bool GetNameSetByUser()
		{
			return this.bool_0;
		}

		// Token: 0x06001AB2 RID: 6834 RVA: 0x0001185C File Offset: 0x0000FA5C
		public void SetNameSetByUser(bool set)
		{
			this.bool_0 = set;
		}

		// Token: 0x06001AB3 RID: 6835 RVA: 0x00011865 File Offset: 0x0000FA65
		public int GetNameChangeState()
		{
			return this.int_20;
		}

		// Token: 0x06001AB4 RID: 6836 RVA: 0x0001186D File Offset: 0x0000FA6D
		public void SetNameChangeState(int state)
		{
			this.int_20 = state;
		}

		// Token: 0x06001AB5 RID: 6837 RVA: 0x00011876 File Offset: 0x0000FA76
		public override string GetName()
		{
			return this.string_2;
		}

		// Token: 0x06001AB6 RID: 6838 RVA: 0x0001187E File Offset: 0x0000FA7E
		public void SetName(string name)
		{
			this.string_2 = name;
		}

		// Token: 0x06001AB7 RID: 6839 RVA: 0x00011887 File Offset: 0x0000FA87
		public string GetFacebookId()
		{
			return this.string_0;
		}

		// Token: 0x06001AB8 RID: 6840 RVA: 0x0001188F File Offset: 0x0000FA8F
		public void SetFacebookId(string facebookId)
		{
			this.string_0 = facebookId;
		}

		// Token: 0x06001AB9 RID: 6841 RVA: 0x00011898 File Offset: 0x0000FA98
		public bool GetAllianceChatFilterEnabled()
		{
			return this.bool_1;
		}

		// Token: 0x06001ABA RID: 6842 RVA: 0x000118A0 File Offset: 0x0000FAA0
		public void SetAllianceChatFilterEnabled(bool enabled)
		{
			this.bool_1 = enabled;
		}

		// Token: 0x06001ABB RID: 6843 RVA: 0x000118A9 File Offset: 0x0000FAA9
		public bool HasEnoughDiamonds(int count, bool callListener, LogicLevel level)
		{
			bool flag = this.int_5 >= count;
			if (!flag && callListener)
			{
				level.GetGameListener().NotEnoughDiamonds();
			}
			return flag;
		}

		// Token: 0x06001ABC RID: 6844 RVA: 0x000658D4 File Offset: 0x00063AD4
		public bool HasEnoughResources(LogicResourceData data, int count, bool callListener, LogicCommand command, bool unk)
		{
			bool flag = this.GetResourceCount(data) >= count;
			if (callListener && !flag && this.m_level != null)
			{
				this.m_level.GetGameListener().NotEnoughResources(data, count, command, unk);
			}
			return flag;
		}

		// Token: 0x06001ABD RID: 6845 RVA: 0x00065914 File Offset: 0x00063B14
		public bool HasEnoughResources(LogicResourceData data1, int count1, LogicResourceData data2, int count2, bool callListener, LogicCommand command, bool unk)
		{
			int resourceCount = this.GetResourceCount(data1);
			int resourceCount2 = this.GetResourceCount(data2);
			bool flag = resourceCount >= count1 && resourceCount2 >= count2;
			if (callListener && !flag && this.m_level != null)
			{
				if (resourceCount < count1 && resourceCount2 < count2)
				{
					this.m_level.GetGameListener().NotEnoughResources(data1, count1, data2, count2, command, unk);
				}
				else if (resourceCount >= count1)
				{
					if (resourceCount2 < count2)
					{
						this.m_level.GetGameListener().NotEnoughResources(data2, count2, command, unk);
					}
				}
				else
				{
					this.m_level.GetGameListener().NotEnoughResources(data1, count1, command, unk);
				}
			}
			return flag;
		}

		// Token: 0x06001ABE RID: 6846 RVA: 0x000118CA File Offset: 0x0000FACA
		public int GetDiamonds()
		{
			return this.int_5;
		}

		// Token: 0x06001ABF RID: 6847 RVA: 0x000118D2 File Offset: 0x0000FAD2
		public void SetDiamonds(int count)
		{
			this.int_5 = count;
		}

		// Token: 0x06001AC0 RID: 6848 RVA: 0x000118DB File Offset: 0x0000FADB
		public void UseDiamonds(int count)
		{
			this.int_5 -= count;
			if (this.int_6 > this.int_5)
			{
				this.int_6 = this.int_5;
			}
		}

		// Token: 0x06001AC1 RID: 6849 RVA: 0x00011905 File Offset: 0x0000FB05
		public int GetFreeDiamonds()
		{
			return this.int_6;
		}

		// Token: 0x06001AC2 RID: 6850 RVA: 0x0001190D File Offset: 0x0000FB0D
		public void SetFreeDiamonds(int count)
		{
			this.int_6 = count;
		}

		// Token: 0x06001AC3 RID: 6851 RVA: 0x00011916 File Offset: 0x0000FB16
		public void AddCumulativePurchasedDiamonds(int count)
		{
			this.int_7 += count;
		}

		// Token: 0x06001AC4 RID: 6852 RVA: 0x00011926 File Offset: 0x0000FB26
		public int GetCumulativePurchasedDiamonds()
		{
			return this.int_7;
		}

		// Token: 0x06001AC5 RID: 6853 RVA: 0x0001192E File Offset: 0x0000FB2E
		public int GetLeagueType()
		{
			return LogicMath.Clamp(this.m_leagueType, 0, LogicDataTables.GetTable(LogicDataType.LEAGUE).GetItemCount() - 1);
		}

		// Token: 0x06001AC6 RID: 6854 RVA: 0x0001194A File Offset: 0x0000FB4A
		public void SetLeagueType(int value)
		{
			this.m_leagueType = value;
		}

		// Token: 0x06001AC7 RID: 6855 RVA: 0x00011953 File Offset: 0x0000FB53
		public int GetAttackWinCount()
		{
			return this.int_13;
		}

		// Token: 0x06001AC8 RID: 6856 RVA: 0x0001195B File Offset: 0x0000FB5B
		public void SetAttackWinCount(int value)
		{
			this.int_13 = value;
		}

		// Token: 0x06001AC9 RID: 6857 RVA: 0x00011964 File Offset: 0x0000FB64
		public int GetAttackLoseCount()
		{
			return this.int_14;
		}

		// Token: 0x06001ACA RID: 6858 RVA: 0x0001196C File Offset: 0x0000FB6C
		public void SetAttackLoseCount(int value)
		{
			this.int_14 = value;
		}

		// Token: 0x06001ACB RID: 6859 RVA: 0x00011975 File Offset: 0x0000FB75
		public int GetDefenseWinCount()
		{
			return this.int_15;
		}

		// Token: 0x06001ACC RID: 6860 RVA: 0x0001197D File Offset: 0x0000FB7D
		public void SetDefenseWinCount(int value)
		{
			this.int_15 = value;
		}

		// Token: 0x06001ACD RID: 6861 RVA: 0x00011986 File Offset: 0x0000FB86
		public int GetDefenseLoseCount()
		{
			return this.int_16;
		}

		// Token: 0x06001ACE RID: 6862 RVA: 0x0001198E File Offset: 0x0000FB8E
		public void SetDefenseLoseCount(int value)
		{
			this.int_16 = value;
		}

		// Token: 0x06001ACF RID: 6863 RVA: 0x00011997 File Offset: 0x0000FB97
		public int GetDuelWinCount()
		{
			return this.int_23;
		}

		// Token: 0x06001AD0 RID: 6864 RVA: 0x0001199F File Offset: 0x0000FB9F
		public void SetDuelWinCount(int value)
		{
			this.int_23 = value;
		}

		// Token: 0x06001AD1 RID: 6865 RVA: 0x000119A8 File Offset: 0x0000FBA8
		public int GetDuelLoseCount()
		{
			return this.int_24;
		}

		// Token: 0x06001AD2 RID: 6866 RVA: 0x000119B0 File Offset: 0x0000FBB0
		public void SetDuelLoseCount(int value)
		{
			this.int_24 = value;
		}

		// Token: 0x06001AD3 RID: 6867 RVA: 0x000119B9 File Offset: 0x0000FBB9
		public int GetDuelDrawCount()
		{
			return this.int_25;
		}

		// Token: 0x06001AD4 RID: 6868 RVA: 0x000119C1 File Offset: 0x0000FBC1
		public void SetDuelDrawCount(int value)
		{
			this.int_25 = value;
		}

		// Token: 0x06001AD5 RID: 6869 RVA: 0x000119CA File Offset: 0x0000FBCA
		public LogicLong GetLeagueInstanceId()
		{
			return this.logicLong_3;
		}

		// Token: 0x06001AD6 RID: 6870 RVA: 0x000119D2 File Offset: 0x0000FBD2
		public void SetLeagueInstanceId(LogicLong id)
		{
			this.logicLong_3 = id;
		}

		// Token: 0x06001AD7 RID: 6871 RVA: 0x000119DB File Offset: 0x0000FBDB
		public int GetAttackShieldReduceCounter()
		{
			return this.int_21;
		}

		// Token: 0x06001AD8 RID: 6872 RVA: 0x000119E3 File Offset: 0x0000FBE3
		public void SetAttackShieldReduceCounter(int value)
		{
			this.int_21 = value;
		}

		// Token: 0x06001AD9 RID: 6873 RVA: 0x000119EC File Offset: 0x0000FBEC
		public int GetDefenseVillageGuardCounter()
		{
			return this.int_22;
		}

		// Token: 0x06001ADA RID: 6874 RVA: 0x000119F4 File Offset: 0x0000FBF4
		public void SetDefenseVillageGuardCounter(int value)
		{
			this.int_22 = value;
		}

		// Token: 0x06001ADB RID: 6875 RVA: 0x000119FD File Offset: 0x0000FBFD
		public int GetScore()
		{
			return this.int_8;
		}

		// Token: 0x06001ADC RID: 6876 RVA: 0x00011A05 File Offset: 0x0000FC05
		public int GetDuelScore()
		{
			return this.int_9;
		}

		// Token: 0x06001ADD RID: 6877 RVA: 0x00011A0D File Offset: 0x0000FC0D
		public void SetDuelScore(int score)
		{
			this.int_9 = score;
		}

		// Token: 0x06001ADE RID: 6878 RVA: 0x00011A16 File Offset: 0x0000FC16
		public void SetScore(int value)
		{
			this.int_8 = value;
		}

		// Token: 0x06001ADF RID: 6879 RVA: 0x00011A1F File Offset: 0x0000FC1F
		public int GetLegendaryScore()
		{
			return this.int_1;
		}

		// Token: 0x06001AE0 RID: 6880 RVA: 0x00011A27 File Offset: 0x0000FC27
		public void SetLegendaryScore(int value)
		{
			this.int_1 = value;
		}

		// Token: 0x06001AE1 RID: 6881 RVA: 0x00011A30 File Offset: 0x0000FC30
		public int GetLegendaryScoreVillage2()
		{
			return this.int_2;
		}

		// Token: 0x06001AE2 RID: 6882 RVA: 0x00011A38 File Offset: 0x0000FC38
		public void SetLegendaryScoreVillage2(int value)
		{
			this.int_2 = value;
		}

		// Token: 0x06001AE3 RID: 6883 RVA: 0x00011A41 File Offset: 0x0000FC41
		public LogicAvatarTournamentEntry GetLegendSeasonEntry()
		{
			return this.logicAvatarTournamentEntry_0;
		}

		// Token: 0x06001AE4 RID: 6884 RVA: 0x00011A49 File Offset: 0x0000FC49
		public LogicAvatarTournamentEntry GetLegendSeasonEntryVillage2()
		{
			return this.logicAvatarTournamentEntry_1;
		}

		// Token: 0x06001AE5 RID: 6885 RVA: 0x00011A51 File Offset: 0x0000FC51
		public int GetChallengeState()
		{
			return this.int_26;
		}

		// Token: 0x06001AE6 RID: 6886 RVA: 0x00011A59 File Offset: 0x0000FC59
		public void SetChallengeState(int value)
		{
			this.int_26 = value;
		}

		// Token: 0x06001AE7 RID: 6887 RVA: 0x00011A62 File Offset: 0x0000FC62
		public LogicLong GetChallengeId()
		{
			return this.logicLong_4;
		}

		// Token: 0x06001AE8 RID: 6888 RVA: 0x00011A6A File Offset: 0x0000FC6A
		public void SetChallengeId(LogicLong value)
		{
			this.logicLong_4 = value;
		}

		// Token: 0x06001AE9 RID: 6889 RVA: 0x00011A73 File Offset: 0x0000FC73
		public override int GetResourceCount(LogicResourceData data)
		{
			if (data.IsPremiumCurrency())
			{
				return this.int_5;
			}
			return base.GetResourceCount(data);
		}

		// Token: 0x06001AEA RID: 6890 RVA: 0x000659B0 File Offset: 0x00063BB0
		public override LogicLeagueData GetLeagueTypeData()
		{
			LogicDataTable table = LogicDataTables.GetTable(LogicDataType.LEAGUE);
			Debugger.DoAssert(this.m_leagueType > -1 && table.GetItemCount() > this.m_leagueType, "Player league ranking out of bounds");
			return (LogicLeagueData)table.GetItemAt(this.m_leagueType);
		}

		// Token: 0x06001AEB RID: 6891 RVA: 0x000659FC File Offset: 0x00063BFC
		public override void XpGainHelper(int count)
		{
			if (count > 0)
			{
				int maxExpPoints = LogicDataTables.GetExperienceLevel(this.int_3).GetMaxExpPoints();
				if (this.int_3 < LogicExperienceLevelData.GetLevelCap())
				{
					int num = this.int_4 + count;
					if (num >= maxExpPoints)
					{
						if (this.int_3 + 1 == LogicExperienceLevelData.GetLevelCap())
						{
							num = maxExpPoints;
						}
						num -= maxExpPoints;
						this.int_3++;
						this.m_listener.ExpLevelGained(num);
						if (this.m_level != null)
						{
							if (this.m_level.GetPlayerAvatar() == this)
							{
								this.m_level.GetGameListener().LevelUp(this.int_3);
							}
							if (this.m_level.GetHomeOwnerAvatar() == this)
							{
								this.m_level.RefreshNewShopUnlocksExp();
							}
						}
					}
					else
					{
						this.m_listener.ExpPointsGained(num);
					}
					this.int_4 = num;
				}
			}
		}

		// Token: 0x06001AEC RID: 6892 RVA: 0x00065AC8 File Offset: 0x00063CC8
		public void RemoveUnitsVillage2()
		{
			LogicDataTable table = LogicDataTables.GetTable(LogicDataType.CHARACTER);
			for (int i = 0; i < table.GetItemCount(); i++)
			{
				LogicCharacterData logicCharacterData = (LogicCharacterData)table.GetItemAt(i);
				if (logicCharacterData.GetVillageType() == 1)
				{
					base.SetUnitCountVillage2(logicCharacterData, 0);
					this.m_listener.CommodityCountChanged(7, logicCharacterData, 0);
				}
			}
		}

		// Token: 0x06001AED RID: 6893 RVA: 0x00011A8B File Offset: 0x0000FC8B
		public void AddMissionResourceReward(LogicResourceData resourceData, int count)
		{
			if (resourceData != null && count > 0)
			{
				base.SetResourceCount(resourceData, this.GetResourceCount(resourceData) + count);
				this.m_listener.CommodityCountChanged(0, resourceData, count);
			}
		}

		// Token: 0x06001AEE RID: 6894 RVA: 0x00065B1C File Offset: 0x00063D1C
		public override bool AddDuelReward(int goldCount, int elixirCount, int bonusGoldCount, int bonusElixirCount, LogicLong matchId)
		{
			if (goldCount > 0 || elixirCount > 0)
			{
				this.m_level.RefreshResourceCaps();
				base.SetVariableByName("LootLimitWinCount", base.GetVariableByName("LootLimitWinCount") + 1);
				int resourceCap = base.GetResourceCap(LogicDataTables.GetGold2Data());
				int resourceCap2 = base.GetResourceCap(LogicDataTables.GetElixir2Data());
				if (base.GetVariableByName("LootLimitCooldown") != 1 && base.GetVariableByName("LootLimitWinCount") >= this.m_level.GetGameMode().GetConfiguration().GetDuelBonusLimitWinsPerDay())
				{
					this.StartLootLimitCooldown();
					if (bonusGoldCount > 0)
					{
						this.AddResource(0, LogicDataTables.GetGold2Data(), bonusGoldCount, resourceCap);
					}
					if (bonusElixirCount > 0)
					{
						this.AddResource(0, LogicDataTables.GetElixir2Data(), bonusElixirCount, resourceCap2);
					}
				}
				if (goldCount != 0)
				{
					this.AddResource(0, LogicDataTables.GetGold2Data(), goldCount, resourceCap);
				}
				if (elixirCount != 0)
				{
					this.AddResource(0, LogicDataTables.GetElixir2Data(), elixirCount, resourceCap2);
				}
			}
			return true;
		}

		// Token: 0x06001AEF RID: 6895 RVA: 0x00065BF0 File Offset: 0x00063DF0
		public override bool AddStarBonusReward(int goldCount, int elixirCount, int darkElixirCount)
		{
			int resourceCap = base.GetResourceCap(LogicDataTables.GetWarGoldData());
			int resourceCap2 = base.GetResourceCap(LogicDataTables.GetWarElixirData());
			int resourceCap3 = base.GetResourceCap(LogicDataTables.GetWarDarkElixirData());
			this.m_level.RefreshResourceCaps();
			int resourceCap4 = base.GetResourceCap(LogicDataTables.GetWarGoldData());
			int resourceCap5 = base.GetResourceCap(LogicDataTables.GetWarElixirData());
			int resourceCap6 = base.GetResourceCap(LogicDataTables.GetWarDarkElixirData());
			if (goldCount != 0)
			{
				this.AddResource(0, LogicDataTables.GetWarGoldData(), goldCount, LogicMath.Max(resourceCap, resourceCap4));
			}
			if (elixirCount != 0)
			{
				this.AddResource(0, LogicDataTables.GetWarElixirData(), elixirCount, LogicMath.Max(resourceCap2, resourceCap5));
			}
			if (darkElixirCount != 0 && base.IsDarkElixirUnlocked())
			{
				this.AddResource(0, LogicDataTables.GetWarDarkElixirData(), darkElixirCount, LogicMath.Max(resourceCap3, resourceCap6));
			}
			else
			{
				darkElixirCount = 0;
			}
			this.m_level.GetGameListener().StarBonusAdded(goldCount, elixirCount, darkElixirCount);
			if (this.m_listener != null)
			{
				this.m_listener.StarBonusAdded(goldCount, elixirCount, darkElixirCount);
			}
			return true;
		}

		// Token: 0x06001AF0 RID: 6896 RVA: 0x00065CD0 File Offset: 0x00063ED0
		public override bool AddWarReward(int gold, int elixir, int darkElixir, int unk, LogicLong warInstanceId)
		{
			if (warInstanceId != null && !this.logicLong_5.Equals(warInstanceId))
			{
				this.int_17 += gold;
				this.int_18 += elixir;
				this.int_19 = darkElixir;
				this.logicLong_5 = warInstanceId;
				return true;
			}
			return false;
		}

		// Token: 0x06001AF1 RID: 6897 RVA: 0x00065D20 File Offset: 0x00063F20
		public override void FastForwardLootLimit(int secs)
		{
			int remainingLootLimitTime = this.GetRemainingLootLimitTime();
			if (remainingLootLimitTime > secs)
			{
				int num = base.GetVariableByName("LootLimitTimerEndSubTick");
				int variableByName = base.GetVariableByName("LootLimitTimerEndTimestamp");
				int num2 = this.m_level.GetLogicTime().GetTick();
				int startTime = this.m_level.GetGameMode().GetStartTime();
				int num3 = 60 * (variableByName - startTime);
				if (variableByName < 1 || startTime == -1)
				{
					num2 = num;
					num3 = -60 * secs;
				}
				num = num2 + num3;
				if (LogicDataTables.GetGlobals().ClampAvatarTimersToMax())
				{
					num = this.m_level.GetLogicTime().GetTick() + 60 * LogicMath.Clamp((num - this.m_level.GetLogicTime().GetTick()) / 60, 1, 60 * LogicCalendar.GetDuelLootLimitCooldownInMinutes(this.m_level.GetGameMode().GetCalendar(), this.m_level.GetGameMode().GetConfiguration()));
				}
				base.SetVariableByName("LootLimitTimerEndSubTick", num);
				return;
			}
			if (base.GetVariableByName("LootLimitCooldown") == 1)
			{
				this.RestartLootLimitTimer(secs - remainingLootLimitTime, this.m_level.GetHomeOwnerAvatarChangeListener().GetCurrentTimestamp());
				base.SetVariableByName("LootLimitCooldown", 0);
				this.ResetLootLimitWinCount();
				return;
			}
			base.SetVariableByName("LootLimitTimerEndSubTick", this.m_level.GetLogicTime().GetTick());
		}

		// Token: 0x06001AF2 RID: 6898 RVA: 0x00065E58 File Offset: 0x00064058
		public override void FastForwardStarBonusLimit(int secs)
		{
			int remainingStarBonusTime = this.GetRemainingStarBonusTime();
			if (remainingStarBonusTime > secs)
			{
				int num = base.GetVariableByName("StarBonusTimerEndSubTick");
				int variableByName = base.GetVariableByName("StarBonusTimerEndTimestep");
				int num2 = this.m_level.GetLogicTime().GetTick();
				int startTime = this.m_level.GetGameMode().GetStartTime();
				int num3 = 60 * (variableByName - startTime);
				if (variableByName < 1 || startTime == -1)
				{
					num2 = num;
					num3 = -60 * secs;
				}
				num = num2 + num3;
				if (LogicDataTables.GetGlobals().ClampAvatarTimersToMax())
				{
					num = this.m_level.GetLogicTime().GetTick() + 60 * LogicMath.Clamp((num - this.m_level.GetLogicTime().GetTick()) / 60, 1, 60 * LogicCalendar.GetDuelLootLimitCooldownInMinutes(this.m_level.GetGameMode().GetCalendar(), this.m_level.GetGameMode().GetConfiguration()));
				}
				base.SetVariableByName("StarBonusTimerEndSubTick", num);
				return;
			}
			if (base.GetVariableByName("StarBonusCooldown") == 1)
			{
				this.RestartStartBonusLimitTimer(secs - remainingStarBonusTime, this.m_level.GetHomeOwnerAvatarChangeListener().GetCurrentTimestamp());
				base.SetVariableByName("StarBonusCooldown", 0);
				return;
			}
			base.SetVariableByName("StarBonusTimerEndSubTick", this.m_level.GetLogicTime().GetTick());
		}

		// Token: 0x06001AF3 RID: 6899 RVA: 0x00065F8C File Offset: 0x0006418C
		public void AddResource(int commodityType, LogicResourceData resourceData, int gainCount, int resourceCap)
		{
			int num = this.GetResourceCount(resourceData);
			int num2 = LogicMath.Max(num + gainCount, 0);
			if (gainCount <= 0)
			{
				base.SetResourceCount(resourceData, num2);
				base.GetChangeListener().CommodityCountChanged(commodityType, resourceData, num2);
				return;
			}
			num2 = LogicMath.Min(num2, resourceCap);
			num = LogicMath.Min(num, resourceCap);
			if (num2 > num)
			{
				base.SetResourceCount(resourceData, num2);
				base.GetChangeListener().CommodityCountChanged(commodityType, resourceData, num2);
			}
		}

		// Token: 0x06001AF4 RID: 6900 RVA: 0x00065FF4 File Offset: 0x000641F4
		public void StartLootLimitCooldown()
		{
			int variableByName = base.GetVariableByName("LootLimitFreeSpeedUp");
			if (variableByName < LogicDataTables.GetGlobals().GetDuelLootLimitFreeSpeedUps())
			{
				this.RestartLootLimitTimer(0, this.m_level.GetHomeOwnerAvatarChangeListener().GetCurrentTimestamp());
				this.ResetLootLimitWinCount();
				base.SetVariableByName("LootLimitFreeSpeedUp", variableByName + 1);
				return;
			}
			if (this.GetRemainingLootLimitTime() <= 0)
			{
				this.RestartLootLimitTimer(0, this.m_level.GetHomeOwnerAvatarChangeListener().GetCurrentTimestamp());
				this.ResetLootLimitWinCount();
				return;
			}
			base.SetVariableByName("LootLimitCooldown", 1);
		}

		// Token: 0x06001AF5 RID: 6901 RVA: 0x0006607C File Offset: 0x0006427C
		public int GetRemainingLootLimitTime()
		{
			int num = base.GetVariableByName("LootLimitTimerEndSubTick") - this.m_level.GetLogicTime().GetTick();
			if (num <= 0)
			{
				return 0;
			}
			return LogicMath.Max(1, (num + 59) / 60);
		}

		// Token: 0x06001AF6 RID: 6902 RVA: 0x000660BC File Offset: 0x000642BC
		public int GetRemainingStarBonusTime()
		{
			int num = base.GetVariableByName("StarBonusTimerEndSubTick") - this.m_level.GetLogicTime().GetTick();
			if (num <= 0)
			{
				return 0;
			}
			return LogicMath.Max(1, (num + 59) / 60);
		}

		// Token: 0x06001AF7 RID: 6903 RVA: 0x000660FC File Offset: 0x000642FC
		public void RestartLootLimitTimer(int passedSecs, int timestamp)
		{
			int num = LogicCalendar.GetDuelLootLimitCooldownInMinutes(this.m_level.GetGameMode().GetCalendar(), this.m_level.GetGameMode().GetConfiguration()) * 60 - passedSecs;
			if (num <= passedSecs)
			{
				base.SetVariableByName("LootLimitTimerEndSubTick", this.m_level.GetLogicTime().GetTick());
				return;
			}
			base.SetVariableByName("LootLimitTimerEndSubTick", this.m_level.GetLogicTime().GetTick() + num * 60);
			if (timestamp != -1)
			{
				base.SetVariableByName("LootLimitTimerEndTimestamp", timestamp + num);
			}
		}

		// Token: 0x06001AF8 RID: 6904 RVA: 0x00066188 File Offset: 0x00064388
		public void RestartStartBonusLimitTimer(int passedSecs, int timestamp)
		{
			int num = LogicDataTables.GetGlobals().GetStarBonusCooldownMinutes() * 60 - passedSecs;
			if (num <= passedSecs)
			{
				base.SetVariableByName("StarBonusTimerEndSubTick", this.m_level.GetLogicTime().GetTick());
				return;
			}
			base.SetVariableByName("StarBonusTimerEndSubTick", this.m_level.GetLogicTime().GetTick() + num * 60);
			if (timestamp != -1)
			{
				base.SetVariableByName("StarBonusTimerEndTimestep", timestamp + num);
			}
		}

		// Token: 0x06001AF9 RID: 6905 RVA: 0x000661F8 File Offset: 0x000643F8
		public override void UpdateLootLimitCooldown()
		{
			if (this.GetRemainingLootLimitTime() <= 0 && base.GetVariableByName("LootLimitCooldown") == 1)
			{
				this.RestartLootLimitTimer(0, this.m_level.GetHomeOwnerAvatarChangeListener().GetCurrentTimestamp());
				base.SetVariableByName("LootLimitCooldown", 0);
				this.ResetLootLimitWinCount();
			}
		}

		// Token: 0x06001AFA RID: 6906 RVA: 0x00011AB2 File Offset: 0x0000FCB2
		public override void UpdateStarBonusLimitCooldown()
		{
			if (this.GetRemainingStarBonusTime() <= 0 && base.GetVariableByName("StarBonusCooldown") == 1)
			{
				this.RestartStartBonusLimitTimer(0, this.m_level.GetHomeOwnerAvatarChangeListener().GetCurrentTimestamp());
				base.SetVariableByName("StarBonusCooldown", 0);
			}
		}

		// Token: 0x06001AFB RID: 6907 RVA: 0x00011AEE File Offset: 0x0000FCEE
		public void ResetLootLimitWinCount()
		{
			base.SetVariableByName("LootLimitWinCount", 0);
		}

		// Token: 0x06001AFC RID: 6908 RVA: 0x00011AFC File Offset: 0x0000FCFC
		public int GetStarBonusCounter()
		{
			return base.GetVariableByName("StarBonusCounter");
		}

		// Token: 0x06001AFD RID: 6909 RVA: 0x00011B09 File Offset: 0x0000FD09
		public int GetLootLimitWinCount()
		{
			return base.GetVariableByName("LootLimitWinCount");
		}

		// Token: 0x06001AFE RID: 6910 RVA: 0x00011B16 File Offset: 0x0000FD16
		public void SetStarBonusCounter(int count)
		{
			base.SetVariableByName("StarBonusCounter", count);
		}

		// Token: 0x06001AFF RID: 6911 RVA: 0x00011B24 File Offset: 0x0000FD24
		public bool GetStarBonusCooldown()
		{
			return base.GetVariableByName("StarBonusCooldown") == 1;
		}

		// Token: 0x06001B00 RID: 6912 RVA: 0x00011B34 File Offset: 0x0000FD34
		public bool GetLootLimitCooldown()
		{
			return base.GetVariableByName("LootLimitCooldown") == 1;
		}

		// Token: 0x06001B01 RID: 6913 RVA: 0x00066248 File Offset: 0x00064448
		public int GetTroopRequestCooldown()
		{
			if (this.IsInAlliance() && this.int_0 > 0)
			{
				LogicAllianceLevelData allianceLevel = LogicDataTables.GetAllianceLevel(this.int_0);
				if (allianceLevel != null)
				{
					return allianceLevel.GetTroopRequestCooldown() * 60;
				}
			}
			return LogicDataTables.GetGlobals().GetAllianceTroopRequestCooldown();
		}

		// Token: 0x06001B02 RID: 6914 RVA: 0x0006628C File Offset: 0x0006448C
		public int GetTroopDonationRefund()
		{
			if (this.IsInAlliance() && this.int_0 > 0)
			{
				LogicAllianceLevelData allianceLevel = LogicDataTables.GetAllianceLevel(this.int_0);
				if (allianceLevel != null)
				{
					return allianceLevel.GetTroopDonationRefund();
				}
			}
			return 0;
		}

		// Token: 0x06001B03 RID: 6915 RVA: 0x000662C4 File Offset: 0x000644C4
		public void SetLastUsedArmy(LogicArrayList<LogicDataSlot> unitCount, LogicArrayList<LogicDataSlot> spellCount)
		{
			for (int i = 0; i < unitCount.Size(); i++)
			{
				LogicDataSlot logicDataSlot = unitCount[i];
				LogicCombatItemData data = (LogicCombatItemData)logicDataSlot.GetData();
				int count = logicDataSlot.GetCount();
				if (base.GetUnitPresetCount(data, 0) != count)
				{
					base.SetCommodityCount(2, data, count);
					base.GetChangeListener().CommodityCountChanged(2, data, count);
				}
			}
			for (int j = 0; j < spellCount.Size(); j++)
			{
				LogicDataSlot logicDataSlot2 = spellCount[j];
				LogicCombatItemData data2 = (LogicCombatItemData)logicDataSlot2.GetData();
				int count2 = logicDataSlot2.GetCount();
				if (base.GetUnitPresetCount(data2, 0) != count2)
				{
					base.SetCommodityCount(2, data2, count2);
					base.GetChangeListener().CommodityCountChanged(2, data2, count2);
				}
			}
		}

		// Token: 0x06001B04 RID: 6916 RVA: 0x00066374 File Offset: 0x00064574
		public void StarBonusCollected()
		{
			int variableByName = base.GetVariableByName("StarBonusTimesCollected");
			base.SetVariableByName("StarBonusTimesCollected", variableByName + 1);
			if (variableByName == 0)
			{
				this.RestartStartBonusLimitTimer(0, this.m_level.GetHomeOwnerAvatar().GetChangeListener().GetCurrentTimestamp());
			}
			if (this.GetRemainingStarBonusTime() <= 0)
			{
				this.RestartStartBonusLimitTimer(0, this.m_level.GetHomeOwnerAvatar().GetChangeListener().GetCurrentTimestamp());
				return;
			}
			base.SetVariableByName("StarBonusCooldown", 1);
		}

		// Token: 0x06001B05 RID: 6917 RVA: 0x000663EC File Offset: 0x000645EC
		public bool CanCollectStarBonus()
		{
			if (LogicDataTables.GetGlobals().UseStarBonus())
			{
				LogicLeagueData leagueTypeData = this.GetLeagueTypeData();
				if (leagueTypeData != null && leagueTypeData.GetUseStarBonus())
				{
					return base.GetAllianceCastleLevel() >= 0;
				}
			}
			return false;
		}

		// Token: 0x06001B06 RID: 6918 RVA: 0x00066428 File Offset: 0x00064628
		public void Decode(ByteStream stream)
		{
			this.logicLong_0 = stream.ReadLong();
			this.logicLong_1 = stream.ReadLong();
			if (stream.ReadBoolean())
			{
				this.logicLong_2 = stream.ReadLong();
				this.string_1 = stream.ReadString(900000);
				this.m_allianceBadgeId = stream.ReadInt();
				this.logicAvatarAllianceRole_0 = (LogicAvatarAllianceRole)stream.ReadInt();
				this.int_0 = stream.ReadInt();
			}
			if (stream.ReadBoolean())
			{
				this.logicLong_3 = stream.ReadLong();
			}
			this.int_1 = stream.ReadInt();
			this.int_2 = stream.ReadInt();
			this.logicAvatarTournamentEntry_0.Decode(stream);
			this.logicAvatarTournamentEntry_1.Decode(stream);
			this.int_23 = stream.ReadInt();
			this.int_24 = stream.ReadInt();
			this.int_25 = stream.ReadInt();
			this.m_leagueType = stream.ReadInt();
			this.m_allianceCastleLevel = stream.ReadInt();
			this.m_allianceCastleTotalCapacity = stream.ReadInt();
			this.m_allianceCastleUsedCapacity = stream.ReadInt();
			this.m_allianceCastleTotalSpellCapacity = stream.ReadInt();
			this.m_allianceCastleUsedSpellCapacity = stream.ReadInt();
			this.m_townHallLevel = stream.ReadInt();
			this.m_townHallLevelVillage2 = stream.ReadInt();
			this.string_2 = stream.ReadString(900000);
			this.string_0 = stream.ReadString(900000);
			this.int_3 = stream.ReadInt();
			this.int_4 = stream.ReadInt();
			this.int_5 = stream.ReadInt();
			this.int_6 = stream.ReadInt();
			this.int_11 = stream.ReadInt();
			this.int_12 = stream.ReadInt();
			this.int_8 = stream.ReadInt();
			this.int_9 = stream.ReadInt();
			this.int_13 = stream.ReadInt();
			this.int_14 = stream.ReadInt();
			this.int_15 = stream.ReadInt();
			this.int_16 = stream.ReadInt();
			this.int_17 = stream.ReadInt();
			this.int_18 = stream.ReadInt();
			this.int_19 = stream.ReadInt();
			stream.ReadInt();
			if (stream.ReadBoolean())
			{
				stream.ReadLong();
			}
			this.bool_0 = stream.ReadBoolean();
			this.bool_1 = stream.ReadBoolean();
			this.int_20 = stream.ReadInt();
			this.int_7 = stream.ReadInt();
			this.m_redPackageState = stream.ReadInt();
			this.int_10 = stream.ReadInt();
			this.int_21 = stream.ReadInt();
			stream.ReadInt();
			if (stream.ReadBoolean())
			{
				this.int_26 = stream.ReadInt();
				this.logicLong_4 = stream.ReadLong();
			}
			base.ClearDataSlotArray(this.m_resourceCap);
			base.ClearDataSlotArray(this.m_resourceCount);
			base.ClearDataSlotArray(this.m_unitCount);
			base.ClearDataSlotArray(this.m_spellCount);
			base.ClearDataSlotArray(this.m_unitUpgrade);
			base.ClearDataSlotArray(this.m_spellUpgrade);
			base.ClearDataSlotArray(this.m_heroUpgrade);
			base.ClearDataSlotArray(this.m_heroHealth);
			base.ClearDataSlotArray(this.m_heroState);
			base.ClearUnitSlotArray(this.m_allianceUnitCount);
			base.ClearDataSlotArray(this.m_achievementProgress);
			base.ClearDataSlotArray(this.m_npcStars);
			base.ClearDataSlotArray(this.m_lootedNpcGold);
			base.ClearDataSlotArray(this.m_lootedNpcElixir);
			base.ClearDataSlotArray(this.m_heroMode);
			base.ClearDataSlotArray(this.m_variables);
			base.ClearDataSlotArray(this.m_unitPreset1);
			base.ClearDataSlotArray(this.m_unitPreset2);
			base.ClearDataSlotArray(this.m_unitPreset3);
			base.ClearDataSlotArray(this.m_previousArmy);
			base.ClearDataSlotArray(this.m_eventUnitCounter);
			base.ClearDataSlotArray(this.m_unitCountVillage2);
			base.ClearDataSlotArray(this.m_unitCountNewVillage2);
			base.ClearDataSlotArray(this.m_freeActionCount);
			this.m_missionCompleted.Clear();
			this.m_achievementRewardClaimed.Clear();
			int i = 0;
			int num = stream.ReadInt();
			while (i < num)
			{
				LogicDataSlot logicDataSlot = new LogicDataSlot(null, 0);
				logicDataSlot.Decode(stream);
				this.m_resourceCap.Add(logicDataSlot);
				i++;
			}
			int j = 0;
			int num2 = stream.ReadInt();
			while (j < num2)
			{
				LogicDataSlot logicDataSlot2 = new LogicDataSlot(null, 0);
				logicDataSlot2.Decode(stream);
				if (logicDataSlot2.GetData() != null)
				{
					this.m_resourceCount.Add(logicDataSlot2);
				}
				else
				{
					logicDataSlot2.Destruct();
					Debugger.Error("LogicClientAvatar::decode - resource slot data is NULL");
				}
				j++;
			}
			int k = 0;
			int num3 = stream.ReadInt();
			while (k < num3)
			{
				LogicDataSlot logicDataSlot3 = new LogicDataSlot(null, 0);
				logicDataSlot3.Decode(stream);
				if (logicDataSlot3.GetData() != null)
				{
					this.m_unitCount.Add(logicDataSlot3);
				}
				else
				{
					logicDataSlot3.Destruct();
					Debugger.Error("LogicClientAvatar::decode - unit slot data is NULL");
				}
				k++;
			}
			int l = 0;
			int num4 = stream.ReadInt();
			while (l < num4)
			{
				LogicDataSlot logicDataSlot4 = new LogicDataSlot(null, 0);
				logicDataSlot4.Decode(stream);
				if (logicDataSlot4.GetData() != null)
				{
					this.m_spellCount.Add(logicDataSlot4);
				}
				else
				{
					logicDataSlot4.Destruct();
					Debugger.Error("LogicClientAvatar::decode - spell slot data is NULL");
				}
				l++;
			}
			int m = 0;
			int num5 = stream.ReadInt();
			while (m < num5)
			{
				LogicDataSlot logicDataSlot5 = new LogicDataSlot(null, 0);
				logicDataSlot5.Decode(stream);
				if (logicDataSlot5.GetData() != null)
				{
					this.m_unitUpgrade.Add(logicDataSlot5);
				}
				else
				{
					logicDataSlot5.Destruct();
					Debugger.Error("LogicClientAvatar::decode - unit upgrade slot data is NULL");
				}
				m++;
			}
			int n = 0;
			int num6 = stream.ReadInt();
			while (n < num6)
			{
				LogicDataSlot logicDataSlot6 = new LogicDataSlot(null, 0);
				logicDataSlot6.Decode(stream);
				if (logicDataSlot6.GetData() != null)
				{
					this.m_spellUpgrade.Add(logicDataSlot6);
				}
				else
				{
					logicDataSlot6.Destruct();
					Debugger.Error("LogicClientAvatar::decode - spell upgrade slot data is NULL");
				}
				n++;
			}
			int num7 = 0;
			int num8 = stream.ReadInt();
			while (num7 < num8)
			{
				LogicDataSlot logicDataSlot7 = new LogicDataSlot(null, 0);
				logicDataSlot7.Decode(stream);
				if (logicDataSlot7.GetData() != null)
				{
					this.m_heroUpgrade.Add(logicDataSlot7);
				}
				else
				{
					logicDataSlot7.Destruct();
					Debugger.Error("LogicClientAvatar::decode - hero upgrade slot data is NULL");
				}
				num7++;
			}
			int num9 = 0;
			int num10 = stream.ReadInt();
			while (num9 < num10)
			{
				LogicDataSlot logicDataSlot8 = new LogicDataSlot(null, 0);
				logicDataSlot8.Decode(stream);
				if (logicDataSlot8.GetData() != null)
				{
					this.m_heroHealth.Add(logicDataSlot8);
				}
				else
				{
					logicDataSlot8.Destruct();
					Debugger.Error("LogicClientAvatar::decode - hero health slot data is NULL");
				}
				num9++;
			}
			int num11 = 0;
			int num12 = stream.ReadInt();
			while (num11 < num12)
			{
				LogicDataSlot logicDataSlot9 = new LogicDataSlot(null, 0);
				logicDataSlot9.Decode(stream);
				if (logicDataSlot9.GetData() != null)
				{
					this.m_heroState.Add(logicDataSlot9);
				}
				else
				{
					logicDataSlot9.Destruct();
					Debugger.Error("LogicClientAvatar::decode - hero state slot data is NULL");
				}
				num11++;
			}
			int num13 = 0;
			int num14 = stream.ReadInt();
			while (num13 < num14)
			{
				LogicUnitSlot logicUnitSlot = new LogicUnitSlot(null, 0, 0);
				logicUnitSlot.Decode(stream);
				if (logicUnitSlot.GetData() != null)
				{
					this.m_allianceUnitCount.Add(logicUnitSlot);
				}
				else
				{
					logicUnitSlot.Destruct();
					Debugger.Error("LogicClientAvatar::decode - alliance unit data is NULL");
				}
				num13++;
			}
			int num15 = 0;
			int num16 = stream.ReadInt();
			while (num15 < num16)
			{
				LogicMissionData logicMissionData = (LogicMissionData)ByteStreamHelper.ReadDataReference(stream, LogicDataType.MISSION);
				if (logicMissionData != null)
				{
					this.m_missionCompleted.Add(logicMissionData);
				}
				num15++;
			}
			int num17 = 0;
			int num18 = stream.ReadInt();
			while (num17 < num18)
			{
				LogicAchievementData logicAchievementData = (LogicAchievementData)ByteStreamHelper.ReadDataReference(stream, LogicDataType.ACHIEVEMENT);
				if (logicAchievementData != null)
				{
					this.m_achievementRewardClaimed.Add(logicAchievementData);
				}
				num17++;
			}
			int num19 = 0;
			int num20 = stream.ReadInt();
			while (num19 < num20)
			{
				LogicDataSlot logicDataSlot10 = new LogicDataSlot(null, 0);
				logicDataSlot10.Decode(stream);
				if (logicDataSlot10.GetData() != null)
				{
					this.m_achievementProgress.Add(logicDataSlot10);
				}
				else
				{
					logicDataSlot10.Destruct();
					Debugger.Error("LogicClientAvatar::decode - achievement progress data is NULL");
				}
				num19++;
			}
			int num21 = 0;
			int num22 = stream.ReadInt();
			while (num21 < num22)
			{
				LogicDataSlot logicDataSlot11 = new LogicDataSlot(null, 0);
				logicDataSlot11.Decode(stream);
				if (logicDataSlot11.GetData() != null)
				{
					this.m_npcStars.Add(logicDataSlot11);
				}
				else
				{
					logicDataSlot11.Destruct();
					Debugger.Error("LogicClientAvatar::decode - npc map progress data is NULL");
				}
				num21++;
			}
			int num23 = 0;
			int num24 = stream.ReadInt();
			while (num23 < num24)
			{
				LogicDataSlot logicDataSlot12 = new LogicDataSlot(null, 0);
				logicDataSlot12.Decode(stream);
				if (logicDataSlot12.GetData() != null)
				{
					this.m_lootedNpcGold.Add(logicDataSlot12);
				}
				else
				{
					logicDataSlot12.Destruct();
					Debugger.Error("LogicClientAvatar::decode - npc looted gold data is NULL");
				}
				num23++;
			}
			int num25 = 0;
			int num26 = stream.ReadInt();
			while (num25 < num26)
			{
				LogicDataSlot logicDataSlot13 = new LogicDataSlot(null, 0);
				logicDataSlot13.Decode(stream);
				if (logicDataSlot13.GetData() != null)
				{
					this.m_lootedNpcElixir.Add(logicDataSlot13);
				}
				else
				{
					logicDataSlot13.Destruct();
					Debugger.Error("LogicClientAvatar::decode - npc looted elixir data is NULL");
				}
				num25++;
			}
			this.m_allianceUnitVisitCapacity = stream.ReadInt();
			this.m_allianceUnitSpellVisitCapacity = stream.ReadInt();
			int num27 = 0;
			int num28 = stream.ReadInt();
			while (num27 < num28)
			{
				LogicDataSlot logicDataSlot14 = new LogicDataSlot(null, 0);
				logicDataSlot14.Decode(stream);
				if (logicDataSlot14.GetData() != null)
				{
					this.m_heroMode.Add(logicDataSlot14);
				}
				else
				{
					logicDataSlot14.Destruct();
					Debugger.Error("LogicClientAvatar::decode - hero mode slot data is NULL");
				}
				num27++;
			}
			int num29 = 0;
			int num30 = stream.ReadInt();
			while (num29 < num30)
			{
				LogicDataSlot logicDataSlot15 = new LogicDataSlot(null, 0);
				logicDataSlot15.Decode(stream);
				if (logicDataSlot15.GetData() != null)
				{
					this.m_variables.Add(logicDataSlot15);
				}
				else
				{
					logicDataSlot15.Destruct();
					Debugger.Error("LogicClientAvatar::decode - variables data is NULL");
				}
				num29++;
			}
			int num31 = 0;
			int num32 = stream.ReadInt();
			while (num31 < num32)
			{
				LogicDataSlot logicDataSlot16 = new LogicDataSlot(null, 0);
				logicDataSlot16.Decode(stream);
				if (logicDataSlot16.GetData() != null)
				{
					this.m_unitPreset1.Add(logicDataSlot16);
				}
				else
				{
					logicDataSlot16.Destruct();
					Debugger.Error("LogicClientAvatar::decode - unitPreset1 data is NULL");
				}
				num31++;
			}
			int num33 = 0;
			int num34 = stream.ReadInt();
			while (num33 < num34)
			{
				LogicDataSlot logicDataSlot17 = new LogicDataSlot(null, 0);
				logicDataSlot17.Decode(stream);
				if (logicDataSlot17.GetData() != null)
				{
					this.m_unitPreset2.Add(logicDataSlot17);
				}
				else
				{
					logicDataSlot17.Destruct();
					Debugger.Error("LogicClientAvatar::decode - unitPreset2 data is NULL");
				}
				num33++;
			}
			int num35 = 0;
			int num36 = stream.ReadInt();
			while (num35 < num36)
			{
				LogicDataSlot logicDataSlot18 = new LogicDataSlot(null, 0);
				logicDataSlot18.Decode(stream);
				if (logicDataSlot18.GetData() != null)
				{
					this.m_unitPreset3.Add(logicDataSlot18);
				}
				else
				{
					logicDataSlot18.Destruct();
					Debugger.Error("LogicClientAvatar::decode - unitPreset3 data is NULL");
				}
				num35++;
			}
			int num37 = 0;
			int num38 = stream.ReadInt();
			while (num37 < num38)
			{
				LogicDataSlot logicDataSlot19 = new LogicDataSlot(null, 0);
				logicDataSlot19.Decode(stream);
				if (logicDataSlot19.GetData() != null)
				{
					this.m_previousArmy.Add(logicDataSlot19);
				}
				else
				{
					logicDataSlot19.Destruct();
					Debugger.Error("LogicClientAvatar::decode - previousArmySize data is NULL");
				}
				num37++;
			}
			int num39 = 0;
			int num40 = stream.ReadInt();
			while (num39 < num40)
			{
				LogicDataSlot logicDataSlot20 = new LogicDataSlot(null, 0);
				logicDataSlot20.Decode(stream);
				if (logicDataSlot20.GetData() != null)
				{
					this.m_eventUnitCounter.Add(logicDataSlot20);
				}
				else
				{
					logicDataSlot20.Destruct();
					Debugger.Error("LogicClientAvatar::decode - unitCounterForEvent data is NULL");
				}
				num39++;
			}
			int num41 = 0;
			int num42 = stream.ReadInt();
			while (num41 < num42)
			{
				LogicDataSlot logicDataSlot21 = new LogicDataSlot(null, 0);
				logicDataSlot21.Decode(stream);
				if (logicDataSlot21.GetData() != null)
				{
					this.m_unitCountVillage2.Add(logicDataSlot21);
				}
				else
				{
					logicDataSlot21.Destruct();
					Debugger.Error("LogicClientAvatar::decode - unit village2 slot data is NULL");
				}
				num41++;
			}
			int num43 = 0;
			int num44 = stream.ReadInt();
			while (num43 < num44)
			{
				LogicDataSlot logicDataSlot22 = new LogicDataSlot(null, 0);
				logicDataSlot22.Decode(stream);
				if (logicDataSlot22.GetData() != null)
				{
					this.m_unitCountNewVillage2.Add(logicDataSlot22);
				}
				else
				{
					logicDataSlot22.Destruct();
					Debugger.Error("LogicClientAvatar::decode - unit village2 new slot data is NULL");
				}
				num43++;
			}
			int num45 = 0;
			int num46 = stream.ReadInt();
			while (num45 < num46)
			{
				LogicDataSlot logicDataSlot23 = new LogicDataSlot(null, 0);
				logicDataSlot23.Decode(stream);
				if (logicDataSlot23.GetData() != null)
				{
					this.m_freeActionCount.Add(logicDataSlot23);
				}
				else
				{
					logicDataSlot23.Destruct();
					Debugger.Error("LogicClientAvatar::decode - slot data is NULL");
				}
				num45++;
			}
		}

		// Token: 0x06001B07 RID: 6919 RVA: 0x0006706C File Offset: 0x0006526C
		public void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteLong(this.logicLong_0);
			encoder.WriteLong(this.logicLong_1);
			if (this.logicLong_2 != null)
			{
				encoder.WriteBoolean(true);
				encoder.WriteLong(this.logicLong_2);
				encoder.WriteString(this.string_1);
				encoder.WriteInt(this.m_allianceBadgeId);
				encoder.WriteInt((int)this.logicAvatarAllianceRole_0);
				encoder.WriteInt(this.int_0);
			}
			else
			{
				encoder.WriteBoolean(false);
			}
			if (this.logicLong_3 != null)
			{
				encoder.WriteBoolean(true);
				encoder.WriteLong(this.logicLong_3);
			}
			else
			{
				encoder.WriteBoolean(false);
			}
			encoder.WriteInt(this.int_1);
			encoder.WriteInt(this.int_2);
			this.logicAvatarTournamentEntry_0.Encode(encoder);
			this.logicAvatarTournamentEntry_1.Encode(encoder);
			encoder.WriteInt(this.int_23);
			encoder.WriteInt(this.int_24);
			encoder.WriteInt(this.int_25);
			encoder.WriteInt(this.m_leagueType);
			encoder.WriteInt(this.m_allianceCastleLevel);
			encoder.WriteInt(this.m_allianceCastleTotalCapacity);
			encoder.WriteInt(this.m_allianceCastleUsedCapacity);
			encoder.WriteInt(this.m_allianceCastleTotalSpellCapacity);
			encoder.WriteInt(this.m_allianceCastleUsedSpellCapacity);
			encoder.WriteInt(this.m_townHallLevel);
			encoder.WriteInt(this.m_townHallLevelVillage2);
			encoder.WriteString(this.string_2);
			encoder.WriteString(this.string_0);
			encoder.WriteInt(this.int_3);
			encoder.WriteInt(this.int_4);
			encoder.WriteInt(this.int_5);
			encoder.WriteInt(this.int_6);
			encoder.WriteInt(this.int_11);
			encoder.WriteInt(this.int_12);
			encoder.WriteInt(this.int_8);
			encoder.WriteInt(this.int_9);
			encoder.WriteInt(this.int_13);
			encoder.WriteInt(this.int_14);
			encoder.WriteInt(this.int_15);
			encoder.WriteInt(this.int_16);
			encoder.WriteInt(this.int_17);
			encoder.WriteInt(this.int_18);
			encoder.WriteInt(this.int_19);
			encoder.WriteInt(0);
			if (this.logicLong_5 != null)
			{
				encoder.WriteBoolean(true);
				encoder.WriteLong(this.logicLong_5);
			}
			else
			{
				encoder.WriteBoolean(false);
			}
			encoder.WriteBoolean(this.bool_0);
			encoder.WriteBoolean(this.bool_1);
			encoder.WriteInt(this.int_20);
			encoder.WriteInt(this.int_7);
			encoder.WriteInt(this.m_redPackageState);
			encoder.WriteInt(this.int_10);
			encoder.WriteInt(this.int_21);
			encoder.WriteInt(0);
			if (this.logicLong_4 != null)
			{
				encoder.WriteBoolean(true);
				encoder.WriteInt(this.int_26);
				encoder.WriteLong(this.logicLong_4);
			}
			else
			{
				encoder.WriteBoolean(false);
			}
			encoder.WriteInt(this.m_resourceCap.Size());
			for (int i = 0; i < this.m_resourceCap.Size(); i++)
			{
				this.m_resourceCap[i].Encode(encoder);
			}
			encoder.WriteInt(this.m_resourceCount.Size());
			for (int j = 0; j < this.m_resourceCount.Size(); j++)
			{
				this.m_resourceCount[j].Encode(encoder);
			}
			encoder.WriteInt(this.m_unitCount.Size());
			for (int k = 0; k < this.m_unitCount.Size(); k++)
			{
				this.m_unitCount[k].Encode(encoder);
			}
			encoder.WriteInt(this.m_spellCount.Size());
			for (int l = 0; l < this.m_spellCount.Size(); l++)
			{
				this.m_spellCount[l].Encode(encoder);
			}
			encoder.WriteInt(this.m_unitUpgrade.Size());
			for (int m = 0; m < this.m_unitUpgrade.Size(); m++)
			{
				this.m_unitUpgrade[m].Encode(encoder);
			}
			encoder.WriteInt(this.m_spellUpgrade.Size());
			for (int n = 0; n < this.m_spellUpgrade.Size(); n++)
			{
				this.m_spellUpgrade[n].Encode(encoder);
			}
			encoder.WriteInt(this.m_heroUpgrade.Size());
			for (int num = 0; num < this.m_heroUpgrade.Size(); num++)
			{
				this.m_heroUpgrade[num].Encode(encoder);
			}
			encoder.WriteInt(this.m_heroHealth.Size());
			for (int num2 = 0; num2 < this.m_heroHealth.Size(); num2++)
			{
				this.m_heroHealth[num2].Encode(encoder);
			}
			encoder.WriteInt(this.m_heroState.Size());
			for (int num3 = 0; num3 < this.m_heroState.Size(); num3++)
			{
				this.m_heroState[num3].Encode(encoder);
			}
			encoder.WriteInt(this.m_allianceUnitCount.Size());
			for (int num4 = 0; num4 < this.m_allianceUnitCount.Size(); num4++)
			{
				this.m_allianceUnitCount[num4].Encode(encoder);
			}
			encoder.WriteInt(this.m_missionCompleted.Size());
			for (int num5 = 0; num5 < this.m_missionCompleted.Size(); num5++)
			{
				ByteStreamHelper.WriteDataReference(encoder, this.m_missionCompleted[num5]);
			}
			encoder.WriteInt(this.m_achievementRewardClaimed.Size());
			for (int num6 = 0; num6 < this.m_achievementRewardClaimed.Size(); num6++)
			{
				ByteStreamHelper.WriteDataReference(encoder, this.m_achievementRewardClaimed[num6]);
			}
			encoder.WriteInt(this.m_achievementProgress.Size());
			for (int num7 = 0; num7 < this.m_achievementProgress.Size(); num7++)
			{
				this.m_achievementProgress[num7].Encode(encoder);
			}
			encoder.WriteInt(this.m_npcStars.Size());
			for (int num8 = 0; num8 < this.m_npcStars.Size(); num8++)
			{
				this.m_npcStars[num8].Encode(encoder);
			}
			encoder.WriteInt(this.m_lootedNpcGold.Size());
			for (int num9 = 0; num9 < this.m_lootedNpcGold.Size(); num9++)
			{
				this.m_lootedNpcGold[num9].Encode(encoder);
			}
			encoder.WriteInt(this.m_lootedNpcElixir.Size());
			for (int num10 = 0; num10 < this.m_lootedNpcElixir.Size(); num10++)
			{
				this.m_lootedNpcElixir[num10].Encode(encoder);
			}
			encoder.WriteInt(this.m_allianceUnitVisitCapacity);
			encoder.WriteInt(this.m_allianceUnitSpellVisitCapacity);
			encoder.WriteInt(this.m_heroMode.Size());
			for (int num11 = 0; num11 < this.m_heroMode.Size(); num11++)
			{
				this.m_heroMode[num11].Encode(encoder);
			}
			encoder.WriteInt(this.m_variables.Size());
			for (int num12 = 0; num12 < this.m_variables.Size(); num12++)
			{
				this.m_variables[num12].Encode(encoder);
			}
			encoder.WriteInt(this.m_unitPreset1.Size());
			for (int num13 = 0; num13 < this.m_unitPreset1.Size(); num13++)
			{
				this.m_unitPreset1[num13].Encode(encoder);
			}
			encoder.WriteInt(this.m_unitPreset2.Size());
			for (int num14 = 0; num14 < this.m_unitPreset2.Size(); num14++)
			{
				this.m_unitPreset2[num14].Encode(encoder);
			}
			encoder.WriteInt(this.m_unitPreset3.Size());
			for (int num15 = 0; num15 < this.m_unitPreset3.Size(); num15++)
			{
				this.m_unitPreset3[num15].Encode(encoder);
			}
			encoder.WriteInt(this.m_previousArmy.Size());
			for (int num16 = 0; num16 < this.m_previousArmy.Size(); num16++)
			{
				this.m_previousArmy[num16].Encode(encoder);
			}
			encoder.WriteInt(this.m_eventUnitCounter.Size());
			for (int num17 = 0; num17 < this.m_eventUnitCounter.Size(); num17++)
			{
				this.m_eventUnitCounter[num17].Encode(encoder);
			}
			encoder.WriteInt(this.m_unitCountVillage2.Size());
			for (int num18 = 0; num18 < this.m_unitCountVillage2.Size(); num18++)
			{
				this.m_unitCountVillage2[num18].Encode(encoder);
			}
			encoder.WriteInt(this.m_unitCountNewVillage2.Size());
			for (int num19 = 0; num19 < this.m_unitCountNewVillage2.Size(); num19++)
			{
				this.m_unitCountNewVillage2[num19].Encode(encoder);
			}
			encoder.WriteInt(this.m_freeActionCount.Size());
			for (int num20 = 0; num20 < this.m_freeActionCount.Size(); num20++)
			{
				this.m_freeActionCount[num20].Encode(encoder);
			}
		}

		// Token: 0x06001B08 RID: 6920 RVA: 0x00067990 File Offset: 0x00065B90
		public void Load(LogicJSONObject jsonObject)
		{
			LogicJSONString jsonstring = jsonObject.GetJSONString("name");
			if (jsonstring != null)
			{
				this.string_2 = jsonstring.GetStringValue();
			}
			LogicJSONBoolean jsonboolean = jsonObject.GetJSONBoolean("name_set");
			if (jsonboolean != null)
			{
				this.bool_0 = jsonboolean.IsTrue();
			}
			LogicJSONNumber jsonnumber = jsonObject.GetJSONNumber("name_change_state");
			if (jsonnumber != null)
			{
				this.int_20 = jsonnumber.GetIntValue();
			}
			LogicJSONNumber jsonnumber2 = jsonObject.GetJSONNumber("badge_id");
			if (jsonnumber2 != null)
			{
				this.m_allianceBadgeId = jsonnumber2.GetIntValue();
			}
			LogicJSONNumber jsonnumber3 = jsonObject.GetJSONNumber("alliance_exp_level");
			if (jsonnumber3 != null)
			{
				this.int_0 = jsonnumber3.GetIntValue();
			}
			if (this.m_allianceBadgeId == -1)
			{
				this.logicLong_2 = null;
			}
			else
			{
				LogicJSONNumber jsonnumber4 = jsonObject.GetJSONNumber("alliance_id_low");
				LogicJSONNumber jsonnumber5 = jsonObject.GetJSONNumber("alliance_id_high");
				int highInteger = -1;
				int lowInteger = -1;
				if (jsonnumber5 != null && jsonnumber4 != null)
				{
					highInteger = jsonnumber5.GetIntValue();
					lowInteger = jsonnumber4.GetIntValue();
				}
				this.logicLong_2 = new LogicLong(highInteger, lowInteger);
				this.string_1 = LogicJSONHelper.GetString(jsonObject, "alliance_name");
				this.logicAvatarAllianceRole_0 = (LogicAvatarAllianceRole)LogicJSONHelper.GetInt(jsonObject, "alliance_role");
			}
			LogicJSONNumber jsonnumber6 = jsonObject.GetJSONNumber("league_id_low");
			LogicJSONNumber jsonnumber7 = jsonObject.GetJSONNumber("league_id_high");
			if (jsonnumber7 != null && jsonnumber6 != null)
			{
				this.logicLong_3 = new LogicLong(jsonnumber7.GetIntValue(), jsonnumber6.GetIntValue());
			}
			this.m_allianceUnitVisitCapacity = LogicJSONHelper.GetInt(jsonObject, "alliance_unit_visit_capacity", 0);
			this.m_allianceUnitSpellVisitCapacity = LogicJSONHelper.GetInt(jsonObject, "alliance_unit_spell_visit_capacity", 0);
			this.int_3 = LogicJSONHelper.GetInt(jsonObject, "xp_level", 0);
			this.int_4 = LogicJSONHelper.GetInt(jsonObject, "xp_points", 0);
			this.int_5 = LogicJSONHelper.GetInt(jsonObject, "diamonds", 0);
			this.int_6 = LogicJSONHelper.GetInt(jsonObject, "free_diamonds", 0);
			this.m_leagueType = LogicJSONHelper.GetInt(jsonObject, "league_type", 0);
			this.int_1 = LogicJSONHelper.GetInt(jsonObject, "legendary_score", 0);
			this.int_2 = LogicJSONHelper.GetInt(jsonObject, "legendary_score_v2", 0);
			LogicJSONObject jsonobject = jsonObject.GetJSONObject("legend_league_entry");
			if (jsonobject != null)
			{
				this.logicAvatarTournamentEntry_0.ReadFromJSON(jsonobject);
			}
			LogicJSONObject jsonobject2 = jsonObject.GetJSONObject("legend_league_entry_v2");
			if (jsonobject2 != null)
			{
				this.logicAvatarTournamentEntry_1.ReadFromJSON(jsonobject2);
			}
			this.method_0(jsonObject, "units", this.m_unitCount);
			this.method_0(jsonObject, "spells", this.m_spellCount);
			this.method_0(jsonObject, "unit_upgrades", this.m_unitUpgrade);
			this.method_0(jsonObject, "spell_upgrades", this.m_spellUpgrade);
			this.method_0(jsonObject, "resources", this.m_resourceCount);
			this.method_0(jsonObject, "resource_caps", this.m_resourceCap);
			this.method_1(jsonObject, "alliance_units", this.m_allianceUnitCount);
			this.method_0(jsonObject, "hero_states", this.m_heroState);
			this.method_0(jsonObject, "hero_health", this.m_heroHealth);
			this.method_0(jsonObject, "hero_upgrade", this.m_heroUpgrade);
			this.method_0(jsonObject, "hero_modes", this.m_heroMode);
			this.method_0(jsonObject, "variables", this.m_variables);
			this.method_0(jsonObject, "units2", this.m_unitCountVillage2);
			this.method_0(jsonObject, "units_new2", this.m_unitCountNewVillage2);
			this.method_0(jsonObject, "unit_preset1", this.m_unitPreset1);
			this.method_0(jsonObject, "unit_preset2", this.m_unitPreset2);
			this.method_0(jsonObject, "unit_preset3", this.m_unitPreset3);
			this.method_0(jsonObject, "previous_army", this.m_previousArmy);
			this.method_0(jsonObject, "event_unit_counter", this.m_eventUnitCounter);
			this.method_0(jsonObject, "looted_npc_gold", this.m_lootedNpcGold);
			this.method_0(jsonObject, "looted_npc_elixir", this.m_lootedNpcElixir);
			this.method_0(jsonObject, "npc_stars", this.m_npcStars);
			this.method_0(jsonObject, "achievement_progress", this.m_achievementProgress);
			LogicJSONArray jsonarray = jsonObject.GetJSONArray("achievement_rewards");
			if (jsonarray != null && jsonarray.Size() != 0)
			{
				this.m_achievementRewardClaimed.Clear();
				this.m_achievementRewardClaimed.EnsureCapacity(jsonarray.Size());
				for (int i = 0; i < jsonarray.Size(); i++)
				{
					LogicJSONNumber jsonnumber8 = jsonarray.GetJSONNumber(i);
					if (jsonnumber8 != null)
					{
						LogicData dataById = LogicDataTables.GetDataById(jsonnumber8.GetIntValue());
						if (dataById != null)
						{
							this.m_achievementRewardClaimed.Add(dataById);
						}
					}
				}
			}
			LogicJSONArray jsonarray2 = jsonObject.GetJSONArray("missions");
			if (jsonarray2 != null && jsonarray2.Size() != 0)
			{
				this.m_missionCompleted.Clear();
				this.m_missionCompleted.EnsureCapacity(jsonarray2.Size());
				for (int j = 0; j < jsonarray2.Size(); j++)
				{
					LogicJSONNumber jsonnumber9 = jsonarray2.GetJSONNumber(j);
					if (jsonnumber9 != null)
					{
						LogicData dataById2 = LogicDataTables.GetDataById(jsonnumber9.GetIntValue());
						if (dataById2 != null)
						{
							this.m_missionCompleted.Add(dataById2);
						}
					}
				}
			}
			this.m_allianceCastleLevel = LogicJSONHelper.GetInt(jsonObject, "castle_lvl", -1);
			this.m_allianceCastleTotalCapacity = LogicJSONHelper.GetInt(jsonObject, "castle_total", 0);
			this.m_allianceCastleUsedCapacity = LogicJSONHelper.GetInt(jsonObject, "castle_used", 0);
			this.m_allianceCastleTotalSpellCapacity = LogicJSONHelper.GetInt(jsonObject, "castle_total_sp", 0);
			this.m_allianceCastleUsedSpellCapacity = LogicJSONHelper.GetInt(jsonObject, "castle_used_sp", 0);
			this.m_townHallLevel = LogicJSONHelper.GetInt(jsonObject, "town_hall_lvl", 0);
			this.m_townHallLevelVillage2 = LogicJSONHelper.GetInt(jsonObject, "th_v2_lvl", 0);
			this.int_8 = LogicJSONHelper.GetInt(jsonObject, "score", 0);
			this.int_9 = LogicJSONHelper.GetInt(jsonObject, "duel_score", 0);
			this.int_10 = LogicJSONHelper.GetInt(jsonObject, "war_preference", 0);
			this.int_11 = LogicJSONHelper.GetInt(jsonObject, "attack_rating", 0);
			this.int_12 = LogicJSONHelper.GetInt(jsonObject, "atack_kfactor", 0);
			this.int_13 = LogicJSONHelper.GetInt(jsonObject, "attack_win_cnt", 0);
			this.int_14 = LogicJSONHelper.GetInt(jsonObject, "attack_lose_cnt", 0);
			this.int_15 = LogicJSONHelper.GetInt(jsonObject, "defense_win_cnt", 0);
			this.int_16 = LogicJSONHelper.GetInt(jsonObject, "defense_lose_cnt", 0);
			this.int_17 = LogicJSONHelper.GetInt(jsonObject, "treasury_gold_cnt", 0);
			this.int_18 = LogicJSONHelper.GetInt(jsonObject, "treasury_elixir_cnt", 0);
			this.int_19 = LogicJSONHelper.GetInt(jsonObject, "treasury_dark_elixir_cnt", 0);
			this.m_redPackageState = LogicJSONHelper.GetInt(jsonObject, "red_package_state", 0);
			this.bool_1 = LogicJSONHelper.GetBool(jsonObject, "alliance_chat_filter");
			this.int_7 = LogicJSONHelper.GetInt(jsonObject, "cumulative_purchased_diamonds", 0);
			this.int_21 = LogicJSONHelper.GetInt(jsonObject, "attack_shield_reduce_counter", 0);
			this.int_22 = LogicJSONHelper.GetInt(jsonObject, "defense_village_guard_counter", 0);
			this.int_23 = LogicJSONHelper.GetInt(jsonObject, "duel_win_cnt", 0);
			this.int_25 = LogicJSONHelper.GetInt(jsonObject, "duel_draw_cnt", 0);
			this.int_24 = LogicJSONHelper.GetInt(jsonObject, "duel_lose_cnt", 0);
		}

		// Token: 0x06001B09 RID: 6921 RVA: 0x00068038 File Offset: 0x00066238
		public override void LoadForReplay(LogicJSONObject jsonObject, bool replay)
		{
			LogicJSONNumber jsonnumber = jsonObject.GetJSONNumber("avatar_id_low");
			LogicJSONNumber jsonnumber2 = jsonObject.GetJSONNumber("avatar_id_high");
			if (jsonnumber2 != null && jsonnumber != null)
			{
				this.logicLong_0 = new LogicLong(jsonnumber2.GetIntValue(), jsonnumber.GetIntValue());
			}
			LogicJSONString jsonstring = jsonObject.GetJSONString("name");
			if (jsonstring != null)
			{
				this.string_2 = jsonstring.GetStringValue();
			}
			LogicJSONNumber jsonnumber3 = jsonObject.GetJSONNumber("badge_id");
			if (jsonnumber3 != null)
			{
				this.m_allianceBadgeId = jsonnumber3.GetIntValue();
			}
			LogicJSONNumber jsonnumber4 = jsonObject.GetJSONNumber("alliance_exp_level");
			if (jsonnumber4 != null)
			{
				this.int_0 = jsonnumber4.GetIntValue();
			}
			if (this.m_allianceBadgeId != -1)
			{
				LogicJSONNumber jsonnumber5 = jsonObject.GetJSONNumber("alliance_id_low");
				LogicJSONNumber jsonnumber6 = jsonObject.GetJSONNumber("alliance_id_high");
				int highInteger = -1;
				int lowInteger = -1;
				if (jsonnumber6 != null && jsonnumber5 != null)
				{
					highInteger = jsonnumber6.GetIntValue();
					lowInteger = jsonnumber5.GetIntValue();
				}
				this.logicLong_2 = new LogicLong(highInteger, lowInteger);
				this.string_1 = LogicJSONHelper.GetString(jsonObject, "alliance_name");
			}
			else
			{
				this.logicLong_2 = null;
			}
			this.m_allianceUnitVisitCapacity = LogicJSONHelper.GetInt(jsonObject, "alliance_unit_visit_capacity", 0);
			this.m_allianceUnitSpellVisitCapacity = LogicJSONHelper.GetInt(jsonObject, "alliance_unit_spell_visit_capacity", 0);
			this.m_leagueType = LogicJSONHelper.GetInt(jsonObject, "league_type", 0);
			this.int_3 = LogicJSONHelper.GetInt(jsonObject, "xp_level", 1);
			if (replay)
			{
				this.method_0(jsonObject, "units", this.m_unitCount);
				this.method_0(jsonObject, "spells", this.m_spellCount);
				this.method_0(jsonObject, "unit_upgrades", this.m_unitUpgrade);
				this.method_0(jsonObject, "spell_upgrades", this.m_spellUpgrade);
			}
			this.method_0(jsonObject, "resources", this.m_resourceCount);
			this.method_1(jsonObject, "alliance_units", this.m_allianceUnitCount);
			this.method_0(jsonObject, "hero_states", this.m_heroState);
			this.method_0(jsonObject, "hero_health", this.m_heroHealth);
			this.method_0(jsonObject, "hero_upgrade", this.m_heroUpgrade);
			this.method_0(jsonObject, "hero_modes", this.m_heroMode);
			this.method_0(jsonObject, "variables", this.m_variables);
			if (replay)
			{
				this.method_0(jsonObject, "units2", this.m_unitCountVillage2);
			}
			this.m_allianceCastleLevel = LogicJSONHelper.GetInt(jsonObject, "castle_lvl", -1);
			this.m_allianceCastleTotalCapacity = LogicJSONHelper.GetInt(jsonObject, "castle_total", 0);
			this.m_allianceCastleUsedCapacity = LogicJSONHelper.GetInt(jsonObject, "castle_used", 0);
			this.m_allianceCastleTotalSpellCapacity = LogicJSONHelper.GetInt(jsonObject, "castle_total_sp", 0);
			this.m_allianceCastleUsedSpellCapacity = LogicJSONHelper.GetInt(jsonObject, "castle_used_sp", 0);
			this.m_townHallLevel = LogicJSONHelper.GetInt(jsonObject, "town_hall_lvl", -1);
			this.m_townHallLevelVillage2 = LogicJSONHelper.GetInt(jsonObject, "th_v2_lvl", -1);
			this.int_8 = LogicJSONHelper.GetInt(jsonObject, "score", 0);
			this.int_9 = LogicJSONHelper.GetInt(jsonObject, "duel_score", 0);
			this.m_redPackageState = LogicJSONHelper.GetInt(jsonObject, "red_package_state", 0);
		}

		// Token: 0x06001B0A RID: 6922 RVA: 0x00068314 File Offset: 0x00066514
		private void method_0(LogicJSONObject logicJSONObject_0, string string_3, LogicArrayList<LogicDataSlot> logicArrayList_0)
		{
			base.ClearDataSlotArray(logicArrayList_0);
			LogicJSONArray jsonarray = logicJSONObject_0.GetJSONArray(string_3);
			if (jsonarray != null)
			{
				int num = jsonarray.Size();
				if (num != 0)
				{
					logicArrayList_0.EnsureCapacity(num);
					for (int i = 0; i < num; i++)
					{
						LogicJSONObject jsonobject = jsonarray.GetJSONObject(i);
						if (jsonobject != null)
						{
							LogicDataSlot logicDataSlot = new LogicDataSlot(null, 0);
							logicDataSlot.ReadFromJSON(jsonobject);
							if (logicDataSlot.GetData() != null)
							{
								logicArrayList_0.Add(logicDataSlot);
							}
						}
					}
				}
			}
		}

		// Token: 0x06001B0B RID: 6923 RVA: 0x00068380 File Offset: 0x00066580
		private void method_1(LogicJSONObject logicJSONObject_0, string string_3, LogicArrayList<LogicUnitSlot> logicArrayList_0)
		{
			base.ClearUnitSlotArray(logicArrayList_0);
			LogicJSONArray jsonarray = logicJSONObject_0.GetJSONArray(string_3);
			if (jsonarray != null)
			{
				int num = jsonarray.Size();
				if (num != 0)
				{
					logicArrayList_0.EnsureCapacity(num);
					for (int i = 0; i < num; i++)
					{
						LogicJSONObject jsonobject = jsonarray.GetJSONObject(i);
						if (jsonobject != null)
						{
							LogicUnitSlot logicUnitSlot = new LogicUnitSlot(null, 0, 0);
							logicUnitSlot.ReadFromJSON(jsonobject);
							if (logicUnitSlot.GetData() != null)
							{
								logicArrayList_0.Add(logicUnitSlot);
							}
						}
					}
				}
			}
		}

		// Token: 0x06001B0C RID: 6924 RVA: 0x000683EC File Offset: 0x000665EC
		public void Save(LogicJSONObject jsonObject)
		{
			jsonObject.Put("name", new LogicJSONString(this.string_2));
			jsonObject.Put("name_set", new LogicJSONBoolean(this.bool_0));
			jsonObject.Put("name_change_state", new LogicJSONNumber(this.int_20));
			jsonObject.Put("alliance_name", new LogicJSONString(this.string_1 ?? string.Empty));
			jsonObject.Put("xp_level", new LogicJSONNumber(this.int_3));
			jsonObject.Put("xp_points", new LogicJSONNumber(this.int_4));
			jsonObject.Put("diamonds", new LogicJSONNumber(this.int_5));
			jsonObject.Put("free_diamonds", new LogicJSONNumber(this.int_6));
			if (this.logicLong_2 != null)
			{
				jsonObject.Put("alliance_id_high", new LogicJSONNumber(this.logicLong_2.GetHigherInt()));
				jsonObject.Put("alliance_id_low", new LogicJSONNumber(this.logicLong_2.GetLowerInt()));
				jsonObject.Put("badge_id", new LogicJSONNumber(this.m_allianceBadgeId));
				jsonObject.Put("alliance_role", new LogicJSONNumber((int)this.logicAvatarAllianceRole_0));
				jsonObject.Put("alliance_exp_level", new LogicJSONNumber(this.int_0));
				jsonObject.Put("alliance_unit_visit_capacity", new LogicJSONNumber(this.m_allianceUnitVisitCapacity));
				jsonObject.Put("alliance_unit_spell_visit_capacity", new LogicJSONNumber(this.m_allianceUnitSpellVisitCapacity));
			}
			if (this.logicLong_3 != null)
			{
				jsonObject.Put("league_id_high", new LogicJSONNumber(this.logicLong_3.GetHigherInt()));
				jsonObject.Put("league_id_low", new LogicJSONNumber(this.logicLong_3.GetLowerInt()));
			}
			jsonObject.Put("league_type", new LogicJSONNumber(this.m_leagueType));
			jsonObject.Put("legendary_score", new LogicJSONNumber(this.int_1));
			jsonObject.Put("legendary_score_v2", new LogicJSONNumber(this.int_2));
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			this.logicAvatarTournamentEntry_0.WriteToJSON(logicJSONObject);
			jsonObject.Put("legend_league_entry", logicJSONObject);
			LogicJSONObject logicJSONObject2 = new LogicJSONObject();
			this.logicAvatarTournamentEntry_1.WriteToJSON(logicJSONObject2);
			jsonObject.Put("legend_league_entry_v2", logicJSONObject2);
			this.method_2(jsonObject, "units", this.m_unitCount);
			this.method_2(jsonObject, "spells", this.m_spellCount);
			this.method_2(jsonObject, "unit_upgrades", this.m_unitUpgrade);
			this.method_2(jsonObject, "spell_upgrades", this.m_spellUpgrade);
			this.method_2(jsonObject, "resources", this.m_resourceCount);
			this.method_2(jsonObject, "resource_caps", this.m_resourceCap);
			this.method_3(jsonObject, "alliance_units", this.m_allianceUnitCount);
			this.method_2(jsonObject, "hero_states", this.m_heroState);
			this.method_2(jsonObject, "hero_health", this.m_heroHealth);
			this.method_2(jsonObject, "hero_upgrade", this.m_heroUpgrade);
			this.method_2(jsonObject, "hero_modes", this.m_heroMode);
			this.method_2(jsonObject, "variables", this.m_variables);
			this.method_2(jsonObject, "units2", this.m_unitCountVillage2);
			this.method_2(jsonObject, "units_new2", this.m_unitCountNewVillage2);
			this.method_2(jsonObject, "unit_preset1", this.m_unitPreset1);
			this.method_2(jsonObject, "unit_preset2", this.m_unitPreset2);
			this.method_2(jsonObject, "unit_preset3", this.m_unitPreset3);
			this.method_2(jsonObject, "previous_army", this.m_previousArmy);
			this.method_2(jsonObject, "event_unit_counter", this.m_eventUnitCounter);
			this.method_2(jsonObject, "looted_npc_gold", this.m_lootedNpcGold);
			this.method_2(jsonObject, "looted_npc_elixir", this.m_lootedNpcElixir);
			this.method_2(jsonObject, "npc_stars", this.m_npcStars);
			this.method_2(jsonObject, "achievement_progress", this.m_achievementProgress);
			LogicJSONArray logicJSONArray = new LogicJSONArray();
			for (int i = 0; i < this.m_achievementRewardClaimed.Size(); i++)
			{
				logicJSONArray.Add(new LogicJSONNumber(this.m_achievementRewardClaimed[i].GetGlobalID()));
			}
			jsonObject.Put("achievement_rewards", logicJSONArray);
			LogicJSONArray logicJSONArray2 = new LogicJSONArray();
			for (int j = 0; j < this.m_missionCompleted.Size(); j++)
			{
				logicJSONArray2.Add(new LogicJSONNumber(this.m_missionCompleted[j].GetGlobalID()));
			}
			jsonObject.Put("missions", logicJSONArray2);
			jsonObject.Put("castle_lvl", new LogicJSONNumber(this.m_allianceCastleLevel));
			jsonObject.Put("castle_total", new LogicJSONNumber(this.m_allianceCastleTotalCapacity));
			jsonObject.Put("castle_used", new LogicJSONNumber(this.m_allianceCastleUsedCapacity));
			jsonObject.Put("castle_total_sp", new LogicJSONNumber(this.m_allianceCastleTotalSpellCapacity));
			jsonObject.Put("castle_used_sp", new LogicJSONNumber(this.m_allianceCastleUsedSpellCapacity));
			jsonObject.Put("town_hall_lvl", new LogicJSONNumber(this.m_townHallLevel));
			jsonObject.Put("th_v2_lvl", new LogicJSONNumber(this.m_townHallLevelVillage2));
			jsonObject.Put("score", new LogicJSONNumber(this.int_8));
			jsonObject.Put("duel_score", new LogicJSONNumber(this.int_9));
			jsonObject.Put("war_preference", new LogicJSONNumber(this.int_10));
			jsonObject.Put("attack_rating", new LogicJSONNumber(this.int_11));
			jsonObject.Put("atack_kfactor", new LogicJSONNumber(this.int_12));
			jsonObject.Put("attack_win_cnt", new LogicJSONNumber(this.int_13));
			jsonObject.Put("attack_lose_cnt", new LogicJSONNumber(this.int_14));
			jsonObject.Put("defense_win_cnt", new LogicJSONNumber(this.int_15));
			jsonObject.Put("defense_lose_cnt", new LogicJSONNumber(this.int_16));
			jsonObject.Put("treasury_gold_cnt", new LogicJSONNumber(this.int_17));
			jsonObject.Put("treasury_elixir_cnt", new LogicJSONNumber(this.int_18));
			jsonObject.Put("treasury_dark_elixir_cnt", new LogicJSONNumber(this.int_19));
			if (this.m_redPackageState != 0)
			{
				jsonObject.Put("red_package_state", new LogicJSONNumber(this.m_redPackageState));
			}
			jsonObject.Put("alliance_chat_filter", new LogicJSONBoolean(this.bool_1));
			jsonObject.Put("cumulative_purchased_diamonds", new LogicJSONNumber(this.int_7));
			jsonObject.Put("attack_shield_reduce_counter", new LogicJSONNumber(this.int_21));
			jsonObject.Put("defense_village_guard_counter", new LogicJSONNumber(this.int_22));
			jsonObject.Put("duel_win_cnt", new LogicJSONNumber(this.int_23));
			jsonObject.Put("duel_draw_cnt", new LogicJSONNumber(this.int_25));
			jsonObject.Put("duel_lose_cnt", new LogicJSONNumber(this.int_24));
		}

		// Token: 0x06001B0D RID: 6925 RVA: 0x00068AA8 File Offset: 0x00066CA8
		public override void SaveToReplay(LogicJSONObject jsonObject)
		{
			jsonObject.Put("avatar_id_high", new LogicJSONNumber(this.logicLong_0.GetHigherInt()));
			jsonObject.Put("avatar_id_low", new LogicJSONNumber(this.logicLong_0.GetLowerInt()));
			jsonObject.Put("name", new LogicJSONString(this.string_2));
			jsonObject.Put("alliance_name", new LogicJSONString(this.string_1 ?? string.Empty));
			jsonObject.Put("xp_level", new LogicJSONNumber(this.int_3));
			if (this.logicLong_2 != null)
			{
				jsonObject.Put("alliance_id_high", new LogicJSONNumber(this.logicLong_2.GetHigherInt()));
				jsonObject.Put("alliance_id_low", new LogicJSONNumber(this.logicLong_2.GetLowerInt()));
				jsonObject.Put("badge_id", new LogicJSONNumber(this.m_allianceBadgeId));
				jsonObject.Put("alliance_exp_level", new LogicJSONNumber(this.int_0));
				jsonObject.Put("alliance_unit_visit_capacity", new LogicJSONNumber(this.m_allianceUnitVisitCapacity));
				jsonObject.Put("alliance_unit_spell_visit_capacity", new LogicJSONNumber(this.m_allianceUnitSpellVisitCapacity));
			}
			jsonObject.Put("league_type", new LogicJSONNumber(this.m_leagueType));
			this.method_2(jsonObject, "units", this.m_unitCount);
			this.method_2(jsonObject, "spells", this.m_spellCount);
			this.method_2(jsonObject, "unit_upgrades", this.m_unitUpgrade);
			this.method_2(jsonObject, "spell_upgrades", this.m_spellUpgrade);
			this.method_2(jsonObject, "resources", this.m_resourceCount);
			this.method_3(jsonObject, "alliance_units", this.m_allianceUnitCount);
			this.method_2(jsonObject, "hero_states", this.m_heroState);
			this.method_2(jsonObject, "hero_health", this.m_heroHealth);
			this.method_2(jsonObject, "hero_upgrade", this.m_heroUpgrade);
			this.method_2(jsonObject, "hero_modes", this.m_heroMode);
			this.method_2(jsonObject, "variables", this.m_variables);
			this.method_2(jsonObject, "units2", this.m_unitCountVillage2);
			jsonObject.Put("castle_lvl", new LogicJSONNumber(this.m_allianceCastleLevel));
			jsonObject.Put("castle_total", new LogicJSONNumber(this.m_allianceCastleTotalCapacity));
			jsonObject.Put("castle_used", new LogicJSONNumber(this.m_allianceCastleUsedCapacity));
			jsonObject.Put("castle_total_sp", new LogicJSONNumber(this.m_allianceCastleTotalSpellCapacity));
			jsonObject.Put("castle_used_sp", new LogicJSONNumber(this.m_allianceCastleUsedSpellCapacity));
			jsonObject.Put("town_hall_lvl", new LogicJSONNumber(this.m_townHallLevel));
			jsonObject.Put("th_v2_lvl", new LogicJSONNumber(this.m_townHallLevelVillage2));
			jsonObject.Put("score", new LogicJSONNumber(this.int_8));
			jsonObject.Put("duel_score", new LogicJSONNumber(this.int_9));
			if (this.m_redPackageState != 0)
			{
				jsonObject.Put("red_package_state", new LogicJSONNumber(this.m_redPackageState));
			}
		}

		// Token: 0x06001B0E RID: 6926 RVA: 0x00068DA4 File Offset: 0x00066FA4
		public override void SaveToDirect(LogicJSONObject jsonObject)
		{
			jsonObject.Put("avatar_id_high", new LogicJSONNumber(this.logicLong_0.GetHigherInt()));
			jsonObject.Put("avatar_id_low", new LogicJSONNumber(this.logicLong_0.GetLowerInt()));
			jsonObject.Put("name", new LogicJSONString(this.string_2));
			jsonObject.Put("alliance_name", new LogicJSONString(this.string_1 ?? string.Empty));
			jsonObject.Put("xp_level", new LogicJSONNumber(this.int_3));
			if (this.logicLong_2 != null)
			{
				jsonObject.Put("alliance_id_high", new LogicJSONNumber(this.logicLong_2.GetHigherInt()));
				jsonObject.Put("alliance_id_low", new LogicJSONNumber(this.logicLong_2.GetLowerInt()));
				jsonObject.Put("badge_id", new LogicJSONNumber(this.m_allianceBadgeId));
				jsonObject.Put("alliance_exp_level", new LogicJSONNumber(this.int_0));
				jsonObject.Put("alliance_unit_visit_capacity", new LogicJSONNumber(this.m_allianceUnitVisitCapacity));
				jsonObject.Put("alliance_unit_spell_visit_capacity", new LogicJSONNumber(this.m_allianceUnitSpellVisitCapacity));
			}
			jsonObject.Put("league_type", new LogicJSONNumber(this.m_leagueType));
			this.method_2(jsonObject, "resources", this.m_resourceCount);
			this.method_3(jsonObject, "alliance_units", this.m_allianceUnitCount);
			this.method_2(jsonObject, "hero_states", this.m_heroState);
			this.method_2(jsonObject, "hero_health", this.m_heroHealth);
			this.method_2(jsonObject, "hero_upgrade", this.m_heroUpgrade);
			this.method_2(jsonObject, "hero_modes", this.m_heroMode);
			this.method_2(jsonObject, "variables", this.m_variables);
			jsonObject.Put("castle_lvl", new LogicJSONNumber(this.m_allianceCastleLevel));
			jsonObject.Put("castle_total", new LogicJSONNumber(this.m_allianceCastleTotalCapacity));
			jsonObject.Put("castle_used", new LogicJSONNumber(this.m_allianceCastleUsedCapacity));
			jsonObject.Put("castle_total_sp", new LogicJSONNumber(this.m_allianceCastleTotalSpellCapacity));
			jsonObject.Put("castle_used_sp", new LogicJSONNumber(this.m_allianceCastleUsedSpellCapacity));
			jsonObject.Put("town_hall_lvl", new LogicJSONNumber(this.m_townHallLevel));
			jsonObject.Put("th_v2_lvl", new LogicJSONNumber(this.m_townHallLevelVillage2));
			jsonObject.Put("score", new LogicJSONNumber(this.int_8));
			jsonObject.Put("duel_score", new LogicJSONNumber(this.int_9));
			if (this.m_redPackageState != 0)
			{
				jsonObject.Put("red_package_state", new LogicJSONNumber(this.m_redPackageState));
			}
		}

		// Token: 0x06001B0F RID: 6927 RVA: 0x00069044 File Offset: 0x00067244
		private void method_2(LogicJSONObject logicJSONObject_0, string string_3, LogicArrayList<LogicDataSlot> logicArrayList_0)
		{
			LogicJSONArray logicJSONArray = new LogicJSONArray(logicArrayList_0.Size());
			for (int i = 0; i < logicArrayList_0.Size(); i++)
			{
				LogicJSONObject logicJSONObject = new LogicJSONObject();
				logicArrayList_0[i].WriteToJSON(logicJSONObject);
				logicJSONArray.Add(logicJSONObject);
			}
			logicJSONObject_0.Put(string_3, logicJSONArray);
		}

		// Token: 0x06001B10 RID: 6928 RVA: 0x00069090 File Offset: 0x00067290
		private void method_3(LogicJSONObject logicJSONObject_0, string string_3, LogicArrayList<LogicUnitSlot> logicArrayList_0)
		{
			LogicJSONArray logicJSONArray = new LogicJSONArray(logicArrayList_0.Size());
			for (int i = 0; i < logicArrayList_0.Size(); i++)
			{
				LogicJSONObject logicJSONObject = new LogicJSONObject();
				logicArrayList_0[i].WriteToJSON(logicJSONObject);
				logicJSONArray.Add(logicJSONObject);
			}
			logicJSONObject_0.Put(string_3, logicJSONArray);
		}

		// Token: 0x04000E44 RID: 3652
		private LogicLong logicLong_0;

		// Token: 0x04000E45 RID: 3653
		private LogicLong logicLong_1;

		// Token: 0x04000E46 RID: 3654
		private LogicLong logicLong_2;

		// Token: 0x04000E47 RID: 3655
		private LogicLong logicLong_3;

		// Token: 0x04000E48 RID: 3656
		private LogicLong logicLong_4;

		// Token: 0x04000E49 RID: 3657
		private LogicLong logicLong_5;

		// Token: 0x04000E4A RID: 3658
		private LogicAvatarTournamentEntry logicAvatarTournamentEntry_0;

		// Token: 0x04000E4B RID: 3659
		private LogicAvatarTournamentEntry logicAvatarTournamentEntry_1;

		// Token: 0x04000E4C RID: 3660
		private bool bool_0;

		// Token: 0x04000E4D RID: 3661
		private bool bool_1;

		// Token: 0x04000E4E RID: 3662
		private LogicAvatarAllianceRole logicAvatarAllianceRole_0;

		// Token: 0x04000E4F RID: 3663
		private int int_0;

		// Token: 0x04000E50 RID: 3664
		private int int_1;

		// Token: 0x04000E51 RID: 3665
		private int int_2;

		// Token: 0x04000E52 RID: 3666
		private int int_3;

		// Token: 0x04000E53 RID: 3667
		private int int_4;

		// Token: 0x04000E54 RID: 3668
		private int int_5;

		// Token: 0x04000E55 RID: 3669
		private int int_6;

		// Token: 0x04000E56 RID: 3670
		private int int_7;

		// Token: 0x04000E57 RID: 3671
		private int int_8;

		// Token: 0x04000E58 RID: 3672
		private int int_9;

		// Token: 0x04000E59 RID: 3673
		private int int_10;

		// Token: 0x04000E5A RID: 3674
		private int int_11;

		// Token: 0x04000E5B RID: 3675
		private int int_12;

		// Token: 0x04000E5C RID: 3676
		private int int_13;

		// Token: 0x04000E5D RID: 3677
		private int int_14;

		// Token: 0x04000E5E RID: 3678
		private int int_15;

		// Token: 0x04000E5F RID: 3679
		private int int_16;

		// Token: 0x04000E60 RID: 3680
		private int int_17;

		// Token: 0x04000E61 RID: 3681
		private int int_18;

		// Token: 0x04000E62 RID: 3682
		private int int_19;

		// Token: 0x04000E63 RID: 3683
		private int int_20;

		// Token: 0x04000E64 RID: 3684
		private int int_21;

		// Token: 0x04000E65 RID: 3685
		private int int_22;

		// Token: 0x04000E66 RID: 3686
		private int int_23;

		// Token: 0x04000E67 RID: 3687
		private int int_24;

		// Token: 0x04000E68 RID: 3688
		private int int_25;

		// Token: 0x04000E69 RID: 3689
		private int int_26;

		// Token: 0x04000E6A RID: 3690
		private string string_0;

		// Token: 0x04000E6B RID: 3691
		private string string_1;

		// Token: 0x04000E6C RID: 3692
		private string string_2;
	}
}
