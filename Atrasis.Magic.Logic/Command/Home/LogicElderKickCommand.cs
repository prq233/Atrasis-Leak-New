using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001A2 RID: 418
	public sealed class LogicElderKickCommand : LogicCommand
	{
		// Token: 0x06001725 RID: 5925 RVA: 0x0000F1E4 File Offset: 0x0000D3E4
		public override void Decode(ByteStream stream)
		{
			this.logicLong_0 = stream.ReadLong();
			if (stream.ReadBoolean())
			{
				this.string_0 = stream.ReadString(900000);
			}
			base.Decode(stream);
		}

		// Token: 0x06001726 RID: 5926 RVA: 0x0000F212 File Offset: 0x0000D412
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteLong(this.logicLong_0);
			if (this.string_0 != null)
			{
				encoder.WriteBoolean(true);
				encoder.WriteString(this.string_0);
			}
			else
			{
				encoder.WriteBoolean(false);
			}
			base.Encode(encoder);
		}

		// Token: 0x06001727 RID: 5927 RVA: 0x0000F24B File Offset: 0x0000D44B
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.ELDER_KICK;
		}

		// Token: 0x06001728 RID: 5928 RVA: 0x0000F252 File Offset: 0x0000D452
		public override void Destruct()
		{
			base.Destruct();
			this.logicLong_0 = null;
			this.string_0 = null;
		}

		// Token: 0x06001729 RID: 5929 RVA: 0x0005889C File Offset: 0x00056A9C
		public override int Execute(LogicLevel level)
		{
			LogicAvatarAllianceRole allianceRole = level.GetHomeOwnerAvatar().GetAllianceRole();
			if (allianceRole != LogicAvatarAllianceRole.MEMBER)
			{
				if (allianceRole != LogicAvatarAllianceRole.LEADER)
				{
					if (allianceRole != LogicAvatarAllianceRole.CO_LEADER)
					{
						LogicBuilding allianceCastle = level.GetGameObjectManagerAt(0).GetAllianceCastle();
						if (allianceCastle != null)
						{
							LogicBunkerComponent bunkerComponent = allianceCastle.GetBunkerComponent();
							if (bunkerComponent != null && bunkerComponent.GetElderCooldownTime() == 0)
							{
								bunkerComponent.StartElderKickCooldownTime();
								level.GetHomeOwnerAvatar().GetChangeListener().KickPlayer(this.logicLong_0, this.string_0);
								return 0;
							}
						}
						return -2;
					}
				}
				level.GetHomeOwnerAvatar().GetChangeListener().KickPlayer(this.logicLong_0, this.string_0);
				return 0;
			}
			return -1;
		}

		// Token: 0x04000CCD RID: 3277
		private LogicLong logicLong_0;

		// Token: 0x04000CCE RID: 3278
		private string string_0;
	}
}
