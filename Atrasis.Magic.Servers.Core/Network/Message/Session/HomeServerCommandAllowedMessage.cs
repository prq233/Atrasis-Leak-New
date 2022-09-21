using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Command;
using Atrasis.Magic.Logic.Command.Server;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session
{
	// Token: 0x0200003D RID: 61
	public class HomeServerCommandAllowedMessage : ServerSessionMessage
	{
		// Token: 0x17000058 RID: 88
		// (get) Token: 0x06000174 RID: 372 RVA: 0x0000546E File Offset: 0x0000366E
		// (set) Token: 0x06000175 RID: 373 RVA: 0x00005476 File Offset: 0x00003676
		public LogicServerCommand ServerCommand { get; set; }

		// Token: 0x06000176 RID: 374 RVA: 0x0000547F File Offset: 0x0000367F
		public override void Encode(ByteStream stream)
		{
			LogicCommandManager.EncodeCommand(stream, this.ServerCommand);
		}

		// Token: 0x06000177 RID: 375 RVA: 0x0000548D File Offset: 0x0000368D
		public override void Decode(ByteStream stream)
		{
			this.ServerCommand = (LogicServerCommand)LogicCommandManager.DecodeCommand(stream);
		}

		// Token: 0x06000178 RID: 376 RVA: 0x000054A0 File Offset: 0x000036A0
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.HOME_SERVER_COMMAND_ALLOWED;
		}

		// Token: 0x040000F5 RID: 245
		[CompilerGenerated]
		private LogicServerCommand logicServerCommand_0;
	}
}
