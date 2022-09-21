using System;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001C4 RID: 452
	public sealed class LogicSetItemSeenCommand : LogicCommand
	{
		// Token: 0x06001801 RID: 6145 RVA: 0x0000EB66 File Offset: 0x0000CD66
		public LogicSetItemSeenCommand()
		{
		}

		// Token: 0x06001802 RID: 6146 RVA: 0x0000FDCB File Offset: 0x0000DFCB
		public LogicSetItemSeenCommand(int villageType)
		{
			this.int_1 = villageType;
		}

		// Token: 0x06001803 RID: 6147 RVA: 0x0000FDDA File Offset: 0x0000DFDA
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x06001804 RID: 6148 RVA: 0x0000FDEF File Offset: 0x0000DFEF
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			base.Encode(encoder);
		}

		// Token: 0x06001805 RID: 6149 RVA: 0x0000FE04 File Offset: 0x0000E004
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.SET_ITEM_SEEN;
		}

		// Token: 0x06001806 RID: 6150 RVA: 0x0000EB45 File Offset: 0x0000CD45
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06001807 RID: 6151 RVA: 0x0000FE0B File Offset: 0x0000E00B
		public override int Execute(LogicLevel level)
		{
			if (this.int_1 == 0)
			{
				level.GetPlayerAvatar().SetVariableByName("SeenBuilderMenu", 1);
				return 0;
			}
			return -1;
		}

		// Token: 0x04000D12 RID: 3346
		private int int_1;
	}
}
