using System.Collections.Generic;

namespace PokerGame
{
	class TexasHoldem : Deal
	{
        private Hand commonCards;
        public TexasHoldem()
        {
            commonCards = new Hand(Deck, 5);
            Player = new Hand(Deck, 2);
            Computer = new Hand(Deck, 2);
        }
        
        public void CreateHandsFromCards()
        {
            List<Hand> playerHandCombination = CreateCombination(Player, commonCards);
            List<Hand> computerHandCombination = CreateCombination(Computer, commonCards);
        }

        private List<Hand> CreateCombination(Hand hand1, Hand hand2)
        {
            Hand cards = hand1.CombineHandWith(hand2);
            List<Hand> combinations = cards.GetFiveCardCombinations();
            return combinations;
        }
    }
}
