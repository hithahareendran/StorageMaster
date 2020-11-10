using StorageMaster.Models.Products;
using System;
using System.Collections.Generic;
using System.Text;
using WarehouseManagement.Factories;

namespace StorageMaster
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Gpu gpu = new Gpu(23);
            Ram ram = new Ram(10);
            HardDrive harddrive = new HardDrive(40);
            SolidStateDrive solidStateDrive = new SolidStateDrive(50);
            Vehicle vehicles = new Vehicle(500);
            var storageFac = new StorageFactory(10000);
            Console.WriteLine(gpu.Price);
            Console.WriteLine(gpu.Weight);
            Console.WriteLine(harddrive.Weight);
            Console.WriteLine(harddrive.Price);
            Console.WriteLine(solidStateDrive.Weight);
            Console.WriteLine(solidStateDrive.Price);
            Console.WriteLine(ram.Weight);
            Console.WriteLine(ram.Price);
            Console.WriteLine(vehicles.Capacity);
            Console.WriteLine(storageFac.Price);

        }
    }
}
