using System;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;

namespace Atrasis.Magic.Logic.Command.Battle
{
	// Token: 0x020001E8 RID: 488
	public sealed class LogicEndAttackPreparationCommand : LogicCommand
	{
		// Token: 0x060018F7 RID: 6391 RVA: 0x0000EC66 File Offset: 0x0000CE66
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
		}

		// Token: 0x060018F8 RID: 6392 RVA: 0x0000EC6F File Offset: 0x0000CE6F
		public override void Encode(ChecksumEncoder encoder)
		{
			base.Encode(encoder);
		}

		// Token: 0x060018F9 RID: 6393 RVA: 0x0001095A File Offset: 0x0000EB5A
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.END_ATTACK_PREPARATION;
		}

		// Token: 0x060018FA RID: 6394 RVA: 0x0000EB45 File Offset: 0x0000CD45
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x060018FB RID: 6395 RVA: 0x00002B30 File Offset: 0x00000D30
		public override int Execute(LogicLevel level)
		{
			return -1;
		}

		// Token: 0x060018FC RID: 6396 RVA: 0x0005F070 File Offset: 0x0005D270
		public override void LoadFromJSON(LogicJSONObject jsonRoot)
		{
			LogicJSONObject jsonobject = jsonRoot.GetJSONObject("base");
			if (jsonobject == null)
			{
				Debugger.Error("Replay LogicEndAttackPreparationCommand load failed! Base missing!");
			}
			base.LoadFromJSON(jsonobject);
		}

		// Token: 0x060018FD RID: 6397 RVA: 0x00010961 File Offset: 0x0000EB61
		public override LogicJSONObject GetJSONForReplay()
		{
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			logicJSONObject.Put("base", base.GetJSONForReplay());
			return logicJSONObject;
		}
	}
}
