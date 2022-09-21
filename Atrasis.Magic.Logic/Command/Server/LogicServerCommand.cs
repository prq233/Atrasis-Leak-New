using System;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Server
{
	// Token: 0x02000185 RID: 389
	public class LogicServerCommand : LogicCommand
	{
		// Token: 0x06001661 RID: 5729 RVA: 0x0000EA13 File Offset: 0x0000CC13
		public LogicServerCommand()
		{
			this.int_1 = -1;
		}

		// Token: 0x06001662 RID: 5730 RVA: 0x0000EA22 File Offset: 0x0000CC22
		public override void Destruct()
		{
			base.Destruct();
			this.int_1 = -1;
		}

		// Token: 0x06001663 RID: 5731 RVA: 0x0000EA31 File Offset: 0x0000CC31
		public int GetId()
		{
			return this.int_1;
		}

		// Token: 0x06001664 RID: 5732 RVA: 0x0000EA39 File Offset: 0x0000CC39
		public void SetId(int id)
		{
			this.int_1 = id;
		}

		// Token: 0x06001665 RID: 5733 RVA: 0x0000EA42 File Offset: 0x0000CC42
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x06001666 RID: 5734 RVA: 0x0000EA57 File Offset: 0x0000CC57
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			base.Encode(encoder);
		}

		// Token: 0x06001667 RID: 5735 RVA: 0x00002B36 File Offset: 0x00000D36
		public sealed override bool IsServerCommand()
		{
			return true;
		}

		// Token: 0x04000C9C RID: 3228
		private int int_1;
	}
}
