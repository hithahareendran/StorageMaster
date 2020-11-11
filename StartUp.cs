//using StorageMaster.Models.Vehicles;
using System;
using System.Collections.Generic;

namespace StorageMaster
{
    class StartUp
    {
        static void Main(string[] args)
        {
           

            try
            {

                var controller = new StorageMaster();
                Console.WriteLine(controller.RegisterStorage("Warehouse", "testStorage"));
                Console.WriteLine(controller.SelectVehicle("testStorage", 0));
                Console.WriteLine(controller.AddProduct("Gpu", 100));
                Console.WriteLine(controller.AddProduct("Ram", 100));
                Console.WriteLine(controller.LoadVehicle(new List<String>() { "Gpu","Ram"}));
                Console.WriteLine(controller.UnloadVehicle("testStorage", 0));
                Console.WriteLine(controller.GetStorageStatus("testStorage"));
                Console.WriteLine(controller.GetSummary());




            }
            catch (Exception e)
            {
                
                Console.WriteLine(e.Message);
            }
            
            // // --------below creates error. Planned fix:
            // // we need to register a storage first before. = TODO
            //--------------------------------
            // Console.WriteLine( "testiiing" );
            // var controller = new WarehouseManagement.Core.StorageMaster();
            // controller.GetStorageStatus("Awesome storage");
            
        }
    }
}
