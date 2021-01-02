using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace WcfOrderService
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant, InstanceContextMode = InstanceContextMode.PerSession)]

    public class OrderPlacementService : IOrderPlacementService, KitchenService.IKitchenRecievingServiceCallback
    {

        static List<IOrderServiceCallback> OrderSubscribers = new List<IOrderServiceCallback>();

        KitchenService.KitchenRecievingServiceClient client;

        public OrderPlacementService()
        {
            InstanceContext instanceContext = new InstanceContext(this);
            client = new KitchenService.KitchenRecievingServiceClient(instanceContext);
        }

        int ID;
        string Name;
        string DateTime;

        public void PlaceOrder(int id, string name, DateTime dateTime)
        {
            ID = id;
            Name = name;
            
            DateTime = dateTime.ToString();
            OperationContext.Current.GetCallbackChannel<IOrderServiceCallback>().OrderCallback(ID, Name, dateTime);
            Console.WriteLine("Order From Customer: {0}", ID.ToString() + Name, dateTime);
            client.PublishToKitchenService(id, name , dateTime);    //Sends order to KS from OS
        }
        public void KitchenCallback(int orderId, string orderName, DateTime dateTime) //Tells OS that order is recieved
        {
            Console.WriteLine("CB:Order Recieved in KS from OS=> {0}", orderId + orderName + dateTime);
        }




        public void PublishToOrderService(int id, string name, DateTime dateTime)
        {
            this.ID = id;
            this.Name = name;
            this.DateTime = dateTime.ToString();

            
            OperationContext.Current.GetCallbackChannel<IOrderServiceCallback>().PublishToOrderServiceCallback(id, name, dateTime);
            RecieveOrder(id, name, dateTime);
            Console.WriteLine("Order taken to OS from KS + :{0}", id + name + dateTime);
        }

        public void RecieveOrder(int id, string name, DateTime dateTime) //Writing in KS. Relates OS and KS.
        {
            OrderSubscribers.ForEach(delegate (IOrderServiceCallback callback)
            {
                if (((ICommunicationObject)callback).State == CommunicationState.Opened)
                {
                    callback.SubscribeToCustomerCallback(id, name, dateTime);
                    Console.WriteLine("CB:Order Recieved in KS:" + id + name + dateTime);
                }
                else
                {
                    OrderSubscribers.Remove(callback);
                }
            });
        }


        public bool OrderSubscribe()
        {
            try
            {
                IOrderServiceCallback callback = OperationContext.Current.GetCallbackChannel<IOrderServiceCallback>();
                if (!OrderSubscribers.Contains(callback))
                    OrderSubscribers.Add(callback);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool OrderUnsubscribe()
        {
            try
            {
                IOrderServiceCallback callback = OperationContext.Current.GetCallbackChannel<IOrderServiceCallback>();
                if (OrderSubscribers.Contains(callback))
                    OrderSubscribers.Remove(callback);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void StationSendToKitchenCallback(int orderId, string orderName, DateTime dateTime)
        {
            //throw new NotImplementedException();
        }
        public void KitchenSendToStationCallback(int orderId, string orderName, DateTime dateTime)
        {
            //throw new NotImplementedException();
        }









    }
}



