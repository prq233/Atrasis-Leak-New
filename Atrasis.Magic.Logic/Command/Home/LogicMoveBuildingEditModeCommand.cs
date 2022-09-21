using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001AD RID: 429
	public sealed class LogicMoveBuildingEditModeCommand : LogicCommand
	{
		// Token: 0x06001769 RID: 5993 RVA: 0x0000F572 File Offset: 0x0000D772
		public override void Decode(ByteStream stream)
		{
			this.int_3 = stream.ReadInt();
			this.int_4 = stream.ReadInt();
			this.int_1 = stream.ReadInt();
			this.int_2 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x0600176A RID: 5994 RVA: 0x0000F5AB File Offset: 0x0000D7AB
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_3);
			encoder.WriteInt(this.int_4);
			encoder.WriteInt(this.int_1);
			encoder.WriteInt(this.int_2);
			base.Encode(encoder);
		}

		// Token: 0x0600176B RID: 5995 RVA: 0x0000F5E4 File Offset: 0x0000D7E4
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.MOVE_BUILDING_EDIT_MODE;
		}

		// Token: 0x0600176C RID: 5996 RVA: 0x0000EB45 File Offset: 0x0000CD45
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x0600176D RID: 5997 RVA: 0x00059148 File Offset: 0x00057348
		public override int Execute(LogicLevel level)
		{
			if (this.int_2 == 6)
			{
				return -5;
			}
			if (this.int_2 == 7)
			{
				return -6;
			}
			LogicGameObject gameObjectByID = level.GetGameObjectManager().GetGameObjectByID(this.int_1);
			if (gameObjectByID == null)
			{
				return -3;
			}
			LogicGameObjectType gameObjectType = gameObjectByID.GetGameObjectType();
			if (gameObjectType != LogicGameObjectType.BUILDING && gameObjectType != LogicGameObjectType.TRAP)
			{
				if (gameObjectType != LogicGameObjectType.DECO)
				{
					return -1;
				}
			}
			LogicRect playArea = level.GetPlayArea();
			if ((!playArea.IsInside(this.int_3, this.int_4) || !playArea.IsInside(this.int_3 + gameObjectByID.GetWidthInTiles(), this.int_4 + gameObjectByID.GetHeightInTiles())) && this.int_3 != -1)
			{
				if (this.int_4 != -1)
				{
					return -2;
				}
			}
			if (gameObjectType == LogicGameObjectType.BUILDING && ((LogicBuilding)gameObjectByID).GetWallIndex() != 0)
			{
				return -23;
			}
			gameObjectByID.SetPositionLayoutXY(this.int_3, this.int_4, this.int_2, true);
			LogicGlobals globals = LogicDataTables.GetGlobals();
			if (!globals.NoCooldownFromMoveEditModeActive() && level.GetActiveLayout(level.GetVillageType()) == this.int_2 && level.GetHomeOwnerAvatar().GetExpLevel() >= globals.GetChallengeBaseCooldownEnabledTownHall())
			{
				level.SetLayoutCooldownSecs(this.int_2, globals.GetChallengeBaseSaveCooldown());
			}
			return 0;
		}

		// Token: 0x04000CDD RID: 3293
		private int int_1;

		// Token: 0x04000CDE RID: 3294
		private int int_2;

		// Token: 0x04000CDF RID: 3295
		private int int_3;

		// Token: 0x04000CE0 RID: 3296
		private int int_4;
	}
}
