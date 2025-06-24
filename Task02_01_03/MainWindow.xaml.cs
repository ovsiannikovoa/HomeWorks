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

namespace Task02_01_03
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
            SetRandomButtonPosition();
        }

        private void EvadeButton_MouseEnter(object sender, MouseEventArgs e)
        {
            SetRandomButtonPosition();
        }

        private void SetRandomButtonPosition()
        {
            if (MainGrid.ActualWidth == 0 || MainGrid.ActualHeight == 0)
                return;

            // Учитываем размеры кнопки при расчетах
            double buttonWidth = CatchMe.ActualWidth;
            double buttonHeight = CatchMe.ActualHeight;

            // Вычисляем доступные размеры области
            double maxX = MainGrid.ActualWidth - buttonWidth;
            double maxY = MainGrid.ActualHeight - buttonHeight;

            // Генерируем случайные координаты в пределах окна
            double newX = random.NextDouble() * maxX;
            double newY = random.NextDouble() * maxY;

            // Устанавливаем новую позицию кнопки
            CatchMe.Margin = new Thickness(newX, newY, 0, 0);
        }
    }
}