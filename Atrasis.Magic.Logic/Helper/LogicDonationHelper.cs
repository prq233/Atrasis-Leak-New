using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Message.Alliance.Stream;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Helper
{
	// Token: 0x0200010A RID: 266
	public static class LogicDonationHelper
	{
		// Token: 0x06000CB1 RID: 3249 RVA: 0x0002B96C File Offset: 0x00029B6C
		public static int GetMaxUnitDonationCount(int allianceLevel, int unitType)
		{
			if (unitType == 1)
			{
				return LogicDataTables.GetGlobals().GetMaxSpellDonationCount();
			}
			if (allianceLevel > 0)
			{
				LogicAllianceLevelData allianceLevel2 = LogicDataTables.GetAllianceLevel(allianceLevel);
				if (allianceLevel2 != null)
				{
					return allianceLevel2.GetTroopDonationLimit();
				}
			}
			return LogicDataTables.GetGlobals().GetMaxTroopDonationCount();
		}

		// Token: 0x06000CB2 RID: 3250 RVA: 0x0002B9A8 File Offset: 0x00029BA8
		public static int GetTotalDonationCapacity(LogicArrayList<DonationContainer> arrayList, LogicCombatItemType unitType)
		{
			if (arrayList != null)
			{
				int num = 0;
				for (int i = 0; i < arrayList.Size(); i++)
				{
					num += arrayList[i].GetDonationCapacity(unitType);
				}
				return num;
			}
			return 0;
		}

		// Token: 0x06000CB3 RID: 3251 RVA: 0x0002B9E0 File Offset: 0x00029BE0
		public static int GetTotalDonateCount(LogicArrayList<DonationContainer> arrayList, LogicLong avatarId, LogicCombatItemType unitType)
		{
			Debugger.DoAssert(arrayList != null, "pDonations cannot be null");
			for (int i = 0; i < arrayList.Size(); i++)
			{
				if (LogicLong.Equals(arrayList[i].GetAvatarId(), avatarId))
				{
					return arrayList[i].GetTotalDonationCount(unitType);
				}
			}
			return 0;
		}

		// Token: 0x06000CB4 RID: 3252 RVA: 0x0002BA30 File Offset: 0x00029C30
		public static int GetDonateCount(LogicArrayList<DonationContainer> arrayList, LogicLong avatarId, LogicCombatItemData data)
		{
			Debugger.DoAssert(arrayList != null, "pDonations cannot be null");
			for (int i = 0; i < arrayList.Size(); i++)
			{
				if (LogicLong.Equals(arrayList[i].GetAvatarId(), avatarId))
				{
					return arrayList[i].GetDonationCount(data);
				}
			}
			return 0;
		}

		// Token: 0x06000CB5 RID: 3253 RVA: 0x0002BA80 File Offset: 0x00029C80
		public static bool CanAddDonation(LogicArrayList<DonationContainer> arrayList, LogicLong avatarId, LogicCombatItemData data, int allianceLevel)
		{
			Debugger.DoAssert(arrayList != null, "pDonations cannot be null");
			for (int i = 0; i < arrayList.Size(); i++)
			{
				if (LogicLong.Equals(arrayList[i].GetAvatarId(), avatarId))
				{
					return arrayList[i].CanAddUnit(data, allianceLevel);
				}
			}
			return true;
		}

		// Token: 0x06000CB6 RID: 3254 RVA: 0x0002BAD4 File Offset: 0x00029CD4
		public static bool CanDonateAnything(LogicArrayList<DonationContainer> arrayList, LogicLong avatarId, int allianceLevel)
		{
			Debugger.DoAssert(arrayList != null, "pDonations cannot be null");
			for (int i = 0; i < arrayList.Size(); i++)
			{
				if (LogicLong.Equals(arrayList[i].GetAvatarId(), avatarId) && arrayList[i].IsDonationLimitReached(allianceLevel))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06000CB7 RID: 3255 RVA: 0x0002BB28 File Offset: 0x00029D28
		public static void AddDonation(LogicArrayList<DonationContainer> arrayList, LogicLong avatarId, LogicCombatItemData data, int upgLevel)
		{
			Debugger.DoAssert(arrayList != null, "pDonations cannot be null");
			int num = -1;
			int i = 0;
			while (i < arrayList.Size())
			{
				if (!LogicLong.Equals(arrayList[i].GetAvatarId(), avatarId))
				{
					i++;
				}
				else
				{
					num = i;
					IL_3A:
					if (num != -1)
					{
						arrayList[num].AddUnit(data, upgLevel);
						return;
					}
					DonationContainer donationContainer = new DonationContainer(avatarId.Clone());
					donationContainer.AddUnit(data, upgLevel);
					arrayList.Add(donationContainer);
					return;
				}
			}
			goto IL_3A;
		}

		// Token: 0x06000CB8 RID: 3256 RVA: 0x0002BBA0 File Offset: 0x00029DA0
		public static void RemoveDonation(LogicArrayList<DonationContainer> arrayList, LogicLong avatarId, LogicCombatItemData data, int upgLevel)
		{
			Debugger.DoAssert(arrayList != null, "pDonations cannot be null");
			int num = -1;
			for (int i = 0; i < arrayList.Size(); i++)
			{
				if (LogicLong.Equals(arrayList[i].GetAvatarId(), avatarId))
				{
					num = i;
					IL_3A:
					if (num != -1)
					{
						arrayList[num].RemoveUnit(data, upgLevel);
					}
					return;
				}
			}
			goto IL_3A;
		}
	}
}
