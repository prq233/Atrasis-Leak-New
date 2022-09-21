using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Mission;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001AA RID: 426
	public sealed class LogicMissionProgressCommand : LogicCommand
	{
		// Token: 0x06001755 RID: 5973 RVA: 0x0000EB66 File Offset: 0x0000CD66
		public LogicMissionProgressCommand()
		{
		}

		// Token: 0x06001756 RID: 5974 RVA: 0x0000F43D File Offset: 0x0000D63D
		public LogicMissionProgressCommand(LogicMissionData missionData)
		{
			this.logicMissionData_0 = missionData;
		}

		// Token: 0x06001757 RID: 5975 RVA: 0x0000F44C File Offset: 0x0000D64C
		public override void Decode(ByteStream stream)
		{
			this.logicMissionData_0 = (LogicMissionData)ByteStreamHelper.ReadDataReference(stream, LogicDataType.MISSION);
			base.Decode(stream);
		}

		// Token: 0x06001758 RID: 5976 RVA: 0x0000F468 File Offset: 0x0000D668
		public override void Encode(ChecksumEncoder encoder)
		{
			ByteStreamHelper.WriteDataReference(encoder, this.logicMissionData_0);
			base.Encode(encoder);
		}

		// Token: 0x06001759 RID: 5977 RVA: 0x0000F47D File Offset: 0x0000D67D
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.MISSION_PROGRESS;
		}

		// Token: 0x0600175A RID: 5978 RVA: 0x0000F484 File Offset: 0x0000D684
		public override void Destruct()
		{
			base.Destruct();
			this.logicMissionData_0 = null;
		}

		// Token: 0x0600175B RID: 5979 RVA: 0x00058D28 File Offset: 0x00056F28
		public override int Execute(LogicLevel level)
		{
			if (this.logicMissionData_0 == null)
			{
				return -1;
			}
			LogicMission missionByData = level.GetMissionManager().GetMissionByData(this.logicMissionData_0);
			if (missionByData != null)
			{
				missionByData.StateChangeConfirmed();
				return 0;
			}
			return -2;
		}

		// Token: 0x04000CD6 RID: 3286
		private LogicMissionData logicMissionData_0;
	}
}
