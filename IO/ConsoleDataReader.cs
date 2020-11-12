using System;
using System.Collections.Generic;
using System.Linq;


namespace StorageMaster.IO
{
    // Class that reads the commands, handles exceptions and passes the command to the StorageMaster
    //Will implement interface IReader
    public class ConsoleDataReader
    {
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

        public ConsoleDataReader()
        {

            // 1. get the command name and parameters from user
            // 2. validate the input
            // 3. based on userinput (use switch statements..), call the right method from Storagemaster
          
            var storageMaster = new StorageMaster();

            //read commands
            List<String> commands = new List<String>();
            var input = "";

            do
            {
                input = Console.ReadLine();
                commands.Add(input);
            } while (input != "END");

            foreach (var commandWithParams in commands)
            {
                List<String> command = commandWithParams.Split(" ").ToList();

                // catching errors the methodcalls
                try
                {
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

        }
    }
}
