using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001BB RID: 443
	public sealed class LogicRotateBuildingCommand : LogicCommand
	{
		// Token: 0x060017C3 RID: 6083 RVA: 0x0000EB66 File Offset: 0x0000CD66
		public LogicRotateBuildingCommand()
		{
		}

		// Token: 0x060017C4 RID: 6084 RVA: 0x0000FB06 File Offset: 0x0000DD06
		public LogicRotateBuildingCommand(int gameObjectId, int layout, bool draftLayout, bool updateListener, int baseLayout, bool baseDraftLayout)
		{
			this.int_1 = gameObjectId;
			this.int_2 = layout;
			this.bool_0 = draftLayout;
			this.bool_2 = updateListener;
			this.int_3 = baseLayout;
			this.bool_1 = baseDraftLayout;
		}

		// Token: 0x060017C5 RID: 6085 RVA: 0x0005A884 File Offset: 0x00058A84
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			this.int_2 = stream.ReadInt();
			this.bool_0 = stream.ReadBoolean();
			this.bool_2 = stream.ReadBoolean();
			this.int_3 = stream.ReadInt();
			this.bool_1 = stream.ReadBoolean();
			base.Decode(stream);
		}

		// Token: 0x060017C6 RID: 6086 RVA: 0x0005A8E0 File Offset: 0x00058AE0
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			encoder.WriteInt(this.int_2);
			encoder.WriteBoolean(this.bool_0);
			encoder.WriteBoolean(this.bool_2);
			encoder.WriteInt(this.int_3);
			encoder.WriteBoolean(this.bool_1);
			base.Encode(encoder);
		}

		// Token: 0x060017C7 RID: 6087 RVA: 0x0000FB3B File Offset: 0x0000DD3B
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.ROTATE_BUILDING;
		}

		// Token: 0x060017C8 RID: 6088 RVA: 0x0000EB45 File Offset: 0x0000CD45
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x060017C9 RID: 6089 RVA: 0x0005A93C File Offset: 0x00058B3C
		public override int Execute(LogicLevel level)
		{
			LogicGameObject gameObjectByID = level.GetGameObjectManager().GetGameObjectByID(this.int_1);
			if (gameObjectByID != null)
			{
				if (gameObjectByID.GetGameObjectType() == LogicGameObjectType.BUILDING)
				{
					LogicBuilding logicBuilding = (LogicBuilding)gameObjectByID;
					LogicBuildingData buildingData = logicBuilding.GetBuildingData();
					LogicCombatComponent combatComponent = logicBuilding.GetCombatComponent(false);
					if (combatComponent != null && combatComponent.GetAttackerItemData().GetTargetingConeAngle() != 0)
					{
						if (this.int_3 == -1)
						{
							combatComponent.ToggleAimAngle(buildingData.GetAimRotateStep(), this.int_2, this.bool_0);
						}
						else
						{
							int aimAngle = combatComponent.GetAimAngle(this.int_3, this.bool_1);
							int aimAngle2 = combatComponent.GetAimAngle(this.int_2, this.bool_0);
							combatComponent.ToggleAimAngle(aimAngle - aimAngle2, this.int_2, this.bool_0);
						}
						return 0;
					}
				}
				else if (gameObjectByID.GetGameObjectType() == LogicGameObjectType.TRAP)
				{
					LogicTrap logicTrap = (LogicTrap)gameObjectByID;
					if (logicTrap.GetTrapData().GetDirectionCount() > 0)
					{
						if (this.int_3 == -1)
						{
							logicTrap.ToggleDirection(this.int_2, this.bool_0);
						}
						else
						{
							logicTrap.SetDirection(this.int_2, this.bool_0, logicTrap.GetDirection(this.int_3, this.bool_1));
						}
						return 0;
					}
					return -21;
				}
			}
			return -1;
		}

		// Token: 0x04000CFF RID: 3327
		private int int_1;

		// Token: 0x04000D00 RID: 3328
		private int int_2;

		// Token: 0x04000D01 RID: 3329
		private int int_3;

		// Token: 0x04000D02 RID: 3330
		private bool bool_0;

		// Token: 0x04000D03 RID: 3331
		private bool bool_1;

		// Token: 0x04000D04 RID: 3332
		private bool bool_2;
	}
}
