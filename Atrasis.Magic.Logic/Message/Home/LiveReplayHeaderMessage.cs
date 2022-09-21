using System;
using Atrasis.Magic.Logic.Command;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Message;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Message.Home
{
	// Token: 0x02000056 RID: 86
	public class LiveReplayHeaderMessage : PiranhaMessage
	{
		// Token: 0x060003CF RID: 975 RVA: 0x0000446B File Offset: 0x0000266B
		public LiveReplayHeaderMessage() : this(0)
		{
		}

		// Token: 0x060003D0 RID: 976 RVA: 0x0000328C File Offset: 0x0000148C
		public LiveReplayHeaderMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x060003D1 RID: 977 RVA: 0x0001C574 File Offset: 0x0001A774
		public override void Decode()
		{
			base.Decode();
			this.string_0 = this.m_stream.ReadString(900000);
			this.byte_0 = this.m_stream.ReadBytes(this.m_stream.ReadBytesLength(), 900000);
			this.int_0 = this.m_stream.ReadInt();
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
				}
			}
			else
			{
				Debugger.Error(string.Format("LiveReplayHeaderMessage::decode() command count is too high! ({0})", num));
			}
			this.m_stream.ReadInt();
		}

		// Token: 0x060003D2 RID: 978 RVA: 0x0001C640 File Offset: 0x0001A840
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteString(this.string_0);
			this.m_stream.WriteBytes(this.byte_0, this.byte_0.Length);
			this.m_stream.WriteInt(this.int_0);
			if (this.logicArrayList_0 != null)
			{
				this.m_stream.WriteInt(this.logicArrayList_0.Size());
				for (int i = 0; i < this.logicArrayList_0.Size(); i++)
				{
					LogicCommandManager.EncodeCommand(this.m_stream, this.logicArrayList_0[i]);
				}
			}
			else
			{
				this.m_stream.WriteInt(0);
			}
			this.m_stream.WriteInt(0);
		}

		// Token: 0x060003D3 RID: 979 RVA: 0x00004474 File Offset: 0x00002674
		public override short GetMessageType()
		{
			return 24118;
		}

		// Token: 0x060003D4 RID: 980 RVA: 0x00003F09 File Offset: 0x00002109
		public override int GetServiceNodeType()
		{
			return 9;
		}

		// Token: 0x060003D5 RID: 981 RVA: 0x0000447B File Offset: 0x0000267B
		public override void Destruct()
		{
			base.Destruct();
			this.byte_0 = null;
			this.logicArrayList_0 = null;
		}

		// Token: 0x060003D6 RID: 982 RVA: 0x00004491 File Offset: 0x00002691
		public int GetServerSubTick()
		{
			return this.int_0;
		}

		// Token: 0x060003D7 RID: 983 RVA: 0x00004499 File Offset: 0x00002699
		public void SetServerSubTick(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x060003D8 RID: 984 RVA: 0x000044A2 File Offset: 0x000026A2
		public LogicArrayList<LogicCommand> GetCommands()
		{
			return this.logicArrayList_0;
		}

		// Token: 0x060003D9 RID: 985 RVA: 0x000044AA File Offset: 0x000026AA
		public void SetCommands(LogicArrayList<LogicCommand> commands)
		{
			this.logicArrayList_0 = commands;
		}

		// Token: 0x060003DA RID: 986 RVA: 0x000044B3 File Offset: 0x000026B3
		public void SetCompressedStreamHeaderJson(byte[] value)
		{
			this.byte_0 = value;
		}

		// Token: 0x060003DB RID: 987 RVA: 0x000044BC File Offset: 0x000026BC
		public byte[] RemoveCompressedstreamHeaderJson()
		{
			byte[] result = this.byte_0;
			this.byte_0 = null;
			return result;
		}

		// Token: 0x0400017B RID: 379
		public const int MESSAGE_TYPE = 24118;

		// Token: 0x0400017C RID: 380
		private int int_0;

		// Token: 0x0400017D RID: 381
		private string string_0;

		// Token: 0x0400017E RID: 382
		private byte[] byte_0;

		// Token: 0x0400017F RID: 383
		private LogicArrayList<LogicCommand> logicArrayList_0;
	}
}
