using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechSupport.Model;
using TechSupport.DBAccess;

namespace TechSupport.Controller
{
    public static class ProductsController
    {
        public static List<Product> Products()
        {
            return ProductData.GetProducts();
        }

    }
}
