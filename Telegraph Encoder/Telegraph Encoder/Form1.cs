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
            if (checkValidity_d(textBox3.Text))//the value is valid
                Settings.Default.Duration = Convert.ToUInt32(textBox3.Text);
            else if (textBox3.Text!="")//when a user is changing textBox3.Text, he or she may first delete all numbers and then type a new one
            {
                ParameterRangeForm rangeForm = new ParameterRangeForm(true);
                rangeForm.Show();
            }
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
            if (checkValidity_d(textBox4.Text))
                Settings.Default.Duration = Convert.ToUInt32(textBox3.Text);
            else if (textBox4.Text != "")//when a user is changing textBox3.Text, he or she may first delete all numbers and then type a new one
            {
                ParameterRangeForm rangeForm = new ParameterRangeForm(false);
                rangeForm.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkValidity_f(textBox4.Text))
            {
                SimulationForm simForm = new SimulationForm();
                simForm.simCode = code;//transfer code
                simForm.Show();
                //Show a form that simulates and contains basic control
            }
            else
            {
                ParameterRangeForm rangeForm = new ParameterRangeForm(false);
                rangeForm.Show();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.Save(); //save settings
        }

        //Pre-emptive check for if variable duration in Code.simulation() would cause exceptio in Console.Beep(int,int)
        private bool checkValidity_d(string s)
        {
            //Check if s is an unsigned interger
            try
            {
                Convert.ToUInt32(s);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //Because when a user is changing textBox3.Text, he or she may first delete all numbers and then type a new one,
        //and within this process textBox3.Text would temporally be smaller than 37,
        //this check is run before simulation
        private bool checkValidity_f(string s)
        {
            uint i = Convert.ToUInt32(s);
            if (i >= 37u && i <= 32767u)//the range of frequency in Console.Beep(frequency,duration)
                return true;
            else return false;
        }
    }
}
