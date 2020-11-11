using System;
using WarehouseManagement.Core;

namespace StorageMaster
{
    // Class that reads the commands, handles exceptions and passes the command to the StorageMaster
    //Will implement interface IReader
    public class ConsoleDataReader
    {

        
        //var storagemaster = WarehouseManagement.Core.StorageMaster.;
        enum Commands
        {
            AddProduct,
            RegisterStorage,
            SelectVehicle
        }

        public static void dataReader()
        {
            var storagemaster = new WarehouseManagement.Core.StorageMaster();

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
                        storagemaster.AddProduct(userParameters[0],double.Parse(userParameters[1]));
                        break;

                    case Commands.RegisterStorage:
                        storagemaster.RegisterStorage(userParameters[0], userParameters[1]);
                        break;

                    case Commands.SelectVehicle:
                       
                        storagemaster.SelectVehicle(userParameters[0], int.Parse(userParameters[1]));
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
    }



}

