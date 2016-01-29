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

namespace TechSupport
{
    public partial class IncidentsForm : Form
    {

        public IncidentsForm()
        {
            InitializeComponent();
            showOpenIncidents();
        }

        private void showOpenIncidents()
        {
            List<Incident> incidents = IncidentsController.OpenIncidents();

            Incident incident;
            for (int i = 0; i < incidents.Count; i++)
            {
                incident = incidents[i];
                IncidentsListView.Items.Add(incident.ProductCode);
                IncidentsListView.Items[i].SubItems.Add(incident.DateOpened.ToShortDateString());
                IncidentsListView.Items[i].SubItems.Add(incident.Customer);
                IncidentsListView.Items[i].SubItems.Add(incident.Technician);
                IncidentsListView.Items[i].SubItems.Add(incident.Title);
            }
        }


    }
}
