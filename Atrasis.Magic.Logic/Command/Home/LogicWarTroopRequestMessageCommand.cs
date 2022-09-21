using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001E3 RID: 483
	public sealed class LogicWarTroopRequestMessageCommand : LogicCommand
	{
		// Token: 0x060018D1 RID: 6353 RVA: 0x00010858 File Offset: 0x0000EA58
		public override void Decode(ByteStream stream)
		{
			this.string_0 = stream.ReadString(900000);
			base.Decode(stream);
		}

		// Token: 0x060018D2 RID: 6354 RVA: 0x00010872 File Offset: 0x0000EA72
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteString(this.string_0);
			base.Encode(encoder);
		}

		// Token: 0x060018D3 RID: 6355 RVA: 0x00010887 File Offset: 0x0000EA87
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.WAR_TROOP_REQUEST_MESSAGE;
		}

		// Token: 0x060018D4 RID: 6356 RVA: 0x0001088E File Offset: 0x0000EA8E
		public override void Destruct()
		{
			base.Destruct();
			this.string_0 = null;
		}

		// Token: 0x060018D5 RID: 6357 RVA: 0x0005CF54 File Offset: 0x0005B154
		public override int Execute(LogicLevel level)
		{
			level.SetWarTroopRequestMessage(this.string_0);
			LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
			if (playerAvatar != null)
			{
				playerAvatar.GetChangeListener().WarTroopRequestMessageChanged(this.string_0);
			}
			return 0;
		}

		// Token: 0x04000D49 RID: 3401
		private string string_0;
	}
}
