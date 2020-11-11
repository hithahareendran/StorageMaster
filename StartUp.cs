//using StorageMaster.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorageMaster
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var storageMaster = new StorageMaster();

            /*try
            {
                Console.WriteLine(storageMaster.RegisterStorage("Warehouse", "testStorage"));
                Console.WriteLine(storageMaster.SelectVehicle("testStorage", 0));
                Console.WriteLine(storageMaster.AddProduct("Gpu", 100));
                Console.WriteLine(storageMaster.AddProduct("Ram", 100));
                Console.WriteLine(storageMaster.LoadVehicle(new List<String>() { "Gpu","Ram"}));
                Console.WriteLine(storageMaster.UnloadVehicle("testStorage", 0));
                Console.WriteLine(storageMaster.GetStorageStatus("testStorage"));
                Console.WriteLine(storageMaster.GetSummary());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }*/


            //read commands
            List<String> commands = new List<String>();
            var input = "";
            do
            {
                input = Console.ReadLine();
                commands.Add(input);
            } while (input != "END");


            //execute commands
            foreach (var commandWithParams in commands)
            {
                List<String> command = commandWithParams.Split(" ").ToList();
                try
                {
                    switch (command[0])
                    {
                        case "AddProduct": Console.WriteLine(storageMaster.AddProduct(command[1], double.Parse(command[2]))); break;
                        case "RegisterStorage": Console.WriteLine(storageMaster.RegisterStorage(command[1], command[2])); break;
                        case "SelectVehicle": Console.WriteLine(storageMaster.SelectVehicle(command[1], int.Parse(command[2]))); break;
                        case "LoadVehicle": Console.WriteLine(storageMaster.LoadVehicle(command.Where(item => item != command[0]))); break;
                        case "SendVehicleTo": Console.WriteLine(storageMaster.SendVehicleTo(command[1], int.Parse(command[2]), command[3])); break;
                        case "UnloadVehicle": Console.WriteLine(storageMaster.UnloadVehicle(command[1], int.Parse(command[2]))); break;
                        case "GetStorageStatus": Console.WriteLine(storageMaster.GetStorageStatus(command[1])); break;
                        case "END": Console.WriteLine(storageMaster.GetSummary()); break;

                        default: throw new InvalidOperationException("No Command " + command[0]);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }

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
