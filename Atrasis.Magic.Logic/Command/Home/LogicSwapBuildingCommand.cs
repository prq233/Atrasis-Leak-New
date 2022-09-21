using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001D4 RID: 468
	public sealed class LogicSwapBuildingCommand : LogicCommand
	{
		// Token: 0x0600186B RID: 6251 RVA: 0x0000EB66 File Offset: 0x0000CD66
		public LogicSwapBuildingCommand()
		{
		}

		// Token: 0x0600186C RID: 6252 RVA: 0x0001023E File Offset: 0x0000E43E
		public LogicSwapBuildingCommand(int gameObject1, int gameObject2)
		{
			this.int_1 = gameObject1;
			this.int_2 = gameObject2;
		}

		// Token: 0x0600186D RID: 6253 RVA: 0x00010254 File Offset: 0x0000E454
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			this.int_2 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x0600186E RID: 6254 RVA: 0x00010275 File Offset: 0x0000E475
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			encoder.WriteInt(this.int_2);
			base.Encode(encoder);
		}

		// Token: 0x0600186F RID: 6255 RVA: 0x00010296 File Offset: 0x0000E496
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.SWAP_BUILDING;
		}

		// Token: 0x06001870 RID: 6256 RVA: 0x0005BB94 File Offset: 0x00059D94
		public override int Execute(LogicLevel level)
		{
			if (!LogicDataTables.GetGlobals().UseSwapBuildings())
			{
				return -99;
			}
			if (this.int_1 == this.int_2)
			{
				return -98;
			}
			LogicGameObject gameObjectByID = level.GetGameObjectManager().GetGameObjectByID(this.int_1);
			LogicGameObject gameObjectByID2 = level.GetGameObjectManager().GetGameObjectByID(this.int_2);
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
				int x = gameObjectByID.GetX();
				int y = gameObjectByID.GetY();
				int x2 = gameObjectByID2.GetX();
				int y2 = gameObjectByID2.GetY();
				gameObjectByID.SetPositionXY(x2, y2);
				gameObjectByID2.SetPositionXY(x, y);
				return 0;
			}
			return -5;
		}

		// Token: 0x04000D28 RID: 3368
		private int int_1;

		// Token: 0x04000D29 RID: 3369
		private int int_2;
	}
}
