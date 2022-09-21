using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Command.Server
{
	// Token: 0x02000188 RID: 392
	public class LogicWarLootAwardedCommand : LogicServerCommand
	{
		// Token: 0x06001677 RID: 5751 RVA: 0x00002463 File Offset: 0x00000663
		public void SetDatas(int diamondCount)
		{
		}

		// Token: 0x06001678 RID: 5752 RVA: 0x0000E2EC File Offset: 0x0000C4EC
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06001679 RID: 5753 RVA: 0x000562B4 File Offset: 0x000544B4
		public override void Decode(ByteStream stream)
		{
			this.int_2 = stream.ReadInt();
			this.int_3 = stream.ReadInt();
			this.int_4 = stream.ReadInt();
			stream.ReadInt();
			if (stream.ReadBoolean())
			{
				this.logicLong_0 = stream.ReadLong();
			}
			base.Decode(stream);
		}

		// Token: 0x0600167A RID: 5754 RVA: 0x00056308 File Offset: 0x00054508
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_2);
			encoder.WriteInt(this.int_3);
			encoder.WriteInt(this.int_4);
			encoder.WriteInt(0);
			if (this.logicLong_0 != null)
			{
				encoder.WriteBoolean(true);
				encoder.WriteLong(this.logicLong_0);
			}
			else
			{
				encoder.WriteBoolean(false);
			}
			base.Encode(encoder);
		}

		// Token: 0x0600167B RID: 5755 RVA: 0x0005636C File Offset: 0x0005456C
		public override int Execute(LogicLevel level)
		{
			LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
			if (playerAvatar != null)
			{
				playerAvatar.AddWarReward(this.int_2, this.int_3, this.int_4, 0, this.logicLong_0);
				return 0;
			}
			return -1;
		}

		// Token: 0x0600167C RID: 5756 RVA: 0x00003F09 File Offset: 0x00002109
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.WAR_LOOT_AWARDED;
		}

		// Token: 0x04000C9F RID: 3231
		private LogicLong logicLong_0;

		// Token: 0x04000CA0 RID: 3232
		private int int_2;

		// Token: 0x04000CA1 RID: 3233
		private int int_3;

		// Token: 0x04000CA2 RID: 3234
		private int int_4;
	}
}
