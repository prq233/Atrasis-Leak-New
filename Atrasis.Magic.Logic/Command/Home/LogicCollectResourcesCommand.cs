using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x0200019F RID: 415
	public sealed class LogicCollectResourcesCommand : LogicCommand
	{
		// Token: 0x06001712 RID: 5906 RVA: 0x0000EB66 File Offset: 0x0000CD66
		public LogicCollectResourcesCommand()
		{
		}

		// Token: 0x06001713 RID: 5907 RVA: 0x0000F156 File Offset: 0x0000D356
		public LogicCollectResourcesCommand(int gameObjectId)
		{
			this.int_1 = gameObjectId;
		}

		// Token: 0x06001714 RID: 5908 RVA: 0x0000F165 File Offset: 0x0000D365
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x06001715 RID: 5909 RVA: 0x0000F17A File Offset: 0x0000D37A
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			base.Encode(encoder);
		}

		// Token: 0x06001716 RID: 5910 RVA: 0x0000F18F File Offset: 0x0000D38F
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.COLLECT_RESOURCES;
		}

		// Token: 0x06001717 RID: 5911 RVA: 0x0000EB45 File Offset: 0x0000CD45
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06001718 RID: 5912 RVA: 0x00058408 File Offset: 0x00056608
		public override int Execute(LogicLevel level)
		{
			LogicGameObject gameObjectByID = level.GetGameObjectManager().GetGameObjectByID(this.int_1);
			if (gameObjectByID == null || gameObjectByID.GetGameObjectType() != LogicGameObjectType.BUILDING)
			{
				return -2;
			}
			if (gameObjectByID.GetVillageType() != level.GetVillageType())
			{
				return -3;
			}
			LogicResourceProductionComponent resourceProductionComponent = gameObjectByID.GetResourceProductionComponent();
			if (resourceProductionComponent != null)
			{
				if (LogicDataTables.GetGlobals().CollectAllResourcesAtOnce())
				{
					int resourceCount = resourceProductionComponent.GetResourceCount();
					int num = resourceProductionComponent.CollectResources(true);
					bool flag = resourceCount > 0 && num == 0;
					LogicArrayList<LogicComponent> components = level.GetComponentManager().GetComponents(resourceProductionComponent.GetComponentType());
					for (int i = 0; i < components.Size(); i++)
					{
						LogicResourceProductionComponent logicResourceProductionComponent = (LogicResourceProductionComponent)components[i];
						if (resourceProductionComponent != logicResourceProductionComponent && resourceProductionComponent.GetResourceData() == logicResourceProductionComponent.GetResourceData())
						{
							int resourceCount2 = logicResourceProductionComponent.GetResourceCount();
							int num2 = logicResourceProductionComponent.CollectResources(!flag);
							if (resourceCount2 > 0 && num2 == 0)
							{
								flag = true;
							}
						}
					}
				}
				else
				{
					resourceProductionComponent.CollectResources(true);
				}
				return 0;
			}
			return -1;
		}

		// Token: 0x04000CCA RID: 3274
		private int int_1;
	}
}
