using System;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001B5 RID: 437
	public sealed class LogicRemoveTroopVillage2Command : LogicCommand
	{
		// Token: 0x0600179D RID: 6045 RVA: 0x0000EB66 File Offset: 0x0000CD66
		public LogicRemoveTroopVillage2Command()
		{
		}

		// Token: 0x0600179E RID: 6046 RVA: 0x0000F93E File Offset: 0x0000DB3E
		public LogicRemoveTroopVillage2Command(int gameObjectId)
		{
			this.int_1 = gameObjectId;
		}

		// Token: 0x0600179F RID: 6047 RVA: 0x0000F94D File Offset: 0x0000DB4D
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x060017A0 RID: 6048 RVA: 0x0000F962 File Offset: 0x0000DB62
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			base.Encode(encoder);
		}

		// Token: 0x060017A1 RID: 6049 RVA: 0x0000F977 File Offset: 0x0000DB77
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.REMOVE_TROOP_VILLAGE_2;
		}

		// Token: 0x060017A2 RID: 6050 RVA: 0x0000F97E File Offset: 0x0000DB7E
		public override void Destruct()
		{
			base.Destruct();
			this.int_1 = 0;
		}

		// Token: 0x060017A3 RID: 6051 RVA: 0x0005A06C File Offset: 0x0005826C
		public override int Execute(LogicLevel level)
		{
			LogicGameObject gameObjectByID = level.GetGameObjectManager().GetGameObjectByID(this.int_1);
			if (gameObjectByID != null && gameObjectByID.GetGameObjectType() == LogicGameObjectType.BUILDING)
			{
				LogicVillage2UnitComponent village2UnitComponent = ((LogicBuilding)gameObjectByID).GetVillage2UnitComponent();
				if (village2UnitComponent != null)
				{
					level.GetPlayerAvatar().CommodityCountChangeHelper(7, village2UnitComponent.GetUnitData(), -village2UnitComponent.GetUnitCount());
					village2UnitComponent.RemoveUnits();
					return 0;
				}
			}
			return -1;
		}

		// Token: 0x04000CF4 RID: 3316
		private int int_1;
	}
}
