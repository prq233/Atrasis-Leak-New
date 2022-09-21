using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001B8 RID: 440
	public sealed class LogicRepairTrapsCommand : LogicCommand
	{
		// Token: 0x060017AF RID: 6063 RVA: 0x0000FA46 File Offset: 0x0000DC46
		public LogicRepairTrapsCommand()
		{
			this.logicArrayList_0 = new LogicArrayList<int>(50);
		}

		// Token: 0x060017B0 RID: 6064 RVA: 0x0005A578 File Offset: 0x00058778
		public override void Decode(ByteStream stream)
		{
			for (int i = stream.ReadInt(); i > 0; i--)
			{
				this.logicArrayList_0.Add(stream.ReadInt());
			}
			base.Decode(stream);
		}

		// Token: 0x060017B1 RID: 6065 RVA: 0x0005A5B0 File Offset: 0x000587B0
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.logicArrayList_0.Size());
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				encoder.WriteInt(this.logicArrayList_0[i]);
			}
			base.Encode(encoder);
		}

		// Token: 0x060017B2 RID: 6066 RVA: 0x0000FA5B File Offset: 0x0000DC5B
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.REPAIR_TRAPS;
		}

		// Token: 0x060017B3 RID: 6067 RVA: 0x0000EB45 File Offset: 0x0000CD45
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x060017B4 RID: 6068 RVA: 0x0005A600 File Offset: 0x00058800
		public override int Execute(LogicLevel level)
		{
			LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
			LogicGameObjectManager gameObjectManager = level.GetGameObjectManager();
			LogicResourceData logicResourceData = null;
			int num = 0;
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				LogicGameObject gameObjectByID = gameObjectManager.GetGameObjectByID(this.logicArrayList_0[i]);
				if (gameObjectByID != null && gameObjectByID.GetGameObjectType() == LogicGameObjectType.TRAP)
				{
					LogicTrap logicTrap = (LogicTrap)gameObjectByID;
					if (logicTrap.IsDisarmed() && !logicTrap.IsConstructing())
					{
						LogicTrapData trapData = logicTrap.GetTrapData();
						logicResourceData = trapData.GetBuildResource();
						num += trapData.GetRearmCost(logicTrap.GetUpgradeLevel());
					}
				}
			}
			if (logicResourceData == null || num == 0)
			{
				return -1;
			}
			if (playerAvatar.HasEnoughResources(logicResourceData, num, true, this, false))
			{
				playerAvatar.CommodityCountChangeHelper(0, logicResourceData, -num);
				for (int j = 0; j < this.logicArrayList_0.Size(); j++)
				{
					LogicGameObject gameObjectByID2 = gameObjectManager.GetGameObjectByID(this.logicArrayList_0[j]);
					if (gameObjectByID2 != null && gameObjectByID2.GetGameObjectType() == LogicGameObjectType.TRAP)
					{
						LogicTrap logicTrap2 = (LogicTrap)gameObjectByID2;
						if (logicTrap2.IsDisarmed() && !logicTrap2.IsConstructing())
						{
							logicTrap2.RepairTrap();
						}
					}
				}
				return 0;
			}
			return -2;
		}

		// Token: 0x04000CFC RID: 3324
		private readonly LogicArrayList<int> logicArrayList_0;
	}
}
