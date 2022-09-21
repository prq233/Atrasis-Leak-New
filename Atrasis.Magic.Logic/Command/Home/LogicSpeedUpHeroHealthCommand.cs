using System;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001CC RID: 460
	public sealed class LogicSpeedUpHeroHealthCommand : LogicCommand
	{
		// Token: 0x06001836 RID: 6198 RVA: 0x0000EB66 File Offset: 0x0000CD66
		public LogicSpeedUpHeroHealthCommand()
		{
		}

		// Token: 0x06001837 RID: 6199 RVA: 0x00010075 File Offset: 0x0000E275
		public LogicSpeedUpHeroHealthCommand(int gameObjectId, int villageType)
		{
			this.int_1 = gameObjectId;
			this.int_2 = villageType;
		}

		// Token: 0x06001838 RID: 6200 RVA: 0x0001008B File Offset: 0x0000E28B
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			this.int_2 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x06001839 RID: 6201 RVA: 0x000100AC File Offset: 0x0000E2AC
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			encoder.WriteInt(this.int_2);
			base.Encode(encoder);
		}

		// Token: 0x0600183A RID: 6202 RVA: 0x000100CD File Offset: 0x0000E2CD
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.SPEED_UP_HERO_HEALTH;
		}

		// Token: 0x0600183B RID: 6203 RVA: 0x0000EB45 File Offset: 0x0000CD45
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x0600183C RID: 6204 RVA: 0x0005B634 File Offset: 0x00059834
		public override int Execute(LogicLevel level)
		{
			LogicGameObject logicGameObject = (this.int_2 <= 1) ? level.GetGameObjectManagerAt(this.int_2).GetGameObjectByID(this.int_1) : level.GetGameObjectManager().GetGameObjectByID(this.int_1);
			if (logicGameObject != null && logicGameObject.GetGameObjectType() == LogicGameObjectType.BUILDING)
			{
				LogicHeroBaseComponent heroBaseComponent = ((LogicBuilding)logicGameObject).GetHeroBaseComponent();
				if (heroBaseComponent != null)
				{
					if (!heroBaseComponent.SpeedUpHealth())
					{
						return -2;
					}
					return 0;
				}
			}
			return -1;
		}

		// Token: 0x04000D20 RID: 3360
		private int int_1;

		// Token: 0x04000D21 RID: 3361
		private int int_2;
	}
}
