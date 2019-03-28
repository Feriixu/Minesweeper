using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{ 
    public class CustomEventArgs
    {
        public CustomEventArgs(int n)
        {
            num = n;
        }
        private int num;
        public int Num
        {
            get { return num; }
        }
    }

    class MineButton : System.Windows.Forms.Button
    {
        private bool isBomb;
        private int nearby;
        private int num;
        public delegate void ButtonClickDelegate(object sender, CustomEventArgs e);
        public event ButtonClickDelegate RaiseCustomEvent;

        public bool IsBomb { get => isBomb; set => isBomb = value; }
        public int Nearby { get => nearby; set => nearby = value; }
        public int Num { get => num; set => num = value; }

        public MineButton()
        {
            this.Size = new System.Drawing.Size(40, 40);
            this.Click += buttonClick;
            this.BackColor = Color.LightGray;
            this.TabStop = false;
        }

        private void buttonClick(object sender, EventArgs e)
        {
            ButtonClickDelegate handler = RaiseCustomEvent;
            if (handler != null)
            {
                handler(this, new CustomEventArgs(this.num));
            }
        }
    }
}
