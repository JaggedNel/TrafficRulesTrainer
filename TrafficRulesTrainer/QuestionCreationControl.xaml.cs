using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для QuestionCreationControl.xaml
    /// </summary>
    public partial class QuestionCreationControl : UserControl {
        public QuestionCreationControl() {
            InitializeComponent();
        }

        public int SelectedAnswerVariant {
            get => AnswerVariantsList.SelectedIndex;
        }
        public int RightAnswerVariant {
            get => _rightAnswerVariant;
            set {
                ListBoxItem answerBox;
                if (_rightAnswerVariant != -1) {
                    answerBox = AnswerVariantsList.Items[_rightAnswerVariant] as ListBoxItem;
                    answerBox.Background = null;
                }

                answerBox = AnswerVariantsList.Items[SelectedAnswerVariant] as ListBoxItem;
                answerBox.Background = Brushes.LightGreen;

                _rightAnswerVariant = value;
            }
        }
        int _rightAnswerVariant = -1;

        private void AddAnswerVariant_Click(object sender, RoutedEventArgs e) {
            var newListItem = new ListBoxItem();
            newListItem.Content = new TextBox();
            AnswerVariantsList.Items.Add(newListItem);
        }
        private void RemoveAnsverVariant_Click(object sender, RoutedEventArgs e) {
            if (SelectedAnswerVariant < 0)
                return;
            else if (RightAnswerVariant == SelectedAnswerVariant)
                _rightAnswerVariant = -1;
            AnswerVariantsList.Items.RemoveAt(SelectedAnswerVariant);
        }
        private void SetRightAnswer_Click(object sender, RoutedEventArgs e) {
            RightAnswerVariant = SelectedAnswerVariant;
        }
        private void SaveQuestionBtn_Click(object sender, RoutedEventArgs e) {
            if (string.IsNullOrWhiteSpace(QuestionTextBox.Text)) {
                MessageBox.Show("Введите текст вопроса.");
                return;
            }
            if (AnswerVariantsList.Items.Count < 2) {
                MessageBox.Show("Предложите 2 или более вариантов ответа.");
                return;
            }
            if (RightAnswerVariant < 0) {
                MessageBox.Show("Отметьте правильный ответ");
                return;
            }
            List<string> variants = new List<string>();
            foreach (var i in AnswerVariantsList.Items) {
                string variant = ((i as ListBoxItem).Content as TextBox).Text;
                if (string.IsNullOrWhiteSpace(variant)) {
                    MessageBox.Show("Заполните или удалите пустое поле ответа.");
                    return;
                }
                variants.Add(variant);
            }

            //using (var client = new ServiceReference1.Service1Client()) {
            //    bool res = client.CreateQuestion(new ServiceReference1.QuestionForm(
            //        QuestionImageViewer.Source,
            //        string.IsNullOrWhiteSpace(QuestionTextBox.Text) ? null : QuestionTextBox.Text,
            //        variants,
            //        RightAnswerVariant,
            //        string.IsNullOrWhiteSpace(AnswerExplanationBox.Text) ? null : AnswerExplanationBox.Text,
            //        0
            //    ));

            //    if (res) {
            //        Clear();
            //    } else {
            //        MessageBox.Show("Не удалось создать вопрос");
            //    }
            //}


            //QuestionForm form = new QuestionForm(
            //	QuestionImageViewer.Source,
            //	string.IsNullOrWhiteSpace(QuestionTextBox.Text) ? null : QuestionTextBox.Text,
            //	variants,
            //	RightAnswerVariant,
            //	string.IsNullOrWhiteSpace(AnswerExplanationBox.Text) ? null : AnswerExplanationBox.Text,
            //	0
            //	);


            using (var client = new ServiceReference1.Service1Client()) {
                var ret = client.GetDataUsingDataContract(new ServiceReference1.CompositeType { BoolValue = true, StringValue = "aaaa" });
            }

        }

        public void Clear() {
            AnswerVariantsList.Items.Clear();
            QuestionImageViewer.Source = null;
            QuestionTextBox.Text = string.Empty;
            AnswerExplanationBox.Text = string.Empty;
        }

        private void ChooseImageBtn_Click(object sender, RoutedEventArgs e) {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = "c:\\";
            dlg.Filter = "Image files (*.jpg)|*.jpg|All Files (*.*)|*.*";
            dlg.RestoreDirectory = true;

            if (dlg.ShowDialog() == true)// == System.Windows.Forms.DialogResult.OK)
            {
                string selectedFileName = dlg.FileName;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(selectedFileName);
                bitmap.EndInit();
                QuestionImageViewer.Source = bitmap;
            }
        }

        /// <summary>
        /// Запрос дирректории файла для открытия
        /// </summary>
        public static FileInfo OpenFileDialog(string filter) {
            OpenFileDialog openFileDialog = new OpenFileDialog { Filter = filter };
            return openFileDialog.ShowDialog() == true ? new FileInfo(openFileDialog.FileName) : null;
        }
    }
}
