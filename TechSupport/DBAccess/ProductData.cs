using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using TechSupport.Model;

namespace TechSupport.DBAccess
{
    public static class ProductData
    {
        public static List<Product> GetProducts()
        {
            List<Product> productList = new List<Product>();
            SqlConnection connection = DBConnection.GetConnection();
            string selectStatement =
                "SELECT ProductCode, Name FROM Products";
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            SqlDataReader reader = null;

            try
            {
                connection.Open();
                reader = selectCommand.ExecuteReader();

                while (reader.Read())
                {
                    Product product = new Product(reader["ProductCode"].ToString());
                    product.Name = reader["Name"].ToString();
                    productList.Add(product);
                }

            }
            finally
            {
                if (connection != null)
                    connection.Close();
                if (reader != null)
                    reader.Close();
            }
            return productList;
        }
    }
}
