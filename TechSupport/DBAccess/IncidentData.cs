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
                "SELECT i.ProductCode, i.DateOpened, c.Name as Customer, c.CustomerID as customerID, " + 
                "    t.Name as Technician, i.Title " +
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
                    incident.CustomerID = (int) reader["CustomerID"];
                    incident.Technician = reader["Technician"].ToString();
                    incident.Title = reader["Title"].ToString();
                    incidentList.Add(incident);
                }

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

        public static int AddIncident(Incident incident)
        {
            if (incident == null)
            {
                throw new ArgumentException("incident parameter must not be null");
            }
            SqlConnection connection = DBConnection.GetConnection();
            string insertStatement =
                "INSERT Incidents " +
                "(CustomerID, ProductCode, DateOpened, Title, Description) " +
                "VALUES (@CustomerID, @ProductCode, @DateOpened, @Title, @Description)";
            SqlCommand insertCommand = new SqlCommand(insertStatement, connection);
            insertCommand.Parameters.AddWithValue("@CustomerID", incident.CustomerID);
            insertCommand.Parameters.AddWithValue("@ProductCode", incident.ProductCode);
            insertCommand.Parameters.AddWithValue("@DateOpened", incident.DateOpened);
            insertCommand.Parameters.AddWithValue("@Title", incident.Title);
            insertCommand.Parameters.AddWithValue("@Description", incident.Description);
            try
            {
                connection.Open();
                insertCommand.ExecuteNonQuery();
                string selectStatement =
                    "SELECT IDENT_CURRENT('Incidents') FROM Incidents";
                SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
                int incidentID = Convert.ToInt32(selectCommand.ExecuteScalar());
                return incidentID;
            }
            finally
            {
                connection.Close();
            }
        }

        public static Incident IncidentByID(int incidentID)
        {
            SqlConnection connection = DBConnection.GetConnection();
            string selectStatement =
                "SELECT i.ProductCode, i.DateOpened, c.Name as Customer, c.CustomerID as customerID, " + 
                "    t.Name as Technician, t.TechID, i.Title, p.Name as ProductName, i.IncidentID, i.Description " +
                "FROM Incidents i " +
                "JOIN Customers c ON c.CustomerID = i.CustomerID " +
                "JOIN Products p ON p.ProductCode = i.ProductCode " +
                "LEFT OUTER JOIN Technicians t ON t.TechID = i.TechID " +
                "WHERE IncidentID = @IncidentID";
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@IncidentID", incidentID);
            SqlDataReader reader = null;
            try
            {
                connection.Open();
                reader = selectCommand.ExecuteReader();

                if (reader.Read())
                {
                    Incident incident = new Incident((int) reader["IncidentID"]);
                    incident.CustomerID = (int) reader["CustomerID"];
                    incident.Customer = reader["Customer"].ToString();
                    incident.DateOpened = (DateTime) reader["DateOpened"];
                    incident.Title = reader["Title"].ToString();
                    incident.Description = reader["Description"].ToString();
                    if (!DBNull.Value.Equals(reader["TechID"]))
                    {
                        incident.TechID = (int)reader["TechID"];
                    }
                    incident.Technician = reader["Technician"].ToString();
                    incident.ProductCode = reader["ProductCode"].ToString();
                    incident.ProductName = reader["ProductName"].ToString();
                    return incident;
                }
                else
                {
                    return null;
                }

            }
            finally
            {
                if (connection != null)
                    connection.Close();
                if (reader != null)
                    reader.Close();
            }
        }
    }
}
