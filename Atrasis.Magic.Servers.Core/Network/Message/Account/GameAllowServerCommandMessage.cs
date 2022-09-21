using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Command;
using Atrasis.Magic.Logic.Command.Server;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Account
{
	// Token: 0x020000BE RID: 190
	public class GameAllowServerCommandMessage : ServerAccountMessage
	{
		// Token: 0x1700014A RID: 330
		// (get) Token: 0x06000560 RID: 1376 RVA: 0x00007C5F File Offset: 0x00005E5F
		// (set) Token: 0x06000561 RID: 1377 RVA: 0x00007C67 File Offset: 0x00005E67
		public LogicServerCommand ServerCommand { get; set; }

		// Token: 0x06000562 RID: 1378 RVA: 0x00007C70 File Offset: 0x00005E70
		public override void Encode(ByteStream stream)
		{
			LogicCommandManager.EncodeCommand(stream, this.ServerCommand);
		}

		// Token: 0x06000563 RID: 1379 RVA: 0x00007C7E File Offset: 0x00005E7E
		public override void Decode(ByteStream stream)
		{
			this.ServerCommand = (LogicServerCommand)LogicCommandManager.DecodeCommand(stream);
		}

		// Token: 0x06000564 RID: 1380 RVA: 0x00007C91 File Offset: 0x00005E91
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.GAME_ALLOW_SERVER_COMMAND;
		}

		// Token: 0x04000231 RID: 561
		[CompilerGenerated]
		private LogicServerCommand logicServerCommand_0;
	}
}
