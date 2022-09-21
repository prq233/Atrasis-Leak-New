using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Server
{
	// Token: 0x02000175 RID: 373
	public class LogicChangeAvatarNameCommand : LogicServerCommand
	{
		// Token: 0x060015F1 RID: 5617 RVA: 0x0000E4FE File Offset: 0x0000C6FE
		public override void Destruct()
		{
			base.Destruct();
			this.string_0 = null;
		}

		// Token: 0x060015F2 RID: 5618 RVA: 0x0000E50D File Offset: 0x0000C70D
		public override void Decode(ByteStream stream)
		{
			this.string_0 = stream.ReadString(900000);
			this.int_2 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x060015F3 RID: 5619 RVA: 0x0000E533 File Offset: 0x0000C733
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteString(this.string_0);
			encoder.WriteInt(this.int_2);
			base.Encode(encoder);
		}

		// Token: 0x060015F4 RID: 5620 RVA: 0x00054C1C File Offset: 0x00052E1C
		public override int Execute(LogicLevel level)
		{
			LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
			if (playerAvatar != null)
			{
				playerAvatar.SetName(this.string_0);
				playerAvatar.SetNameSetByUser(true);
				playerAvatar.SetNameChangeState(this.int_2);
				level.GetGameListener().NameChanged(this.string_0);
				return 0;
			}
			return -1;
		}

		// Token: 0x060015F5 RID: 5621 RVA: 0x00002C4D File Offset: 0x00000E4D
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.CHANGE_AVATAR_NAME;
		}

		// Token: 0x060015F6 RID: 5622 RVA: 0x0000E554 File Offset: 0x0000C754
		public void SetAvatarName(string avatarName)
		{
			this.string_0 = avatarName;
		}

		// Token: 0x060015F7 RID: 5623 RVA: 0x0000E55D File Offset: 0x0000C75D
		public void SetAvatarNameChangeState(int state)
		{
			this.int_2 = state;
		}

		// Token: 0x04000C72 RID: 3186
		private string string_0;

		// Token: 0x04000C73 RID: 3187
		private int int_2;
	}
}
