using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Command;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Servers.Core.Network.Message.Account
{
	// Token: 0x020000B7 RID: 183
	public class ClientUpdateLiveReplayMessage : ServerAccountMessage
	{
		// Token: 0x1700013C RID: 316
		// (get) Token: 0x06000528 RID: 1320 RVA: 0x00007A66 File Offset: 0x00005C66
		// (set) Token: 0x06000529 RID: 1321 RVA: 0x00007A6E File Offset: 0x00005C6E
		public int SubTick { get; set; }

		// Token: 0x1700013D RID: 317
		// (get) Token: 0x0600052A RID: 1322 RVA: 0x00007A77 File Offset: 0x00005C77
		// (set) Token: 0x0600052B RID: 1323 RVA: 0x00007A7F File Offset: 0x00005C7F
		public LogicArrayList<LogicCommand> Commands { get; set; }

		// Token: 0x0600052C RID: 1324 RVA: 0x0000D39C File Offset: 0x0000B59C
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt(this.SubTick);
			if (this.Commands != null)
			{
				stream.WriteVInt(this.Commands.Size());
				for (int i = 0; i < this.Commands.Size(); i++)
				{
					LogicCommandManager.EncodeCommand(stream, this.Commands[i]);
				}
				return;
			}
			stream.WriteVInt(-1);
		}

		// Token: 0x0600052D RID: 1325 RVA: 0x0000D400 File Offset: 0x0000B600
		public override void Decode(ByteStream stream)
		{
			this.SubTick = stream.ReadVInt();
			int num = stream.ReadVInt();
			if (num >= 0)
			{
				this.Commands = new LogicArrayList<LogicCommand>(num);
				for (int i = 0; i < num; i++)
				{
					this.Commands.Add(LogicCommandManager.DecodeCommand(stream));
				}
			}
		}

		// Token: 0x0600052E RID: 1326 RVA: 0x00007A88 File Offset: 0x00005C88
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.CLIENT_UPDATE_LIVE_REPLAY;
		}

		// Token: 0x04000223 RID: 547
		[CompilerGenerated]
		private int int_2;

		// Token: 0x04000224 RID: 548
		[CompilerGenerated]
		private LogicArrayList<LogicCommand> logicArrayList_0;
	}
}
