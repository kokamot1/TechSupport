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

        public static int AddIncident(Customer customer, Product product, string title, string description)
        {
            if (customer == null || product == null) 
            {
                throw new ArgumentException("customer and product parameters must not be null");
            }
            Incident incident = new Incident();
            incident.CustomerID = customer.CustomerID;
            incident.ProductCode = product.ProductCode;
            incident.Title = title;
            incident.Description = description;
            incident.DateOpened = DateTime.Now;
            return IncidentData.AddIncident(incident);
        }

        public static Incident GetIncidentByID(int incidentID)
        {
            return IncidentData.IncidentByID(incidentID);
        }

        public static Boolean UpdateIncident(Incident oldIncident, Incident newIncident)
        {
            return IncidentData.UpdateIncident(oldIncident, newIncident);
        }
    }
}
