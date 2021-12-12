using System;
using System.Collections.Generic;
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
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		public MainWindow() {
			InitializeComponent();

			DataContext = ApplicationPresenter.GetInstance(this, MainGrid, MenuPanel);
			//this.Activated += MainWindow_Activated;
			this.Loaded += MainWindow_Activated;
		}

		private void MainWindow_Activated(object sender, EventArgs e) {
			Login.Open();
		}
	}

	public class ApplicationPresenter {
		public static ApplicationPresenter ViewModel { get; private set; }
		public readonly MainWindow MainWindow;
		public QuestionCreationControl questionCreationControl;
		public QuestionControl questionControl;
		public HistoryControl historyControl;
		private Button MainButton;

		Grid DataView;
		StackPanel Menu;

		public ServiceReference1.UserData User = null;

		public static ApplicationPresenter GetInstance(MainWindow window, Grid dataView, StackPanel menu) {
			return ViewModel = ViewModel ?? new ApplicationPresenter(window, dataView, menu);
		}
		ApplicationPresenter(MainWindow window, Grid dataView, StackPanel menu) {
			MainWindow = window;

			DataView = dataView;
			Menu = menu;
		}

		public void MakeMenu() {
			Button mainBtn = new Button();
			mainBtn.Content = "Главная";
			mainBtn.Click += MainBtn_Click;
			Menu.Children.Add(mainBtn);
			mainBtn.Visibility = Visibility.Hidden;
			MainButton = mainBtn;

			if (User.Permission > 0) {
				Button createQuestionBtn = new Button();
				createQuestionBtn.Content = "Создать вопрос";
				createQuestionBtn.Click += CreateQuestionBtn_Click;
				Menu.Children.Add(createQuestionBtn);
				questionCreationControl = new QuestionCreationControl();

				Button globalHistoryBtn = new Button();
				globalHistoryBtn.Content = "Поиск по истории";
				globalHistoryBtn.Click += GlobalHistory_Click;
				Menu.Children.Add(globalHistoryBtn);
				historyControl = new HistoryControl();
			}

			Button startTestBtn = new Button();
			startTestBtn.Content = "Начать тест";
			startTestBtn.Click += StartTestBtn_Click;
			Menu.Children.Add(startTestBtn);
			questionControl = new QuestionControl();

			Button myHistoryBtn = new Button();
			myHistoryBtn.Content = "Мои результаты";
			myHistoryBtn.Click += MyHistoryBtn_Click;
			Menu.Children.Add(myHistoryBtn);
		}

		DataGrid historyTable;
		private void MyHistoryBtn_Click(object sender, RoutedEventArgs e) {
			historyTable = new DataGrid();
			GridLocate(DataView, historyTable, 1, 1);
			using (var client = new ServiceReference1.Service1Client()) {
				var info = client.GetHistory(User.UserID, null, null, null, null).ToList();
				historyTable.ItemsSource = info;
			}
			historyTable.IsManipulationEnabled = false;
			historyTable.Loaded += HistoryTable_Loaded;
			MainButton.Visibility = Visibility.Visible;
		}

		private void HistoryTable_Loaded(object sender, RoutedEventArgs e) {
			int i = 0;
			while (i < historyTable.Columns.Count) {
				if (historyTable.Columns[i].Header.ToString() == "ExtensionData") {
					historyTable.Columns.RemoveAt(i);
				} else {
					i++;
				}
			}
		}

		private void GlobalHistory_Click(object sender, RoutedEventArgs e) {
			historyControl.Clear();
			GridLocate(DataView, historyControl, 1, 1);
			historyControl.HistoryTable.IsManipulationEnabled = false;
			MainButton.Visibility = Visibility.Visible;
		}

		private void MainBtn_Click(object sender, RoutedEventArgs e) {
			//if (MessageBox.Show("Вы действительно хотите покинуть страницу?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
			GoToMainPage();
		}

		private void StartTestBtn_Click(object sender, RoutedEventArgs e) {
			questionControl.Clear();
			GridLocate(DataView, questionControl, 1, 1);
			List<ServiceReference1.QuestionForm> testQuestions;
			using (var client = new ServiceReference1.Service1Client()) {
				testQuestions = client.GetTestQuestions().ToList();
			}
			questionControl.Questions = testQuestions;
			questionControl.FillQuestionForm(testQuestions[0]);
			MainButton.Visibility = Visibility.Visible;
		}

		private void CreateQuestionBtn_Click(object sender, RoutedEventArgs e) {
			questionCreationControl.Clear();
			GridLocate(DataView, questionCreationControl, 1, 1);
			MainButton.Visibility = Visibility.Visible;
		}

		public void GoToMainPage() {
			foreach (var i in DataView.Children) {
				if (Grid.GetRow(i as UIElement) == 1 && new int[] { 1, 2 }.Contains(Grid.GetColumn(i as UIElement))) {
					DataView.Children.Remove(i as UIElement);
					break;
				}
			}
			MainButton.Visibility = Visibility.Hidden;
		}

		/// <summary>
		/// Размещение графического элемента на разметке (Grid)
		/// </summary>
		public static void GridLocate(Grid grid, UIElement element, int row, int column) {
			if (grid.Children.Contains(element))
				return;
			foreach(var i in grid.Children) {
				if (Grid.GetRow(i as UIElement) == row && Grid.GetColumn(i as UIElement) == column) {
					grid.Children.Remove(i as UIElement);
					break;
				}
			}
			Grid.SetRow(element, row);
			Grid.SetColumn(element, column);
			grid.Children.Add(element);
		}
	}
}
