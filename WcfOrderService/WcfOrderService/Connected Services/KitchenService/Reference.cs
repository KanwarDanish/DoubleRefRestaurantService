﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WcfOrderService.KitchenService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="KitchenService.IKitchenRecievingService", CallbackContract=typeof(WcfOrderService.KitchenService.IKitchenRecievingServiceCallback))]
    public interface IKitchenRecievingService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IKitchenRecievingService/PublishToKitchenService", ReplyAction="http://tempuri.org/IKitchenRecievingService/PublishToKitchenServiceResponse")]
        void PublishToKitchenService(int id, string name, System.DateTime dateTime);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IKitchenRecievingService/PublishToKitchenService", ReplyAction="http://tempuri.org/IKitchenRecievingService/PublishToKitchenServiceResponse")]
        System.Threading.Tasks.Task PublishToKitchenServiceAsync(int id, string name, System.DateTime dateTime);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IKitchenRecievingService/RecieveKitchen", ReplyAction="http://tempuri.org/IKitchenRecievingService/RecieveKitchenResponse")]
        void RecieveKitchen(int id, string name, System.DateTime dateTime);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IKitchenRecievingService/RecieveKitchen", ReplyAction="http://tempuri.org/IKitchenRecievingService/RecieveKitchenResponse")]
        System.Threading.Tasks.Task RecieveKitchenAsync(int id, string name, System.DateTime dateTime);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IKitchenRecievingService/KitchenSubscribe", ReplyAction="http://tempuri.org/IKitchenRecievingService/KitchenSubscribeResponse")]
        bool KitchenSubscribe();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IKitchenRecievingService/KitchenSubscribe", ReplyAction="http://tempuri.org/IKitchenRecievingService/KitchenSubscribeResponse")]
        System.Threading.Tasks.Task<bool> KitchenSubscribeAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IKitchenRecievingService/KitchenUnsubscribe", ReplyAction="http://tempuri.org/IKitchenRecievingService/KitchenUnsubscribeResponse")]
        bool KitchenUnsubscribe();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IKitchenRecievingService/KitchenUnsubscribe", ReplyAction="http://tempuri.org/IKitchenRecievingService/KitchenUnsubscribeResponse")]
        System.Threading.Tasks.Task<bool> KitchenUnsubscribeAsync();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IKitchenRecievingService/GetBackOrder")]
        void GetBackOrder(int id, string name, System.DateTime dateTime);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IKitchenRecievingService/GetBackOrder")]
        System.Threading.Tasks.Task GetBackOrderAsync(int id, string name, System.DateTime dateTime);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IKitchenRecievingServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IKitchenRecievingService/KitchenCallback")]
        void KitchenCallback(int orderId, string orderName, System.DateTime dateTime);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IKitchenRecievingService/KitchenSendToStationCallback")]
        void KitchenSendToStationCallback(int orderId, string orderName, System.DateTime dateTime);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IKitchenRecievingService/StationSendToKitchenCallback")]
        void StationSendToKitchenCallback(int orderId, string orderName, System.DateTime dateTime);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IKitchenRecievingServiceChannel : WcfOrderService.KitchenService.IKitchenRecievingService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class KitchenRecievingServiceClient : System.ServiceModel.DuplexClientBase<WcfOrderService.KitchenService.IKitchenRecievingService>, WcfOrderService.KitchenService.IKitchenRecievingService {
        
        public KitchenRecievingServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public KitchenRecievingServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public KitchenRecievingServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public KitchenRecievingServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public KitchenRecievingServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void PublishToKitchenService(int id, string name, System.DateTime dateTime) {
            base.Channel.PublishToKitchenService(id, name, dateTime);
        }
        
        public System.Threading.Tasks.Task PublishToKitchenServiceAsync(int id, string name, System.DateTime dateTime) {
            return base.Channel.PublishToKitchenServiceAsync(id, name, dateTime);
        }
        
        public void RecieveKitchen(int id, string name, System.DateTime dateTime) {
            base.Channel.RecieveKitchen(id, name, dateTime);
        }
        
        public System.Threading.Tasks.Task RecieveKitchenAsync(int id, string name, System.DateTime dateTime) {
            return base.Channel.RecieveKitchenAsync(id, name, dateTime);
        }
        
        public bool KitchenSubscribe() {
            return base.Channel.KitchenSubscribe();
        }
        
        public System.Threading.Tasks.Task<bool> KitchenSubscribeAsync() {
            return base.Channel.KitchenSubscribeAsync();
        }
        
        public bool KitchenUnsubscribe() {
            return base.Channel.KitchenUnsubscribe();
        }
        
        public System.Threading.Tasks.Task<bool> KitchenUnsubscribeAsync() {
            return base.Channel.KitchenUnsubscribeAsync();
        }
        
        public void GetBackOrder(int id, string name, System.DateTime dateTime) {
            base.Channel.GetBackOrder(id, name, dateTime);
        }
        
        public System.Threading.Tasks.Task GetBackOrderAsync(int id, string name, System.DateTime dateTime) {
            return base.Channel.GetBackOrderAsync(id, name, dateTime);
        }
    }
}
