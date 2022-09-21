using System;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Message.Alliance.War.Event
{
	// Token: 0x020000D2 RID: 210
	public class AttackWarEventEntry : WarEventEntry
	{
		// Token: 0x06000921 RID: 2337 RVA: 0x000072F7 File Offset: 0x000054F7
		public AttackWarEventEntry()
		{
			this.string_0 = string.Empty;
			this.string_1 = string.Empty;
		}

		// Token: 0x06000922 RID: 2338 RVA: 0x00021B54 File Offset: 0x0001FD54
		public override void Encode(ByteStream stream)
		{
			base.Encode(stream);
			stream.WriteLong(this.logicLong_4);
			stream.WriteLong(this.logicLong_1);
			stream.WriteLong(this.logicLong_2);
			stream.WriteLong(this.logicLong_3);
			stream.WriteString(this.string_1);
			stream.WriteString(this.string_0);
			stream.WriteInt(1);
			stream.WriteInt(2);
			stream.WriteInt(3);
			stream.WriteInt(4);
			stream.WriteInt(5);
			stream.WriteInt(6);
			stream.WriteInt(7);
			if (this.logicLong_5 != null)
			{
				stream.WriteBoolean(true);
				stream.WriteInt(this.int_3);
				stream.WriteLong(this.logicLong_5);
			}
			else
			{
				stream.WriteBoolean(false);
			}
			stream.WriteInt(8);
		}

		// Token: 0x06000923 RID: 2339 RVA: 0x00002B36 File Offset: 0x00000D36
		public override int GetWarEventEntryType()
		{
			return 1;
		}

		// Token: 0x04000387 RID: 903
		private LogicLong logicLong_1;

		// Token: 0x04000388 RID: 904
		private LogicLong logicLong_2;

		// Token: 0x04000389 RID: 905
		private LogicLong logicLong_3;

		// Token: 0x0400038A RID: 906
		private LogicLong logicLong_4;

		// Token: 0x0400038B RID: 907
		private readonly string string_0;

		// Token: 0x0400038C RID: 908
		private readonly string string_1;

		// Token: 0x0400038D RID: 909
		private int int_1;

		// Token: 0x0400038E RID: 910
		private int int_2;

		// Token: 0x0400038F RID: 911
		private int int_3;

		// Token: 0x04000390 RID: 912
		private LogicLong logicLong_5;
	}
}
