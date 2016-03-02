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
            List<Product> productsList;
            try
            {
                customersList = CustomersController.Customers();
                productsList = ProductsController.Products();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("A Database error occured fetching the lists of customers and products: " + ex.Message);
                this.BeginInvoke(new MethodInvoker(Close));
                return;
            }
            customerBox.DataSource = customersList;
            customerBox.DisplayMember = "Name";
            productBox.DataSource = productsList;
            productBox.DisplayMember = "Name";
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

                try
                {
                    int newIncidentID = IncidentsController.AddIncident(customer, product, title, description);
                    System.Windows.Forms.MessageBox.Show("Incident " + newIncidentID + " added");
                    Close();
                }
                catch (SqlException exception)
                {
                    System.Windows.Forms.MessageBox.Show("Error Adding Incident. \nDetails: " + exception.Message);
                }
            }
             
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
