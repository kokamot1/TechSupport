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
        private Incident currentIncident;

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
                MessageBox.Show("Incident ID must be an integer");
                IncidentIDBox.Text = "";
                return;
            }
            Incident incident;
            try
            {
                incident = IncidentsController.GetIncidentByID(incidentID);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database Query error fetching incident.\n" + ex.Message);
                return;
            }
            if (incident == null)
            {
                MessageBox.Show("No incidents found with Incident ID " + incidentID);
                return;
            }
            else if (incident.DateClosed != null)
            {
                MessageBox.Show("Incident " + incidentID + " has already been closed");
            }
            else
            {
                this.currentIncident = incident;
                putIncidentDataIntoForm(incident);
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
                MessageBox.Show("A Database error occured fetching technicians: " + ex.Message);
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
            CloseIncidentBtn.Enabled = true;
            UpdateBtn.Enabled = true;
            TextToAddBox.Enabled = true;
            TechnicianBox.Enabled = true;
        }

        private void CloseIncidentBtn_Click(object sender, EventArgs e)
        {
            if (TechnicianBox.SelectedIndex < 0)
            {
                MessageBox.Show("A Technician must be assigned before an incident can be closed");
                return;
            }
            Boolean successfullyClosed = CloseIncident();
            if (successfullyClosed)
            {
                MessageBox.Show("Incident Closed");
                Close();
            }            
        }

        private Boolean CloseIncident()
        {
            List<Technician> techList = (List<Technician>) TechnicianBox.DataSource;
            String selectedTechName = techList[TechnicianBox.SelectedIndex].Name;
            int selectedTechID = techList[TechnicianBox.SelectedIndex].TechID;

            String addText = TextToAddBox.Text;

            this.currentIncident.TechID = selectedTechID;
            this.currentIncident.TechName = selectedTechName;
            this.currentIncident.Description = this.currentIncident.Description + Environment.NewLine + addText;
            this.currentIncident.DateClosed = DateTime.Now;

            try
            {
                IncidentsController.UpdateIncident(this.currentIncident);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error updating incidnet.\n" + ex.Message);
                return false;
            }
            return true;
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            Boolean newTechAssigned = false;
            if (TechnicianBox.SelectedIndex >= 0)
            {
                List<Technician> techList = (List<Technician>)TechnicianBox.DataSource;
                String selectedTechName = techList[TechnicianBox.SelectedIndex].Name;
                int selectedTechID = techList[TechnicianBox.SelectedIndex].TechID;
                if (selectedTechID != this.currentIncident.TechID)
                {
                    newTechAssigned = true;
                }
                this.currentIncident.TechID = selectedTechID;
                this.currentIncident.TechName = selectedTechName;
            }

            String addText = TextToAddBox.Text;
            if (addText.Trim() == "" && !newTechAssigned)
            {
                MessageBox.Show("Incident cannot be updated unless text is added or a tech is changed");
                return;
            }
            else if (addText.Trim() == "")
            {
                addText = DateTime.Now.ToString() + ":  updated/assigned the technician";
            }
            this.currentIncident.Description = this.currentIncident.Description + Environment.NewLine + addText;

            try
            {
                IncidentsController.UpdateIncident(this.currentIncident);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error updating incident.\n" + ex.Message);
                return;
            }
            MessageBox.Show("Incident updated");
            Close();
        }


    }

}
