using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerGame
{
    class Hand
    {
        private Deck _deck;
        private List<Card> _cards = new List<Card>();
        
        public Hand(Deck deck, int drawCount)
        {
            _deck = deck;
            DrawCards(drawCount);
        }

        private void DrawCards(int drawCount)
        {
            for (int i = 0; i < drawCount; i++)
            {
                _cards.Add(_deck.Draw());
            }
        }

        public bool HasExactlyFiveCards()
        {
            return _cards.Count == 5;
        }

        private enum WhoWins
        {
            ME,
            OTHER,
            DRAW,
            UNKNOWN
        }

        private WhoWins WhoHasHighHand(Hand otherHand, int numberOfCards)
        {
            Hand myHandContainingFourOfAKind = LeaveAll(numberOfCards);
            Hand otherHandContainingFourOfAKind = otherHand.LeaveAll(numberOfCards);
            var v = CheckHighCard(myHandContainingFourOfAKind, otherHandContainingFourOfAKind);
            if (v == WhoWins.DRAW)
            {
                Hand myHandWithoutFourOfAKind = TakeAway(numberOfCards);
                Hand otherHandWithoutFourOfAKind = otherHand.TakeAway(numberOfCards);
                return CheckHighCard(myHandWithoutFourOfAKind, otherHandWithoutFourOfAKind);
            }

            return v;
        }

        private WhoWins CheckRoyalFlush(Hand otherHand)
        {
            if (HasRoyalFlush() && !otherHand.HasRoyalFlush())
            {
                return WhoWins.ME;
            }

            if (otherHand.HasRoyalFlush() && !HasRoyalFlush())
            {
                return WhoWins.OTHER;
            }

            if (HasRoyalFlush() && otherHand.HasRoyalFlush())
            {
                return WhoWins.DRAW;
            }

            return WhoWins.UNKNOWN;
        }

        private WhoWins CheckStraightFlush(Hand otherHand)
        {
            if (HasStraightFlush() && !otherHand.HasStraightFlush())
            {
                return WhoWins.ME;
            }

            if (otherHand.HasStraightFlush() && !HasStraightFlush())
            {
                return WhoWins.OTHER;
            }

            if (HasStraightFlush() && otherHand.HasStraightFlush())
            {
                return WhoWins.DRAW;
            }

            return WhoWins.UNKNOWN;
        }

        private WhoWins CheckFourOfAKind(Hand otherHand)
        {
            if (HasFourOfAKind() && !otherHand.HasFourOfAKind())
            {
                return WhoWins.ME;
            }

            if (otherHand.HasFourOfAKind() && !HasFourOfAKind())
            {
                return WhoWins.OTHER;
            }

            if (otherHand.HasFourOfAKind() && HasFourOfAKind())
            {
                return WhoHasHighHand(otherHand, 4);
            }

            return WhoWins.UNKNOWN;
        }

        private WhoWins CheckFullHouse(Hand otherHand)
        {
            if (HasFullHouse() && !otherHand.HasFullHouse())
            {
                return WhoWins.ME;
            }

            if (otherHand.HasFullHouse() && !HasFullHouse())
            {
                return WhoWins.OTHER;
            }

            if (otherHand.HasFullHouse() && HasFullHouse())
            {
                WhoHasHighHand(otherHand, 3);
            }

            return WhoWins.UNKNOWN;
        }

        private WhoWins CheckFlush(Hand otherHand)
        {
			if (HasFlush() && !otherHand.HasFlush())
			{
                return WhoWins.ME;
			}

            if (otherHand.HasFlush() && !HasFlush())
            {
                return WhoWins.OTHER;
            }

            if (otherHand.HasFlush() && HasFlush())
            {
                return CheckHighCard(this, otherHand);
            }

            return WhoWins.UNKNOWN;
        }

        private WhoWins CheckStraight(Hand otherHand)
        {
			if (HasStraight() && !otherHand.HasStraight())
			{
                return WhoWins.ME;
			}

			if (otherHand.HasStraight() && !HasStraight())
			{
                return WhoWins.OTHER;
			}

			if (otherHand.HasStraight() && HasStraight())
			{
                return CheckHighCard(this, otherHand);
			}

            return WhoWins.UNKNOWN;
        }

        private WhoWins CheckDrill(Hand otherHand)
        {
            if (HasDrill() && !otherHand.HasDrill())
            {
                return WhoWins.ME;
            }

            if (otherHand.HasDrill() && !HasDrill())
            {
                return WhoWins.OTHER;
            }

            if (otherHand.HasDrill() && HasDrill())
            {
                return WhoHasHighHand(otherHand, 3);
            }

            return WhoWins.UNKNOWN;
        }

        private WhoWins CheckTwoPair(Hand otherHand)
        {
            if (HasTwoPair() && !otherHand.HasTwoPair())
            {
                return WhoWins.ME;
            }

            if (otherHand.HasTwoPair() && !HasTwoPair())
            {
                return WhoWins.OTHER;
            }

            if (otherHand.HasTwoPair() && HasTwoPair())
            {
                return WhoHasHighHand(otherHand, 2);
            }

            return WhoWins.UNKNOWN;
        }

        private WhoWins CheckPair(Hand otherHand)
        {
            if (HasPair() && !otherHand.HasPair())
            {
                return WhoWins.ME;
            }

            if (otherHand.HasPair() && !HasPair())
            {
                return WhoWins.OTHER;
            }

            if (otherHand.HasPair() && HasPair())
            {
                return WhoHasHighHand(otherHand, 2);
            }

            return WhoWins.UNKNOWN;
        }

        private WhoWins CheckHighCard(Hand myHandContainingFourOfAKind, Hand otherHandContainingFourOfAKind)
        {
            myHandContainingFourOfAKind._cards = myHandContainingFourOfAKind._cards.OrderByDescending(card => card.ValueOfCard).ToList();
            otherHandContainingFourOfAKind._cards = otherHandContainingFourOfAKind._cards.OrderByDescending(card => card.ValueOfCard).ToList();

            if (myHandContainingFourOfAKind._cards[0].ValueOfCard > otherHandContainingFourOfAKind._cards[0].ValueOfCard)
			{
                return WhoWins.ME;
			}

			if (otherHandContainingFourOfAKind._cards[0].ValueOfCard > myHandContainingFourOfAKind._cards[0].ValueOfCard)
			{
                return WhoWins.OTHER;
			}

			if (myHandContainingFourOfAKind._cards[0].ValueOfCard == otherHandContainingFourOfAKind._cards[0].ValueOfCard)
			{
                return WhoWins.DRAW;
			}

            return WhoWins.UNKNOWN;
        }

        private Hand TakeAway(int numberOfMatchingCards)
        {
            Hand result = new Hand(this);
            foreach (CardValue v in Enum.GetValues(typeof(CardValue)))
            {
                if (CountCardsWithValueValueOf(v) == numberOfMatchingCards)
                {
                    result._cards.RemoveAll(x => x.ValueOfCard == v);
                    return result;
                }
            }

            return null;
        }

        private Hand LeaveAll(int numberOfMatchingCards)
        {
            Hand result = new Hand(this);
            foreach (CardValue v in Enum.GetValues(typeof(CardValue)))
            {
                if (CountCardsWithValueValueOf(v) == numberOfMatchingCards)
                {
                    result._cards.RemoveAll(x => x.ValueOfCard != v);
                    return result;
                }
            }

            return null;
        }

        private Hand(Hand parent)
        {
            _deck = parent._deck;
            _cards = new List<Card>(parent._cards);
        }

        private bool HasRoyalFlush()
        {
            if (NumberOfDifferentSuites() != 1) return false;

            if (CountCardsWithValueValueOf(CardValue.ACE) != 1) return false;
            if (CountCardsWithValueValueOf(CardValue.KING) != 1) return false;
            if (CountCardsWithValueValueOf(CardValue.DAMA) != 1) return false;
            if (CountCardsWithValueValueOf(CardValue.JUMBO) != 1) return false;
            if (CountCardsWithValueValueOf(CardValue.TEN) != 1) return false;
            return true;
        }

        private bool HasStraightFlush()
        {
            if (NumberOfDifferentSuites() != 1) return false;
            if (!HasStraight()) return false;
            return true;
        }

        private bool HasFourOfAKind()
        {
            return Enum.GetValues(typeof(CardValue)).Cast<CardValue>().Any(v => CountCardsWithValueValueOf(v) == 4);
        }

        private bool HasFullHouse()
        {
			if (HasDrill() && HasPair())
			{
                return true;
			}

            return false;
        }

        private bool HasFlush()
        {
            return Enum.GetValues(typeof(Symbol)).Cast<Symbol>().Any(v => CountCardsWithSymbolOf(v) == 5);
        }

        private bool HasStraight()
        {
            for (int i = 1; i <= 10; i++)
            {
                bool x = true;
                for (int j = 0; j < 5; j++)
                {
                    x &= HasCardNumericValueOf(i + j);
                }

                if (x) return true;
            }

            return false;
        }

        private bool HasDrill()
        {
            return Enum.GetValues(typeof(CardValue)).Cast<CardValue>().Any(v => CountCardsWithValueValueOf(v) == 3);
        }

        private bool HasTwoPair()
        {
            Hand handWithTwoPair;
            if (HasPair())
			{
                handWithTwoPair = TakeAway(2);
				if (handWithTwoPair.HasPair())
				{
                    return true;
				}
			}
            return false;
        }
        
        private bool HasPair()
        {
            return Enum.GetValues(typeof(CardValue)).Cast<CardValue>().Any(v => CountCardsWithValueValueOf(v) == 2);
        }

        private int GetWinner(WhoWins w)
        {
			switch (w)
			{
				case WhoWins.ME:
                    return 1;
				case WhoWins.OTHER:
                    return -1;
				case WhoWins.DRAW:
                    return 0;
				default:
                    return -1000;
			}
        }

        public int BetterThan(Hand otherHand)
        {
            if (!HasExactlyFiveCards()) throw new Exception("Hands must contain exactly 5 cards!");
            if (!otherHand.HasExactlyFiveCards()) throw new Exception("Hands must contain exactly 5 cards!");

            WhoWins winner = CheckRoyalFlush(otherHand);
            if (winner != WhoWins.UNKNOWN)
            {
                return GetWinner(winner);
            }

            winner = CheckStraightFlush(otherHand);
            if (winner != WhoWins.UNKNOWN)
            {
                return GetWinner(winner);
            }

            winner = CheckFourOfAKind(otherHand);
            if (winner != WhoWins.UNKNOWN)
            {
                return GetWinner(winner);
            }

            winner = CheckFullHouse(otherHand);
			if (winner != WhoWins.UNKNOWN)
			{
                return GetWinner(winner);
			}

            winner = CheckFlush(otherHand);
			if (winner != WhoWins.UNKNOWN)
			{
                return GetWinner(winner);
			}

            winner = CheckStraight(otherHand);
			if (winner != WhoWins.UNKNOWN)
			{
                return GetWinner(winner);
			}

            winner = CheckDrill(otherHand);
			if (winner != WhoWins.UNKNOWN)
			{
                return GetWinner(winner);
			}

            winner = CheckTwoPair(otherHand);
			if (winner != WhoWins.UNKNOWN)
			{
                return GetWinner(winner);
			}

            winner = CheckPair(otherHand);
			if (winner != WhoWins.UNKNOWN)
			{
                return GetWinner(winner);

			}

            winner = CheckHighCard(this, otherHand);
			if (winner != WhoWins.UNKNOWN)
			{
                return GetWinner(winner);
			}
            return 0;
        }

        private int CountCardsWithValueValueOf(CardValue value)
        {
            return _cards.Count(card => card.ValueOfCard == value);
        }

        private int CountCardsWithSymbolOf(Symbol s)
        {
            return _cards.Count(x => x.SymbolOfCard == s);
        }

        private int NumberOfDifferentSuites()
        {
            return Enum.GetValues(typeof(Symbol)).Cast<Symbol>().Count(t => CountCardsWithSymbolOf(t) != 0);
        }

        private bool HasCardNumericValueOf(int value)
        {
            if (CountCardsWithValueValueOf(CardValue.ACE) == 1 && value == 1) return true;
            if (CountCardsWithValueValueOf(CardValue.TWO) == 1 && value == 2) return true;
            if (CountCardsWithValueValueOf(CardValue.THREE) == 1 && value == 3) return true;
            if (CountCardsWithValueValueOf(CardValue.FOUR) == 1 && value == 4) return true;
            if (CountCardsWithValueValueOf(CardValue.FIVE) == 1 && value == 5) return true;
            if (CountCardsWithValueValueOf(CardValue.SIX) == 1 && value == 6) return true;
            if (CountCardsWithValueValueOf(CardValue.SEVEN) == 1 && value == 7) return true;
            if (CountCardsWithValueValueOf(CardValue.EIGHT) == 1 && value == 8) return true;
            if (CountCardsWithValueValueOf(CardValue.NINE) == 1 && value == 9) return true;
            if (CountCardsWithValueValueOf(CardValue.TEN) == 1 && value == 10) return true;
            if (CountCardsWithValueValueOf(CardValue.JUMBO) == 1 && value == 11) return true;
            if (CountCardsWithValueValueOf(CardValue.DAMA) == 1 && value == 12) return true;
            if (CountCardsWithValueValueOf(CardValue.KING) == 1 && value == 13) return true;
            if (CountCardsWithValueValueOf(CardValue.ACE) == 1 && value == 14) return true;
            return false;
        }

        public string GetCards()
        {
            return string.Join(" ", _cards);
        }

        public Hand CombineHandWith(Hand hand2)
        {
            Hand result = new Hand(this);
            foreach (var card in hand2._cards)
            {
                result._cards.Add(card);
            }

            return result;
        }

        public List<Hand> GetFiveCardCombinations()
        {
            List<Hand> result = new List<Hand>();
            for (int i = 0; i < _cards.Count - 1; i++)
            {
                for (int j = i + 1; j < _cards.Count; j++)
                {
                    Hand hand = new Hand(this);
                    hand._cards.RemoveAt(j);
                    hand._cards.RemoveAt(i);
                    result.Add(hand);
                }
            }

            return result;
        }
    }
}