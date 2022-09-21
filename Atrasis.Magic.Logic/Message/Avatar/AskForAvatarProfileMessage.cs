using System;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Avatar
{
	// Token: 0x02000080 RID: 128
	public class AskForAvatarProfileMessage : PiranhaMessage
	{
		// Token: 0x0600058C RID: 1420 RVA: 0x0000536C File Offset: 0x0000356C
		public AskForAvatarProfileMessage() : this(0)
		{
		}

		// Token: 0x0600058D RID: 1421 RVA: 0x0000328C File Offset: 0x0000148C
		public AskForAvatarProfileMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x0600058E RID: 1422 RVA: 0x0001D644 File Offset: 0x0001B844
		public override void Decode()
		{
			base.Decode();
			this.logicLong_0 = this.m_stream.ReadLong();
			if (this.m_stream.ReadBoolean())
			{
				this.logicLong_1 = this.m_stream.ReadLong();
			}
			this.m_stream.ReadBoolean();
		}

		// Token: 0x0600058F RID: 1423 RVA: 0x0001D694 File Offset: 0x0001B894
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteLong(this.logicLong_0);
			if (this.logicLong_1 != null)
			{
				this.m_stream.WriteBoolean(true);
				this.m_stream.WriteLong(this.logicLong_1);
			}
			else
			{
				this.m_stream.WriteBoolean(false);
			}
			this.m_stream.WriteBoolean(false);
		}

		// Token: 0x06000590 RID: 1424 RVA: 0x00005375 File Offset: 0x00003575
		public override short GetMessageType()
		{
			return 14325;
		}

		// Token: 0x06000591 RID: 1425 RVA: 0x00003F09 File Offset: 0x00002109
		public override int GetServiceNodeType()
		{
			return 9;
		}

		// Token: 0x06000592 RID: 1426 RVA: 0x0000537C File Offset: 0x0000357C
		public override void Destruct()
		{
			base.Destruct();
			this.logicLong_0 = null;
			this.logicLong_1 = null;
		}

		// Token: 0x06000593 RID: 1427 RVA: 0x00005392 File Offset: 0x00003592
		public LogicLong RemoveAvatarId()
		{
			LogicLong result = this.logicLong_0;
			this.logicLong_0 = null;
			return result;
		}

		// Token: 0x06000594 RID: 1428 RVA: 0x000053A1 File Offset: 0x000035A1
		public void SetAvatarId(LogicLong id)
		{
			this.logicLong_0 = id;
		}

		// Token: 0x06000595 RID: 1429 RVA: 0x000053AA File Offset: 0x000035AA
		public LogicLong RemoveHomeId()
		{
			LogicLong result = this.logicLong_1;
			this.logicLong_1 = null;
			return result;
		}

		// Token: 0x06000596 RID: 1430 RVA: 0x000053B9 File Offset: 0x000035B9
		public void SetHomeId(LogicLong id)
		{
			this.logicLong_1 = id;
		}

		// Token: 0x04000211 RID: 529
		public const int MESSAGE_TYPE = 14325;

		// Token: 0x04000212 RID: 530
		private LogicLong logicLong_0;

		// Token: 0x04000213 RID: 531
		private LogicLong logicLong_1;
	}
}
