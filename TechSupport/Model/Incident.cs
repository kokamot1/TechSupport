using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TechSupport.Model
{
    public class Incident
    {
        public string ProductCode { get; set; }
        public DateTime DateOpened { get; set; }
        public string Customer { get; set; }
        public string Technician { get; set; }
        public string Title { get; set; }

    }
}
