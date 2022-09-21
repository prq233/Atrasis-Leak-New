using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001B1 RID: 433
	public sealed class LogicNewShopItemsSeenCommand : LogicCommand
	{
		// Token: 0x06001783 RID: 6019 RVA: 0x0000EB66 File Offset: 0x0000CD66
		public LogicNewShopItemsSeenCommand()
		{
		}

		// Token: 0x06001784 RID: 6020 RVA: 0x0000F760 File Offset: 0x0000D960
		public LogicNewShopItemsSeenCommand(int index, int type, int count)
		{
			this.int_1 = index;
			this.logicDataType_0 = (LogicDataType)type;
			this.int_2 = count;
		}

		// Token: 0x06001785 RID: 6021 RVA: 0x0000F77D File Offset: 0x0000D97D
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			this.logicDataType_0 = (LogicDataType)stream.ReadInt();
			this.int_2 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x06001786 RID: 6022 RVA: 0x0000F7AA File Offset: 0x0000D9AA
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			encoder.WriteInt((int)this.logicDataType_0);
			encoder.WriteInt(this.int_2);
			base.Encode(encoder);
		}

		// Token: 0x06001787 RID: 6023 RVA: 0x0000F7D7 File Offset: 0x0000D9D7
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.NEW_SHOP_ITEMS_SEEN;
		}

		// Token: 0x06001788 RID: 6024 RVA: 0x0000EB45 File Offset: 0x0000CD45
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06001789 RID: 6025 RVA: 0x00059D70 File Offset: 0x00057F70
		public override int Execute(LogicLevel level)
		{
			if (this.logicDataType_0 != LogicDataType.BUILDING && this.logicDataType_0 != LogicDataType.TRAP)
			{
				if (this.logicDataType_0 != LogicDataType.DECO)
				{
					return -1;
				}
			}
			if (level.SetUnlockedShopItemCount((LogicGameObjectData)LogicDataTables.GetTable(this.logicDataType_0).GetItemAt(this.int_1), this.int_1, this.int_2, level.GetVillageType()))
			{
				return 0;
			}
			return -2;
		}

		// Token: 0x04000CEA RID: 3306
		private LogicDataType logicDataType_0;

		// Token: 0x04000CEB RID: 3307
		private int int_1;

		// Token: 0x04000CEC RID: 3308
		private int int_2;
	}
}
