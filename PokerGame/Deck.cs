using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerGame
{
	class Deck
	{
		public int DeckSize => DeckOfCards.Count;
		private Queue<Card> DeckOfCards = new Queue<Card>();

		public Deck(int count = 1)
		{
			for (int i = 0; i < count; i++)
			{
				FillUpDeck();
			}
			ShuffleDeck();
		}

		private void FillUpDeck()
		{
			int sizeOfCardValue = Enum.GetValues(typeof(CardValue)).Length;
			int sizeOfSymbol = Enum.GetValues(typeof(Symbol)).Length;

			for (int h = 0; h < sizeOfSymbol; h++)
			{
				for (int y = 0; y < sizeOfCardValue; y++)
				{
					DeckOfCards.Enqueue(new Card((Symbol)h, (CardValue)y));
				}
			}
		}

		Random rnd = new Random();

		private void ShuffleDeck()
		{
			List<Card> randomizedList = DeckOfCards.OrderBy(x => rnd.Next()).ToList();
			DeckOfCards = new Queue<Card>();

			foreach (var item in randomizedList)
			{
				DeckOfCards.Enqueue(item);
			}
		}

		public Card Draw()
		{
			return DeckOfCards.Dequeue();
		}
	}
}
