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

        private void addNewIncidentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewIncidentForm newIncident = new NewIncidentForm();
            newIncident.MdiParent = this;
            newIncident.Show();
        }

        private void updateIncidentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateIncidentForm updateIncident = new UpdateIncidentForm();
            updateIncident.MdiParent = this;
            updateIncident.Show();

        }

        private void viewOpenIncidentsByTechnicianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewIncidentsByTechnician openIncidentsByTechnician = new ViewIncidentsByTechnician();
            openIncidentsByTechnician.MdiParent = this;
            openIncidentsByTechnician.Show();

        }
    }
}
