﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WcfKitchenService.OrderService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="OrderService.IOrderPlacementService", CallbackContract=typeof(WcfKitchenService.OrderService.IOrderPlacementServiceCallback))]
    public interface IOrderPlacementService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderPlacementService/PlaceOrder", ReplyAction="http://tempuri.org/IOrderPlacementService/PlaceOrderResponse")]
        void PlaceOrder(int id, string name, System.DateTime dateTime);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderPlacementService/PlaceOrder", ReplyAction="http://tempuri.org/IOrderPlacementService/PlaceOrderResponse")]
        System.Threading.Tasks.Task PlaceOrderAsync(int id, string name, System.DateTime dateTime);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderPlacementService/PublishToOrderService", ReplyAction="http://tempuri.org/IOrderPlacementService/PublishToOrderServiceResponse")]
        void PublishToOrderService(int id, string name, System.DateTime dateTime);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderPlacementService/PublishToOrderService", ReplyAction="http://tempuri.org/IOrderPlacementService/PublishToOrderServiceResponse")]
        System.Threading.Tasks.Task PublishToOrderServiceAsync(int id, string name, System.DateTime dateTime);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderPlacementService/OrderSubscribe", ReplyAction="http://tempuri.org/IOrderPlacementService/OrderSubscribeResponse")]
        bool OrderSubscribe();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderPlacementService/OrderSubscribe", ReplyAction="http://tempuri.org/IOrderPlacementService/OrderSubscribeResponse")]
        System.Threading.Tasks.Task<bool> OrderSubscribeAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderPlacementService/OrderUnsubscribe", ReplyAction="http://tempuri.org/IOrderPlacementService/OrderUnsubscribeResponse")]
        bool OrderUnsubscribe();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderPlacementService/OrderUnsubscribe", ReplyAction="http://tempuri.org/IOrderPlacementService/OrderUnsubscribeResponse")]
        System.Threading.Tasks.Task<bool> OrderUnsubscribeAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IOrderPlacementServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderPlacementService/OrderCallback", ReplyAction="http://tempuri.org/IOrderPlacementService/OrderCallbackResponse")]
        void OrderCallback(int Id, string Name, System.DateTime dateTime);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderPlacementService/PublishToOrderServiceCallback", ReplyAction="http://tempuri.org/IOrderPlacementService/PublishToOrderServiceCallbackResponse")]
        void PublishToOrderServiceCallback(int Id, string Name, System.DateTime dateTime);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderPlacementService/SubscribeToCustomerCallback", ReplyAction="http://tempuri.org/IOrderPlacementService/SubscribeToCustomerCallbackResponse")]
        void SubscribeToCustomerCallback(int Id, string Name, System.DateTime dateTime);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IOrderPlacementServiceChannel : WcfKitchenService.OrderService.IOrderPlacementService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class OrderPlacementServiceClient : System.ServiceModel.DuplexClientBase<WcfKitchenService.OrderService.IOrderPlacementService>, WcfKitchenService.OrderService.IOrderPlacementService {
        
        public OrderPlacementServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public OrderPlacementServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public OrderPlacementServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public OrderPlacementServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public OrderPlacementServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void PlaceOrder(int id, string name, System.DateTime dateTime) {
            base.Channel.PlaceOrder(id, name, dateTime);
        }
        
        public System.Threading.Tasks.Task PlaceOrderAsync(int id, string name, System.DateTime dateTime) {
            return base.Channel.PlaceOrderAsync(id, name, dateTime);
        }
        
        public void PublishToOrderService(int id, string name, System.DateTime dateTime) {
            base.Channel.PublishToOrderService(id, name, dateTime);
        }
        
        public System.Threading.Tasks.Task PublishToOrderServiceAsync(int id, string name, System.DateTime dateTime) {
            return base.Channel.PublishToOrderServiceAsync(id, name, dateTime);
        }
        
        public bool OrderSubscribe() {
            return base.Channel.OrderSubscribe();
        }
        
        public System.Threading.Tasks.Task<bool> OrderSubscribeAsync() {
            return base.Channel.OrderSubscribeAsync();
        }
        
        public bool OrderUnsubscribe() {
            return base.Channel.OrderUnsubscribe();
        }
        
        public System.Threading.Tasks.Task<bool> OrderUnsubscribeAsync() {
            return base.Channel.OrderUnsubscribeAsync();
        }
    }
}