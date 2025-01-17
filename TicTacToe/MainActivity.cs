﻿using System;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class MainActivity : Form
    {
        public MainActivity()
        {
            InitializeComponent();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (bunifuTextBox1.Text == "" || bunifuTextBox2.Text == "")
            {
                bunifuSnackbar1.Show(this, "All players should have a nickname.", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomRight);
                return;
            }
            new Game(bunifuTextBox1.Text, bunifuTextBox2.Text, 0, 0, true).Show();
            Hide();
        }
    }
}
