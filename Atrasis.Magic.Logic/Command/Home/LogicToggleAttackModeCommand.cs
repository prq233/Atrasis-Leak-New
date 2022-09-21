using System;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001D7 RID: 471
	public sealed class LogicToggleAttackModeCommand : LogicCommand
	{
		// Token: 0x0600187E RID: 6270 RVA: 0x0000EB66 File Offset: 0x0000CD66
		public LogicToggleAttackModeCommand()
		{
		}

		// Token: 0x0600187F RID: 6271 RVA: 0x00010393 File Offset: 0x0000E593
		public LogicToggleAttackModeCommand(int gameObjectId, int layout, bool draftMode, bool updateListener)
		{
			this.int_1 = gameObjectId;
			this.int_2 = layout;
			this.bool_0 = draftMode;
			this.bool_1 = updateListener;
		}

		// Token: 0x06001880 RID: 6272 RVA: 0x000103B8 File Offset: 0x0000E5B8
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			this.int_2 = stream.ReadInt();
			this.bool_0 = stream.ReadBoolean();
			this.bool_1 = stream.ReadBoolean();
			base.Decode(stream);
		}

		// Token: 0x06001881 RID: 6273 RVA: 0x000103F1 File Offset: 0x0000E5F1
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			encoder.WriteInt(this.int_2);
			encoder.WriteBoolean(this.bool_0);
			encoder.WriteBoolean(this.bool_1);
			base.Encode(encoder);
		}

		// Token: 0x06001882 RID: 6274 RVA: 0x0001042A File Offset: 0x0000E62A
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.TOGGLE_ATTACK_MODE;
		}

		// Token: 0x06001883 RID: 6275 RVA: 0x0000EB45 File Offset: 0x0000CD45
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06001884 RID: 6276 RVA: 0x0005C2C0 File Offset: 0x0005A4C0
		public override int Execute(LogicLevel level)
		{
			LogicGameObject gameObjectByID = level.GetGameObjectManager().GetGameObjectByID(this.int_1);
			if (gameObjectByID != null)
			{
				if (gameObjectByID.GetGameObjectType() == LogicGameObjectType.BUILDING)
				{
					LogicBuilding logicBuilding = (LogicBuilding)gameObjectByID;
					if (logicBuilding.GetBuildingData().GetGearUpBuildingData() != null && logicBuilding.GetGearLevel() == 0)
					{
						return -95;
					}
					if (logicBuilding.GetAttackerItemData().HasAlternativeAttackMode())
					{
						LogicCombatComponent combatComponent = logicBuilding.GetCombatComponent(false);
						if (combatComponent != null)
						{
							combatComponent.ToggleAttackMode(this.int_2, this.bool_0);
							return 0;
						}
					}
					return -1;
				}
				else if (gameObjectByID.GetGameObjectType() == LogicGameObjectType.TRAP)
				{
					LogicTrap logicTrap = (LogicTrap)gameObjectByID;
					if (logicTrap.HasAirMode())
					{
						logicTrap.ToggleAirMode(this.int_2, this.bool_0);
						return 0;
					}
				}
			}
			return -1;
		}

		// Token: 0x04000D2F RID: 3375
		private int int_1;

		// Token: 0x04000D30 RID: 3376
		private int int_2;

		// Token: 0x04000D31 RID: 3377
		private bool bool_0;

		// Token: 0x04000D32 RID: 3378
		private bool bool_1;
	}
}
