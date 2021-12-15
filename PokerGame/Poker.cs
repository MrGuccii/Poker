using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokerGame
{
	class Poker
	{
		public string GameMode { get; set; }
		public List<Card> PlayerCards { get; private set; }
		public List<Card> ComputerCards { get; private set; }
		public List<Card> TableCards { get; }

		private Combinations combinationOfPlayer;
		private Combinations combinationOfComputer;

		public Poker(string GameMode)
		{
			this.GameMode = GameMode;
			PlayerCards = new List<Card>();
			ComputerCards = new List<Card>();
			if (GameMode == "Texas hold-em")
			{
				TableCards = new List<Card>();
			}
		}

		public void GenerateCards()
		{
			if (GameMode == "Texas hold-em")
			{
				GenerateTexasCards();
			}
			else if(GameMode == "Five laps")
			{
				//GenerateFiveLapsCards();
			}
		}

		public void GenerateTexasCards()
		{	
			for (int i = 0; i < 5; i++)
			{
				TableCards.Add(new Card());
			}
			for (int i = 0; i < 2; i++)
			{
				PlayerCards.Add(new Card());
				ComputerCards.Add(new Card());
			}
			EvaluationOfCards();
		}

		public void EvaluationOfCards()
		{
			if (GameMode=="Texas hold-em")
			{
				foreach (var item in TableCards)
				{
					PlayerCards.Add(item);
					ComputerCards.Add(item);
				}
			}

			//PlayerCards = PlayerCards.OrderByDescending(x => x.ValueOfCard).ToList();
			//ComputerCards = ComputerCards.OrderByDescending(x => x.ValueOfCard).ToList();
			WhoIsTheWinner();
		}

		private void WhoIsTheWinner()
		{
			FindPair(PlayerCards);
			FindPair(ComputerCards);
			FindTwoPairs(PlayerCards);
			FindTwoPairs(ComputerCards);
			FindThreeKind(PlayerCards);
			//FindRoyalFlush();
		}

		private void FindPair(List<Card> ListOfCards)
		{	
			for (int i = 0; i < ListOfCards.Count; i++)
			{
				for (int h = i; h < ListOfCards.Count; h++)
				{
					if (ListOfCards[i].ValueOfCard == ListOfCards[h].ValueOfCard)
					{
						combinationOfPlayer = Combinations.ONEPAIR;
						break;
					}
				}
			}
		}

		private void FindTwoPairs(List<Card> ListOfCards)
		{
			bool firstPairIsFound = false;
			CardValue foundPairValue = CardValue.TWO;
			for (int i = 0; i < ListOfCards.Count; i++)
			{
				for (int h = i + 1; h < ListOfCards.Count; h++)
				{
					if (!firstPairIsFound && ListOfCards[i].ValueOfCard == ListOfCards[h].ValueOfCard)
					{
						foundPairValue = ListOfCards[i].ValueOfCard;
						firstPairIsFound = true;
					}
					else if(firstPairIsFound && ListOfCards[i].ValueOfCard != foundPairValue && ListOfCards[i].ValueOfCard == ListOfCards[h].ValueOfCard)
					{
						combinationOfPlayer = Combinations.TWOPAIR;
						break;
					}
				}
			}
		}

		private void FindThreeKind(List<Card> ListOfCards)
		{
			bool firstTwoIsFound = false;
			CardValue firstTwoValue = CardValue.TWO;
			for (int i = 0; i < ListOfCards.Count-2; i++)
			{
				for (int h = i + 1; h < ListOfCards.Count; h++)
				{
					if (!firstTwoIsFound && ListOfCards[i].ValueOfCard == ListOfCards[h].ValueOfCard)
					{
						firstTwoValue = ListOfCards[i].ValueOfCard;
						firstTwoIsFound = true;
					}
					else if (firstTwoIsFound && ListOfCards[h].ValueOfCard == firstTwoValue)
					{
						combinationOfPlayer = Combinations.THREEKIND;
						MessageBox.Show("drill");
						break;
					}
				}
			}
		}

		/*private void FindRoyalFlush()
		{
			PlayerCards = PlayerCards.OrderByDescending(x => x.ColorOfCard).ThenByDescending(x => x.SymbolOfCard).ThenByDescending(x => x.ValueOfCard).ToList();
		

			bool foundAce = false;
			int AcePosition = 0;
			Card firstCardOfCombination = null;

			for (int i = 0; i  < PlayerCards.Count; i++)
			{
				if (PlayerCards[i].ValueOfCard == CardValue.ACE)
				{
					foundAce = true;
					AcePosition = i;
					firstCardOfCombination = PlayerCards[i];
					break;
				}

			}
			
			List<Card> RoyalFlush = new List<Card>();
			for (int i = 12; i > 7; i--)
			{
				RoyalFlush.Add(new Card(0, 0, (CardValue)i));
			}

			if (foundAce)
			{
				for (int i = 0; i < 5; i++)
				{
					if (PlayerCards[i + AcePosition].ValueOfCard == RoyalFlush[i].ValueOfCard)
					{
						if (RoyalFlush.Last().ValueOfCard == PlayerCards[i].ValueOfCard)
						{
							MessageBox.Show("asd");
						}
					}
					else
					{
						break;
					}
				}
			}
		}*/
	}
}