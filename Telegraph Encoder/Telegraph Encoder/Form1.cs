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
using Telegraph_Encoder.Properties;

namespace Telegraph_Encoder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //Retrieve settings
            textBox3.Text = Convert.ToString(Settings.Default.Duration);
            textBox4.Text = Convert.ToString(Settings.Default.Frequency);
        }

        private Code code;

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.SelectedItem = listBox1.Items[0];
            code = new Code();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //Change and save duration settings
            try
            {
                Settings.Default.Duration = Convert.ToInt32(textBox3.Text);
            }
            catch (FormatException ex) { };
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //Encode Immediately
            try
            {
                code.encode(textBox1.Text);
                textBox2.Text = code.ciphertext;
            }
            catch(InvalidCharacterException ex)
            {
                //Show an error dialog
                ErrorForm err = new ErrorForm(ex.Message);
                err.Show();
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //Change and save frequency settings
            try
            {
                Settings.Default.Frequency = Convert.ToInt32(textBox4.Text);
            }
            catch (FormatException ex) { };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SimulationForm simForm = new SimulationForm();
            simForm.simCode = code;//transfer code
            simForm.Show();
            //Show a form that simulates and contains basic control
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.Save(); //save settings
        }
    }
}
