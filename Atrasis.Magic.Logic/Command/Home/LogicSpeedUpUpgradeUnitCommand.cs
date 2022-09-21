using System;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001D1 RID: 465
	public sealed class LogicSpeedUpUpgradeUnitCommand : LogicCommand
	{
		// Token: 0x06001858 RID: 6232 RVA: 0x0000EB66 File Offset: 0x0000CD66
		public LogicSpeedUpUpgradeUnitCommand()
		{
		}

		// Token: 0x06001859 RID: 6233 RVA: 0x000101BF File Offset: 0x0000E3BF
		public LogicSpeedUpUpgradeUnitCommand(int gameObjectId)
		{
			this.int_1 = gameObjectId;
		}

		// Token: 0x0600185A RID: 6234 RVA: 0x000101CE File Offset: 0x0000E3CE
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x0600185B RID: 6235 RVA: 0x000101E3 File Offset: 0x0000E3E3
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			base.Encode(encoder);
		}

		// Token: 0x0600185C RID: 6236 RVA: 0x000101F8 File Offset: 0x0000E3F8
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.SPEED_UP_UPGRADE_UNIT;
		}

		// Token: 0x0600185D RID: 6237 RVA: 0x000101FF File Offset: 0x0000E3FF
		public override void Destruct()
		{
			base.Destruct();
			this.int_1 = 0;
		}

		// Token: 0x0600185E RID: 6238 RVA: 0x0005B944 File Offset: 0x00059B44
		public override int Execute(LogicLevel level)
		{
			LogicGameObject gameObjectByID = level.GetGameObjectManager().GetGameObjectByID(this.int_1);
			if (gameObjectByID != null && gameObjectByID.GetGameObjectType() == LogicGameObjectType.BUILDING)
			{
				LogicUnitUpgradeComponent unitUpgradeComponent = ((LogicBuilding)gameObjectByID).GetUnitUpgradeComponent();
				if (unitUpgradeComponent.GetCurrentlyUpgradedUnit() != null)
				{
					if (!unitUpgradeComponent.SpeedUp())
					{
						return -2;
					}
					return 0;
				}
			}
			return -1;
		}

		// Token: 0x04000D26 RID: 3366
		private int int_1;
	}
}
