using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001BF RID: 447
	public sealed class LogicSendAllianceMailCommand : LogicCommand
	{
		// Token: 0x060017DF RID: 6111 RVA: 0x0000EB66 File Offset: 0x0000CD66
		public LogicSendAllianceMailCommand()
		{
		}

		// Token: 0x060017E0 RID: 6112 RVA: 0x0000FC3F File Offset: 0x0000DE3F
		public LogicSendAllianceMailCommand(string message)
		{
			this.string_0 = message;
		}

		// Token: 0x060017E1 RID: 6113 RVA: 0x0000FC4E File Offset: 0x0000DE4E
		public override void Decode(ByteStream stream)
		{
			this.string_0 = stream.ReadString(900000);
			base.Decode(stream);
		}

		// Token: 0x060017E2 RID: 6114 RVA: 0x0000FC68 File Offset: 0x0000DE68
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteString(this.string_0);
			base.Encode(encoder);
		}

		// Token: 0x060017E3 RID: 6115 RVA: 0x0000FC7D File Offset: 0x0000DE7D
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.SEND_ALLIANCE_MAIL;
		}

		// Token: 0x060017E4 RID: 6116 RVA: 0x0000FC84 File Offset: 0x0000DE84
		public override void Destruct()
		{
			base.Destruct();
			this.string_0 = null;
		}

		// Token: 0x060017E5 RID: 6117 RVA: 0x0005B068 File Offset: 0x00059268
		public override int Execute(LogicLevel level)
		{
			LogicAvatarAllianceRole allianceRole = level.GetHomeOwnerAvatar().GetAllianceRole();
			if (allianceRole != LogicAvatarAllianceRole.LEADER)
			{
				if (allianceRole != LogicAvatarAllianceRole.CO_LEADER)
				{
					return -1;
				}
			}
			LogicBuilding allianceCastle = level.GetGameObjectManagerAt(0).GetAllianceCastle();
			if (allianceCastle != null)
			{
				LogicBunkerComponent bunkerComponent = allianceCastle.GetBunkerComponent();
				if (bunkerComponent != null && bunkerComponent.GetClanMailCooldownTime() == 0)
				{
					bunkerComponent.StartClanMailCooldownTime();
					level.GetHomeOwnerAvatar().GetChangeListener().SendClanMail(this.string_0);
					return 0;
				}
			}
			return -2;
		}

		// Token: 0x04000D0B RID: 3339
		private string string_0;
	}
}
