using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001A9 RID: 425
	public sealed class LogicLoadTurretCommand : LogicCommand
	{
		// Token: 0x0600174F RID: 5967 RVA: 0x0000F423 File Offset: 0x0000D623
		public LogicLoadTurretCommand()
		{
			this.logicArrayList_0 = new LogicArrayList<int>();
		}

		// Token: 0x06001750 RID: 5968 RVA: 0x00058AA4 File Offset: 0x00056CA4
		public override void Decode(ByteStream stream)
		{
			int i = 0;
			int num = stream.ReadInt();
			while (i < num)
			{
				this.logicArrayList_0.Add(stream.ReadInt());
				i++;
			}
			base.Decode(stream);
		}

		// Token: 0x06001751 RID: 5969 RVA: 0x00058ADC File Offset: 0x00056CDC
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.logicArrayList_0.Size());
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				encoder.WriteInt(this.logicArrayList_0[i]);
			}
			base.Encode(encoder);
		}

		// Token: 0x06001752 RID: 5970 RVA: 0x0000F436 File Offset: 0x0000D636
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.LOAD_TURRET;
		}

		// Token: 0x06001753 RID: 5971 RVA: 0x0000EB45 File Offset: 0x0000CD45
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06001754 RID: 5972 RVA: 0x00058B2C File Offset: 0x00056D2C
		public override int Execute(LogicLevel level)
		{
			if (this.logicArrayList_0.Size() > 0)
			{
				LogicResourceData logicResourceData = null;
				int num = 0;
				int num2 = 0;
				do
				{
					LogicGameObject gameObjectByID = level.GetGameObjectManager().GetGameObjectByID(this.logicArrayList_0[num2]);
					if (gameObjectByID != null && gameObjectByID.GetGameObjectType() == LogicGameObjectType.BUILDING)
					{
						LogicBuilding logicBuilding = (LogicBuilding)gameObjectByID;
						if (logicBuilding.GetData().GetVillageType() != level.GetVillageType())
						{
							return -32;
						}
						LogicCombatComponent combatComponent = logicBuilding.GetCombatComponent(false);
						if (combatComponent != null && combatComponent.UseAmmo() && combatComponent.GetAmmoCount() < combatComponent.GetMaxAmmo() && !logicBuilding.IsUpgrading())
						{
							LogicBuildingData buildingData = logicBuilding.GetBuildingData();
							logicResourceData = buildingData.GetAmmoResourceData(0);
							num += buildingData.GetAmmoCost(logicBuilding.GetUpgradeLevel(), combatComponent.GetMaxAmmo() - combatComponent.GetAmmoCount());
						}
					}
				}
				while (++num2 < this.logicArrayList_0.Size());
				if (logicResourceData == null || num <= 0)
				{
					return -1;
				}
				LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
				if (playerAvatar.HasEnoughResources(logicResourceData, num, true, this, false))
				{
					for (int i = 0; i < this.logicArrayList_0.Size(); i++)
					{
						LogicGameObject gameObjectByID2 = level.GetGameObjectManager().GetGameObjectByID(this.logicArrayList_0[i]);
						if (gameObjectByID2 == null || gameObjectByID2.GetGameObjectType() != LogicGameObjectType.BUILDING)
						{
							break;
						}
						LogicBuilding logicBuilding2 = (LogicBuilding)gameObjectByID2;
						LogicCombatComponent combatComponent2 = logicBuilding2.GetCombatComponent(false);
						if (combatComponent2 == null || !combatComponent2.UseAmmo() || combatComponent2.GetAmmoCount() >= combatComponent2.GetMaxAmmo())
						{
							break;
						}
						int upgradeLevel = logicBuilding2.GetUpgradeLevel();
						LogicBuildingData buildingData2 = logicBuilding2.GetBuildingData();
						LogicResourceData ammoResourceData = buildingData2.GetAmmoResourceData(upgradeLevel);
						int ammoCost = buildingData2.GetAmmoCost(upgradeLevel, combatComponent2.GetMaxAmmo() - combatComponent2.GetAmmoCount());
						if (!playerAvatar.HasEnoughResources(ammoResourceData, ammoCost, true, this, false))
						{
							break;
						}
						playerAvatar.CommodityCountChangeHelper(0, ammoResourceData, -ammoCost);
						combatComponent2.LoadAmmo();
					}
					return 0;
				}
				return -2;
			}
			return -1;
		}

		// Token: 0x04000CD5 RID: 3285
		private readonly LogicArrayList<int> logicArrayList_0;
	}
}
