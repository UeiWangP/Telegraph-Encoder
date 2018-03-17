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

        async private Task simulateAsync()
        {
            await SimCode.SimulateAsync();

            this.Close();
        }
    }
}
