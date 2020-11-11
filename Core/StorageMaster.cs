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

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            Storage storage = storageRegistry.First(s => s.Name == storageName);
            int productsInVehicle = storage.GetVehicle(garageSlot).Trunk.Count;
            int unloadedProductsCount = storage.UnloadVehicle(garageSlot);
            return $"Unloaded {unloadedProductsCount}/{productsInVehicle} products at {storageName}";
        }

        public string GetStorageStatus(string storageName)
        {
            Storage storage = storageRegistry.First(s => s.Name == storageName);
            IEnumerable<String> stockInfo = storage.Products.GroupBy(p => p.GetType().Name)
                .Select(group => new
                {
                    Name = group.Key,
                    Count = group.Count()
                })
                .OrderByDescending(group => group.Count)
                .ThenBy(group => group.Name)
                .Select(group => String.Format("{0}({1})", group.Name, group.Count));

            double weightSum = storage.Products.Sum(p => p.Weight);
            int storageCapacity = storage.Capacity;

            List<String> vehicleName = new List<string>();
            for (int i = 0; i < storageCapacity; i++)
            {
                Vehicle vehicle = storage.GetVehicle(i);
                if (vehicle == null)
                    vehicleName.Add("empty");
                else
                    vehicleName.Add(vehicle.GetType().Name);

            }

            return $"Stock ({weightSum}/{storageCapacity}): [{String.Join(",", stockInfo)}]" +
                    Environment.NewLine +
                    $"Garage: [{String.Join("| ", vehicleName)}]";
        }

        public string GetSummary()
        {
            IEnumerable<String> priceInfo = storageRegistry
                .OrderByDescending(storage => storage.Products.Sum(p => p.Price))
                .Select(s => $"{s.Name}:" + Environment.NewLine + $"Storage worth: ${s.Products.Sum(p => p.Price):F2}");

            return String.Join(Environment.NewLine, priceInfo);

        }





    }

}
