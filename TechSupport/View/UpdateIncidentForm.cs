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
        public const int MAX_DESCRIPTION_LENGTH = 200;
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
                ResetUpdateForm();
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


        private void ResetUpdateForm()
        {
            CustomerBox.Text = this.currentIncident.Customer;
            ProductBox.Text = this.currentIncident.ProductName;
            TitleBox.Text = this.currentIncident.Title;
            DateOpenedBox.Text = this.currentIncident.DateOpened.ToString();
            DescriptionBox.Text = this.currentIncident.Description;
            if (this.currentIncident.TechID > 0)
            {
                TechnicianBox.SelectedValue = this.currentIncident.TechID;
            }
            else
            {
                TechnicianBox.SelectedIndex = -1;
            }
            CloseIncidentBtn.Enabled = true;
            UpdateBtn.Enabled = true;
            TextToAddBox.Text = "";
            TextToAddBox.Enabled = true;
            DescriptionBox.Enabled = false;
            TechnicianBox.Enabled = true;

            if (this.currentIncident.Description.Length == MAX_DESCRIPTION_LENGTH)
            {
                MessageBox.Show("The description for this incidident is at its max size and must be edited if you want to change it.");
                EnableEditInDescriptionBox(this.currentIncident.Description);
            }

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
            if (!ConfirmCloseIncident())
            {
                return false;
            }
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

            //If DescriptionBox has become enabled the user already added text
            //and it was too long so all modifications are now in the description box
            if (!DescriptionBox.Enabled)
            {
                if (addText == "" && !newTechAssigned)
                {
                    MessageBox.Show("Incident cannot be updated unless text is added or a tech is changed");
                    return;
                }
                if (addText == "" && newTechAssigned)
                {
                    addText = "updated/assigned the technician";
                }
                addText = Environment.NewLine + "<" + DateTime.Now.Date.ToShortDateString() + ">  " + addText;
            }

            string newDescription = "";
            try
            {
                newDescription = CreateNewDescription(addText);
            }
            catch (DescriptionTooLongException ex)
            {
                //Description is too long and was not truncated.  
                //User must edit before incident can be updated
                return;
            }
            this.currentIncident.Description = newDescription;

            try
            {
                IncidentsController.UpdateIncident(this.currentIncident);
                MessageBox.Show("Incident updated");
                ResetUpdateForm();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error updating incident.\n" + ex.Message);
                return;
            }
           
        }

        private string CreateNewDescription(string updateText)
        {
            string newDescription = DescriptionBox.Text + updateText;
            if (newDescription.Length <= MAX_DESCRIPTION_LENGTH)
            {
                return newDescription;
            }

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show("The updated description is over " + MAX_DESCRIPTION_LENGTH + " characters. OK to truncate?", "Description too long", buttons);

            if (result == DialogResult.Yes)
            {
                return newDescription.Substring(0, MAX_DESCRIPTION_LENGTH);
            }
            //Description is too long and not truncated.  User must do the editing
            EnableEditInDescriptionBox(newDescription);
            throw new DescriptionTooLongException();
        }

        private Boolean ConfirmCloseIncident()
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            string message = "Once closed an incident can no longer be updated. Proceed to close?";
            result = MessageBox.Show(message, "Confirm Close", buttons);
            return (result == DialogResult.Yes);
        }

        //Move the added text to the description and have the user edit it there
        private void EnableEditInDescriptionBox(string newDescription)
        {
            DescriptionBox.Text = newDescription;
            TextToAddBox.Text = "";
            DescriptionBox.Enabled = true;
            TextToAddBox.Enabled = false;
          
        }

        public class DescriptionTooLongException : Exception
        {
            public DescriptionTooLongException()
            {
            }
        }


    }

}
