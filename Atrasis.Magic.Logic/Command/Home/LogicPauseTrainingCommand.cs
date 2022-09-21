using System;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Unit;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001B3 RID: 435
	public sealed class LogicPauseTrainingCommand : LogicCommand
	{
		// Token: 0x06001790 RID: 6032 RVA: 0x0000EB66 File Offset: 0x0000CD66
		public LogicPauseTrainingCommand()
		{
		}

		// Token: 0x06001791 RID: 6033 RVA: 0x0000F82D File Offset: 0x0000DA2D
		public LogicPauseTrainingCommand(bool disabled, int index)
		{
			this.bool_0 = disabled;
			this.int_1 = index;
		}

		// Token: 0x06001792 RID: 6034 RVA: 0x0000F843 File Offset: 0x0000DA43
		public override void Decode(ByteStream stream)
		{
			this.bool_0 = stream.ReadBoolean();
			this.int_1 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x06001793 RID: 6035 RVA: 0x0000F864 File Offset: 0x0000DA64
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteBoolean(this.bool_0);
			encoder.WriteInt(this.int_1);
			base.Encode(encoder);
		}

		// Token: 0x06001794 RID: 6036 RVA: 0x0000F885 File Offset: 0x0000DA85
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.PAUSE_TRAINING;
		}

		// Token: 0x06001795 RID: 6037 RVA: 0x00059DD8 File Offset: 0x00057FD8
		public override int Execute(LogicLevel level)
		{
			if (level.GetVillageType() != 0)
			{
				return -32;
			}
			LogicUnitProduction logicUnitProduction = null;
			int num = this.int_1;
			if (num != 1)
			{
				if (num == 2)
				{
					logicUnitProduction = level.GetGameObjectManagerAt(0).GetSpellProduction();
				}
			}
			else
			{
				logicUnitProduction = level.GetGameObjectManagerAt(0).GetUnitProduction();
			}
			if (logicUnitProduction == null)
			{
				return -1;
			}
			logicUnitProduction.SetLocked(this.bool_0);
			return 0;
		}

		// Token: 0x04000CEE RID: 3310
		private bool bool_0;

		// Token: 0x04000CEF RID: 3311
		private int int_1;
	}
}
