using System;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Message;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Message.Avatar.Stream
{
	// Token: 0x02000099 RID: 153
	public class AvatarStreamMessage : PiranhaMessage
	{
		// Token: 0x06000684 RID: 1668 RVA: 0x00005CAC File Offset: 0x00003EAC
		public AvatarStreamMessage() : this(0)
		{
		}

		// Token: 0x06000685 RID: 1669 RVA: 0x0000328C File Offset: 0x0000148C
		public AvatarStreamMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000686 RID: 1670 RVA: 0x0001E734 File Offset: 0x0001C934
		public override void Decode()
		{
			base.Decode();
			int num = this.m_stream.ReadInt();
			if (num != -1)
			{
				this.logicArrayList_0 = new LogicArrayList<AvatarStreamEntry>(num);
				for (int i = 0; i < num; i++)
				{
					AvatarStreamEntry avatarStreamEntry = AvatarStreamEntryFactory.CreateStreamEntryByType((AvatarStreamEntryType)this.m_stream.ReadInt());
					if (avatarStreamEntry == null)
					{
						Debugger.Warning("Corrupted AvatarStreamMessage");
						return;
					}
					avatarStreamEntry.Decode(this.m_stream);
				}
				return;
			}
			this.logicArrayList_0 = null;
		}

		// Token: 0x06000687 RID: 1671 RVA: 0x0001E7A4 File Offset: 0x0001C9A4
		public override void Encode()
		{
			base.Encode();
			if (this.logicArrayList_0 != null)
			{
				this.m_stream.WriteInt(this.logicArrayList_0.Size());
				for (int i = 0; i < this.logicArrayList_0.Size(); i++)
				{
					this.m_stream.WriteInt((int)this.logicArrayList_0[i].GetAvatarStreamEntryType());
					this.logicArrayList_0[i].Encode(this.m_stream);
				}
				return;
			}
			this.m_stream.WriteInt(-1);
		}

		// Token: 0x06000688 RID: 1672 RVA: 0x00005CB5 File Offset: 0x00003EB5
		public override short GetMessageType()
		{
			return 24411;
		}

		// Token: 0x06000689 RID: 1673 RVA: 0x000046E0 File Offset: 0x000028E0
		public override int GetServiceNodeType()
		{
			return 11;
		}

		// Token: 0x0600068A RID: 1674 RVA: 0x0001E82C File Offset: 0x0001CA2C
		public override void Destruct()
		{
			base.Destruct();
			if (this.logicArrayList_0 != null)
			{
				if (this.logicArrayList_0.Size() != 0)
				{
					do
					{
						this.logicArrayList_0[0].Destruct();
						this.logicArrayList_0.Remove(0);
					}
					while (this.logicArrayList_0.Size() != 0);
				}
				this.logicArrayList_0 = null;
			}
		}

		// Token: 0x0600068B RID: 1675 RVA: 0x00005CBC File Offset: 0x00003EBC
		public LogicArrayList<AvatarStreamEntry> RemoveStreamEntries()
		{
			LogicArrayList<AvatarStreamEntry> result = this.logicArrayList_0;
			this.logicArrayList_0 = null;
			return result;
		}

		// Token: 0x0600068C RID: 1676 RVA: 0x00005CCB File Offset: 0x00003ECB
		public void SetStreamEntries(LogicArrayList<AvatarStreamEntry> entry)
		{
			this.logicArrayList_0 = entry;
		}

		// Token: 0x04000272 RID: 626
		public const int MESSAGE_TYPE = 24411;

		// Token: 0x04000273 RID: 627
		private LogicArrayList<AvatarStreamEntry> logicArrayList_0;
	}
}
