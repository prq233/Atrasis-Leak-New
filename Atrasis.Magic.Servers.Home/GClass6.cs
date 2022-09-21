using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Command;
using Atrasis.Magic.Logic.Command.Battle;
using Atrasis.Magic.Logic.Command.Server;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Home;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Message.Avatar.Stream;
using Atrasis.Magic.Logic.Message.Home;
using Atrasis.Magic.Logic.Mode;
using Atrasis.Magic.Logic.Time;
using Atrasis.Magic.Servers.Core;
using Atrasis.Magic.Servers.Core.Helper;
using Atrasis.Magic.Servers.Core.Network;
using Atrasis.Magic.Servers.Core.Network.Message;
using Atrasis.Magic.Servers.Core.Network.Message.Account;
using Atrasis.Magic.Servers.Core.Network.Message.Request.Stream;
using Atrasis.Magic.Servers.Core.Network.Message.Session;
using Atrasis.Magic.Servers.Core.Network.Message.Session.State;
using Atrasis.Magic.Servers.Core.Network.Request;
using Atrasis.Magic.Servers.Core.Settings;
using Atrasis.Magic.Servers.Core.Util;
using Atrasis.Magic.Titan.Exception;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace ns0
{
	// Token: 0x02000009 RID: 9
	public class GClass6
	{
		// Token: 0x0600002A RID: 42 RVA: 0x000032DC File Offset: 0x000014DC
		private GClass6(GClass2 gclass2_1)
		{
			this.gclass2_0 = gclass2_1;
			this.stopwatch_0 = new Stopwatch();
			this.logicGameMode_0 = new LogicGameMode();
			this.gclass10_0 = new GClass10(this, this.logicGameMode_0);
			this.gclass8_0 = new GClass8(this);
			this.logicGameMode_0.GetLevel().SetGameListener(this.gclass8_0);
			this.logicGameMode_0.GetCommandManager().SetListener(this.gclass10_0);
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00003358 File Offset: 0x00001558
		public void method_0()
		{
			GClass6.Struct0 @struct;
			@struct.gclass6_0 = this;
			@struct.asyncVoidMethodBuilder_0 = AsyncVoidMethodBuilder.Create();
			@struct.int_0 = -1;
			AsyncVoidMethodBuilder asyncVoidMethodBuilder_ = @struct.asyncVoidMethodBuilder_0;
			asyncVoidMethodBuilder_.Start<GClass6.Struct0>(ref @struct);
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00003394 File Offset: 0x00001594
		public void method_1(int int_0, int int_1, LogicArrayList<LogicCommand> logicArrayList_0)
		{
			if (!this.bool_1 && this.logicGameMode_0.GetState() != 4)
			{
				if (this.logicGameMode_0.GetState() != 5)
				{
					int timestamp = TimeUtil.GetTimestamp();
					int num = this.logicGameMode_0.GetStartTime() + LogicTime.GetTicksInSeconds(int_0);
					if (timestamp + 1 >= num)
					{
						if (logicArrayList_0 != null)
						{
							this.gclass10_0.method_3(int_0, logicArrayList_0);
							for (int i = 0; i < logicArrayList_0.Size(); i++)
							{
								this.logicGameMode_0.GetCommandManager().AddCommand(logicArrayList_0[i]);
							}
						}
						int tick = this.logicGameMode_0.GetLevel().GetLogicTime().GetTick();
						try
						{
							this.stopwatch_0.Start();
							int j = 0;
							int num2 = int_0 - tick;
							while (j < num2)
							{
								this.logicGameMode_0.UpdateOneSubTick();
								j++;
							}
							GClass12.smethod_7(this.stopwatch_0.ElapsedMilliseconds);
							this.stopwatch_0.Reset();
						}
						catch (LogicException ex)
						{
							Logging.Error(string.Concat(new object[]
							{
								"GameMode.onClientTurnReceived: logic exception thrown: ",
								ex,
								" (acc id: ",
								this.gclass2_0.AccountId,
								")"
							}));
							ServerErrorMessage serverErrorMessage = new ServerErrorMessage();
							serverErrorMessage.SetErrorMessage(ex.Message);
							this.gclass2_0.SendPiranhaMessage(serverErrorMessage, 1);
							this.gclass2_0.SendMessage(new StopSessionMessage(), 1);
						}
						catch (Exception ex2)
						{
							Logging.Error(string.Concat(new object[]
							{
								"GameMode.onClientTurnReceived: exception thrown: ",
								ex2,
								" (acc id: ",
								this.gclass2_0.AccountId,
								")"
							}));
							this.gclass2_0.SendMessage(new StopSessionMessage(), 1);
						}
						this.method_4();
						this.method_5(int_1);
						if (this.logicLong_0 != null)
						{
							this.method_6(int_0, logicArrayList_0);
						}
						if (this.logicGameMode_0.IsBattleOver() && this.logicGameMode_0.GetState() == 2)
						{
							this.bool_0 = true;
						}
						if (this.bool_0)
						{
							this.gclass2_0.method_6();
							return;
						}
					}
					else
					{
						this.gclass2_0.SendMessage(new StopSessionMessage(), 1);
					}
					return;
				}
			}
		}

		// Token: 0x0600002D RID: 45 RVA: 0x000035E0 File Offset: 0x000017E0
		private void method_2()
		{
			GClass6.Class1 @class = new GClass6.Class1();
			@class.gclass6_0 = this;
			@class.logicClientAvatar_1 = (LogicClientAvatar)this.logicGameMode_0.GetLevel().GetVisitorAvatar();
			@class.logicClientAvatar_0 = (LogicClientAvatar)this.logicGameMode_0.GetLevel().GetHomeOwnerAvatar();
			@class.string_0 = LogicJSONParser.CreateJSONString(this.logicGameMode_0.GetLevel().GetBattleLog().GenerateAttackerJSON(), 20);
			@class.string_1 = LogicJSONParser.CreateJSONString(this.logicGameMode_0.GetLevel().GetBattleLog().GenerateDefenderJSON(), 20);
			ServerRequestManager.Create(new CreateReplayStreamRequestMessage
			{
				JSON = LogicJSONParser.CreateJSONString(this.logicGameMode_0.GetReplay().GetJson(), 1536)
			}, ServerManager.GetNextSocket(11), 30).OnComplete = new ServerRequestArgs.CompleteHandler(@class.method_0);
		}

		// Token: 0x0600002E RID: 46 RVA: 0x000036B8 File Offset: 0x000018B8
		private void method_3()
		{
			LogicGameObjectManager gameObjectManager = this.logicGameMode_0.GetLevel().GetGameObjectManager();
			LogicArrayList<LogicGameObject> gameObjects = gameObjectManager.GetGameObjects(LogicGameObjectType.CHARACTER);
			LogicArrayList<LogicGameObject> gameObjects2 = gameObjectManager.GetGameObjects(LogicGameObjectType.PROJECTILE);
			LogicArrayList<LogicGameObject> gameObjects3 = gameObjectManager.GetGameObjects(LogicGameObjectType.SPELL);
			LogicArrayList<LogicGameObject> gameObjects4 = gameObjectManager.GetGameObjects(LogicGameObjectType.ALLIANCE_PORTAL);
			try
			{
				this.stopwatch_0.Start();
				while (!this.logicGameMode_0.IsBattleOver())
				{
					bool flag = !this.logicGameMode_0.GetConfiguration().GetBattleWaitForProjectileDestruction() || gameObjects2.Size() == 0;
					for (int i = 0; i < gameObjects.Size(); i++)
					{
						LogicCharacter logicCharacter = (LogicCharacter)gameObjects[i];
						LogicHitpointComponent hitpointComponent = logicCharacter.GetHitpointComponent();
						if (hitpointComponent != null && hitpointComponent.GetTeam() == 0 && logicCharacter.GetAttackerItemData().GetDamage(0, false) > 0 && (hitpointComponent.GetHitpoints() > 0 || (this.logicGameMode_0.GetConfiguration().GetBattleWaitForDieDamage() && logicCharacter.GetWaitDieDamage())))
						{
							flag = false;
						}
					}
					for (int j = 0; j < gameObjects3.Size(); j++)
					{
						LogicSpell logicSpell = (LogicSpell)gameObjects3[j];
						if (!logicSpell.GetHitsCompleted() && (logicSpell.GetSpellData().IsDamageSpell() || logicSpell.GetSpellData().GetSummonTroop() != null))
						{
							flag = false;
						}
					}
					for (int k = 0; k < gameObjects4.Size(); k++)
					{
						LogicAlliancePortal logicAlliancePortal = (LogicAlliancePortal)gameObjects4[k];
						if (logicAlliancePortal.GetBunkerComponent().GetTeam() == 0 && !logicAlliancePortal.GetBunkerComponent().IsEmpty())
						{
							flag = false;
						}
					}
					int num;
					if (flag)
					{
						num = 1;
						goto IL_184;
					}
					if ((num = ((this.stopwatch_0.ElapsedMilliseconds >= 10000L) ? 1 : 0)) != 0)
					{
						goto IL_184;
					}
					IL_1B9:
					this.logicGameMode_0.UpdateOneSubTick();
					if (num == 0)
					{
						continue;
					}
					break;
					IL_184:
					LogicEndCombatCommand logicEndCombatCommand = new LogicEndCombatCommand();
					logicEndCombatCommand.SetExecuteSubTick(this.logicGameMode_0.GetLevel().GetLogicTime().GetTick());
					this.logicGameMode_0.GetCommandManager().AddCommand(logicEndCombatCommand);
					goto IL_1B9;
				}
				this.stopwatch_0.Reset();
			}
			catch (LogicException)
			{
			}
			catch (Exception ex)
			{
				Logging.Error(string.Concat(new object[]
				{
					"GameMode.simulateEndAttackState: exception thrown: ",
					ex,
					" (acc id: ",
					this.gclass2_0.AccountId,
					")"
				}));
			}
			if (!this.logicGameMode_0.IsBattleOver())
			{
				this.logicGameMode_0.SetBattleOver();
			}
			if (this.logicLong_0 != null)
			{
				this.method_6(this.logicGameMode_0.GetLevel().GetLogicTime().GetTick(), null);
			}
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00003964 File Offset: 0x00001B64
		private void method_4()
		{
			if (this.logicGameMode_0.GetState() == 1)
			{
				LogicJSONObject logicJSONObject = new LogicJSONObject(64);
				this.logicGameMode_0.SaveToJSON(logicJSONObject);
				byte[] homeJSON;
				ZLibHelper.CompressInZLibFormat(LogicStringUtil.GetBytes(LogicJSONParser.CreateJSONString(logicJSONObject, 1536)), out homeJSON);
				ServerMessageManager.SendMessage(new GameStateCallbackMessage
				{
					AccountId = this.logicGameMode_0.GetLevel().GetPlayerAvatar().GetId(),
					SessionId = this.gclass2_0.Id,
					LogicClientAvatar = this.logicGameMode_0.GetLevel().GetPlayerAvatar(),
					AvatarChanges = this.gclass7_0.method_0(),
					ExecutedServerCommands = this.gclass10_0.method_2(),
					HomeJSON = homeJSON,
					SaveTime = TimeUtil.GetTimestamp()
				}, 9);
			}
			else if (this.gclass7_0 != null)
			{
				ServerMessageManager.SendMessage(new GameStateCallbackMessage
				{
					AccountId = this.logicGameMode_0.GetLevel().GetPlayerAvatar().GetId(),
					SessionId = this.gclass2_0.Id,
					AvatarChanges = this.gclass7_0.method_0()
				}, 9);
			}
			if (this.bool_2)
			{
				LogicClientAvatar logicClientAvatar = (LogicClientAvatar)this.logicGameMode_0.GetLevel().GetHomeOwnerAvatar();
				LogicJSONObject logicJSONObject2 = new LogicJSONObject(64);
				this.logicGameMode_0.SaveToJSON(logicJSONObject2);
				byte[] homeJSON2;
				ZLibHelper.CompressInZLibFormat(LogicStringUtil.GetBytes(LogicJSONParser.CreateJSONString(logicJSONObject2, 1536)), out homeJSON2);
				ServerMessageManager.SendMessage(new GameStateCallbackMessage
				{
					AccountId = logicClientAvatar.GetId(),
					AvatarChanges = this.gclass7_1.method_0(),
					HomeJSON = homeJSON2,
					SaveTime = TimeUtil.GetTimestamp()
				}, 9);
			}
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00003B0C File Offset: 0x00001D0C
		private void method_5(int int_0)
		{
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			ChecksumHelper checksumHelper = this.logicGameMode_0.CalculateChecksum(logicJSONObject, ResourceSettings.Environment.ContentValidationModeEnabled);
			if (checksumHelper.GetChecksum() != int_0)
			{
				OutOfSyncMessage outOfSyncMessage = new OutOfSyncMessage();
				outOfSyncMessage.SetSubTick(this.logicGameMode_0.GetLevel().GetLogicTime().GetTick());
				outOfSyncMessage.SetClientChecksum(int_0);
				outOfSyncMessage.SetServerChecksum(checksumHelper.GetChecksum());
				outOfSyncMessage.SetDebugJSON(logicJSONObject);
				this.gclass2_0.SendPiranhaMessage(outOfSyncMessage, 1);
				this.bool_0 = true;
			}
		}

		// Token: 0x06000031 RID: 49 RVA: 0x0000221E File Offset: 0x0000041E
		private void method_6(int int_0, LogicArrayList<LogicCommand> logicArrayList_0)
		{
			ServerMessageManager.SendMessage(new ClientUpdateLiveReplayMessage
			{
				AccountId = this.logicLong_0,
				SubTick = int_0,
				Commands = logicArrayList_0
			}, 9);
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00002246 File Offset: 0x00000446
		public void method_7()
		{
			this.bool_0 = true;
		}

		// Token: 0x06000033 RID: 51 RVA: 0x0000224F File Offset: 0x0000044F
		public GClass2 method_8()
		{
			return this.gclass2_0;
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00002257 File Offset: 0x00000457
		public LogicGameMode method_9()
		{
			return this.logicGameMode_0;
		}

		// Token: 0x06000035 RID: 53 RVA: 0x0000225F File Offset: 0x0000045F
		public LogicClientAvatar method_10()
		{
			return this.logicGameMode_0.GetLevel().GetPlayerAvatar();
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00002271 File Offset: 0x00000471
		public GClass7 method_11()
		{
			return this.gclass7_0;
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00002279 File Offset: 0x00000479
		public bool method_12(LogicCommandType logicCommandType_0)
		{
			return this.gclass10_0.method_1(logicCommandType_0);
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00003B8C File Offset: 0x00001D8C
		public void method_13(LogicServerCommand logicServerCommand_0)
		{
			if (this.logicGameMode_0.GetState() != 1)
			{
				throw new Exception("GameMode.addServerCommand: Method called in invalid game state.");
			}
			this.gclass10_0.method_0(logicServerCommand_0);
			AvailableServerCommandMessage availableServerCommandMessage = new AvailableServerCommandMessage();
			availableServerCommandMessage.SetServerCommand(logicServerCommand_0);
			this.gclass2_0.SendPiranhaMessage(availableServerCommandMessage, 1);
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00003BD8 File Offset: 0x00001DD8
		public byte[] method_14()
		{
			if (this.logicGameMode_0.GetState() != 1)
			{
				throw new Exception("GameMode.createChallengeSnapshot called in invalid logic state.");
			}
			LogicLevel level = this.logicGameMode_0.GetLevel();
			LogicJSONObject logicJSONObject = new LogicJSONObject(64);
			logicJSONObject.Put("exp_ver", new LogicJSONNumber(level.GetExperienceVersion()));
			level.GetGameObjectManagerAt(0).SaveToSnapshot(logicJSONObject, 6);
			this.logicGameMode_0.GetLevel().GetHomeOwnerAvatar().SaveToDirect(logicJSONObject);
			byte[] result;
			ZLibHelper.CompressInZLibFormat(LogicStringUtil.GetBytes(LogicJSONParser.CreateJSONString(logicJSONObject, 1536)), out result);
			return result;
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00003C68 File Offset: 0x00001E68
		public byte[] method_15()
		{
			if (this.logicGameMode_0.GetState() != 1)
			{
				throw new Exception("GameMode.createSnapshot called in invalid logic state.");
			}
			LogicLevel level = this.logicGameMode_0.GetLevel();
			LogicJSONObject logicJSONObject = new LogicJSONObject(64);
			logicJSONObject.Put("exp_ver", new LogicJSONNumber(level.GetExperienceVersion()));
			level.GetGameObjectManagerAt(0).SaveToSnapshot(logicJSONObject, level.GetActiveLayout(0));
			level.GetGameObjectManagerAt(1).SaveToSnapshot(logicJSONObject, level.GetActiveLayout(1));
			this.logicGameMode_0.GetLevel().GetHomeOwnerAvatar().SaveToDirect(logicJSONObject);
			byte[] result;
			ZLibHelper.CompressInZLibFormat(LogicStringUtil.GetBytes(LogicJSONParser.CreateJSONString(logicJSONObject, 1536)), out result);
			return result;
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00003D10 File Offset: 0x00001F10
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("account: " + this.gclass2_0.AccountId);
			stringBuilder.AppendLine("state: " + this.logicGameMode_0.GetState());
			stringBuilder.AppendLine("numGameObjects: " + this.logicGameMode_0.GetLevel().GetGameObjectManager().GetNumGameObjects());
			stringBuilder.AppendLine("numCharacterCount: " + this.logicGameMode_0.GetLevel().GetGameObjectManager().GetGameObjects(LogicGameObjectType.CHARACTER).Size());
			return stringBuilder.ToString();
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00003DC0 File Offset: 0x00001FC0
		public static GClass6 smethod_0(GClass2 gclass2_1, GameHomeState gameHomeState_0)
		{
			LogicClientHome logicClientHome = GClass6.smethod_5(gameHomeState_0.HomeId, gameHomeState_0.HomeData, gameHomeState_0.RemainingShieldTimeSeconds, gameHomeState_0.RemainingGuardTimeSeconds, LogicDataTables.GetGlobals().GetPersonalBreakLimitSeconds());
			LogicClientAvatar playerAvatar = gameHomeState_0.PlayerAvatar;
			int timestamp = TimeUtil.GetTimestamp();
			int num = (gameHomeState_0.SaveTime != -1) ? (timestamp - gameHomeState_0.SaveTime) : 0;
			int secondsSinceLastMaintenance = (gameHomeState_0.MaintenanceTime != -1) ? (timestamp - gameHomeState_0.MaintenanceTime) : 0;
			int reengagementSeconds = (num >= 86400) ? (num - 86400) : 0;
			OwnHomeDataMessage ownHomeDataMessage = new OwnHomeDataMessage();
			ownHomeDataMessage.SetCurrentTimestamp(timestamp);
			ownHomeDataMessage.SetReengagementSeconds(reengagementSeconds);
			ownHomeDataMessage.SetSecondsSinceLastSave(num);
			ownHomeDataMessage.SetSecondsSinceLastMaintenance(secondsSinceLastMaintenance);
			ownHomeDataMessage.SetLogicClientHome(logicClientHome);
			ownHomeDataMessage.SetLogicClientAvatar(playerAvatar);
			ownHomeDataMessage.SetLayoutId(gameHomeState_0.LayoutId);
			ownHomeDataMessage.SetMapId(gameHomeState_0.MapId);
			ownHomeDataMessage.Encode();
			CompressibleStringHelper.Uncompress(logicClientHome.GetCompressibleHomeJSON());
			CompressibleStringHelper.Uncompress(logicClientHome.GetCompressibleCalendarJSON());
			CompressibleStringHelper.Uncompress(logicClientHome.GetCompressibleGlobalJSON());
			try
			{
				GClass6 gclass = new GClass6(gclass2_1);
				gclass.gclass7_0 = new GClass7(gclass, playerAvatar);
				gclass.gclass9_0 = new GClass9(gclass, logicClientHome);
				logicClientHome.SetChangeListener(gclass.gclass9_0);
				playerAvatar.SetChangeListener(gclass.gclass7_0);
				gclass.logicGameMode_0.LoadHomeState(logicClientHome, playerAvatar, num, -1, timestamp, secondsSinceLastMaintenance, reengagementSeconds);
				gclass2_1.SendPiranhaMessage(ownHomeDataMessage, 1);
				for (int i = 0; i < gameHomeState_0.ServerCommands.Size(); i++)
				{
					gclass.method_13(gameHomeState_0.ServerCommands[i]);
				}
				return gclass;
			}
			catch (Exception arg)
			{
				Logging.Error("GameMode.loadHomeState: exception while the loading of home state: " + arg);
			}
			return null;
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00003F78 File Offset: 0x00002178
		public static GClass6 smethod_1(GClass2 gclass2_1, GameNpcAttackState gameNpcAttackState_0)
		{
			LogicClientHome logicClientHome = GClass6.smethod_5(gameNpcAttackState_0.HomeId, gameNpcAttackState_0.HomeData, 0, 0, 0);
			LogicNpcAvatar npcAvatar = gameNpcAttackState_0.NpcAvatar;
			LogicClientAvatar playerAvatar = gameNpcAttackState_0.PlayerAvatar;
			int timestamp = TimeUtil.GetTimestamp();
			int secondsSinceLastSave = (gameNpcAttackState_0.SaveTime != -1) ? (timestamp - gameNpcAttackState_0.SaveTime) : 0;
			NpcDataMessage npcDataMessage = new NpcDataMessage();
			npcDataMessage.SetCurrentTimestamp(timestamp);
			npcDataMessage.SetLogicClientHome(logicClientHome);
			npcDataMessage.SetLogicClientAvatar(playerAvatar);
			npcDataMessage.SetLogicNpcAvatar(npcAvatar);
			npcDataMessage.SetSecondsSinceLastSave(secondsSinceLastSave);
			npcDataMessage.SetNpcDuel(false);
			npcDataMessage.Encode();
			CompressibleStringHelper.Uncompress(logicClientHome.GetCompressibleHomeJSON());
			CompressibleStringHelper.Uncompress(logicClientHome.GetCompressibleCalendarJSON());
			CompressibleStringHelper.Uncompress(logicClientHome.GetCompressibleGlobalJSON());
			try
			{
				GClass6 gclass = new GClass6(gclass2_1);
				gclass.gclass7_0 = new GClass7(gclass, playerAvatar);
				playerAvatar.SetChangeListener(gclass.gclass7_0);
				gclass.logicGameMode_0.LoadNpcAttackState(logicClientHome, npcAvatar, playerAvatar, timestamp, secondsSinceLastSave);
				gclass2_1.SendPiranhaMessage(npcDataMessage, 1);
				return gclass;
			}
			catch (Exception arg)
			{
				Logging.Error("GameMode.loadNpcAttackState: exception while the loading of attack state: " + arg);
			}
			return null;
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00004094 File Offset: 0x00002294
		public static GClass6 smethod_2(GClass2 gclass2_1, GameNpcDuelState gameNpcDuelState_0)
		{
			LogicClientHome logicClientHome = GClass6.smethod_5(gameNpcDuelState_0.HomeId, gameNpcDuelState_0.HomeData, 0, 0, LogicDataTables.GetGlobals().GetPersonalBreakLimitSeconds());
			LogicNpcAvatar npcAvatar = gameNpcDuelState_0.NpcAvatar;
			LogicClientAvatar playerAvatar = gameNpcDuelState_0.PlayerAvatar;
			int timestamp = TimeUtil.GetTimestamp();
			int secondsSinceLastSave = (gameNpcDuelState_0.SaveTime != -1) ? (timestamp - gameNpcDuelState_0.SaveTime) : 0;
			NpcDataMessage npcDataMessage = new NpcDataMessage();
			npcDataMessage.SetCurrentTimestamp(timestamp);
			npcDataMessage.SetLogicClientHome(logicClientHome);
			npcDataMessage.SetLogicClientAvatar(playerAvatar);
			npcDataMessage.SetLogicNpcAvatar(npcAvatar);
			npcDataMessage.SetSecondsSinceLastSave(secondsSinceLastSave);
			npcDataMessage.SetNpcDuel(true);
			npcDataMessage.Encode();
			CompressibleStringHelper.Uncompress(logicClientHome.GetCompressibleHomeJSON());
			CompressibleStringHelper.Uncompress(logicClientHome.GetCompressibleCalendarJSON());
			CompressibleStringHelper.Uncompress(logicClientHome.GetCompressibleGlobalJSON());
			try
			{
				GClass6 gclass = new GClass6(gclass2_1);
				gclass.gclass7_0 = new GClass7(gclass, playerAvatar);
				playerAvatar.SetChangeListener(gclass.gclass7_0);
				gclass.logicGameMode_0.LoadNpcDuelState(logicClientHome, npcAvatar, playerAvatar, timestamp, secondsSinceLastSave);
				gclass2_1.SendPiranhaMessage(npcDataMessage, 1);
				return gclass;
			}
			catch (Exception arg)
			{
				Logging.Error("GameMode.loadNpcDuelState: exception while the loading of attack state: " + arg);
			}
			return null;
		}

		// Token: 0x0600003F RID: 63 RVA: 0x000041B8 File Offset: 0x000023B8
		public static GClass6 smethod_3(GClass2 gclass2_1, GameMatchedAttackState gameMatchedAttackState_0)
		{
			LogicClientHome logicClientHome = GClass6.smethod_5(gameMatchedAttackState_0.HomeId, gameMatchedAttackState_0.HomeData, 0, 0, 0);
			LogicClientAvatar homeOwnerAvatar = gameMatchedAttackState_0.HomeOwnerAvatar;
			LogicClientAvatar playerAvatar = gameMatchedAttackState_0.PlayerAvatar;
			int timestamp = TimeUtil.GetTimestamp();
			int secondsSinceLastSave = (gameMatchedAttackState_0.SaveTime != -1) ? (timestamp - gameMatchedAttackState_0.SaveTime) : 0;
			int secondsSinceLastMaintenance = (gameMatchedAttackState_0.MaintenanceTime != -1) ? (timestamp - gameMatchedAttackState_0.MaintenanceTime) : 0;
			EnemyHomeDataMessage enemyHomeDataMessage = new EnemyHomeDataMessage();
			enemyHomeDataMessage.SetCurrentTimestamp(timestamp);
			enemyHomeDataMessage.SetSecondsSinceLastSave(secondsSinceLastSave);
			enemyHomeDataMessage.SetSecondsSinceLastMaintenance(secondsSinceLastMaintenance);
			enemyHomeDataMessage.SetLogicClientHome(logicClientHome);
			enemyHomeDataMessage.SetLogicClientAvatar(homeOwnerAvatar);
			enemyHomeDataMessage.SetAttackerLogicClientAvatar(playerAvatar);
			enemyHomeDataMessage.SetAttackSource(3);
			enemyHomeDataMessage.Encode();
			CompressibleStringHelper.Uncompress(logicClientHome.GetCompressibleHomeJSON());
			CompressibleStringHelper.Uncompress(logicClientHome.GetCompressibleCalendarJSON());
			CompressibleStringHelper.Uncompress(logicClientHome.GetCompressibleGlobalJSON());
			try
			{
				GClass6 gclass = new GClass6(gclass2_1);
				gclass.gclass7_0 = new GClass7(gclass, playerAvatar);
				playerAvatar.SetChangeListener(gclass.gclass7_0);
				if (gameMatchedAttackState_0.GameDefenderLocked)
				{
					gclass.gclass7_1 = new GClass7(gclass, homeOwnerAvatar);
					gclass.gclass9_0 = new GClass9(gclass, logicClientHome);
					gclass.bool_2 = true;
					homeOwnerAvatar.SetChangeListener(gclass.gclass7_1);
					logicClientHome.SetChangeListener(gclass.gclass9_0);
				}
				gclass.logicGameMode_0.LoadMatchedAttackState(logicClientHome, homeOwnerAvatar, playerAvatar, timestamp, secondsSinceLastSave, secondsSinceLastMaintenance);
				gclass.logicLong_0 = gameMatchedAttackState_0.LiveReplayId;
				byte[] streamData;
				ZLibHelper.CompressInZLibFormat(LogicStringUtil.GetBytes(LogicJSONParser.CreateJSONString(gclass.logicGameMode_0.GetReplay().GetJson(), 20)), out streamData);
				ServerMessageManager.SendMessage(new InitializeLiveReplayMessage
				{
					AccountId = gclass.logicLong_0,
					StreamData = streamData
				}, 9);
				gclass2_1.SendPiranhaMessage(enemyHomeDataMessage, 1);
				return gclass;
			}
			catch (Exception arg)
			{
				Logging.Error("GameMode.loadMatchedAttackState: exception while the loading of attack state: " + arg);
			}
			return null;
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00004390 File Offset: 0x00002590
		public static GClass6 smethod_4(GClass2 gclass2_1, GameVisitState gameVisitState_0)
		{
			LogicClientHome logicClientHome = GClass6.smethod_5(gameVisitState_0.HomeId, gameVisitState_0.HomeData, 0, 0, 0);
			LogicClientAvatar homeOwnerAvatar = gameVisitState_0.HomeOwnerAvatar;
			LogicClientAvatar playerAvatar = gameVisitState_0.PlayerAvatar;
			int timestamp = TimeUtil.GetTimestamp();
			int secondsSinceLastSave = (gameVisitState_0.SaveTime != -1) ? (timestamp - gameVisitState_0.SaveTime) : 0;
			int visitType = gameVisitState_0.VisitType;
			VisitedHomeDataMessage visitedHomeDataMessage = new VisitedHomeDataMessage();
			visitedHomeDataMessage.SetCurrentTimestamp(timestamp);
			visitedHomeDataMessage.SetSecondsSinceLastSave(secondsSinceLastSave);
			visitedHomeDataMessage.SetLogicClientHome(logicClientHome);
			visitedHomeDataMessage.SetOwnerLogicClientAvatar(homeOwnerAvatar);
			visitedHomeDataMessage.SetVisitorLogicClientAvatar(playerAvatar);
			visitedHomeDataMessage.Encode();
			CompressibleStringHelper.Uncompress(logicClientHome.GetCompressibleHomeJSON());
			CompressibleStringHelper.Uncompress(logicClientHome.GetCompressibleCalendarJSON());
			CompressibleStringHelper.Uncompress(logicClientHome.GetCompressibleGlobalJSON());
			try
			{
				GClass6 gclass = new GClass6(gclass2_1);
				gclass.gclass7_0 = new GClass7(gclass, playerAvatar);
				playerAvatar.SetChangeListener(gclass.gclass7_0);
				gclass.logicGameMode_0.LoadVisitState(logicClientHome, homeOwnerAvatar, playerAvatar, secondsSinceLastSave, visitType, timestamp);
				gclass2_1.SendPiranhaMessage(visitedHomeDataMessage, 1);
				return gclass;
			}
			catch (Exception arg)
			{
				Logging.Error("GameMode.loadVisitAttackState: exception while the loading of visit state: " + arg);
			}
			return null;
		}

		// Token: 0x06000041 RID: 65 RVA: 0x000044AC File Offset: 0x000026AC
		private static LogicClientHome smethod_5(LogicLong logicLong_1, byte[] byte_0, int int_0, int int_1, int int_2)
		{
			LogicClientHome logicClientHome = new LogicClientHome();
			logicClientHome.SetHomeId(logicLong_1);
			logicClientHome.SetShieldDurationSeconds(int_0);
			logicClientHome.SetGuardDurationSeconds(int_1);
			logicClientHome.SetPersonalBreakSeconds(int_2);
			logicClientHome.GetCompressibleHomeJSON().Set(byte_0);
			logicClientHome.GetCompressibleGlobalJSON().Set(ResourceManager.SERVER_SAVE_FILE_GLOBAL);
			logicClientHome.GetCompressibleCalendarJSON().Set(ResourceManager.SERVER_SAVE_FILE_CALENDAR);
			return logicClientHome;
		}

		// Token: 0x04000006 RID: 6
		public const long long_0 = 1000L;

		// Token: 0x04000007 RID: 7
		private readonly GClass2 gclass2_0;

		// Token: 0x04000008 RID: 8
		private readonly LogicGameMode logicGameMode_0;

		// Token: 0x04000009 RID: 9
		private readonly Stopwatch stopwatch_0;

		// Token: 0x0400000A RID: 10
		private readonly GClass10 gclass10_0;

		// Token: 0x0400000B RID: 11
		private readonly GClass8 gclass8_0;

		// Token: 0x0400000C RID: 12
		private bool bool_0;

		// Token: 0x0400000D RID: 13
		private bool bool_1;

		// Token: 0x0400000E RID: 14
		private bool bool_2;

		// Token: 0x0400000F RID: 15
		private LogicLong logicLong_0;

		// Token: 0x04000010 RID: 16
		private GClass9 gclass9_0;

		// Token: 0x04000011 RID: 17
		private GClass7 gclass7_0;

		// Token: 0x04000012 RID: 18
		private GClass7 gclass7_1;

		// Token: 0x0200000B RID: 11
		[CompilerGenerated]
		private sealed class Class1
		{
			// Token: 0x06000045 RID: 69 RVA: 0x000046F4 File Offset: 0x000028F4
			internal void method_0(ServerRequestArgs serverRequestArgs_0)
			{
				LogicLong replayId = null;
				if (serverRequestArgs_0.ErrorCode == ServerRequestError.Success && serverRequestArgs_0.ResponseMessage.Success)
				{
					replayId = ((CreateReplayStreamResponseMessage)serverRequestArgs_0.ResponseMessage).Id;
				}
				BattleReportStreamEntry battleReportStreamEntry = new BattleReportStreamEntry(AvatarStreamEntryType.ATTACKER_BATTLE_REPORT);
				battleReportStreamEntry.SetSenderAvatarId(this.logicClientAvatar_0.GetId());
				battleReportStreamEntry.SetSenderLevel(this.logicClientAvatar_0.GetExpLevel());
				battleReportStreamEntry.SetSenderLeagueType(this.logicClientAvatar_0.GetLeagueType());
				battleReportStreamEntry.SetSenderName(this.logicClientAvatar_0.GetName());
				battleReportStreamEntry.SetMajorVersion(9);
				battleReportStreamEntry.SetBuildVersion(256);
				battleReportStreamEntry.SetContentVersion(ResourceManager.GetContentVersion());
				battleReportStreamEntry.SetBattleLogJSON(this.string_0);
				battleReportStreamEntry.SetReplayId(replayId);
				ServerRequestArgs serverRequestArgs = ServerRequestManager.Create(new CreateAvatarStreamRequestMessage
				{
					OwnerId = this.logicClientAvatar_1.GetId(),
					Entry = battleReportStreamEntry
				}, ServerManager.GetDocumentSocket(11, this.logicClientAvatar_1.GetId()), 30);
				ServerRequestArgs.CompleteHandler onComplete;
				if ((onComplete = this.completeHandler_0) == null)
				{
					onComplete = (this.completeHandler_0 = new ServerRequestArgs.CompleteHandler(this.method_1));
				}
				serverRequestArgs.OnComplete = onComplete;
				if (this.gclass6_0.bool_2)
				{
					BattleReportStreamEntry battleReportStreamEntry2 = new BattleReportStreamEntry(AvatarStreamEntryType.DEFENDER_BATTLE_REPORT);
					battleReportStreamEntry2.SetSenderAvatarId(this.logicClientAvatar_1.GetId());
					battleReportStreamEntry2.SetSenderLevel(this.logicClientAvatar_1.GetExpLevel());
					battleReportStreamEntry2.SetSenderLeagueType(this.logicClientAvatar_1.GetLeagueType());
					battleReportStreamEntry2.SetSenderName(this.logicClientAvatar_1.GetName());
					battleReportStreamEntry2.SetMajorVersion(9);
					battleReportStreamEntry2.SetBuildVersion(256);
					battleReportStreamEntry2.SetContentVersion(ResourceManager.GetContentVersion());
					battleReportStreamEntry2.SetBattleLogJSON(this.string_1);
					battleReportStreamEntry2.SetReplayId(replayId);
					battleReportStreamEntry2.SetRevengeUsed(true);
					ServerRequestArgs serverRequestArgs2 = ServerRequestManager.Create(new CreateAvatarStreamRequestMessage
					{
						OwnerId = this.logicClientAvatar_0.GetId(),
						Entry = battleReportStreamEntry2
					}, ServerManager.GetDocumentSocket(11, this.logicClientAvatar_0.GetId()), 30);
					ServerRequestArgs.CompleteHandler onComplete2;
					if ((onComplete2 = this.completeHandler_1) == null)
					{
						onComplete2 = (this.completeHandler_1 = new ServerRequestArgs.CompleteHandler(this.method_2));
					}
					serverRequestArgs2.OnComplete = onComplete2;
				}
			}

			// Token: 0x06000046 RID: 70 RVA: 0x000048EC File Offset: 0x00002AEC
			internal void method_1(ServerRequestArgs serverRequestArgs_0)
			{
				if (serverRequestArgs_0.ErrorCode == ServerRequestError.Success && serverRequestArgs_0.ResponseMessage.Success)
				{
					ServerMessageManager.SendMessage(new CreateAvatarStreamMessage
					{
						AccountId = this.logicClientAvatar_1.GetId(),
						Entry = ((CreateAvatarStreamResponseMessage)serverRequestArgs_0.ResponseMessage).Entry
					}, 9);
				}
			}

			// Token: 0x06000047 RID: 71 RVA: 0x00004944 File Offset: 0x00002B44
			internal void method_2(ServerRequestArgs serverRequestArgs_0)
			{
				if (serverRequestArgs_0.ErrorCode == ServerRequestError.Success && serverRequestArgs_0.ResponseMessage.Success)
				{
					ServerMessageManager.SendMessage(new CreateAvatarStreamMessage
					{
						AccountId = this.logicClientAvatar_0.GetId(),
						Entry = ((CreateAvatarStreamResponseMessage)serverRequestArgs_0.ResponseMessage).Entry
					}, 9);
				}
			}

			// Token: 0x04000018 RID: 24
			public LogicClientAvatar logicClientAvatar_0;

			// Token: 0x04000019 RID: 25
			public string string_0;

			// Token: 0x0400001A RID: 26
			public LogicClientAvatar logicClientAvatar_1;

			// Token: 0x0400001B RID: 27
			public GClass6 gclass6_0;

			// Token: 0x0400001C RID: 28
			public string string_1;

			// Token: 0x0400001D RID: 29
			public ServerRequestArgs.CompleteHandler completeHandler_0;

			// Token: 0x0400001E RID: 30
			public ServerRequestArgs.CompleteHandler completeHandler_1;
		}
	}
}
