using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001DC RID: 476
	public sealed class LogicTransferWarResourcesCommand : LogicCommand
	{
		// Token: 0x060018A2 RID: 6306 RVA: 0x0000EC66 File Offset: 0x0000CE66
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
		}

		// Token: 0x060018A3 RID: 6307 RVA: 0x0000EC6F File Offset: 0x0000CE6F
		public override void Encode(ChecksumEncoder encoder)
		{
			base.Encode(encoder);
		}

		// Token: 0x060018A4 RID: 6308 RVA: 0x00010648 File Offset: 0x0000E848
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.TRANSFER_WAR_RESOURCES;
		}

		// Token: 0x060018A5 RID: 6309 RVA: 0x0000EB45 File Offset: 0x0000CD45
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x060018A6 RID: 6310 RVA: 0x0005C740 File Offset: 0x0005A940
		public override int Execute(LogicLevel level)
		{
			LogicArrayList<LogicGameObject> gameObjects = level.GetGameObjectManagerAt(0).GetGameObjects(LogicGameObjectType.BUILDING);
			for (int i = 0; i < gameObjects.Size(); i++)
			{
				LogicBuilding logicBuilding = (LogicBuilding)gameObjects[i];
				if (logicBuilding.GetData() == LogicDataTables.GetAllianceCastleData())
				{
					LogicWarResourceStorageComponent warResourceStorageComponent = logicBuilding.GetWarResourceStorageComponent();
					if (warResourceStorageComponent.IsNotEmpty())
					{
						warResourceStorageComponent.CollectResources();
					}
				}
			}
			return 0;
		}
	}
}
