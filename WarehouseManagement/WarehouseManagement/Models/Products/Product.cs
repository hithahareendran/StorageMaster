using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster
{
   public abstract class Product
    {

        private double price { get; set; }
        private double weight { get; set; }
        public Product(double price, double weight)
        {
            this.price = price;
            this.weight = weight;
        }
        
        public double Price
        {
            get { return this.price; }
            set
            {
                if (price < 0)
                {
                    throw new InvalidOperationException("Price cannot be negative");
                }
                this.price = value;
            }
        }
        public double Weight
        {
            get { return this.weight; }
            set { this.weight = value; }
        }
    }
}
