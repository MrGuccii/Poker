
namespace PokerGame
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.BT_Play = new System.Windows.Forms.Button();
			this.BT_Texas = new System.Windows.Forms.Button();
			this.BT_FiveLaps = new System.Windows.Forms.Button();
			this.LB_GameModeText = new System.Windows.Forms.Label();
			this.LB_CurrentGameModeText = new System.Windows.Forms.Label();
			this.LB_GameMode = new System.Windows.Forms.Label();
			this.LB_PlayerCards = new System.Windows.Forms.Label();
			this.LB_ComputerCards = new System.Windows.Forms.Label();
			this.LB_TableCards = new System.Windows.Forms.Label();
			this.LB_Winner = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// BT_Play
			// 
			this.BT_Play.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BT_Play.Location = new System.Drawing.Point(15, 104);
			this.BT_Play.Name = "BT_Play";
			this.BT_Play.Size = new System.Drawing.Size(119, 30);
			this.BT_Play.TabIndex = 0;
			this.BT_Play.Text = "Play";
			this.BT_Play.UseVisualStyleBackColor = true;
			this.BT_Play.Click += new System.EventHandler(this.BT_Play_Click);
			// 
			// BT_Texas
			// 
			this.BT_Texas.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BT_Texas.Enabled = false;
			this.BT_Texas.Location = new System.Drawing.Point(15, 25);
			this.BT_Texas.Name = "BT_Texas";
			this.BT_Texas.Size = new System.Drawing.Size(119, 30);
			this.BT_Texas.TabIndex = 4;
			this.BT_Texas.Text = "Texas hold-em";
			this.BT_Texas.UseVisualStyleBackColor = true;
			this.BT_Texas.Click += new System.EventHandler(this.BT_Texas_Click);
			// 
			// BT_FiveLaps
			// 
			this.BT_FiveLaps.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BT_FiveLaps.Location = new System.Drawing.Point(140, 25);
			this.BT_FiveLaps.Name = "BT_FiveLaps";
			this.BT_FiveLaps.Size = new System.Drawing.Size(119, 30);
			this.BT_FiveLaps.TabIndex = 5;
			this.BT_FiveLaps.Text = "Five laps";
			this.BT_FiveLaps.UseVisualStyleBackColor = true;
			this.BT_FiveLaps.Click += new System.EventHandler(this.BT_FiveLaps_Click);
			// 
			// LB_GameModeText
			// 
			this.LB_GameModeText.AutoSize = true;
			this.LB_GameModeText.Location = new System.Drawing.Point(12, 9);
			this.LB_GameModeText.Name = "LB_GameModeText";
			this.LB_GameModeText.Size = new System.Drawing.Size(64, 13);
			this.LB_GameModeText.TabIndex = 6;
			this.LB_GameModeText.Text = "Game mode";
			// 
			// LB_CurrentGameModeText
			// 
			this.LB_CurrentGameModeText.AutoSize = true;
			this.LB_CurrentGameModeText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LB_CurrentGameModeText.Location = new System.Drawing.Point(11, 67);
			this.LB_CurrentGameModeText.Name = "LB_CurrentGameModeText";
			this.LB_CurrentGameModeText.Size = new System.Drawing.Size(189, 24);
			this.LB_CurrentGameModeText.TabIndex = 7;
			this.LB_CurrentGameModeText.Text = "Current game mode: ";
			// 
			// LB_GameMode
			// 
			this.LB_GameMode.AutoSize = true;
			this.LB_GameMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LB_GameMode.Location = new System.Drawing.Point(189, 67);
			this.LB_GameMode.Name = "LB_GameMode";
			this.LB_GameMode.Size = new System.Drawing.Size(137, 24);
			this.LB_GameMode.TabIndex = 8;
			this.LB_GameMode.Text = "Texas hold-em";
			// 
			// LB_PlayerCards
			// 
			this.LB_PlayerCards.AutoSize = true;
			this.LB_PlayerCards.Location = new System.Drawing.Point(15, 150);
			this.LB_PlayerCards.Name = "LB_PlayerCards";
			this.LB_PlayerCards.Size = new System.Drawing.Size(0, 13);
			this.LB_PlayerCards.TabIndex = 9;
			// 
			// LB_ComputerCards
			// 
			this.LB_ComputerCards.AutoSize = true;
			this.LB_ComputerCards.Location = new System.Drawing.Point(15, 205);
			this.LB_ComputerCards.Name = "LB_ComputerCards";
			this.LB_ComputerCards.Size = new System.Drawing.Size(0, 13);
			this.LB_ComputerCards.TabIndex = 10;
			// 
			// LB_TableCards
			// 
			this.LB_TableCards.AutoSize = true;
			this.LB_TableCards.Location = new System.Drawing.Point(15, 176);
			this.LB_TableCards.Name = "LB_TableCards";
			this.LB_TableCards.Size = new System.Drawing.Size(0, 13);
			this.LB_TableCards.TabIndex = 11;
			// 
			// LB_Winner
			// 
			this.LB_Winner.AutoSize = true;
			this.LB_Winner.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LB_Winner.Location = new System.Drawing.Point(14, 271);
			this.LB_Winner.Name = "LB_Winner";
			this.LB_Winner.Size = new System.Drawing.Size(0, 24);
			this.LB_Winner.TabIndex = 12;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(349, 384);
			this.Controls.Add(this.LB_Winner);
			this.Controls.Add(this.LB_TableCards);
			this.Controls.Add(this.LB_ComputerCards);
			this.Controls.Add(this.LB_PlayerCards);
			this.Controls.Add(this.LB_GameMode);
			this.Controls.Add(this.LB_CurrentGameModeText);
			this.Controls.Add(this.LB_GameModeText);
			this.Controls.Add(this.BT_FiveLaps);
			this.Controls.Add(this.BT_Texas);
			this.Controls.Add(this.BT_Play);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button BT_Play;
		private System.Windows.Forms.Button BT_Texas;
		private System.Windows.Forms.Button BT_FiveLaps;
		private System.Windows.Forms.Label LB_GameModeText;
		private System.Windows.Forms.Label LB_CurrentGameModeText;
		private System.Windows.Forms.Label LB_GameMode;
		private System.Windows.Forms.Label LB_PlayerCards;
		private System.Windows.Forms.Label LB_ComputerCards;
		private System.Windows.Forms.Label LB_TableCards;
		private System.Windows.Forms.Label LB_Winner;
	}
}

