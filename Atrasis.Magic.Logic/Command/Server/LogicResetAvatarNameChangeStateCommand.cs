using System;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Server
{
	// Token: 0x02000183 RID: 387
	public class LogicResetAvatarNameChangeStateCommand : LogicServerCommand
	{
		// Token: 0x06001652 RID: 5714 RVA: 0x0000E2D5 File Offset: 0x0000C4D5
		public LogicResetAvatarNameChangeStateCommand()
		{
		}

		// Token: 0x06001653 RID: 5715 RVA: 0x0000E99E File Offset: 0x0000CB9E
		public LogicResetAvatarNameChangeStateCommand(int state)
		{
			this.int_2 = state;
		}

		// Token: 0x06001654 RID: 5716 RVA: 0x0000E2EC File Offset: 0x0000C4EC
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06001655 RID: 5717 RVA: 0x0000E9AD File Offset: 0x0000CBAD
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
			this.int_2 = stream.ReadInt();
		}

		// Token: 0x06001656 RID: 5718 RVA: 0x0000E9C2 File Offset: 0x0000CBC2
		public override void Encode(ChecksumEncoder encoder)
		{
			base.Encode(encoder);
			encoder.WriteInt(this.int_2);
		}

		// Token: 0x06001657 RID: 5719 RVA: 0x0000E9D7 File Offset: 0x0000CBD7
		public override int Execute(LogicLevel level)
		{
			if (level.GetPlayerAvatar() != null)
			{
				level.GetPlayerAvatar().SetNameChangeState(this.int_2);
				return 0;
			}
			return -1;
		}

		// Token: 0x06001658 RID: 5720 RVA: 0x0000746A File Offset: 0x0000566A
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.RESET_AVATAR_NAME_CHANGE_STATE;
		}

		// Token: 0x04000C99 RID: 3225
		private int int_2;
	}
}
