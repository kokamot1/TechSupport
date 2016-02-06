using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechSupport.Model;
using TechSupport.DBAccess;

namespace TechSupport
{
    public static class IncidentsController
    {
        public static List<Incident> OpenIncidents()
        {
            return IncidentData.GetOpenIncidents();
        }

        public static Boolean AddIncident(Customer customer, Product product, string title, string description)
        {
            return false;
        } 
    }
}
