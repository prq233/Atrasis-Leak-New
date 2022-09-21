using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Util;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Avatar
{
	// Token: 0x02000201 RID: 513
	public class LogicNpcAvatar : LogicAvatar
	{
		// Token: 0x06001B11 RID: 6929 RVA: 0x00011B44 File Offset: 0x0000FD44
		public LogicNpcAvatar()
		{
			this.InitBase();
		}

		// Token: 0x06001B12 RID: 6930 RVA: 0x00011B52 File Offset: 0x0000FD52
		public override void Destruct()
		{
			base.Destruct();
			this.logicNpcData_0 = null;
		}

		// Token: 0x06001B13 RID: 6931 RVA: 0x00011B61 File Offset: 0x0000FD61
		public LogicNpcData GetNpcData()
		{
			return this.logicNpcData_0;
		}

		// Token: 0x06001B14 RID: 6932 RVA: 0x00011B69 File Offset: 0x0000FD69
		public override int GetExpLevel()
		{
			return this.logicNpcData_0.GetExpLevel();
		}

		// Token: 0x06001B15 RID: 6933 RVA: 0x00011B76 File Offset: 0x0000FD76
		public override string GetName()
		{
			return this.logicNpcData_0.GetPlayerName();
		}

		// Token: 0x06001B16 RID: 6934 RVA: 0x00011B83 File Offset: 0x0000FD83
		public override int GetAllianceBadgeId()
		{
			return this.logicNpcData_0.GetAllianceBadge();
		}

		// Token: 0x06001B17 RID: 6935 RVA: 0x00011B90 File Offset: 0x0000FD90
		public void Encode(ChecksumEncoder encoder)
		{
			ByteStreamHelper.WriteDataReference(encoder, this.logicNpcData_0);
		}

		// Token: 0x06001B18 RID: 6936 RVA: 0x00011B9E File Offset: 0x0000FD9E
		public void Decode(ByteStream stream)
		{
			this.SetNpcData((LogicNpcData)ByteStreamHelper.ReadDataReference(stream, LogicDataType.NPC));
		}

		// Token: 0x06001B19 RID: 6937 RVA: 0x00011BB3 File Offset: 0x0000FDB3
		public static LogicNpcAvatar GetNpcAvatar(LogicNpcData data)
		{
			LogicNpcAvatar logicNpcAvatar = new LogicNpcAvatar();
			logicNpcAvatar.SetNpcData(data);
			return logicNpcAvatar;
		}

		// Token: 0x06001B1A RID: 6938 RVA: 0x00002B36 File Offset: 0x00000D36
		public override bool IsNpcAvatar()
		{
			return true;
		}

		// Token: 0x06001B1B RID: 6939 RVA: 0x00002B33 File Offset: 0x00000D33
		public override LogicLeagueData GetLeagueTypeData()
		{
			return null;
		}

		// Token: 0x06001B1C RID: 6940 RVA: 0x00002463 File Offset: 0x00000663
		public override void SaveToReplay(LogicJSONObject jsonObject)
		{
		}

		// Token: 0x06001B1D RID: 6941 RVA: 0x00002463 File Offset: 0x00000663
		public override void SaveToDirect(LogicJSONObject jsonObject)
		{
		}

		// Token: 0x06001B1E RID: 6942 RVA: 0x00002463 File Offset: 0x00000663
		public override void LoadForReplay(LogicJSONObject jsonObject, bool direct)
		{
		}

		// Token: 0x06001B1F RID: 6943 RVA: 0x000690DC File Offset: 0x000672DC
		public void SetNpcData(LogicNpcData data)
		{
			this.logicNpcData_0 = data;
			base.SetResourceCount(LogicDataTables.GetGoldData(), this.logicNpcData_0.GetGoldCount());
			base.SetResourceCount(LogicDataTables.GetElixirData(), this.logicNpcData_0.GetElixirCount());
			if (this.m_allianceUnitCount.Size() != 0)
			{
				base.ClearUnitSlotArray(this.m_allianceUnitCount);
				this.m_allianceUnitCount = null;
			}
			if (this.m_unitCount.Size() != 0)
			{
				base.ClearDataSlotArray(this.m_unitCount);
				this.m_unitCount = null;
			}
			this.m_allianceUnitCount = new LogicArrayList<LogicUnitSlot>();
			this.m_unitCount = this.logicNpcData_0.GetClonedUnits();
		}

		// Token: 0x04000E6D RID: 3693
		private LogicNpcData logicNpcData_0;
	}
}
