using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace KitchenServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost
         (typeof(WcfKitchenService.KitchenRecievingService)))
            {
                host.Open();
                Console.WriteLine("KitchenService Host started @ " + DateTime.Now.ToString());


                
                //WcfKitchenService.KitchenRecievingService service = new WcfKitchenService.KitchenRecievingService();
                
                Console.ReadLine();

            }
        }
    }
}
