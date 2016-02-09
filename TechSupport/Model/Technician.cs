using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechSupport.Model
{
    class Technician
    {
        //Technician ID should not be changed
        private readonly int technicianID;

        public Technician(int technicianID)
        {
            this.technicianID = technicianID;
        }
        
        public int TechnicianID 
        {
            get
            {
                return technicianID;
            }
        }
        public string Name { get; set; }
    }
}
