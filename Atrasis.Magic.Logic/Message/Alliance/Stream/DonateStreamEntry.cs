using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Util;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Message.Alliance.Stream
{
	// Token: 0x020000E1 RID: 225
	public class DonateStreamEntry : StreamEntry
	{
		// Token: 0x060009D6 RID: 2518 RVA: 0x00007909 File Offset: 0x00005B09
		public DonateStreamEntry()
		{
			this.logicArrayList_1 = new LogicArrayList<DonationContainer>();
		}

		// Token: 0x060009D7 RID: 2519 RVA: 0x00022E28 File Offset: 0x00021028
		public override void Destruct()
		{
			base.Destruct();
			if (this.logicArrayList_1 != null)
			{
				for (int i = this.logicArrayList_1.Size() - 1; i >= 0; i--)
				{
					this.logicArrayList_1[i].Destruct();
					this.logicArrayList_1.Remove(i);
				}
				this.logicArrayList_1 = null;
			}
			if (this.logicArrayList_0 != null)
			{
				for (int j = this.logicArrayList_0.Size() - 1; j >= 0; j--)
				{
					this.logicArrayList_0[j].Destruct();
					this.logicArrayList_0.Remove(j);
				}
				this.logicArrayList_0 = null;
			}
			this.string_1 = null;
		}

		// Token: 0x060009D8 RID: 2520 RVA: 0x00022ECC File Offset: 0x000210CC
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
			this.int_3 = stream.ReadInt();
			this.int_6 = stream.ReadInt();
			this.int_7 = stream.ReadInt();
			this.int_4 = stream.ReadInt();
			this.int_5 = stream.ReadInt();
			int i = 0;
			int num = stream.ReadInt();
			while (i < num)
			{
				DonationContainer donationContainer = new DonationContainer();
				donationContainer.Decode(stream);
				this.logicArrayList_1.Add(donationContainer);
				i++;
			}
			if (stream.ReadBoolean())
			{
				this.string_1 = stream.ReadString(900000);
			}
			int num2 = stream.ReadInt();
			if (num2 > -1)
			{
				this.logicArrayList_0 = new LogicArrayList<LogicUnitSlot>(num2);
				for (int j = 0; j < num2; j++)
				{
					LogicUnitSlot logicUnitSlot = new LogicUnitSlot(null, -1, 0);
					logicUnitSlot.Decode(stream);
					this.logicArrayList_0.Add(logicUnitSlot);
				}
			}
		}

		// Token: 0x060009D9 RID: 2521 RVA: 0x00022FA8 File Offset: 0x000211A8
		public override void Encode(ByteStream stream)
		{
			base.Encode(stream);
			stream.WriteInt(this.int_3);
			stream.WriteInt(this.int_6);
			stream.WriteInt(this.int_7);
			stream.WriteInt(this.int_4);
			stream.WriteInt(this.int_5);
			stream.WriteInt(this.logicArrayList_1.Size());
			for (int i = 0; i < this.logicArrayList_1.Size(); i++)
			{
				this.logicArrayList_1[i].Encode(stream);
			}
			if (this.string_1 != null)
			{
				stream.WriteBoolean(true);
				stream.WriteString(this.string_1);
			}
			else
			{
				stream.WriteBoolean(false);
			}
			if (this.logicArrayList_0 != null)
			{
				stream.WriteInt(this.logicArrayList_0.Size());
				for (int j = 0; j < this.logicArrayList_0.Size(); j++)
				{
					this.logicArrayList_0[j].Encode(stream);
				}
				return;
			}
			stream.WriteInt(-1);
		}

		// Token: 0x060009DA RID: 2522 RVA: 0x0000791C File Offset: 0x00005B1C
		public int GetDonationPendingRequestCount()
		{
			return this.int_8;
		}

		// Token: 0x060009DB RID: 2523 RVA: 0x00007924 File Offset: 0x00005B24
		public void SetDonationPendingRequestCount(int count)
		{
			this.int_8 = count;
		}

		// Token: 0x060009DC RID: 2524 RVA: 0x0000792D File Offset: 0x00005B2D
		public int GetCastleLevel()
		{
			return this.int_3;
		}

		// Token: 0x060009DD RID: 2525 RVA: 0x00007935 File Offset: 0x00005B35
		public void SetCasteLevel(int castleLevel, int castleUsedCapacity, int castleUsedSpellCapacity, int castleTotalCapacity, int castleTotalSpellCapacity)
		{
			this.int_3 = castleLevel;
			this.int_4 = castleUsedCapacity;
			this.int_5 = castleUsedSpellCapacity;
			this.int_6 = castleTotalCapacity;
			this.int_7 = castleTotalSpellCapacity;
		}

		// Token: 0x060009DE RID: 2526 RVA: 0x0000795C File Offset: 0x00005B5C
		public int GetCastleTotalCapacity(LogicCombatItemType unitType)
		{
			if (unitType != LogicCombatItemType.SPELL)
			{
				return this.int_6;
			}
			return this.int_7;
		}

		// Token: 0x060009DF RID: 2527 RVA: 0x0000796F File Offset: 0x00005B6F
		public int GetCastleUsedCapacity(LogicCombatItemType unitType)
		{
			return ((unitType == LogicCombatItemType.SPELL) ? this.int_5 : this.int_4) + LogicDonationHelper.GetTotalDonationCapacity(this.logicArrayList_1, unitType);
		}

		// Token: 0x060009E0 RID: 2528 RVA: 0x00007990 File Offset: 0x00005B90
		public bool IsCastleFull()
		{
			return LogicDonationHelper.GetTotalDonationCapacity(this.logicArrayList_1, LogicCombatItemType.CHARACTER) + this.int_4 >= this.int_6 && LogicDonationHelper.GetTotalDonationCapacity(this.logicArrayList_1, LogicCombatItemType.SPELL) + this.int_5 >= this.int_7;
		}

		// Token: 0x060009E1 RID: 2529 RVA: 0x000079CD File Offset: 0x00005BCD
		public int GetTotalDonateCount(LogicLong avatarId, LogicCombatItemType unitType)
		{
			return LogicDonationHelper.GetTotalDonateCount(this.logicArrayList_1, avatarId, unitType);
		}

		// Token: 0x060009E2 RID: 2530 RVA: 0x000079DC File Offset: 0x00005BDC
		public int GetDonateCount(LogicLong avatarId, LogicCombatItemData data)
		{
			return LogicDonationHelper.GetDonateCount(this.logicArrayList_1, avatarId, data);
		}

		// Token: 0x060009E3 RID: 2531 RVA: 0x000079EB File Offset: 0x00005BEB
		public int GetTotalDonationCapacity(LogicCombatItemType unitType)
		{
			return LogicDonationHelper.GetTotalDonationCapacity(this.logicArrayList_1, unitType);
		}

		// Token: 0x060009E4 RID: 2532 RVA: 0x000230A0 File Offset: 0x000212A0
		public bool CanDonateAnything(LogicLong avatarId, int allianceLevel, bool includeDarkSpell)
		{
			if (!LogicLong.Equals(avatarId, base.GetSenderAvatarId()) && !this.IsCastleFull())
			{
				int totalDonateCount = this.GetTotalDonateCount(avatarId, LogicCombatItemType.CHARACTER);
				int totalDonateCount2 = this.GetTotalDonateCount(avatarId, LogicCombatItemType.SPELL);
				int num = this.int_7 - this.int_5 - totalDonateCount2;
				int maxUnitDonationCount = LogicDonationHelper.GetMaxUnitDonationCount(allianceLevel, 0);
				int maxUnitDonationCount2 = LogicDonationHelper.GetMaxUnitDonationCount(allianceLevel, 1);
				return (maxUnitDonationCount != totalDonateCount || maxUnitDonationCount2 != totalDonateCount2) && (includeDarkSpell || num >= 2 || this.int_6 != this.int_5 + LogicDonationHelper.GetTotalDonationCapacity(this.logicArrayList_1, LogicCombatItemType.CHARACTER)) && LogicDonationHelper.CanDonateAnything(this.logicArrayList_1, avatarId, allianceLevel);
			}
			return false;
		}

		// Token: 0x060009E5 RID: 2533 RVA: 0x00023130 File Offset: 0x00021330
		public bool CanAddDonation(LogicLong avatarId, LogicCombatItemData data, int allianceLevel)
		{
			if (!LogicLong.Equals(avatarId, base.GetSenderAvatarId()))
			{
				if (data.GetCombatItemType() == LogicCombatItemType.CHARACTER)
				{
					if (data.GetHousingSpace() + this.int_4 + LogicDonationHelper.GetTotalDonationCapacity(this.logicArrayList_1, LogicCombatItemType.CHARACTER) > this.int_6)
					{
						return false;
					}
				}
				else if (this.int_7 == 0 || data.GetHousingSpace() + this.int_5 + LogicDonationHelper.GetTotalDonationCapacity(this.logicArrayList_1, LogicCombatItemType.SPELL) > this.int_7)
				{
					return false;
				}
				return LogicDonationHelper.CanAddDonation(this.logicArrayList_1, avatarId, data, allianceLevel);
			}
			return false;
		}

		// Token: 0x060009E6 RID: 2534 RVA: 0x000079F9 File Offset: 0x00005BF9
		public void AddDonation(LogicLong avatarId, LogicCombatItemData data, int upgLevel)
		{
			LogicDonationHelper.AddDonation(this.logicArrayList_1, avatarId, data, upgLevel);
		}

		// Token: 0x060009E7 RID: 2535 RVA: 0x00007A09 File Offset: 0x00005C09
		public void RemoveDonation(LogicLong avatarId, LogicCombatItemData data, int upgLevel)
		{
			LogicDonationHelper.RemoveDonation(this.logicArrayList_1, avatarId, data, upgLevel);
		}

		// Token: 0x060009E8 RID: 2536 RVA: 0x00007A19 File Offset: 0x00005C19
		public string GetMessage()
		{
			return this.string_1;
		}

		// Token: 0x060009E9 RID: 2537 RVA: 0x00007A21 File Offset: 0x00005C21
		public void SetMessage(string message)
		{
			this.string_1 = message;
		}

		// Token: 0x060009EA RID: 2538 RVA: 0x00007A2A File Offset: 0x00005C2A
		public int GetUnitTypeCount()
		{
			if (this.logicArrayList_0 != null)
			{
				return this.logicArrayList_0.Size();
			}
			return 0;
		}

		// Token: 0x060009EB RID: 2539 RVA: 0x00007A41 File Offset: 0x00005C41
		public LogicCombatItemData GetUnitType(int idx)
		{
			return (LogicCombatItemData)this.logicArrayList_0[idx].GetData();
		}

		// Token: 0x060009EC RID: 2540 RVA: 0x00007A59 File Offset: 0x00005C59
		public LogicArrayList<LogicUnitSlot> GetUnits()
		{
			return this.logicArrayList_0;
		}

		// Token: 0x060009ED RID: 2541 RVA: 0x00007A61 File Offset: 0x00005C61
		public void SetUnits(LogicArrayList<LogicUnitSlot> slot)
		{
			this.logicArrayList_0 = slot;
		}

		// Token: 0x060009EE RID: 2542 RVA: 0x000231B4 File Offset: 0x000213B4
		public int GetXPReward(LogicLong avatarId)
		{
			for (int i = 0; i < this.logicArrayList_1.Size(); i++)
			{
				if (LogicLong.Equals(this.logicArrayList_1[i].GetAvatarId(), avatarId))
				{
					return this.logicArrayList_1[i].GetXPReward();
				}
			}
			return 0;
		}

		// Token: 0x060009EF RID: 2543 RVA: 0x00023204 File Offset: 0x00021404
		public DonationContainer GetDonationContainer(LogicLong avatarId)
		{
			for (int i = 0; i < this.logicArrayList_1.Size(); i++)
			{
				if (LogicLong.Equals(this.logicArrayList_1[i].GetAvatarId(), avatarId))
				{
					return this.logicArrayList_1[i];
				}
			}
			return null;
		}

		// Token: 0x060009F0 RID: 2544 RVA: 0x00002B36 File Offset: 0x00000D36
		public override StreamEntryType GetStreamEntryType()
		{
			return StreamEntryType.DONATE;
		}

		// Token: 0x060009F1 RID: 2545 RVA: 0x00023250 File Offset: 0x00021450
		public override void Load(LogicJSONObject jsonObject)
		{
			LogicJSONObject jsonobject = jsonObject.GetJSONObject("base");
			if (jsonobject == null)
			{
				Debugger.Error("ChatStreamEntry::load base is NULL");
			}
			base.Load(jsonobject);
			this.int_3 = LogicJSONHelper.GetInt(jsonObject, "castle_level");
			this.int_4 = LogicJSONHelper.GetInt(jsonObject, "castle_used");
			this.int_5 = LogicJSONHelper.GetInt(jsonObject, "castle_sp_used");
			this.int_6 = LogicJSONHelper.GetInt(jsonObject, "castle_total");
			this.int_7 = LogicJSONHelper.GetInt(jsonObject, "castle_sp_total");
			LogicJSONString jsonstring = jsonObject.GetJSONString("message");
			if (jsonstring != null)
			{
				this.string_1 = jsonstring.GetStringValue();
			}
			LogicJSONArray jsonarray = jsonObject.GetJSONArray("donators");
			if (jsonarray != null)
			{
				for (int i = 0; i < jsonarray.Size(); i++)
				{
					DonationContainer donationContainer = new DonationContainer();
					donationContainer.Load(jsonarray.GetJSONObject(i));
					this.logicArrayList_1.Add(donationContainer);
				}
			}
			LogicJSONArray jsonarray2 = jsonObject.GetJSONArray("units");
			if (jsonarray2 != null)
			{
				this.logicArrayList_0 = new LogicArrayList<LogicUnitSlot>();
				for (int j = 0; j < jsonarray2.Size(); j++)
				{
					LogicUnitSlot logicUnitSlot = new LogicUnitSlot(null, -1, 0);
					logicUnitSlot.ReadFromJSON(jsonarray2.GetJSONObject(j));
					this.logicArrayList_0.Add(logicUnitSlot);
				}
			}
		}

		// Token: 0x060009F2 RID: 2546 RVA: 0x0002338C File Offset: 0x0002158C
		public override void Save(LogicJSONObject jsonObject)
		{
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			base.Save(logicJSONObject);
			jsonObject.Put("base", logicJSONObject);
			jsonObject.Put("castle_level", new LogicJSONNumber(this.int_3));
			jsonObject.Put("castle_used", new LogicJSONNumber(this.int_4));
			jsonObject.Put("castle_sp_used", new LogicJSONNumber(this.int_5));
			jsonObject.Put("castle_total", new LogicJSONNumber(this.int_6));
			jsonObject.Put("castle_sp_total", new LogicJSONNumber(this.int_7));
			if (this.string_1 != null)
			{
				jsonObject.Put("message", new LogicJSONString(this.string_1));
			}
			LogicJSONArray logicJSONArray = new LogicJSONArray();
			for (int i = 0; i < this.logicArrayList_1.Size(); i++)
			{
				logicJSONArray.Add(this.logicArrayList_1[i].Save());
			}
			jsonObject.Put("donators", logicJSONArray);
			if (this.logicArrayList_0 != null)
			{
				LogicJSONArray logicJSONArray2 = new LogicJSONArray();
				for (int j = 0; j < this.logicArrayList_0.Size(); j++)
				{
					LogicJSONObject logicJSONObject2 = new LogicJSONObject();
					this.logicArrayList_0[j].WriteToJSON(logicJSONObject2);
					logicJSONArray2.Add(logicJSONObject2);
				}
				jsonObject.Put("units", logicJSONArray2);
			}
		}

		// Token: 0x040003D7 RID: 983
		private int int_3;

		// Token: 0x040003D8 RID: 984
		private int int_4;

		// Token: 0x040003D9 RID: 985
		private int int_5;

		// Token: 0x040003DA RID: 986
		private int int_6;

		// Token: 0x040003DB RID: 987
		private int int_7;

		// Token: 0x040003DC RID: 988
		private int int_8;

		// Token: 0x040003DD RID: 989
		private string string_1;

		// Token: 0x040003DE RID: 990
		private LogicArrayList<LogicUnitSlot> logicArrayList_0;

		// Token: 0x040003DF RID: 991
		private LogicArrayList<DonationContainer> logicArrayList_1;
	}
}
