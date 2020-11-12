using System;
using System.Collections.Generic;
using System.Linq;

namespace StorageMaster
{
    // 1. validate the input
    // 2. based on userinput (use switch statements..), call the right method from Storagemaster
    // 3. Present result to user

    public class ConsoleDataWriter
    {
        //private List<string> commands;
        private StorageMaster storageMaster;

        // The actions in StorageMaster available for user
        enum Commands
        {
            AddProduct,
            RegisterStorage,
            SelectVehicle,
            LoadVehicle,
            SendVehicleTo,
            UnloadVehicle,
            GetStorageStatus,
            END
        }

        public ConsoleDataWriter()
        {
            this.storageMaster = new StorageMaster();
        }

        public void WriteData(string commandWithParams)
        {

            List<String> command = commandWithParams.Split(" ").ToList();

            // catching errors from methodcalls
            try
            {   // Some userinput validation: input needs to match an available action
                if (Enum.TryParse<Commands>(command[0], out var cmd))
                {
                    switch (cmd)
                    {
                        case Commands.AddProduct:
                            Console.WriteLine(storageMaster.AddProduct(command[1], double.Parse(command[2])));
                            break;

                        case Commands.RegisterStorage:
                            Console.WriteLine(storageMaster.RegisterStorage(command[1], command[2]));
                            break;

                        case Commands.SelectVehicle:
                            Console.WriteLine(storageMaster.SelectVehicle(command[1], int.Parse(command[2])));
                            break;

                        case Commands.LoadVehicle:
                            Console.WriteLine(storageMaster.LoadVehicle(command.Where(item => item != command[0])));
                            break;

                        case Commands.SendVehicleTo:
                            Console.WriteLine(storageMaster.SendVehicleTo(command[1], int.Parse(command[2]), command[3]));
                            break;

                        case Commands.UnloadVehicle:
                            Console.WriteLine(storageMaster.UnloadVehicle(command[1], int.Parse(command[2])));
                            break;

                        case Commands.GetStorageStatus:
                            Console.WriteLine(storageMaster.GetStorageStatus(command[1]));
                            break;

                        case Commands.END:
                            Console.WriteLine(storageMaster.GetSummary());
                            break;

                        default:
                            break;
                    }
                }
                else Console.WriteLine("Unknown command");

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);

            }
        }

        //public ConsoleDataWriter(List<String> commands)
        //{
        //    this.commands = commands;
        //    var storageMaster = new StorageMaster();

        //    foreach (var commandWithParams in commands)
        //    {
        //        List<String> command = commandWithParams.Split(" ").ToList();

        //        // catching errors the methodcalls
        //        try
        //        {
        //            if (Enum.TryParse<Commands>(command[0], out var cmd))
        //            {
        //                switch (cmd)
        //                {
        //                    case Commands.AddProduct:
        //                        Console.WriteLine(storageMaster.AddProduct(command[1], double.Parse(command[2])));
        //                        break;

        //                    case Commands.RegisterStorage:
        //                        Console.WriteLine(storageMaster.RegisterStorage(command[1], command[2]));
        //                        break;

        //                    case Commands.SelectVehicle:
        //                        Console.WriteLine(storageMaster.SelectVehicle(command[1], int.Parse(command[2])));
        //                        break;

        //                    case Commands.LoadVehicle:
        //                        Console.WriteLine(storageMaster.LoadVehicle(command.Where(item => item != command[0])));
        //                        break;

        //                    case Commands.SendVehicleTo:
        //                        Console.WriteLine(storageMaster.SendVehicleTo(command[1], int.Parse(command[2]), command[3]));
        //                        break;

        //                    case Commands.UnloadVehicle:
        //                        Console.WriteLine(storageMaster.UnloadVehicle(command[1], int.Parse(command[2])));
        //                        break;

        //                    case Commands.GetStorageStatus:
        //                        Console.WriteLine(storageMaster.GetStorageStatus(command[1]));
        //                        break;

        //                    case Commands.END:
        //                        Console.WriteLine(storageMaster.GetSummary());
        //                        break;

        //                    default:
        //                        break;
        //                }
        //            }
        //            else Console.WriteLine("Unknown command");
        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine("Error: " + e.Message);
        //        }

        //    }
        //}
    }
}
