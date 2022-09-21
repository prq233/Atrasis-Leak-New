using System;
using Atrasis.Magic.Logic.Message.Battle;
using Atrasis.Magic.Titan.Message;

namespace ns0
{
	// Token: 0x02000007 RID: 7
	public class GClass4
	{
		// Token: 0x06000013 RID: 19 RVA: 0x00002182 File Offset: 0x00000382
		public GClass4(GClass2 gclass2_1)
		{
			this.gclass2_0 = gclass2_1;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002191 File Offset: 0x00000391
		public void method_0(PiranhaMessage piranhaMessage_0)
		{
			if (piranhaMessage_0.GetMessageType() == 14510)
			{
				this.method_1((BattleEndClientTurnMessage)piranhaMessage_0);
			}
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002828 File Offset: 0x00000A28
		private void method_1(BattleEndClientTurnMessage battleEndClientTurnMessage_0)
		{
			GClass6 gclass = this.gclass2_0.method_1();
			if (gclass != null)
			{
				gclass.method_1(battleEndClientTurnMessage_0.GetSubTick(), battleEndClientTurnMessage_0.GetChecksum(), battleEndClientTurnMessage_0.GetCommands());
			}
		}

		// Token: 0x04000004 RID: 4
		private readonly GClass2 gclass2_0;
	}
}
