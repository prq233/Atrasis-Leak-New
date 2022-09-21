using System;
using Atrasis.Magic.Logic.Command;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Message;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Message.Battle
{
	// Token: 0x0200007B RID: 123
	public class BattleEndClientTurnMessage : PiranhaMessage
	{
		// Token: 0x06000557 RID: 1367 RVA: 0x00005220 File Offset: 0x00003420
		public BattleEndClientTurnMessage() : this(0)
		{
		}

		// Token: 0x06000558 RID: 1368 RVA: 0x0000328C File Offset: 0x0000148C
		public BattleEndClientTurnMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000559 RID: 1369 RVA: 0x0001D38C File Offset: 0x0001B58C
		public override void Decode()
		{
			base.Decode();
			this.int_0 = this.m_stream.ReadInt();
			this.int_1 = this.m_stream.ReadInt();
			int num = this.m_stream.ReadInt();
			if (num <= 512)
			{
				if (num > 0)
				{
					this.logicArrayList_0 = new LogicArrayList<LogicCommand>(num);
					do
					{
						LogicCommand logicCommand = LogicCommandManager.DecodeCommand(this.m_stream);
						if (logicCommand == null)
						{
							return;
						}
						this.logicArrayList_0.Add(logicCommand);
					}
					while (--num != 0);
					return;
				}
			}
			else
			{
				Debugger.Error(string.Format("BattleEndClientTurn::decode() command count is too high! ({0})", num));
			}
		}

		// Token: 0x0600055A RID: 1370 RVA: 0x0001D424 File Offset: 0x0001B624
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt(this.int_0);
			this.m_stream.WriteInt(this.int_1);
			if (this.logicArrayList_0 != null)
			{
				this.m_stream.WriteInt(this.logicArrayList_0.Size());
				for (int i = 0; i < this.logicArrayList_0.Size(); i++)
				{
					LogicCommandManager.EncodeCommand(this.m_stream, this.logicArrayList_0[i]);
				}
				return;
			}
			this.m_stream.WriteInt(-1);
		}

		// Token: 0x0600055B RID: 1371 RVA: 0x00005229 File Offset: 0x00003429
		public override short GetMessageType()
		{
			return 14510;
		}

		// Token: 0x0600055C RID: 1372 RVA: 0x00005230 File Offset: 0x00003430
		public override int GetServiceNodeType()
		{
			return 27;
		}

		// Token: 0x0600055D RID: 1373 RVA: 0x00005234 File Offset: 0x00003434
		public override void Destruct()
		{
			base.Destruct();
			this.logicArrayList_0 = null;
		}

		// Token: 0x0600055E RID: 1374 RVA: 0x00005243 File Offset: 0x00003443
		public int GetSubTick()
		{
			return this.int_0;
		}

		// Token: 0x0600055F RID: 1375 RVA: 0x0000524B File Offset: 0x0000344B
		public void SetSubTick(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x06000560 RID: 1376 RVA: 0x00005254 File Offset: 0x00003454
		public int GetChecksum()
		{
			return this.int_1;
		}

		// Token: 0x06000561 RID: 1377 RVA: 0x0000525C File Offset: 0x0000345C
		public void SetChecksum(int value)
		{
			this.int_1 = value;
		}

		// Token: 0x06000562 RID: 1378 RVA: 0x00005265 File Offset: 0x00003465
		public LogicArrayList<LogicCommand> GetCommands()
		{
			return this.logicArrayList_0;
		}

		// Token: 0x06000563 RID: 1379 RVA: 0x0000526D File Offset: 0x0000346D
		public void SetCommands(LogicArrayList<LogicCommand> commands)
		{
			this.logicArrayList_0 = commands;
		}

		// Token: 0x04000203 RID: 515
		public const int MESSAGE_TYPE = 14510;

		// Token: 0x04000204 RID: 516
		private int int_0;

		// Token: 0x04000205 RID: 517
		private int int_1;

		// Token: 0x04000206 RID: 518
		private LogicArrayList<LogicCommand> logicArrayList_0;
	}
}
