﻿using System;
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
            //customerBox.ValueMember = "CustomerID";

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
            //productBox.ValueMember = "ProductCode";

        }

        private Boolean IsValidEntry()
        {
            if (titleBox.Text.Trim() == "")
            {
                System.Windows.Forms.MessageBox.Show("Title cannot be blank");
                return false;
            }
            else if (descriptionBox.Text.Trim() == "")
            {
                System.Windows.Forms.MessageBox.Show("Description cannot be blank");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void createIncidentButton_Click(object sender, EventArgs e)
        {
            if (IsValidEntry())
            {
                Product product = (Product) productBox.SelectedItem;
                Customer customer = (Customer)customerBox.SelectedItem;
                String title = titleBox.Text;
                String description = descriptionBox.Text;

                if (IncidentsController.AddIncident(customer, product, title, description))
                {
                    System.Windows.Forms.MessageBox.Show("Incident Added");
                }
                else {
                    System.Windows.Forms.MessageBox.Show("Error Adding Incident");
                }

            }
             
        }
    }
}
