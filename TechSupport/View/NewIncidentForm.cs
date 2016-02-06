using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechSupport.Controller;
using TechSupport.Model;

namespace TechSupport
{
    public partial class NewIncidentForm : Form
    {
        public NewIncidentForm()
        {
            InitializeComponent(); 
        }

        private void NewIncidentForm_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
        }

        private void LoadComboBoxes()
        {
            List<Customer> customersList;
            try
            {
                customersList = CustomersController.Customers();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("A Database error occured fetching customers: " + ex.Message);
                this.BeginInvoke(new MethodInvoker(Close));
                return;
            }
            customerBox.DataSource = customersList;
            customerBox.DisplayMember = "Name";
            customerBox.ValueMember = "CustomerID";

            List<Product> productsList;
            try
            {
                productsList = ProductsController.Products();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("A Database error occured fetching products: " + ex.Message);
                this.BeginInvoke(new MethodInvoker(Close));
                return;
            }
            productBox.DataSource = productsList;
            productBox.DisplayMember = "Name";
            productBox.ValueMember = "ProductCode";

        }


    }
}
