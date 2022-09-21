using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001E0 RID: 480
	public sealed class LogicUpgradeHeroCommand : LogicCommand
	{
		// Token: 0x060018BD RID: 6333 RVA: 0x0000EB66 File Offset: 0x0000CD66
		public LogicUpgradeHeroCommand()
		{
		}

		// Token: 0x060018BE RID: 6334 RVA: 0x00010742 File Offset: 0x0000E942
		public LogicUpgradeHeroCommand(int gameObjectId)
		{
			this.int_1 = gameObjectId;
		}

		// Token: 0x060018BF RID: 6335 RVA: 0x00010751 File Offset: 0x0000E951
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x060018C0 RID: 6336 RVA: 0x00010766 File Offset: 0x0000E966
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			base.Encode(encoder);
		}

		// Token: 0x060018C1 RID: 6337 RVA: 0x0001077B File Offset: 0x0000E97B
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.UPGRADE_HERO;
		}

		// Token: 0x060018C2 RID: 6338 RVA: 0x0000EB45 File Offset: 0x0000CD45
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x060018C3 RID: 6339 RVA: 0x0005CB5C File Offset: 0x0005AD5C
		public override int Execute(LogicLevel level)
		{
			LogicBuilding logicBuilding = (LogicBuilding)level.GetGameObjectManager().GetGameObjectByID(this.int_1);
			if (logicBuilding.IsLocked())
			{
				return -23;
			}
			if (logicBuilding.GetBuildingData().GetVillageType() == level.GetVillageType())
			{
				LogicHeroBaseComponent heroBaseComponent = logicBuilding.GetHeroBaseComponent();
				if (heroBaseComponent != null && heroBaseComponent.CanStartUpgrading(true))
				{
					LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
					LogicHeroData heroData = logicBuilding.GetBuildingData().GetHeroData();
					int unitUpgradeLevel = playerAvatar.GetUnitUpgradeLevel(heroData);
					int upgradeCost = heroData.GetUpgradeCost(unitUpgradeLevel);
					LogicResourceData upgradeResource = heroData.GetUpgradeResource(unitUpgradeLevel);
					if (playerAvatar.HasEnoughResources(upgradeResource, upgradeCost, true, this, false) && level.HasFreeWorkers(this, -1))
					{
						playerAvatar.CommodityCountChangeHelper(0, upgradeResource, -upgradeCost);
						heroBaseComponent.StartUpgrading();
						return 0;
					}
				}
				return -1;
			}
			return -32;
		}

		// Token: 0x04000D43 RID: 3395
		private int int_1;
	}
}
