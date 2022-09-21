using System;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001B0 RID: 432
	public sealed class LogicNamePresetCommand : LogicCommand
	{
		// Token: 0x0600177C RID: 6012 RVA: 0x0000EB66 File Offset: 0x0000CD66
		public LogicNamePresetCommand()
		{
		}

		// Token: 0x0600177D RID: 6013 RVA: 0x0000F6AF File Offset: 0x0000D8AF
		public LogicNamePresetCommand(int id, string name)
		{
			this.int_1 = id;
			this.string_0 = name;
		}

		// Token: 0x0600177E RID: 6014 RVA: 0x0000F6C5 File Offset: 0x0000D8C5
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			this.string_0 = stream.ReadString(900000);
			base.Decode(stream);
		}

		// Token: 0x0600177F RID: 6015 RVA: 0x0000F6EB File Offset: 0x0000D8EB
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			encoder.WriteString(this.string_0);
			base.Encode(encoder);
		}

		// Token: 0x06001780 RID: 6016 RVA: 0x0000F70C File Offset: 0x0000D90C
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.NAME_PRESET;
		}

		// Token: 0x06001781 RID: 6017 RVA: 0x0000F713 File Offset: 0x0000D913
		public override void Destruct()
		{
			base.Destruct();
			this.string_0 = null;
		}

		// Token: 0x06001782 RID: 6018 RVA: 0x0000F722 File Offset: 0x0000D922
		public override int Execute(LogicLevel level)
		{
			if (this.int_1 <= -1)
			{
				return -1;
			}
			if (this.int_1 > 3)
			{
				return -2;
			}
			if (this.string_0.Length <= 16)
			{
				level.SetArmyName(this.int_1, this.string_0);
				return 0;
			}
			return -4;
		}

		// Token: 0x04000CE8 RID: 3304
		private int int_1;

		// Token: 0x04000CE9 RID: 3305
		private string string_0;
	}
}
