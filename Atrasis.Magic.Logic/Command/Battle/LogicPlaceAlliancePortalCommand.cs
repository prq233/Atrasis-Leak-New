using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Util;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Command.Battle
{
	// Token: 0x020001EA RID: 490
	public sealed class LogicPlaceAlliancePortalCommand : LogicCommand
	{
		// Token: 0x06001905 RID: 6405 RVA: 0x000109A3 File Offset: 0x0000EBA3
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			this.int_2 = stream.ReadInt();
			this.logicAlliancePortalData_0 = (LogicAlliancePortalData)ByteStreamHelper.ReadDataReference(stream, LogicDataType.ALLIANCE_PORTAL);
			base.Decode(stream);
		}

		// Token: 0x06001906 RID: 6406 RVA: 0x000109D7 File Offset: 0x0000EBD7
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			encoder.WriteInt(this.int_2);
			ByteStreamHelper.WriteDataReference(encoder, this.logicAlliancePortalData_0);
			base.Encode(encoder);
		}

		// Token: 0x06001907 RID: 6407 RVA: 0x00010A04 File Offset: 0x0000EC04
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.PLACE_ALLIANCE_PORTAL;
		}

		// Token: 0x06001908 RID: 6408 RVA: 0x00010A0B File Offset: 0x0000EC0B
		public override void Destruct()
		{
			base.Destruct();
			this.logicAlliancePortalData_0 = null;
		}

		// Token: 0x06001909 RID: 6409 RVA: 0x0005F0A0 File Offset: 0x0005D2A0
		public override int Execute(LogicLevel level)
		{
			if (level.IsReadyForAttack() && level.GetVillageType() == 0)
			{
				if (LogicDataTables.GetGlobals().AllowClanCastleDeployOnObstacles())
				{
					if (!level.GetTileMap().IsValidAttackPos(this.int_1 >> 9, this.int_2 >> 9))
					{
						return -2;
					}
				}
				else
				{
					LogicTile tile = level.GetTileMap().GetTile(this.int_1 >> 9, this.int_2 >> 9);
					if (tile == null)
					{
						return -4;
					}
					if (tile.GetPassableFlag() == 0)
					{
						return -3;
					}
				}
				LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
				if (playerAvatar != null && this.logicAlliancePortalData_0 != null)
				{
					LogicGameObjectManager gameObjectManagerAt = level.GetGameObjectManagerAt(0);
					if (gameObjectManagerAt.GetGameObjectCountByData(this.logicAlliancePortalData_0) <= 0 && playerAvatar.GetAllianceCastleUsedCapacity() > 0)
					{
						LogicAlliancePortal logicAlliancePortal = (LogicAlliancePortal)LogicGameObjectFactory.CreateGameObject(this.logicAlliancePortalData_0, level, level.GetVillageType());
						LogicBunkerComponent bunkerComponent = logicAlliancePortal.GetBunkerComponent();
						logicAlliancePortal.SetInitialPosition(this.int_1, this.int_2);
						if (bunkerComponent != null)
						{
							bunkerComponent.SetMaxCapacity(playerAvatar.GetAllianceCastleTotalCapacity());
							if (level.GetBattleLog() != null && !level.GetBattleLog().HasDeployedUnits() && level.GetTotalAttackerHeroPlaced() == 0)
							{
								level.UpdateLastUsedArmy();
							}
							if (level.GetGameMode().IsInAttackPreparationMode())
							{
								level.GetGameMode().EndAttackPreparation();
							}
							bunkerComponent.RemoveAllUnits();
							LogicArrayList<LogicUnitSlot> allianceUnits = playerAvatar.GetAllianceUnits();
							for (int i = 0; i < allianceUnits.Size(); i++)
							{
								LogicUnitSlot logicUnitSlot = allianceUnits[i];
								LogicCombatItemData logicCombatItemData = (LogicCombatItemData)logicUnitSlot.GetData();
								if (logicCombatItemData != null)
								{
									int count = logicUnitSlot.GetCount();
									if (logicCombatItemData.GetCombatItemType() == LogicCombatItemType.CHARACTER)
									{
										for (int j = 0; j < count; j++)
										{
											if (bunkerComponent.GetUnusedCapacity() >= logicCombatItemData.GetHousingSpace())
											{
												bunkerComponent.AddUnitImpl(logicCombatItemData, logicUnitSlot.GetLevel());
											}
										}
									}
								}
								else
								{
									Debugger.Error("LogicPlaceAlliancePortalCommand::execute - NULL alliance character");
								}
							}
						}
						gameObjectManagerAt.AddGameObject(logicAlliancePortal, -1);
						return 0;
					}
				}
				return -5;
			}
			return -1;
		}

		// Token: 0x0600190A RID: 6410 RVA: 0x0005F280 File Offset: 0x0005D480
		public override void LoadFromJSON(LogicJSONObject jsonRoot)
		{
			LogicJSONObject jsonobject = jsonRoot.GetJSONObject("base");
			if (jsonobject == null)
			{
				Debugger.Error("Replay LogicPlaceAlliancePortalCommand load failed! Base missing!");
			}
			base.LoadFromJSON(jsonobject);
			LogicJSONNumber jsonnumber = jsonRoot.GetJSONNumber("d");
			if (jsonnumber != null)
			{
				this.logicAlliancePortalData_0 = (LogicAlliancePortalData)LogicDataTables.GetDataById(jsonnumber.GetIntValue(), LogicDataType.ALLIANCE_PORTAL);
			}
			if (this.logicAlliancePortalData_0 == null)
			{
				Debugger.Error("Replay LogicPlaceAlliancePortalCommand load failed! Data is NULL!");
			}
			this.int_1 = jsonRoot.GetJSONNumber("x").GetIntValue();
			this.int_2 = jsonRoot.GetJSONNumber("y").GetIntValue();
		}

		// Token: 0x0600190B RID: 6411 RVA: 0x0005F314 File Offset: 0x0005D514
		public override LogicJSONObject GetJSONForReplay()
		{
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			logicJSONObject.Put("base", base.GetJSONForReplay());
			if (this.logicAlliancePortalData_0 != null)
			{
				logicJSONObject.Put("d", new LogicJSONNumber(this.logicAlliancePortalData_0.GetGlobalID()));
			}
			logicJSONObject.Put("x", new LogicJSONNumber(this.int_1));
			logicJSONObject.Put("y", new LogicJSONNumber(this.int_2));
			return logicJSONObject;
		}

		// Token: 0x04000D96 RID: 3478
		private int int_1;

		// Token: 0x04000D97 RID: 3479
		private int int_2;

		// Token: 0x04000D98 RID: 3480
		private LogicAlliancePortalData logicAlliancePortalData_0;
	}
}
