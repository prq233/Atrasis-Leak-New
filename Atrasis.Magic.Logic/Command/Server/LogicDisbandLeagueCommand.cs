using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Server
{
	// Token: 0x0200017A RID: 378
	public class LogicDisbandLeagueCommand : LogicServerCommand
	{
		// Token: 0x06001614 RID: 5652 RVA: 0x0000E2EC File Offset: 0x0000C4EC
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06001615 RID: 5653 RVA: 0x0000E6A0 File Offset: 0x0000C8A0
		public override void Decode(ByteStream stream)
		{
			this.int_2 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x06001616 RID: 5654 RVA: 0x0000E6B5 File Offset: 0x0000C8B5
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_2);
			base.Encode(encoder);
		}

		// Token: 0x06001617 RID: 5655 RVA: 0x00054FE8 File Offset: 0x000531E8
		public override int Execute(LogicLevel level)
		{
			LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
			if (playerAvatar != null)
			{
				playerAvatar.SetLeagueType(0);
				playerAvatar.SetLeagueInstanceId(null);
				playerAvatar.SetAttackWinCount(0);
				playerAvatar.SetAttackLoseCount(0);
				playerAvatar.SetDefenseWinCount(0);
				playerAvatar.SetDefenseLoseCount(0);
				level.SetLastLeagueShuffle(true);
				playerAvatar.GetChangeListener().LeagueChanged(0, null);
				return 0;
			}
			return -1;
		}

		// Token: 0x06001618 RID: 5656 RVA: 0x000077D6 File Offset: 0x000059D6
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.DISBAND_LEAGUE;
		}

		// Token: 0x04000C81 RID: 3201
		private int int_2;
	}
}
