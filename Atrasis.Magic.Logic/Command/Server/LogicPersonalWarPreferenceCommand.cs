using System;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Server
{
	// Token: 0x02000182 RID: 386
	public class LogicPersonalWarPreferenceCommand : LogicServerCommand
	{
		// Token: 0x0600164B RID: 5707 RVA: 0x0000E2D5 File Offset: 0x0000C4D5
		public LogicPersonalWarPreferenceCommand()
		{
		}

		// Token: 0x0600164C RID: 5708 RVA: 0x0000E951 File Offset: 0x0000CB51
		public LogicPersonalWarPreferenceCommand(int preference)
		{
			this.int_2 = preference;
		}

		// Token: 0x0600164D RID: 5709 RVA: 0x0000E2EC File Offset: 0x0000C4EC
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x0600164E RID: 5710 RVA: 0x0000E960 File Offset: 0x0000CB60
		public override void Decode(ByteStream stream)
		{
			this.int_2 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x0600164F RID: 5711 RVA: 0x0000E975 File Offset: 0x0000CB75
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_2);
			base.Encode(encoder);
		}

		// Token: 0x06001650 RID: 5712 RVA: 0x0000E98A File Offset: 0x0000CB8A
		public override int Execute(LogicLevel level)
		{
			level.GetPlayerAvatar().SetWarPreference(this.int_2);
			return 0;
		}

		// Token: 0x06001651 RID: 5713 RVA: 0x0000ABA0 File Offset: 0x00008DA0
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.PERSONAL_WAR_PREFERENCE_CHANGED;
		}

		// Token: 0x04000C98 RID: 3224
		private int int_2;
	}
}
