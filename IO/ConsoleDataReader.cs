using System;

namespace StorageMaster
{

    public class ConsoleDataReader

    {
        public ConsoleDataReader()
        {
            string input = "";
            ConsoleDataWriter writer = new ConsoleDataWriter();
            do
            {
                input = Console.ReadLine();
                writer.WriteData(input);
            } while (input != "END");

        }
    }
}
