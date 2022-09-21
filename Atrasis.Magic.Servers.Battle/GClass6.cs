using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Battle;
using Atrasis.Magic.Logic.Command;
using Atrasis.Magic.Logic.Command.Battle;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Home;
using Atrasis.Magic.Logic.Message.Battle;
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
		// Token: 0x0600001B RID: 27 RVA: 0x000028A0 File Offset: 0x00000AA0
		private GClass6(GClass2 gclass2_1)
		{
			this.gclass2_0 = gclass2_1;
			this.stopwatch_0 = new Stopwatch();
			this.logicGameMode_0 = new LogicGameMode();
			this.gclass8_0 = new GClass8(this, this.logicGameMode_0);
			this.logicGameMode_0.GetCommandManager().SetListener(this.gclass8_0);
		}

		// Token: 0x0600001C RID: 28 RVA: 0x000028F8 File Offset: 0x00000AF8
		public void method_0()
		{
			GClass6.Struct0 @struct;
			@struct.gclass6_0 = this;
			@struct.asyncVoidMethodBuilder_0 = AsyncVoidMethodBuilder.Create();
			@struct.int_0 = -1;
			AsyncVoidMethodBuilder asyncVoidMethodBuilder_ = @struct.asyncVoidMethodBuilder_0;
			asyncVoidMethodBuilder_.Start<GClass6.Struct0>(ref @struct);
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002934 File Offset: 0x00000B34
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
							this.gclass8_0.method_0(int_0, logicArrayList_0);
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
								if (this.stopwatch_0.ElapsedMilliseconds >= 1000L && j != num2)
								{
									Logging.Error(string.Format("GameMode.onClientTurnReceived: logic update stopped because it took too long. ({0}ms for {1} updates)", this.stopwatch_0.ElapsedMilliseconds, j + 1));
									File.WriteAllText("logic-stopped-" + this.gclass2_0.AccountId + ".txt", this.ToString());
									IL_130:
									GClass10.smethod_7(this.stopwatch_0.ElapsedMilliseconds);
									this.stopwatch_0.Reset();
									goto IL_227;
								}
								j++;
							}
							goto IL_130;
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
						IL_227:
						this.method_4(int_1);
						if (this.gclass7_0 != null)
						{
							this.method_2();
						}
						if (this.logicLong_0 != null)
						{
							this.method_5(int_0, logicArrayList_0);
						}
						if (this.logicLong_3 != null)
						{
							this.method_7();
						}
						if (this.logicGameMode_0.IsBattleOver())
						{
							this.bool_0 = true;
						}
						if (this.bool_0)
						{
							this.gclass2_0.method_4();
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

		// Token: 0x0600001E RID: 30 RVA: 0x00002BF4 File Offset: 0x00000DF4
		private void method_2()
		{
			LogicClientAvatar playerAvatar = this.logicGameMode_0.GetLevel().GetPlayerAvatar();
			ServerMessageManager.SendMessage(new GameStateCallbackMessage
			{
				AccountId = playerAvatar.GetId(),
				SessionId = this.gclass2_0.Id,
				AvatarChanges = this.gclass7_0.method_0()
			}, 9);
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00002C4C File Offset: 0x00000E4C
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
				this.method_5(this.logicGameMode_0.GetLevel().GetLogicTime().GetTick(), null);
			}
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002EF8 File Offset: 0x000010F8
		private void method_4(int int_0)
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

		// Token: 0x06000021 RID: 33 RVA: 0x000021F5 File Offset: 0x000003F5
		private void method_5(int int_0, LogicArrayList<LogicCommand> logicArrayList_0)
		{
			ServerMessageManager.SendMessage(new ClientUpdateLiveReplayMessage
			{
				AccountId = this.logicLong_0,
				SubTick = int_0,
				Commands = logicArrayList_0
			}, 9);
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002F78 File Offset: 0x00001178
		private void method_6()
		{
			GClass6.Class1 @class = new GClass6.Class1();
			@class.gclass6_0 = this;
			@class.string_0 = LogicJSONParser.CreateJSONString(this.logicGameMode_0.GetLevel().GetBattleLog().GenerateAttackerJSON(), 20);
			ServerRequestManager.Create(new CreateReplayStreamRequestMessage
			{
				JSON = LogicJSONParser.CreateJSONString(this.logicGameMode_0.GetReplay().GetJson(), 1536)
			}, ServerManager.GetNextSocket(11), 30).OnComplete = new ServerRequestArgs.CompleteHandler(@class.method_0);
		}

		// Token: 0x06000023 RID: 35 RVA: 0x0000221D File Offset: 0x0000041D
		private void method_7()
		{
			ServerMessageManager.SendMessage(new DuelProgressMessage
			{
				AccountId = this.logicLong_3,
				AvatarId = this.method_13().GetId(),
				RemainingSeconds = this.logicGameMode_0.GetRemainingAttackSeconds()
			}, this.serverSocket_0);
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00002FF8 File Offset: 0x000011F8
		private void method_8()
		{
			GClass6.Class2 @class = new GClass6.Class2();
			@class.gclass6_0 = this;
			LogicBattleLog battleLog = this.logicGameMode_0.GetLevel().GetBattleLog();
			@class.string_0 = LogicJSONParser.CreateJSONString(battleLog.GenerateAttackerJSON(), 256);
			@class.int_0 = battleLog.GetDestructionPercentage();
			@class.int_1 = battleLog.GetStars();
			@class.logicLong_0 = this.method_13().GetId();
			ServerRequestManager.Create(new CreateReplayStreamRequestMessage
			{
				JSON = LogicJSONParser.CreateJSONString(this.logicGameMode_0.GetReplay().GetJson(), 1536)
			}, ServerManager.GetNextSocket(11), 10).OnComplete = new ServerRequestArgs.CompleteHandler(@class.method_0);
		}

		// Token: 0x06000025 RID: 37 RVA: 0x000030A8 File Offset: 0x000012A8
		public void method_9(int int_0, int int_1)
		{
			if (this.logicLong_3 != null)
			{
				ServerMessageManager.SendMessage(new DuelAttackEventMessage
				{
					AccountId = this.logicLong_3,
					AvatarId = this.method_13().GetId(),
					Type = int_0,
					Stars = int_1
				}, this.serverSocket_0);
			}
		}

		// Token: 0x06000026 RID: 38 RVA: 0x0000225D File Offset: 0x0000045D
		public void method_10()
		{
			this.bool_0 = true;
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00002266 File Offset: 0x00000466
		public GClass2 method_11()
		{
			return this.gclass2_0;
		}

		// Token: 0x06000028 RID: 40 RVA: 0x0000226E File Offset: 0x0000046E
		public LogicGameMode method_12()
		{
			return this.logicGameMode_0;
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00002276 File Offset: 0x00000476
		public LogicClientAvatar method_13()
		{
			return this.logicGameMode_0.GetLevel().GetPlayerAvatar();
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00002288 File Offset: 0x00000488
		public GClass7 method_14()
		{
			return this.gclass7_0;
		}

		// Token: 0x0600002B RID: 43 RVA: 0x000030F8 File Offset: 0x000012F8
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("account: " + this.gclass2_0.AccountId);
			stringBuilder.AppendLine("state: " + this.logicGameMode_0.GetState());
			stringBuilder.AppendLine("numGameObjects: " + this.logicGameMode_0.GetLevel().GetGameObjectManager().GetNumGameObjects());
			stringBuilder.AppendLine("numCharacterCount: " + this.logicGameMode_0.GetLevel().GetGameObjectManager().GetGameObjects(LogicGameObjectType.CHARACTER).Size());
			return stringBuilder.ToString();
		}

		// Token: 0x0600002C RID: 44 RVA: 0x000031A8 File Offset: 0x000013A8
		public static GClass6 smethod_0(GClass2 gclass2_1, GameFakeAttackState gameFakeAttackState_0)
		{
			LogicClientHome logicClientHome = GClass6.smethod_3(gameFakeAttackState_0.HomeId, gameFakeAttackState_0.HomeData, 0, 0, 0);
			LogicClientAvatar homeOwnerAvatar = gameFakeAttackState_0.HomeOwnerAvatar;
			LogicClientAvatar playerAvatar = gameFakeAttackState_0.PlayerAvatar;
			int timestamp = TimeUtil.GetTimestamp();
			int secondsSinceLastSave = (gameFakeAttackState_0.SaveTime != -1) ? (timestamp - gameFakeAttackState_0.SaveTime) : 0;
			int secondsSinceLastMaintenance = (gameFakeAttackState_0.MaintenanceTime != -1) ? (timestamp - gameFakeAttackState_0.MaintenanceTime) : 0;
			EnemyHomeDataMessage enemyHomeDataMessage = new EnemyHomeDataMessage();
			enemyHomeDataMessage.SetCurrentTimestamp(timestamp);
			enemyHomeDataMessage.SetSecondsSinceLastSave(secondsSinceLastSave);
			enemyHomeDataMessage.SetSecondsSinceLastMaintenance(secondsSinceLastMaintenance);
			enemyHomeDataMessage.SetLogicClientHome(logicClientHome);
			enemyHomeDataMessage.SetLogicClientAvatar(homeOwnerAvatar);
			enemyHomeDataMessage.SetAttackerLogicClientAvatar(playerAvatar);
			enemyHomeDataMessage.SetAttackSource(1);
			enemyHomeDataMessage.Encode();
			CompressibleStringHelper.Uncompress(logicClientHome.GetCompressibleHomeJSON());
			CompressibleStringHelper.Uncompress(logicClientHome.GetCompressibleCalendarJSON());
			CompressibleStringHelper.Uncompress(logicClientHome.GetCompressibleGlobalJSON());
			try
			{
				GClass6 gclass = new GClass6(gclass2_1);
				gclass.logicGameMode_0.LoadDirectAttackState(logicClientHome, homeOwnerAvatar, playerAvatar, secondsSinceLastSave, false, false, timestamp);
				gclass2_1.SendPiranhaMessage(enemyHomeDataMessage, 1);
				return gclass;
			}
			catch (Exception arg)
			{
				Logging.Error("GameMode.loadFakeAttackState: exception while the loading of attack state: " + arg);
			}
			return null;
		}

		// Token: 0x0600002D RID: 45 RVA: 0x000032C4 File Offset: 0x000014C4
		public static GClass6 smethod_1(GClass2 gclass2_1, GameChallengeAttackState gameChallengeAttackState_0)
		{
			LogicClientHome logicClientHome = GClass6.smethod_3(gameChallengeAttackState_0.HomeId, gameChallengeAttackState_0.HomeData, 0, 0, 0);
			LogicClientAvatar logicClientAvatar = GClass1.smethod_2(logicClientHome);
			LogicClientAvatar playerAvatar = gameChallengeAttackState_0.PlayerAvatar;
			int timestamp = TimeUtil.GetTimestamp();
			int secondsSinceLastSave = (gameChallengeAttackState_0.SaveTime != -1) ? (timestamp - gameChallengeAttackState_0.SaveTime) : 0;
			EnemyHomeDataMessage enemyHomeDataMessage = new EnemyHomeDataMessage();
			enemyHomeDataMessage.SetCurrentTimestamp(timestamp);
			enemyHomeDataMessage.SetSecondsSinceLastSave(secondsSinceLastSave);
			enemyHomeDataMessage.SetSecondsSinceLastMaintenance(0);
			enemyHomeDataMessage.SetLogicClientHome(logicClientHome);
			enemyHomeDataMessage.SetLogicClientAvatar(logicClientAvatar);
			enemyHomeDataMessage.SetAttackerLogicClientAvatar(playerAvatar);
			enemyHomeDataMessage.SetAttackSource(5);
			enemyHomeDataMessage.SetMapId(gameChallengeAttackState_0.MapId);
			enemyHomeDataMessage.Encode();
			CompressibleStringHelper.Uncompress(logicClientHome.GetCompressibleHomeJSON());
			CompressibleStringHelper.Uncompress(logicClientHome.GetCompressibleCalendarJSON());
			CompressibleStringHelper.Uncompress(logicClientHome.GetCompressibleGlobalJSON());
			try
			{
				GClass6 gclass = new GClass6(gclass2_1);
				gclass.logicGameMode_0.LoadDirectAttackState(logicClientHome, logicClientAvatar, playerAvatar, secondsSinceLastSave, gameChallengeAttackState_0.MapId == 1, false, timestamp);
				gclass.logicLong_2 = gameChallengeAttackState_0.AllianceId;
				gclass.logicLong_1 = gameChallengeAttackState_0.StreamId;
				gclass.logicLong_0 = gameChallengeAttackState_0.LiveReplayId;
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
				Logging.Error("GameMode.loadChallengeAttackState: exception while the loading of attack state: " + arg);
			}
			return null;
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00003450 File Offset: 0x00001650
		public static GClass6 smethod_2(GClass2 gclass2_1, GameDuelState gameDuelState_0)
		{
			LogicClientHome logicClientHome = GClass6.smethod_3(gameDuelState_0.HomeId, gameDuelState_0.HomeData, 0, 0, 0);
			LogicClientAvatar homeOwnerAvatar = GClass1.smethod_2(logicClientHome);
			LogicClientAvatar playerAvatar = gameDuelState_0.PlayerAvatar;
			int timestamp = TimeUtil.GetTimestamp();
			Village2AttackAvatarDataMessage village2AttackAvatarDataMessage = new Village2AttackAvatarDataMessage();
			village2AttackAvatarDataMessage.SetAvatarId(gameDuelState_0.AvatarId);
			village2AttackAvatarDataMessage.SetLogicClientAvatar(playerAvatar);
			village2AttackAvatarDataMessage.SetLogicClientHome(logicClientHome);
			village2AttackAvatarDataMessage.SetTimestamp(timestamp);
			village2AttackAvatarDataMessage.Encode();
			CompressibleStringHelper.Uncompress(logicClientHome.GetCompressibleHomeJSON());
			CompressibleStringHelper.Uncompress(logicClientHome.GetCompressibleCalendarJSON());
			CompressibleStringHelper.Uncompress(logicClientHome.GetCompressibleGlobalJSON());
			try
			{
				GClass6 gclass = new GClass6(gclass2_1);
				gclass.gclass7_0 = new GClass7(gclass, playerAvatar, true);
				playerAvatar.SetChangeListener(gclass.gclass7_0);
				gclass.logicGameMode_0.LoadDirectAttackState(logicClientHome, homeOwnerAvatar, playerAvatar, 0, false, true, timestamp);
				gclass.logicLong_0 = gameDuelState_0.LiveReplayId;
				gclass.logicLong_3 = gameDuelState_0.DuelEntryId;
				gclass.serverSocket_0 = ServerManager.GetDocumentSocket(9, gameDuelState_0.PlayerAvatar.GetId());
				byte[] streamData;
				ZLibHelper.CompressInZLibFormat(LogicStringUtil.GetBytes(LogicJSONParser.CreateJSONString(gclass.logicGameMode_0.GetReplay().GetJson(), 20)), out streamData);
				ServerMessageManager.SendMessage(new InitializeLiveReplayMessage
				{
					AccountId = gclass.logicLong_0,
					StreamData = streamData
				}, 9);
				gclass2_1.SendPiranhaMessage(village2AttackAvatarDataMessage, 1);
				return gclass;
			}
			catch (Exception arg)
			{
				Logging.Error("GameMode.loadDuelState: exception while the loading of attack state: " + arg);
			}
			return null;
		}

		// Token: 0x0600002F RID: 47 RVA: 0x000035C4 File Offset: 0x000017C4
		private static LogicClientHome smethod_3(LogicLong logicLong_4, byte[] byte_0, int int_0, int int_1, int int_2)
		{
			LogicClientHome logicClientHome = new LogicClientHome();
			logicClientHome.SetHomeId(logicLong_4);
			logicClientHome.SetShieldDurationSeconds(int_0);
			logicClientHome.SetGuardDurationSeconds(int_1);
			logicClientHome.SetPersonalBreakSeconds(int_2);
			logicClientHome.GetCompressibleHomeJSON().Set(byte_0);
			logicClientHome.GetCompressibleGlobalJSON().Set(ResourceManager.SERVER_SAVE_FILE_GLOBAL);
			logicClientHome.GetCompressibleCalendarJSON().Set(ResourceManager.SERVER_SAVE_FILE_CALENDAR);
			return logicClientHome;
		}

		// Token: 0x04000005 RID: 5
		public const long long_0 = 1000L;

		// Token: 0x04000006 RID: 6
		private readonly GClass2 gclass2_0;

		// Token: 0x04000007 RID: 7
		private readonly LogicGameMode logicGameMode_0;

		// Token: 0x04000008 RID: 8
		private readonly Stopwatch stopwatch_0;

		// Token: 0x04000009 RID: 9
		private readonly GClass8 gclass8_0;

		// Token: 0x0400000A RID: 10
		private bool bool_0;

		// Token: 0x0400000B RID: 11
		private bool bool_1;

		// Token: 0x0400000C RID: 12
		private LogicLong logicLong_0;

		// Token: 0x0400000D RID: 13
		private LogicLong logicLong_1;

		// Token: 0x0400000E RID: 14
		private LogicLong logicLong_2;

		// Token: 0x0400000F RID: 15
		private LogicLong logicLong_3;

		// Token: 0x04000010 RID: 16
		private ServerSocket serverSocket_0;

		// Token: 0x04000011 RID: 17
		private GClass7 gclass7_0;

		// Token: 0x0200000B RID: 11
		[CompilerGenerated]
		private sealed class Class1
		{
			// Token: 0x06000033 RID: 51 RVA: 0x00003768 File Offset: 0x00001968
			internal void method_0(ServerRequestArgs serverRequestArgs_0)
			{
				LogicLong replayId = null;
				if (serverRequestArgs_0.ErrorCode == ServerRequestError.Success && serverRequestArgs_0.ResponseMessage.Success)
				{
					replayId = ((CreateReplayStreamResponseMessage)serverRequestArgs_0.ResponseMessage).Id;
				}
				ServerMessageManager.SendMessage(new AllianceChallengeReportMessage
				{
					AccountId = this.gclass6_0.logicLong_2,
					StreamId = this.gclass6_0.logicLong_1,
					ReplayId = replayId,
					BattleLog = this.string_0
				}, 11);
			}

			// Token: 0x04000016 RID: 22
			public GClass6 gclass6_0;

			// Token: 0x04000017 RID: 23
			public string string_0;
		}

		// Token: 0x0200000C RID: 12
		[CompilerGenerated]
		private sealed class Class2
		{
			// Token: 0x06000035 RID: 53 RVA: 0x000037E0 File Offset: 0x000019E0
			internal void method_0(ServerRequestArgs serverRequestArgs_0)
			{
				LogicLong replayId = null;
				if (serverRequestArgs_0.ErrorCode == ServerRequestError.Success && serverRequestArgs_0.ResponseMessage.Success)
				{
					replayId = ((CreateReplayStreamResponseMessage)serverRequestArgs_0.ResponseMessage).Id;
				}
				ServerMessageManager.SendMessage(new DuelResultMessage
				{
					AccountId = this.gclass6_0.logicLong_3,
					ReplayId = replayId,
					AvatarId = this.logicLong_0,
					BattleLog = this.string_0,
					DestructionPercentage = this.int_0,
					Stars = this.int_1
				}, this.gclass6_0.serverSocket_0);
			}

			// Token: 0x04000018 RID: 24
			public GClass6 gclass6_0;

			// Token: 0x04000019 RID: 25
			public LogicLong logicLong_0;

			// Token: 0x0400001A RID: 26
			public string string_0;

			// Token: 0x0400001B RID: 27
			public int int_0;

			// Token: 0x0400001C RID: 28
			public int int_1;
		}
	}
}
