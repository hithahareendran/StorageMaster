﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster
{
    class ProductFactory
    {
        public static Product CreateProduct(String type, double price)
        {
            switch(type)
            {
                case "Gpu": return new Gpu(price);
                case "SolidStateDrive": return new SolidStateDrive(price);
                case "HardDrive": return new HardDrive(price);
                case "Ram": return new Ram(price);
                default: throw new InvalidOperationException("Invalid product type!");
            }
        }
    }
}
