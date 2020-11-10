using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster
{

    class DistributionCenter : Storage
    {
        public DistributionCenter(String name) : base(name, 2, 5, new Vehicle[] { new Van(), new Van(), new Van() })
        { }
    }
}
