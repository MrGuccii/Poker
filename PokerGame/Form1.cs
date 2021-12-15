using PokerGame.Enums;
using System;
using System.Windows.Forms;

namespace PokerGame
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		static string _gameMode = "Texas hold-em";

		private void BT_Texas_Click(object sender, EventArgs e)
		{
			_gameMode = "Texas hold-em";
			BT_Texas.Enabled = false;
			BT_FiveLaps.Enabled = true;
			LB_GameMode.Text = _gameMode;
		}

		private void BT_FiveLaps_Click(object sender, EventArgs e)
		{
			_gameMode = "Five laps";
			BT_FiveLaps.Enabled = false;
			BT_Texas.Enabled = true;
			LB_GameMode.Text = _gameMode;
		}

		private void BT_Play_Click(object sender, EventArgs e)
		{
			if (_gameMode == "Five laps")
			{
				Deal deal = new FiveCardDraw();
				LB_PlayerCards.Text = deal.PrintCards(WhichPlayer.PLAYER1);
				LB_ComputerCards.Text = deal.PrintCards(WhichPlayer.COMPUTER);
				LB_Winner.Text = "The winner is: " + deal.GetWinningHand();
			}
			/*else
			{
				Deal deal = new TexasHoldem();
				LB_PlayerCards.Text = deal.PrintCards(WhichPlayer.PLAYER1);
				LB_ComputerCards.Text = deal.PrintCards(WhichPlayer.COMPUTER);
				LB_Winner.Text = "The winner is: " + deal.GetWinningHand();
			}*/
		}
	}
}
