using System;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001D9 RID: 473
	public sealed class LogicToggleHeroSleepCommand : LogicCommand
	{
		// Token: 0x0600188C RID: 6284 RVA: 0x0000EB66 File Offset: 0x0000CD66
		public LogicToggleHeroSleepCommand()
		{
		}

		// Token: 0x0600188D RID: 6285 RVA: 0x00010490 File Offset: 0x0000E690
		public LogicToggleHeroSleepCommand(int gameObjectId, bool enabled)
		{
			this.int_1 = gameObjectId;
			this.bool_0 = enabled;
		}

		// Token: 0x0600188E RID: 6286 RVA: 0x000104A6 File Offset: 0x0000E6A6
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			this.bool_0 = stream.ReadBoolean();
			base.Decode(stream);
		}

		// Token: 0x0600188F RID: 6287 RVA: 0x000104C7 File Offset: 0x0000E6C7
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			encoder.WriteBoolean(this.bool_0);
			base.Encode(encoder);
		}

		// Token: 0x06001890 RID: 6288 RVA: 0x000104E8 File Offset: 0x0000E6E8
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.TOGGLE_HERO_SLEEP;
		}

		// Token: 0x06001891 RID: 6289 RVA: 0x0000EB45 File Offset: 0x0000CD45
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06001892 RID: 6290 RVA: 0x0005C3C0 File Offset: 0x0005A5C0
		public override int Execute(LogicLevel level)
		{
			LogicGameObject gameObjectByID = level.GetGameObjectManager().GetGameObjectByID(this.int_1);
			if (gameObjectByID == null || gameObjectByID.GetGameObjectType() != LogicGameObjectType.BUILDING)
			{
				return -1;
			}
			LogicHeroBaseComponent heroBaseComponent = ((LogicBuilding)gameObjectByID).GetHeroBaseComponent();
			if (heroBaseComponent == null)
			{
				return -4;
			}
			if (heroBaseComponent.GetHeroData().HasNoDefence())
			{
				return -3;
			}
			if (!heroBaseComponent.SetSleep(this.bool_0))
			{
				return -2;
			}
			return 0;
		}

		// Token: 0x04000D35 RID: 3381
		private int int_1;

		// Token: 0x04000D36 RID: 3382
		private bool bool_0;
	}
}
