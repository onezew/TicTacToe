using Bunifu.UI.WinForms;
using System;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Game : Form
    {
        public string xPlayerName, oPlayerName;
        public int[,] table = { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        /*
         * (!) 0 - Nothing
         * (!) 1 - X
         * (!) 2 - O
        */
        public int turnPlayer = 1; // 1 - X | 2 - O
        public int xPlayerScore = 0, oPlayerScore = 0;
        public bool isDraw = false, isFirstGame;
        public Game(string xPlayer, string oPlayer, int player1Score, int player2Score, bool firstGame)
        {
            InitializeComponent();
            isFirstGame = firstGame;
            if(isFirstGame)
            {
                xPlayerName = xPlayer;
                oPlayerName = oPlayer;
                xPlayerScore = player1Score;
                oPlayerScore = player2Score;
            }
            else
            {
                xPlayerName = oPlayer;
                oPlayerName = xPlayer;
                xPlayerScore = player2Score;
                oPlayerScore = player1Score;
            }
        }

        private void Game_Load(object sender, EventArgs e)
        {
            Player1TileButton.LabelText = xPlayerName;
            Player2TileButton.LabelText = oPlayerName;
            xPlayerScoreLabel.Text = "Score: " + xPlayerScore.ToString();
            oPlayerScoreLabel.Text = "Score: " + oPlayerScore.ToString();
        }

        private void resetTimer_Tick(object sender, EventArgs e)
        {
            if(isDraw)
            {
                new Game(xPlayerName, oPlayerName, xPlayerScore, oPlayerScore, false).Show();
                Close();
            }
            else
            {
                if (turnPlayer == 1) // Player 2 wins
                {
                    new Game(xPlayerName, oPlayerName, xPlayerScore, ++oPlayerScore, false).Show();
                    Close();
                }
                else // Player 1 wins
                {
                    new Game(xPlayerName, oPlayerName, ++xPlayerScore, oPlayerScore, false).Show();
                    Close();
                }
            }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            new MainActivity().Show();
            this.Close();
        }

        public void checkGameDone()
        {
            bool gameFinished = false;
            // Rows
            if ((table[0, 0] == table[0, 1] && table[0, 1] == table[0, 2] && table[0, 2] != 0) ||
                (table[1, 0] == table[1, 1] && table[1, 1] == table[1, 2] && table[1, 2] != 0) ||
                (table[2, 0] == table[2, 1] && table[2, 1] == table[2, 2] && table[2, 2] != 0))
            {
                if (turnPlayer == 1) // Player 2 wins
                {
                    bunifuSnackbar1.Show(this, oPlayerName + " wins the game.\nThe game will automatically restart!", BunifuSnackbar.MessageTypes.Success, 3000, "", BunifuSnackbar.Positions.BottomRight);
                }
                else // Player 1 wins
                {
                    bunifuSnackbar1.Show(this, xPlayerName + " wins the game.\nThe game will automatically restart!", BunifuSnackbar.MessageTypes.Success, 3000, "", BunifuSnackbar.Positions.BottomRight);
                }
                gameFinished = true;
            }
            // Columns
            else if ((table[0, 0] == table[1, 0] && table[1, 0] == table[2, 0] && table[2, 0] != 0) ||
                    (table[0, 1] == table[1, 1] && table[1, 1] == table[2, 1] && table[2, 1] != 0) ||
                    (table[0, 2] == table[1, 2] && table[1, 2] == table[2, 2] && table[2, 2] != 0))
            {
                if (turnPlayer == 1) // Player 2 wins
                {
                    bunifuSnackbar1.Show(this, oPlayerName + " wins the game.\nThe game will automatically restart!", BunifuSnackbar.MessageTypes.Success, 3000, "", BunifuSnackbar.Positions.BottomRight);
                }
                else // Player 1 wins
                {
                    bunifuSnackbar1.Show(this, xPlayerName + " wins the game.\nThe game will automatically restart!", BunifuSnackbar.MessageTypes.Success, 3000, "", BunifuSnackbar.Positions.BottomRight);
                }
                gameFinished = true;
            }
            // Diagonal
            else if ((table[0, 0] == table[1, 1] && table[1, 1] == table[2, 2] && table[2, 2] != 0) ||
                     (table[0, 2] == table[1, 1] && table[1, 1] == table[2, 0] && table[2, 0] != 0))
            {
                if (turnPlayer == 1) // Player 2 wins
                {
                    bunifuSnackbar1.Show(this, oPlayerName + " wins the game.\nThe game will automatically restart!", BunifuSnackbar.MessageTypes.Success, 3000, "", BunifuSnackbar.Positions.BottomRight);
                }
                else // Player 1 wins
                {
                    bunifuSnackbar1.Show(this, xPlayerName + " wins the game.\nThe game will automatically restart!", BunifuSnackbar.MessageTypes.Success, 3000, "", BunifuSnackbar.Positions.BottomRight);
                }
                gameFinished = true;
            }
            else
            {
                isDraw = true;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (table[i, j] == 0)
                        {
                            isDraw = false;
                        }

                    }
                }
            }
            if(gameFinished || isDraw)
            {
                if(isDraw)
                    bunifuSnackbar1.Show(this, "It is a draw.\nThe game will automatically restart!", BunifuSnackbar.MessageTypes.Success, 3000, "", BunifuSnackbar.Positions.BottomRight);
                resetTimer.Start();
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
                if (turnPlayer == 1) // X is playing
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

    }
}
