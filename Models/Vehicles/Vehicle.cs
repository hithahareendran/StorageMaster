using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace StorageMaster
{
    public abstract class Vehicle
    {
        public int Capacity { get; private set; }
        private List<Product> trunk;

        public Vehicle(int capacity)
        {
            this.Capacity = capacity;
            this.trunk = new List<Product>();
        }
        public IReadOnlyCollection<Product> Trunk {
            get {
                return trunk.AsReadOnly();
            }
        }
        public bool IsFull
        {
            get {
                return trunk.Sum(product => product.Weight) >= this.Capacity;
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
