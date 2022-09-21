using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Command.Server
{
	// Token: 0x02000176 RID: 374
	public class LogicChangeLeagueCommand : LogicServerCommand
	{
		// Token: 0x060015F9 RID: 5625 RVA: 0x0000E2EC File Offset: 0x0000C4EC
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x060015FA RID: 5626 RVA: 0x0000E566 File Offset: 0x0000C766
		public override void Decode(ByteStream stream)
		{
			if (stream.ReadBoolean())
			{
				this.logicLong_0 = stream.ReadLong();
			}
			this.int_2 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x060015FB RID: 5627 RVA: 0x0000E58F File Offset: 0x0000C78F
		public override void Encode(ChecksumEncoder encoder)
		{
			if (this.logicLong_0 != null)
			{
				encoder.WriteBoolean(true);
				encoder.WriteLong(this.logicLong_0);
			}
			else
			{
				encoder.WriteBoolean(false);
			}
			encoder.WriteInt(this.int_2);
			base.Encode(encoder);
		}

		// Token: 0x060015FC RID: 5628 RVA: 0x00054C68 File Offset: 0x00052E68
		public override int Execute(LogicLevel level)
		{
			LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
			if (playerAvatar != null)
			{
				playerAvatar.SetLeagueType(this.int_2);
				if (this.int_2 != 0)
				{
					playerAvatar.SetLeagueInstanceId(this.logicLong_0.Clone());
				}
				else
				{
					playerAvatar.SetLeagueInstanceId(null);
					playerAvatar.SetAttackWinCount(0);
					playerAvatar.SetAttackLoseCount(0);
					playerAvatar.SetDefenseWinCount(0);
					playerAvatar.SetDefenseLoseCount(0);
				}
				playerAvatar.GetChangeListener().LeagueChanged(this.int_2, this.logicLong_0);
				return 0;
			}
			return -1;
		}

		// Token: 0x060015FD RID: 5629 RVA: 0x000046E0 File Offset: 0x000028E0
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.CHANGE_LEAGUE;
		}

		// Token: 0x060015FE RID: 5630 RVA: 0x0000E5C8 File Offset: 0x0000C7C8
		public void SetDatas(LogicLong id, int leagueType)
		{
			this.logicLong_0 = id;
			this.int_2 = leagueType;
		}

		// Token: 0x04000C74 RID: 3188
		private LogicLong logicLong_0;

		// Token: 0x04000C75 RID: 3189
		private int int_2;
	}
}
