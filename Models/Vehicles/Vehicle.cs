using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Models.Vehicles
{
    public abstract class Vehicle
    {
        private int capacity { get; set; }
        private IReadOnlyCollection<Product> Trunk { get; set; }
        private bool isFull { get; set; }
        private bool isEmpty { get; set; }



        public bool IsFull
        {
            get { return this.isFull; }
            set
            {
                foreach(Product p in Trunk)
                {

                }
                this.isFull = true;
            }
        }
        public bool ISEmpty {
            get { return this.isEmpty }
            set
            {

            }
        }


        public Vehicle(int capcity)
        {
            this.capacity = capcity;
            this.Trunk = new List<Product>();
            this.isFull = this.SetIsFull();
        }

    }
}
