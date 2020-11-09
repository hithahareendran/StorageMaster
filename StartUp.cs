using System;

namespace StorageMaster
{
    class StartUp
    {
        static void Main(string[] args)
        {
            
            Gpu gp = new Gpu(12);
            Console.WriteLine(gp.Price);
            Console.WriteLine(gp.Weight);
        }
    }
}