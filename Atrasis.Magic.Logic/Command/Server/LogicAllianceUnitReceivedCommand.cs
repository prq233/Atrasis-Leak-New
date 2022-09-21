using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Server
{
	// Token: 0x02000171 RID: 369
	public class LogicAllianceUnitReceivedCommand : LogicServerCommand
	{
		// Token: 0x060015D6 RID: 5590 RVA: 0x0000E3B3 File Offset: 0x0000C5B3
		public void SetData(string senderName, LogicCombatItemData data, int upgLevel)
		{
			this.string_0 = senderName;
			this.logicCombatItemData_0 = data;
			this.int_2 = upgLevel;
		}

		// Token: 0x060015D7 RID: 5591 RVA: 0x0000E3CA File Offset: 0x0000C5CA
		public override void Destruct()
		{
			base.Destruct();
			this.logicCombatItemData_0 = null;
		}

		// Token: 0x060015D8 RID: 5592 RVA: 0x000547FC File Offset: 0x000529FC
		public override void Decode(ByteStream stream)
		{
			this.string_0 = stream.ReadString(900000);
			this.logicCombatItemData_0 = (LogicCombatItemData)ByteStreamHelper.ReadDataReference(stream, (stream.ReadInt() != 0) ? LogicDataType.SPELL : LogicDataType.CHARACTER);
			this.int_2 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x060015D9 RID: 5593 RVA: 0x0000E3D9 File Offset: 0x0000C5D9
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteString(this.string_0);
			encoder.WriteInt((int)this.logicCombatItemData_0.GetCombatItemType());
			ByteStreamHelper.WriteDataReference(encoder, this.logicCombatItemData_0);
			encoder.WriteInt(this.int_2);
			base.Encode(encoder);
		}

		// Token: 0x060015DA RID: 5594 RVA: 0x0005484C File Offset: 0x00052A4C
		public override int Execute(LogicLevel level)
		{
			LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
			if (playerAvatar != null && this.logicCombatItemData_0 != null)
			{
				playerAvatar.AddAllianceUnit(this.logicCombatItemData_0, this.int_2);
				playerAvatar.GetChangeListener().AllianceUnitAdded(this.logicCombatItemData_0, this.int_2);
				level.GetGameListener().UnitReceivedFromAlliance(this.string_0, this.logicCombatItemData_0, this.int_2);
				if (level.GetState() == 1 || level.GetState() == 3)
				{
					level.GetComponentManagerAt(0).AddAvatarAllianceUnitsToCastle();
				}
				return 0;
			}
			return -1;
		}

		// Token: 0x060015DB RID: 5595 RVA: 0x00002BCC File Offset: 0x00000DCC
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.ALLIANCE_UNIT_RECEIVED;
		}

		// Token: 0x04000C63 RID: 3171
		private LogicCombatItemData logicCombatItemData_0;

		// Token: 0x04000C64 RID: 3172
		private int int_2;

		// Token: 0x04000C65 RID: 3173
		private string string_0;
	}
}
