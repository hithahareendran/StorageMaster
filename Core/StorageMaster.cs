using StorageMaster;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorageMaster
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

        // Create a new product and add to pool
        public string AddProduct(string type, double price)
        {
            var product = ProductFactory.CreateProduct(type, price);
            this.productPool.Add(product);

            return $"Added {type} to pool";
        }

        // Create a storage and add to storageregistry
        public string RegisterStorage(string type, string name)
        {
            var store = StorageFactory.CreateStorage(type, name);
            storageRegistry.Add(store);

            return $"Registered {name}";
        }

        // Select the current vehicle in the storage garageslot
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
                // check if prouct is available
                if (!productPool.Any(p => p.GetType().Name == name))
                {
                    throw new InvalidOperationException($"{name} is out of stock!");
                }
                else
                {
                    // Exit when vehicle is full
                    if (currentVehicle == null || currentVehicle.IsFull) break;
                    // Find last product and remove from pool then load to vehicle
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
            // check if sourcestorage exists
            if (!storageRegistry.Any(s => s.Name == sourceName))
            {
                throw new InvalidOperationException($"Invalid source storage!");
            }
            // Check if destination storage exists
            else if (!storageRegistry.Any(s => s.Name == destinationName))
            {
                throw new InvalidOperationException($"Invalid destination storage!");
            }
            else
            {
             // Send vehicle to the destination storage
                Storage sourceStorage = storageRegistry.First(s => s.Name == sourceName);
                Vehicle vehicle = sourceStorage.GetVehicle(sourceGarageSlot);
                Storage deliveryLocation = storageRegistry.First(s => s.Name == destinationName);
                int destinationGarageSlot = sourceStorage.SendVehicleTo(sourceGarageSlot, deliveryLocation);
                return $"Sent {vehicle.GetType().Name} to {deliveryLocation.Name} (slot {destinationGarageSlot})";
            }

        }

        // Get the vehicle in the storage garageslot
        public string UnloadVehicle(string StorageName, int GarageSlot)
        {
            // count need to be calculated before unloading
            var productsInVehicle = this.currentVehicle.Trunk.Count;
            int unloadedProductsCount = storageRegistry.First(s => s.Name == StorageName)
                .UnloadVehicle(GarageSlot);

            return $"Unloaded {unloadedProductsCount}/{productsInVehicle} products at {StorageName}";
        }


        public string GetStorageStatus(string StorageName)
        {
            //1. get storage
            Storage storage = this.storageRegistry.First(s => s.Name == StorageName);

            //2. products-> group by name, and count
            //   sort by count descending
            //   then by name ascending  ( eg result :  HardDrive (2)  )
            var stockInfo = storage.Products
                .GroupBy(p => p.GetType().Name) /* returns key -> name,  and Count() */
                .OrderByDescending(g => g.Count())
                .ThenBy(g => g.Key)
                .Select(g => String.Format("{0} ({1})", g.Key, g.Count()));


            //3. get name of all vehicle with 'empty'
            List<String> vehicleNames = new List<String>();
            foreach(var vehicle in storage.Garage)
            {
                if (vehicle == null)
                    vehicleNames.Add("empty");
                else
                    vehicleNames.Add(vehicle.GetType().Name); 
            }

            //4. Result -> "Stock ({0}/{1}): [{2}]” ,  0->sum of products weight, 1->capacity, 2->(step 2 stock)
            // eg: - Stock (2.7/10): [HardDrive (2), Gpu (1)]
            var result1 = String.Format("Stock ({0}/{1}): [{2}]", storage.Products.Sum(p=>p.Weight) 
                ,storage.Capacity, String.Join(", ", stockInfo));

            //5. Result-> “Garage: [{0}]”, eg-> (from step3) Garage: [Semi|Semi|Semi|Van|empty|empty|empty|empty|empty|empty]
            var result2 = String.Format("Garage: [{0}]", String.Join("|", vehicleNames));

            return result1 + Environment.NewLine + result2;

        }

        public string GetSummary()
        {
            // 1. get sum of the product price in desc =totalmoney
            // 2. for each storage produce {storageName}:+ Environment.Newline + Storage worth: ${ totalMoney: F2}
           
            var results = storageRegistry
                .OrderByDescending(s => s.Products.Sum(p => p.Price))
                .Select(s => {
                    var totalMoney = s.Products.Sum(p => p.Price);
                    var result = $"{s.Name }:" + Environment.NewLine + 
                    string.Format("Storage worth: ${0:F2}",totalMoney);
                    return result;
                });

            // 3. join each result by new lines
            return string.Join(Environment.NewLine, results);
        }

    }



}


