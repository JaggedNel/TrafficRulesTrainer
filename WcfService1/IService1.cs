using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Windows.Media;

namespace WcfService1 {
	// ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
	[ServiceContract]
	public interface IService1 {

		[OperationContract]
		string GetData(int value);

		[OperationContract]
		CompositeType GetDataUsingDataContract(CompositeType composite);

		[OperationContract]
		bool CreateQuestionForm(string imageName, string questionText, List<string> answerVariants
			, int rightAnswerNumber, string answerExplanation);

		[OperationContract]
		List<QuestionForm> GetTestQuestions();

		[OperationContract]
		string UploadImage(Stream imageStream);

		[OperationContract]
		Stream DownloadImage(string imageName);

		[OperationContract]
		UserData Login(string name, string password);

		[OperationContract]
		bool ExistsUserName(string name);

		[OperationContract]
		UserData Registration(UserData user);

		// TODO: Добавьте здесь операции служб
	}

	[DataContract]
	public class QuestionForm {
		int questionID = 0;
		string imageName;
		string questionText;
		List<string> answerVariants = new List<string>();
		int rightAnswerNumber;
		string answerExplanation;
		int? selectedVariant = null;

		[DataMember]
		public int QuestionID {
			get { return questionID; }
			set { questionID = value; }
		}
		[DataMember]
		public string ImageName {
			get { return imageName; }
			set { imageName = value; }
		}
		[DataMember]
		public string QuestionText{
			get { return questionText; }
			set { questionText = value; }
		}
		[DataMember]
		public List<string> AnswerVariants {
			get { return answerVariants; }
			set { answerVariants = value; }
		}
		[DataMember]
		public int RightAnswerNumber {
			get { return rightAnswerNumber; }
			set { rightAnswerNumber = value; }
		}
		[DataMember]
		public string AnswerExplanation {
			get { return answerExplanation; }
			set { answerExplanation = value; }
		}
		[DataMember]
		public int? SelectedVariant {
			get { return selectedVariant; }
			set { selectedVariant = value; }
		}
	}


	// Используйте контракт данных, как показано в примере ниже, чтобы добавить составные типы к операциям служб.
	[DataContract]
	public class CompositeType {
		bool boolValue = true;
		string stringValue = "Hello ";

		[DataMember]
		public bool BoolValue {
			get { return boolValue; }
			set { boolValue = value; }
		}

		[DataMember]
		public string StringValue {
			get { return stringValue; }
			set { stringValue = value; }
		}
	}
	
	[DataContract]
	public class UserData {
		[DataMember]
		public int UserID { get; set; }
		[DataMember]
		public string UserName { get; set; }
		[DataMember]
		public string FirstName { get; set; }
		[DataMember]
		public string LastName { get; set; }
		[DataMember]
		public string MiddleName { get; set; }
		[DataMember]
		public int Permission { get; set; }
		[DataMember]
		public string Password { get; set; }
	}
}
