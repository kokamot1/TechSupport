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
        // This object will hold the updates made in the form
        private Incident currentIncident;
        // This object will hold the values of the incident as fetched from the db
        // and be used to check if the db has been modified before executing an update
        private Incident fetchedIncident;

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
            LoadIncident();
        }

        private void CloseIncidentBtn_Click(object sender, EventArgs e)
        {
            if (this.currentIncident.TechID == null)
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

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            UpdateIncident();
        }

        private void TechnicianBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSelectedTechnician();
        }

        //Sets the technician for the currentIncident based on the ComboBox slection
        private void UpdateSelectedTechnician()
        {
            if (this.currentIncident == null)
            {
                return;
            }
            else if (TechnicianBox.SelectedItem == null)
            {
                this.currentIncident.TechID = null;
                this.currentIncident.TechName = null;
            }
            else
            {
                this.currentIncident.TechID = ((Technician)TechnicianBox.SelectedItem).TechID;
                this.currentIncident.TechName = ((Technician)TechnicianBox.SelectedItem).Name;
            }
        }

        private void LoadIncident()
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
                this.fetchedIncident = incident;
                this.currentIncident = this.fetchedIncident.ShallowCopy();
                ResetForm();
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

        //Sets the form fields with to the values of currentIncident
        private void ResetForm()
        {
            CustomerBox.Text = this.currentIncident.Customer;
            ProductBox.Text = this.currentIncident.ProductName;
            TitleBox.Text = this.currentIncident.Title;
            DateOpenedBox.Text = this.currentIncident.DateOpened.ToString();
            DescriptionBox.Text = this.currentIncident.Description;
            if (this.currentIncident.TechID != null)
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

        private void UpdateIncident()
        {
            Boolean newTechAssigned = this.currentIncident.TechID != this.fetchedIncident.TechID;

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

            string newDescription;
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
                if (CheckIfDatabaseModified())
                {
                    return;
                }
                IncidentsController.UpdateIncident(this.currentIncident);
                this.fetchedIncident = this.currentIncident.ShallowCopy();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error updating incident.\n" + ex.Message);
            }
            MessageBox.Show("Incident updated");
            ResetForm();
        }

        private string CreateNewDescription(string updateText)
        {
            string newDescription = DescriptionBox.Text + updateText;
            if (newDescription.Length <= MAX_DESCRIPTION_LENGTH)
            {
                return newDescription;
            }

            //Handle when the new description is too long
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show("The updated description is over " + MAX_DESCRIPTION_LENGTH + " characters. OK to truncate?", "Description too long", buttons);

            if (result == DialogResult.Yes)
            {
                return newDescription.Substring(0, MAX_DESCRIPTION_LENGTH);
            }
            else
            {
                //Description is too long and not truncated.  User must do the editing
                EnableEditInDescriptionBox(newDescription);
                throw new DescriptionTooLongException();
            }
        }

        private Boolean ConfirmCloseIncident()
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            string message = "Once closed an incident can no longer be updated. Proceed to close?";
            result = MessageBox.Show(message, "Confirm Close", buttons);
            return (result == DialogResult.Yes);
        }

        //Set the description box text and allow user to edit the box.
        //And clear and disable the TextToAdd box
        private void EnableEditInDescriptionBox(string newDescription)
        {
            DescriptionBox.Text = newDescription;
            TextToAddBox.Text = "";
            DescriptionBox.Enabled = true;
            TextToAddBox.Enabled = false;
        }

        // Check if the incident has been modified in the database since the form was loaded
        // Returns true if it has been modified
        private Boolean CheckIfDatabaseModified()
        {
            Incident dbIncident = IncidentsController.GetIncidentByID(this.currentIncident.IncidentID);

            if (dbIncident == null)
            {
                MessageBox.Show("This incident has been deleted by another process and cannot be updated");
                Close();
                return true;
            }

            else if (dbIncident.DateClosed != null)
            {
                MessageBox.Show("This incident has been closed by another process and cannot be updated");
                Close();
                return true;
            }

            else if (dbIncident.Description != this.fetchedIncident.Description)
            {
                MessageBox.Show("Incident has been changed by another process.\nClick 'Get Incident' to reload", "Error Updating");
                return true;
            }

            else
            {
                return false;
            }
        }

        // Used to indicate the description field has too many characters
        public class DescriptionTooLongException : Exception
        {
            public DescriptionTooLongException()
            {
            }
        }

    }

}
