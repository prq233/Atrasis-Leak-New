using System;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001CD RID: 461
	public sealed class LogicSpeedUpHeroUpgradeCommand : LogicCommand
	{
		// Token: 0x0600183D RID: 6205 RVA: 0x0000EB66 File Offset: 0x0000CD66
		public LogicSpeedUpHeroUpgradeCommand()
		{
		}

		// Token: 0x0600183E RID: 6206 RVA: 0x000100D4 File Offset: 0x0000E2D4
		public LogicSpeedUpHeroUpgradeCommand(int gameObjectId, int villageType)
		{
			this.int_1 = gameObjectId;
			this.int_2 = villageType;
		}

		// Token: 0x0600183F RID: 6207 RVA: 0x000100EA File Offset: 0x0000E2EA
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			this.int_2 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x06001840 RID: 6208 RVA: 0x0001010B File Offset: 0x0000E30B
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			encoder.WriteInt(this.int_2);
			base.Encode(encoder);
		}

		// Token: 0x06001841 RID: 6209 RVA: 0x0001012C File Offset: 0x0000E32C
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.SPEED_UP_HERO_UPGRADE;
		}

		// Token: 0x06001842 RID: 6210 RVA: 0x0000EB45 File Offset: 0x0000CD45
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06001843 RID: 6211 RVA: 0x0005B6A0 File Offset: 0x000598A0
		public override int Execute(LogicLevel level)
		{
			LogicGameObject logicGameObject = (this.int_2 > 1 || level.GetGameObjectManagerAt(this.int_2) == null) ? level.GetGameObjectManager().GetGameObjectByID(this.int_1) : level.GetGameObjectManagerAt(this.int_2).GetGameObjectByID(this.int_1);
			if (logicGameObject != null && logicGameObject.GetGameObjectType() == LogicGameObjectType.BUILDING)
			{
				LogicHeroBaseComponent heroBaseComponent = ((LogicBuilding)logicGameObject).GetHeroBaseComponent();
				if (heroBaseComponent != null)
				{
					if (!heroBaseComponent.SpeedUp())
					{
						return -2;
					}
					return 0;
				}
			}
			return -1;
		}

		// Token: 0x04000D22 RID: 3362
		private int int_1;

		// Token: 0x04000D23 RID: 3363
		private int int_2;
	}
}
