using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfOrderService
{
    [ServiceContract(CallbackContract = typeof(IOrderKitchenServiceCallback))] //Kitchen service interface

    public interface IOrderPlacementService2
    {
        [OperationContract(IsOneWay = false)]
        void SendOrder(int id, string name, DateTime dateTime);

        [OperationContract(IsOneWay = false)]
        bool OrderSubscribe();

        [OperationContract(IsOneWay = false)]
        bool OrderUnsubscribe();
    }
   
    public interface IOrderKitchenServiceCallback // kitchen
    {
        // If we not set IsOnway=true, the operation is Request/Reply operation
        [OperationContract(IsOneWay = true)]
        void OrderKitchenCallback(int Id, string Name, DateTime dateTime);
    }



}
