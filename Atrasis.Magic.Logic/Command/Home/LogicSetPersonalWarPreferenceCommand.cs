using System;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001C7 RID: 455
	public class LogicSetPersonalWarPreferenceCommand : LogicCommand
	{
		// Token: 0x06001814 RID: 6164 RVA: 0x0000EB66 File Offset: 0x0000CD66
		public LogicSetPersonalWarPreferenceCommand()
		{
		}

		// Token: 0x06001815 RID: 6165 RVA: 0x0000FEED File Offset: 0x0000E0ED
		public LogicSetPersonalWarPreferenceCommand(int preference)
		{
			this.int_1 = preference;
		}

		// Token: 0x06001816 RID: 6166 RVA: 0x0000EB45 File Offset: 0x0000CD45
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06001817 RID: 6167 RVA: 0x0000FEFC File Offset: 0x0000E0FC
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x06001818 RID: 6168 RVA: 0x0000FF11 File Offset: 0x0000E111
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			base.Encode(encoder);
		}

		// Token: 0x06001819 RID: 6169 RVA: 0x0000FF26 File Offset: 0x0000E126
		public override int Execute(LogicLevel level)
		{
			level.GetPlayerAvatar().GetChangeListener().WarPreferenceChanged(this.int_1);
			return 0;
		}

		// Token: 0x0600181A RID: 6170 RVA: 0x0000FF3F File Offset: 0x0000E13F
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.SET_PERSONAL_WAR_PREFERENCE;
		}

		// Token: 0x04000D18 RID: 3352
		private int int_1;
	}
}
