using System;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Message.Avatar
{
	// Token: 0x0200008C RID: 140
	public class BookmarksListMessage : PiranhaMessage
	{
		// Token: 0x060005F0 RID: 1520 RVA: 0x000057B1 File Offset: 0x000039B1
		public BookmarksListMessage() : this(0)
		{
		}

		// Token: 0x060005F1 RID: 1521 RVA: 0x0000328C File Offset: 0x0000148C
		public BookmarksListMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x060005F2 RID: 1522 RVA: 0x0001D8BC File Offset: 0x0001BABC
		public override void Decode()
		{
			base.Decode();
			int num = this.m_stream.ReadInt();
			if (num >= 0)
			{
				Debugger.DoAssert(num < 1000, "Too many alliance ids in BookmarksListMessage");
				this.logicArrayList_0 = new LogicArrayList<LogicLong>(num);
				for (int i = 0; i < num; i++)
				{
					this.logicArrayList_0.Add(this.m_stream.ReadLong());
				}
			}
		}

		// Token: 0x060005F3 RID: 1523 RVA: 0x0001D920 File Offset: 0x0001BB20
		public override void Encode()
		{
			base.Encode();
			if (this.logicArrayList_0 != null)
			{
				this.m_stream.WriteInt(this.logicArrayList_0.Size());
				for (int i = 0; i < this.logicArrayList_0.Size(); i++)
				{
					this.m_stream.WriteLong(this.logicArrayList_0[i]);
				}
				return;
			}
			this.m_stream.WriteInt(-1);
		}

		// Token: 0x060005F4 RID: 1524 RVA: 0x000057BA File Offset: 0x000039BA
		public override short GetMessageType()
		{
			return 24340;
		}

		// Token: 0x060005F5 RID: 1525 RVA: 0x00003F09 File Offset: 0x00002109
		public override int GetServiceNodeType()
		{
			return 9;
		}

		// Token: 0x060005F6 RID: 1526 RVA: 0x000057C1 File Offset: 0x000039C1
		public override void Destruct()
		{
			base.Destruct();
			this.logicArrayList_0 = null;
		}

		// Token: 0x060005F7 RID: 1527 RVA: 0x000057D0 File Offset: 0x000039D0
		public LogicArrayList<LogicLong> GetAllianceIds()
		{
			return this.logicArrayList_0;
		}

		// Token: 0x060005F8 RID: 1528 RVA: 0x000057D8 File Offset: 0x000039D8
		public void SetAllianceIds(LogicArrayList<LogicLong> list)
		{
			this.logicArrayList_0 = list;
		}

		// Token: 0x0400023D RID: 573
		public const int MESSAGE_TYPE = 24340;

		// Token: 0x0400023E RID: 574
		private LogicArrayList<LogicLong> logicArrayList_0;
	}
}
