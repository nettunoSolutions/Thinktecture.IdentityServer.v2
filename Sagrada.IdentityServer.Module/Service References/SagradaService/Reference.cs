﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18034
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sagrada.IdentityServer.Module.SagradaService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="IdentityCompany", Namespace="http://schemas.datacontract.org/2004/07/Sagrada.Web.Services.Identity")]
    [System.SerializableAttribute()]
    internal partial class IdentityCompany : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid IdField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        internal string Description {
            get {
                return this.DescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescriptionField, value) != true)) {
                    this.DescriptionField = value;
                    this.RaisePropertyChanged("Description");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        internal System.Guid Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="IdentityProfile", Namespace="http://schemas.datacontract.org/2004/07/Sagrada.Web.Services.Identity")]
    [System.SerializableAttribute()]
    internal partial class IdentityProfile : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsDefaultField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        internal string Description {
            get {
                return this.DescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescriptionField, value) != true)) {
                    this.DescriptionField = value;
                    this.RaisePropertyChanged("Description");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        internal System.Guid Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        internal bool IsDefault {
            get {
                return this.IsDefaultField;
            }
            set {
                if ((this.IsDefaultField.Equals(value) != true)) {
                    this.IsDefaultField = value;
                    this.RaisePropertyChanged("IsDefault");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="IdentityLanguage", Namespace="http://schemas.datacontract.org/2004/07/Sagrada.Web.Services.Identity")]
    [System.SerializableAttribute()]
    internal partial class IdentityLanguage : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DisplayNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        internal string DisplayName {
            get {
                return this.DisplayNameField;
            }
            set {
                if ((object.ReferenceEquals(this.DisplayNameField, value) != true)) {
                    this.DisplayNameField = value;
                    this.RaisePropertyChanged("DisplayName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        internal string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SagradaService.IIdentityUserService")]
    internal interface IIdentityUserService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IIdentityUserService/GetCompanies", ReplyAction="http://tempuri.org/IIdentityUserService/GetCompaniesResponse")]
        Sagrada.IdentityServer.Module.SagradaService.IdentityCompany[] GetCompanies();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IIdentityUserService/GetCompanies", ReplyAction="http://tempuri.org/IIdentityUserService/GetCompaniesResponse")]
        System.Threading.Tasks.Task<Sagrada.IdentityServer.Module.SagradaService.IdentityCompany[]> GetCompaniesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IIdentityUserService/GetRoles", ReplyAction="http://tempuri.org/IIdentityUserService/GetRolesResponse")]
        string[] GetRoles(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IIdentityUserService/GetRoles", ReplyAction="http://tempuri.org/IIdentityUserService/GetRolesResponse")]
        System.Threading.Tasks.Task<string[]> GetRolesAsync(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IIdentityUserService/GetProfiles", ReplyAction="http://tempuri.org/IIdentityUserService/GetProfilesResponse")]
        Sagrada.IdentityServer.Module.SagradaService.IdentityProfile[] GetProfiles(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IIdentityUserService/GetProfiles", ReplyAction="http://tempuri.org/IIdentityUserService/GetProfilesResponse")]
        System.Threading.Tasks.Task<Sagrada.IdentityServer.Module.SagradaService.IdentityProfile[]> GetProfilesAsync(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IIdentityUserService/GetLanguages", ReplyAction="http://tempuri.org/IIdentityUserService/GetLanguagesResponse")]
        Sagrada.IdentityServer.Module.SagradaService.IdentityLanguage[] GetLanguages();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IIdentityUserService/GetLanguages", ReplyAction="http://tempuri.org/IIdentityUserService/GetLanguagesResponse")]
        System.Threading.Tasks.Task<Sagrada.IdentityServer.Module.SagradaService.IdentityLanguage[]> GetLanguagesAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    internal interface IIdentityUserServiceChannel : Sagrada.IdentityServer.Module.SagradaService.IIdentityUserService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    internal partial class IdentityUserServiceClient : System.ServiceModel.ClientBase<Sagrada.IdentityServer.Module.SagradaService.IIdentityUserService>, Sagrada.IdentityServer.Module.SagradaService.IIdentityUserService {
        
        public IdentityUserServiceClient() {
        }
        
        public IdentityUserServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public IdentityUserServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IdentityUserServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IdentityUserServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Sagrada.IdentityServer.Module.SagradaService.IdentityCompany[] GetCompanies() {
            return base.Channel.GetCompanies();
        }
        
        public System.Threading.Tasks.Task<Sagrada.IdentityServer.Module.SagradaService.IdentityCompany[]> GetCompaniesAsync() {
            return base.Channel.GetCompaniesAsync();
        }
        
        public string[] GetRoles(string userName) {
            return base.Channel.GetRoles(userName);
        }
        
        public System.Threading.Tasks.Task<string[]> GetRolesAsync(string userName) {
            return base.Channel.GetRolesAsync(userName);
        }
        
        public Sagrada.IdentityServer.Module.SagradaService.IdentityProfile[] GetProfiles(string userName) {
            return base.Channel.GetProfiles(userName);
        }
        
        public System.Threading.Tasks.Task<Sagrada.IdentityServer.Module.SagradaService.IdentityProfile[]> GetProfilesAsync(string userName) {
            return base.Channel.GetProfilesAsync(userName);
        }
        
        public Sagrada.IdentityServer.Module.SagradaService.IdentityLanguage[] GetLanguages() {
            return base.Channel.GetLanguages();
        }
        
        public System.Threading.Tasks.Task<Sagrada.IdentityServer.Module.SagradaService.IdentityLanguage[]> GetLanguagesAsync() {
            return base.Channel.GetLanguagesAsync();
        }
    }
}
