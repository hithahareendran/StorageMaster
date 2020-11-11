using System;
using System.Collections.Generic;
using System.Linq;

namespace WarehouseManagement.Core
{
    class StorageMaster
    {
        //private IProductFactory productFactory;
        //private IProductRepository productRepository;
        //private IStorageFactory storageFactory;
        //private IStorageRepository storageRepository;
        //private IVehicle currentVehicle;

        //public StorageMaster(IProductFactory productFactory, 
        //    IProductRepository productRepository, IStorageFactory storageFactory,
        //    IStorageRepository storageRepository)
        //{
        //    this.productFactory = productFactory;
        //    this.productRepository = productRepository;
        //    this.storageFactory = storageFactory;
        //    this.storageRepository = storageRepository;
        //    this.currentVehicle = null;
        //}


        //public string AddProduct(string type, double price)
        //{
        //    var product = this.productFactory.CreateProduct(type, price);

        //    this.productRepository.Add(product);

        //    return $"Added {type} to pool";
        //}

        //public string RegisterStorage(string type, string name)
        //{
        //    var store = this.storageFactory.CreateStorage(type, name);

        //    this.storageRepository.Add(store);

        //    return $"Registered {name}";
        //}

        //public string SelectVehicle(string storageName, int garageSlot)
        //{
        //    this.currentVehicle = this.storageRepository.Storages.First
        //        (s => s.Name == storageName).GetVehicle(garageSlot);
        //    return $"Selected {currentVehicle.GetType()}";
        //}

        //public string LoadVehicle(IEnumerable<string> productNames)
        //{
        //    var LoadProductsCount = 0;

        //    foreach (var item in productNames)
        //    {
        //        if (!this.productRepository.Products.Any(p => p.GetType().Name == item))
        //        {
        //            throw new InvalidOperationException($"{item} is OutOfMemoryException of stock!");
        //        }
        //    } 
        //}

        public StorageMaster()
        {
            
        }

        public string AddProduct(string type, double price)
        {
            

            return $"Added {type} to pool";
        }

        public string RegisterStorage(string type, string name)
        {
           

            return $"Registered {name}";
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            
            return "Selected the current vehicle";
        }

       
           
        

    }

}
