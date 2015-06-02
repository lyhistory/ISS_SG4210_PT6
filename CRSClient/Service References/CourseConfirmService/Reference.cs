﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
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
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/CancelCourseClass", ReplyAction="http://tempuri.org/IService/CancelCourseClassResponse")]
        CRSClient.CourseConfirmService.CancelCourseClassResponse CancelCourseClass(CRSClient.CourseConfirmService.CancelCourseClassRequest request);
        
        // CODEGEN: Generating message contract since the operation has multiple return values.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/CancelCourseClass", ReplyAction="http://tempuri.org/IService/CancelCourseClassResponse")]
        System.Threading.Tasks.Task<CRSClient.CourseConfirmService.CancelCourseClassResponse> CancelCourseClassAsync(CRSClient.CourseConfirmService.CancelCourseClassRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/ConfirmCourseClass", ReplyAction="http://tempuri.org/IService/ConfirmCourseClassResponse")]
        CRSClient.CourseConfirmService.ConfirmCourseClassResponse ConfirmCourseClass(CRSClient.CourseConfirmService.ConfirmCourseClassRequest request);
        
        // CODEGEN: Generating message contract since the operation has multiple return values.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/ConfirmCourseClass", ReplyAction="http://tempuri.org/IService/ConfirmCourseClassResponse")]
        System.Threading.Tasks.Task<CRSClient.CourseConfirmService.ConfirmCourseClassResponse> ConfirmCourseClassAsync(CRSClient.CourseConfirmService.ConfirmCourseClassRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/MakePayment", ReplyAction="http://tempuri.org/IService/MakePaymentResponse")]
        CRSClient.CourseConfirmService.MakePaymentResponse MakePayment(CRSClient.CourseConfirmService.MakePaymentRequest request);
        
        // CODEGEN: Generating message contract since the operation has multiple return values.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/MakePayment", ReplyAction="http://tempuri.org/IService/MakePaymentResponse")]
        System.Threading.Tasks.Task<CRSClient.CourseConfirmService.MakePaymentResponse> MakePaymentAsync(CRSClient.CourseConfirmService.MakePaymentRequest request);
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
    [System.ServiceModel.MessageContractAttribute(WrapperName="CancelCourseClass", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class CancelCourseClassRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public int classSize;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string classCode;
        
        public CancelCourseClassRequest() {
        }
        
        public CancelCourseClassRequest(int classSize, string classCode) {
            this.classSize = classSize;
            this.classCode = classCode;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="CancelCourseClassResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class CancelCourseClassResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string status;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string message;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
        public string classCode;
        
        public CancelCourseClassResponse() {
        }
        
        public CancelCourseClassResponse(string status, string message, string classCode) {
            this.status = status;
            this.message = message;
            this.classCode = classCode;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ConfirmCourseClass", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ConfirmCourseClassRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public int classSize;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string classCode;
        
        public ConfirmCourseClassRequest() {
        }
        
        public ConfirmCourseClassRequest(int classSize, string classCode) {
            this.classSize = classSize;
            this.classCode = classCode;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ConfirmCourseClassResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ConfirmCourseClassResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string status;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string message;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
        public string classCode;
        
        public ConfirmCourseClassResponse() {
        }
        
        public ConfirmCourseClassResponse(string status, string message, string classCode) {
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
        CRSClient.CourseConfirmService.CancelCourseClassResponse CRSClient.CourseConfirmService.IService.CancelCourseClass(CRSClient.CourseConfirmService.CancelCourseClassRequest request) {
            return base.Channel.CancelCourseClass(request);
        }
        
        public string CancelCourseClass(int classSize, ref string classCode, out string message) {
            CRSClient.CourseConfirmService.CancelCourseClassRequest inValue = new CRSClient.CourseConfirmService.CancelCourseClassRequest();
            inValue.classSize = classSize;
            inValue.classCode = classCode;
            CRSClient.CourseConfirmService.CancelCourseClassResponse retVal = ((CRSClient.CourseConfirmService.IService)(this)).CancelCourseClass(inValue);
            message = retVal.message;
            classCode = retVal.classCode;
            return retVal.status;
        }
        
        public System.Threading.Tasks.Task<CRSClient.CourseConfirmService.CancelCourseClassResponse> CancelCourseClassAsync(CRSClient.CourseConfirmService.CancelCourseClassRequest request) {
            return base.Channel.CancelCourseClassAsync(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        CRSClient.CourseConfirmService.ConfirmCourseClassResponse CRSClient.CourseConfirmService.IService.ConfirmCourseClass(CRSClient.CourseConfirmService.ConfirmCourseClassRequest request) {
            return base.Channel.ConfirmCourseClass(request);
        }
        
        public string ConfirmCourseClass(int classSize, ref string classCode, out string message) {
            CRSClient.CourseConfirmService.ConfirmCourseClassRequest inValue = new CRSClient.CourseConfirmService.ConfirmCourseClassRequest();
            inValue.classSize = classSize;
            inValue.classCode = classCode;
            CRSClient.CourseConfirmService.ConfirmCourseClassResponse retVal = ((CRSClient.CourseConfirmService.IService)(this)).ConfirmCourseClass(inValue);
            message = retVal.message;
            classCode = retVal.classCode;
            return retVal.status;
        }
        
        public System.Threading.Tasks.Task<CRSClient.CourseConfirmService.ConfirmCourseClassResponse> ConfirmCourseClassAsync(CRSClient.CourseConfirmService.ConfirmCourseClassRequest request) {
            return base.Channel.ConfirmCourseClassAsync(request);
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
    }
}