using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Command;
using Atrasis.Magic.Logic.Command.Server;
using Atrasis.Magic.Servers.Core.Network.Message.Session.Change;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Servers.Core.Network.Message.Account
{
	// Token: 0x020000C0 RID: 192
	public class GameStateCallbackMessage : ServerAccountMessage
	{
		// Token: 0x1700014D RID: 333
		// (get) Token: 0x0600056E RID: 1390 RVA: 0x00007D0B File Offset: 0x00005F0B
		// (set) Token: 0x0600056F RID: 1391 RVA: 0x00007D13 File Offset: 0x00005F13
		public LogicClientAvatar LogicClientAvatar { get; set; }

		// Token: 0x1700014E RID: 334
		// (get) Token: 0x06000570 RID: 1392 RVA: 0x00007D1C File Offset: 0x00005F1C
		// (set) Token: 0x06000571 RID: 1393 RVA: 0x00007D24 File Offset: 0x00005F24
		public LogicArrayList<AvatarChange> AvatarChanges { get; set; }

		// Token: 0x1700014F RID: 335
		// (get) Token: 0x06000572 RID: 1394 RVA: 0x00007D2D File Offset: 0x00005F2D
		// (set) Token: 0x06000573 RID: 1395 RVA: 0x00007D35 File Offset: 0x00005F35
		public LogicArrayList<LogicServerCommand> ExecutedServerCommands { get; set; }

		// Token: 0x17000150 RID: 336
		// (get) Token: 0x06000574 RID: 1396 RVA: 0x00007D3E File Offset: 0x00005F3E
		// (set) Token: 0x06000575 RID: 1397 RVA: 0x00007D46 File Offset: 0x00005F46
		public int SaveTime { get; set; }

		// Token: 0x17000151 RID: 337
		// (get) Token: 0x06000576 RID: 1398 RVA: 0x00007D4F File Offset: 0x00005F4F
		// (set) Token: 0x06000577 RID: 1399 RVA: 0x00007D57 File Offset: 0x00005F57
		public byte[] HomeJSON { get; set; }

		// Token: 0x17000152 RID: 338
		// (get) Token: 0x06000578 RID: 1400 RVA: 0x00007D60 File Offset: 0x00005F60
		// (set) Token: 0x06000579 RID: 1401 RVA: 0x00007D68 File Offset: 0x00005F68
		public long SessionId { get; set; }

		// Token: 0x0600057A RID: 1402 RVA: 0x0000D50C File Offset: 0x0000B70C
		public override void Encode(ByteStream stream)
		{
			stream.WriteLongLong(this.SessionId);
			stream.WriteVInt(this.AvatarChanges.Size());
			for (int i = 0; i < this.AvatarChanges.Size(); i++)
			{
				AvatarChangeFactory.Encode(stream, this.AvatarChanges[i]);
			}
			if (this.LogicClientAvatar != null)
			{
				stream.WriteBoolean(true);
				this.LogicClientAvatar.Encode(stream);
			}
			else
			{
				stream.WriteBoolean(false);
			}
			if (this.HomeJSON != null)
			{
				stream.WriteBoolean(true);
				if (this.ExecutedServerCommands != null)
				{
					stream.WriteBoolean(true);
					stream.WriteVInt(this.ExecutedServerCommands.Size());
					for (int j = 0; j < this.ExecutedServerCommands.Size(); j++)
					{
						LogicCommandManager.EncodeCommand(stream, this.ExecutedServerCommands[j]);
					}
				}
				else
				{
					stream.WriteBoolean(false);
				}
				stream.WriteVInt(this.SaveTime);
				stream.WriteBytes(this.HomeJSON, this.HomeJSON.Length);
				return;
			}
			stream.WriteBoolean(false);
		}

		// Token: 0x0600057B RID: 1403 RVA: 0x0000D60C File Offset: 0x0000B80C
		public override void Decode(ByteStream stream)
		{
			this.SessionId = stream.ReadLongLong();
			this.AvatarChanges = new LogicArrayList<AvatarChange>();
			for (int i = stream.ReadVInt(); i > 0; i--)
			{
				this.AvatarChanges.Add(AvatarChangeFactory.Decode(stream));
			}
			if (stream.ReadBoolean())
			{
				this.LogicClientAvatar = new LogicClientAvatar();
				this.LogicClientAvatar.Decode(stream);
			}
			if (stream.ReadBoolean())
			{
				if (stream.ReadBoolean())
				{
					this.ExecutedServerCommands = new LogicArrayList<LogicServerCommand>();
					for (int j = stream.ReadVInt(); j > 0; j--)
					{
						this.ExecutedServerCommands.Add((LogicServerCommand)LogicCommandManager.DecodeCommand(stream));
					}
				}
				this.SaveTime = stream.ReadVInt();
				this.HomeJSON = stream.ReadBytes(stream.ReadBytesLength(), 900000);
			}
		}

		// Token: 0x0600057C RID: 1404 RVA: 0x00007D71 File Offset: 0x00005F71
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.GAME_STATE_CALLBACK;
		}

		// Token: 0x04000234 RID: 564
		[CompilerGenerated]
		private LogicClientAvatar logicClientAvatar_0;

		// Token: 0x04000235 RID: 565
		[CompilerGenerated]
		private LogicArrayList<AvatarChange> logicArrayList_0;

		// Token: 0x04000236 RID: 566
		[CompilerGenerated]
		private LogicArrayList<LogicServerCommand> logicArrayList_1;

		// Token: 0x04000237 RID: 567
		[CompilerGenerated]
		private int int_2;

		// Token: 0x04000238 RID: 568
		[CompilerGenerated]
		private byte[] byte_0;

		// Token: 0x04000239 RID: 569
		[CompilerGenerated]
		private long long_0;
	}
}
