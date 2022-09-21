using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Time;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.GameObject.Component
{
	// Token: 0x02000129 RID: 297
	public sealed class LogicResourceProductionComponent : LogicComponent
	{
		// Token: 0x06001016 RID: 4118 RVA: 0x0000AE30 File Offset: 0x00009030
		public LogicResourceProductionComponent(LogicGameObject gameObject, LogicResourceData data) : base(gameObject)
		{
			this.logicTimer_0 = new LogicTimer();
			this.logicResourceData_0 = data;
		}

		// Token: 0x06001017 RID: 4119 RVA: 0x00002BCC File Offset: 0x00000DCC
		public override LogicComponentType GetComponentType()
		{
			return LogicComponentType.RESOURCE_PRODUCTION;
		}

		// Token: 0x06001018 RID: 4120 RVA: 0x0000AE4B File Offset: 0x0000904B
		public LogicResourceData GetResourceData()
		{
			return this.logicResourceData_0;
		}

		// Token: 0x06001019 RID: 4121 RVA: 0x00047294 File Offset: 0x00045494
		public void RestartTimer()
		{
			int totalSecs = 0;
			if (this.int_2 >= 1)
			{
				totalSecs = (int)(360000L * (long)this.int_1 / (long)this.int_2);
			}
			this.logicTimer_0.StartTimer(totalSecs, this.m_parent.GetLevel().GetLogicTime(), false, -1);
		}

		// Token: 0x0600101A RID: 4122 RVA: 0x0000AE53 File Offset: 0x00009053
		public void SetProduction(int productionPer100Hour, int maxResources)
		{
			this.int_2 = productionPer100Hour;
			this.int_1 = maxResources;
			this.RestartTimer();
		}

		// Token: 0x0600101B RID: 4123 RVA: 0x0000AE69 File Offset: 0x00009069
		public int GetStealableResourceCount()
		{
			return LogicMath.Min(this.GetResourceCount(), this.int_0);
		}

		// Token: 0x0600101C RID: 4124 RVA: 0x000472E8 File Offset: 0x000454E8
		public int GetResourceCount()
		{
			if (this.int_2 > 0)
			{
				int num = (int)(360000L * (long)this.int_1 / (long)this.int_2);
				if (num > 0)
				{
					int remainingSeconds = this.logicTimer_0.GetRemainingSeconds(this.m_parent.GetLevel().GetLogicTime());
					if (remainingSeconds != 0)
					{
						return (int)((long)this.int_2 * (long)(num - remainingSeconds) / 360000L);
					}
					return this.int_1;
				}
			}
			return 0;
		}

		// Token: 0x0600101D RID: 4125 RVA: 0x0004735C File Offset: 0x0004555C
		public void DecreaseResources(int count)
		{
			int resourceCount = this.GetResourceCount();
			int num = LogicMath.Min(count, resourceCount);
			if (this.int_2 != 0)
			{
				int num2 = (int)(360000L * (long)this.int_1 / (long)this.int_2);
				int num3 = (int)(360000L * (long)(resourceCount - num) / (long)this.int_2);
				this.logicTimer_0.StartTimer(num2 - num3, this.m_parent.GetLevel().GetLogicTime(), false, -1);
			}
		}

		// Token: 0x0600101E RID: 4126 RVA: 0x000473D4 File Offset: 0x000455D4
		public int CollectResources(bool updateListener)
		{
			if (this.m_parent.GetLevel().GetHomeOwnerAvatar() != null)
			{
				int num = this.GetResourceCount();
				if (this.m_parent.GetLevel().GetHomeOwnerAvatar().IsNpcAvatar())
				{
					Debugger.Error("LogicResourceProductionComponent::collectResources() called for Npc avatar");
				}
				else
				{
					LogicClientAvatar logicClientAvatar = (LogicClientAvatar)this.m_parent.GetLevel().GetHomeOwnerAvatar();
					if (num != 0)
					{
						if (this.logicResourceData_0.IsPremiumCurrency())
						{
							this.DecreaseResources(num);
							logicClientAvatar.SetDiamonds(logicClientAvatar.GetDiamonds() + num);
							logicClientAvatar.SetFreeDiamonds(logicClientAvatar.GetFreeDiamonds() + num);
							logicClientAvatar.GetChangeListener().FreeDiamondsAdded(num, 10);
						}
						else
						{
							int unusedResourceCap = logicClientAvatar.GetUnusedResourceCap(this.logicResourceData_0);
							if (unusedResourceCap != 0)
							{
								if (num > unusedResourceCap)
								{
									num = unusedResourceCap;
								}
								this.DecreaseResources(num);
								logicClientAvatar.CommodityCountChangeHelper(0, this.logicResourceData_0, num);
							}
							else
							{
								num = 0;
							}
						}
						return num;
					}
				}
			}
			return 0;
		}

		// Token: 0x0600101F RID: 4127 RVA: 0x000474B0 File Offset: 0x000456B0
		public override void FastForwardTime(int time)
		{
			int remainingSeconds = this.logicTimer_0.GetRemainingSeconds(this.m_parent.GetLevel().GetLogicTime());
			int remainingBoostTime = this.m_parent.GetRemainingBoostTime();
			if (remainingBoostTime > 0 && LogicDataTables.GetGlobals().GetResourceProductionBoostMultiplier() > 1 && !this.m_parent.IsBoostPaused())
			{
				time += (LogicDataTables.GetGlobals().GetResourceProductionBoostMultiplier() - 1) * LogicMath.Min(time, remainingBoostTime);
			}
			int updatedClockTowerBoostTime = this.m_parent.GetLevel().GetUpdatedClockTowerBoostTime();
			if (updatedClockTowerBoostTime > 0 && !this.m_parent.GetLevel().IsClockTowerBoostPaused() && this.m_parent.GetData().GetDataType() == LogicDataType.BUILDING && this.m_parent.GetData().GetVillageType() == 1)
			{
				time += (LogicDataTables.GetGlobals().GetClockTowerBoostMultiplier() - 1) * LogicMath.Min(time, updatedClockTowerBoostTime);
			}
			this.logicTimer_0.StartTimer((remainingSeconds <= time) ? 0 : (remainingSeconds - time), this.m_parent.GetLevel().GetLogicTime(), false, -1);
		}

		// Token: 0x06001020 RID: 4128 RVA: 0x000475A8 File Offset: 0x000457A8
		public override void GetChecksum(ChecksumHelper checksum)
		{
			checksum.StartObject("LogicResourceProductionComponent");
			checksum.WriteValue("resourceTimer", this.logicTimer_0.GetRemainingSeconds(this.m_parent.GetLevel().GetLogicTime()));
			checksum.WriteValue("m_availableLoot", this.int_0);
			checksum.WriteValue("m_maxResources", this.int_1);
			checksum.WriteValue("m_productionPer100Hour", this.int_2);
			checksum.EndObject();
		}

		// Token: 0x06001021 RID: 4129 RVA: 0x00047620 File Offset: 0x00045820
		public override void Load(LogicJSONObject jsonObject)
		{
			LogicJSONNumber jsonnumber = jsonObject.GetJSONNumber("res_time");
			int num = (this.int_2 > 0) ? ((int)(360000L * (long)this.int_1 / (long)this.int_2)) : 0;
			if (jsonnumber != null)
			{
				num = LogicMath.Min(jsonnumber.GetIntValue(), num);
			}
			this.logicTimer_0.StartTimer(num, this.m_parent.GetLevel().GetLogicTime(), false, -1);
		}

		// Token: 0x06001022 RID: 4130 RVA: 0x0000AE7C File Offset: 0x0000907C
		public override void Save(LogicJSONObject jsonObject, int villageType)
		{
			jsonObject.Put("res_time", new LogicJSONNumber(this.logicTimer_0.GetRemainingSeconds(this.m_parent.GetLevel().GetLogicTime())));
		}

		// Token: 0x06001023 RID: 4131 RVA: 0x00047690 File Offset: 0x00045890
		public void RecalculateAvailableLoot()
		{
			LogicAvatar homeOwnerAvatar = this.m_parent.GetLevel().GetHomeOwnerAvatar();
			if (!homeOwnerAvatar.IsNpcAvatar())
			{
				int matchType = this.m_parent.GetLevel().GetMatchType();
				if (matchType < 10)
				{
					if (matchType == 3 || matchType == 5)
					{
						this.int_0 = 0;
						return;
					}
				}
				int num = LogicDataTables.GetGlobals().GetResourceProductionLootPercentage(this.logicResourceData_0);
				if (homeOwnerAvatar.IsClientAvatar())
				{
					LogicAvatar visitorAvatar = this.m_parent.GetLevel().GetVisitorAvatar();
					if (visitorAvatar != null && visitorAvatar.IsClientAvatar())
					{
						num = num * LogicDataTables.GetGlobals().GetLootMultiplierByTownHallDiff(visitorAvatar.GetTownHallLevel(), homeOwnerAvatar.GetTownHallLevel()) / 100;
					}
				}
				if (num > 100)
				{
					num = 100;
				}
				this.int_0 = (int)((long)this.GetResourceCount() * (long)num / 100L);
				return;
			}
			this.int_0 = 0;
		}

		// Token: 0x06001024 RID: 4132 RVA: 0x00047760 File Offset: 0x00045960
		public void ResourcesStolen(int damage, int hp)
		{
			if (damage > 0 && hp > 0)
			{
				int num = damage * this.GetStealableResourceCount() / hp;
				if (num > 0)
				{
					this.m_parent.GetLevel().GetBattleLog().IncreaseStolenResourceCount(this.logicResourceData_0, num);
					this.DecreaseResources(num);
					this.m_parent.GetLevel().GetVisitorAvatar().CommodityCountChangeHelper(0, this.logicResourceData_0, num);
					this.int_0 -= num;
				}
			}
		}

		// Token: 0x06001025 RID: 4133 RVA: 0x000477D4 File Offset: 0x000459D4
		public override void Tick()
		{
			if (this.m_parent.GetRemainingBoostTime() > 0 && !this.m_parent.IsBoostPaused())
			{
				this.logicTimer_0.FastForwardSubticks(4 * LogicDataTables.GetGlobals().GetResourceProductionBoostMultiplier() - 4);
			}
			if (this.m_parent.GetLevel().GetRemainingClockTowerBoostTime() > 0 && this.m_parent.GetData().GetDataType() == LogicDataType.BUILDING && this.m_parent.GetData().GetVillageType() == 1)
			{
				this.logicTimer_0.FastForwardSubticks(4 * LogicDataTables.GetGlobals().GetClockTowerBoostMultiplier() - 4);
			}
		}

		// Token: 0x040006A8 RID: 1704
		private readonly LogicResourceData logicResourceData_0;

		// Token: 0x040006A9 RID: 1705
		private readonly LogicTimer logicTimer_0;

		// Token: 0x040006AA RID: 1706
		private int int_0;

		// Token: 0x040006AB RID: 1707
		private int int_1;

		// Token: 0x040006AC RID: 1708
		private int int_2;
	}
}
