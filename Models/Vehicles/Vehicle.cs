using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Xml.Linq;

namespace StorageMaster.Models.Vehicles
{
    public abstract class Vehicle
    {
        private List<Product> trunk;

        private int Capacity { get; set; }
        public IReadOnlyCollection<Product> Trunk {
            get {
                return trunk.AsReadOnly();
            }
        }
        public bool IsFull
        {
            get {
                double sum = 0;
                foreach (Product p in Trunk)
                {
                    sum += p.Weight;
                }
                if (sum >= this.Capacity)
                   return true;
                else
                    return false;
            }
        }
        public bool IsEmpty {
            get {
                if (this.Trunk.Count == 0)
                    return true;
                else
                    return false;
            }
         
        }


        public Vehicle(int capcity)
        {
            this.Capacity = capcity;
            this.trunk = new List<Product>();
        }

        public void LoadProduct(Product product)
        {
            if (this.IsFull)
                throw new InvalidOperationException("Vehicle is full!");
            else
                trunk.Add(product);
        }

        public Product Unload()
        {
            if(this.IsEmpty)
                throw new InvalidOperationException("No products left in vehicle!");
            else
            {
                Product product = this.trunk[trunk.Count - 1];
                this.trunk.RemoveAt(trunk.Count - 1);
                return product;
            }
        }

    }
}
