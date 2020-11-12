//using StorageMaster.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorageMaster
{
    class StartUp
    {
        enum Commands
        {
            AddProduct,
            RegisterStorage,
            SelectVehicle
        }

        static void tempSwitch()
        {

            var storageMaster = new StorageMaster();

            // 1.get the command name and parameters from user
            var inputArray = Console.ReadLine().Split();
            var userCommand = inputArray[0];
            var userParameters = inputArray[1..]; //all items exept the first

            Console.WriteLine(userParameters[0]);
            Console.WriteLine(userParameters[1]);

            // 2. validate the input: checking if the userinput matches available methods
            // 3. based on userinput call the right method from Storagemaster
            // Status! storagemasterobject.(methodname) is not firing in the switch.
            // ---works if methods are static in storagemasterclass and just call directly.
            if (Enum.TryParse<Commands>(userCommand, out var cmd))
            {
                switch (cmd)
                {
                    case Commands.AddProduct:
                        storageMaster.AddProduct(userParameters[0], double.Parse(userParameters[1]));
                        break;

                    case Commands.RegisterStorage:
                        storageMaster.RegisterStorage(userParameters[0], userParameters[1]);
                        break;

                    case Commands.SelectVehicle:

                        storageMaster.SelectVehicle(userParameters[0], int.Parse(userParameters[1]));
                        break;

                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine("Unknown command");

            }
        }

        static void Main(string[] args)
        {
            tempSwitch();

            var storageMaster = new StorageMaster();

           

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
