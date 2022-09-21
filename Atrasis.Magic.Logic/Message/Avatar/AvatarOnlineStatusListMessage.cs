using System;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Message.Avatar
{
	// Token: 0x02000086 RID: 134
	public class AvatarOnlineStatusListMessage : PiranhaMessage
	{
		// Token: 0x060005B6 RID: 1462 RVA: 0x00005549 File Offset: 0x00003749
		public AvatarOnlineStatusListMessage() : this(0)
		{
		}

		// Token: 0x060005B7 RID: 1463 RVA: 0x0000328C File Offset: 0x0000148C
		public AvatarOnlineStatusListMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x060005B8 RID: 1464 RVA: 0x0001D6F8 File Offset: 0x0001B8F8
		public override void Decode()
		{
			base.Decode();
			for (int i = this.m_stream.ReadVInt(); i > 0; i--)
			{
				this.logicArrayList_0.Add(this.m_stream.ReadVInt());
				this.logicArrayList_1.Add(this.m_stream.ReadLong());
			}
			if (!this.m_stream.IsAtEnd())
			{
				this.int_0 = this.m_stream.ReadVInt();
			}
		}

		// Token: 0x060005B9 RID: 1465 RVA: 0x0001D76C File Offset: 0x0001B96C
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteVInt(this.logicArrayList_1.Size());
			for (int i = 0; i < this.logicArrayList_1.Size(); i++)
			{
				this.m_stream.WriteVInt(this.logicArrayList_0[i]);
				this.m_stream.WriteLong(this.logicArrayList_1[i]);
			}
			this.m_stream.WriteVInt(this.int_0);
		}

		// Token: 0x060005BA RID: 1466 RVA: 0x00005552 File Offset: 0x00003752
		public override short GetMessageType()
		{
			return 20208;
		}

		// Token: 0x060005BB RID: 1467 RVA: 0x00003F09 File Offset: 0x00002109
		public override int GetServiceNodeType()
		{
			return 9;
		}

		// Token: 0x060005BC RID: 1468 RVA: 0x00005559 File Offset: 0x00003759
		public override void Destruct()
		{
			base.Destruct();
			this.logicArrayList_1 = null;
		}

		// Token: 0x060005BD RID: 1469 RVA: 0x00005568 File Offset: 0x00003768
		public LogicArrayList<int> GetAvatarStatus()
		{
			return this.logicArrayList_0;
		}

		// Token: 0x060005BE RID: 1470 RVA: 0x00005570 File Offset: 0x00003770
		public void SetAvatarStatusList(LogicArrayList<int> value)
		{
			this.logicArrayList_0 = value;
		}

		// Token: 0x060005BF RID: 1471 RVA: 0x00005579 File Offset: 0x00003779
		public LogicArrayList<LogicLong> GetAvatarIdList()
		{
			return this.logicArrayList_1;
		}

		// Token: 0x060005C0 RID: 1472 RVA: 0x00005581 File Offset: 0x00003781
		public void SetAvatarIdList(LogicArrayList<LogicLong> value)
		{
			this.logicArrayList_1 = value;
		}

		// Token: 0x060005C1 RID: 1473 RVA: 0x0000558A File Offset: 0x0000378A
		public int GetListType()
		{
			return this.int_0;
		}

		// Token: 0x060005C2 RID: 1474 RVA: 0x00005592 File Offset: 0x00003792
		public void SetListType(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x04000228 RID: 552
		public const int MESSAGE_TYPE = 20208;

		// Token: 0x04000229 RID: 553
		private LogicArrayList<int> logicArrayList_0;

		// Token: 0x0400022A RID: 554
		private LogicArrayList<LogicLong> logicArrayList_1;

		// Token: 0x0400022B RID: 555
		private int int_0;
	}
}
