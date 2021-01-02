using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfKitchenService
{
    [ServiceContract(CallbackContract = typeof(IKitchenStationCallback))]
    public interface IKitchenRecievingService
    {
        [OperationContract(IsOneWay = false)]
        void PublishToKitchenService(int id, string name, DateTime dateTime);
        [OperationContract(IsOneWay = false)]
        void RecieveKitchen(int id, string name, DateTime dateTime);
        [OperationContract(IsOneWay = false)]
        bool KitchenSubscribe();
        [OperationContract(IsOneWay = false)]
        bool KitchenUnsubscribe();
        [OperationContract(IsOneWay = true)]
        void GetBackOrder(int id, string name, DateTime dateTime);
    }
    public interface IKitchenStationCallback
    {
        [OperationContract(IsOneWay = true)]
        void KitchenCallback(int orderId, string orderName, DateTime dateTime);
        [OperationContract(IsOneWay = true)]
        void KitchenSendToStationCallback(int orderId, string orderName, DateTime dateTime);
        [OperationContract(IsOneWay = true)]
        void StationSendToKitchenCallback(int orderId, string orderName, DateTime dateTime);
      }
}
