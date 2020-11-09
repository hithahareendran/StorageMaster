using StorageMaster.Models.Vehicles;
using System;

namespace StorageMaster
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Van vh = new Van();
            vh.LoadProduct(new Gpu(100.0));
            vh.LoadProduct(new Gpu(100.0));
            vh.LoadProduct(new HardDrive(100.0));
           // Console.WriteLine(vh.IsEmpty);
            Console.WriteLine(vh.IsFull);
           
        }
    }
}