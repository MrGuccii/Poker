using System;
using System.Collections.Generic;

namespace PokerGame
{
	class Deck
	{
		public List<Card> DeckOfCards { get; set; }

		public Deck()
		{
			DeckOfCards = new List<Card>();
			
			int sizeOfCardValue = Enum.GetValues(typeof(CardValue)).Length;
			int sizeOfColor = Enum.GetValues(typeof(Color)).Length;
			int sizeOfSymbol = Enum.GetValues(typeof(Symbol)).Length;

			for (int i = 0; i < sizeOfColor; i++)
			{
				for (int h = 0; h < sizeOfSymbol; h++)
				{
					for (int y = 0; y < sizeOfCardValue; y++)
					{
						DeckOfCards.Add(new Card((Color)i, (Symbol)h, (CardValue)y));
					}
				}
			}
		}
	}
}
