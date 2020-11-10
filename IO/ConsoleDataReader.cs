using System;
using System.Data;

namespace StorageMaster.IO
{
    // Class that reads the commands, handles exceptions and passes the command to the StorageMaster
    //Will implement interface IReader
    public class ConsoleDataReader
    {
        public ConsoleDataReader()
        {
            var inputArray = Console.ReadLine().Split();
            var usercommand = inputArray[0];
            //var parameters = inputArray[


            // 1.get the command name and parameters from user
            // 2. validate the input
            // 3. based on userinput (use switch statements..), call the right method from Storagemaster
            

        }
    }
}
