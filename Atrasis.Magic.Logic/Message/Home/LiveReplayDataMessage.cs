using System;
using Atrasis.Magic.Logic.Command;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Message;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Message.Home
{
	// Token: 0x02000052 RID: 82
	public class LiveReplayDataMessage : PiranhaMessage
	{
		// Token: 0x060003B2 RID: 946 RVA: 0x000043A5 File Offset: 0x000025A5
		public LiveReplayDataMessage() : this(0)
		{
		}

		// Token: 0x060003B3 RID: 947 RVA: 0x0000328C File Offset: 0x0000148C
		public LiveReplayDataMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x060003B4 RID: 948 RVA: 0x0001C42C File Offset: 0x0001A62C
		public override void Decode()
		{
			base.Decode();
			this.int_0 = this.m_stream.ReadVInt();
			this.int_1 = this.m_stream.ReadVInt();
			this.int_2 = this.m_stream.ReadVInt();
			int num = this.m_stream.ReadInt();
			if (num <= 512)
			{
				if (num > 0)
				{
					this.logicArrayList_0 = new LogicArrayList<LogicCommand>(num);
					for (int i = 0; i < num; i++)
					{
						LogicCommand logicCommand = LogicCommandManager.DecodeCommand(this.m_stream);
						if (logicCommand != null)
						{
							this.logicArrayList_0.Add(logicCommand);
						}
					}
					return;
				}
			}
			else
			{
				Debugger.Error(string.Format("LiveReplayDataMessage::decode() command count is too high! ({0})", num));
			}
		}

		// Token: 0x060003B5 RID: 949 RVA: 0x0001C4D4 File Offset: 0x0001A6D4
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteVInt(this.int_0);
			this.m_stream.WriteVInt(this.int_1);
			this.m_stream.WriteVInt(this.int_2);
			if (this.logicArrayList_0 != null)
			{
				this.m_stream.WriteInt(this.logicArrayList_0.Size());
				for (int i = 0; i < this.logicArrayList_0.Size(); i++)
				{
					LogicCommandManager.EncodeCommand(this.m_stream, this.logicArrayList_0[i]);
				}
				return;
			}
			this.m_stream.WriteInt(0);
		}

		// Token: 0x060003B6 RID: 950 RVA: 0x000043AE File Offset: 0x000025AE
		public override short GetMessageType()
		{
			return 24119;
		}

		// Token: 0x060003B7 RID: 951 RVA: 0x00003F09 File Offset: 0x00002109
		public override int GetServiceNodeType()
		{
			return 9;
		}

		// Token: 0x060003B8 RID: 952 RVA: 0x000043B5 File Offset: 0x000025B5
		public override void Destruct()
		{
			base.Destruct();
			this.logicArrayList_0 = null;
		}

		// Token: 0x060003B9 RID: 953 RVA: 0x000043C4 File Offset: 0x000025C4
		public int GetServerSubTick()
		{
			return this.int_0;
		}

		// Token: 0x060003BA RID: 954 RVA: 0x000043CC File Offset: 0x000025CC
		public void SetServerSubTick(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x060003BB RID: 955 RVA: 0x000043D5 File Offset: 0x000025D5
		public void SetViewerCount(int value)
		{
			this.int_1 = value;
		}

		// Token: 0x060003BC RID: 956 RVA: 0x000043DE File Offset: 0x000025DE
		public int GetViewerCount()
		{
			return this.int_1;
		}

		// Token: 0x060003BD RID: 957 RVA: 0x000043E6 File Offset: 0x000025E6
		public void SetEnemyViewerCount(int value)
		{
			this.int_2 = value;
		}

		// Token: 0x060003BE RID: 958 RVA: 0x000043EF File Offset: 0x000025EF
		public int GetEnemyViewerCount()
		{
			return this.int_2;
		}

		// Token: 0x060003BF RID: 959 RVA: 0x000043F7 File Offset: 0x000025F7
		public LogicArrayList<LogicCommand> GetCommands()
		{
			return this.logicArrayList_0;
		}

		// Token: 0x060003C0 RID: 960 RVA: 0x000043FF File Offset: 0x000025FF
		public void SetCommands(LogicArrayList<LogicCommand> commands)
		{
			this.logicArrayList_0 = commands;
		}

		// Token: 0x0400016F RID: 367
		public const int MESSAGE_TYPE = 24119;

		// Token: 0x04000170 RID: 368
		private int int_0;

		// Token: 0x04000171 RID: 369
		private int int_1;

		// Token: 0x04000172 RID: 370
		private int int_2;

		// Token: 0x04000173 RID: 371
		private LogicArrayList<LogicCommand> logicArrayList_0;
	}
}
