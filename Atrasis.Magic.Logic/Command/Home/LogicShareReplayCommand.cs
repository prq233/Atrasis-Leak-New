using System;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001C8 RID: 456
	public sealed class LogicShareReplayCommand : LogicCommand
	{
		// Token: 0x0600181B RID: 6171 RVA: 0x0000FF46 File Offset: 0x0000E146
		public override void Decode(ByteStream stream)
		{
			this.logicLong_0 = stream.ReadLong();
			this.bool_0 = stream.ReadBoolean();
			if (stream.ReadBoolean())
			{
				this.string_0 = stream.ReadString(900000);
			}
			base.Decode(stream);
		}

		// Token: 0x0600181C RID: 6172 RVA: 0x0005B434 File Offset: 0x00059634
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteLong(this.logicLong_0);
			encoder.WriteBoolean(this.bool_0);
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

		// Token: 0x0600181D RID: 6173 RVA: 0x0000FF80 File Offset: 0x0000E180
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.SHARE_REPLAY;
		}

		// Token: 0x0600181E RID: 6174 RVA: 0x0000FF87 File Offset: 0x0000E187
		public override void Destruct()
		{
			base.Destruct();
			this.string_0 = null;
			this.logicLong_0 = null;
		}

		// Token: 0x0600181F RID: 6175 RVA: 0x0005B484 File Offset: 0x00059684
		public override int Execute(LogicLevel level)
		{
			LogicBuilding allianceCastle = level.GetGameObjectManagerAt(0).GetAllianceCastle();
			if (allianceCastle != null)
			{
				LogicBunkerComponent bunkerComponent = allianceCastle.GetBunkerComponent();
				if (bunkerComponent != null && bunkerComponent.GetReplayShareCooldownTime() == 0)
				{
					bunkerComponent.StartReplayShareCooldownTime();
					if (this.bool_0)
					{
						level.GetGameListener().DuelReplayShared(this.logicLong_0);
						level.GetHomeOwnerAvatar().GetChangeListener().ShareDuelReplay(this.logicLong_0, this.string_0);
					}
					else
					{
						level.GetHomeOwnerAvatar().GetChangeListener().ShareReplay(this.logicLong_0, this.string_0);
					}
					return 0;
				}
			}
			return -1;
		}

		// Token: 0x04000D19 RID: 3353
		private LogicLong logicLong_0;

		// Token: 0x04000D1A RID: 3354
		private bool bool_0;

		// Token: 0x04000D1B RID: 3355
		private string string_0;
	}
}
