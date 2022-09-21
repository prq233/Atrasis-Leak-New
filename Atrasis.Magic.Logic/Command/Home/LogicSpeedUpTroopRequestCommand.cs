using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Util;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001D0 RID: 464
	public sealed class LogicSpeedUpTroopRequestCommand : LogicCommand
	{
		// Token: 0x06001852 RID: 6226 RVA: 0x0000EC66 File Offset: 0x0000CE66
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
		}

		// Token: 0x06001853 RID: 6227 RVA: 0x0000EC6F File Offset: 0x0000CE6F
		public override void Encode(ChecksumEncoder encoder)
		{
			base.Encode(encoder);
		}

		// Token: 0x06001854 RID: 6228 RVA: 0x000101B8 File Offset: 0x0000E3B8
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.SPEED_UP_TROOP_REQUEST;
		}

		// Token: 0x06001855 RID: 6229 RVA: 0x0000EB45 File Offset: 0x0000CD45
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06001856 RID: 6230 RVA: 0x0005B8A0 File Offset: 0x00059AA0
		public override int Execute(LogicLevel level)
		{
			if (!LogicDataTables.GetGlobals().UseTroopRequestSpeedUp())
			{
				return -1;
			}
			LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
			LogicBuilding allianceCastle = level.GetGameObjectManagerAt(0).GetAllianceCastle();
			if (allianceCastle == null)
			{
				return -3;
			}
			LogicBunkerComponent bunkerComponent = allianceCastle.GetBunkerComponent();
			if (bunkerComponent == null)
			{
				return -4;
			}
			if (playerAvatar.GetAllianceCastleUsedCapacity() >= playerAvatar.GetAllianceCastleTotalCapacity() && playerAvatar.GetAllianceCastleUsedSpellCapacity() >= playerAvatar.GetAllianceCastleTotalSpellCapacity())
			{
				return -5;
			}
			int speedUpCost = LogicGamePlayUtil.GetSpeedUpCost(bunkerComponent.GetRequestCooldownTime(), 3, 0);
			if (playerAvatar.HasEnoughDiamonds(speedUpCost, true, level))
			{
				playerAvatar.UseDiamonds(speedUpCost);
				playerAvatar.GetChangeListener().DiamondPurchaseMade(11, 0, 0, speedUpCost, level.GetVillageType());
				bunkerComponent.StopRequestCooldownTime();
				return 0;
			}
			return -6;
		}
	}
}
