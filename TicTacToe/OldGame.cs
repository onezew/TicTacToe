using System;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class bunifuImageButton1 : Form
    {
        public string xPlayerName, oPlayerName;
        public int[,] table = { { 0, 0, 0}, { 0, 0, 0 }, { 0, 0, 0 } };
        /*
         * (!) 0 - Nothing
         * (!) 1 - X
         * (!) 2 - O
        */
        public int turnPlayer = 1; // 1 - X | 2 - O
        public int xPlayerScore = 0, oPlayerScore = 0;
        public void Game(string xPlayer, string oPlayer, int player1Score, int player2Score)
        {
            InitializeComponent();
            xPlayerName = xPlayer;
            oPlayerName = oPlayer;
            xPlayerScore = player1Score;
            oPlayerScore = player2Score;
        }

        private void Game_Load(object sender, EventArgs e)
        {
            Player1TileButton.LabelText = xPlayerName;
            Player2TileButton.LabelText = oPlayerName;
        }

        public void checkGameDone()
        {
            // Rows
            if (table[0, 0] == table[0, 1] && table[0, 1] == table[0, 2] && table[0, 2] != 0) 
            {
                if(turnPlayer == 1) // Player 2 wins
                {
                    MessageBox.Show(oPlayerName + " wins the game.");
                }
                else
                {
                    MessageBox.Show(xPlayerName + " wins the game.");
                }
            }
            else if(table[1, 0] == table[1, 1] && table[1, 1] == table[1, 2] && table[1, 2] != 0)
            {
                if (turnPlayer == 1) // Player 2 wins
                {
                    MessageBox.Show(oPlayerName + " wins the game.");
                }
                else
                {
                    MessageBox.Show(xPlayerName + " wins the game.");
                }
            }
            else if(table[2, 0] == table[2, 1] && table[2, 1] == table[2, 2] && table[2, 2] != 0)
            {
                if(turnPlayer == 1) // Player 2 wins
                {
                    MessageBox.Show(oPlayerName + " wins the game.");
                }
                else
                {
                    MessageBox.Show(xPlayerName + " wins the game.");
                }
            }
        }

        public void newMove(object sender, EventArgs e)
        {
            Bunifu.UI.WinForms.BunifuImageButton thisTile = (Bunifu.UI.WinForms.BunifuImageButton)sender;
            int posX = 0, posY = 0;
            posX = int.Parse(thisTile.Tag.ToString()) / 10 - 1;
            posY = int.Parse(thisTile.Tag.ToString()) % 10 - 1;
            if (table[posX, posY] == 0) // the cell is empty
            {
                if(turnPlayer == 1) // X is playing
                {
                    thisTile.Image = Properties.Resources.x_png_18__1_;
                    table[posX, posY] = turnPlayer;
                    turnPlayer = 2;
                }
                else // O is playing
                {
                    thisTile.Image = Properties.Resources.literaObuna__1_;
                    table[posX, posY] = turnPlayer;
                    turnPlayer = 1;
                }
                thisTile.Enabled = false;
            }
            checkGameDone();
        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            bunifuSnackbar1.Show(this, "Player one won the game!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Information, 3000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomRight);
        }
    }
}
