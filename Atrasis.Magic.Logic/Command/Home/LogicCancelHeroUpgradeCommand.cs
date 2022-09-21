using System;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x02000199 RID: 409
	public sealed class LogicCancelHeroUpgradeCommand : LogicCommand
	{
		// Token: 0x060016E8 RID: 5864 RVA: 0x0000EB66 File Offset: 0x0000CD66
		public LogicCancelHeroUpgradeCommand()
		{
		}

		// Token: 0x060016E9 RID: 5865 RVA: 0x0000EFB6 File Offset: 0x0000D1B6
		public LogicCancelHeroUpgradeCommand(int gameObjectId)
		{
			this.int_1 = gameObjectId;
		}

		// Token: 0x060016EA RID: 5866 RVA: 0x0000EFC5 File Offset: 0x0000D1C5
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x060016EB RID: 5867 RVA: 0x0000EFDA File Offset: 0x0000D1DA
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			base.Encode(encoder);
		}

		// Token: 0x060016EC RID: 5868 RVA: 0x0000EFEF File Offset: 0x0000D1EF
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.CANCEL_HERO_UPGRADE;
		}

		// Token: 0x060016ED RID: 5869 RVA: 0x0000EB45 File Offset: 0x0000CD45
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x060016EE RID: 5870 RVA: 0x00057BEC File Offset: 0x00055DEC
		public override int Execute(LogicLevel level)
		{
			LogicGameObject gameObjectByID = level.GetGameObjectManager().GetGameObjectByID(this.int_1);
			if (gameObjectByID != null && gameObjectByID.GetGameObjectType() == LogicGameObjectType.BUILDING)
			{
				LogicHeroBaseComponent heroBaseComponent = ((LogicBuilding)gameObjectByID).GetHeroBaseComponent();
				if (heroBaseComponent != null)
				{
					heroBaseComponent.CancelUpgrade();
					return 0;
				}
			}
			return -1;
		}

		// Token: 0x04000CBB RID: 3259
		private int int_1;
	}
}
