using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame
{
	class Card
	{
		public Color ColorOfCard { get; set; }
		public Symbol SymbolOfCard { get; set; }
		public CardValue ValueOfCard { get; set; }

		static Queue<Card> randomizedDeck = new Queue<Card>();

		private static Random rnd = new Random();

		public Card()
		{
			if (randomizedDeck.Count==0)
			{
				ShuffleDeck();
			}
			Card newCard = randomizedDeck.Dequeue();
			ColorOfCard = newCard.ColorOfCard;
			SymbolOfCard = newCard.SymbolOfCard;
			ValueOfCard = newCard.ValueOfCard;
		}
		
		public Card(Color ColorOfCard, Symbol SymbolOfCard, CardValue ValueOfCard)
		{
			this.ColorOfCard = ColorOfCard;
			this.SymbolOfCard = SymbolOfCard;
			this.ValueOfCard = ValueOfCard;
		}

		private void ShuffleDeck()
		{
			Deck deck = new Deck();
			List<Card> randomizedList = deck.DeckOfCards.OrderBy(x => rnd.Next()).ToList();
			foreach (var item in randomizedList)
			{
				randomizedDeck.Enqueue(item);
			}
		}
	}
}