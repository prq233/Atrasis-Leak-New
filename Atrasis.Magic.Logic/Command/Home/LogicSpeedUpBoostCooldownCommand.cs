using System;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001C9 RID: 457
	public sealed class LogicSpeedUpBoostCooldownCommand : LogicCommand
	{
		// Token: 0x06001821 RID: 6177 RVA: 0x0000EB66 File Offset: 0x0000CD66
		public LogicSpeedUpBoostCooldownCommand()
		{
		}

		// Token: 0x06001822 RID: 6178 RVA: 0x0000FF9D File Offset: 0x0000E19D
		public LogicSpeedUpBoostCooldownCommand(int gameObjectId)
		{
			this.int_1 = gameObjectId;
		}

		// Token: 0x06001823 RID: 6179 RVA: 0x0000FFAC File Offset: 0x0000E1AC
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x06001824 RID: 6180 RVA: 0x0000FFC1 File Offset: 0x0000E1C1
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			base.Encode(encoder);
		}

		// Token: 0x06001825 RID: 6181 RVA: 0x0000FFD6 File Offset: 0x0000E1D6
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.SPEED_UP_BOOST_COOLDOWN;
		}

		// Token: 0x06001826 RID: 6182 RVA: 0x0000EB45 File Offset: 0x0000CD45
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06001827 RID: 6183 RVA: 0x0005B510 File Offset: 0x00059710
		public override int Execute(LogicLevel level)
		{
			LogicGameObject gameObjectByID = level.GetGameObjectManager().GetGameObjectByID(this.int_1);
			if (gameObjectByID == null || gameObjectByID.GetGameObjectType() != LogicGameObjectType.BUILDING)
			{
				return -1;
			}
			LogicBuilding logicBuilding = (LogicBuilding)gameObjectByID;
			bool flag = logicBuilding.SpeedUpBoostCooldown();
			if (logicBuilding.GetBuildingData().IsClockTower())
			{
				logicBuilding.GetListener().RefreshState();
			}
			if (!flag)
			{
				return -2;
			}
			return 0;
		}

		// Token: 0x04000D1C RID: 3356
		private int int_1;
	}
}
