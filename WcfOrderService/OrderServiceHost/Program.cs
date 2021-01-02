using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace OrderServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost
         (typeof(WcfOrderService.OrderPlacementService)))
            {
                host.Open();
                Console.WriteLine("OrderService Host started @ " + DateTime.Now.ToString());


                //if (host.State != CommunicationState.Closed)
                //    host.Close();

                Console.ReadLine();

            }
        }
        }
}
