using System;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001CA RID: 458
	public sealed class LogicSpeedUpClearingCommand : LogicCommand
	{
		// Token: 0x06001828 RID: 6184 RVA: 0x0000EB66 File Offset: 0x0000CD66
		public LogicSpeedUpClearingCommand()
		{
		}

		// Token: 0x06001829 RID: 6185 RVA: 0x0000FFDD File Offset: 0x0000E1DD
		public LogicSpeedUpClearingCommand(int gameObjectId)
		{
			this.int_1 = gameObjectId;
		}

		// Token: 0x0600182A RID: 6186 RVA: 0x0000FFEC File Offset: 0x0000E1EC
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x0600182B RID: 6187 RVA: 0x00010001 File Offset: 0x0000E201
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			base.Encode(encoder);
		}

		// Token: 0x0600182C RID: 6188 RVA: 0x00010016 File Offset: 0x0000E216
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.SPEED_UP_CLEARING;
		}

		// Token: 0x0600182D RID: 6189 RVA: 0x0000EB45 File Offset: 0x0000CD45
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x0600182E RID: 6190 RVA: 0x0005B56C File Offset: 0x0005976C
		public override int Execute(LogicLevel level)
		{
			LogicGameObject gameObjectByID = level.GetGameObjectManager().GetGameObjectByID(this.int_1);
			if (gameObjectByID == null || gameObjectByID.GetGameObjectType() != LogicGameObjectType.OBSTACLE)
			{
				return -1;
			}
			if (!((LogicObstacle)gameObjectByID).SpeedUpClearing())
			{
				return -2;
			}
			return 0;
		}

		// Token: 0x04000D1D RID: 3357
		private int int_1;
	}
}
