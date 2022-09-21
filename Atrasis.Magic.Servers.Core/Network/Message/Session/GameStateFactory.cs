using System;
using Atrasis.Magic.Servers.Core.Network.Message.Session.State;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session
{
	// Token: 0x02000044 RID: 68
	public static class GameStateFactory
	{
		// Token: 0x060001A6 RID: 422 RVA: 0x0000C108 File Offset: 0x0000A308
		public static GameState CreateByType(GameStateType type)
		{
			switch (type)
			{
			case GameStateType.HOME:
				return new GameHomeState();
			case GameStateType.NPC_ATTACK:
				return new GameNpcAttackState();
			case GameStateType.NPC_DUEL:
				return new GameNpcDuelState();
			case GameStateType.MATCHED_ATTACK:
				return new GameMatchedAttackState();
			case GameStateType.CHALLENGE_ATTACK:
				return new GameChallengeAttackState();
			case GameStateType.FAKE_ATTACK:
				return new GameFakeAttackState();
			case GameStateType.DUEL:
				return new GameDuelState();
			case GameStateType.VISIT:
				return new GameVisitState();
			default:
				Logging.Error("GameStateFactory: unknown game state type: " + type);
				return null;
			}
		}
	}
}
