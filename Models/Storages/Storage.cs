using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster
{
    public abstract class Storage
    {
        private IEnumerable<Product> products;
        private IEnumerable<Vehicle> vehicles;

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
            this.vehicles = vehicles;
            this.products = new List<Product>();
        }

        public Vehicle GetVehicle(int garageSlot)
        {
            if (garageSlot >= this.GarageSlots)
                throw new InvalidOperationException("Invalid garage slot!");
            else if (this.GarageSlots == 0)
                throw new InvalidOperationException("No vehicle in this garage slot!");
            else
                return vehicles.ElementAt(garageSlot - 1);
        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
           Vehicle vehicle = this.GetVehicle(garageSlot);
            if(deliveryLocation.Garage.Last() == null)
            {
               
            }
            else
            {
                throw new InvalidOperationException("No room in garage!");
            }
        }
    }
}
