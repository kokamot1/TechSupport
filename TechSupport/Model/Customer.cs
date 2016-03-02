using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechSupport.Model
{
    public class Customer
    {
        //Customer ID should not be changed
        private readonly int customerID;
        public Customer(int customerID)
        {
            this.customerID = customerID;
        }

        public int CustomerID 
        {
            get
            {
                return customerID;
            }
        }
        public string Name { get; set; }

    }

}
