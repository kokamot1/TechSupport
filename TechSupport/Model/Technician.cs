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
        private readonly int techID;

        public Technician(int techID)
        {
            this.techID = techID;
        }
        
        public int TechID 
        {
            get
            {
                return techID;
            }
        }
        public string Name { get; set; }
    }
}
