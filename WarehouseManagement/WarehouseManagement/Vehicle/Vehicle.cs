using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace StorageMaster
{
    public /*abstract*/ class Vehicle
    {
        private List<Product> trunk;

        public int Capacity { get; set;}
        public IReadOnlyCollection<Product> Trunk 
        { 
        get
           {
            return trunk.AsReadOnly();
           } 
        }
        public bool IsFull => trunk.Sum(product => product.Weight) >= this.Capacity;

        public bool IsEmpty
        {
            get
           
            {
                if (Trunk.Count == 0)
                    return true;
                else
                   return false;
                
            }
            
        }
      public Vehicle(int capacity)
        {
            this.Capacity = capacity;
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
 
                if (this.IsEmpty)
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
