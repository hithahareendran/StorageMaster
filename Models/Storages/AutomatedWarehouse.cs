using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster
{
    class AutomatedWarehouse : Storage
    {
        public AutomatedWarehouse(String name) : base(name, 1, 2, new Vehicle[] { new Truck() })
        { }
    }
}
