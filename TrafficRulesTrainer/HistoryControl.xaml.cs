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
	/// Логика взаимодействия для HistoryControl.xaml
	/// Пользовательский контрол
	/// </summary>
	public partial class HistoryControl : UserControl {
		public HistoryControl() {
			InitializeComponent();
		}

		/// <summary>
		/// Кнопка "Поиск"
		/// </summary>
		private void SearchBtn_Click(object sender, RoutedEventArgs e) {
			// Запрос истории по критериям
			using (var client = new ServiceReference1.Service1Client()) {
				var info = client.GetHistory(null, FirstNameBox.Text, LastNameBox.Text, MiddleNameBox.Text, DateTimeBox.Text).ToList();
				HistoryTable.ItemsSource = info;
			}
			// Отсечение столбцов с техничеческой информацией
			int i = 0;
			while (i < HistoryTable.Columns.Count) {
				switch (HistoryTable.Columns[i].Header.ToString()) {
					case "ExtensionData":
						HistoryTable.Columns.RemoveAt(i);
						break;
					default:
						i++;
						break;
				}
			}
		}

		/// <summary>
		/// Очистка контролов
		/// </summary>
		public void Clear() {
			FirstNameBox.Text = "";
			LastNameBox.Text = "";
			MiddleNameBox.Text = "";
			DateTimeBox.Text = "";
			HistoryTable.ItemsSource = null;
		}
	}
}
