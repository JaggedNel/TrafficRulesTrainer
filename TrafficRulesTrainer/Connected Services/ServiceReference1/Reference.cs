﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TrafficRulesTrainer.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CompositeType", Namespace="http://schemas.datacontract.org/2004/07/WcfService1")]
    [System.SerializableAttribute()]
    public partial class CompositeType : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool BoolValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StringValueField;
        
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
        public bool BoolValue {
            get {
                return this.BoolValueField;
            }
            set {
                if ((this.BoolValueField.Equals(value) != true)) {
                    this.BoolValueField = value;
                    this.RaisePropertyChanged("BoolValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StringValue {
            get {
                return this.StringValueField;
            }
            set {
                if ((object.ReferenceEquals(this.StringValueField, value) != true)) {
                    this.StringValueField = value;
                    this.RaisePropertyChanged("StringValue");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="QuestionForm", Namespace="http://schemas.datacontract.org/2004/07/WcfService1")]
    [System.SerializableAttribute()]
    public partial class QuestionForm : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AnswerExplanationField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string[] AnswerVariantsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ImageNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int QuestionIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string QuestionTextField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int RightAnswerNumberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> SelectedVariantField;
        
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
        public string AnswerExplanation {
            get {
                return this.AnswerExplanationField;
            }
            set {
                if ((object.ReferenceEquals(this.AnswerExplanationField, value) != true)) {
                    this.AnswerExplanationField = value;
                    this.RaisePropertyChanged("AnswerExplanation");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string[] AnswerVariants {
            get {
                return this.AnswerVariantsField;
            }
            set {
                if ((object.ReferenceEquals(this.AnswerVariantsField, value) != true)) {
                    this.AnswerVariantsField = value;
                    this.RaisePropertyChanged("AnswerVariants");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ImageName {
            get {
                return this.ImageNameField;
            }
            set {
                if ((object.ReferenceEquals(this.ImageNameField, value) != true)) {
                    this.ImageNameField = value;
                    this.RaisePropertyChanged("ImageName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int QuestionID {
            get {
                return this.QuestionIDField;
            }
            set {
                if ((this.QuestionIDField.Equals(value) != true)) {
                    this.QuestionIDField = value;
                    this.RaisePropertyChanged("QuestionID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string QuestionText {
            get {
                return this.QuestionTextField;
            }
            set {
                if ((object.ReferenceEquals(this.QuestionTextField, value) != true)) {
                    this.QuestionTextField = value;
                    this.RaisePropertyChanged("QuestionText");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int RightAnswerNumber {
            get {
                return this.RightAnswerNumberField;
            }
            set {
                if ((this.RightAnswerNumberField.Equals(value) != true)) {
                    this.RightAnswerNumberField = value;
                    this.RaisePropertyChanged("RightAnswerNumber");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> SelectedVariant {
            get {
                return this.SelectedVariantField;
            }
            set {
                if ((this.SelectedVariantField.Equals(value) != true)) {
                    this.SelectedVariantField = value;
                    this.RaisePropertyChanged("SelectedVariant");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="UserData", Namespace="http://schemas.datacontract.org/2004/07/WcfService1")]
    [System.SerializableAttribute()]
    public partial class UserData : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FirstNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LastNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MiddleNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PermissionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int UserIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserNameField;
        
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
        public string FirstName {
            get {
                return this.FirstNameField;
            }
            set {
                if ((object.ReferenceEquals(this.FirstNameField, value) != true)) {
                    this.FirstNameField = value;
                    this.RaisePropertyChanged("FirstName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LastName {
            get {
                return this.LastNameField;
            }
            set {
                if ((object.ReferenceEquals(this.LastNameField, value) != true)) {
                    this.LastNameField = value;
                    this.RaisePropertyChanged("LastName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MiddleName {
            get {
                return this.MiddleNameField;
            }
            set {
                if ((object.ReferenceEquals(this.MiddleNameField, value) != true)) {
                    this.MiddleNameField = value;
                    this.RaisePropertyChanged("MiddleName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Permission {
            get {
                return this.PermissionField;
            }
            set {
                if ((this.PermissionField.Equals(value) != true)) {
                    this.PermissionField = value;
                    this.RaisePropertyChanged("Permission");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int UserID {
            get {
                return this.UserIDField;
            }
            set {
                if ((this.UserIDField.Equals(value) != true)) {
                    this.UserIDField = value;
                    this.RaisePropertyChanged("UserID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserName {
            get {
                return this.UserNameField;
            }
            set {
                if ((object.ReferenceEquals(this.UserNameField, value) != true)) {
                    this.UserNameField = value;
                    this.RaisePropertyChanged("UserName");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetData", ReplyAction="http://tempuri.org/IService1/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetData", ReplyAction="http://tempuri.org/IService1/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IService1/GetDataUsingDataContractResponse")]
        TrafficRulesTrainer.ServiceReference1.CompositeType GetDataUsingDataContract(TrafficRulesTrainer.ServiceReference1.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IService1/GetDataUsingDataContractResponse")]
        System.Threading.Tasks.Task<TrafficRulesTrainer.ServiceReference1.CompositeType> GetDataUsingDataContractAsync(TrafficRulesTrainer.ServiceReference1.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CreateQuestionForm", ReplyAction="http://tempuri.org/IService1/CreateQuestionFormResponse")]
        bool CreateQuestionForm(string imageName, string questionText, string[] answerVariants, int rightAnswerNumber, string answerExplanation);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CreateQuestionForm", ReplyAction="http://tempuri.org/IService1/CreateQuestionFormResponse")]
        System.Threading.Tasks.Task<bool> CreateQuestionFormAsync(string imageName, string questionText, string[] answerVariants, int rightAnswerNumber, string answerExplanation);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetTestQuestions", ReplyAction="http://tempuri.org/IService1/GetTestQuestionsResponse")]
        TrafficRulesTrainer.ServiceReference1.QuestionForm[] GetTestQuestions();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetTestQuestions", ReplyAction="http://tempuri.org/IService1/GetTestQuestionsResponse")]
        System.Threading.Tasks.Task<TrafficRulesTrainer.ServiceReference1.QuestionForm[]> GetTestQuestionsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/UploadImage", ReplyAction="http://tempuri.org/IService1/UploadImageResponse")]
        string UploadImage(System.IO.Stream imageStream);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/UploadImage", ReplyAction="http://tempuri.org/IService1/UploadImageResponse")]
        System.Threading.Tasks.Task<string> UploadImageAsync(System.IO.Stream imageStream);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/DownloadImage", ReplyAction="http://tempuri.org/IService1/DownloadImageResponse")]
        System.IO.Stream DownloadImage(string imageName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/DownloadImage", ReplyAction="http://tempuri.org/IService1/DownloadImageResponse")]
        System.Threading.Tasks.Task<System.IO.Stream> DownloadImageAsync(string imageName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Login", ReplyAction="http://tempuri.org/IService1/LoginResponse")]
        TrafficRulesTrainer.ServiceReference1.UserData Login(string name, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Login", ReplyAction="http://tempuri.org/IService1/LoginResponse")]
        System.Threading.Tasks.Task<TrafficRulesTrainer.ServiceReference1.UserData> LoginAsync(string name, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ExistsUserName", ReplyAction="http://tempuri.org/IService1/ExistsUserNameResponse")]
        bool ExistsUserName(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ExistsUserName", ReplyAction="http://tempuri.org/IService1/ExistsUserNameResponse")]
        System.Threading.Tasks.Task<bool> ExistsUserNameAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Registration", ReplyAction="http://tempuri.org/IService1/RegistrationResponse")]
        TrafficRulesTrainer.ServiceReference1.UserData Registration(TrafficRulesTrainer.ServiceReference1.UserData user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Registration", ReplyAction="http://tempuri.org/IService1/RegistrationResponse")]
        System.Threading.Tasks.Task<TrafficRulesTrainer.ServiceReference1.UserData> RegistrationAsync(TrafficRulesTrainer.ServiceReference1.UserData user);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : TrafficRulesTrainer.ServiceReference1.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<TrafficRulesTrainer.ServiceReference1.IService1>, TrafficRulesTrainer.ServiceReference1.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetData(int value) {
            return base.Channel.GetData(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(int value) {
            return base.Channel.GetDataAsync(value);
        }
        
        public TrafficRulesTrainer.ServiceReference1.CompositeType GetDataUsingDataContract(TrafficRulesTrainer.ServiceReference1.CompositeType composite) {
            return base.Channel.GetDataUsingDataContract(composite);
        }
        
        public System.Threading.Tasks.Task<TrafficRulesTrainer.ServiceReference1.CompositeType> GetDataUsingDataContractAsync(TrafficRulesTrainer.ServiceReference1.CompositeType composite) {
            return base.Channel.GetDataUsingDataContractAsync(composite);
        }
        
        public bool CreateQuestionForm(string imageName, string questionText, string[] answerVariants, int rightAnswerNumber, string answerExplanation) {
            return base.Channel.CreateQuestionForm(imageName, questionText, answerVariants, rightAnswerNumber, answerExplanation);
        }
        
        public System.Threading.Tasks.Task<bool> CreateQuestionFormAsync(string imageName, string questionText, string[] answerVariants, int rightAnswerNumber, string answerExplanation) {
            return base.Channel.CreateQuestionFormAsync(imageName, questionText, answerVariants, rightAnswerNumber, answerExplanation);
        }
        
        public TrafficRulesTrainer.ServiceReference1.QuestionForm[] GetTestQuestions() {
            return base.Channel.GetTestQuestions();
        }
        
        public System.Threading.Tasks.Task<TrafficRulesTrainer.ServiceReference1.QuestionForm[]> GetTestQuestionsAsync() {
            return base.Channel.GetTestQuestionsAsync();
        }
        
        public string UploadImage(System.IO.Stream imageStream) {
            return base.Channel.UploadImage(imageStream);
        }
        
        public System.Threading.Tasks.Task<string> UploadImageAsync(System.IO.Stream imageStream) {
            return base.Channel.UploadImageAsync(imageStream);
        }
        
        public System.IO.Stream DownloadImage(string imageName) {
            return base.Channel.DownloadImage(imageName);
        }
        
        public System.Threading.Tasks.Task<System.IO.Stream> DownloadImageAsync(string imageName) {
            return base.Channel.DownloadImageAsync(imageName);
        }
        
        public TrafficRulesTrainer.ServiceReference1.UserData Login(string name, string password) {
            return base.Channel.Login(name, password);
        }
        
        public System.Threading.Tasks.Task<TrafficRulesTrainer.ServiceReference1.UserData> LoginAsync(string name, string password) {
            return base.Channel.LoginAsync(name, password);
        }
        
        public bool ExistsUserName(string name) {
            return base.Channel.ExistsUserName(name);
        }
        
        public System.Threading.Tasks.Task<bool> ExistsUserNameAsync(string name) {
            return base.Channel.ExistsUserNameAsync(name);
        }
        
        public TrafficRulesTrainer.ServiceReference1.UserData Registration(TrafficRulesTrainer.ServiceReference1.UserData user) {
            return base.Channel.Registration(user);
        }
        
        public System.Threading.Tasks.Task<TrafficRulesTrainer.ServiceReference1.UserData> RegistrationAsync(TrafficRulesTrainer.ServiceReference1.UserData user) {
            return base.Channel.RegistrationAsync(user);
        }
    }
}
