using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using TechSupport.Model;
using TechSupport.Controller;

namespace TechSupport
{
    public partial class UpdateIncidentForm : Form
    {
        public UpdateIncidentForm()
        {
            InitializeComponent();
        }

        private void UpdateIncidentForm_Load(object sender, EventArgs e)
        {
            LoadTechnicianComboBoxItems();
        }


        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GetIncidentBtn_Click(object sender, EventArgs e)
        {
            int incidentID;
            try
            {
                incidentID = Convert.ToInt32(IncidentIDBox.Text);
            }
            catch (System.FormatException ex)
            {
                System.Windows.Forms.MessageBox.Show("Incident ID must be an integer");
                IncidentIDBox.Text = "";
                return;
            }

            Incident incident = null;
            try
            {
                incident = IncidentsController.GetIncidentByID(incidentID);
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Database Query error fetching incident.\n" + ex.Message);
            }
            if (incident != null)
            {
                putIncidentDataIntoForm(incident);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("No incidents found with Incident ID " + incidentID);
            }
        }


        // Add the items in the Technician combo box
        private void LoadTechnicianComboBoxItems()
        {
            try
            {
                List<Technician> techniciansList;
                techniciansList = TechniciansController.Technicians();
                TechnicianBox.DataSource = techniciansList;
                TechnicianBox.DisplayMember = "Name";
                TechnicianBox.ValueMember = "TechID";
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("A Database error occured fetching technicians: " + ex.Message);
                this.BeginInvoke(new MethodInvoker(Close));
                return;
            }
            TechnicianBox.SelectedIndex = -1;
        }


        private void putIncidentDataIntoForm(Incident incident)
        {
            CustomerBox.Text = incident.Customer;
            ProductBox.Text = incident.ProductName;
            TitleBox.Text = incident.Title;
            DateOpenedBox.Text = incident.DateOpened.ToString();
            DescriptionBox.Text = incident.Description;
            if (incident.TechID > 0)
            {
                TechnicianBox.SelectedValue = incident.TechID;
            }
            else
            {
                TechnicianBox.SelectedIndex = -1;
            }
        }

    }

}
