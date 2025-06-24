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

namespace Task02_01_02
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int _currentState = 0; // 0=Red, 1=Yellow, 2=Green

        public MainWindow()
        {
            InitializeComponent();
            ChangeColor();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            _currentState = (_currentState + 1)%3;
            ChangeColor();
        }

        private void ChangeColor()
        {
            Top.Fill = Brushes.Gray;
            Middle.Fill = Brushes.Gray;
            Bottom.Fill = Brushes.Gray;

            switch (_currentState)
            {
                case 0:
                    Top.Fill= Brushes.Red;
                    break;
                case 1:
                    Middle.Fill= Brushes.Yellow;
                    break;
                case 2:
                    Bottom.Fill= Brushes.Green;
                    break;
            }
        }
    }
}