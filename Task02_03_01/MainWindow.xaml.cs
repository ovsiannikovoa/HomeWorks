using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Task02_03_01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckBox.IsChecked == true)
            {
                MessageBox.Show("Ошибка: необходимо согласиться обработку персональных данных!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var selectedCourses = Courses.SelectedItems
                .Cast<ListBoxItem>()
                .Select(item => item.Content.ToString())
                .ToList();

            string message = $"Профиль сохранен!\n\n" +
                             $"Имя: {UserName.Text}\n" +
                             $"Факультет: {Faculty.Text}\n" +
                             $"Выбранные курсы: {string.Join(", ", selectedCourses)}\n" +
                             $"Согласие на рассылку: {(CheckBox.IsChecked == true ? "Да" : "Нет")}";

            MessageBox.Show(message, "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}