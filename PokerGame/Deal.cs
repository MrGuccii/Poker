using PokerGame.Enums;

namespace PokerGame
{
	class Deal
	{
        protected Hand Player;
        protected Hand Computer;
        protected readonly Deck Deck = new Deck(1);

        public WhichPlayer GetWinningHand()
        {
			switch (Player.BetterThan(Computer))
			{
                case 1:
                    return WhichPlayer.PLAYER1;
                case 0:
                    return WhichPlayer.DRAW;
                case -1:
                    return WhichPlayer.COMPUTER;
			}

			return Player.BetterThan(Computer) == 1 ? WhichPlayer.PLAYER1 : WhichPlayer.COMPUTER;
        }

        private Hand GetHand(WhichPlayer player)
        {
			switch (player)
			{
				case WhichPlayer.PLAYER1:
                    return Player;
				case WhichPlayer.COMPUTER:
                    return Computer;
				default:
                    return null;
			}
        }

        public string PrintCards(WhichPlayer player)
        {
            return "Player " + player + "'s hand is: " + GetHand(player).GetCards();
        }
    }
}
