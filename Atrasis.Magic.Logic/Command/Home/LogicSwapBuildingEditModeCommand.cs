using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001D5 RID: 469
	public sealed class LogicSwapBuildingEditModeCommand : LogicCommand
	{
		// Token: 0x06001871 RID: 6257 RVA: 0x0000EB66 File Offset: 0x0000CD66
		public LogicSwapBuildingEditModeCommand()
		{
		}

		// Token: 0x06001872 RID: 6258 RVA: 0x0001029D File Offset: 0x0000E49D
		public LogicSwapBuildingEditModeCommand(int layoutId, int gameObject1, int gameObject2)
		{
			this.int_1 = layoutId;
			this.int_2 = gameObject1;
			this.int_3 = gameObject2;
		}

		// Token: 0x06001873 RID: 6259 RVA: 0x000102BA File Offset: 0x0000E4BA
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			this.int_2 = stream.ReadInt();
			this.int_3 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x06001874 RID: 6260 RVA: 0x000102E7 File Offset: 0x0000E4E7
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			encoder.WriteInt(this.int_2);
			encoder.WriteInt(this.int_3);
			base.Encode(encoder);
		}

		// Token: 0x06001875 RID: 6261 RVA: 0x00010314 File Offset: 0x0000E514
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.SWAP_BUILDING_EDIT_MODE;
		}

		// Token: 0x06001876 RID: 6262 RVA: 0x0005BCE0 File Offset: 0x00059EE0
		public override int Execute(LogicLevel level)
		{
			if (!LogicDataTables.GetGlobals().UseSwapBuildings())
			{
				return -99;
			}
			if (this.int_2 == this.int_3)
			{
				return -98;
			}
			LogicGameObject gameObjectByID = level.GetGameObjectManager().GetGameObjectByID(this.int_2);
			LogicGameObject gameObjectByID2 = level.GetGameObjectManager().GetGameObjectByID(this.int_3);
			if (gameObjectByID == null)
			{
				return -1;
			}
			if (gameObjectByID2 == null)
			{
				return -2;
			}
			LogicGameObjectType gameObjectType = gameObjectByID.GetGameObjectType();
			if (gameObjectType != LogicGameObjectType.BUILDING && gameObjectType != LogicGameObjectType.TRAP)
			{
				if (gameObjectType != LogicGameObjectType.DECO)
				{
					return -3;
				}
			}
			LogicGameObjectType gameObjectType2 = gameObjectByID2.GetGameObjectType();
			if (gameObjectType2 != LogicGameObjectType.BUILDING && gameObjectType2 != LogicGameObjectType.TRAP)
			{
				if (gameObjectType2 != LogicGameObjectType.DECO)
				{
					return -4;
				}
			}
			int widthInTiles = gameObjectByID.GetWidthInTiles();
			int widthInTiles2 = gameObjectByID2.GetWidthInTiles();
			int heightInTiles = gameObjectByID.GetHeightInTiles();
			int heightInTiles2 = gameObjectByID2.GetHeightInTiles();
			if (widthInTiles == widthInTiles2 && heightInTiles == heightInTiles2)
			{
				if (gameObjectByID.GetGameObjectType() == LogicGameObjectType.BUILDING)
				{
					LogicBuilding logicBuilding = (LogicBuilding)gameObjectByID;
					if (logicBuilding.IsLocked())
					{
						return -6;
					}
					if (logicBuilding.IsWall())
					{
						return -7;
					}
				}
				if (gameObjectByID2.GetGameObjectType() == LogicGameObjectType.BUILDING)
				{
					LogicBuilding logicBuilding2 = (LogicBuilding)gameObjectByID2;
					if (logicBuilding2.IsLocked())
					{
						return -8;
					}
					if (logicBuilding2.IsWall())
					{
						return -9;
					}
				}
				int x = gameObjectByID.GetPositionLayout(this.int_1, true).m_x;
				int y = gameObjectByID.GetPositionLayout(this.int_1, true).m_y;
				int x2 = gameObjectByID2.GetPositionLayout(this.int_1, true).m_x;
				int y2 = gameObjectByID2.GetPositionLayout(this.int_1, true).m_y;
				gameObjectByID.SetPositionLayoutXY(x2, y2, this.int_1, true);
				gameObjectByID2.SetPositionLayoutXY(x, y, this.int_1, true);
				return 0;
			}
			return -5;
		}

		// Token: 0x04000D2A RID: 3370
		private int int_1;

		// Token: 0x04000D2B RID: 3371
		private int int_2;

		// Token: 0x04000D2C RID: 3372
		private int int_3;
	}
}
