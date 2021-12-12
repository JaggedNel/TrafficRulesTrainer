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

		/// <summary>
		/// Создание нового вопроса
		/// </summary>
		/// <param name="imageName">Название файла</param>
		/// <param name="questionText">Текст вопроса</param>
		/// <param name="answerVariants">Варианты ответа</param>
		/// <param name="rightAnswerNumber">Номер правильного ответа</param>
		/// <param name="answerExplanation">Объяснение ответа</param>
		/// <returns>True если вопрос создан</returns>
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

		/// <summary>
		/// Путь хранения картинок вопросов
		/// </summary>
		public const string FILES_DIRECTORY = @"D:\University\Images\{0}.jpg";
		/// <summary>
		/// Загрузка изображения на сервер
		/// </summary>
		/// <param name="imageStream">Поток с изображением</param>
		/// <returns>Название файла на сервере</returns>
		public string UploadImage(Stream imageStream) {
			var image = Bitmap.FromStream(imageStream);
			string name = $"{DateTime.Now.ToString("yy.MM.dd")}_{image.GetHashCode()}";
			image.Save(string.Format(FILES_DIRECTORY, name));
			return name;
		}

		/// <summary>
		/// Загрузка изображения с сервера
		/// </summary>
		/// <param name="imageName">Название изображения</param>
		/// <returns>Поток с изображением</returns>
		public Stream DownloadImage(string imageName) {
			FileInfo f = new FileInfo(string.Format(FILES_DIRECTORY, imageName));
			return f.OpenRead();
		}

		/// <summary>
		/// Логирование
		/// </summary>
		/// <param name="message">Сообщение лога</param>
		public void Log(string message) {
			string log = $"{DateTime.Now} - {message}\n";
			File.AppendAllText(@"D:\University\service.log", log);
		}

		/// <summary>
		/// Количество вопросов в тестах
		/// </summary>
		const int TEST_QUESTIONS_COUNT = 5;
		/// <summary>
		/// Запрос вопросов теста
		/// </summary>
		/// <returns>Список вопросов</returns>
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
					Log("Error: " + e.Message);
				} finally {
					if (conn.State == System.Data.ConnectionState.Open)
						conn.Close();
				}
			}
			return test;
		}

		/// <summary>
		/// Авторизация
		/// </summary>
		/// <param name="name">Имя пользователя</param>
		/// <param name="password">Пароль</param>
		/// <returns>Пользовательская сессия</returns>
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
					Log("Error: " + e.Message);
				} finally {
					if (conn.State == System.Data.ConnectionState.Open)
						conn.Close();
				}
			}
			return user;
		}

		/// <summary>
		/// Проверка занятости имени пользователя
		/// </summary>
		/// <param name="name">Имя пользователя</param>
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
					Log("Error: " + e.Message);
				} finally {
					if (conn.State == System.Data.ConnectionState.Open)
						conn.Close();
				}
			}
			return exists;
		}

		/// <summary>
		/// Регистрация нового пользователя
		/// </summary>
		/// <param name="user">Параметры создаваемого пользователя</param>
		/// <returns>Пользовательская сессия</returns>
		public UserData Registration(UserData user) {
			if (ExistsUserName(user.UserName))
				return null;

			using (SqlConnection conn = DBUtils.GetDBConnection()) {
				try {
					conn.Open();

					string sql = 
						"INSERT INTO [dbo].[Users] ([UserName], [FirstName], [LastName], [MiddleName], [Password]) " +
						$"VALUES ('{user.UserName}', {(string.IsNullOrEmpty(user.FirstName) ? "NULL" : $"'{user.FirstName}'")}, " +
							$"{(string.IsNullOrEmpty(user.LastName) ? "NULL" : $"'{user.LastName}'")}, " +
							$"{(string.IsNullOrEmpty(user.MiddleName) ? "NULL" : $"'{user.MiddleName}'")}, '{user.Password}')";

					SqlCommand cmd = new SqlCommand(sql, conn);

					int rowCount = cmd.ExecuteNonQuery();
				} catch (Exception e) {
					Log("Error: " + e.Message);
					return null;
				} finally {
					if (conn.State == System.Data.ConnectionState.Open)
						conn.Close();
				}
			}

			return Login(user.UserName, user.Password);
		}

		/// <summary>
		/// Фиксация результатов теста
		/// </summary>
		/// <param name="result">Список вопросов с результатами</param>
		public void TestCompleted(TestResult result) {
			using (SqlConnection conn = DBUtils.GetDBConnection()) {
				try {
					conn.Open();

					string sql = "INSERT INTO [dbo].[TestHistory] ([UserID], [RightAnswersCount], [QuestionsCount], [DateTime]) " +
						$"VALUES ({result.UserID}, {result.RightAnswers}, {result.QuestionsCount}, GETDATE())";

					SqlCommand cmd = new SqlCommand(sql, conn);

					int rowCount = cmd.ExecuteNonQuery();
				} catch (Exception e) {
					Log("Error: " + e.Message);
				} finally {
					if (conn.State == System.Data.ConnectionState.Open)
						conn.Close();
				}
			}
		}

		/// <summary>
		/// Запрос истории прохождения тестов
		/// </summary>
		/// <param name="userID">Номер конкретного пользователя</param>
		/// <param name="firstName">Поиск по имени</param>
		/// <param name="lastName">Поиск по фамилии</param>
		/// <param name="middleName">Поиск по отчеству</param>
		/// <param name="dateTime">Поиск по дате прохождения</param>
		/// <returns>История прохождений удовлетворяющих критериям</returns>
		public List<TestResult> GetHistory(int? userID, string firstName = null, string lastName = null, string middleName = null, string dateTime = null) {
			List<TestResult> history = new List<TestResult>();
			using (SqlConnection conn = DBUtils.GetDBConnection()) {
				try {
					conn.Open();

					List<string> where;
					if (userID.HasValue && userID != 0)
						where = new List<string> { $"History.UserID = {userID}"	};
					else {
						where = new List<string>();
						if (!string.IsNullOrWhiteSpace(firstName))
							where.Add($"Users.FirstName = '{firstName}'");
						if (!string.IsNullOrWhiteSpace(lastName))
							where.Add($"Users.LastName = '{lastName}'");
						if (!string.IsNullOrWhiteSpace(middleName))
							where.Add($"Users.MiddleName = '{middleName}'");
						if (!string.IsNullOrWhiteSpace(dateTime))
							where.Add($"History.[DateTime] LIKE '{dateTime}'");
					}

					string sql =
						"SELECT * " +
						"FROM [dbo].[TestHistory] AS History " +
						"LEFT JOIN[dbo].[Users] AS Users ON Users.UserID = History.UserID" +
						$"{(where.Any() ? $" WHERE {string.Join(" AND ", where)}" : "")}";

					SqlCommand cmd = new SqlCommand(sql, conn);

					using (DbDataReader reader = cmd.ExecuteReader()) {
						if (reader.HasRows) {
							while (reader.Read()) {
								history.Add(new TestResult {
									UserID = reader.GetInt32(1),
									RightAnswers = reader.GetInt32(2),
									QuestionsCount = reader.GetInt32(3),
									@DateTime = reader.GetDateTime(4).ToString(),
									FirstName = reader.GetString(6),
									LastName = reader.GetString(7),
									MiddleName = reader.GetString(8)
								});
							}
						}
					}
				} catch (Exception e) {
					Log("Error: " + e.Message);
				} finally {
					if (conn.State == System.Data.ConnectionState.Open)
						conn.Close();
				}
			}
			return history;
		}
	}
}
