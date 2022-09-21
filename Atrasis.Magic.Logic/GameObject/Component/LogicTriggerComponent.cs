using System;
using Atrasis.Magic.Logic.Command.Battle;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.GameObject.Component
{
	// Token: 0x0200012C RID: 300
	public sealed class LogicTriggerComponent : LogicComponent
	{
		// Token: 0x0600103C RID: 4156 RVA: 0x00048540 File Offset: 0x00046740
		public LogicTriggerComponent(LogicGameObject gameObject, int triggerRadius, bool airTrigger, bool groundTrigger, bool healerTrigger, int minTriggerHousingLimit) : base(gameObject)
		{
			this.int_0 = triggerRadius;
			this.bool_0 = airTrigger;
			this.bool_1 = groundTrigger;
			this.bool_2 = healerTrigger;
			this.int_1 = minTriggerHousingLimit;
			int num = (LogicMath.Min(this.m_parent.GetWidthInTiles(), this.m_parent.GetHeightInTiles()) << 9) + 1024 >> 1;
			this.bool_3 = (num < triggerRadius);
		}

		// Token: 0x0600103D RID: 4157 RVA: 0x0000AFD5 File Offset: 0x000091D5
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x0600103E RID: 4158 RVA: 0x0000A1EC File Offset: 0x000083EC
		public override LogicComponentType GetComponentType()
		{
			return LogicComponentType.TRIGGER;
		}

		// Token: 0x0600103F RID: 4159 RVA: 0x000485AC File Offset: 0x000467AC
		public override void Tick()
		{
			if (this.bool_3)
			{
				LogicLevel level = this.m_parent.GetLevel();
				if (level.IsInCombatState() && !this.bool_4 && (level.GetLogicTime().GetTick() / 4 & 7) == 0)
				{
					LogicArrayList<LogicComponent> components = this.m_parent.GetComponentManager().GetComponents(LogicComponentType.MOVEMENT);
					for (int i = 0; i < components.Size(); i++)
					{
						LogicGameObject parent = components[i].GetParent();
						if (parent.GetGameObjectType() == LogicGameObjectType.CHARACTER)
						{
							LogicCharacter logicCharacter = (LogicCharacter)parent;
							LogicMovementComponent movementComponent = logicCharacter.GetMovementComponent();
							bool flag = false;
							if (movementComponent != null)
							{
								LogicMovementSystem movementSystem = movementComponent.GetMovementSystem();
								if (movementSystem != null && movementSystem.IsPushed())
								{
									flag = movementSystem.IgnorePush();
								}
							}
							if (!flag && logicCharacter.GetCharacterData().GetTriggersTraps())
							{
								this.ObjectClose(logicCharacter);
							}
						}
					}
				}
			}
		}

		// Token: 0x06001040 RID: 4160 RVA: 0x00048684 File Offset: 0x00046884
		public void ObjectClose(LogicGameObject gameObject)
		{
			LogicHitpointComponent hitpointComponent = gameObject.GetHitpointComponent();
			if (hitpointComponent == null || hitpointComponent.GetTeam() != 1)
			{
				if (gameObject.GetGameObjectType() == LogicGameObjectType.CHARACTER && ((LogicCharacter)gameObject).GetCharacterData().GetHousingSpace() < this.int_1)
				{
					return;
				}
				LogicCombatComponent combatComponent = gameObject.GetCombatComponent();
				if ((combatComponent == null || combatComponent.GetUndergroundTime() <= 0) && (!gameObject.IsFlying() || this.bool_0) && (gameObject.IsFlying() || this.bool_1) && (this.bool_2 || combatComponent == null || !combatComponent.IsHealer()))
				{
					int num = gameObject.GetX() - this.m_parent.GetMidX();
					int num2 = gameObject.GetY() - this.m_parent.GetMidY();
					if (LogicMath.Abs(num) <= this.int_0 && LogicMath.Abs(num2) <= this.int_0 && (long)(num * num + num2 * num2) < (long)((ulong)(this.int_0 * this.int_0)))
					{
						this.method_0();
					}
				}
			}
		}

		// Token: 0x06001041 RID: 4161 RVA: 0x00048778 File Offset: 0x00046978
		private void method_0()
		{
			if (!this.bool_4)
			{
				if (LogicDataTables.GetGlobals().UseTrapTriggerCommand())
				{
					if (!this.bool_5)
					{
						if (this.m_parent.GetLevel().GetState() != 5)
						{
							LogicTriggerComponentTriggeredCommand logicTriggerComponentTriggeredCommand = new LogicTriggerComponentTriggeredCommand(this.m_parent);
							logicTriggerComponentTriggeredCommand.SetExecuteSubTick(this.m_parent.GetLevel().GetLogicTime().GetTick() + 1);
							this.m_parent.GetLevel().GetGameMode().GetCommandManager().AddCommand(logicTriggerComponentTriggeredCommand);
						}
						this.bool_5 = true;
						return;
					}
				}
				else
				{
					this.bool_4 = true;
				}
			}
		}

		// Token: 0x06001042 RID: 4162 RVA: 0x0000AFDD File Offset: 0x000091DD
		public void SetAirTrigger(bool value)
		{
			this.bool_0 = value;
		}

		// Token: 0x06001043 RID: 4163 RVA: 0x0000AFE6 File Offset: 0x000091E6
		public void SetGroundTrigger(bool value)
		{
			this.bool_1 = value;
		}

		// Token: 0x06001044 RID: 4164 RVA: 0x0000AFEF File Offset: 0x000091EF
		public bool IsTriggeredByRadius()
		{
			return this.bool_3;
		}

		// Token: 0x06001045 RID: 4165 RVA: 0x0000AFF7 File Offset: 0x000091F7
		public bool IsTriggered()
		{
			return this.bool_4;
		}

		// Token: 0x06001046 RID: 4166 RVA: 0x0000AFFF File Offset: 0x000091FF
		public void SetTriggered()
		{
			this.bool_4 = true;
		}

		// Token: 0x040006BC RID: 1724
		private bool bool_0;

		// Token: 0x040006BD RID: 1725
		private bool bool_1;

		// Token: 0x040006BE RID: 1726
		private readonly bool bool_2;

		// Token: 0x040006BF RID: 1727
		private readonly int int_0;

		// Token: 0x040006C0 RID: 1728
		private readonly int int_1;

		// Token: 0x040006C1 RID: 1729
		private readonly bool bool_3;

		// Token: 0x040006C2 RID: 1730
		private bool bool_4;

		// Token: 0x040006C3 RID: 1731
		private bool bool_5;
	}
}
