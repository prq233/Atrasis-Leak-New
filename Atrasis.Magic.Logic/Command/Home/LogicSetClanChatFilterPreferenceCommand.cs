using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001C2 RID: 450
	public sealed class LogicSetClanChatFilterPreferenceCommand : LogicCommand
	{
		// Token: 0x060017F2 RID: 6130 RVA: 0x0000EB66 File Offset: 0x0000CD66
		public LogicSetClanChatFilterPreferenceCommand()
		{
		}

		// Token: 0x060017F3 RID: 6131 RVA: 0x0000FD0C File Offset: 0x0000DF0C
		public LogicSetClanChatFilterPreferenceCommand(bool enabled)
		{
			this.bool_0 = enabled;
		}

		// Token: 0x060017F4 RID: 6132 RVA: 0x0000FD1B File Offset: 0x0000DF1B
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
			this.bool_0 = stream.ReadBoolean();
		}

		// Token: 0x060017F5 RID: 6133 RVA: 0x0000FD30 File Offset: 0x0000DF30
		public override void Encode(ChecksumEncoder encoder)
		{
			base.Encode(encoder);
			encoder.WriteBoolean(this.bool_0);
		}

		// Token: 0x060017F6 RID: 6134 RVA: 0x0000FD45 File Offset: 0x0000DF45
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.SET_CLAN_CHAT_FILTER_PREFERENCE;
		}

		// Token: 0x060017F7 RID: 6135 RVA: 0x0000EB45 File Offset: 0x0000CD45
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x060017F8 RID: 6136 RVA: 0x0005B2C4 File Offset: 0x000594C4
		public override int Execute(LogicLevel level)
		{
			LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
			if (playerAvatar != null)
			{
				if (this.bool_0 != playerAvatar.GetAllianceChatFilterEnabled())
				{
					playerAvatar.SetAllianceChatFilterEnabled(true);
					level.GetHomeOwnerAvatar().GetChangeListener().AllianceChatFilterChanged(this.bool_0);
				}
				return 0;
			}
			return -1;
		}

		// Token: 0x04000D10 RID: 3344
		private bool bool_0;
	}
}
