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

        private List<Technician> technicianList;

        private void ViewIncidentsByTechnician_Load(object sender, EventArgs e)
        {
            this.GetTechniciansWithOpenIncidentList();
        }

        private void GetTechniciansWithOpenIncidentList()
        {
            try
            {
                technicianList = TechniciansController.TechniciansWithOpenIncidents();
                nameComboBox.DataSource = technicianList;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("A Database error occured fetching the technicians: " + ex.Message);
                this.BeginInvoke(new MethodInvoker(Close));
                return;
            }
        }

    }
}
