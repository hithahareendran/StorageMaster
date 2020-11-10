using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster
{
    public abstract class Storage
    {
        private List<Product> products;
        private IEnumerable<Vehicle> vehicles;
   
        //private class VehicleItrator : IEnumerator<Vehicle>
        //{
        //    private readonly List<Vehicle> vehicles;
        //    private int currentIndex;

        //    public VehicleItrator(IEnumerable<Vehicle> vehicles)
        //    {
        //        this.Reset();
        //        this.vehicles = new List<Vehicle>(vehicles);
        //    }

        //    public void Dispose() { }
        //    public bool MoveNext() => ++this.currentIndex < this.vehicles.Count;
        //    public void Reset() => this.currentIndex = -1;
        //    public Vehicle Current => this.vehicles[this.currentIndex];
        //    object IEnumerator.Current => this.Current;

        //}

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
           Vehicle vehicle = this.GetVehicle(garageSlot-1);
            if (deliveryLocation.Garage.Contains(null) )
            {
                var ourGarage = this.Garage.ToList();
                ourGarage[garageSlot - 1] = null;
                this.Garage = ourGarage;

                var deliveryLocationGarage = deliveryLocation.Garage.ToList();
                int firstFreeGarageSlot = deliveryLocationGarage
                .Where(v => v == null)
                .Select((v, index) => index)
                .First();
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

            Vehicle vehicle = this.GetVehicle(garageSlot - 1);
            int numberOfUnloadedProducts = 0;
            while(this.IsFull || vehicle.IsEmpty)
            {
               Product product = vehicle.Unload();
                products.Add(product);
                numberOfUnloadedProducts++;
            }

            return numberOfUnloadedProducts;

        }


    }
}
