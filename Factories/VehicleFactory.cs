using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster
{
    public static class VehicleFactory
    {
        public static Vehicle CreateVehicle(String type)
        {
            switch (type)
            {
                case "Semi": return new Semi();
                case "Truck": return new Truck();
                case "Van": return new Van();
                default: throw new InvalidOperationException("Invalid vehicle type!");
            }
        }
    }
}
