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
using TechSupport.Controller;
using System.Data.SqlClient;


namespace TechSupport
{
    public partial class ViewIncidentsByTechnician : Form
    {
        public ViewIncidentsByTechnician()
        {
            InitializeComponent();
        }

        private void nameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GetIncidentData();
        }

        private List<Technician> technicianList;

        private void ViewIncidentsByTechnician_Load(object sender, EventArgs e)
        {
            try
            {
                technicianList = TechniciansController.TechniciansWithOpenIncidents();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("A Database error occured fetching the technicians: " + ex.Message);
                this.BeginInvoke(new MethodInvoker(Close));
                return;
            }
            nameComboBox.DataSource = technicianList;
            this.GetIncidentData();
        }

        private void GetIncidentData()
        {
            if (nameComboBox.SelectedValue == null)
            {
                MessageBox.Show("There are no technicians with open incidents");
                return;
            }
            int techID = (int)nameComboBox.SelectedValue;
            technicianBindingSource.Clear();
            technicianBindingSource.Add(nameComboBox.SelectedItem);

            try
            {
                List<Incident> incidents = IncidentsController.IncidentsByTechnician(techID);
                incidentDataGridView.DataSource = incidents;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error retreiving incidents for technician: " + ex.Message);
            }
        }

        private void incidentDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
