using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechSupport.Model
{
    public class Product
    {
        //Product Code should not be changed
        private readonly string productCode;
        public Product(string productCode)
        {
            this.productCode = productCode;
        }
        
        public string ProductCode 
        {
            get
            {
                return productCode;
            }
        }
        public string Name { get; set; }
        public decimal Version { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
