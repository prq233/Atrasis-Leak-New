using System;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;

namespace Atrasis.Magic.Logic.Command
{
	// Token: 0x0200016C RID: 364
	public class LogicCommand
	{
		// Token: 0x060015B0 RID: 5552 RVA: 0x0000E1E9 File Offset: 0x0000C3E9
		public LogicCommand()
		{
			this.int_0 = -1;
		}

		// Token: 0x060015B1 RID: 5553 RVA: 0x00002465 File Offset: 0x00000665
		public virtual bool IsServerCommand()
		{
			return false;
		}

		// Token: 0x060015B2 RID: 5554 RVA: 0x00002465 File Offset: 0x00000665
		public virtual LogicCommandType GetCommandType()
		{
			return (LogicCommandType)0;
		}

		// Token: 0x060015B3 RID: 5555 RVA: 0x0000E1F8 File Offset: 0x0000C3F8
		public virtual void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_0);
		}

		// Token: 0x060015B4 RID: 5556 RVA: 0x0000E206 File Offset: 0x0000C406
		public virtual void Decode(ByteStream stream)
		{
			this.int_0 = stream.ReadInt();
		}

		// Token: 0x060015B5 RID: 5557 RVA: 0x00002465 File Offset: 0x00000665
		public virtual int Execute(LogicLevel level)
		{
			return 0;
		}

		// Token: 0x060015B6 RID: 5558 RVA: 0x0000E214 File Offset: 0x0000C414
		public virtual LogicJSONObject GetJSONForReplay()
		{
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			logicJSONObject.Put("t", new LogicJSONNumber(this.int_0));
			return logicJSONObject;
		}

		// Token: 0x060015B7 RID: 5559 RVA: 0x00053BD8 File Offset: 0x00051DD8
		public virtual void LoadFromJSON(LogicJSONObject jsonRoot)
		{
			LogicJSONNumber jsonnumber = jsonRoot.GetJSONNumber("t");
			if (jsonnumber != null)
			{
				this.int_0 = jsonnumber.GetIntValue();
				return;
			}
			Debugger.Error("Replay - Load command from JSON failed! Execute sub tick was not found!");
		}

		// Token: 0x060015B8 RID: 5560 RVA: 0x0000E231 File Offset: 0x0000C431
		public virtual void Destruct()
		{
			this.int_0 = -1;
		}

		// Token: 0x060015B9 RID: 5561 RVA: 0x0000E23A File Offset: 0x0000C43A
		public void SetExecuteSubTick(int tick)
		{
			this.int_0 = tick;
		}

		// Token: 0x060015BA RID: 5562 RVA: 0x0000E243 File Offset: 0x0000C443
		public int GetExecuteSubTick()
		{
			return this.int_0;
		}

		// Token: 0x04000BD3 RID: 3027
		private int int_0;
	}
}
