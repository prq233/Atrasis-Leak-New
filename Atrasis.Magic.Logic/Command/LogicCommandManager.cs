using System;
using Atrasis.Magic.Logic.Battle;
using Atrasis.Magic.Logic.Command.Battle;
using Atrasis.Magic.Logic.Command.Debug;
using Atrasis.Magic.Logic.Command.Home;
using Atrasis.Magic.Logic.Command.Listener;
using Atrasis.Magic.Logic.Command.Server;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Command
{
	// Token: 0x0200016E RID: 366
	public class LogicCommandManager
	{
		// Token: 0x060015BB RID: 5563 RVA: 0x0000E24B File Offset: 0x0000C44B
		public LogicCommandManager(LogicLevel level)
		{
			this.logicLevel_0 = level;
			this.logicArrayList_0 = new LogicArrayList<LogicCommand>();
		}

		// Token: 0x060015BC RID: 5564 RVA: 0x00053C0C File Offset: 0x00051E0C
		public void Destruct()
		{
			if (this.logicArrayList_0 != null)
			{
				for (int i = this.logicArrayList_0.Size() - 1; i >= 0; i--)
				{
					this.logicArrayList_0[i].Destruct();
					this.logicArrayList_0.Remove(i);
				}
				this.logicArrayList_0 = null;
			}
			this.logicCommandManagerListener_0 = null;
			this.logicLevel_0 = null;
		}

		// Token: 0x060015BD RID: 5565 RVA: 0x0000E265 File Offset: 0x0000C465
		public void SetListener(LogicCommandManagerListener listener)
		{
			this.logicCommandManagerListener_0 = listener;
		}

		// Token: 0x060015BE RID: 5566 RVA: 0x0000E26E File Offset: 0x0000C46E
		public void AddCommand(LogicCommand command)
		{
			if (command != null)
			{
				if (this.logicLevel_0.GetState() == 4)
				{
					command.Destruct();
					command = null;
					return;
				}
				this.logicArrayList_0.Add(command);
			}
		}

		// Token: 0x060015BF RID: 5567 RVA: 0x00053C6C File Offset: 0x00051E6C
		public void Decode(ByteStream stream)
		{
			for (int i = this.logicArrayList_0.Size() - 1; i >= 0; i--)
			{
				this.logicArrayList_0[i].Destruct();
				this.logicArrayList_0.Remove(i);
			}
			stream.EnableCheckSum(false);
			int j = 0;
			int num = stream.ReadInt();
			while (j < num)
			{
				this.logicArrayList_0.Add(LogicCommandManager.DecodeCommand(stream));
				j++;
			}
			stream.EnableCheckSum(true);
		}

		// Token: 0x060015C0 RID: 5568 RVA: 0x00053CE0 File Offset: 0x00051EE0
		public void Encode(ChecksumEncoder encoder)
		{
			encoder.EnableCheckSum(false);
			encoder.WriteInt(this.logicArrayList_0.Size());
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				LogicCommand logicCommand = this.logicArrayList_0[i];
				encoder.WriteInt((int)logicCommand.GetCommandType());
				logicCommand.Encode(encoder);
			}
			encoder.EnableCheckSum(true);
		}

		// Token: 0x060015C1 RID: 5569 RVA: 0x00053D44 File Offset: 0x00051F44
		public bool IsCommandAllowedInCurrentState(LogicCommand command)
		{
			int commandType = (int)command.GetCommandType();
			int state = this.logicLevel_0.GetState();
			if (state == 4)
			{
				Debugger.Warning("Execute command failed! Commands are not allowed in visit state.");
				return false;
			}
			if (commandType < 1000 && commandType < 800)
			{
				if (commandType >= 700)
				{
					if (state != 2 && state != 5)
					{
						Debugger.Error("Execute command failed! Command is only allowed in attack state.");
						return false;
					}
				}
				else if (commandType >= 500 && state != 1)
				{
					Debugger.Error("Execute command failed! Command is only allowed in home state.");
					return false;
				}
			}
			return true;
		}

		// Token: 0x060015C2 RID: 5570 RVA: 0x00053DBC File Offset: 0x00051FBC
		public void SubTick()
		{
			int tick = this.logicLevel_0.GetLogicTime().GetTick();
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				LogicCommand logicCommand = this.logicArrayList_0[i];
				if (logicCommand.GetExecuteSubTick() < tick)
				{
					Debugger.Error(string.Format("Execute command failed! Command should have been executed already. (type={0} server_tick={1} command_tick={2})", logicCommand.GetCommandType(), tick, logicCommand.GetExecuteSubTick()));
				}
				if (logicCommand.GetExecuteSubTick() == tick)
				{
					if (this.IsCommandAllowedInCurrentState(logicCommand))
					{
						if (logicCommand.Execute(this.logicLevel_0) == 0)
						{
							LogicCommandManagerListener logicCommandManagerListener = this.logicCommandManagerListener_0;
							if (logicCommandManagerListener != null)
							{
								logicCommandManagerListener.CommandExecuted(logicCommand);
							}
							LogicReplay replay = this.logicLevel_0.GetGameMode().GetReplay();
							if (replay != null)
							{
								replay.RecordCommand(logicCommand);
							}
						}
						this.logicArrayList_0.Remove(i--);
					}
					else
					{
						Debugger.Error(string.Format("Execute command failed! Command not allowed in current state. (type={0} current_state={1}", logicCommand.GetCommandType(), this.logicLevel_0.GetState()));
					}
				}
			}
		}

		// Token: 0x060015C3 RID: 5571 RVA: 0x00053EC4 File Offset: 0x000520C4
		public static LogicCommand CreateCommand(LogicCommandType type)
		{
			LogicCommand result = null;
			if (type < LogicCommandType.BUY_BUILDING)
			{
				switch (type)
				{
				case LogicCommandType.JOIN_ALLIANCE:
					return new LogicJoinAllianceCommand();
				case LogicCommandType.LEAVE_ALLIANCE:
					return new LogicLeaveAllianceCommand();
				case LogicCommandType.CHANGE_AVATAR_NAME:
					return new LogicChangeAvatarNameCommand();
				case LogicCommandType.DONATE_ALLIANCE_UNIT:
					return new LogicDonateAllianceUnitCommand();
				case LogicCommandType.ALLIANCE_UNIT_RECEIVED:
					return new LogicAllianceUnitReceivedCommand();
				case LogicCommandType.ALLIANCE_SETTINGS_CHANGED:
					return new LogicAllianceSettingsChangedCommand();
				case LogicCommandType.DIAMONDS_ADDED:
					return new LogicDiamondsAddedCommand();
				case LogicCommandType.CHANGE_ALLIANCE_ROLE:
					return new LogicChangeAllianceRoleCommand();
				case LogicCommandType.WAR_LOOT_AWARDED:
					return new LogicWarLootAwardedCommand();
				case LogicCommandType.DONATE_ALLIANCE_WAR_UNIT:
					return new LogicDonateAllianceWarUnitCommand();
				case LogicCommandType.CHANGE_LEAGUE:
					return new LogicChangeLeagueCommand();
				case LogicCommandType.DISBAND_LEAGUE:
					return new LogicDisbandLeagueCommand();
				case LogicCommandType.PERSONAL_WAR_PREFERENCE_CHANGED:
					return new LogicPersonalWarPreferenceCommand();
				case LogicCommandType.ALLIANCE_EXP_EARNED:
					return new LogicAllianceExpEarnedCommand();
				case LogicCommandType.RESET_AVATAR_NAME_CHANGE_STATE:
					return new LogicResetAvatarNameChangeStateCommand();
				case LogicCommandType.AVATAR_TOURNAMENT_RESULT:
					return new LogicAvatarTournamentResultCommand();
				case LogicCommandType.TRANSACTIONS_REVOKED:
					return new LogicTransactionsRevokedCommand();
				case LogicCommandType.CHALLENGE_UPDATED:
					return new LogicChallengeUpdatedCommand();
				case LogicCommandType.SAVE_USED_ARMY:
					return new LogicSaveUsedArmyCommand();
				case LogicCommandType.CONTINUE_OFFER_PURCHASE:
					return new LogicContinueOfferPurchaseCommand();
				case LogicCommandType.OFFER_STATE_UPDATED:
					return new LogicOfferStateUpdatedCommand();
				case LogicCommandType.DELIVER_OFFER_PURCHASE:
					return new LogicDeliverOfferPurchaseCommand();
				case LogicCommandType.DUEL_SCORE_CHANGED:
					return new LogicDuelScoreChangedCommand();
				case LogicCommandType.DUEL_LOOT_AWARDED:
					return new LogicDuelLootAwardedCommand();
				case LogicCommandType.V2_HOME_DATA:
					return new LogicV2HomeDataCommand();
				}
				Debugger.Warning("LogicCommandManager::createCommand() - Unknown command type: " + type);
			}
			else
			{
				if (type <= LogicCommandType.CHANGE_UNIT_VILLAGE_2)
				{
					switch (type)
					{
					case LogicCommandType.BUY_BUILDING:
						return new LogicBuyBuildingCommand();
					case LogicCommandType.MOVE_BUILDING:
						return new LogicMoveBuildingCommand();
					case LogicCommandType.UPGRADE_BUILDING:
						return new LogicUpgradeBuildingCommand();
					case LogicCommandType.SELL_BUILDING:
						return new LogicSellBuildingCommand();
					case LogicCommandType.SPEED_UP_CONSTRUCTION:
						return new LogicSpeedUpConstructionCommand();
					case LogicCommandType.CANCEL_CONSTRUCTION:
						return new LogicCancelConstructionCommand();
					case LogicCommandType.COLLECT_RESOURCES:
						return new LogicCollectResourcesCommand();
					case LogicCommandType.CLEAR_OBSTACLE:
						return new LogicClearObstacleCommand();
					case LogicCommandType.TRAIN_UNIT:
						return new LogicTrainUnitCommand();
					case LogicCommandType.CANCEL_UNIT_PRODUCTION:
						return new LogicCancelUnitProductionCommand();
					case LogicCommandType.BUY_TRAP:
						return new LogicBuyTrapCommand();
					case LogicCommandType.REQUEST_ALLIANCE_UNITS:
						return new LogicRequestAllianceUnitsCommand();
					case LogicCommandType.BUY_DECO:
						return new LogicBuyDecoCommand();
					case LogicCommandType.SPEED_UP_TRAINING:
						return new LogicSpeedUpTrainingCommand();
					case LogicCommandType.SPEED_UP_CLEARING:
						return new LogicSpeedUpClearingCommand();
					case LogicCommandType.CANCEL_UPGRADE_UNIT:
						return new LogicCancelUpgradeUnitCommand();
					case LogicCommandType.UPGRADE_UNIT:
						return new LogicUpgradeUnitCommand();
					case LogicCommandType.SPEED_UP_UPGRADE_UNIT:
						return new LogicSpeedUpUpgradeUnitCommand();
					case LogicCommandType.BUY_RESOURCES:
						return new LogicBuyResourcesCommand();
					case LogicCommandType.MISSION_PROGRESS:
						return new LogicMissionProgressCommand();
					case LogicCommandType.UNLOCK_BUILDING:
						return new LogicUnlockBuildingCommand();
					case LogicCommandType.FREE_WORKER:
						return new LogicFreeWorkerCommand();
					case LogicCommandType.BUY_SHIELD:
						return new LogicBuyShieldCommand();
					case LogicCommandType.CLAIM_ACHIEVEMENT_REWARD:
						return new LogicClaimAchievementRewardCommand();
					case LogicCommandType.TOGGLE_ATTACK_MODE:
						return new LogicToggleAttackModeCommand();
					case LogicCommandType.LOAD_TURRET:
						return new LogicLoadTurretCommand();
					case LogicCommandType.BOOST_BUILDING:
						return new LogicBoostBuildingCommand();
					case LogicCommandType.UPGRADE_HERO:
						return new LogicUpgradeHeroCommand();
					case LogicCommandType.SPEED_UP_HERO_UPGRADE:
						return new LogicSpeedUpHeroUpgradeCommand();
					case LogicCommandType.TOGGLE_HERO_SLEEP:
						return new LogicToggleHeroSleepCommand();
					case LogicCommandType.SPEED_UP_HERO_HEALTH:
						return new LogicSpeedUpHeroHealthCommand();
					case LogicCommandType.CANCEL_HERO_UPGRADE:
						return new LogicCancelHeroUpgradeCommand();
					case LogicCommandType.NEW_SHOP_ITEMS_SEEN:
						return new LogicNewShopItemsSeenCommand();
					case LogicCommandType.MOVE_MULTIPLE_BUILDING:
						return new LogicMoveMultipleBuildingsCommand();
					case LogicCommandType.BREAK_SHIELD:
						return new LogicBreakShieldCommand();
					case (LogicCommandType)535:
					case (LogicCommandType)536:
					case (LogicCommandType)547:
					case (LogicCommandType)555:
					case (LogicCommandType)557:
					case (LogicCommandType)562:
					case (LogicCommandType)565:
					case (LogicCommandType)575:
					case (LogicCommandType)578:
					case LogicCommandType.CHALLENGE_FRIEND_CANCEL:
					case LogicCommandType.ACCEPT_ARRANGED_WAR:
					case LogicCommandType.SELECT_WAR_BASE_FOR_ARRANGED_WAR:
					case (LogicCommandType)587:
					case (LogicCommandType)588:
					case (LogicCommandType)594:
						break;
					case LogicCommandType.SEND_ALLIANCE_MAIL:
						return new LogicSendAllianceMailCommand();
					case LogicCommandType.LEAGUE_NOTIFICATION_SEEN:
						return new LogicLeagueNotificationSeenCommand();
					case LogicCommandType.NEWS_SEEN:
						return new LogicNewsSeenCommand();
					case LogicCommandType.TROOP_REQUEST_MESSAGE:
						return new LogicTroopRequestMessageCommand();
					case LogicCommandType.SPEED_UP_TROOP_REQUEST:
						return new LogicSpeedUpTroopRequestCommand();
					case LogicCommandType.SHARE_REPLAY:
						return new LogicShareReplayCommand();
					case LogicCommandType.ELDER_KICK:
						return new LogicElderKickCommand();
					case LogicCommandType.EDIT_MODE_SHOWN:
						return new LogicEditModeShownCommand();
					case LogicCommandType.REPAIR_TRAPS:
						return new LogicRepairTrapsCommand();
					case LogicCommandType.MOVE_BUILDING_EDIT_MODE:
						return new LogicMoveBuildingEditModeCommand();
					case LogicCommandType.SAVE_BASE_LAYOUT:
						return new LogicSaveBaseLayoutCommand();
					case LogicCommandType.UPGRADE_MULTIPLE_BUILDINGS:
						return new LogicUpgradeMultipleBuildingsCommand();
					case LogicCommandType.REMOVE_UNITS:
						return new LogicRemoveUnitsCommand();
					case LogicCommandType.RESUME_BOOST_TRAINING:
						return new LogicResumeBoostTrainingCommand();
					case LogicCommandType.SET_LAYOUT_STATE:
						return new LogicSetLayoutStateCommand();
					case LogicCommandType.ALLIANCE_LEVEL_SEEN:
						return new LogicAllianceLevelSeenCommand();
					case LogicCommandType.ROTATE_BUILDING:
						return new LogicRotateBuildingCommand();
					case LogicCommandType.MOVE_ALL_BUILDINGS_EDIT_MODE:
						return new LogicMoveAllBuildingsEditModeCommand();
					case LogicCommandType.SAVE_UNIT_PRESET:
						return new LogicSaveUnitPresetCommand();
					case LogicCommandType.APPLY_UNIT_PRESET:
						return new LogicApplyUnitPresetCommand();
					case LogicCommandType.START_ALLIANCE_WAR:
						return new LogicStartAllianceWarCommand();
					case LogicCommandType.CANCEL_ALLIANCE_WAR:
						return new LogicCancelAllianceWarCommand();
					case LogicCommandType.TRANSFER_WAR_RESOURCES:
						return new LogicTransferWarResourcesCommand();
					case LogicCommandType.WAR_TROOP_REQUEST_MESSAGE:
						return new LogicWarTroopRequestMessageCommand();
					case LogicCommandType.HELP_OPENED:
						return new LogicHelpOpenedCommand();
					case LogicCommandType.SWITCH_LAYOUT:
						return new LogicSwitchLayoutCommand();
					case LogicCommandType.COPY_LAYOUT:
						return new LogicCopyLayoutCommand();
					case LogicCommandType.SET_PERSISTENT_BOOL:
						return new LogicSetPersistentBoolCommand();
					case LogicCommandType.SET_PERSONAL_WAR_PREFERENCE:
						return new LogicSetPersonalWarPreferenceCommand();
					case LogicCommandType.SET_CLAN_CHAT_FILTER_PREFERENCE:
						return new LogicSetClanChatFilterPreferenceCommand();
					case LogicCommandType.TOGGLE_HERO_MODE:
						return new LogicToggleHeroModeCommand();
					case LogicCommandType.SET_ACCOUNT_FLAG_TO_LEVEL:
						return new LogicSetAccountFlagToLevelCommand();
					case LogicCommandType.CHALLENGE:
						return new LogicChallengeCommand();
					case LogicCommandType.REORDER_TRAINING:
						return new LogicReorderTrainingCommand();
					case LogicCommandType.SWAP_BUILDING:
						return new LogicSwapBuildingCommand();
					case LogicCommandType.FRIEND_LIST_OPENED:
						return new LogicFriendListOpenedCommand();
					case LogicCommandType.SEND_ARRANGED_WAR_REQUEST:
						return new LogicSendArrangedWarRequestCommand();
					case LogicCommandType.BOOST_TRAINING:
						return new LogicBoostTrainingCommand();
					case LogicCommandType.PAUSE_TRAINING:
						return new LogicPauseTrainingCommand();
					case LogicCommandType.NAME_PRESET:
						return new LogicNamePresetCommand();
					case LogicCommandType.PLACE_PENDING_BUILDING:
						return new LogicPlacePendingBuildingCommand();
					case LogicCommandType.BUY_WALL_BLOCK:
						return new LogicBuyWallBlockCommand();
					case LogicCommandType.SET_CURRENT_VILLAGE:
						return new LogicSetCurrentVillageCommand();
					case LogicCommandType.TRAIN_UNIT_VILLAGE_2:
						return new LogicTrainUnitVillage2Command();
					case LogicCommandType.SPEED_UP_TRAINING_VILLAGE_2:
						return new LogicSpeedUpTrainingVillage2Command();
					case LogicCommandType.SPEED_UP_BOOST_COOLDOWN:
						return new LogicSpeedUpBoostCooldownCommand();
					case LogicCommandType.REMOVE_TROOP_VILLAGE_2:
						return new LogicRemoveTroopVillage2Command();
					case LogicCommandType.EVENT_SEEN:
						return new LogicEventSeenCommand();
					case LogicCommandType.MOVE_MULTIPLE_BUILDINGS_EDIT_MODE:
						return new LogicMoveMultipleBuildingsEditModeCommand();
					case LogicCommandType.SWAP_BUILDING_EDIT_MODE:
						return new LogicSwapBuildingEditModeCommand();
					case LogicCommandType.GEAR_UP_BUILDING:
						return new LogicGearUpBuildingCommand();
					case LogicCommandType.MATCHMAKE_VILLAGE2:
						return new LogicMatchmakeVillage2Command();
					case LogicCommandType.SPEED_UP_VILLAGE_2_LOOT_TIMER:
						return new LogicSpeedUpVillage2LootTimerCommand();
					case LogicCommandType.ACCOUNT_BOUND:
						return new LogicAccountBoundCommand();
					case LogicCommandType.SET_ITEM_SEEN:
						return new LogicSetItemSeenCommand();
					case LogicCommandType.CANCEL_CHALLENGE:
						return new LogicCancelChallengeCommand();
					default:
						switch (type)
						{
						case LogicCommandType.PLACE_ATTACKER:
							return new LogicPlaceAttackerCommand();
						case LogicCommandType.PLACE_ALLIANCE_PORTAL:
							return new LogicPlaceAlliancePortalCommand();
						case LogicCommandType.END_ATTACK_PREPARATION:
							return new LogicEndAttackPreparationCommand();
						case LogicCommandType.END_COMBAT:
							return new LogicEndCombatCommand();
						case LogicCommandType.CAST_SPELL:
							return new LogicCastSpellCommand();
						case LogicCommandType.PLACE_HERO:
							return new LogicPlaceHeroCommand();
						case LogicCommandType.TRIGGER_HERO_ABILITY:
							return new LogicTriggerHeroAbilityCommand();
						case LogicCommandType.TRIGGER_COMPONENT_TRIGGERED:
							return new LogicTriggerComponentTriggeredCommand();
						case LogicCommandType.TRIGGER_TESLA:
							return new LogicTriggerTeslaCommand();
						case LogicCommandType.CHANGE_UNIT_VILLAGE_2:
							return new LogicChangeUnitVillage2Command();
						}
						break;
					}
				}
				else
				{
					if (type == LogicCommandType.MATCHMAKING)
					{
						return new LogicMatchmakingCommand();
					}
					if (type == LogicCommandType.DEBUG)
					{
						return new LogicDebugCommand();
					}
				}
				Debugger.Warning("LogicCommandManager::createCommand() - Unknown command type: " + type);
			}
			return result;
		}

		// Token: 0x060015C4 RID: 5572 RVA: 0x000546F4 File Offset: 0x000528F4
		public static LogicCommand DecodeCommand(ByteStream stream)
		{
			LogicCommand logicCommand = LogicCommandManager.CreateCommand((LogicCommandType)stream.ReadInt());
			if (logicCommand == null)
			{
				Debugger.Warning("LogicCommandManager::decodeCommand() - command is null");
			}
			else
			{
				logicCommand.Decode(stream);
			}
			return logicCommand;
		}

		// Token: 0x060015C5 RID: 5573 RVA: 0x0000E297 File Offset: 0x0000C497
		public static void EncodeCommand(ChecksumEncoder encoder, LogicCommand command)
		{
			encoder.WriteInt((int)command.GetCommandType());
			command.Encode(encoder);
		}

		// Token: 0x060015C6 RID: 5574 RVA: 0x00054724 File Offset: 0x00052924
		public static LogicCommand LoadCommandFromJSON(LogicJSONObject jsonObject)
		{
			LogicJSONNumber jsonnumber = jsonObject.GetJSONNumber("ct");
			if (jsonnumber == null)
			{
				Debugger.Error("loadCommandFromJSON - Unknown command type");
				return null;
			}
			LogicCommand logicCommand = LogicCommandManager.CreateCommand((LogicCommandType)jsonnumber.GetIntValue());
			if (logicCommand != null)
			{
				logicCommand.LoadFromJSON(jsonObject.GetJSONObject("c"));
			}
			return logicCommand;
		}

		// Token: 0x060015C7 RID: 5575 RVA: 0x0000E2AC File Offset: 0x0000C4AC
		public static void SaveCommandToJSON(LogicJSONObject jsonObject, LogicCommand command)
		{
			jsonObject.Put("ct", new LogicJSONNumber((int)command.GetCommandType()));
			jsonObject.Put("c", command.GetJSONForReplay());
		}

		// Token: 0x04000C5C RID: 3164
		private LogicLevel logicLevel_0;

		// Token: 0x04000C5D RID: 3165
		private LogicCommandManagerListener logicCommandManagerListener_0;

		// Token: 0x04000C5E RID: 3166
		private LogicArrayList<LogicCommand> logicArrayList_0;
	}
}
