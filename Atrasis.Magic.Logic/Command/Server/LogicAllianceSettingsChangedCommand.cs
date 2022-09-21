using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Command.Server
{
	// Token: 0x02000170 RID: 368
	public class LogicAllianceSettingsChangedCommand : LogicServerCommand
	{
		// Token: 0x060015CF RID: 5583 RVA: 0x0000E352 File Offset: 0x0000C552
		public override void Destruct()
		{
			base.Destruct();
			this.logicLong_0 = null;
		}

		// Token: 0x060015D0 RID: 5584 RVA: 0x0000E361 File Offset: 0x0000C561
		public override void Decode(ByteStream stream)
		{
			this.logicLong_0 = stream.ReadLong();
			this.int_2 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x060015D1 RID: 5585 RVA: 0x0000E382 File Offset: 0x0000C582
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteLong(this.logicLong_0);
			encoder.WriteInt(this.int_2);
			base.Encode(encoder);
		}

		// Token: 0x060015D2 RID: 5586 RVA: 0x000547B8 File Offset: 0x000529B8
		public override int Execute(LogicLevel level)
		{
			LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
			if (playerAvatar != null)
			{
				if (LogicLong.Equals(playerAvatar.GetAllianceId(), this.logicLong_0))
				{
					playerAvatar.SetAllianceBadgeId(this.int_2);
					level.GetGameListener().AllianceSettingsChanged();
				}
				return 0;
			}
			return -1;
		}

		// Token: 0x060015D3 RID: 5587 RVA: 0x00002D0B File Offset: 0x00000F0B
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.ALLIANCE_SETTINGS_CHANGED;
		}

		// Token: 0x060015D4 RID: 5588 RVA: 0x0000E3A3 File Offset: 0x0000C5A3
		public void SetAllianceData(LogicLong allianceId, int allianceBadgeId)
		{
			this.logicLong_0 = allianceId;
			this.int_2 = allianceBadgeId;
		}

		// Token: 0x04000C61 RID: 3169
		private LogicLong logicLong_0;

		// Token: 0x04000C62 RID: 3170
		private int int_2;
	}
}
