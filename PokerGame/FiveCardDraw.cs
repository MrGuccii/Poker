namespace PokerGame
{
	class FiveCardDraw : Deal
	{
		public FiveCardDraw()
		{
			Player = new Hand(Deck, 5);
			Computer = new Hand(Deck, 5);
		}
	}
}
