using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lotteryGamesInterfaces
{
    public partial class Form1 : Form
    {
        int selectedNumbers = 0;
        int howManyNumbers = 0;
        int columns = 0;
        int rows = 0;
        
        public Form1()
        {
            InitializeComponent();
        }

        void ticketDesign()
        {
            tableLayoutPanel1.Size = new Size(50 * columns + 10 * (columns - 1) , 35 * rows + 10 * (rows - 1));
            tableLayoutPanel1.ColumnCount = columns;
            tableLayoutPanel1.RowCount = rows;

            for (int i = 1; i <= tableLayoutPanel1.ColumnCount; i++)
            {
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            }

            for (int i = 1; i <= tableLayoutPanel1.RowCount; i++)
            {
                tableLayoutPanel1.RowStyles.Add(new RowStyle());
            }

            for(int i = 1; i <= columns * rows; i++)
            {
                CheckBox cb = new CheckBox();
                cb.TextAlign = ContentAlignment.MiddleCenter;
                cb.Appearance = Appearance.Button;
                cb.FlatStyle = FlatStyle.Flat;
                cb.FlatAppearance.BorderSize = 0;
                cb.FlatAppearance.CheckedBackColor = Color.Snow;
                cb.ForeColor = Color.DarkOrange;
                cb.BackColor = Color.SeaGreen;
                cb.Size = new Size(50,35);
                cb.Text = "" + i;
                cb.Click += makeLotteryTicket;
                tableLayoutPanel1.Controls.Add(cb); 
            }
        }

        void labelVisibility()
        {
            lbNumbers.Visible = true;
        }

        void lottery5Visibility()
        {
            btnResetLottery5.Visible= true;
            btnResetLottery6.Visible = false;
            btnResetLottery7.Visible= false;
        }

        void lottery6Visibility()
        {
            btnResetLottery6.Visible = true;
            btnResetLottery5.Visible = false;
            btnResetLottery7.Visible= false;
        }

        void lottery7Visibility()
        {
            btnResetLottery7.Visible = true;
            btnResetLottery5.Visible = false;
            btnResetLottery6.Visible= false;
        }

        void makeLotteryTicket(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;

            if (cb.Checked) selectedNumbers++; else selectedNumbers--;
            if (selectedNumbers == howManyNumbers)
            {
                foreach (Control c in tableLayoutPanel1.Controls)
                {
                    if (!(c as CheckBox).Checked) c.Enabled = false;
                }
            }
            else
            {
                foreach (Control c in tableLayoutPanel1.Controls)
                {
                    c.Enabled = true;
                }
            }
        }

        private void lottery5_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Clear();
            selectedNumbers = 0;
            howManyNumbers = 5;
            columns = 10;
            rows = 9;
            ticketDesign();
            labelVisibility();
            lottery5Visibility();
        }

        private void lottery6_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Clear();
            selectedNumbers = 0;
            howManyNumbers = 6;
            columns = 9;
            rows = 5;
            ticketDesign();
            labelVisibility();
            lottery6Visibility();
        }

        private void lottery7_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Clear();
            selectedNumbers = 0;
            howManyNumbers = 7;
            columns = 7;
            rows = 5;
            ticketDesign();
            labelVisibility();
            lottery7Visibility();
        }

        private void btnResetLottery5_Click(object sender, EventArgs e)
        {
            foreach (CheckBox cb in tableLayoutPanel1.Controls.OfType<CheckBox>())
            {
                if (cb.Enabled)
                {
                    if (selectedNumbers >= 0 || selectedNumbers <= 5)
                    {
                        if (cb.Checked == true)
                        { 
                            tableLayoutPanel1.Controls.Clear();
                            lottery5_Click(sender, e);
                        }
                    }
                }
            }
        }

        private void btnResetLottery6_Click(object sender, EventArgs e)
        {
            foreach (CheckBox cb in tableLayoutPanel1.Controls.OfType<CheckBox>())
            {
                if (cb.Enabled)
                {
                    if (selectedNumbers >= 0 || selectedNumbers <= 6)
                    {
                        if (cb.Checked == true)
                        {
                            tableLayoutPanel1.Controls.Clear();
                            lottery6_Click(sender, e);
                        }
                    }
                }
            }
        }

        private void btnResetLottery7_Click(object sender, EventArgs e)
        {
            foreach (CheckBox cb in tableLayoutPanel1.Controls.OfType<CheckBox>())
            {
                if (cb.Enabled)
                {
                    if (selectedNumbers >= 0 || selectedNumbers <= 7)
                    {
                        if (cb.Checked == true)
                        {
                            tableLayoutPanel1.Controls.Clear();
                            lottery7_Click(sender, e);
                        }
                    }
                }
            }
        }
    }
}
