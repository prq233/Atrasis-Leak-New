using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Command.Server
{
	// Token: 0x02000180 RID: 384
	public class LogicLeaveAllianceCommand : LogicServerCommand
	{
		// Token: 0x0600163E RID: 5694 RVA: 0x0000E8C9 File Offset: 0x0000CAC9
		public void SetAllianceData(LogicLong value)
		{
			this.logicLong_0 = value;
		}

		// Token: 0x0600163F RID: 5695 RVA: 0x0000E8D2 File Offset: 0x0000CAD2
		public override void Destruct()
		{
			base.Destruct();
			this.logicLong_0 = null;
		}

		// Token: 0x06001640 RID: 5696 RVA: 0x0000E8E1 File Offset: 0x0000CAE1
		public override void Decode(ByteStream stream)
		{
			this.logicLong_0 = stream.ReadLong();
			base.Decode(stream);
		}

		// Token: 0x06001641 RID: 5697 RVA: 0x0000E8F6 File Offset: 0x0000CAF6
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteLong(this.logicLong_0);
			base.Encode(encoder);
		}

		// Token: 0x06001642 RID: 5698 RVA: 0x00055DF4 File Offset: 0x00053FF4
		public override int Execute(LogicLevel level)
		{
			LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
			if (playerAvatar != null)
			{
				if (playerAvatar.IsInAlliance() && playerAvatar.GetAllianceId().Equals(this.logicLong_0))
				{
					playerAvatar.SetAllianceId(null);
					playerAvatar.SetAllianceName(null);
					playerAvatar.SetAllianceBadgeId(-1);
					playerAvatar.SetAllianceLevel(-1);
					playerAvatar.GetChangeListener().AllianceLeft();
				}
				level.GetGameListener().AllianceLeft();
				return 0;
			}
			return -1;
		}

		// Token: 0x06001643 RID: 5699 RVA: 0x00002B56 File Offset: 0x00000D56
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.LEAVE_ALLIANCE;
		}

		// Token: 0x04000C95 RID: 3221
		private LogicLong logicLong_0;
	}
}
