using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Util;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Battle
{
	// Token: 0x020001F1 RID: 497
	public sealed class LogicMatchmakingCommand : LogicCommand
	{
		// Token: 0x0600193F RID: 6463 RVA: 0x00010CD8 File Offset: 0x0000EED8
		public override void Decode(ByteStream stream)
		{
			this.logicResourceData_0 = (LogicResourceData)ByteStreamHelper.ReadDataReference(stream, LogicDataType.RESOURCE);
			this.int_1 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x06001940 RID: 6464 RVA: 0x00010CFF File Offset: 0x0000EEFF
		public override void Encode(ChecksumEncoder encoder)
		{
			ByteStreamHelper.WriteDataReference(encoder, this.logicResourceData_0);
			encoder.WriteInt(this.int_1);
			base.Encode(encoder);
		}

		// Token: 0x06001941 RID: 6465 RVA: 0x00010D20 File Offset: 0x0000EF20
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.MATCHMAKING;
		}

		// Token: 0x06001942 RID: 6466 RVA: 0x00010D27 File Offset: 0x0000EF27
		public override void Destruct()
		{
			base.Destruct();
			this.logicResourceData_0 = null;
		}

		// Token: 0x06001943 RID: 6467 RVA: 0x00060024 File Offset: 0x0005E224
		public override int Execute(LogicLevel level)
		{
			if (level.GetVillageType() == 0)
			{
				if (level.GetState() != 2)
				{
					if (level.GetState() != 1)
					{
						return -3;
					}
				}
				if (this.logicResourceData_0 != null && this.int_1 > 0 && !this.logicResourceData_0.IsPremiumCurrency())
				{
					int resourceDiamondCost = LogicGamePlayUtil.GetResourceDiamondCost(this.int_1, this.logicResourceData_0);
					LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
					if (playerAvatar.GetUnusedResourceCap(this.logicResourceData_0) < this.int_1)
					{
						return -1;
					}
					if (!playerAvatar.HasEnoughDiamonds(resourceDiamondCost, true, level))
					{
						return -2;
					}
					playerAvatar.UseDiamonds(resourceDiamondCost);
					playerAvatar.GetChangeListener().DiamondPurchaseMade(5, this.logicResourceData_0.GetGlobalID(), this.int_1, resourceDiamondCost, level.GetVillageType());
					playerAvatar.CommodityCountChangeHelper(0, this.logicResourceData_0, this.int_1);
				}
				level.GetGameListener().MatchmakingCommandExecuted();
				return 0;
			}
			return -32;
		}

		// Token: 0x04000DA8 RID: 3496
		private LogicResourceData logicResourceData_0;

		// Token: 0x04000DA9 RID: 3497
		private int int_1;
	}
}
