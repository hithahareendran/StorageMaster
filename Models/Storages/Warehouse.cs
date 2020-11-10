using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster
{
    class Warehouse : Storage
    {
        public Warehouse(String name) : base(name, 10, 10, new Vehicle[] { new Semi(), new Semi(), new Semi() })
        { }
    }
}
