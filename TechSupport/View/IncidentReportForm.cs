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

namespace TechSupport
{
    public partial class IncidentReportForm : Form
    {
        public IncidentReportForm()
        {
            InitializeComponent();
        }

        private void IncidentReportForm_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: This line of code loads data into the 'dataSet1.OpenIncidentsAssigned' table. You can move, or remove it, as needed.
                this.openIncidentsAssignedTableAdapter.Fill(this.dataSet1.OpenIncidentsAssigned);
                this.reportViewer1.RefreshReport();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error querying data for report\n" + ex.Message);
                this.BeginInvoke(new MethodInvoker(Close));
            }
        }
    }
}
