using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
        }

        private Code code;

        private void Form1_Load(object sender, EventArgs e)
        {
            //Retrieve settings
            textBox3.Text = Convert.ToString(Settings.Default.Duration);
            textBox4.Text = Convert.ToString(Settings.Default.Frequency);

            listBox1.SelectedItem = listBox1.Items[0];
            code = new Code();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //Change and save duration settings
            Settings.Default.Duration = Convert.ToInt32(textBox3.Text);
            Settings.Default.Save();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            code.continueSimulation = false;//if is simulating, stop it immediately

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
            Settings.Default.Frequency = Convert.ToInt32(textBox3.Text);
            Settings.Default.Save();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            code.simulate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            code.continueSimulation = false;//stop immediately
        }
    }
}
