using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using TechSupport.Model;

namespace TechSupport.DBAccess
{
    public static class CustomerData
    {
        public static List<Customer> GetCustomers()
        {
            List<Customer> customerList = new List<Customer>();
            SqlConnection connection = DBConnection.GetConnection();
            string selectStatement =
                "SELECT CustomerID, Name FROM Customers";
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            SqlDataReader reader = null;

            try
            {
                connection.Open();
                reader = selectCommand.ExecuteReader();

                while (reader.Read())
                {
                    Customer customer = new Customer((int)reader["CustomerID"]);
                    customer.Name = reader["Name"].ToString();
                    customerList.Add(customer);
                }

            }
            finally
            {
                if (connection != null)
                    connection.Close();
                if (reader != null)
                    reader.Close();
            }
            return customerList;
        }
    }
}
