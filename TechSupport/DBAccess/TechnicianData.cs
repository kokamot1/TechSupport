using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechSupport.Model;
using System.Data.SqlClient;


namespace TechSupport.DBAccess
{
    class TechnicianData
    {
        public static List<Technician> GetTechnicians()
        {
            List<Technician> TechnicianList = new List<Technician>();
            SqlConnection connection = DBConnection.GetConnection();
            string selectStatement =
                "SELECT TechId, Name FROM Technicians";
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            SqlDataReader reader = null;

            try
            {
                connection.Open();
                reader = selectCommand.ExecuteReader();

                while (reader.Read())
                {
                    Technician technician = new Technician((int) reader["TechID"]);
                    technician.Name = reader["Name"].ToString();
                    TechnicianList.Add(technician);
                }

            }
            finally
            {
                if (connection != null)
                    connection.Close();
                if (reader != null)
                    reader.Close();
            }
            return TechnicianList;
        }


        public static List<Technician> GetTechniciansWithOpenIncidents()
        {
            List<Technician> TechnicianList = new List<Technician>();
            SqlConnection connection = DBConnection.GetConnection();
            string selectStatement =
                "SELECT TechId, Name, Email, Phone FROM Technicians " +
                "WHERE TechID IN (SELECT TechID FROM Incidents)";
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            SqlDataReader reader = null;

            try
            {
                connection.Open();
                reader = selectCommand.ExecuteReader();

                while (reader.Read())
                {
                    Technician technician = new Technician((int)reader["TechID"]);
                    technician.Name = reader["Name"].ToString();
                    technician.Email = reader["Email"].ToString();
                    technician.Phone = reader["Phone"].ToString();
                    TechnicianList.Add(technician);
                }

            }
            finally
            {
                if (connection != null)
                    connection.Close();
                if (reader != null)
                    reader.Close();
            }
            return TechnicianList;
        }
    }
}
