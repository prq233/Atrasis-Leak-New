using System;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001A4 RID: 420
	public sealed class LogicFreeWorkerCommand : LogicCommand
	{
		// Token: 0x06001731 RID: 5937 RVA: 0x0000EB66 File Offset: 0x0000CD66
		public LogicFreeWorkerCommand()
		{
		}

		// Token: 0x06001732 RID: 5938 RVA: 0x0000F2B2 File Offset: 0x0000D4B2
		public LogicFreeWorkerCommand(LogicCommand resourceCommand, int villageType)
		{
			this.logicCommand_0 = resourceCommand;
			this.int_1 = villageType;
		}

		// Token: 0x06001733 RID: 5939 RVA: 0x0000F2C8 File Offset: 0x0000D4C8
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
			this.int_1 = stream.ReadInt();
			if (stream.ReadBoolean())
			{
				this.logicCommand_0 = LogicCommandManager.DecodeCommand(stream);
			}
		}

		// Token: 0x06001734 RID: 5940 RVA: 0x0000F2F1 File Offset: 0x0000D4F1
		public override void Encode(ChecksumEncoder encoder)
		{
			base.Encode(encoder);
			encoder.WriteInt(this.int_1);
			if (this.logicCommand_0 != null)
			{
				encoder.WriteBoolean(true);
				LogicCommandManager.EncodeCommand(encoder, this.logicCommand_0);
				return;
			}
			encoder.WriteBoolean(false);
		}

		// Token: 0x06001735 RID: 5941 RVA: 0x0000F329 File Offset: 0x0000D529
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.FREE_WORKER;
		}

		// Token: 0x06001736 RID: 5942 RVA: 0x0000F330 File Offset: 0x0000D530
		public override void Destruct()
		{
			base.Destruct();
			if (this.logicCommand_0 != null)
			{
				this.logicCommand_0.Destruct();
				this.logicCommand_0 = null;
			}
		}

		// Token: 0x06001737 RID: 5943 RVA: 0x0005892C File Offset: 0x00056B2C
		public override int Execute(LogicLevel level)
		{
			int index = (this.int_1 != -1) ? this.int_1 : level.GetVillageType();
			if (level.GetWorkerManagerAt(index).GetFreeWorkers() == 0 && level.GetWorkerManagerAt(index).FinishTaskOfOneWorker())
			{
				if (this.logicCommand_0 != null)
				{
					int commandType = (int)this.logicCommand_0.GetCommandType();
					if (commandType < 1000 && commandType >= 500 && commandType < 700)
					{
						this.logicCommand_0.Execute(level);
					}
				}
				return 0;
			}
			return -1;
		}

		// Token: 0x04000CD0 RID: 3280
		private int int_1;

		// Token: 0x04000CD1 RID: 3281
		private LogicCommand logicCommand_0;
	}
}
