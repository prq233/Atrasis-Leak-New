using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001B9 RID: 441
	public sealed class LogicRequestAllianceUnitsCommand : LogicCommand
	{
		// Token: 0x060017B5 RID: 6069 RVA: 0x0000FA62 File Offset: 0x0000DC62
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
			if (stream.ReadBoolean())
			{
				this.string_0 = stream.ReadString(900000);
			}
		}

		// Token: 0x060017B6 RID: 6070 RVA: 0x0000FA84 File Offset: 0x0000DC84
		public override void Encode(ChecksumEncoder encoder)
		{
			base.Encode(encoder);
			if (this.string_0 != null)
			{
				encoder.WriteBoolean(true);
				encoder.WriteString(this.string_0);
				return;
			}
			encoder.WriteBoolean(false);
		}

		// Token: 0x060017B7 RID: 6071 RVA: 0x0000FAB0 File Offset: 0x0000DCB0
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.REQUEST_ALLIANCE_UNITS;
		}

		// Token: 0x060017B8 RID: 6072 RVA: 0x0000FAB7 File Offset: 0x0000DCB7
		public override void Destruct()
		{
			base.Destruct();
			this.string_0 = null;
		}

		// Token: 0x060017B9 RID: 6073 RVA: 0x0005A71C File Offset: 0x0005891C
		public override int Execute(LogicLevel level)
		{
			LogicBuilding allianceCastle = level.GetGameObjectManagerAt(0).GetAllianceCastle();
			if (allianceCastle != null)
			{
				LogicBunkerComponent bunkerComponent = allianceCastle.GetBunkerComponent();
				if (bunkerComponent != null && bunkerComponent.GetRequestCooldownTime() == 0)
				{
					LogicAvatar homeOwnerAvatar = level.GetHomeOwnerAvatar();
					homeOwnerAvatar.GetChangeListener().RequestAllianceUnits(allianceCastle.GetUpgradeLevel(), bunkerComponent.GetUsedCapacity(), bunkerComponent.GetMaxCapacity(), homeOwnerAvatar.GetAllianceCastleUsedSpellCapacity(), homeOwnerAvatar.GetAllianceCastleTotalSpellCapacity(), this.string_0);
					bunkerComponent.StartRequestCooldownTime();
					return 0;
				}
			}
			return -1;
		}

		// Token: 0x04000CFD RID: 3325
		private string string_0;
	}
}
