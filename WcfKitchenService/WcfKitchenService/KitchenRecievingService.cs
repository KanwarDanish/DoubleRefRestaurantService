using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace WcfKitchenService
{
    // [CallbackBehavior(UseSynchronizationContext = false)]
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant, InstanceContextMode = InstanceContextMode.PerSession)]
    public class KitchenRecievingService : IKitchenRecievingService, OrderService.IOrderPlacementServiceCallback
    {
        
        static List<IKitchenStationCallback> KitchenSubscribers = new List<IKitchenStationCallback>();

        OrderService.OrderPlacementServiceClient client;
        public KitchenRecievingService()
        {
            InstanceContext instanceContext = new InstanceContext(this);
            client = new OrderService.OrderPlacementServiceClient(instanceContext);
        }


         int id;
         string name;
         string dateTime;

        public void PublishToKitchenService(int id, string name, DateTime dateTime) //Taking from OS...publishing
        {
            this.id = id;
            this.name = name;
            this.dateTime = dateTime.ToString();
            
            OperationContext.Current.GetCallbackChannel<IKitchenStationCallback>().KitchenCallback(id,name,dateTime);
            RecieveKitchen(id, name, dateTime);
            Console.WriteLine("Order taken to KS from OS + :{0}", id + name + dateTime);
        }

        public void PublishToOrderServiceCallback(int Id, string Name, DateTime dateTime)
        {
            Console.WriteLine("CB:From OS to KS" + Id+Name+dateTime);
        }


        public void RecieveKitchen(int id, string name, DateTime dateTime) //Writing in KS. Relates OS and KS.
        {
            KitchenSubscribers.ForEach(delegate (IKitchenStationCallback callback)
            {
                if (((ICommunicationObject)callback).State == CommunicationState.Opened)
                {    
                    callback.KitchenSendToStationCallback(id, name, dateTime);
                    Console.WriteLine("CB:Order Recieved in Station:" + id + name   + dateTime);
                }
                else
                {
                    KitchenSubscribers.Remove(callback);
                }
            });
        }

        public bool KitchenSubscribe()//KS subscription by Station
        {
            try
            {
                IKitchenStationCallback callback = OperationContext.Current.GetCallbackChannel<IKitchenStationCallback>();
                if (!KitchenSubscribers.Contains(callback))
                    KitchenSubscribers.Add(callback);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool KitchenUnsubscribe()
        {
            try
            {
                IKitchenStationCallback callback = OperationContext.Current.GetCallbackChannel<IKitchenStationCallback>();
                if (KitchenSubscribers.Contains(callback))
                    KitchenSubscribers.Remove(callback);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void GetBackOrder(int id, string name, DateTime dateTime)
        {
            // OperationContext.Current.GetCallbackChannel<IKitchenStationCallback>().StationSendToKitchenCallback( id, name, dateTime);

            this.id = id;
            this.name = name;
            this.dateTime = dateTime.ToString();
            OperationContext.Current.GetCallbackChannel<IKitchenStationCallback>().StationSendToKitchenCallback(id,name,dateTime);
            Console.WriteLine("Order From Station: {0}", id+name+dateTime);
            client.PublishToOrderService(id,name,dateTime); 
        }

        public void OrderCallback(int Id, string Name, DateTime dateTime)
        {
            //throw new NotImplementedException();
        }

       
        public void SubscribeToCustomerCallback(int Id, string Name, DateTime dateTime)
        {
            //throw new NotImplementedException();
        }
    }
}