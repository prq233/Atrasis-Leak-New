using System;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Message.Alliance.War
{
	// Token: 0x020000CE RID: 206
	public class AllianceWarHistoryEntry
	{
		// Token: 0x060008FE RID: 2302 RVA: 0x000214DC File Offset: 0x0001F6DC
		public void Decode(ByteStream stream)
		{
			this.logicLong_0 = stream.ReadLong();
			this.string_0 = stream.ReadString(900000);
			this.int_0 = stream.ReadInt();
			this.int_1 = stream.ReadInt();
			this.logicLong_1 = stream.ReadLong();
			this.string_1 = stream.ReadString(900000);
			this.int_2 = stream.ReadInt();
			this.int_3 = stream.ReadInt();
			stream.ReadInt();
			stream.ReadInt();
			stream.ReadInt();
			stream.ReadInt();
			stream.ReadInt();
			stream.ReadInt();
			stream.ReadInt();
			stream.ReadInt();
			stream.ReadLong();
			stream.ReadInt();
			this.int_4 = stream.ReadInt();
			this.bool_0 = stream.ReadBoolean();
			this.int_5 = stream.ReadInt();
			stream.ReadLong();
			this.int_6 = stream.ReadInt();
		}

		// Token: 0x060008FF RID: 2303 RVA: 0x000215D0 File Offset: 0x0001F7D0
		public void Encode(ByteStream encoder)
		{
			encoder.WriteLong(this.logicLong_0);
			encoder.WriteString(this.string_0);
			encoder.WriteInt(this.int_0);
			encoder.WriteInt(this.int_1);
			encoder.WriteLong(this.logicLong_1);
			encoder.WriteString(this.string_1);
			encoder.WriteInt(this.int_2);
			encoder.WriteInt(this.int_3);
			encoder.WriteInt(0);
			encoder.WriteInt(0);
			encoder.WriteInt(0);
			encoder.WriteInt(0);
			encoder.WriteInt(0);
			encoder.WriteInt(0);
			encoder.WriteInt(0);
			encoder.WriteInt(0);
			encoder.WriteLong(0L);
			encoder.WriteInt(0);
			encoder.WriteInt(this.int_4);
			encoder.WriteBoolean(this.bool_0);
			encoder.WriteInt(this.int_5);
			encoder.WriteLong(0L);
			encoder.WriteInt(this.int_6);
		}

		// Token: 0x04000370 RID: 880
		private LogicLong logicLong_0;

		// Token: 0x04000371 RID: 881
		private LogicLong logicLong_1;

		// Token: 0x04000372 RID: 882
		private string string_0;

		// Token: 0x04000373 RID: 883
		private string string_1;

		// Token: 0x04000374 RID: 884
		private int int_0;

		// Token: 0x04000375 RID: 885
		private int int_1;

		// Token: 0x04000376 RID: 886
		private int int_2;

		// Token: 0x04000377 RID: 887
		private int int_3;

		// Token: 0x04000378 RID: 888
		private int int_4;

		// Token: 0x04000379 RID: 889
		private bool bool_0;

		// Token: 0x0400037A RID: 890
		private int int_5;

		// Token: 0x0400037B RID: 891
		private int int_6;
	}
}
