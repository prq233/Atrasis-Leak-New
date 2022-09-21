using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Battle;
using Atrasis.Magic.Logic.Calendar;
using Atrasis.Magic.Logic.Command;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Home;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Time;
using Atrasis.Magic.Logic.Util;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Mode
{
	// Token: 0x02000025 RID: 37
	public class LogicGameMode
	{
		// Token: 0x0600018B RID: 395 RVA: 0x00017A18 File Offset: 0x00015C18
		public LogicGameMode()
		{
			this.logicLevel_0 = new LogicLevel(this);
			this.logicCommandManager_0 = new LogicCommandManager(this.logicLevel_0);
			this.logicCalendar_0 = new LogicCalendar();
			this.logicConfiguration_0 = new LogicConfiguration();
			this.int_2 = -1;
		}

		// Token: 0x0600018C RID: 396 RVA: 0x00017A68 File Offset: 0x00015C68
		public void Destruct()
		{
			this.logicLevel_0.Destruct();
			this.logicCommandManager_0.Destruct();
			this.logicCalendar_0.Destruct();
			if (this.logicTimer_0 != null)
			{
				this.logicTimer_0.Destruct();
				this.logicTimer_0 = null;
			}
			if (this.logicReplay_0 != null)
			{
				this.logicReplay_0.Destruct();
				this.logicReplay_0 = null;
			}
		}

		// Token: 0x0600018D RID: 397 RVA: 0x00017ACC File Offset: 0x00015CCC
		public ChecksumHelper CalculateChecksum(LogicJSONObject root, bool includeGameObjects)
		{
			ChecksumHelper checksumHelper = new ChecksumHelper(root);
			checksumHelper.StartObject("LogicGameMode");
			checksumHelper.WriteValue("subtick", this.logicLevel_0.GetLogicTime().GetTick());
			checksumHelper.WriteValue("m_currentTimestamp", this.int_2);
			if (this.logicLevel_0.GetHomeOwnerAvatar() != null)
			{
				checksumHelper.StartObject("homeOwner");
				this.logicLevel_0.GetHomeOwnerAvatar().GetChecksum(checksumHelper);
				checksumHelper.EndObject();
			}
			if (this.logicLevel_0.GetVisitorAvatar() != null)
			{
				checksumHelper.StartObject("visitor");
				this.logicLevel_0.GetVisitorAvatar().GetChecksum(checksumHelper);
				checksumHelper.EndObject();
			}
			this.logicLevel_0.GetGameObjectManager().GetChecksum(checksumHelper, includeGameObjects);
			if (this.logicCalendar_0 != null)
			{
				checksumHelper.StartObject("calendar");
				this.logicCalendar_0.GetChecksum(checksumHelper);
				checksumHelper.EndObject();
			}
			checksumHelper.WriteValue("checksum", checksumHelper.GetChecksum());
			checksumHelper.EndObject();
			return checksumHelper;
		}

		// Token: 0x0600018E RID: 398 RVA: 0x00002FC1 File Offset: 0x000011C1
		public LogicCommandManager GetCommandManager()
		{
			return this.logicCommandManager_0;
		}

		// Token: 0x0600018F RID: 399 RVA: 0x00002FC9 File Offset: 0x000011C9
		public LogicLevel GetLevel()
		{
			return this.logicLevel_0;
		}

		// Token: 0x06000190 RID: 400 RVA: 0x00002FD1 File Offset: 0x000011D1
		public LogicConfiguration GetConfiguration()
		{
			return this.logicConfiguration_0;
		}

		// Token: 0x06000191 RID: 401 RVA: 0x00002FD9 File Offset: 0x000011D9
		public LogicCalendar GetCalendar()
		{
			return this.logicCalendar_0;
		}

		// Token: 0x06000192 RID: 402 RVA: 0x00002FE1 File Offset: 0x000011E1
		public LogicReplay GetReplay()
		{
			return this.logicReplay_0;
		}

		// Token: 0x06000193 RID: 403 RVA: 0x00002FE9 File Offset: 0x000011E9
		public int GetServerTimeInSecondsSince1970()
		{
			return 16 * this.logicLevel_0.GetLogicTime().GetTick() / 1000 + this.int_2 + this.int_3;
		}

		// Token: 0x06000194 RID: 404 RVA: 0x00003012 File Offset: 0x00001212
		public int GetStartTime()
		{
			return this.int_2;
		}

		// Token: 0x06000195 RID: 405 RVA: 0x0000301A File Offset: 0x0000121A
		public int GetDebugFastForwardSecs()
		{
			return this.int_3;
		}

		// Token: 0x06000196 RID: 406 RVA: 0x00003022 File Offset: 0x00001222
		public void SetDebugFastForwardSecs(int secs)
		{
			this.int_3 = secs;
		}

		// Token: 0x06000197 RID: 407 RVA: 0x0000302B File Offset: 0x0000122B
		public int GetSecondsSinceLastMaintenance()
		{
			return this.int_8;
		}

		// Token: 0x06000198 RID: 408 RVA: 0x00003033 File Offset: 0x00001233
		public int GetVisitType()
		{
			if (this.int_0 == 4)
			{
				return this.int_1;
			}
			return -1;
		}

		// Token: 0x06000199 RID: 409 RVA: 0x00003046 File Offset: 0x00001246
		public int GetVillageType()
		{
			if (this.int_0 == 1)
			{
				return this.int_12;
			}
			return -1;
		}

		// Token: 0x0600019A RID: 410 RVA: 0x00017BC4 File Offset: 0x00015DC4
		public void SetBattleOver()
		{
			if (this.bool_0)
			{
				return;
			}
			this.logicLevel_0.GetBattleLog().SetBattleEnded(LogicDataTables.GetGlobals().GetAttackLengthSecs() - this.GetRemainingAttackSeconds());
			this.logicLevel_0.GetMissionManager().Tick();
			LogicArrayList<LogicComponent> components = this.logicLevel_0.GetComponentManager().GetComponents(LogicComponentType.COMBAT);
			for (int i = 0; i < components.Size(); i++)
			{
				((LogicCombatComponent)components[i]).Boost(0, 0, 0);
			}
			bool flag;
			if (flag = (((long)this.logicLevel_0.GetMatchType() & 4294967294L) == 8L))
			{
				LogicAvatar visitorAvatar = this.logicLevel_0.GetVisitorAvatar();
				if (visitorAvatar != null && visitorAvatar.IsClientAvatar())
				{
					((LogicClientAvatar)visitorAvatar).RemoveUnitsVillage2();
				}
			}
			if (this.int_0 == 3)
			{
				this.EndDefendState();
			}
			else
			{
				LogicBattleLog battleLog = this.logicLevel_0.GetBattleLog();
				if (battleLog.GetBattleStarted())
				{
					LogicAvatar visitorAvatar2 = this.logicLevel_0.GetVisitorAvatar();
					LogicAvatar homeOwnerAvatar = this.logicLevel_0.GetHomeOwnerAvatar();
					int stars = battleLog.GetStars();
					if (this.logicLevel_0.GetVisitorAvatar().IsClientAvatar() && this.logicLevel_0.GetHomeOwnerAvatar().IsClientAvatar())
					{
						LogicClientAvatar logicClientAvatar = (LogicClientAvatar)visitorAvatar2;
						LogicClientAvatar logicClientAvatar2 = (LogicClientAvatar)homeOwnerAvatar;
						int score = logicClientAvatar.GetScore();
						int score2 = logicClientAvatar2.GetScore();
						int matchType = this.logicLevel_0.GetMatchType();
						if (matchType == 1 || (!LogicDataTables.GetGlobals().ScoringOnlyFromMatchedMode() && (matchType == 0 || matchType == 2 || matchType == 4 || matchType == 6)))
						{
							LogicGamePlayUtil.CalculateCombatScore(logicClientAvatar, logicClientAvatar2, stars, false, matchType == 4, battleLog.GetDestructionPercentage(), this.logicCalendar_0.GetStarBonusMultiplier(), flag);
							if (!flag && homeOwnerAvatar.GetTownHallLevel() >= LogicDataTables.GetGlobals().GetLootCartEnabledTownHall())
							{
								LogicDataTable table = LogicDataTables.GetTable(LogicDataType.RESOURCE);
								if (table.GetItemCount() > 0)
								{
									bool flag2 = false;
									for (int j = 0; j < table.GetItemCount(); j++)
									{
										LogicResourceData logicResourceData = (LogicResourceData)table.GetItemAt(j);
										if (!logicResourceData.IsPremiumCurrency() && battleLog.GetStolenResources(logicResourceData) > 0)
										{
											flag2 = true;
										}
									}
									if (flag2)
									{
										LogicGameObjectManager gameObjectManagerAt = this.logicLevel_0.GetGameObjectManagerAt(0);
										LogicObstacle lootCart = gameObjectManagerAt.GetLootCart();
										if (lootCart == null)
										{
											gameObjectManagerAt.AddLootCart();
											lootCart = gameObjectManagerAt.GetLootCart();
										}
										if (lootCart != null)
										{
											LogicLootCartComponent lootCartComponent = lootCart.GetLootCartComponent();
											if (lootCartComponent != null)
											{
												for (int k = 0; k < table.GetItemCount(); k++)
												{
													LogicResourceData logicResourceData2 = (LogicResourceData)table.GetItemAt(k);
													if (!logicResourceData2.IsPremiumCurrency() && logicResourceData2.GetWarResourceReferenceData() == null)
													{
														int lootDefensePercentage = lootCart.GetObstacleData().GetLootDefensePercentage();
														int valueA = battleLog.GetStolenResources(logicResourceData2) * lootDefensePercentage / 100;
														lootCartComponent.SetResourceCount(k, LogicMath.Min(LogicMath.Max(valueA, lootCartComponent.GetResourceCount(k)), lootCartComponent.GetCapacityCount(k)));
													}
												}
											}
										}
									}
								}
							}
							this.logicLevel_0.UpdateBattleShieldStatus(false);
							if (stars > 0)
							{
								LogicArrayList<LogicDataSlot> castedUnits = battleLog.GetCastedUnits();
								LogicArrayList<LogicDataSlot> castedSpells = battleLog.GetCastedSpells();
								LogicArrayList<LogicUnitSlot> castedAllianceUnits = battleLog.GetCastedAllianceUnits();
								LogicArrayList<LogicDataSlot> logicArrayList = new LogicArrayList<LogicDataSlot>(castedUnits.Size());
								for (int l = 0; l < castedUnits.Size(); l++)
								{
									logicArrayList.Add(new LogicDataSlot(castedUnits[l].GetData(), castedUnits[l].GetCount()));
								}
								int m = 0;
								IL_409:
								while (m < castedSpells.Size())
								{
									int num = -1;
									for (int n = 0; n < logicArrayList.Size(); n++)
									{
										if (logicArrayList[n].GetData() == castedSpells[m].GetData())
										{
											num = n;
											IL_3A9:
											if (num != -1)
											{
												logicArrayList[num].SetCount(logicArrayList[num].GetCount() + castedSpells[m].GetCount());
											}
											else
											{
												logicArrayList.Add(new LogicDataSlot(castedSpells[m].GetData(), castedSpells[m].GetCount()));
											}
											m++;
											goto IL_409;
										}
									}
									goto IL_3A9;
								}
								for (int num2 = 0; num2 < castedAllianceUnits.Size(); num2++)
								{
									logicArrayList.Add(new LogicDataSlot(castedAllianceUnits[num2].GetData(), castedAllianceUnits[num2].GetCount()));
								}
								for (int num3 = 0; num3 < logicArrayList.Size(); num3++)
								{
									LogicCombatItemData data = (LogicCombatItemData)logicArrayList[num3].GetData();
									LogicCalendarUseTroop useTroopEvents = this.logicCalendar_0.GetUseTroopEvents(data);
									if (useTroopEvents != null)
									{
										int eventUnitCounterCount = logicClientAvatar.GetEventUnitCounterCount(data);
										if (logicArrayList[num3].GetCount() >= eventUnitCounterCount >> 16)
										{
											int num4 = (int)((short)eventUnitCounterCount + 1);
											int count = num4 | (int)((long)eventUnitCounterCount & 4294901760L);
											logicClientAvatar.SetCommodityCount(6, data, count);
											logicClientAvatar.GetChangeListener().CommodityCountChanged(6, data, count);
											if (useTroopEvents.GetParameter(0) == num4)
											{
												int parameter = useTroopEvents.GetParameter(2);
												int parameter2 = useTroopEvents.GetParameter(3);
												logicClientAvatar.XpGainHelper(parameter2);
												logicClientAvatar.SetDiamonds(logicClientAvatar.GetDiamonds() + parameter);
												logicClientAvatar.SetFreeDiamonds(logicClientAvatar.GetFreeDiamonds() + parameter);
												logicClientAvatar.GetChangeListener().FreeDiamondsAdded(parameter, 9);
											}
										}
									}
								}
								for (int num5 = 0; num5 < logicArrayList.Size(); num5++)
								{
									logicArrayList[num5].Destruct();
								}
								logicArrayList.Destruct();
							}
						}
						if (this.int_0 != 5 && this.logicLevel_0.GetDefenseShieldActivatedHours() == 0 && battleLog.GetDestructionPercentage() > 0)
						{
							int num6 = logicClientAvatar2.GetDefenseVillageGuardCounter() + 1;
							logicClientAvatar2.SetDefenseVillageGuardCounter(num6);
							logicClientAvatar2.GetChangeListener().DefenseVillageGuardCounterChanged(num6);
							int num7 = ((num6 & 16777215) == 3 * ((num6 & 16777215) / 3)) ? logicClientAvatar2.GetLeagueTypeData().GetVillageGuardInMins() : LogicDataTables.GetGlobals().GetDefaultDefenseVillageGuard();
							this.logicLevel_0.GetHome().GetChangeListener().GuardActivated(60 * num7);
						}
						battleLog.SetAttackerScore(logicClientAvatar.GetScore() - score);
						battleLog.SetDefenderScore(logicClientAvatar2.GetScore() - score2);
						battleLog.SetOriginalAttackerScore(score);
						battleLog.SetOriginalDefenderScore(score2);
						if (this.int_0 != 5)
						{
							if (stars != 0)
							{
								if (matchType != 3 && matchType != 7 && matchType != 8 && matchType != 9)
								{
									if (matchType == 5)
									{
										if (stars > this.logicLevel_0.GetPreviousAttackStars() && !this.logicLevel_0.GetIgnoreAttack())
										{
											this.logicLevel_0.GetAchievementManager().IncreaseWarStars(stars);
										}
									}
									else
									{
										this.logicLevel_0.GetAchievementManager().PvpAttackWon();
									}
								}
							}
							else if (matchType > 9 || matchType == 3 || matchType == 5 || matchType == 7 || matchType == 8 || matchType == 9)
							{
								this.logicLevel_0.GetAchievementManager().PvpDefenseWon();
							}
						}
					}
					else if (visitorAvatar2.IsClientAvatar() && homeOwnerAvatar.IsNpcAvatar())
					{
						LogicNpcData npcData = ((LogicNpcAvatar)homeOwnerAvatar).GetNpcData();
						int npcStars = visitorAvatar2.GetNpcStars(npcData);
						if (stars > npcStars && npcData.IsSinglePlayer())
						{
							visitorAvatar2.SetNpcStars(npcData, stars);
							visitorAvatar2.GetChangeListener().CommodityCountChanged(0, npcData, stars);
						}
					}
				}
			}
			this.bool_0 = true;
		}

		// Token: 0x0600019B RID: 411 RVA: 0x00003059 File Offset: 0x00001259
		public int GetState()
		{
			return this.int_0;
		}

		// Token: 0x0600019C RID: 412 RVA: 0x00003061 File Offset: 0x00001261
		public int GetShieldRemainingSeconds()
		{
			return LogicMath.Max(LogicTime.GetTicksInSeconds(this.int_4 - this.logicLevel_0.GetLogicTime().GetTick()), 0);
		}

		// Token: 0x0600019D RID: 413 RVA: 0x00018324 File Offset: 0x00016524
		public void SetShieldRemainingSeconds(int secs)
		{
			this.int_4 = LogicTime.GetSecondsInTicks(secs) + this.logicLevel_0.GetLogicTime().GetTick();
			int tick = this.logicLevel_0.GetLogicTime().GetTick();
			int num = this.int_4;
			if (this.int_4 < tick)
			{
				num = tick;
			}
			this.int_7 = num;
		}

		// Token: 0x0600019E RID: 414 RVA: 0x00018378 File Offset: 0x00016578
		public int GetGuardRemainingSeconds()
		{
			int num = this.int_7 - this.logicLevel_0.GetLogicTime().GetTick();
			if (num > 0)
			{
				num = 0;
			}
			return LogicMath.Max(LogicTime.GetTicksInSeconds(this.int_5 + num), 0);
		}

		// Token: 0x0600019F RID: 415 RVA: 0x000183B8 File Offset: 0x000165B8
		public void SetGuardRemainingSeconds(int secs)
		{
			this.int_5 = LogicTime.GetSecondsInTicks(secs);
			int tick = this.logicLevel_0.GetLogicTime().GetTick();
			int num = tick;
			if (this.int_4 >= tick)
			{
				num = this.int_4;
			}
			this.int_7 = num;
		}

		// Token: 0x060001A0 RID: 416 RVA: 0x00003085 File Offset: 0x00001285
		public int GetPersonalBreakCooldownSeconds()
		{
			return LogicMath.Max(LogicTime.GetTicksInSeconds(this.int_6 - this.logicLevel_0.GetLogicTime().GetTick()), 0);
		}

		// Token: 0x060001A1 RID: 417 RVA: 0x000030A9 File Offset: 0x000012A9
		public void SetPersonalBreakCooldownSeconds(int secs)
		{
			this.int_6 = LogicTime.GetSecondsInTicks(secs) + this.logicLevel_0.GetLogicTime().GetTick();
		}

		// Token: 0x060001A2 RID: 418 RVA: 0x000030C8 File Offset: 0x000012C8
		public void SaveToJSON(LogicJSONObject jsonObject)
		{
			this.logicLevel_0.SaveToJSON(jsonObject);
		}

		// Token: 0x060001A3 RID: 419 RVA: 0x000183FC File Offset: 0x000165FC
		public void SubTick()
		{
			if (this.int_0 == 1)
			{
				this.logicCalendar_0.Update(this.GetServerTimeInSecondsSince1970(), this.logicLevel_0.GetHomeOwnerAvatar(), this.logicLevel_0);
			}
			this.logicCommandManager_0.SubTick();
			this.logicLevel_0.SubTick();
			if (this.logicReplay_0 != null)
			{
				this.logicReplay_0.SubTick();
			}
		}

		// Token: 0x060001A4 RID: 420 RVA: 0x000030D6 File Offset: 0x000012D6
		public void Tick()
		{
			if (this.bool_1)
			{
				this.int_10 = this.int_11 - this.logicLevel_0.GetLogicTime().GetTick();
			}
			this.logicLevel_0.Tick();
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x00018460 File Offset: 0x00016660
		public void UpdateOneSubTick()
		{
			LogicTime logicTime = this.logicLevel_0.GetLogicTime();
			if (this.int_0 != 2 || !this.bool_0)
			{
				this.SubTick();
				if (logicTime.IsFullTick())
				{
					this.Tick();
				}
			}
			if (this.logicLevel_0.IsInCombatState() && ((this.logicTimer_0 != null && this.logicTimer_0.GetRemainingSeconds(logicTime) == 0) || this.logicLevel_0.GetBattleEndPending()))
			{
				this.SetBattleOver();
			}
			logicTime.IncreaseTick();
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x00003108 File Offset: 0x00001308
		public void StartDefendState(LogicAvatar avatar)
		{
			if (this.int_0 != 1)
			{
				if (this.int_0 != 3)
				{
					Debugger.Error("startDefendState called from invalid state");
					return;
				}
			}
			this.int_0 = 3;
			this.bool_0 = false;
			this.logicLevel_0.DefenseStateStarted(avatar);
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x00003143 File Offset: 0x00001343
		public void EndDefendState()
		{
			if (this.int_0 == 3)
			{
				this.int_0 = 1;
				this.logicLevel_0.DefenseStateEnded();
				return;
			}
			Debugger.Error("endDefendState called from invalid state");
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x000184DC File Offset: 0x000166DC
		public void EndAttackPreparation()
		{
			if (this.logicTimer_0 != null)
			{
				int attackLengthSecs = LogicDataTables.GetGlobals().GetAttackLengthSecs();
				int remainingSeconds = this.logicTimer_0.GetRemainingSeconds(this.logicLevel_0.GetLogicTime());
				if (remainingSeconds > attackLengthSecs)
				{
					int secs = remainingSeconds - attackLengthSecs;
					if (this.logicReplay_0 != null)
					{
						this.logicReplay_0.RecordPreparationSkipTime(secs);
					}
					this.int_9 = secs;
					this.logicTimer_0.StartTimer(attackLengthSecs, this.logicLevel_0.GetLogicTime(), false, -1);
				}
				if (this.logicLevel_0.GetPlayerAvatar() != null)
				{
					LogicClientAvatar playerAvatar = this.logicLevel_0.GetPlayerAvatar();
					if (playerAvatar.GetChangeListener() != null)
					{
						playerAvatar.GetChangeListener().BattleFeedback(5, 0);
					}
				}
			}
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x0000316B File Offset: 0x0000136B
		public bool IsInAttackPreparationMode()
		{
			return (this.int_0 == 2 || this.int_0 == 5) && this.logicLevel_0.GetHomeOwnerAvatar().IsClientAvatar() && this.GetRemainingAttackSeconds() > LogicDataTables.GetGlobals().GetAttackLengthSecs();
		}

		// Token: 0x060001AA RID: 426 RVA: 0x000031A5 File Offset: 0x000013A5
		public bool IsBattleOver()
		{
			return this.bool_0;
		}

		// Token: 0x060001AB RID: 427 RVA: 0x00018580 File Offset: 0x00016780
		public int GetRemainingAttackSeconds()
		{
			if ((this.int_0 != 2 && this.int_0 != 5) || this.bool_0)
			{
				return 0;
			}
			if (!this.logicLevel_0.GetInvulnerabilityEnabled() && this.logicTimer_0 != null)
			{
				return LogicMath.Max(this.logicTimer_0.GetRemainingSeconds(this.logicLevel_0.GetLogicTime()), 1);
			}
			return 1;
		}

		// Token: 0x060001AC RID: 428 RVA: 0x000185DC File Offset: 0x000167DC
		public void LoadHomeState(LogicClientHome home, LogicAvatar homeOwnerAvatar, int secondsSinceLastSave, int villageType, int currentTimestamp, int secondsSinceLastMaintenance, int reengagementSeconds)
		{
			if (villageType == 2)
			{
				this.logicLevel_0.SetVillageType(villageType);
			}
			if (home != null)
			{
				this.int_0 = 1;
				this.int_12 = villageType;
				if (LogicDataTables.GetGlobals().StartInLastUsedVillage())
				{
					int num = homeOwnerAvatar.GetVillageToGoTo();
					if (!this.logicLevel_0.GetMissionManager().HasTravel(homeOwnerAvatar))
					{
						num = 0;
					}
					if (num < 0)
					{
						Debugger.Warning("VillageToGoTo<0");
					}
					else if (num > 1)
					{
						Debugger.Warning("VillageToGoTo too big");
					}
					else
					{
						this.logicLevel_0.SetVillageType(num);
					}
				}
				this.int_8 = secondsSinceLastMaintenance;
				this.int_2 = currentTimestamp;
				this.logicConfiguration_0.Load(LogicJSONParser.ParseObject(home.GetGlobalJSON()));
				this.logicCalendar_0.Load(home.GetCalendarJSON(), currentTimestamp);
				if (this.logicTimer_0 != null)
				{
					this.logicTimer_0.Destruct();
					this.logicTimer_0 = null;
				}
				this.logicLevel_0.SetHome(home, false);
				this.logicLevel_0.SetHomeOwnerAvatar(homeOwnerAvatar);
				this.logicLevel_0.FastForwardTime(secondsSinceLastSave);
				homeOwnerAvatar.SetLevel(this.logicLevel_0);
				this.logicLevel_0.ReengageLootCart(reengagementSeconds);
				this.logicLevel_0.LoadingFinished();
				this.int_4 = LogicTime.GetSecondsInTicks(home.GetShieldDurationSeconds());
				this.int_5 = LogicTime.GetSecondsInTicks(home.GetGuardDurationSeconds());
				this.int_6 = LogicTime.GetSecondsInTicks(home.GetPersonalBreakSeconds());
				int tick = this.logicLevel_0.GetLogicTime().GetTick();
				int num2 = tick;
				if (this.int_4 >= tick)
				{
					num2 = this.int_4;
				}
				this.int_7 = num2;
				if (LogicDataTables.GetGlobals().UseVillageObjects())
				{
					this.logicLevel_0.LoadVillageObjects();
				}
			}
		}

		// Token: 0x060001AD RID: 429 RVA: 0x00018774 File Offset: 0x00016974
		public void LoadNpcAttackState(LogicClientHome home, LogicAvatar homeOwnerAvatar, LogicAvatar visitorAvatar, int currentTimestamp, int secondsSinceLastSave)
		{
			if (this.int_0 == 1)
			{
				Debugger.Error("loadAttackState called from invalid state");
				return;
			}
			this.int_0 = 2;
			this.int_2 = currentTimestamp;
			this.logicCalendar_0.Load(home.GetCalendarJSON(), currentTimestamp);
			if (this.logicTimer_0 != null)
			{
				this.logicTimer_0.Destruct();
				this.logicTimer_0 = null;
			}
			if (homeOwnerAvatar.IsNpcAvatar())
			{
				LogicNpcData npcData = ((LogicNpcAvatar)homeOwnerAvatar).GetNpcData();
				homeOwnerAvatar.SetResourceCount(LogicDataTables.GetGoldData(), LogicMath.Max(npcData.GetGoldCount() - visitorAvatar.GetLootedNpcGold(npcData), 0));
				homeOwnerAvatar.SetResourceCount(LogicDataTables.GetElixirData(), LogicMath.Max(npcData.GetElixirCount() - visitorAvatar.GetLootedNpcElixir(npcData), 0));
				this.logicLevel_0.SetMatchType(2, 0L);
				this.logicLevel_0.SetHome(home, false);
				this.logicLevel_0.SetHomeOwnerAvatar(homeOwnerAvatar);
				this.logicLevel_0.SetVisitorAvatar(visitorAvatar);
				this.logicLevel_0.FastForwardTime(secondsSinceLastSave);
				this.logicLevel_0.LoadingFinished();
				return;
			}
			Debugger.Error("loadNpcAttackState called and home owner is not npc avatar");
		}

		// Token: 0x060001AE RID: 430 RVA: 0x00018888 File Offset: 0x00016A88
		public void LoadNpcDuelState(LogicClientHome home, LogicAvatar homeOwnerAvatar, LogicAvatar visitorAvatar, int currentTimestamp, int secondsSinceLastSave)
		{
			if (this.int_0 != 0)
			{
				Debugger.Error("loadNpcDuelState called from invalid state");
				return;
			}
			this.int_0 = 2;
			this.int_2 = currentTimestamp;
			this.logicConfiguration_0.Load((LogicJSONObject)LogicJSONParser.Parse(home.GetGlobalJSON()));
			this.logicCalendar_0.Load(home.GetCalendarJSON(), currentTimestamp);
			if (this.logicTimer_0 != null)
			{
				this.logicTimer_0.Destruct();
				this.logicTimer_0 = null;
			}
			this.logicLevel_0.SetMatchType(9, null);
			this.logicLevel_0.SetVillageType(1);
			this.logicLevel_0.SetHome(home, false);
			this.logicLevel_0.SetHomeOwnerAvatar(homeOwnerAvatar);
			homeOwnerAvatar.SetHeroDefenseState();
			this.logicLevel_0.SetVisitorAvatar(visitorAvatar);
			this.logicLevel_0.FastForwardTime(secondsSinceLastSave);
			this.logicLevel_0.LoadingFinished();
			this.logicReplay_0 = new LogicReplay(this.logicLevel_0);
		}

		// Token: 0x060001AF RID: 431 RVA: 0x00018970 File Offset: 0x00016B70
		public void LoadVisitState(LogicClientHome home, LogicAvatar homeOwnerAvatar, LogicAvatar visitorAvatar, int secondsSinceLastSave, int visitType, int currentTimestamp)
		{
			if (this.int_0 != 0)
			{
				Debugger.Error("loadVisitState called from invalid state");
				return;
			}
			this.int_0 = 4;
			this.int_2 = currentTimestamp;
			this.logicConfiguration_0.Load((LogicJSONObject)LogicJSONParser.Parse(home.GetGlobalJSON()));
			this.logicCalendar_0.Load(home.GetCalendarJSON(), currentTimestamp);
			this.int_1 = visitType;
			if (visitType != 0 && ((visitType | 1) == 5 || visitType == 6))
			{
				this.logicLevel_0.SetVillageType(1);
			}
			this.logicLevel_0.SetNpcVillage(homeOwnerAvatar.IsNpcAvatar());
			this.logicLevel_0.SetHome(home, false);
			this.logicLevel_0.SetHomeOwnerAvatar(homeOwnerAvatar);
			this.logicLevel_0.SetVisitorAvatar(visitorAvatar);
			this.logicLevel_0.FastForwardTime(secondsSinceLastSave);
			homeOwnerAvatar.SetLevel(this.logicLevel_0);
			this.logicLevel_0.LoadingFinished();
		}

		// Token: 0x060001B0 RID: 432 RVA: 0x00018A4C File Offset: 0x00016C4C
		public void LoadMatchedAttackState(LogicClientHome home, LogicAvatar homeOwnerAvatar, LogicAvatar visitorAvatar, int currentTimestamp, int secondsSinceLastSave, int secondsSinceLastMaintenance)
		{
			if (this.int_0 != 0)
			{
				Debugger.Error("loadAttackState called from invalid state");
				return;
			}
			this.int_0 = 2;
			this.int_2 = currentTimestamp;
			this.int_8 = secondsSinceLastMaintenance;
			this.logicConfiguration_0.Load((LogicJSONObject)LogicJSONParser.Parse(home.GetGlobalJSON()));
			this.logicCalendar_0.Load(home.GetCalendarJSON(), currentTimestamp);
			if (this.logicTimer_0 != null)
			{
				this.logicTimer_0.Destruct();
				this.logicTimer_0 = null;
			}
			this.logicTimer_0 = new LogicTimer();
			this.logicTimer_0.StartTimer(LogicDataTables.GetGlobals().GetAttackLengthSecs() + LogicDataTables.GetGlobals().GetAttackPreparationLengthSecs(), this.logicLevel_0.GetLogicTime(), false, -1);
			if (homeOwnerAvatar.IsClientAvatar())
			{
				this.logicLevel_0.SetMatchType(1, null);
				this.logicLevel_0.SetHome(home, false);
				this.logicLevel_0.SetHomeOwnerAvatar(homeOwnerAvatar);
				this.logicLevel_0.SetVisitorAvatar(visitorAvatar);
				this.logicLevel_0.FastForwardTime(secondsSinceLastSave);
				homeOwnerAvatar.SetLevel(this.logicLevel_0);
				this.logicLevel_0.LoadingFinished();
				this.logicReplay_0 = new LogicReplay(this.logicLevel_0);
				return;
			}
			Debugger.Error("loadDirectAttackState called and home owner is not client avatar");
		}

		// Token: 0x060001B1 RID: 433 RVA: 0x00018B80 File Offset: 0x00016D80
		public void LoadRevengeAttackState(LogicClientHome home, LogicAvatar homeOwnerAvatar, LogicAvatar visitorAvatar, int currentTimestamp, int secondsSinceLastSave, int secondsSinceLastMaintenance, LogicLong revengeId)
		{
			if (this.int_0 != 0)
			{
				Debugger.Error("loadAttackState called from invalid state");
				return;
			}
			this.int_0 = 2;
			this.int_2 = currentTimestamp;
			this.int_8 = secondsSinceLastMaintenance;
			this.logicConfiguration_0.Load((LogicJSONObject)LogicJSONParser.Parse(home.GetGlobalJSON()));
			this.logicCalendar_0.Load(home.GetCalendarJSON(), currentTimestamp);
			if (this.logicTimer_0 != null)
			{
				this.logicTimer_0.Destruct();
				this.logicTimer_0 = null;
			}
			this.logicTimer_0 = new LogicTimer();
			this.logicTimer_0.StartTimer(LogicDataTables.GetGlobals().GetAttackLengthSecs() + LogicDataTables.GetGlobals().GetAttackPreparationLengthSecs(), this.logicLevel_0.GetLogicTime(), false, -1);
			if (homeOwnerAvatar.IsClientAvatar())
			{
				this.logicLevel_0.SetMatchType(4, revengeId);
				this.logicLevel_0.SetHome(home, false);
				this.logicLevel_0.SetHomeOwnerAvatar(homeOwnerAvatar);
				this.logicLevel_0.SetVisitorAvatar(visitorAvatar);
				this.logicLevel_0.FastForwardTime(secondsSinceLastSave);
				homeOwnerAvatar.SetLevel(this.logicLevel_0);
				this.logicLevel_0.LoadingFinished();
				this.logicReplay_0 = new LogicReplay(this.logicLevel_0);
				return;
			}
			Debugger.Error("loadDirectAttackState called and home owner is not client avatar");
		}

		// Token: 0x060001B2 RID: 434 RVA: 0x00018CB4 File Offset: 0x00016EB4
		public void LoadDirectAttackState(LogicClientHome home, LogicAvatar homeOwnerAvatar, LogicAvatar visitorAvatar, int secondsSinceLastSave, bool war, bool village2, int currentTimestamp)
		{
			if (this.int_0 != 0)
			{
				Debugger.Error("loadAttackState called from invalid state");
			}
			this.int_0 = 2;
			this.int_2 = currentTimestamp;
			this.logicConfiguration_0.Load((LogicJSONObject)LogicJSONParser.Parse(home.GetGlobalJSON()));
			this.logicCalendar_0.Load(home.GetCalendarJSON(), currentTimestamp);
			if (this.logicTimer_0 != null)
			{
				this.logicTimer_0.Destruct();
				this.logicTimer_0 = null;
			}
			this.logicTimer_0 = new LogicTimer();
			this.logicTimer_0.StartTimer(LogicDataTables.GetGlobals().GetAttackLengthSecs() + (village2 ? LogicDataTables.GetGlobals().GetAttackVillage2PreparationLengthSecs() : LogicDataTables.GetGlobals().GetAttackPreparationLengthSecs()), this.logicLevel_0.GetLogicTime(), false, -1);
			if (!homeOwnerAvatar.IsClientAvatar())
			{
				Debugger.Error("loadDirectAttackState called and home owner is not client avatar");
			}
			this.logicLevel_0.SetMatchType(village2 ? 8 : (war ? 7 : 3), null);
			if (village2)
			{
				this.logicLevel_0.SetVillageType(1);
			}
			this.logicLevel_0.SetHome(home, false);
			this.logicLevel_0.SetHomeOwnerAvatar(homeOwnerAvatar);
			homeOwnerAvatar.SetHeroDefenseState();
			this.logicLevel_0.SetVisitorAvatar(visitorAvatar);
			this.logicLevel_0.FastForwardTime(secondsSinceLastSave);
			this.logicLevel_0.LoadingFinished();
			this.logicReplay_0 = new LogicReplay(this.logicLevel_0);
		}

		// Token: 0x04000087 RID: 135
		private bool bool_0;

		// Token: 0x04000088 RID: 136
		private bool bool_1;

		// Token: 0x04000089 RID: 137
		private int int_0;

		// Token: 0x0400008A RID: 138
		private int int_1;

		// Token: 0x0400008B RID: 139
		private int int_2;

		// Token: 0x0400008C RID: 140
		private int int_3;

		// Token: 0x0400008D RID: 141
		private int int_4;

		// Token: 0x0400008E RID: 142
		private int int_5;

		// Token: 0x0400008F RID: 143
		private int int_6;

		// Token: 0x04000090 RID: 144
		private int int_7;

		// Token: 0x04000091 RID: 145
		private int int_8;

		// Token: 0x04000092 RID: 146
		private int int_9;

		// Token: 0x04000093 RID: 147
		private int int_10;

		// Token: 0x04000094 RID: 148
		private int int_11;

		// Token: 0x04000095 RID: 149
		private int int_12;

		// Token: 0x04000096 RID: 150
		private readonly LogicLevel logicLevel_0;

		// Token: 0x04000097 RID: 151
		private readonly LogicCommandManager logicCommandManager_0;

		// Token: 0x04000098 RID: 152
		private readonly LogicCalendar logicCalendar_0;

		// Token: 0x04000099 RID: 153
		private readonly LogicConfiguration logicConfiguration_0;

		// Token: 0x0400009A RID: 154
		private LogicTimer logicTimer_0;

		// Token: 0x0400009B RID: 155
		private LogicReplay logicReplay_0;
	}
}
