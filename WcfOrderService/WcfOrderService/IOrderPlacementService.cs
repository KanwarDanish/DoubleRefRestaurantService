using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfOrderService
{
     [ServiceContract(CallbackContract = typeof(IOrderServiceCallback))] //Customer client interface

    public interface IOrderPlacementService
    {
        [OperationContract(IsOneWay = false)]
        void PlaceOrder(int id, string name, DateTime dateTime);

        [OperationContract(IsOneWay = false)]
        void PublishToOrderService(int id, string name, DateTime dateTime);

        [OperationContract(IsOneWay = false)]
        bool OrderSubscribe();
        [OperationContract(IsOneWay = false)]
        bool OrderUnsubscribe();

    }
    public interface IOrderServiceCallback //customer
    {
        // If we not set IsOnway=true, the operation is Request/Reply operation
        [OperationContract(IsOneWay = false)]
        void OrderCallback(int Id, string Name, DateTime dateTime);
        [OperationContract(IsOneWay = false)]
        void PublishToOrderServiceCallback(int Id, string Name, DateTime dateTime);
        [OperationContract(IsOneWay = false)]
        void SubscribeToCustomerCallback(int Id, string Name, DateTime dateTime);



    }




}
