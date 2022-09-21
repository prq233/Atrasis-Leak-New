using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Time;
using Atrasis.Magic.Logic.Util;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.GameObject.Component
{
	// Token: 0x02000130 RID: 304
	public sealed class LogicVillage2UnitComponent : LogicComponent
	{
		// Token: 0x0600107A RID: 4218 RVA: 0x0000B18F File Offset: 0x0000938F
		public LogicVillage2UnitComponent(LogicGameObject gameObject) : base(gameObject)
		{
		}

		// Token: 0x0600107B RID: 4219 RVA: 0x00049870 File Offset: 0x00047A70
		public void TrainUnit(LogicCombatItemData combatItemData)
		{
			if (this.logicDataSlot_0 != null)
			{
				this.logicDataSlot_0.Destruct();
				this.logicDataSlot_0 = null;
			}
			if (this.logicTimer_0 != null)
			{
				this.logicTimer_0.Destruct();
				this.logicTimer_0 = null;
			}
			this.logicDataSlot_0 = new LogicDataSlot(combatItemData, 0);
			this.logicTimer_0 = new LogicTimer();
			this.logicTimer_0.StartTimer(this.GetTrainingTime(combatItemData), this.m_parent.GetLevel().GetLogicTime(), false, -1);
		}

		// Token: 0x0600107C RID: 4220 RVA: 0x0000B242 File Offset: 0x00009442
		public void RemoveUnits()
		{
			if (this.logicDataSlot_0 != null)
			{
				this.logicDataSlot_0.Destruct();
				this.logicDataSlot_0 = null;
			}
			if (this.logicTimer_0 != null)
			{
				this.logicTimer_0.Destruct();
				this.logicTimer_0 = null;
			}
		}

		// Token: 0x0600107D RID: 4221 RVA: 0x0000B278 File Offset: 0x00009478
		public void SetUnit(LogicCombatItemData combatItemData, int count)
		{
			if (this.logicDataSlot_0 != null)
			{
				this.logicDataSlot_0.Destruct();
				this.logicDataSlot_0 = null;
			}
			this.logicDataSlot_0 = new LogicDataSlot(combatItemData, count);
		}

		// Token: 0x0600107E RID: 4222 RVA: 0x0000B2A1 File Offset: 0x000094A1
		public int GetTrainingTime(LogicCombatItemData data)
		{
			return data.GetTrainingTime(this.m_parent.GetLevel().GetHomeOwnerAvatar().GetUnitUpgradeLevel(data), this.m_parent.GetLevel(), 0);
		}

		// Token: 0x0600107F RID: 4223 RVA: 0x0000B2CB File Offset: 0x000094CB
		public int GetTotalSecs()
		{
			if (this.logicDataSlot_0 != null)
			{
				return this.GetTrainingTime((LogicCombatItemData)this.logicDataSlot_0.GetData());
			}
			return 0;
		}

		// Token: 0x06001080 RID: 4224 RVA: 0x000498F0 File Offset: 0x00047AF0
		public int GetMaxUnitsInCamp(LogicCharacterData data)
		{
			LogicAvatar homeOwnerAvatar = this.m_parent.GetLevel().GetHomeOwnerAvatar();
			if (homeOwnerAvatar != null)
			{
				return data.GetUnitsInCamp(homeOwnerAvatar.GetUnitUpgradeLevel(data));
			}
			Debugger.Error("AVATAR = NULL");
			return 0;
		}

		// Token: 0x06001081 RID: 4225 RVA: 0x0000B2ED File Offset: 0x000094ED
		public bool IsEmpty()
		{
			return this.logicDataSlot_0 == null || this.logicDataSlot_0.GetCount() <= 0;
		}

		// Token: 0x06001082 RID: 4226 RVA: 0x0004992C File Offset: 0x00047B2C
		public int GetRemainingSecs()
		{
			if (this.logicTimer_0 != null)
			{
				int remainingSeconds = this.logicTimer_0.GetRemainingSeconds(this.m_parent.GetLevel().GetLogicTime());
				int valueB = (this.logicDataSlot_0 != null) ? this.GetTrainingTime((LogicCombatItemData)this.logicDataSlot_0.GetData()) : 0;
				return LogicMath.Min(remainingSeconds, valueB);
			}
			return 0;
		}

		// Token: 0x06001083 RID: 4227 RVA: 0x00049988 File Offset: 0x00047B88
		public void ProductionCompleted()
		{
			this.logicDataSlot_0.SetCount(this.GetMaxUnitsInCamp((LogicCharacterData)this.logicDataSlot_0.GetData()));
			if (this.logicTimer_0 != null)
			{
				this.logicTimer_0.Destruct();
				this.logicTimer_0 = null;
			}
			LogicAvatar homeOwnerAvatar = this.m_parent.GetLevel().GetHomeOwnerAvatar();
			LogicCombatItemData data = (LogicCombatItemData)this.logicDataSlot_0.GetData();
			int count = this.m_parent.GetLevel().GetMissionManager().IsVillage2TutorialOpen() ? (this.logicDataSlot_0.GetCount() - homeOwnerAvatar.GetUnitCountVillage2(data)) : this.logicDataSlot_0.GetCount();
			homeOwnerAvatar.CommodityCountChangeHelper(7, this.logicDataSlot_0.GetData(), count);
			this.m_parent.GetLevel().GetGameListener();
			if (this.m_parent.GetLevel().GetState() == 1)
			{
				this.m_parent.GetListener();
			}
		}

		// Token: 0x06001084 RID: 4228 RVA: 0x00049A70 File Offset: 0x00047C70
		public void RefreshArmyCampSize(bool unk)
		{
			if (this.logicDataSlot_0 != null && this.logicTimer_0 == null)
			{
				int maxUnitsInCamp = this.GetMaxUnitsInCamp((LogicCharacterData)this.logicDataSlot_0.GetData());
				int count = this.logicDataSlot_0.GetCount();
				if (maxUnitsInCamp > count)
				{
					this.m_parent.GetLevel().GetHomeOwnerAvatar().CommodityCountChangeHelper(7, this.logicDataSlot_0.GetData(), maxUnitsInCamp - count);
					this.logicDataSlot_0.SetCount(maxUnitsInCamp);
					if (this.m_parent.GetLevel().GetState() == 1 && this.m_parent.GetListener() != null)
					{
						for (int i = count; i < maxUnitsInCamp; i++)
						{
							if (i > 25)
							{
								return;
							}
						}
					}
				}
			}
		}

		// Token: 0x06001085 RID: 4229 RVA: 0x0000B30A File Offset: 0x0000950A
		public int GetRemainingMS()
		{
			if (this.logicTimer_0 != null)
			{
				return this.logicTimer_0.GetRemainingMS(this.m_parent.GetLevel().GetLogicTime());
			}
			return 0;
		}

		// Token: 0x06001086 RID: 4230 RVA: 0x0000B331 File Offset: 0x00009531
		public LogicCharacterData GetUnitData()
		{
			if (this.logicDataSlot_0 != null)
			{
				return (LogicCharacterData)this.logicDataSlot_0.GetData();
			}
			return null;
		}

		// Token: 0x06001087 RID: 4231 RVA: 0x0000B34D File Offset: 0x0000954D
		public LogicCharacterData GetCurrentlyTrainedUnit()
		{
			if (this.logicDataSlot_0 != null && this.logicDataSlot_0.GetCount() == 0)
			{
				return (LogicCharacterData)this.logicDataSlot_0.GetData();
			}
			return null;
		}

		// Token: 0x06001088 RID: 4232 RVA: 0x0000B376 File Offset: 0x00009576
		public int GetUnitCount()
		{
			if (this.logicDataSlot_0 != null)
			{
				return this.logicDataSlot_0.GetCount();
			}
			return 0;
		}

		// Token: 0x06001089 RID: 4233 RVA: 0x0000B38D File Offset: 0x0000958D
		public override LogicComponentType GetComponentType()
		{
			return LogicComponentType.VILLAGE2_UNIT;
		}

		// Token: 0x0600108A RID: 4234 RVA: 0x00049B20 File Offset: 0x00047D20
		public override void FastForwardTime(int secs)
		{
			LogicArrayList<LogicComponent> components = this.m_parent.GetComponentManager().GetComponents(LogicComponentType.VILLAGE2_UNIT);
			int barrackCount = this.m_parent.GetGameObjectManager().GetBarrackCount();
			int num = 0;
			for (int i = 0; i < barrackCount; i++)
			{
				LogicBuilding logicBuilding = (LogicBuilding)this.m_parent.GetGameObjectManager().GetBarrack(i);
				if (logicBuilding != null && !logicBuilding.IsConstructing())
				{
					num++;
				}
			}
			if (components.Size() <= 0 || (num != 0 && components[0] == this))
			{
				LogicLevel level = this.m_parent.GetLevel();
				int updatedClockTowerBoostTime = level.GetUpdatedClockTowerBoostTime();
				int num2 = 0;
				if (updatedClockTowerBoostTime > 0 && !level.IsClockTowerBoostPaused())
				{
					LogicGameObjectData data = this.m_parent.GetData();
					if (data.GetDataType() == LogicDataType.BUILDING && data.GetVillageType() == 1)
					{
						num2 = LogicMath.Min(secs, updatedClockTowerBoostTime) * (LogicDataTables.GetGlobals().GetClockTowerBoostMultiplier() - 1);
					}
				}
				int num3 = secs + num2;
				for (int j = 0; j < components.Size(); j++)
				{
					num3 = LogicMath.Max(0, num3 - ((LogicVillage2UnitComponent)components[j]).FastForwardProduction(num3));
				}
			}
		}

		// Token: 0x0600108B RID: 4235 RVA: 0x00049C3C File Offset: 0x00047E3C
		public int FastForwardProduction(int secs)
		{
			if (secs <= 0 || this.logicDataSlot_0 == null || this.logicDataSlot_0.GetCount() != 0)
			{
				return 0;
			}
			if (this.logicTimer_0 == null)
			{
				this.logicTimer_0 = new LogicTimer();
				this.logicTimer_0.StartTimer(this.GetTrainingTime((LogicCharacterData)this.logicDataSlot_0.GetData()), this.m_parent.GetLevel().GetLogicTime(), false, -1);
			}
			int remainingSeconds = this.logicTimer_0.GetRemainingSeconds(this.m_parent.GetLevel().GetLogicTime());
			if (remainingSeconds - secs <= 0)
			{
				this.ProductionCompleted();
				return remainingSeconds;
			}
			this.logicTimer_0.StartTimer(remainingSeconds - secs, this.m_parent.GetLevel().GetLogicTime(), false, -1);
			return secs;
		}

		// Token: 0x0600108C RID: 4236 RVA: 0x00049D00 File Offset: 0x00047F00
		public override void Tick()
		{
			LogicArrayList<LogicComponent> components = this.m_parent.GetComponentManager().GetComponents(LogicComponentType.VILLAGE2_UNIT);
			int barrackCount = this.m_parent.GetGameObjectManager().GetBarrackCount();
			int num = 0;
			for (int i = 0; i < barrackCount; i++)
			{
				LogicBuilding logicBuilding = (LogicBuilding)this.m_parent.GetGameObjectManager().GetBarrack(i);
				if (logicBuilding != null && !logicBuilding.IsConstructing())
				{
					num++;
				}
			}
			this.bool_0 = (num == 0);
			for (int j = 0; j < components.Size(); j++)
			{
				LogicVillage2UnitComponent logicVillage2UnitComponent = (LogicVillage2UnitComponent)components[j];
				if (num != 0 && this == logicVillage2UnitComponent)
				{
					break;
				}
				if (logicVillage2UnitComponent != null && logicVillage2UnitComponent.logicDataSlot_0 != null && logicVillage2UnitComponent.logicDataSlot_0.GetData() != null && logicVillage2UnitComponent.logicDataSlot_0.GetCount() == 0 && logicVillage2UnitComponent.GetRemainingSecs() > 0)
				{
					if (this.logicTimer_0 != null)
					{
						this.logicTimer_0.StartTimer(this.logicTimer_0.GetRemainingSeconds(this.m_parent.GetLevel().GetLogicTime()), this.m_parent.GetLevel().GetLogicTime(), false, -1);
					}
					return;
				}
			}
			if (this.logicTimer_0 != null && this.m_parent.GetLevel().GetRemainingClockTowerBoostTime() > 0 && this.m_parent.GetData().GetDataType() == LogicDataType.BUILDING && this.m_parent.GetData().GetVillageType() == 1)
			{
				this.logicTimer_0.FastForwardSubticks(4 * LogicDataTables.GetGlobals().GetClockTowerBoostMultiplier() - 4);
			}
			if (this.logicTimer_0 != null && this.logicTimer_0.GetRemainingSeconds(this.m_parent.GetLevel().GetLogicTime()) == 0 && this.logicDataSlot_0 != null)
			{
				this.ProductionCompleted();
			}
		}

		// Token: 0x0600108D RID: 4237 RVA: 0x00049EA4 File Offset: 0x000480A4
		public override void Load(LogicJSONObject jsonObject)
		{
			LogicJSONObject jsonobject = jsonObject.GetJSONObject("up2");
			if (jsonobject != null)
			{
				LogicJSONNumber jsonnumber = jsonobject.GetJSONNumber("t");
				if (jsonnumber != null)
				{
					int intValue = jsonnumber.GetIntValue();
					if (this.logicTimer_0 != null)
					{
						this.logicTimer_0.Destruct();
						this.logicTimer_0 = null;
					}
					this.logicTimer_0 = new LogicTimer();
					this.logicTimer_0.StartTimer(intValue, this.m_parent.GetLevel().GetLogicTime(), false, -1);
				}
				LogicJSONArray jsonarray = jsonobject.GetJSONArray("unit");
				if (jsonarray != null)
				{
					LogicJSONNumber jsonnumber2 = jsonarray.GetJSONNumber(0);
					LogicJSONNumber jsonnumber3 = jsonarray.GetJSONNumber(1);
					if (jsonnumber2 != null && jsonnumber3 != null)
					{
						LogicData dataById = LogicDataTables.GetDataById(jsonnumber2.GetIntValue(), (this.int_0 != 0) ? LogicDataType.SPELL : LogicDataType.CHARACTER);
						if (dataById == null)
						{
							Debugger.Error("LogicVillage2UnitComponent::load - Character data is NULL!");
						}
						this.logicDataSlot_0 = new LogicDataSlot(dataById, jsonnumber3.GetIntValue());
					}
				}
			}
		}

		// Token: 0x0600108E RID: 4238 RVA: 0x00049F84 File Offset: 0x00048184
		public override void Save(LogicJSONObject jsonObject, int villageType)
		{
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			if (this.logicDataSlot_0 != null)
			{
				LogicJSONArray logicJSONArray = new LogicJSONArray();
				logicJSONArray.Add(new LogicJSONNumber(this.logicDataSlot_0.GetData().GetGlobalID()));
				logicJSONArray.Add(new LogicJSONNumber(this.logicDataSlot_0.GetCount()));
				logicJSONObject.Put("unit", logicJSONArray);
			}
			if (this.logicTimer_0 != null)
			{
				logicJSONObject.Put("t", new LogicJSONNumber(this.logicTimer_0.GetRemainingSeconds(this.m_parent.GetLevel().GetLogicTime())));
			}
			jsonObject.Put("up2", logicJSONObject);
		}

		// Token: 0x0600108F RID: 4239 RVA: 0x0000B391 File Offset: 0x00009591
		public override void LoadingFinished()
		{
			this.RefreshArmyCampSize(false);
		}

		// Token: 0x040006CE RID: 1742
		private LogicDataSlot logicDataSlot_0;

		// Token: 0x040006CF RID: 1743
		private LogicTimer logicTimer_0;

		// Token: 0x040006D0 RID: 1744
		private bool bool_0;

		// Token: 0x040006D1 RID: 1745
		private int int_0;
	}
}
