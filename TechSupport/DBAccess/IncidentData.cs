using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using TechSupport.Model;


namespace TechSupport.DBAccess
{
    public static class IncidentData
    {

        public static List<Incident> GetOpenIncidents()
        {
            List<Incident> incidentList = new List<Incident>();
            SqlConnection connection = DBConnection.GetConnection();
            string selectStatement =
                "SELECT i.ProductCode, i.DateOpened, c.Name as Customer, t.Name as Technician, i.Title " +
                "FROM Incidents i " +
                "JOIN Customers c ON c.CustomerID = i.CustomerID " +
                "LEFT OUTER JOIN Technicians t ON t.TechID = i.TechID " +
                "WHERE i.DateClosed IS NULL" ;
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            SqlDataReader reader = null;

            try
            {
                connection.Open();
                reader = selectCommand.ExecuteReader();

                while (reader.Read())
                {
                    Incident incident = new Incident();
                    incident.ProductCode = reader["ProductCode"].ToString();
                    incident.DateOpened = (DateTime)reader["DateOpened"];
                    incident.Customer = reader["Customer"].ToString();
                    incident.Technician = reader["Technician"].ToString();
                    incident.Title = reader["Title"].ToString();
                    incidentList.Add(incident);
                }

            }
            catch (SqlException ex )
            {
                System.Windows.Forms.MessageBox.Show("A Database error occured: " + ex.Message);
                return null;
            }
            finally
            {
                if (connection != null)
                    connection.Close();
                if (reader != null)
                    reader.Close();
            }
            return incidentList;
        }

    }
}
