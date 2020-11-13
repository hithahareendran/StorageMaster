using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster
{ // base class for product children
    public abstract class Product
    {
        
        private double price;
        private double weight;

        public Product(double price,double weight)
        {
            this.Price = price;
            this.Weight = weight;
        }
        
        public double Price
        {
            get { return this.price; } // get => this.price;
            
            // validating input
            set
            {
                
                    if (value < 0)
                {
                    throw new InvalidOperationException("price cannot be negative!");
                }
                this.price = value;
                
            }
        }
        public double Weight
        {
            get { return this.weight; }
            set { this.weight = value;}
        }
    }
}
