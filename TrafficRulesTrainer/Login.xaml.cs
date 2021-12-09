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
        }

        public static void Open() {
            Login loginWindow = new Login();
            loginWindow.Owner = ApplicationPresenter.ViewModel.MainWindow;
            loginWindow.ShowDialog();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e) {
            if (true) {
                ApplicationPresenter.ViewModel.User = new UserData(LoginBox.Text, PasswordBox.Password);
            } else {
                this.DialogResult = true;
                Close();
            }
        }
    }
}
