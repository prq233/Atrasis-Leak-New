using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Util;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x02000192 RID: 402
	public sealed class LogicBuyResourcesCommand : LogicCommand
	{
		// Token: 0x060016BA RID: 5818 RVA: 0x0000EB66 File Offset: 0x0000CD66
		public LogicBuyResourcesCommand()
		{
		}

		// Token: 0x060016BB RID: 5819 RVA: 0x0000EDC2 File Offset: 0x0000CFC2
		public LogicBuyResourcesCommand(LogicResourceData data, int resourceCount, LogicResourceData resource2Data, int resource2Count, LogicCommand resourceCommand)
		{
			this.logicResourceData_0 = data;
			this.logicResourceData_1 = resource2Data;
			this.logicCommand_0 = resourceCommand;
			this.int_1 = resourceCount;
			this.int_2 = resource2Count;
		}

		// Token: 0x060016BC RID: 5820 RVA: 0x00057010 File Offset: 0x00055210
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			this.logicResourceData_0 = (LogicResourceData)ByteStreamHelper.ReadDataReference(stream, LogicDataType.RESOURCE);
			this.int_2 = stream.ReadInt();
			if (this.int_2 > 0)
			{
				this.logicResourceData_1 = (LogicResourceData)ByteStreamHelper.ReadDataReference(stream, LogicDataType.RESOURCE);
			}
			if (stream.ReadBoolean())
			{
				this.logicCommand_0 = LogicCommandManager.DecodeCommand(stream);
			}
			base.Decode(stream);
		}

		// Token: 0x060016BD RID: 5821 RVA: 0x00057080 File Offset: 0x00055280
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			ByteStreamHelper.WriteDataReference(encoder, this.logicResourceData_0);
			encoder.WriteInt(this.int_2);
			if (this.int_2 > 0)
			{
				ByteStreamHelper.WriteDataReference(encoder, this.logicResourceData_1);
			}
			if (this.logicCommand_0 != null)
			{
				encoder.WriteBoolean(true);
				LogicCommandManager.EncodeCommand(encoder, this.logicCommand_0);
			}
			else
			{
				encoder.WriteBoolean(false);
			}
			base.Encode(encoder);
		}

		// Token: 0x060016BE RID: 5822 RVA: 0x0000EDEF File Offset: 0x0000CFEF
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.BUY_RESOURCES;
		}

		// Token: 0x060016BF RID: 5823 RVA: 0x0000EDF6 File Offset: 0x0000CFF6
		public override void Destruct()
		{
			base.Destruct();
			if (this.logicCommand_0 != null)
			{
				this.logicCommand_0.Destruct();
				this.logicCommand_0 = null;
			}
			this.logicResourceData_0 = null;
			this.logicResourceData_1 = null;
		}

		// Token: 0x060016C0 RID: 5824 RVA: 0x000570F4 File Offset: 0x000552F4
		public override int Execute(LogicLevel level)
		{
			if (this.logicResourceData_0 != null && this.int_1 > 0 && !this.logicResourceData_0.IsPremiumCurrency())
			{
				LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
				if (this.logicResourceData_1 != null && this.int_2 > 0)
				{
					if (playerAvatar.GetUnusedResourceCap(this.logicResourceData_0) >= this.int_1 && playerAvatar.GetUnusedResourceCap(this.logicResourceData_1) >= this.int_2)
					{
						int resourceDiamondCost = LogicGamePlayUtil.GetResourceDiamondCost(this.int_1, this.logicResourceData_0);
						int resourceDiamondCost2 = LogicGamePlayUtil.GetResourceDiamondCost(this.int_2, this.logicResourceData_1);
						if (playerAvatar.HasEnoughDiamonds(resourceDiamondCost + resourceDiamondCost2, true, level))
						{
							playerAvatar.UseDiamonds(resourceDiamondCost + resourceDiamondCost2);
							playerAvatar.CommodityCountChangeHelper(0, this.logicResourceData_0, this.int_1);
							playerAvatar.CommodityCountChangeHelper(0, this.logicResourceData_1, this.int_2);
							playerAvatar.GetChangeListener().DiamondPurchaseMade(5, this.logicResourceData_1.GetGlobalID(), this.int_2, resourceDiamondCost + resourceDiamondCost2, level.GetVillageType());
							if (this.logicCommand_0 != null)
							{
								int commandType = (int)this.logicCommand_0.GetCommandType();
								if (commandType < 1000 && commandType >= 500 && commandType < 700)
								{
									this.logicCommand_0.Execute(level);
								}
							}
							return 0;
						}
					}
				}
				else if (playerAvatar.GetUnusedResourceCap(this.logicResourceData_0) >= this.int_1)
				{
					int resourceDiamondCost3 = LogicGamePlayUtil.GetResourceDiamondCost(this.int_1, this.logicResourceData_0);
					if (playerAvatar.HasEnoughDiamonds(resourceDiamondCost3, true, level))
					{
						playerAvatar.UseDiamonds(resourceDiamondCost3);
						playerAvatar.CommodityCountChangeHelper(0, this.logicResourceData_0, this.int_1);
						playerAvatar.GetChangeListener().DiamondPurchaseMade(5, this.logicResourceData_0.GetGlobalID(), this.int_1, resourceDiamondCost3, level.GetVillageType());
						if (this.logicCommand_0 != null)
						{
							int commandType2 = (int)this.logicCommand_0.GetCommandType();
							if (commandType2 < 1000 && commandType2 >= 500 && commandType2 < 700)
							{
								this.logicCommand_0.Execute(level);
							}
						}
						return 0;
					}
				}
			}
			return -1;
		}

		// Token: 0x04000CAF RID: 3247
		private LogicCommand logicCommand_0;

		// Token: 0x04000CB0 RID: 3248
		private LogicResourceData logicResourceData_0;

		// Token: 0x04000CB1 RID: 3249
		private LogicResourceData logicResourceData_1;

		// Token: 0x04000CB2 RID: 3250
		private int int_1;

		// Token: 0x04000CB3 RID: 3251
		private int int_2;
	}
}
