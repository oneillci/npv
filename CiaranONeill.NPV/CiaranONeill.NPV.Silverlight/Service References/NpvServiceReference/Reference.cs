﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.Silverlight.ServiceReference, version 5.0.61118.0
// 
namespace CiaranONeill.NPV.Silverlight.NpvServiceReference {
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="NpvRequest", Namespace="http://schemas.datacontract.org/2004/07/CiaranONeill.NPV.Calculator")]
    public partial class NpvRequest : object, System.ComponentModel.INotifyPropertyChanged {
        
        private System.Collections.ObjectModel.ObservableCollection<CiaranONeill.NPV.Silverlight.NpvServiceReference.Cashflow> CashflowsField;
        
        private double IncrementField;
        
        private double InitialInvestmentField;
        
        private double LowerRateField;
        
        private CiaranONeill.NPV.Silverlight.NpvServiceReference.RolloverType RollTypeField;
        
        private double UpperRateField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.ObjectModel.ObservableCollection<CiaranONeill.NPV.Silverlight.NpvServiceReference.Cashflow> Cashflows {
            get {
                return this.CashflowsField;
            }
            set {
                if ((object.ReferenceEquals(this.CashflowsField, value) != true)) {
                    this.CashflowsField = value;
                    this.RaisePropertyChanged("Cashflows");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Increment {
            get {
                return this.IncrementField;
            }
            set {
                if ((this.IncrementField.Equals(value) != true)) {
                    this.IncrementField = value;
                    this.RaisePropertyChanged("Increment");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double InitialInvestment {
            get {
                return this.InitialInvestmentField;
            }
            set {
                if ((this.InitialInvestmentField.Equals(value) != true)) {
                    this.InitialInvestmentField = value;
                    this.RaisePropertyChanged("InitialInvestment");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double LowerRate {
            get {
                return this.LowerRateField;
            }
            set {
                if ((this.LowerRateField.Equals(value) != true)) {
                    this.LowerRateField = value;
                    this.RaisePropertyChanged("LowerRate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public CiaranONeill.NPV.Silverlight.NpvServiceReference.RolloverType RollType {
            get {
                return this.RollTypeField;
            }
            set {
                if ((this.RollTypeField.Equals(value) != true)) {
                    this.RollTypeField = value;
                    this.RaisePropertyChanged("RollType");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double UpperRate {
            get {
                return this.UpperRateField;
            }
            set {
                if ((this.UpperRateField.Equals(value) != true)) {
                    this.UpperRateField = value;
                    this.RaisePropertyChanged("UpperRate");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Cashflow", Namespace="http://schemas.datacontract.org/2004/07/CiaranONeill.NPV.Calculator")]
    public partial class Cashflow : object, System.ComponentModel.INotifyPropertyChanged {
        
        private double AmountField;
        
        private System.DateTime PeriodField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Amount {
            get {
                return this.AmountField;
            }
            set {
                if ((this.AmountField.Equals(value) != true)) {
                    this.AmountField = value;
                    this.RaisePropertyChanged("Amount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Period {
            get {
                return this.PeriodField;
            }
            set {
                if ((this.PeriodField.Equals(value) != true)) {
                    this.PeriodField = value;
                    this.RaisePropertyChanged("Period");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RolloverType", Namespace="http://schemas.datacontract.org/2004/07/CiaranONeill.NPV.Calculator")]
    public enum RolloverType : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Annual = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Quarter = 4,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Month = 12,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="NpvResponse", Namespace="http://schemas.datacontract.org/2004/07/CiaranONeill.NPV.Calculator")]
    public partial class NpvResponse : object, System.ComponentModel.INotifyPropertyChanged {
        
        private System.Collections.ObjectModel.ObservableCollection<CiaranONeill.NPV.Silverlight.NpvServiceReference.Npv> NetPresentValuesField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.ObjectModel.ObservableCollection<CiaranONeill.NPV.Silverlight.NpvServiceReference.Npv> NetPresentValues {
            get {
                return this.NetPresentValuesField;
            }
            set {
                if ((object.ReferenceEquals(this.NetPresentValuesField, value) != true)) {
                    this.NetPresentValuesField = value;
                    this.RaisePropertyChanged("NetPresentValues");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Npv", Namespace="http://schemas.datacontract.org/2004/07/CiaranONeill.NPV.Calculator")]
    public partial class Npv : object, System.ComponentModel.INotifyPropertyChanged {
        
        private double RateField;
        
        private double ValueField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Rate {
            get {
                return this.RateField;
            }
            set {
                if ((this.RateField.Equals(value) != true)) {
                    this.RateField = value;
                    this.RaisePropertyChanged("Rate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Value {
            get {
                return this.ValueField;
            }
            set {
                if ((this.ValueField.Equals(value) != true)) {
                    this.ValueField = value;
                    this.RaisePropertyChanged("Value");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="", ConfigurationName="NpvServiceReference.NpvService")]
    public interface NpvService {
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="urn:NpvService/GetRandomData", ReplyAction="urn:NpvService/GetRandomDataResponse")]
        System.IAsyncResult BeginGetRandomData(bool loadKnownValues, System.AsyncCallback callback, object asyncState);
        
        System.Collections.ObjectModel.ObservableCollection<double> EndGetRandomData(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="urn:NpvService/CalculateNpvForNpvRequest", ReplyAction="urn:NpvService/CalculateNpvForNpvRequestResponse")]
        System.IAsyncResult BeginCalculateNpvForNpvRequest(CiaranONeill.NPV.Silverlight.NpvServiceReference.NpvRequest request, bool useXnpvFormula, System.AsyncCallback callback, object asyncState);
        
        CiaranONeill.NPV.Silverlight.NpvServiceReference.NpvResponse EndCalculateNpvForNpvRequest(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface NpvServiceChannel : CiaranONeill.NPV.Silverlight.NpvServiceReference.NpvService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetRandomDataCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetRandomDataCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public System.Collections.ObjectModel.ObservableCollection<double> Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((System.Collections.ObjectModel.ObservableCollection<double>)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CalculateNpvForNpvRequestCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public CalculateNpvForNpvRequestCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public CiaranONeill.NPV.Silverlight.NpvServiceReference.NpvResponse Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((CiaranONeill.NPV.Silverlight.NpvServiceReference.NpvResponse)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class NpvServiceClient : System.ServiceModel.ClientBase<CiaranONeill.NPV.Silverlight.NpvServiceReference.NpvService>, CiaranONeill.NPV.Silverlight.NpvServiceReference.NpvService {
        
        private BeginOperationDelegate onBeginGetRandomDataDelegate;
        
        private EndOperationDelegate onEndGetRandomDataDelegate;
        
        private System.Threading.SendOrPostCallback onGetRandomDataCompletedDelegate;
        
        private BeginOperationDelegate onBeginCalculateNpvForNpvRequestDelegate;
        
        private EndOperationDelegate onEndCalculateNpvForNpvRequestDelegate;
        
        private System.Threading.SendOrPostCallback onCalculateNpvForNpvRequestCompletedDelegate;
        
        private BeginOperationDelegate onBeginOpenDelegate;
        
        private EndOperationDelegate onEndOpenDelegate;
        
        private System.Threading.SendOrPostCallback onOpenCompletedDelegate;
        
        private BeginOperationDelegate onBeginCloseDelegate;
        
        private EndOperationDelegate onEndCloseDelegate;
        
        private System.Threading.SendOrPostCallback onCloseCompletedDelegate;
        
        public NpvServiceClient() {
        }
        
        public NpvServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public NpvServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public NpvServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public NpvServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Net.CookieContainer CookieContainer {
            get {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    return httpCookieContainerManager.CookieContainer;
                }
                else {
                    return null;
                }
            }
            set {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    httpCookieContainerManager.CookieContainer = value;
                }
                else {
                    throw new System.InvalidOperationException("Unable to set the CookieContainer. Please make sure the binding contains an HttpC" +
                            "ookieContainerBindingElement.");
                }
            }
        }
        
        public event System.EventHandler<GetRandomDataCompletedEventArgs> GetRandomDataCompleted;
        
        public event System.EventHandler<CalculateNpvForNpvRequestCompletedEventArgs> CalculateNpvForNpvRequestCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> OpenCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> CloseCompleted;
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult CiaranONeill.NPV.Silverlight.NpvServiceReference.NpvService.BeginGetRandomData(bool loadKnownValues, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetRandomData(loadKnownValues, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Collections.ObjectModel.ObservableCollection<double> CiaranONeill.NPV.Silverlight.NpvServiceReference.NpvService.EndGetRandomData(System.IAsyncResult result) {
            return base.Channel.EndGetRandomData(result);
        }
        
        private System.IAsyncResult OnBeginGetRandomData(object[] inValues, System.AsyncCallback callback, object asyncState) {
            bool loadKnownValues = ((bool)(inValues[0]));
            return ((CiaranONeill.NPV.Silverlight.NpvServiceReference.NpvService)(this)).BeginGetRandomData(loadKnownValues, callback, asyncState);
        }
        
        private object[] OnEndGetRandomData(System.IAsyncResult result) {
            System.Collections.ObjectModel.ObservableCollection<double> retVal = ((CiaranONeill.NPV.Silverlight.NpvServiceReference.NpvService)(this)).EndGetRandomData(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetRandomDataCompleted(object state) {
            if ((this.GetRandomDataCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetRandomDataCompleted(this, new GetRandomDataCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetRandomDataAsync(bool loadKnownValues) {
            this.GetRandomDataAsync(loadKnownValues, null);
        }
        
        public void GetRandomDataAsync(bool loadKnownValues, object userState) {
            if ((this.onBeginGetRandomDataDelegate == null)) {
                this.onBeginGetRandomDataDelegate = new BeginOperationDelegate(this.OnBeginGetRandomData);
            }
            if ((this.onEndGetRandomDataDelegate == null)) {
                this.onEndGetRandomDataDelegate = new EndOperationDelegate(this.OnEndGetRandomData);
            }
            if ((this.onGetRandomDataCompletedDelegate == null)) {
                this.onGetRandomDataCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetRandomDataCompleted);
            }
            base.InvokeAsync(this.onBeginGetRandomDataDelegate, new object[] {
                        loadKnownValues}, this.onEndGetRandomDataDelegate, this.onGetRandomDataCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult CiaranONeill.NPV.Silverlight.NpvServiceReference.NpvService.BeginCalculateNpvForNpvRequest(CiaranONeill.NPV.Silverlight.NpvServiceReference.NpvRequest request, bool useXnpvFormula, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginCalculateNpvForNpvRequest(request, useXnpvFormula, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        CiaranONeill.NPV.Silverlight.NpvServiceReference.NpvResponse CiaranONeill.NPV.Silverlight.NpvServiceReference.NpvService.EndCalculateNpvForNpvRequest(System.IAsyncResult result) {
            return base.Channel.EndCalculateNpvForNpvRequest(result);
        }
        
        private System.IAsyncResult OnBeginCalculateNpvForNpvRequest(object[] inValues, System.AsyncCallback callback, object asyncState) {
            CiaranONeill.NPV.Silverlight.NpvServiceReference.NpvRequest request = ((CiaranONeill.NPV.Silverlight.NpvServiceReference.NpvRequest)(inValues[0]));
            bool useXnpvFormula = ((bool)(inValues[1]));
            return ((CiaranONeill.NPV.Silverlight.NpvServiceReference.NpvService)(this)).BeginCalculateNpvForNpvRequest(request, useXnpvFormula, callback, asyncState);
        }
        
        private object[] OnEndCalculateNpvForNpvRequest(System.IAsyncResult result) {
            CiaranONeill.NPV.Silverlight.NpvServiceReference.NpvResponse retVal = ((CiaranONeill.NPV.Silverlight.NpvServiceReference.NpvService)(this)).EndCalculateNpvForNpvRequest(result);
            return new object[] {
                    retVal};
        }
        
        private void OnCalculateNpvForNpvRequestCompleted(object state) {
            if ((this.CalculateNpvForNpvRequestCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.CalculateNpvForNpvRequestCompleted(this, new CalculateNpvForNpvRequestCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void CalculateNpvForNpvRequestAsync(CiaranONeill.NPV.Silverlight.NpvServiceReference.NpvRequest request, bool useXnpvFormula) {
            this.CalculateNpvForNpvRequestAsync(request, useXnpvFormula, null);
        }
        
        public void CalculateNpvForNpvRequestAsync(CiaranONeill.NPV.Silverlight.NpvServiceReference.NpvRequest request, bool useXnpvFormula, object userState) {
            if ((this.onBeginCalculateNpvForNpvRequestDelegate == null)) {
                this.onBeginCalculateNpvForNpvRequestDelegate = new BeginOperationDelegate(this.OnBeginCalculateNpvForNpvRequest);
            }
            if ((this.onEndCalculateNpvForNpvRequestDelegate == null)) {
                this.onEndCalculateNpvForNpvRequestDelegate = new EndOperationDelegate(this.OnEndCalculateNpvForNpvRequest);
            }
            if ((this.onCalculateNpvForNpvRequestCompletedDelegate == null)) {
                this.onCalculateNpvForNpvRequestCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnCalculateNpvForNpvRequestCompleted);
            }
            base.InvokeAsync(this.onBeginCalculateNpvForNpvRequestDelegate, new object[] {
                        request,
                        useXnpvFormula}, this.onEndCalculateNpvForNpvRequestDelegate, this.onCalculateNpvForNpvRequestCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginOpen(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(callback, asyncState);
        }
        
        private object[] OnEndOpen(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndOpen(result);
            return null;
        }
        
        private void OnOpenCompleted(object state) {
            if ((this.OpenCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.OpenCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void OpenAsync() {
            this.OpenAsync(null);
        }
        
        public void OpenAsync(object userState) {
            if ((this.onBeginOpenDelegate == null)) {
                this.onBeginOpenDelegate = new BeginOperationDelegate(this.OnBeginOpen);
            }
            if ((this.onEndOpenDelegate == null)) {
                this.onEndOpenDelegate = new EndOperationDelegate(this.OnEndOpen);
            }
            if ((this.onOpenCompletedDelegate == null)) {
                this.onOpenCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnOpenCompleted);
            }
            base.InvokeAsync(this.onBeginOpenDelegate, null, this.onEndOpenDelegate, this.onOpenCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginClose(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginClose(callback, asyncState);
        }
        
        private object[] OnEndClose(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndClose(result);
            return null;
        }
        
        private void OnCloseCompleted(object state) {
            if ((this.CloseCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.CloseCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void CloseAsync() {
            this.CloseAsync(null);
        }
        
        public void CloseAsync(object userState) {
            if ((this.onBeginCloseDelegate == null)) {
                this.onBeginCloseDelegate = new BeginOperationDelegate(this.OnBeginClose);
            }
            if ((this.onEndCloseDelegate == null)) {
                this.onEndCloseDelegate = new EndOperationDelegate(this.OnEndClose);
            }
            if ((this.onCloseCompletedDelegate == null)) {
                this.onCloseCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnCloseCompleted);
            }
            base.InvokeAsync(this.onBeginCloseDelegate, null, this.onEndCloseDelegate, this.onCloseCompletedDelegate, userState);
        }
        
        protected override CiaranONeill.NPV.Silverlight.NpvServiceReference.NpvService CreateChannel() {
            return new NpvServiceClientChannel(this);
        }
        
        private class NpvServiceClientChannel : ChannelBase<CiaranONeill.NPV.Silverlight.NpvServiceReference.NpvService>, CiaranONeill.NPV.Silverlight.NpvServiceReference.NpvService {
            
            public NpvServiceClientChannel(System.ServiceModel.ClientBase<CiaranONeill.NPV.Silverlight.NpvServiceReference.NpvService> client) : 
                    base(client) {
            }
            
            public System.IAsyncResult BeginGetRandomData(bool loadKnownValues, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = loadKnownValues;
                System.IAsyncResult _result = base.BeginInvoke("GetRandomData", _args, callback, asyncState);
                return _result;
            }
            
            public System.Collections.ObjectModel.ObservableCollection<double> EndGetRandomData(System.IAsyncResult result) {
                object[] _args = new object[0];
                System.Collections.ObjectModel.ObservableCollection<double> _result = ((System.Collections.ObjectModel.ObservableCollection<double>)(base.EndInvoke("GetRandomData", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BeginCalculateNpvForNpvRequest(CiaranONeill.NPV.Silverlight.NpvServiceReference.NpvRequest request, bool useXnpvFormula, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[2];
                _args[0] = request;
                _args[1] = useXnpvFormula;
                System.IAsyncResult _result = base.BeginInvoke("CalculateNpvForNpvRequest", _args, callback, asyncState);
                return _result;
            }
            
            public CiaranONeill.NPV.Silverlight.NpvServiceReference.NpvResponse EndCalculateNpvForNpvRequest(System.IAsyncResult result) {
                object[] _args = new object[0];
                CiaranONeill.NPV.Silverlight.NpvServiceReference.NpvResponse _result = ((CiaranONeill.NPV.Silverlight.NpvServiceReference.NpvResponse)(base.EndInvoke("CalculateNpvForNpvRequest", _args, result)));
                return _result;
            }
        }
    }
}
