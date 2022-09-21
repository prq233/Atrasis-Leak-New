using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Server
{
	// Token: 0x0200016F RID: 367
	public class LogicAllianceExpEarnedCommand : LogicServerCommand
	{
		// Token: 0x060015C8 RID: 5576 RVA: 0x0000E2D5 File Offset: 0x0000C4D5
		public LogicAllianceExpEarnedCommand()
		{
		}

		// Token: 0x060015C9 RID: 5577 RVA: 0x0000E2DD File Offset: 0x0000C4DD
		public LogicAllianceExpEarnedCommand(int expLevel)
		{
			this.int_2 = expLevel;
		}

		// Token: 0x060015CA RID: 5578 RVA: 0x0000E2EC File Offset: 0x0000C4EC
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x060015CB RID: 5579 RVA: 0x0000E2F4 File Offset: 0x0000C4F4
		public override void Decode(ByteStream stream)
		{
			stream.ReadInt();
			stream.ReadInt();
			this.int_2 = stream.ReadInt();
			this.bool_0 = stream.ReadBoolean();
			base.Decode(stream);
		}

		// Token: 0x060015CC RID: 5580 RVA: 0x0000E323 File Offset: 0x0000C523
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(0);
			encoder.WriteInt(0);
			encoder.WriteInt(this.int_2);
			encoder.WriteBoolean(this.bool_0);
			base.Encode(encoder);
		}

		// Token: 0x060015CD RID: 5581 RVA: 0x00054770 File Offset: 0x00052970
		public override int Execute(LogicLevel level)
		{
			LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
			if (playerAvatar != null && playerAvatar.IsInAlliance())
			{
				playerAvatar.SetAllianceLevel(this.int_2);
				if (this.bool_0)
				{
					playerAvatar.GetChangeListener().AllianceLevelChanged(this.int_2);
				}
				return 0;
			}
			return -1;
		}

		// Token: 0x060015CE RID: 5582 RVA: 0x0000B38D File Offset: 0x0000958D
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.ALLIANCE_EXP_EARNED;
		}

		// Token: 0x04000C5F RID: 3167
		private int int_2;

		// Token: 0x04000C60 RID: 3168
		private bool bool_0;
	}
}
