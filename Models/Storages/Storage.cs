using System;
//using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using System.Text;

namespace StorageMaster
{
    public abstract class Storage
    {
        private List<Product> products;
        private List<Vehicle> vehicles;

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int GarageSlots { get; set; }
        public bool IsFull {
            get
            {
               return products.Sum(product => product.Weight) >= this.Capacity;
            }
        }
        public IReadOnlyCollection<Vehicle> Garage
        {
            get
            {
                return vehicles.ToList();
            }
            set
            {
                this.vehicles = value.ToList(); ;
            }
        }
        public IReadOnlyCollection<Product> Products 
        {
            get
            {
                return products.ToList();
            }
        }

        public Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.GarageSlots = garageSlots;
            this.vehicles = vehicles.ToList();
            this.products = new List<Product>();
        }

        public Vehicle GetVehicle(int garageSlot)
        {
            // Check if garageslot exists
            if (garageSlot >= this.GarageSlots)
                throw new InvalidOperationException("Invalid garage slot!");

            // Check if garageslot is empty
            else if (vehicles.ElementAt(garageSlot) == null)
                throw new InvalidOperationException("No vehicle in this garage slot!");
            else
                return vehicles.ElementAt(garageSlot);
        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
           Vehicle vehicle = this.GetVehicle(garageSlot);
            if (deliveryLocation.Garage.Contains(null) )
            {
                //free our vehicle
                vehicles[garageSlot] = null;

                //find the first free slot and add the vehicle on location
                var deliveryLocationGarage = deliveryLocation.Garage.ToList();
                int firstFreeGarageSlot = deliveryLocationGarage.FindIndex(v => v == null);
                deliveryLocationGarage[firstFreeGarageSlot] = vehicle;
                deliveryLocation.Garage = deliveryLocationGarage;

                return firstFreeGarageSlot;
            }
            else
            {
                throw new InvalidOperationException("No room in garage!");
            }
        }

        public int UnloadVehicle(int garageSlot)
        {
            if (IsFull)
                throw new InvalidOperationException("Storage is full!");

            Vehicle vehicle = this.GetVehicle(garageSlot);
            int numberOfUnloadedProducts = 0;
 
                while (!IsFull && !vehicle.IsEmpty)
                {
                    Product product = vehicle.Unload();
                    products.Add(product);
                    numberOfUnloadedProducts++;
                }
            return numberOfUnloadedProducts;
        }


    }
}
