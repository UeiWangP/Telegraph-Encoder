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
    public partial class SimulationForm : Form
    {
        public Code simCode { get; set; }
        public SimulationForm()
        {
            InitializeComponent();
        }

        private void SimulationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            simCode.continueSimulation = false;//terminate the thread
        }

        private void button1_Click(object sender, EventArgs e)
        {
            simCode.continueSimulation = false;//stop simulation
            this.Close();
        }

        private void SimulationForm_Load(object sender, EventArgs e)
        {
            var thread = new Thread(() => simCode.simulate());
            thread.Start();
        }
    }
}
