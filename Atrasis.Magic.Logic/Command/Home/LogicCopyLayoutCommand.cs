using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001A0 RID: 416
	public sealed class LogicCopyLayoutCommand : LogicCommand
	{
		// Token: 0x06001719 RID: 5913 RVA: 0x0000F196 File Offset: 0x0000D396
		public LogicCopyLayoutCommand()
		{
			this.int_1 = -1;
			this.int_2 = -1;
		}

		// Token: 0x0600171A RID: 5914 RVA: 0x000584FC File Offset: 0x000566FC
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
			this.int_1 = stream.ReadInt();
			this.int_2 = stream.ReadInt();
			this.int_1 = LogicMath.Clamp(this.int_1, 0, 7);
			this.int_2 = LogicMath.Clamp(this.int_2, 0, 7);
		}

		// Token: 0x0600171B RID: 5915 RVA: 0x0000F1AC File Offset: 0x0000D3AC
		public override void Encode(ChecksumEncoder encoder)
		{
			base.Encode(encoder);
			encoder.WriteInt(this.int_1);
			encoder.WriteInt(this.int_2);
		}

		// Token: 0x0600171C RID: 5916 RVA: 0x0000F1CD File Offset: 0x0000D3CD
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.COPY_LAYOUT;
		}

		// Token: 0x0600171D RID: 5917 RVA: 0x0000EB45 File Offset: 0x0000CD45
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x0600171E RID: 5918 RVA: 0x00058550 File Offset: 0x00056750
		public override int Execute(LogicLevel level)
		{
			if (this.int_1 == 6)
			{
				return -5;
			}
			if (this.int_2 == 6)
			{
				return -6;
			}
			if (this.int_1 == 7)
			{
				return -7;
			}
			if (this.int_2 == 7)
			{
				return -8;
			}
			int townHallLevel = level.GetTownHallLevel(level.GetVillageType());
			if (townHallLevel >= level.GetRequiredTownHallLevelForLayout(this.int_1, -1) && townHallLevel >= level.GetRequiredTownHallLevelForLayout(this.int_2, -1))
			{
				LogicGameObjectFilter logicGameObjectFilter = new LogicGameObjectFilter();
				LogicArrayList<LogicGameObject> logicArrayList = new LogicArrayList<LogicGameObject>(500);
				logicGameObjectFilter.AddGameObjectType(LogicGameObjectType.BUILDING);
				logicGameObjectFilter.AddGameObjectType(LogicGameObjectType.TRAP);
				logicGameObjectFilter.AddGameObjectType(LogicGameObjectType.DECO);
				level.GetGameObjectManager().GetGameObjects(logicArrayList, logicGameObjectFilter);
				if (this.int_2 == level.GetActiveLayout())
				{
					LogicMoveMultipleBuildingsCommand logicMoveMultipleBuildingsCommand = new LogicMoveMultipleBuildingsCommand();
					for (int i = 0; i < logicArrayList.Size(); i++)
					{
						LogicGameObject logicGameObject = logicArrayList[i];
						LogicVector2 positionLayout = logicGameObject.GetPositionLayout(this.int_1, false);
						logicMoveMultipleBuildingsCommand.AddNewMove(logicGameObject.GetGlobalID(), positionLayout.m_x, positionLayout.m_y);
					}
					int num = logicMoveMultipleBuildingsCommand.Execute(level);
					logicMoveMultipleBuildingsCommand.Destruct();
					if (num != 0)
					{
						logicGameObjectFilter.Destruct();
						return -2;
					}
				}
				for (int j = 0; j < logicArrayList.Size(); j++)
				{
					LogicGameObject logicGameObject2 = logicArrayList[j];
					LogicVector2 positionLayout2 = logicGameObject2.GetPositionLayout(this.int_1, false);
					LogicVector2 positionLayout3 = logicGameObject2.GetPositionLayout(this.int_1, true);
					logicGameObject2.SetPositionLayoutXY(positionLayout2.m_x, positionLayout2.m_y, this.int_2, false);
					logicGameObject2.SetPositionLayoutXY(positionLayout3.m_x, positionLayout3.m_y, this.int_2, true);
					if (logicGameObject2.GetGameObjectType() == LogicGameObjectType.BUILDING)
					{
						LogicCombatComponent combatComponent = logicGameObject2.GetCombatComponent(false);
						if (combatComponent != null)
						{
							if (combatComponent.HasAltAttackMode())
							{
								if (combatComponent.UseAltAttackMode(this.int_1, false) ^ combatComponent.UseAltAttackMode(this.int_2, false))
								{
									combatComponent.ToggleAttackMode(this.int_2, false);
								}
								if (combatComponent.UseAltAttackMode(this.int_1, true) ^ combatComponent.UseAltAttackMode(this.int_2, true))
								{
									combatComponent.ToggleAttackMode(this.int_2, true);
								}
							}
							if (combatComponent.GetAttackerItemData().GetTargetingConeAngle() != 0)
							{
								int aimAngle = combatComponent.GetAimAngle(this.int_1, false);
								int aimAngle2 = combatComponent.GetAimAngle(this.int_2, false);
								if (aimAngle != aimAngle2)
								{
									combatComponent.ToggleAimAngle(aimAngle - aimAngle2, this.int_2, false);
								}
							}
						}
					}
					else if (logicGameObject2.GetGameObjectType() == LogicGameObjectType.TRAP)
					{
						LogicTrap logicTrap = (LogicTrap)logicGameObject2;
						if (logicTrap.HasAirMode())
						{
							if (logicTrap.IsAirMode(this.int_1, false) ^ logicTrap.IsAirMode(this.int_2, false))
							{
								logicTrap.ToggleAirMode(this.int_2, false);
							}
							if (logicTrap.IsAirMode(this.int_1, true) ^ logicTrap.IsAirMode(this.int_2, true))
							{
								logicTrap.ToggleAirMode(this.int_2, true);
							}
						}
					}
				}
				logicGameObjectFilter.Destruct();
				level.SetLayoutState(this.int_2, level.GetVillageType(), level.GetLayoutState(this.int_1, level.GetVillageType()));
				if (level.GetHomeOwnerAvatar().GetTownHallLevel() >= LogicDataTables.GetGlobals().GetChallengeBaseCooldownEnabledTownHall())
				{
					level.SetLayoutCooldownSecs(this.int_2, level.GetLayoutCooldown(this.int_1) / 15);
				}
				return 0;
			}
			return -1;
		}

		// Token: 0x04000CCB RID: 3275
		private int int_1;

		// Token: 0x04000CCC RID: 3276
		private int int_2;
	}
}
