//using StorageMaster.Models.Vehicles;
using System;

namespace StorageMaster
{
    class StartUp
    {
        static void Main(string[] args)
        {
           

            try
            {
                DistributionCenter s = new DistributionCenter("name");
                Console.WriteLine(s.GetVehicle(3));
                
                Van vh = new Van();
                var hd3 = new HardDrive(400.0);
                var hd1 = new HardDrive(200.0);
                var hd2 = new HardDrive(100.0);
                vh.LoadProduct(hd1);
                vh.LoadProduct(hd2);
                Console.WriteLine(s.Name);
                Console.WriteLine(vh.IsFull);
               
                vh.LoadProduct(hd3);



            }
            catch (Exception e)
            {
                
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
