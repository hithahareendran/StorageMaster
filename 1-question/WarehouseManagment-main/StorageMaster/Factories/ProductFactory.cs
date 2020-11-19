﻿namespace StorageMaster.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Models.Products;

    public class ProductFactory
    {
        public Product CreateProduct(string type, double price)
        {
            //search for the productType..
            var productType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .Where(x => !x.IsAbstract && x.Name == type)
                .FirstOrDefault();
            
            // Example OUTPUT: StorageMaster.Models.Products.Gpu
            if (productType == null)
            {
                throw new InvalidOperationException("Invalid product type!");
            }

            Product product = null;

            try
            {
                product = (Product)Activator.CreateInstance(productType, price);
            }
            catch (TargetInvocationException tie)
            {
                throw new InvalidOperationException(tie.InnerException.Message);
            }

            return product;
        }
    }
}
