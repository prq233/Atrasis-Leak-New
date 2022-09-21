using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Time;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.GameObject.Component
{
	// Token: 0x02000122 RID: 290
	public sealed class LogicDefenceUnitProductionComponent : LogicComponent
	{
		// Token: 0x06000F65 RID: 3941 RVA: 0x0000A7EC File Offset: 0x000089EC
		public LogicDefenceUnitProductionComponent(LogicGameObject gameObject) : base(gameObject)
		{
			this.logicArrayList_0 = new LogicArrayList<LogicCharacter>();
			this.logicCharacterData_0 = new LogicCharacterData[2];
		}

		// Token: 0x06000F66 RID: 3942 RVA: 0x000413F0 File Offset: 0x0003F5F0
		public override void Destruct()
		{
			base.Destruct();
			if (this.logicArrayList_0 != null)
			{
				this.logicArrayList_0.Destruct();
				this.logicArrayList_0 = null;
			}
			if (this.logicTimer_0 != null)
			{
				this.logicTimer_0.Destruct();
				this.logicTimer_0 = null;
			}
			this.logicCharacterData_0 = null;
		}

		// Token: 0x06000F67 RID: 3943 RVA: 0x00041440 File Offset: 0x0003F640
		public override void RemoveGameObjectReferences(LogicGameObject gameObject)
		{
			int i = 0;
			int num = this.logicArrayList_0.Size();
			while (i < num)
			{
				if (this.logicArrayList_0[i] == gameObject)
				{
					this.logicArrayList_0.Remove(i);
					this.StartSpawnCooldownTimer();
					return;
				}
				i++;
			}
		}

		// Token: 0x06000F68 RID: 3944 RVA: 0x0000746A File Offset: 0x0000566A
		public override LogicComponentType GetComponentType()
		{
			return LogicComponentType.DEFENCE_UNIT_PRODUCTION;
		}

		// Token: 0x06000F69 RID: 3945 RVA: 0x0004148C File Offset: 0x0003F68C
		public override void Tick()
		{
			if (this.m_parent.IsAlive())
			{
				if (LogicDataTables.GetGlobals().GuardPostNotFunctionalUnderUpgrade() && this.m_parent.GetGameObjectType() == LogicGameObjectType.BUILDING && ((LogicBuilding)this.m_parent).IsConstructing())
				{
					return;
				}
				if (this.int_3 > this.int_2 && (this.logicTimer_0 == null || this.logicTimer_0.GetRemainingSeconds(this.m_parent.GetLevel().GetLogicTime()) <= 0))
				{
					this.method_0(this.m_parent.GetX(), this.m_parent.GetY() + (this.m_parent.GetHeightInTiles() << 8));
					if (this.int_3 > this.logicArrayList_0.Size())
					{
						this.StartSpawnCooldownTimer();
					}
				}
			}
		}

		// Token: 0x06000F6A RID: 3946 RVA: 0x0004154C File Offset: 0x0003F74C
		public void StartSpawnCooldownTimer()
		{
			if (this.logicTimer_0 == null)
			{
				this.logicTimer_0 = new LogicTimer();
			}
			if (this.logicTimer_0.GetRemainingSeconds(this.m_parent.GetLevel().GetLogicTime()) <= 0)
			{
				this.logicTimer_0.StartTimer(this.int_1, this.m_parent.GetLevel().GetLogicTime(), false, -1);
			}
		}

		// Token: 0x06000F6B RID: 3947 RVA: 0x000415B0 File Offset: 0x0003F7B0
		private void method_0(int int_4, int int_5)
		{
			int num = this.int_2 % 2;
			if (this.logicCharacterData_0[num] == null)
			{
				num = 0;
			}
			LogicBuilding logicBuilding = (LogicBuilding)this.m_parent;
			if (logicBuilding.GetBuildingData().IsEnabledInVillageType(this.m_parent.GetLevel().GetVillageType()) && this.m_parent.GetLevel().GetState() != 1 && this.m_parent.GetLevel().GetState() != 4)
			{
				LogicCharacter logicCharacter = (LogicCharacter)LogicGameObjectFactory.CreateGameObject(this.logicCharacterData_0[num], this.m_parent.GetLevel(), this.m_parent.GetVillageType());
				logicCharacter.SetInitialPosition(int_4, int_5);
				logicCharacter.SetUpgradeLevel(this.int_0 - 1);
				LogicHitpointComponent hitpointComponent = logicCharacter.GetHitpointComponent();
				if (hitpointComponent != null)
				{
					hitpointComponent.SetTeam(1);
				}
				if (LogicDataTables.GetGlobals().EnableDefendingAllianceTroopJump())
				{
					logicCharacter.GetMovementComponent().EnableJump(3600000);
				}
				this.m_parent.GetGameObjectManager().AddGameObject(logicCharacter, -1);
				logicCharacter.GetCombatComponent().SetSearchRadius(LogicDataTables.GetGlobals().GetClanCastleRadius() >> 9);
				logicCharacter.GetMovementComponent().GetMovementSystem().CreatePatrolArea(this.m_parent, this.m_parent.GetLevel(), true, this.int_2);
				LogicDefenceUnitProductionComponent defenceUnitProduction = logicBuilding.GetDefenceUnitProduction();
				if (defenceUnitProduction != null)
				{
					defenceUnitProduction.logicArrayList_0.Add(logicCharacter);
				}
				this.int_2++;
			}
		}

		// Token: 0x06000F6C RID: 3948 RVA: 0x0000A80C File Offset: 0x00008A0C
		public void SetDefenceTroops(LogicCharacterData defenceTroopCharacter1, LogicCharacterData defenceTroopCharacter2, int defenceTroopCount, int defenceTroopLevel, int defenseTroopCooldownSecs)
		{
			this.logicCharacterData_0[0] = defenceTroopCharacter1;
			this.logicCharacterData_0[1] = defenceTroopCharacter2;
			this.int_3 = defenceTroopCount;
			this.int_0 = defenceTroopLevel;
			this.int_1 = defenseTroopCooldownSecs;
		}

		// Token: 0x04000650 RID: 1616
		private LogicTimer logicTimer_0;

		// Token: 0x04000651 RID: 1617
		private LogicArrayList<LogicCharacter> logicArrayList_0;

		// Token: 0x04000652 RID: 1618
		private LogicCharacterData[] logicCharacterData_0;

		// Token: 0x04000653 RID: 1619
		private int int_0;

		// Token: 0x04000654 RID: 1620
		private int int_1;

		// Token: 0x04000655 RID: 1621
		private int int_2;

		// Token: 0x04000656 RID: 1622
		private int int_3;
	}
}
