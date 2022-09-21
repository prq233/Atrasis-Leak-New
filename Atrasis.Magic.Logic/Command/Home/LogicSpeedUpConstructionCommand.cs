using System;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001CB RID: 459
	public sealed class LogicSpeedUpConstructionCommand : LogicCommand
	{
		// Token: 0x0600182F RID: 6191 RVA: 0x0000EB66 File Offset: 0x0000CD66
		public LogicSpeedUpConstructionCommand()
		{
		}

		// Token: 0x06001830 RID: 6192 RVA: 0x0001001D File Offset: 0x0000E21D
		public LogicSpeedUpConstructionCommand(int gameObjectId)
		{
			this.int_1 = gameObjectId;
		}

		// Token: 0x06001831 RID: 6193 RVA: 0x0001002C File Offset: 0x0000E22C
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			this.int_2 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x06001832 RID: 6194 RVA: 0x0001004D File Offset: 0x0000E24D
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			encoder.WriteInt(this.int_2);
			base.Encode(encoder);
		}

		// Token: 0x06001833 RID: 6195 RVA: 0x0001006E File Offset: 0x0000E26E
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.SPEED_UP_CONSTRUCTION;
		}

		// Token: 0x06001834 RID: 6196 RVA: 0x0000EB45 File Offset: 0x0000CD45
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06001835 RID: 6197 RVA: 0x0005B5AC File Offset: 0x000597AC
		public override int Execute(LogicLevel level)
		{
			if (this.int_2 <= 1 && level.GetGameObjectManagerAt(this.int_2) != null)
			{
				LogicGameObject gameObjectByID = level.GetGameObjectManagerAt(this.int_2).GetGameObjectByID(this.int_1);
				if (gameObjectByID != null)
				{
					LogicGameObjectType gameObjectType = gameObjectByID.GetGameObjectType();
					if (gameObjectType == LogicGameObjectType.BUILDING)
					{
						if (!((LogicBuilding)gameObjectByID).SpeedUpConstruction())
						{
							return -1;
						}
						return 0;
					}
					else if (gameObjectType == LogicGameObjectType.TRAP)
					{
						if (!((LogicTrap)gameObjectByID).SpeedUpConstruction())
						{
							return -2;
						}
						return 0;
					}
					else if (gameObjectType == LogicGameObjectType.VILLAGE_OBJECT)
					{
						if (!((LogicVillageObject)gameObjectByID).SpeedUpCostruction())
						{
							return -1;
						}
						return 0;
					}
				}
			}
			return -3;
		}

		// Token: 0x04000D1E RID: 3358
		private int int_1;

		// Token: 0x04000D1F RID: 3359
		private int int_2;
	}
}
