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

        }

        public bool TryLogin() {
            Login.Open();

            return true;
        }
    }

    public class ApplicationPresenter {
        public static ApplicationPresenter ViewModel { get; private set; }
        public readonly MainWindow MainWindow;
        public QuestionCreationControl questionCreationControl;

        Grid DataView;
        StackPanel Menu;

        public UserData User;

        public static ApplicationPresenter GetInstance(MainWindow window, Grid dataView, StackPanel menu) {
            return ViewModel = ViewModel ?? new ApplicationPresenter(window, dataView, menu);
        }
        ApplicationPresenter(MainWindow window, Grid dataView, StackPanel menu) {
            MainWindow = window;

            DataView = dataView;
            Menu = menu;

            Button createQuestionBtn = new Button();
            createQuestionBtn.Content = "Создать вопрос";
            createQuestionBtn.Click += CreateQuestionBtn_Click;
            questionCreationControl = new QuestionCreationControl();



            Menu.Children.Add(createQuestionBtn);
        }

        private void CreateQuestionBtn_Click(object sender, RoutedEventArgs e) {
            questionCreationControl.Clear();
            GridLocate(DataView, questionCreationControl, 1, 1);
        }

        /// <summary>
        /// Размещение графического элемента на разметке (Grid)
        /// </summary>
        public static void GridLocate(Grid grid, UIElement element, int row, int column) {
            if (grid.Children.Contains(element))
                return;
            if (row >= 0)
                Grid.SetRow(element, row);
            if (column >= 0)
                Grid.SetColumn(element, column);
            grid.Children.Add(element);
        }
    }
}
