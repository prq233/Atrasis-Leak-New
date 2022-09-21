using System;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001C6 RID: 454
	public sealed class LogicSetPersistentBoolCommand : LogicCommand
	{
		// Token: 0x0600180E RID: 6158 RVA: 0x0000FE8A File Offset: 0x0000E08A
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
			this.int_1 = stream.ReadInt();
			this.bool_0 = stream.ReadBoolean();
		}

		// Token: 0x0600180F RID: 6159 RVA: 0x0000FEAB File Offset: 0x0000E0AB
		public override void Encode(ChecksumEncoder encoder)
		{
			base.Encode(encoder);
			encoder.WriteInt(this.int_1);
			encoder.WriteBoolean(this.bool_0);
		}

		// Token: 0x06001810 RID: 6160 RVA: 0x0000FECC File Offset: 0x0000E0CC
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.SET_PERSISTENT_BOOL;
		}

		// Token: 0x06001811 RID: 6161 RVA: 0x0000EB45 File Offset: 0x0000CD45
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06001812 RID: 6162 RVA: 0x0000FED3 File Offset: 0x0000E0D3
		public override int Execute(LogicLevel level)
		{
			if (this.int_1 == 0)
			{
				level.SetPersistentBool(0, this.bool_0);
				return 0;
			}
			return -1;
		}

		// Token: 0x04000D16 RID: 3350
		private int int_1;

		// Token: 0x04000D17 RID: 3351
		private bool bool_0;
	}
}
