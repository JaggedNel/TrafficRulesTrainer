using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TrafficRulesTrainer {
	/// <summary>
	/// Логика взаимодействия для QuestionControl.xaml
	/// </summary>
	public partial class QuestionControl : UserControl {
		public QuestionControl() {
			InitializeComponent();
		}

		public List<ServiceReference1.QuestionForm> Questions;
		int currentQuestion = 0;
		public ServiceReference1.QuestionForm CurrentQuestion {
			get => Questions[currentQuestion];
		}

		public int SelectedAnswerVariant {
			get => AnswerVariantsList.SelectedIndex;
		}

		public void Clear() {
			QuestionImageViewer.Source = null;
			QuestionTextLabel.Text = "";
			AnswerVariantsList.Items.Clear();
			AnswerExplanationLabel.Text = "";
		}

		public void FillQuestionForm(ServiceReference1.QuestionForm form) {
			Clear();

			// Загрузка изображения
			if (form.ImageName != null) {
				using (var client = new ServiceReference1.Service1Client()) {
					Stream imageStream = client.DownloadImage(form.ImageName);

					var imgSource = new BitmapImage();
					imgSource.BeginInit();
					imgSource.UriSource = null;
					imgSource.CacheOption = BitmapCacheOption.OnLoad;
					imgSource.StreamSource = imageStream;
					imgSource.EndInit();

					QuestionImageViewer.Source = imgSource;
				}
			}

			QuestionTextLabel.Text = form.QuestionText;
			FillAnswerVariants(form.AnswerVariants.ToList());
		}

		void FillAnswerVariants(List<string> variants) {
			foreach (var i in variants)
				AnswerVariantsList.Items.Add(new ListBoxItem() { Content = i });
		}

		/// <summary>
		/// Кнопка "Ответить"
		/// </summary>
		private void AnswerButton_Click(object sender, RoutedEventArgs e) {
			if (SelectedAnswerVariant == -1) {
				MessageBox.Show("Выбирите вариант ответа.");
				return;
			}
			if (!CurrentQuestion.SelectedVariant.HasValue)
				CurrentQuestion.SelectedVariant = SelectedAnswerVariant;
			(AnswerVariantsList.Items[SelectedAnswerVariant] as ListBoxItem).Background
				= SelectedAnswerVariant == CurrentQuestion.RightAnswerNumber
				? System.Windows.Media.Brushes.LightGreen : System.Windows.Media.Brushes.LightCoral;
			AnswerVariantsList.SelectedIndex = -1;
			AnswerExplanationLabel.Text = CurrentQuestion.AnswerExplanation;
		}
		/// <summary>
		/// Кнопка "Далее"
		/// </summary>
		private void NextButton_Click(object sender, RoutedEventArgs e) {
			if (!CurrentQuestion.SelectedVariant.HasValue) {
				MessageBox.Show("Выбирите вариант ответа.");
				return;
			}
			if (++currentQuestion >= Questions.Count) {
				int rightAnswersCount = Questions.Where(x => x.RightAnswerNumber == x.SelectedVariant).Count();
				MessageBox.Show($"Ваш результат: {rightAnswersCount}/{Questions.Count}");
				using (var client = new ServiceReference1.Service1Client()) {
					client.TestCompleted(new ServiceReference1.TestResult {
						Номер = ApplicationPresenter.ViewModel.User.UserID,
						Правильных = rightAnswersCount,
						Всего = Questions.Count
					});
				}
				currentQuestion = 0;
				ApplicationPresenter.ViewModel.GoToMainPage();
			} else {
				FillQuestionForm(CurrentQuestion);
			}
		}
	}
}
