using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Command.Server
{
	// Token: 0x02000174 RID: 372
	public class LogicChangeAllianceRoleCommand : LogicServerCommand
	{
		// Token: 0x060015EA RID: 5610 RVA: 0x0000E49D File Offset: 0x0000C69D
		public void SetData(LogicLong allianceId, LogicAvatarAllianceRole allianceRole)
		{
			this.logicLong_0 = allianceId;
			this.logicAvatarAllianceRole_0 = allianceRole;
		}

		// Token: 0x060015EB RID: 5611 RVA: 0x0000E4AD File Offset: 0x0000C6AD
		public override void Destruct()
		{
			base.Destruct();
			this.logicLong_0 = null;
		}

		// Token: 0x060015EC RID: 5612 RVA: 0x0000E4BC File Offset: 0x0000C6BC
		public override void Decode(ByteStream stream)
		{
			this.logicLong_0 = stream.ReadLong();
			this.logicAvatarAllianceRole_0 = (LogicAvatarAllianceRole)stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x060015ED RID: 5613 RVA: 0x0000E4DD File Offset: 0x0000C6DD
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteLong(this.logicLong_0);
			encoder.WriteInt((int)this.logicAvatarAllianceRole_0);
			base.Encode(encoder);
		}

		// Token: 0x060015EE RID: 5614 RVA: 0x00054BD8 File Offset: 0x00052DD8
		public override int Execute(LogicLevel level)
		{
			LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
			if (playerAvatar != null)
			{
				if (playerAvatar.IsInAlliance() && LogicLong.Equals(playerAvatar.GetAllianceId(), this.logicLong_0))
				{
					playerAvatar.SetAllianceRole(this.logicAvatarAllianceRole_0);
				}
				return 0;
			}
			return -1;
		}

		// Token: 0x060015EF RID: 5615 RVA: 0x0000A1EC File Offset: 0x000083EC
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.CHANGE_ALLIANCE_ROLE;
		}

		// Token: 0x04000C70 RID: 3184
		private LogicLong logicLong_0;

		// Token: 0x04000C71 RID: 3185
		private LogicAvatarAllianceRole logicAvatarAllianceRole_0;
	}
}
