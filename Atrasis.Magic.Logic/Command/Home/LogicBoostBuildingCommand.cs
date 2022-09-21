using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x0200018D RID: 397
	public sealed class LogicBoostBuildingCommand : LogicCommand
	{
		// Token: 0x06001699 RID: 5785 RVA: 0x0000EBFD File Offset: 0x0000CDFD
		public LogicBoostBuildingCommand()
		{
			this.logicArrayList_0 = new LogicArrayList<int>();
		}

		// Token: 0x0600169A RID: 5786 RVA: 0x00056968 File Offset: 0x00054B68
		public override void Decode(ByteStream stream)
		{
			int i = 0;
			int num = stream.ReadInt();
			while (i < num)
			{
				this.logicArrayList_0.Add(stream.ReadInt());
				i++;
			}
			base.Decode(stream);
		}

		// Token: 0x0600169B RID: 5787 RVA: 0x000569A0 File Offset: 0x00054BA0
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.logicArrayList_0.Size());
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				encoder.WriteInt(this.logicArrayList_0[i]);
			}
			base.Encode(encoder);
		}

		// Token: 0x0600169C RID: 5788 RVA: 0x0000EC10 File Offset: 0x0000CE10
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.BOOST_BUILDING;
		}

		// Token: 0x0600169D RID: 5789 RVA: 0x0000EC17 File Offset: 0x0000CE17
		public override void Destruct()
		{
			base.Destruct();
			this.logicArrayList_0 = null;
		}

		// Token: 0x0600169E RID: 5790 RVA: 0x000569F0 File Offset: 0x00054BF0
		public override int Execute(LogicLevel level)
		{
			if (this.logicArrayList_0.Size() > 0)
			{
				int num = 0;
				for (int i = 0; i < this.logicArrayList_0.Size(); i++)
				{
					LogicGameObject gameObjectByID = level.GetGameObjectManager().GetGameObjectByID(this.logicArrayList_0[i]);
					if (gameObjectByID == null || gameObjectByID.GetGameObjectType() != LogicGameObjectType.BUILDING)
					{
						return -5;
					}
					if (gameObjectByID.GetData().GetVillageType() != level.GetVillageType())
					{
						return -32;
					}
					LogicBuilding logicBuilding = (LogicBuilding)gameObjectByID;
					if (logicBuilding.IsLocked())
					{
						return -4;
					}
					if (LogicDataTables.GetGlobals().UseNewTraining() && logicBuilding.GetUnitProductionComponent() != null)
					{
						return -3;
					}
					if (logicBuilding.CanBeBoosted())
					{
						num += logicBuilding.GetBoostCost();
					}
				}
				LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
				if (num > 0)
				{
					if (!playerAvatar.HasEnoughDiamonds(num, true, level))
					{
						return -2;
					}
					playerAvatar.UseDiamonds(num);
					playerAvatar.GetChangeListener().DiamondPurchaseMade(8, 0, 0, num, level.GetVillageType());
				}
				for (int j = 0; j < this.logicArrayList_0.Size(); j++)
				{
					LogicGameObject gameObjectByID2 = level.GetGameObjectManager().GetGameObjectByID(this.logicArrayList_0[j]);
					if (gameObjectByID2 != null && gameObjectByID2.GetGameObjectType() == LogicGameObjectType.BUILDING)
					{
						LogicBuilding logicBuilding2 = (LogicBuilding)gameObjectByID2;
						if (logicBuilding2.GetMaxBoostTime() != 0)
						{
							logicBuilding2.Boost();
						}
					}
				}
				return 0;
			}
			return -1;
		}

		// Token: 0x04000CA7 RID: 3239
		private LogicArrayList<int> logicArrayList_0;
	}
}
