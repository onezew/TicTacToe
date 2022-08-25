using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Game : Form
    {
        public Game(string xPlayer, string oPlayer)
        {
            InitializeComponent();
        }

        private void Game_Load(object sender, EventArgs e)
        {

        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            bunifuSnackbar1.Show(this, "Player one won the game!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Information, 3000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomRight);
        }
    }
}
