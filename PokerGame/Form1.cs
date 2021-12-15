using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
			Poker poker = new Poker(_gameMode);
			poker.GenerateCards();
			foreach (var item in poker.PlayerCards)
			{
				ListBox_Player.Items.Add(ThreeAttributesOfCard(item));
			}
			foreach (var item in poker.ComputerCards)
			{
				ListBox_Computer.Items.Add(ThreeAttributesOfCard(item));
			}
			if (poker.GameMode=="Texas hold-em")
			{
				foreach (var item in poker.TableCards)
				{
					ListBox_Table.Items.Add(ThreeAttributesOfCard(item));
				}
			}
		}

		private string ThreeAttributesOfCard(Card card)
		{ 
			return card.ColorOfCard+", "+card.SymbolOfCard+", "+card.ValueOfCard;
		}
	}
}
