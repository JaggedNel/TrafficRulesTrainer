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
using System.Windows.Shapes;

namespace TrafficRulesTrainer {
	/// <summary>
	/// Логика взаимодействия для Login.xaml
	/// </summary>
	public partial class Login : Window {
		public Login() {
			InitializeComponent();
			this.Closed += Login_Closed;
		}

		private void Login_Closed(object sender, EventArgs e) {
			if (ApplicationPresenter.ViewModel.User == null)
				ApplicationPresenter.ViewModel.MainWindow.Close();
		}

		bool regMode = false; //false -вход , true -регистрация

		public static void Open() {
			Login loginWindow = new Login();
			loginWindow.Owner = ApplicationPresenter.ViewModel.MainWindow;
			loginWindow.ShowDialog();
		}

		private void LoginBtn_Click(object sender, RoutedEventArgs e) {
			if (!regMode) {
				if (string.IsNullOrWhiteSpace(LoginBox.Text) || string.IsNullOrWhiteSpace(PasswordBox.Password)) {
					MessageBox.Show("Введите логин и пароль.");
					return;
				}
				using (var client = new ServiceReference1.Service1Client()) {
					ServiceReference1.UserData user = client.Login(LoginBox.Text, PasswordBox.Password);

					if (user != null) {
						ApplicationPresenter.ViewModel.User = user;
						this.DialogResult = true;
						ApplicationPresenter.ViewModel.MakeMenu();
						Close();
					} else {
						MessageBox.Show("Неверное имя пользователя или пароль.");
					}
				}
			} else {
				regMode = false;
				RepeatPasswordBox.Visibility = RepeatPasswordLabel.Visibility = Visibility.Hidden;
			}
		}

		private void RegistrationBtn_Click(object sender, RoutedEventArgs e) {
			if (regMode) {
				if (string.IsNullOrWhiteSpace(LoginBox.Text) || string.IsNullOrWhiteSpace(PasswordBox.Password)) {
					MessageBox.Show("Введите логин и пароль.");
					return;
				}
				if (PasswordBox.Password != RepeatPasswordBox.Password) {
					MessageBox.Show("Введённые пароли не совпадают.");
					return;
				}
				using (var client = new ServiceReference1.Service1Client()) {
					if (client.ExistsUserName(LoginBox.Text)) {
						MessageBox.Show("Пользователь с таким имененм уже существует.");
						return;
					}
					var user = client.Registration(new ServiceReference1.UserData { UserName = LoginBox.Text, Password = PasswordBox.Password });
					if (user == null) {
						MessageBox.Show("Регистрация не удалась.");
						return;
					} else {
						ApplicationPresenter.ViewModel.User = user;
						this.DialogResult = true;
						Close();
					}
				}
			} else {
				regMode = true;
				RepeatPasswordBox.Visibility = RepeatPasswordLabel.Visibility = Visibility.Visible;
			}
		}
	}
}
