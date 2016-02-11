using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechSupport.Model;
using System.Data.SqlClient;

namespace TechSupport
{
    public partial class IncidentsForm : Form
    {

        public IncidentsForm()
        {
            InitializeComponent();
        }

        private void IncidentsForm_Load(object sender, EventArgs e)
        {
            showOpenIncidents();
        }

        private void showOpenIncidents()
        {
            List<Incident> incidents;
            try
            {
                incidents = IncidentsController.OpenIncidents();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("A Database error occured: " + ex.Message);
                this.BeginInvoke(new MethodInvoker(Close));
                return;
            }

            Incident incident;
            for (int i = 0; i < incidents.Count; i++)
            {
                incident = incidents[i];
                IncidentsListView.Items.Add(incident.ProductCode);
                IncidentsListView.Items[i].SubItems.Add(incident.DateOpened.ToShortDateString());
                IncidentsListView.Items[i].SubItems.Add(incident.Customer);
                IncidentsListView.Items[i].SubItems.Add(incident.TechName);
                IncidentsListView.Items[i].SubItems.Add(incident.Title);
            }
        }

    }
}
