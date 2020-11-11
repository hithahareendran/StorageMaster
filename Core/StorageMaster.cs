using StorageMaster;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WarehouseManagement.Core
{
    public class StorageMaster

    {
        private List<Product> productPool;
        private List<Storage> storageRegistry;
        private Vehicle currentVehicle;
     

        public StorageMaster()
        {
            productPool = new List<Product>();
            storageRegistry = new List<Storage>();
            currentVehicle = null;
        }

        public string AddProduct(string type, double price)
        {
            var product = ProductFactory.CreateProduct(type, price);
            this.productPool.Add(product);

            return $"Added {type} to pool";
        }

        public string RegisterStorage(string type, string name)
        {
            var store = StorageFactory.CreateStorage(type, name);
            storageRegistry.Add(store);

            return $"Registered {name}";
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            this.currentVehicle = storageRegistry.First(s => s.Name == storageName)
                .GetVehicle(garageSlot);

            return $"Selected {currentVehicle.GetType().Name}";
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            var loadedProductsCount = 0;

            foreach (var name in productNames)
            {
                if (!productPool.Any(p => p.GetType().Name == name))
                {
                    throw new InvalidOperationException($"{name} is out of stock!");
                }
                else
                {
                    if (currentVehicle == null || currentVehicle.IsFull) break;
                    Product product = productPool.FindLast(p => p.GetType().Name == name);
                    productPool.Remove(product);
                    currentVehicle.LoadProduct(product);
                    loadedProductsCount++;
                }
            }
            return $"Loaded {loadedProductsCount}/{productNames.Count()} products into {currentVehicle.GetType().Name}";
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            if (!storageRegistry.Any(s => s.Name == sourceName))
            {
                throw new InvalidOperationException($"Invalid source storage!");
            }
            else if (!storageRegistry.Any(s => s.Name == destinationName))
            {
                throw new InvalidOperationException($"Invalid destination storage!");
            }
            else
            {
                Storage sourceStorage = storageRegistry.First(s => s.Name == sourceName);
                Vehicle vehicle = sourceStorage.GetVehicle(sourceGarageSlot);
                Storage deliveryLocation = storageRegistry.First(s => s.Name == destinationName);
                int destinationGarageSlot = sourceStorage.SendVehicleTo(sourceGarageSlot, deliveryLocation);
                return $"Sent {vehicle.GetType().Name} to {deliveryLocation.Name} (slot {destinationGarageSlot})";
            }

        }

        public string UnloadVehicle(string StorageName, int GarageSlot)
        {
            int unloadedProductsCount = storageRegistry.First(s => s.Name == StorageName).UnloadVehicle(GarageSlot);
            
            var productsInVehicle = this.currentVehicle.Trunk.Count;
            //var unloadedProductsCount = productsInVehicle - Vehicle.Trunk.Count;
            return $"Unloaded {unloadedProductsCount}/{productsInVehicle} products at {StorageName}";
        }

        
        public string GetStorageStatus(string StorageName)  {
            
        }




    }

}
