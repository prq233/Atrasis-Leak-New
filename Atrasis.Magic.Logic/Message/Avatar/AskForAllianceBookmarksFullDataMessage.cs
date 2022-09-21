using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Avatar
{
	// Token: 0x0200007F RID: 127
	public class AskForAllianceBookmarksFullDataMessage : PiranhaMessage
	{
		// Token: 0x06000585 RID: 1413 RVA: 0x0000535C File Offset: 0x0000355C
		public AskForAllianceBookmarksFullDataMessage() : this(0)
		{
		}

		// Token: 0x06000586 RID: 1414 RVA: 0x0000328C File Offset: 0x0000148C
		public AskForAllianceBookmarksFullDataMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000587 RID: 1415 RVA: 0x00003E25 File Offset: 0x00002025
		public override void Decode()
		{
			base.Decode();
		}

		// Token: 0x06000588 RID: 1416 RVA: 0x00003E2D File Offset: 0x0000202D
		public override void Encode()
		{
			base.Encode();
		}

		// Token: 0x06000589 RID: 1417 RVA: 0x00005365 File Offset: 0x00003565
		public override short GetMessageType()
		{
			return 14341;
		}

		// Token: 0x0600058A RID: 1418 RVA: 0x00003F09 File Offset: 0x00002109
		public override int GetServiceNodeType()
		{
			return 9;
		}

		// Token: 0x0600058B RID: 1419 RVA: 0x0000341E File Offset: 0x0000161E
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x04000210 RID: 528
		public const int MESSAGE_TYPE = 14341;
	}
}
