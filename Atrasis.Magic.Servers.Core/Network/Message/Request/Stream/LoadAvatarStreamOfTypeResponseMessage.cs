using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Message.Avatar.Stream;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request.Stream
{
	// Token: 0x02000094 RID: 148
	public class LoadAvatarStreamOfTypeResponseMessage : ServerResponseMessage
	{
		// Token: 0x170000FA RID: 250
		// (get) Token: 0x0600041E RID: 1054 RVA: 0x00007030 File Offset: 0x00005230
		// (set) Token: 0x0600041F RID: 1055 RVA: 0x00007038 File Offset: 0x00005238
		public LogicArrayList<AvatarStreamEntry> StreamList { get; set; }

		// Token: 0x06000420 RID: 1056 RVA: 0x0000CE04 File Offset: 0x0000B004
		public override void Encode(ByteStream stream)
		{
			if (base.Success)
			{
				stream.WriteVInt(this.StreamList.Size());
				for (int i = 0; i < this.StreamList.Size(); i++)
				{
					stream.WriteVInt((int)this.StreamList[i].GetAvatarStreamEntryType());
					this.StreamList[i].Encode(stream);
				}
			}
		}

		// Token: 0x06000421 RID: 1057 RVA: 0x0000CE6C File Offset: 0x0000B06C
		public override void Decode(ByteStream stream)
		{
			if (base.Success)
			{
				this.StreamList = new LogicArrayList<AvatarStreamEntry>();
				for (int i = stream.ReadVInt() - 1; i >= 0; i--)
				{
					AvatarStreamEntry avatarStreamEntry = AvatarStreamEntryFactory.CreateStreamEntryByType((AvatarStreamEntryType)stream.ReadVInt());
					avatarStreamEntry.Decode(stream);
					this.StreamList.Add(avatarStreamEntry);
				}
			}
		}

		// Token: 0x06000422 RID: 1058 RVA: 0x00007041 File Offset: 0x00005241
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.LOAD_AVATAR_STREAM_OF_TYPE_RESPONSE;
		}

		// Token: 0x040001DE RID: 478
		[CompilerGenerated]
		private LogicArrayList<AvatarStreamEntry> logicArrayList_0;

		// Token: 0x02000095 RID: 149
		public enum Reason
		{
			// Token: 0x040001E0 RID: 480
			GENERIC,
			// Token: 0x040001E1 RID: 481
			ALREADY_SENT
		}
	}
}
