using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Util;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Calendar
{
	// Token: 0x020001F5 RID: 501
	public class LogicCalendarEvent
	{
		// Token: 0x0600196F RID: 6511 RVA: 0x000609FC File Offset: 0x0005EBFC
		public LogicCalendarEvent()
		{
			this.logicCalendarErrorHandler_0 = new LogicCalendarErrorHandler();
			this.logicArrayList_0 = new LogicArrayList<LogicCalendarFunction>();
			this.logicArrayList_1 = new LogicArrayList<LogicDataSlot>();
			this.logicArrayList_2 = new LogicArrayList<LogicDataSlot>();
			this.logicArrayList_3 = new LogicArrayList<LogicData>();
			this.logicArrayList_4 = new LogicArrayList<LogicDataSlot>();
			this.logicArrayList_5 = new LogicArrayList<LogicCalendarUseTroop>();
			this.int_9 = 1;
			this.int_10 = 1;
			this.int_11 = 1;
			this.int_12 = 1;
			this.int_13 = 1;
		}

		// Token: 0x06001970 RID: 6512 RVA: 0x00060A80 File Offset: 0x0005EC80
		public virtual void Destruct()
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
			if (this.logicArrayList_1 != null)
			{
				while (this.logicArrayList_1.Size() > 0)
				{
					this.logicArrayList_1[0].Destruct();
					this.logicArrayList_1.Remove(0);
				}
				this.logicArrayList_2 = null;
			}
			if (this.logicArrayList_2 != null)
			{
				while (this.logicArrayList_2.Size() > 0)
				{
					this.logicArrayList_2[0].Destruct();
					this.logicArrayList_2.Remove(0);
				}
				this.logicArrayList_2 = null;
			}
			if (this.logicArrayList_4 != null)
			{
				while (this.logicArrayList_4.Size() > 0)
				{
					this.logicArrayList_4[0].Destruct();
					this.logicArrayList_4.Remove(0);
				}
				this.logicArrayList_4 = null;
			}
			this.logicArrayList_3 = null;
			this.logicArrayList_5 = null;
			this.string_0 = null;
			this.string_1 = null;
			this.string_2 = null;
			this.string_3 = null;
			this.string_4 = null;
			this.logicEventEntryData_0 = null;
			this.logicCalendarTargeting_0 = null;
			this.logicCalendarErrorHandler_0 = null;
		}

		// Token: 0x06001971 RID: 6513 RVA: 0x00010EE7 File Offset: 0x0000F0E7
		public void SetErrorHandler(LogicCalendarErrorHandler errorHandler)
		{
			this.logicCalendarErrorHandler_0 = errorHandler;
		}

		// Token: 0x06001972 RID: 6514 RVA: 0x00010EF0 File Offset: 0x0000F0F0
		public void Init(LogicJSONObject jsonObject)
		{
			this.Load(jsonObject);
			this.ApplyFunctions();
		}

		// Token: 0x06001973 RID: 6515 RVA: 0x00060BCC File Offset: 0x0005EDCC
		public virtual void Load(LogicJSONObject jsonObject)
		{
			if (jsonObject == null)
			{
				this.logicCalendarErrorHandler_0.Error(this, "Json cannot be null");
			}
			this.int_0 = LogicJSONHelper.GetInt(jsonObject, "id", -1);
			this.int_1 = LogicJSONHelper.GetInt(jsonObject, "version", 0);
			this.int_7 = LogicDataTables.GetGlobals().GetNewTrainingBoostBarracksCost();
			this.int_8 = LogicDataTables.GetGlobals().GetNewTrainingBoostLaboratoryCost();
			this.int_2 = LogicCalendarEvent.smethod_0(LogicJSONHelper.GetString(jsonObject, "startTime"), false);
			this.int_3 = LogicCalendarEvent.smethod_0(LogicJSONHelper.GetString(jsonObject, "endTime"), true);
			if (this.int_2 >= this.int_3)
			{
				this.logicCalendarErrorHandler_0.ErrorField(this, "endTime", "End time must be after start time.");
			}
			LogicJSONString jsonstring = jsonObject.GetJSONString("visibleTime");
			if (jsonstring != null)
			{
				this.int_4 = LogicCalendarEvent.smethod_0(jsonstring.GetStringValue(), false);
				if (this.int_4 > this.int_2)
				{
					this.logicCalendarErrorHandler_0.ErrorField(this, "visibleTime", "Visible time must be before or at start time.");
				}
			}
			else
			{
				this.int_4 = 0;
			}
			this.string_0 = jsonObject.GetJSONString("clashBoxEntryName").GetStringValue();
			LogicJSONString jsonstring2 = jsonObject.GetJSONString("eventEntryName");
			this.logicEventEntryData_0 = LogicDataTables.GetEventEntryByName(jsonstring2.GetStringValue(), null);
			if (jsonstring2.GetStringValue().Length > 0)
			{
				if (this.logicEventEntryData_0 == null)
				{
					this.logicCalendarErrorHandler_0.ErrorField(this, "eventEntryName", string.Format("Invalid event entry name: {0}.", jsonstring2.GetStringValue()));
				}
				if (this.int_4 == 0)
				{
					this.logicCalendarErrorHandler_0.ErrorField(this, "visibleTime", "Visible time must be set if event entry name is set.");
				}
			}
			if (this.int_4 != 0 && this.logicEventEntryData_0 == null)
			{
				this.logicCalendarErrorHandler_0.ErrorField(this, "eventEntryName", "Event entry name must be set if visible time is set.");
			}
			this.int_6 = LogicJSONHelper.GetInt(jsonObject, "inboxEntryId", -1);
			this.string_1 = LogicJSONHelper.GetString(jsonObject, "notificationTid");
			this.string_2 = LogicJSONHelper.GetString(jsonObject, "image");
			this.string_3 = LogicJSONHelper.GetString(jsonObject, "sc");
			this.string_4 = LogicJSONHelper.GetString(jsonObject, "localization");
			if (jsonObject.GetJSONObject("targeting") != null)
			{
				this.logicCalendarTargeting_0 = new LogicCalendarTargeting(jsonObject);
			}
			LogicJSONArray jsonarray = jsonObject.GetJSONArray("functions");
			if (jsonarray != null)
			{
				for (int i = 0; i < jsonarray.Size(); i++)
				{
					this.logicArrayList_0.Add(new LogicCalendarFunction(this, i, jsonarray.GetJSONObject(i), this.logicCalendarErrorHandler_0));
				}
			}
		}

		// Token: 0x06001974 RID: 6516 RVA: 0x00060E30 File Offset: 0x0005F030
		public virtual LogicJSONObject Save()
		{
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			logicJSONObject.Put("type", new LogicJSONNumber(this.GetCalendarEventType()));
			logicJSONObject.Put("id", new LogicJSONNumber(this.int_0));
			logicJSONObject.Put("version", new LogicJSONNumber(this.int_1));
			logicJSONObject.Put("visibleTime", new LogicJSONString(LogicCalendarEvent.smethod_1(this.int_4)));
			logicJSONObject.Put("startTime", new LogicJSONString(LogicCalendarEvent.smethod_1(this.int_2)));
			logicJSONObject.Put("endTime", new LogicJSONString(LogicCalendarEvent.smethod_1(this.int_3)));
			logicJSONObject.Put("clashBoxEntryName", new LogicJSONString(this.string_0));
			logicJSONObject.Put("eventEntryName", new LogicJSONString((this.logicEventEntryData_0 != null) ? this.logicEventEntryData_0.GetName() : string.Empty));
			logicJSONObject.Put("inboxEntryId", new LogicJSONNumber(this.int_6));
			logicJSONObject.Put("notificationTid", new LogicJSONString(this.string_1));
			logicJSONObject.Put("image", new LogicJSONString(this.string_2));
			logicJSONObject.Put("sc", new LogicJSONString(this.string_3));
			logicJSONObject.Put("localization", new LogicJSONString(this.string_4));
			LogicJSONArray logicJSONArray = new LogicJSONArray(this.logicArrayList_0.Size());
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				logicJSONArray.Add(this.logicArrayList_0[i].Save());
			}
			logicJSONObject.Put("functions", logicJSONArray);
			if (this.logicCalendarTargeting_0 != null)
			{
				LogicJSONObject item = new LogicJSONObject();
				this.logicCalendarTargeting_0.Save(logicJSONObject);
				logicJSONObject.Put("targeting", item);
			}
			return logicJSONObject;
		}

		// Token: 0x06001975 RID: 6517 RVA: 0x00060FF8 File Offset: 0x0005F1F8
		public void ApplyFunctions()
		{
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				this.logicArrayList_0[i].ApplyToEvent(this);
			}
		}

		// Token: 0x06001976 RID: 6518 RVA: 0x00061030 File Offset: 0x0005F230
		private static int smethod_0(string string_5, bool bool_0)
		{
			int num = string_5.IndexOf("T");
			Debugger.DoAssert(num == 8, "Unable to convert time. ISO8601 expected.");
			LogicGregDate logicGregDate = new LogicGregDate(LogicStringUtil.ConvertToInt(string_5, 0, 4), LogicStringUtil.ConvertToInt(string_5, 4, 6), LogicStringUtil.ConvertToInt(string_5, 6, 8));
			logicGregDate.Validate();
			int num2 = logicGregDate.GetIndex() * 86400;
			string text = string_5.Substring(num + 1);
			if (text.Length < 2)
			{
				if (bool_0)
				{
					return num2 + 82800;
				}
				return num2;
			}
			else
			{
				num2 += 3600 * LogicStringUtil.ConvertToInt(text, 0, 2);
				if (text.Length < 4)
				{
					if (bool_0)
					{
						return num2 + 3540;
					}
					return num2;
				}
				else
				{
					num2 += 60 * LogicStringUtil.ConvertToInt(text, 2, 4);
					if (text.Length >= 6)
					{
						return num2 + LogicStringUtil.ConvertToInt(text, 4, 6);
					}
					if (bool_0)
					{
						return num2 + 59;
					}
					return num2;
				}
			}
		}

		// Token: 0x06001977 RID: 6519 RVA: 0x000610FC File Offset: 0x0005F2FC
		private static string smethod_1(int int_14)
		{
			LogicGregDate logicGregDate = new LogicGregDate(int_14 / 86400);
			return string.Format("{0:D4}{1:D2}{2:D2}T{3:D2}{4:D2}{5:D2}.000Z", new object[]
			{
				logicGregDate.GetYear(),
				logicGregDate.GetMonth(),
				logicGregDate.GetDay(),
				int_14 % 86400 / 3600,
				int_14 % 86400 % 3600 / 60,
				int_14 % 86400 % 3600 % 60
			});
		}

		// Token: 0x06001978 RID: 6520 RVA: 0x00002465 File Offset: 0x00000665
		public virtual int GetCalendarEventType()
		{
			return 0;
		}

		// Token: 0x06001979 RID: 6521 RVA: 0x00010EFF File Offset: 0x0000F0FF
		public int GetId()
		{
			return this.int_0;
		}

		// Token: 0x0600197A RID: 6522 RVA: 0x00010F07 File Offset: 0x0000F107
		public void SetId(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x0600197B RID: 6523 RVA: 0x00010F10 File Offset: 0x0000F110
		public int GetVersion()
		{
			return this.int_1;
		}

		// Token: 0x0600197C RID: 6524 RVA: 0x00010F18 File Offset: 0x0000F118
		public void SetVersion(int value)
		{
			this.int_1 = value;
		}

		// Token: 0x0600197D RID: 6525 RVA: 0x00010F21 File Offset: 0x0000F121
		public int GetStartTime()
		{
			return this.int_2;
		}

		// Token: 0x0600197E RID: 6526 RVA: 0x00010F29 File Offset: 0x0000F129
		public void SetStartTime(int value)
		{
			this.int_2 = value;
		}

		// Token: 0x0600197F RID: 6527 RVA: 0x00010F32 File Offset: 0x0000F132
		public int GetEndTime()
		{
			return this.int_3;
		}

		// Token: 0x06001980 RID: 6528 RVA: 0x00010F3A File Offset: 0x0000F13A
		public void SetEndTime(int value)
		{
			this.int_3 = value;
		}

		// Token: 0x06001981 RID: 6529 RVA: 0x00010F43 File Offset: 0x0000F143
		public int GetVisibleTime()
		{
			return this.int_4;
		}

		// Token: 0x06001982 RID: 6530 RVA: 0x00010F4B File Offset: 0x0000F14B
		public void SetVisibleTime(int value)
		{
			this.int_4 = value;
		}

		// Token: 0x06001983 RID: 6531 RVA: 0x00010F54 File Offset: 0x0000F154
		public int GetVisibleEndTime()
		{
			return this.int_5;
		}

		// Token: 0x06001984 RID: 6532 RVA: 0x00010F5C File Offset: 0x0000F15C
		public void SetVisibleEndTime(int value)
		{
			this.int_5 = value;
		}

		// Token: 0x06001985 RID: 6533 RVA: 0x00010F65 File Offset: 0x0000F165
		public int GetInboxEntryId()
		{
			return this.int_6;
		}

		// Token: 0x06001986 RID: 6534 RVA: 0x00010F6D File Offset: 0x0000F16D
		public void SetInboxEntryId(int value)
		{
			this.int_6 = value;
		}

		// Token: 0x06001987 RID: 6535 RVA: 0x00010F76 File Offset: 0x0000F176
		public string GetClashBoxEntryName()
		{
			return this.string_0;
		}

		// Token: 0x06001988 RID: 6536 RVA: 0x00010F7E File Offset: 0x0000F17E
		public void SetClashBoxEntryName(string value)
		{
			this.string_0 = value;
		}

		// Token: 0x06001989 RID: 6537 RVA: 0x00010F87 File Offset: 0x0000F187
		public string GetNotificationTid()
		{
			return this.string_1;
		}

		// Token: 0x0600198A RID: 6538 RVA: 0x00010F8F File Offset: 0x0000F18F
		public void SetNotificationTid(string value)
		{
			this.string_1 = value;
		}

		// Token: 0x0600198B RID: 6539 RVA: 0x00010F98 File Offset: 0x0000F198
		public string GetImage()
		{
			return this.string_2;
		}

		// Token: 0x0600198C RID: 6540 RVA: 0x00010FA0 File Offset: 0x0000F1A0
		public void SetImage(string value)
		{
			this.string_2 = value;
		}

		// Token: 0x0600198D RID: 6541 RVA: 0x00010FA9 File Offset: 0x0000F1A9
		public string GetSc()
		{
			return this.string_3;
		}

		// Token: 0x0600198E RID: 6542 RVA: 0x00010FB1 File Offset: 0x0000F1B1
		public void SetSc(string value)
		{
			this.string_3 = value;
		}

		// Token: 0x0600198F RID: 6543 RVA: 0x00010FBA File Offset: 0x0000F1BA
		public string GetLocalization()
		{
			return this.string_4;
		}

		// Token: 0x06001990 RID: 6544 RVA: 0x00010FC2 File Offset: 0x0000F1C2
		public void SetLocalization(string value)
		{
			this.string_4 = value;
		}

		// Token: 0x06001991 RID: 6545 RVA: 0x00010FCB File Offset: 0x0000F1CB
		public LogicEventEntryData GetEventEntryData()
		{
			return this.logicEventEntryData_0;
		}

		// Token: 0x06001992 RID: 6546 RVA: 0x00010FD3 File Offset: 0x0000F1D3
		public void SetEventEntryData(LogicEventEntryData value)
		{
			this.logicEventEntryData_0 = value;
		}

		// Token: 0x06001993 RID: 6547 RVA: 0x00010FDC File Offset: 0x0000F1DC
		public int GetNewTrainingBoostBarracksCost()
		{
			return this.int_7;
		}

		// Token: 0x06001994 RID: 6548 RVA: 0x00010FE4 File Offset: 0x0000F1E4
		public void SetNewTrainingBoostBarracksCost(int value)
		{
			this.int_7 = value;
		}

		// Token: 0x06001995 RID: 6549 RVA: 0x00010FED File Offset: 0x0000F1ED
		public int GetNewTrainingBoostSpellCost()
		{
			return this.int_8;
		}

		// Token: 0x06001996 RID: 6550 RVA: 0x00010FF5 File Offset: 0x0000F1F5
		public void SetNewTrainingBoostSpellCost(int value)
		{
			this.int_8 = value;
		}

		// Token: 0x06001997 RID: 6551 RVA: 0x00010FFE File Offset: 0x0000F1FE
		public void AddBuildingBoost(LogicData data, int count)
		{
			this.logicArrayList_1.Add(new LogicDataSlot(data, count));
		}

		// Token: 0x06001998 RID: 6552 RVA: 0x00061198 File Offset: 0x0005F398
		public int GetBuildingBoostCost(LogicBuildingData data, int upgLevel)
		{
			for (int i = 0; i < this.logicArrayList_1.Size(); i++)
			{
				LogicDataSlot logicDataSlot = this.logicArrayList_1[i];
				if (logicDataSlot.GetData() == data)
				{
					return logicDataSlot.GetCount();
				}
			}
			return data.GetBoostCost(upgLevel);
		}

		// Token: 0x06001999 RID: 6553 RVA: 0x00011012 File Offset: 0x0000F212
		public void AddTroopDiscount(LogicData data, int count)
		{
			this.logicArrayList_2.Add(new LogicDataSlot(data, count));
		}

		// Token: 0x0600199A RID: 6554 RVA: 0x000611E4 File Offset: 0x0005F3E4
		public int GetTrainingCost(LogicCombatItemData data, int upgLevel)
		{
			int trainingCost = data.GetTrainingCost(upgLevel);
			for (int i = 0; i < this.logicArrayList_2.Size(); i++)
			{
				LogicDataSlot logicDataSlot = this.logicArrayList_2[i];
				if (logicDataSlot.GetData() == data)
				{
					return (logicDataSlot.GetCount() * trainingCost + 99) / 100;
				}
			}
			return trainingCost;
		}

		// Token: 0x0600199B RID: 6555 RVA: 0x00011026 File Offset: 0x0000F226
		public void AddEnabledData(LogicData data)
		{
			this.logicArrayList_3.Add(data);
		}

		// Token: 0x0600199C RID: 6556 RVA: 0x00011034 File Offset: 0x0000F234
		public bool IsEnabled(LogicData data)
		{
			return !data.IsEnableByCalendar() || this.logicArrayList_3.IndexOf(data) != -1;
		}

		// Token: 0x0600199D RID: 6557 RVA: 0x00011052 File Offset: 0x0000F252
		public void AddFreeTroop(LogicCombatItemData data, int count)
		{
			if (!data.IsProductionEnabled())
			{
				Debugger.Error(data.GetName() + " cannot be produced!");
			}
			this.logicArrayList_4.Add(new LogicDataSlot(data, count));
		}

		// Token: 0x0600199E RID: 6558 RVA: 0x00061238 File Offset: 0x0005F438
		public void AddUseTroop(LogicCombatItemData data, int count, int ratioOfHousing, int rewardDiamonds, int rewardXp)
		{
			LogicCalendarUseTroop logicCalendarUseTroop = new LogicCalendarUseTroop(data);
			logicCalendarUseTroop.AddParameter(count);
			logicCalendarUseTroop.AddParameter(ratioOfHousing);
			logicCalendarUseTroop.AddParameter(rewardDiamonds);
			logicCalendarUseTroop.AddParameter(rewardXp);
			this.logicArrayList_5.Add(logicCalendarUseTroop);
		}

		// Token: 0x0600199F RID: 6559 RVA: 0x00011083 File Offset: 0x0000F283
		public void AddBuildingDestroyedSpawnUnit(LogicBuildingData data, LogicCharacterData spawnData, int count)
		{
			this.SetBuildingDestroyedSpawnUnit(new LogicCalendarBuildingDestroyedSpawnUnit(data, spawnData, count));
		}

		// Token: 0x060019A0 RID: 6560 RVA: 0x00011093 File Offset: 0x0000F293
		public void SetBuildingDestroyedSpawnUnit(LogicCalendarBuildingDestroyedSpawnUnit buildingDestroyedSpawnUnit)
		{
			this.logicCalendarBuildingDestroyedSpawnUnit_0 = buildingDestroyedSpawnUnit;
		}

		// Token: 0x060019A1 RID: 6561 RVA: 0x0001109C File Offset: 0x0000F29C
		public int GetAllianceXpMultiplier()
		{
			return this.int_9;
		}

		// Token: 0x060019A2 RID: 6562 RVA: 0x000110A4 File Offset: 0x0000F2A4
		public void SetAllianceXpMultiplier(int value)
		{
			this.int_9 = value;
		}

		// Token: 0x060019A3 RID: 6563 RVA: 0x000110AD File Offset: 0x0000F2AD
		public int GetStarBonusMultiplier()
		{
			return this.int_10;
		}

		// Token: 0x060019A4 RID: 6564 RVA: 0x000110B5 File Offset: 0x0000F2B5
		public void SetStarBonusMultiplier(int value)
		{
			this.int_10 = value;
		}

		// Token: 0x060019A5 RID: 6565 RVA: 0x000110BE File Offset: 0x0000F2BE
		public int GetAllianceWarWinLootMultiplier()
		{
			return this.int_11;
		}

		// Token: 0x060019A6 RID: 6566 RVA: 0x000110C6 File Offset: 0x0000F2C6
		public void SetAllianceWarWinLootMultiplier(int value)
		{
			this.int_11 = value;
		}

		// Token: 0x060019A7 RID: 6567 RVA: 0x000110CF File Offset: 0x0000F2CF
		public int GetAllianceWarDrawLootMultiplier()
		{
			return this.int_12;
		}

		// Token: 0x060019A8 RID: 6568 RVA: 0x000110D7 File Offset: 0x0000F2D7
		public void SetAllianceWarDrawLootMultiplier(int value)
		{
			this.int_12 = value;
		}

		// Token: 0x060019A9 RID: 6569 RVA: 0x000110E0 File Offset: 0x0000F2E0
		public int GetAllianceWarLooseLootMultiplier()
		{
			return this.int_13;
		}

		// Token: 0x060019AA RID: 6570 RVA: 0x000110E8 File Offset: 0x0000F2E8
		public void SetAllianceWarLooseLootMultiplier(int value)
		{
			this.int_13 = value;
		}

		// Token: 0x060019AB RID: 6571 RVA: 0x000110F1 File Offset: 0x0000F2F1
		public bool IsEqual(LogicCalendarEvent calendarEvent)
		{
			return this.int_0 == calendarEvent.int_0 && this.int_1 == calendarEvent.int_1;
		}

		// Token: 0x060019AC RID: 6572 RVA: 0x00061278 File Offset: 0x0005F478
		public void StartUseTroopEvent(LogicAvatar homeOwnerAvatar, LogicLevel level)
		{
			if (homeOwnerAvatar != null)
			{
				for (int i = 0; i < this.logicArrayList_5.Size(); i++)
				{
					LogicCalendarUseTroop logicCalendarUseTroop = this.logicArrayList_5[i];
					LogicCombatItemData data = logicCalendarUseTroop.GetData();
					int valueB;
					if (data.GetCombatItemType() != LogicCombatItemType.CHARACTER)
					{
						int num = data.GetHousingSpace() * 2;
						valueB = (data.GetHousingSpace() + 2 * (level.GetComponentManagerAt(data.GetVillageType()).GetTotalMaxHousing(data.GetCombatItemType()) * logicCalendarUseTroop.GetParameter(1) / 100)) / num;
					}
					else
					{
						LogicBuildingData buildingByName = LogicDataTables.GetBuildingByName("Troop Housing", null);
						LogicBuildingData buildingByName2 = LogicDataTables.GetBuildingByName("Barrack", null);
						LogicBuildingData buildingByName3 = LogicDataTables.GetBuildingByName("Dark Elixir Barrack", null);
						int townHallLevel = homeOwnerAvatar.GetTownHallLevel();
						int maxUpgradeLevelForTownHallLevel = buildingByName.GetMaxUpgradeLevelForTownHallLevel(townHallLevel);
						int unitStorageCapacity = buildingByName.GetUnitStorageCapacity(maxUpgradeLevelForTownHallLevel);
						int num = data.GetHousingSpace();
						if ((data.GetUnitOfType() == 1 && buildingByName2.GetRequiredTownHallLevel(data.GetRequiredProductionHouseLevel()) <= townHallLevel) || (data.GetUnitOfType() == 2 && buildingByName3.GetRequiredTownHallLevel(data.GetRequiredProductionHouseLevel()) <= townHallLevel))
						{
							int num2 = (int)((long)LogicDataTables.GetTownHallLevel(townHallLevel).GetUnlockedBuildingCount(buildingByName) * (long)logicCalendarUseTroop.GetParameter(1) * (long)unitStorageCapacity);
							valueB = (int)(((float)num * 0.5f + (float)(num2 / 100)) / (float)num);
						}
						else
						{
							LogicBuildingData buildingByName4 = LogicDataTables.GetBuildingByName("Alliance Castle", null);
							valueB = buildingByName4.GetUnitStorageCapacity(buildingByName4.GetMaxUpgradeLevelForTownHallLevel(townHallLevel)) / num;
						}
					}
					int count = LogicMath.Max(1, valueB) << 16;
					homeOwnerAvatar.SetCommodityCount(6, data, count);
					homeOwnerAvatar.GetChangeListener().CommodityCountChanged(6, data, count);
				}
			}
		}

		// Token: 0x060019AD RID: 6573 RVA: 0x00011111 File Offset: 0x0000F311
		public LogicCalendarBuildingDestroyedSpawnUnit GetBuildingDestroyedSpawnUnit()
		{
			return this.logicCalendarBuildingDestroyedSpawnUnit_0;
		}

		// Token: 0x060019AE RID: 6574 RVA: 0x00011119 File Offset: 0x0000F319
		public LogicArrayList<LogicCalendarUseTroop> GetUseTroops()
		{
			return this.logicArrayList_5;
		}

		// Token: 0x060019AF RID: 6575 RVA: 0x00011121 File Offset: 0x0000F321
		public LogicArrayList<LogicCalendarFunction> GetFunctions()
		{
			return this.logicArrayList_0;
		}

		// Token: 0x04000DB2 RID: 3506
		public const int EVENT_TYPE_BASE = 0;

		// Token: 0x04000DB3 RID: 3507
		public const int EVENT_TYPE_OFFER = 1;

		// Token: 0x04000DB4 RID: 3508
		public const int EVENT_TYPE_DUEL_LOOT_LIMIT = 4;

		// Token: 0x04000DB5 RID: 3509
		private int int_0;

		// Token: 0x04000DB6 RID: 3510
		private int int_1;

		// Token: 0x04000DB7 RID: 3511
		private int int_2;

		// Token: 0x04000DB8 RID: 3512
		private int int_3;

		// Token: 0x04000DB9 RID: 3513
		private int int_4;

		// Token: 0x04000DBA RID: 3514
		private int int_5;

		// Token: 0x04000DBB RID: 3515
		private int int_6;

		// Token: 0x04000DBC RID: 3516
		private int int_7;

		// Token: 0x04000DBD RID: 3517
		private int int_8;

		// Token: 0x04000DBE RID: 3518
		private int int_9;

		// Token: 0x04000DBF RID: 3519
		private int int_10;

		// Token: 0x04000DC0 RID: 3520
		private int int_11;

		// Token: 0x04000DC1 RID: 3521
		private int int_12;

		// Token: 0x04000DC2 RID: 3522
		private int int_13;

		// Token: 0x04000DC3 RID: 3523
		private string string_0;

		// Token: 0x04000DC4 RID: 3524
		private string string_1;

		// Token: 0x04000DC5 RID: 3525
		private string string_2;

		// Token: 0x04000DC6 RID: 3526
		private string string_3;

		// Token: 0x04000DC7 RID: 3527
		private string string_4;

		// Token: 0x04000DC8 RID: 3528
		private LogicArrayList<LogicCalendarFunction> logicArrayList_0;

		// Token: 0x04000DC9 RID: 3529
		private readonly LogicArrayList<LogicDataSlot> logicArrayList_1;

		// Token: 0x04000DCA RID: 3530
		private LogicArrayList<LogicDataSlot> logicArrayList_2;

		// Token: 0x04000DCB RID: 3531
		private LogicArrayList<LogicData> logicArrayList_3;

		// Token: 0x04000DCC RID: 3532
		private LogicArrayList<LogicDataSlot> logicArrayList_4;

		// Token: 0x04000DCD RID: 3533
		private LogicArrayList<LogicCalendarUseTroop> logicArrayList_5;

		// Token: 0x04000DCE RID: 3534
		private LogicCalendarBuildingDestroyedSpawnUnit logicCalendarBuildingDestroyedSpawnUnit_0;

		// Token: 0x04000DCF RID: 3535
		private LogicEventEntryData logicEventEntryData_0;

		// Token: 0x04000DD0 RID: 3536
		private LogicCalendarTargeting logicCalendarTargeting_0;

		// Token: 0x04000DD1 RID: 3537
		private LogicCalendarErrorHandler logicCalendarErrorHandler_0;
	}
}
