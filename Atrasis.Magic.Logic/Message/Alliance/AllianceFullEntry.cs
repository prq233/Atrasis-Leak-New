using System;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Message.Alliance
{
	// Token: 0x020000A9 RID: 169
	public class AllianceFullEntry
	{
		// Token: 0x06000751 RID: 1873 RVA: 0x0001FB04 File Offset: 0x0001DD04
		public void Decode(ByteStream stream)
		{
			this.allianceHeaderEntry_0 = new AllianceHeaderEntry();
			this.allianceHeaderEntry_0.Decode(stream);
			this.string_0 = stream.ReadString(900000);
			stream.ReadInt();
			if (stream.ReadBoolean())
			{
				stream.ReadLong();
			}
			stream.ReadInt();
			if (stream.ReadBoolean())
			{
				stream.ReadLong();
			}
			int num = stream.ReadInt();
			if (num >= 0)
			{
				Debugger.DoAssert(num < 51, "Too many members in the alliance");
				this.logicArrayList_0 = new LogicArrayList<AllianceMemberEntry>();
				this.logicArrayList_0.EnsureCapacity(num);
				int num2 = 0;
				do
				{
					AllianceMemberEntry allianceMemberEntry = new AllianceMemberEntry();
					allianceMemberEntry.Decode(stream);
					this.logicArrayList_0.Add(allianceMemberEntry);
				}
				while (++num2 != num);
			}
			stream.ReadInt();
			stream.ReadInt();
		}

		// Token: 0x06000752 RID: 1874 RVA: 0x0001FBC8 File Offset: 0x0001DDC8
		public void Encode(ByteStream stream)
		{
			this.allianceHeaderEntry_0.Encode(stream);
			stream.WriteString(this.string_0);
			stream.WriteInt(0);
			stream.WriteBoolean(false);
			stream.WriteInt(0);
			stream.WriteBoolean(false);
			if (this.logicArrayList_0 != null)
			{
				stream.WriteInt(this.logicArrayList_0.Size());
				for (int i = 0; i < this.logicArrayList_0.Size(); i++)
				{
					this.logicArrayList_0[i].Encode(stream);
				}
			}
			else
			{
				stream.WriteInt(-1);
			}
			stream.WriteInt(0);
			stream.WriteInt(0);
		}

		// Token: 0x06000753 RID: 1875 RVA: 0x000063D6 File Offset: 0x000045D6
		public void SetAllianceHeaderEntry(AllianceHeaderEntry entry)
		{
			this.allianceHeaderEntry_0 = entry;
		}

		// Token: 0x06000754 RID: 1876 RVA: 0x000063DF File Offset: 0x000045DF
		public void SetAllianceDescription(string description)
		{
			this.string_0 = description;
		}

		// Token: 0x06000755 RID: 1877 RVA: 0x000063E8 File Offset: 0x000045E8
		public void SetAllianceMembers(LogicArrayList<AllianceMemberEntry> entry)
		{
			this.logicArrayList_0 = entry;
		}

		// Token: 0x040002C0 RID: 704
		private string string_0;

		// Token: 0x040002C1 RID: 705
		private AllianceHeaderEntry allianceHeaderEntry_0;

		// Token: 0x040002C2 RID: 706
		private LogicArrayList<AllianceMemberEntry> logicArrayList_0;
	}
}
