using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Command.Server
{
	// Token: 0x0200017D RID: 381
	public class LogicDuelLootAwardedCommand : LogicServerCommand
	{
		// Token: 0x06001628 RID: 5672 RVA: 0x0000E2EC File Offset: 0x0000C4EC
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06001629 RID: 5673 RVA: 0x00055AD0 File Offset: 0x00053CD0
		public override void Decode(ByteStream stream)
		{
			this.int_2 = stream.ReadInt();
			this.int_3 = stream.ReadInt();
			this.int_4 = stream.ReadInt();
			this.int_5 = stream.ReadInt();
			stream.ReadInt();
			this.logicLong_0 = stream.ReadLong();
			base.Decode(stream);
		}

		// Token: 0x0600162A RID: 5674 RVA: 0x00055B28 File Offset: 0x00053D28
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_2);
			encoder.WriteInt(this.int_3);
			encoder.WriteInt(this.int_4);
			encoder.WriteInt(this.int_5);
			encoder.WriteInt(0);
			encoder.WriteLong(this.logicLong_0);
			base.Encode(encoder);
		}

		// Token: 0x0600162B RID: 5675 RVA: 0x00055B80 File Offset: 0x00053D80
		public override int Execute(LogicLevel level)
		{
			LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
			if (playerAvatar != null)
			{
				playerAvatar.AddDuelReward(this.int_2, this.int_3, this.int_4, this.int_5, this.logicLong_0);
				return 0;
			}
			return -1;
		}

		// Token: 0x0600162C RID: 5676 RVA: 0x0000E800 File Offset: 0x0000CA00
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.DUEL_LOOT_AWARDED;
		}

		// Token: 0x0600162D RID: 5677 RVA: 0x0000E804 File Offset: 0x0000CA04
		public void SetDatas(int goldCount, int elixirCount, int bonusGoldCount, int bonusElixirCount, LogicLong matchId)
		{
			this.int_2 = goldCount;
			this.int_3 = elixirCount;
			this.int_4 = bonusGoldCount;
			this.int_5 = bonusElixirCount;
			this.logicLong_0 = matchId;
		}

		// Token: 0x04000C88 RID: 3208
		private int int_2;

		// Token: 0x04000C89 RID: 3209
		private int int_3;

		// Token: 0x04000C8A RID: 3210
		private int int_4;

		// Token: 0x04000C8B RID: 3211
		private int int_5;

		// Token: 0x04000C8C RID: 3212
		private LogicLong logicLong_0;
	}
}
