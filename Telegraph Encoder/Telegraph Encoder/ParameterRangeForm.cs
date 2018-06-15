using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telegraph_Encoder
{
    public partial class ParameterRangeForm : Form
    {
        private bool selection;//duration or frequency

        public ParameterRangeForm(bool b)
        {
            InitializeComponent();

            selection = b;
        }

        private void ParameterRangeForm_Load(object sender, EventArgs e)
        {
            if (selection)//called because of invalid duration
            {
                this.Text = "Duration";
                label1.Text = "Duration should be a positive interger!";
                button2.Visible = true;
            }
            else//called because of invalid frequency
            {
                this.Text = "Frequency";
                label1.Text = "Frequency should be an interger from";
                label2.Text = "37 to 32767!";
                button1.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
