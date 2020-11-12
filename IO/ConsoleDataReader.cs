using System;
using System.Collections.Generic;



namespace StorageMaster
{
    // Class that reads the commands
    //Will implement interface IReader
    public class ConsoleDataReader
    {
        public ConsoleDataReader()
        {

            // 1.Get the command name and parameters from user
            // 2. Call writer class to present the results 
            
            List<String> commands = new List<String>();
            var input = "";

            do
            {
                input = Console.ReadLine();
                commands.Add(input);
            } while (input != "END");

            new ConsoleDataWriter(commands);

        }
    }
}
