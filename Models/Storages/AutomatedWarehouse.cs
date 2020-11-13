﻿using System;

namespace StorageMaster
{
    class AutomatedWarehouse : Storage
    {
        public AutomatedWarehouse(String name) : base(name, 1, 2, new Vehicle[2] { new Truck(), null })
        { }
    }
}
