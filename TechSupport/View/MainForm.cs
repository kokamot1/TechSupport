using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechSupport
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void displayOpenIncidentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IncidentsForm incidents = new IncidentsForm();
            incidents.MdiParent = this;
            incidents.Show();
        }
    }
}
