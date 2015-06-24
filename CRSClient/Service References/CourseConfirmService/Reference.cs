﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRSClient.CourseConfirmService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CourseConfirmService.IService")]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/RequestConfirmation", ReplyAction="http://tempuri.org/IService/RequestConfirmationResponse")]
        CRSClient.CourseConfirmService.RequestConfirmationResponse RequestConfirmation(CRSClient.CourseConfirmService.RequestConfirmationRequest request);
        
        // CODEGEN: Generating message contract since the operation has multiple return values.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/RequestConfirmation", ReplyAction="http://tempuri.org/IService/RequestConfirmationResponse")]
        System.Threading.Tasks.Task<CRSClient.CourseConfirmService.RequestConfirmationResponse> RequestConfirmationAsync(CRSClient.CourseConfirmService.RequestConfirmationRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/MakePayment", ReplyAction="http://tempuri.org/IService/MakePaymentResponse")]
        CRSClient.CourseConfirmService.MakePaymentResponse MakePayment(CRSClient.CourseConfirmService.MakePaymentRequest request);
        
        // CODEGEN: Generating message contract since the operation has multiple return values.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/MakePayment", ReplyAction="http://tempuri.org/IService/MakePaymentResponse")]
        System.Threading.Tasks.Task<CRSClient.CourseConfirmService.MakePaymentResponse> MakePaymentAsync(CRSClient.CourseConfirmService.MakePaymentRequest request);
        
        // CODEGEN: Generating message contract since the operation ManualConfirm is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/ManualConfirm", ReplyAction="http://tempuri.org/IService/ManualConfirmResponse")]
        CRSClient.CourseConfirmService.ManualConfirmResponse ManualConfirm(CRSClient.CourseConfirmService.ManualConfirmRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/ManualConfirm", ReplyAction="http://tempuri.org/IService/ManualConfirmResponse")]
        System.Threading.Tasks.Task<CRSClient.CourseConfirmService.ManualConfirmResponse> ManualConfirmAsync(CRSClient.CourseConfirmService.ManualConfirmRequest request);
        
        // CODEGEN: Generating message contract since the operation ManualCancel is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/ManualCancel", ReplyAction="http://tempuri.org/IService/ManualCancelResponse")]
        CRSClient.CourseConfirmService.ManualCancelResponse ManualCancel(CRSClient.CourseConfirmService.ManualCancelRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/ManualCancel", ReplyAction="http://tempuri.org/IService/ManualCancelResponse")]
        System.Threading.Tasks.Task<CRSClient.CourseConfirmService.ManualCancelResponse> ManualCancelAsync(CRSClient.CourseConfirmService.ManualCancelRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="RequestConfirmation", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class RequestConfirmationRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public int classSize;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string classCode;
        
        public RequestConfirmationRequest() {
        }
        
        public RequestConfirmationRequest(int classSize, string classCode) {
            this.classSize = classSize;
            this.classCode = classCode;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="RequestConfirmationResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class RequestConfirmationResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string status;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string message;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
        public string classCode;
        
        public RequestConfirmationResponse() {
        }
        
        public RequestConfirmationResponse(string status, string message, string classCode) {
            this.status = status;
            this.message = message;
            this.classCode = classCode;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="MakePayment", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class MakePaymentRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public int classSize;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string classCode;
        
        public MakePaymentRequest() {
        }
        
        public MakePaymentRequest(int classSize, string classCode) {
            this.classSize = classSize;
            this.classCode = classCode;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="MakePaymentResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class MakePaymentResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string status;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string message;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
        public string classCode;
        
        public MakePaymentResponse() {
        }
        
        public MakePaymentResponse(string status, string message, string classCode) {
            this.status = status;
            this.message = message;
            this.classCode = classCode;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ManualConfirm", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ManualConfirmRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string classCode;
        
        public ManualConfirmRequest() {
        }
        
        public ManualConfirmRequest(string classCode) {
            this.classCode = classCode;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ManualConfirmResponse {
        
        public ManualConfirmResponse() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ManualCancel", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ManualCancelRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string classCode;
        
        public ManualCancelRequest() {
        }
        
        public ManualCancelRequest(string classCode) {
            this.classCode = classCode;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ManualCancelResponse {
        
        public ManualCancelResponse() {
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : CRSClient.CourseConfirmService.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.ClientBase<CRSClient.CourseConfirmService.IService>, CRSClient.CourseConfirmService.IService {
        
        public ServiceClient() {
        }
        
        public ServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        CRSClient.CourseConfirmService.RequestConfirmationResponse CRSClient.CourseConfirmService.IService.RequestConfirmation(CRSClient.CourseConfirmService.RequestConfirmationRequest request) {
            return base.Channel.RequestConfirmation(request);
        }
        
        public string RequestConfirmation(int classSize, ref string classCode, out string message) {
            CRSClient.CourseConfirmService.RequestConfirmationRequest inValue = new CRSClient.CourseConfirmService.RequestConfirmationRequest();
            inValue.classSize = classSize;
            inValue.classCode = classCode;
            CRSClient.CourseConfirmService.RequestConfirmationResponse retVal = ((CRSClient.CourseConfirmService.IService)(this)).RequestConfirmation(inValue);
            message = retVal.message;
            classCode = retVal.classCode;
            return retVal.status;
        }
        
        public System.Threading.Tasks.Task<CRSClient.CourseConfirmService.RequestConfirmationResponse> RequestConfirmationAsync(CRSClient.CourseConfirmService.RequestConfirmationRequest request) {
            return base.Channel.RequestConfirmationAsync(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        CRSClient.CourseConfirmService.MakePaymentResponse CRSClient.CourseConfirmService.IService.MakePayment(CRSClient.CourseConfirmService.MakePaymentRequest request) {
            return base.Channel.MakePayment(request);
        }
        
        public string MakePayment(int classSize, ref string classCode, out string message) {
            CRSClient.CourseConfirmService.MakePaymentRequest inValue = new CRSClient.CourseConfirmService.MakePaymentRequest();
            inValue.classSize = classSize;
            inValue.classCode = classCode;
            CRSClient.CourseConfirmService.MakePaymentResponse retVal = ((CRSClient.CourseConfirmService.IService)(this)).MakePayment(inValue);
            message = retVal.message;
            classCode = retVal.classCode;
            return retVal.status;
        }
        
        public System.Threading.Tasks.Task<CRSClient.CourseConfirmService.MakePaymentResponse> MakePaymentAsync(CRSClient.CourseConfirmService.MakePaymentRequest request) {
            return base.Channel.MakePaymentAsync(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        CRSClient.CourseConfirmService.ManualConfirmResponse CRSClient.CourseConfirmService.IService.ManualConfirm(CRSClient.CourseConfirmService.ManualConfirmRequest request) {
            return base.Channel.ManualConfirm(request);
        }
        
        public void ManualConfirm(string classCode) {
            CRSClient.CourseConfirmService.ManualConfirmRequest inValue = new CRSClient.CourseConfirmService.ManualConfirmRequest();
            inValue.classCode = classCode;
            CRSClient.CourseConfirmService.ManualConfirmResponse retVal = ((CRSClient.CourseConfirmService.IService)(this)).ManualConfirm(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<CRSClient.CourseConfirmService.ManualConfirmResponse> CRSClient.CourseConfirmService.IService.ManualConfirmAsync(CRSClient.CourseConfirmService.ManualConfirmRequest request) {
            return base.Channel.ManualConfirmAsync(request);
        }
        
        public System.Threading.Tasks.Task<CRSClient.CourseConfirmService.ManualConfirmResponse> ManualConfirmAsync(string classCode) {
            CRSClient.CourseConfirmService.ManualConfirmRequest inValue = new CRSClient.CourseConfirmService.ManualConfirmRequest();
            inValue.classCode = classCode;
            return ((CRSClient.CourseConfirmService.IService)(this)).ManualConfirmAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        CRSClient.CourseConfirmService.ManualCancelResponse CRSClient.CourseConfirmService.IService.ManualCancel(CRSClient.CourseConfirmService.ManualCancelRequest request) {
            return base.Channel.ManualCancel(request);
        }
        
        public void ManualCancel(string classCode) {
            CRSClient.CourseConfirmService.ManualCancelRequest inValue = new CRSClient.CourseConfirmService.ManualCancelRequest();
            inValue.classCode = classCode;
            CRSClient.CourseConfirmService.ManualCancelResponse retVal = ((CRSClient.CourseConfirmService.IService)(this)).ManualCancel(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<CRSClient.CourseConfirmService.ManualCancelResponse> CRSClient.CourseConfirmService.IService.ManualCancelAsync(CRSClient.CourseConfirmService.ManualCancelRequest request) {
            return base.Channel.ManualCancelAsync(request);
        }
        
        public System.Threading.Tasks.Task<CRSClient.CourseConfirmService.ManualCancelResponse> ManualCancelAsync(string classCode) {
            CRSClient.CourseConfirmService.ManualCancelRequest inValue = new CRSClient.CourseConfirmService.ManualCancelRequest();
            inValue.classCode = classCode;
            return ((CRSClient.CourseConfirmService.IService)(this)).ManualCancelAsync(inValue);
        }
    }
}
