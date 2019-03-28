using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Form1 : Form
    {
        private MineButton[] mineButtons;
        private int[] positions = { -1, -11, -10, -9, 1, 9, 10, 11 };
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mineButtons = new MineButton[100];
            Random r = new Random();
            for (int i = 0; i < 100; i++)
            {
                MineButton button = new MineButton
                {
                    IsBomb = (r.Next(0, 4) == 0) ? true : false,
                    Num = i,
                };
                button.RaiseCustomEvent += CustomClick;
                button.Text = button.IsBomb ? "" : "";
                mineButtons[i] = button;
            }

            foreach (MineButton button in mineButtons)
            {
                tableLayoutPanelButtons.Controls.Add(button);
            }

        }

        private void CustomClick(object sender, CustomEventArgs e)
        {
            if (mineButtons[e.Num].IsBomb)
            {
                MessageBox.Show("Verloren!");
            }
            else
            {
                mineButtons[e.Num].Enabled = false;
                mineButtons[e.Num].FlatStyle = FlatStyle.Popup;
                mineButtons[e.Num].BackColor = Color.Gray;
                int count = 0;
                foreach (int position in positions)
                {
                    int checkPos = e.Num + position;
                    if (checkPos > 0 && checkPos < 99)
                    {
                        if (mineButtons[checkPos].IsBomb)
                            count++;
                    }
                }

                mineButtons[e.Num].Text = count.ToString();
            }
        }
    }
}
