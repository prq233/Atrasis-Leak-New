using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001AC RID: 428
	public sealed class LogicMoveBuildingCommand : LogicCommand
	{
		// Token: 0x06001762 RID: 5986 RVA: 0x0000EB66 File Offset: 0x0000CD66
		public LogicMoveBuildingCommand()
		{
		}

		// Token: 0x06001763 RID: 5987 RVA: 0x0000F4F4 File Offset: 0x0000D6F4
		public LogicMoveBuildingCommand(int gameObjectId, int x, int y)
		{
			this.int_1 = x;
			this.int_2 = y;
			this.int_3 = gameObjectId;
		}

		// Token: 0x06001764 RID: 5988 RVA: 0x0000F511 File Offset: 0x0000D711
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			this.int_2 = stream.ReadInt();
			this.int_3 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x06001765 RID: 5989 RVA: 0x0000F53E File Offset: 0x0000D73E
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			encoder.WriteInt(this.int_2);
			encoder.WriteInt(this.int_3);
			base.Encode(encoder);
		}

		// Token: 0x06001766 RID: 5990 RVA: 0x0000F56B File Offset: 0x0000D76B
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.MOVE_BUILDING;
		}

		// Token: 0x06001767 RID: 5991 RVA: 0x0000EB45 File Offset: 0x0000CD45
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06001768 RID: 5992 RVA: 0x00058FD4 File Offset: 0x000571D4
		public override int Execute(LogicLevel level)
		{
			LogicGameObject gameObjectByID = level.GetGameObjectManager().GetGameObjectByID(this.int_3);
			if (gameObjectByID == null)
			{
				return -2;
			}
			LogicGameObjectType gameObjectType = gameObjectByID.GetGameObjectType();
			if (gameObjectType != LogicGameObjectType.BUILDING && gameObjectType != LogicGameObjectType.TRAP)
			{
				if (gameObjectType != LogicGameObjectType.DECO)
				{
					return -1;
				}
			}
			if (gameObjectType == LogicGameObjectType.BUILDING)
			{
				if (((LogicBuildingData)gameObjectByID.GetData()).GetVillageType() != level.GetVillageType())
				{
					return -32;
				}
			}
			if (gameObjectType == LogicGameObjectType.BUILDING && ((LogicBuilding)gameObjectByID).GetWallIndex() != 0)
			{
				return -21;
			}
			int tileX = gameObjectByID.GetTileX();
			int tileY = gameObjectByID.GetTileY();
			int widthInTiles = gameObjectByID.GetWidthInTiles();
			int heightInTiles = gameObjectByID.GetHeightInTiles();
			for (int i = 0; i < widthInTiles; i++)
			{
				for (int j = 0; j < heightInTiles; j++)
				{
					LogicObstacle tallGrass = level.GetTileMap().GetTile(this.int_1 + i, this.int_2 + j).GetTallGrass();
					if (tallGrass != null)
					{
						level.GetGameObjectManager().RemoveGameObject(tallGrass);
					}
				}
			}
			if (level.IsValidPlaceForBuilding(this.int_1, this.int_2, widthInTiles, heightInTiles, gameObjectByID))
			{
				gameObjectByID.SetPositionXY(this.int_1 << 9, this.int_2 << 9);
				if (this.int_1 != tileX || this.int_2 != tileY)
				{
					LogicAvatar homeOwnerAvatar = level.GetHomeOwnerAvatar();
					if (homeOwnerAvatar != null && homeOwnerAvatar.GetTownHallLevel() >= LogicDataTables.GetGlobals().GetChallengeBaseCooldownEnabledTownHall() && gameObjectByID.GetGameObjectType() != LogicGameObjectType.DECO)
					{
						level.SetLayoutCooldownSecs(level.GetActiveLayout(level.GetVillageType()), LogicDataTables.GetGlobals().GetChallengeBaseSaveCooldown());
					}
				}
				return 0;
			}
			return -3;
		}

		// Token: 0x04000CDA RID: 3290
		private int int_1;

		// Token: 0x04000CDB RID: 3291
		private int int_2;

		// Token: 0x04000CDC RID: 3292
		private int int_3;
	}
}
