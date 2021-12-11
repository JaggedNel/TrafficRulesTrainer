using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Windows.Media;

namespace WcfService1 {
	// ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде, SVC-файле и файле конфигурации.
	// ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы Service1.svc или Service1.svc.cs в обозревателе решений и начните отладку.
	public class Service1 : IService1 {
		public string GetData(int value) {
			return string.Format("You entered: {0}", value);
		}

		public CompositeType GetDataUsingDataContract(CompositeType composite) {
			if (composite == null) {
				throw new ArgumentNullException("composite");
			}
			if (composite.BoolValue) {
				composite.StringValue += "Suffix";
			}
			return composite;
		}

		public bool CreateQuestionForm(string imageName, string questionText
			, List<string> answerVariants, int rightAnswerNumber, string answerExplanation) {
			bool success = true;
			using (SqlConnection conn = DBUtils.GetDBConnection()) {
				try {
					conn.Open();

					string sql = 
						$"INSERT INTO Questions (QuestionText, RightAnswerNumber, AnswerExplanation, ImageSourcePath) " +
						$"VALUES ('{questionText}', {rightAnswerNumber}, '{answerExplanation}', {(string.IsNullOrEmpty(imageName) ? "NULL" : $"'{imageName}'" )}) " +
						$"DECLARE @QID int SET @QID = (SELECT MAX(QuestionID) FROM Questions) " +
						$"INSERT INTO AnswerVariants (QuestionID, AnswerText) " +
						$"VALUES {string.Join(", ", answerVariants.Select(x => $"(@QID, '{x}')"))}";

					Log("Query: " + sql);

					SqlCommand cmd = new SqlCommand(sql, conn);

					int rowCount = cmd.ExecuteNonQuery();
				} catch (Exception e) {
					Log("Error: " + e.Message);
					success &= false;
				} finally {
					if (conn.State == System.Data.ConnectionState.Open)
						conn.Close();
				}
			}
			return success;
		}

		public void templateDo() {
			bool success = true;
			using (SqlConnection conn = DBUtils.GetDBConnection()) {
				try {
					conn.Open();

					string sql = "";

					SqlCommand cmd = new SqlCommand(sql, conn);

					int rowCount = cmd.ExecuteNonQuery();
				} catch (Exception e) {
					Console.WriteLine("Error: " + e.Message);
					success &= false;
				} finally {
					if (conn.State == System.Data.ConnectionState.Open)
						conn.Close();
				}
			}
			//return success;
		}

		public void templateRead() {
			bool success = true;
			using (SqlConnection conn = DBUtils.GetDBConnection()) {
				try {
					conn.Open();

					string sql = "";

					SqlCommand cmd = new SqlCommand(sql, conn);

					using (DbDataReader reader = cmd.ExecuteReader()) {
						if (reader.HasRows) {
							while (reader.Read()) {
								//индекс столбца
								int empId = reader.GetOrdinal("EmpId");
								string empName = reader.GetString(empId).ToString();

								if (!reader.IsDBNull(1)) { }
							}
						}
					}
				} catch (Exception e) {
					Console.WriteLine("Error: " + e.Message);
					success &= false;
				} finally {
					if (conn.State == System.Data.ConnectionState.Open)
						conn.Close();
				}
			}
			//return success;
		}

		public const string FILES_DIRECTORY = @"D:\University\Images\{0}.jpg";
		public string UploadImage(Stream imageStream) {
			var image = Bitmap.FromStream(imageStream);
			string name = $"{DateTime.Now.ToString("yy.MM.dd")}_{image.GetHashCode()}";
			image.Save(string.Format(FILES_DIRECTORY, name));
			return name;
		}

		public Stream DownloadImage(string imageName) {
			FileInfo f = new FileInfo(string.Format(FILES_DIRECTORY, imageName));
			return f.OpenRead();
		}

		public void Log(string message) {
			string log = $"{DateTime.Now} - {message}\n";
			File.AppendAllText(@"D:\University\service.log", log);
		}

		const int TEST_QUESTIONS_COUNT = 5;
		public List<QuestionForm> GetTestQuestions() {
			List<QuestionForm> test = new List<QuestionForm>();
			using (SqlConnection conn = DBUtils.GetDBConnection()) {
				try {
					conn.Open();

					string sql = 
						"SELECT * " +
						$"FROM (SELECT TOP {TEST_QUESTIONS_COUNT} * FROM Questions ORDER BY NEWID()) AS Questions " +
						"LEFT JOIN AnswerVariants ON AnswerVariants.QuestionID = Questions.QuestionID";

					// Получена таблица вопросов и вариантов
					SqlCommand cmd = new SqlCommand(sql, conn);

					using (DbDataReader reader = cmd.ExecuteReader()) {
						if (reader.HasRows) {
							List<string> columns = new List<string> { "QuestionID", "QuestionText",
									"RightAnswerNumber", "AnswerExplanation", "ImageSourcePath", "AnswerText" };

							QuestionForm form = null;
							while (reader.Read()) {
								int questionId = reader.GetInt32(0);
								if (questionId != (form?.QuestionID ?? 0)) {
									form = new QuestionForm {
										QuestionID = questionId,
										QuestionText = reader.GetString(1),
										RightAnswerNumber = reader.GetInt32(2),
										AnswerExplanation = reader.GetString(3),
										ImageName = reader.IsDBNull(4) ? null : reader.GetString(4)
									};
									test.Add(form);
								}
								form.AnswerVariants.Add(reader.GetString(7));
							}
						}
					}
				} catch (Exception e) {
					Console.WriteLine("Error: " + e.Message);
				} finally {
					if (conn.State == System.Data.ConnectionState.Open)
						conn.Close();
				}
			}
			return test;
		}

		public UserData Login(string name, string password) {
			UserData user = null;
			using (SqlConnection conn = DBUtils.GetDBConnection()) {
				try {
					conn.Open();

					string sql = $"SELECT * FROM Users WHERE UserName = '{name}' AND Password = '{password}'";

					SqlCommand cmd = new SqlCommand(sql, conn);

					using (DbDataReader reader = cmd.ExecuteReader()) {
						if (reader.HasRows) {
							reader.Read();
							user = new UserData {
								UserID = reader.GetInt32(0),
								UserName = reader.GetString(1),
								FirstName = reader.IsDBNull(2) ? "" : reader.GetString(2),
								LastName = reader.IsDBNull(3) ? "" : reader.GetString(3),
								MiddleName = reader.IsDBNull(4) ? "" : reader.GetString(4),
								Password = reader.GetString(5),
								Permission = reader.GetInt32(6)
							};
						}
					}
				} catch (Exception e) {
					Console.WriteLine("Error: " + e.Message);
				} finally {
					if (conn.State == System.Data.ConnectionState.Open)
						conn.Close();
				}
			}
			return user;
		}

		/// <returns>True если уже есть такой пользователь</returns>
		public bool ExistsUserName(string name) {
			bool exists = true;
			using (SqlConnection conn = DBUtils.GetDBConnection()) {
				try {
					conn.Open();

					string sql = $"SELECT * FROM Users WHERE UserName = '{name}'";

					SqlCommand cmd = new SqlCommand(sql, conn);

					using (DbDataReader reader = cmd.ExecuteReader()) {
						exists = reader.HasRows;
					}
				} catch (Exception e) {
					Console.WriteLine("Error: " + e.Message);
				} finally {
					if (conn.State == System.Data.ConnectionState.Open)
						conn.Close();
				}
			}
			return exists;
		}

		public UserData Registration(UserData user) {
			if (ExistsUserName(user.UserName))
				return null;

			using (SqlConnection conn = DBUtils.GetDBConnection()) {
				try {
					conn.Open();

					string sql = 
						"INSERT INTO [dbo].[Users] ([UserName], [FirstName], [SecondName], [MiddleName], [Password]) " +
						$"VALUES ('{user.UserName}', {(string.IsNullOrEmpty(user.FirstName) ? "NULL" : $"'{user.FirstName}'")}, " +
							$"{(string.IsNullOrEmpty(user.LastName) ? "NULL" : $"'{user.LastName}'")}, " +
							$"{(string.IsNullOrEmpty(user.MiddleName) ? "NULL" : $"'{user.MiddleName}'")}, '{user.Password}')";

					SqlCommand cmd = new SqlCommand(sql, conn);

					int rowCount = cmd.ExecuteNonQuery();
				} catch (Exception e) {
					Console.WriteLine("Error: " + e.Message);
					return null;
				} finally {
					if (conn.State == System.Data.ConnectionState.Open)
						conn.Close();
				}
			}

			return Login(user.UserName, user.Password);
		}
	}
}
