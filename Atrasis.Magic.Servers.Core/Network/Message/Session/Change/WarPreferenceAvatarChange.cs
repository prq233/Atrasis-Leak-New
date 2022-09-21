using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Message.Alliance;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session.Change
{
	// Token: 0x02000070 RID: 112
	public class WarPreferenceAvatarChange : AvatarChange
	{
		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x0600031E RID: 798 RVA: 0x00006570 File Offset: 0x00004770
		// (set) Token: 0x0600031F RID: 799 RVA: 0x00006578 File Offset: 0x00004778
		public int Preference { get; set; }

		// Token: 0x06000320 RID: 800 RVA: 0x00006581 File Offset: 0x00004781
		public override void Decode(ByteStream stream)
		{
			this.Preference = stream.ReadVInt();
		}

		// Token: 0x06000321 RID: 801 RVA: 0x0000658F File Offset: 0x0000478F
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt(this.Preference);
		}

		// Token: 0x06000322 RID: 802 RVA: 0x0000659D File Offset: 0x0000479D
		public override void ApplyAvatarChange(LogicClientAvatar avatar)
		{
			avatar.SetWarPreference(this.Preference);
		}

		// Token: 0x06000323 RID: 803 RVA: 0x000065AB File Offset: 0x000047AB
		public override void ApplyAvatarChange(AllianceMemberEntry memberEntry)
		{
			memberEntry.SetWarPreference(this.Preference);
		}

		// Token: 0x06000324 RID: 804 RVA: 0x00005A9C File Offset: 0x00003C9C
		public override AvatarChangeType GetAvatarChangeType()
		{
			return AvatarChangeType.WAR_PREFERENCE;
		}

		// Token: 0x04000176 RID: 374
		[CompilerGenerated]
		private int int_0;
	}
}
