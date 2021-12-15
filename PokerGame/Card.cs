using System;
using System.Collections.Generic;

namespace PokerGame
{
	class Card
	{
		public Symbol SymbolOfCard { get; }
		public CardValue ValueOfCard { get; }
		
		public Card(Symbol SymbolOfCard, CardValue ValueOfCard)
		{
			this.SymbolOfCard = SymbolOfCard;
			this.ValueOfCard = ValueOfCard;
		}

		public override string ToString()
		{
			return getValueChar() + getSymbolChar();
		}

		private char getSymbolChar()
		{
			switch (SymbolOfCard)
			{
				case Symbol.CLUB:
					return '♣';
				case Symbol.DIAMOND:
					return '♦';
				case Symbol.HEART:
					return '♥';
				case Symbol.SPADE:
					return '♠';
				default:
					return '?';
			}
		}

		private string getValueChar()
		{
			switch (ValueOfCard)
			{
				case CardValue.TWO:
					return "2";
				case CardValue.THREE:
					return "3";
				case CardValue.FOUR:
					return "4";
				case CardValue.FIVE:
					return "5";
				case CardValue.SIX:
					return "6";
				case CardValue.SEVEN:
					return "7";
				case CardValue.EIGHT:
					return "8";
				case CardValue.NINE:
					return "9";
				case CardValue.TEN:
					return "10";
				case CardValue.JUMBO:
					return "J";
				case CardValue.DAMA:
					return "D";
				case CardValue.KING:
					return "K";
				case CardValue.ACE:
					return "A";
				default:
					return "?";
			}
		}
	}
}