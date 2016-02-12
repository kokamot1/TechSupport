using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TechSupport.Model
{
    public class Incident
    {
        //Incident ID should not be changed
        private readonly int incidentID;

        public Incident() { }

        public Incident(int incidentID)
        {
            this.incidentID = incidentID;
        }
        
        public int IncidentID 
        {
            get
            {
                return incidentID;
            }
        }
        public DateTime DateOpened { get; set; }
        public DateTime? DateClosed { get; set; }
        public string Customer { get; set; }
        public int CustomerID { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string TechName { get; set; }
        public int? TechID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public Incident ShallowCopy()
        {
            return (Incident)this.MemberwiseClone();
        }

        public override bool Equals(Object obj)
        {
            // Check for null values and compare run-time types.
            if (obj == null || GetType() != obj.GetType())
                return false;

            Incident other = (Incident) obj;
            return (incidentID == other.incidentID &&
                    DateOpened == other.DateOpened &&
                    DateClosed == other.DateClosed &&
                    Customer == other.Customer &&
                    CustomerID == other.CustomerID &&
                    ProductCode == other.ProductCode &&
                    ProductName == other.ProductName &&
                    TechName == other.TechName &&
                    TechID == other.TechID &&
                    Title == other.Title &&
                    Description == other.Description);
        }

    }
}
