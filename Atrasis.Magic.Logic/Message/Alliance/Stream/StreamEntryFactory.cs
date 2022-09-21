using System;

namespace Atrasis.Magic.Logic.Message.Alliance.Stream
{
	// Token: 0x020000E8 RID: 232
	public class StreamEntryFactory
	{
		// Token: 0x06000A7E RID: 2686 RVA: 0x00024B7C File Offset: 0x00022D7C
		public static StreamEntry CreateStreamEntryByType(StreamEntryType type)
		{
			switch (type)
			{
			case StreamEntryType.DONATE:
				return new DonateStreamEntry();
			case StreamEntryType.CHAT:
				return new ChatStreamEntry();
			case StreamEntryType.JOIN_REQUEST:
				return new JoinRequestAllianceStreamEntry();
			case StreamEntryType.ALLIANCE_EVENT:
				return new AllianceEventStreamEntry();
			case StreamEntryType.REPLAY:
				return new ReplayStreamEntry();
			case StreamEntryType.CHALLENGE_REPLAY:
				return new ChallengeReplayStreamEntry();
			case StreamEntryType.CHALLENGE:
				return new ChallengeStreamEntry();
			case StreamEntryType.ALLIANCE_GIFT:
				return new AllianceGiftStreamEntry();
			case StreamEntryType.BASE_BUILDER_BATTLE_REQUEST:
				return new BaseBuilderBattleRequestStreamEntry();
			case StreamEntryType.BASE_BUILDER_BATTLE_REPLAY:
				return new BaseBuilderBattleReplayStreamEntry();
			case StreamEntryType.DUEL_REPLAY:
				return new DuelReplayStreamEntry();
			}
			return null;
		}
	}
}
