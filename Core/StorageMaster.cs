using StorageMaster;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WarehouseManagement.Core
{
    public class StorageMaster

    {

        public string AddProduct(string type, double price)
        {
            if (AddProduct >= this.AddProduct)
                throw new InvalidOperationException("Invalid garage slot!");
            var product = this.Product.CreateProduct(type, price);
            return $"Added {type} to pool";
        }





    }

}
