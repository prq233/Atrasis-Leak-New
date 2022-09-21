using System;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001D8 RID: 472
	public sealed class LogicToggleHeroModeCommand : LogicCommand
	{
		// Token: 0x06001885 RID: 6277 RVA: 0x0000EB66 File Offset: 0x0000CD66
		public LogicToggleHeroModeCommand()
		{
		}

		// Token: 0x06001886 RID: 6278 RVA: 0x00010431 File Offset: 0x0000E631
		public LogicToggleHeroModeCommand(int gameObjectId, int mode)
		{
			this.int_1 = gameObjectId;
			this.int_2 = mode;
		}

		// Token: 0x06001887 RID: 6279 RVA: 0x00010447 File Offset: 0x0000E647
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			this.int_2 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x06001888 RID: 6280 RVA: 0x00010468 File Offset: 0x0000E668
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			encoder.WriteInt(this.int_2);
			base.Encode(encoder);
		}

		// Token: 0x06001889 RID: 6281 RVA: 0x00010489 File Offset: 0x0000E689
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.TOGGLE_HERO_MODE;
		}

		// Token: 0x0600188A RID: 6282 RVA: 0x0000EB45 File Offset: 0x0000CD45
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x0600188B RID: 6283 RVA: 0x0005C368 File Offset: 0x0005A568
		public override int Execute(LogicLevel level)
		{
			LogicGameObject gameObjectByID = level.GetGameObjectManager().GetGameObjectByID(this.int_1);
			if (gameObjectByID != null && gameObjectByID.GetGameObjectType() == LogicGameObjectType.BUILDING)
			{
				LogicHeroBaseComponent heroBaseComponent = ((LogicBuilding)gameObjectByID).GetHeroBaseComponent();
				if (heroBaseComponent != null && this.int_2 <= 1)
				{
					if (!heroBaseComponent.SetHeroMode(this.int_2))
					{
						return -2;
					}
					return 0;
				}
			}
			return -1;
		}

		// Token: 0x04000D33 RID: 3379
		private int int_1;

		// Token: 0x04000D34 RID: 3380
		private int int_2;
	}
}
