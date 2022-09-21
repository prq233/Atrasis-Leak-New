using System;
using Atrasis.Magic.Logic.Command;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Home
{
	// Token: 0x02000045 RID: 69
	public class AvailableServerCommandMessage : PiranhaMessage
	{
		// Token: 0x06000330 RID: 816 RVA: 0x00003F2F File Offset: 0x0000212F
		public AvailableServerCommandMessage() : this(0)
		{
		}

		// Token: 0x06000331 RID: 817 RVA: 0x0000328C File Offset: 0x0000148C
		public AvailableServerCommandMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000332 RID: 818 RVA: 0x00003F38 File Offset: 0x00002138
		public override void Decode()
		{
			base.Decode();
			this.logicCommand_0 = LogicCommandManager.DecodeCommand(this.m_stream);
		}

		// Token: 0x06000333 RID: 819 RVA: 0x00003F51 File Offset: 0x00002151
		public override void Encode()
		{
			base.Encode();
			LogicCommandManager.EncodeCommand(this.m_stream, this.logicCommand_0);
		}

		// Token: 0x06000334 RID: 820 RVA: 0x00003F6A File Offset: 0x0000216A
		public override short GetMessageType()
		{
			return 24111;
		}

		// Token: 0x06000335 RID: 821 RVA: 0x00003D3D File Offset: 0x00001F3D
		public override int GetServiceNodeType()
		{
			return 10;
		}

		// Token: 0x06000336 RID: 822 RVA: 0x00003F71 File Offset: 0x00002171
		public override void Destruct()
		{
			base.Destruct();
			this.logicCommand_0 = null;
		}

		// Token: 0x06000337 RID: 823 RVA: 0x00003F80 File Offset: 0x00002180
		public LogicCommand RemoveServerCommand()
		{
			LogicCommand result = this.logicCommand_0;
			this.logicCommand_0 = null;
			return result;
		}

		// Token: 0x06000338 RID: 824 RVA: 0x00003F8F File Offset: 0x0000218F
		public void SetServerCommand(LogicCommand command)
		{
			this.logicCommand_0 = command;
		}

		// Token: 0x04000141 RID: 321
		public const int MESSAGE_TYPE = 24111;

		// Token: 0x04000142 RID: 322
		private LogicCommand logicCommand_0;
	}
}
