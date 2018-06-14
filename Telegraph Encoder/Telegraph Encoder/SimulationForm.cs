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
        public Code SimCode { get; set; }
        public SimulationForm()
        {
            InitializeComponent();
        }

        private void SimulationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SimCode.ContinueSimulation = false;//terminate the thread
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SimCode.ContinueSimulation = false;//stop simulation
            this.Close();
        }

        private void SimulationForm_Load(object sender, EventArgs e)
        {
            var thread = new Thread(() => SimCode.Simulate());
            thread.Start();

            var threadCloseForm = new Thread(() => autoClose());
            threadCloseForm.Start();
        }

        private void autoClose()
        {
            //A thread that closes SimulationForm as soon as simulation is finished
            while (true)
            {
                if (SimCode.IsFinished)
                {
                    this.Close();
                    break;
                }
            }
        }
    }
}
