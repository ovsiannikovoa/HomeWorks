using System.Collections.ObjectModel;
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

namespace Task02_08_01
{
    public enum Category
    {
        Food,
        Appliances
    }

    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string ImagePath { get; set; }
        public Category Category { get; set; }
    }

    public partial class MainWindow : Window
    {
        public ObservableCollection<Product> Products { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Products = new ObservableCollection<Product>
            {
                new Product {
                    Name = "Яблоки",
                    Price = 299.99,
                    ImagePath = "C:\\Users\\ovsiannikovoa\\Desktop\\Курс C#\\repos\\HomeWorks\\Task02_08_01\\images\\apple.png",
                    Category = Category.Food
                },
                new Product {
                    Name = "Холодильник",
                    Price = 59999.99,
                    ImagePath = "C:\\Users\\ovsiannikovoa\\Desktop\\Курс C#\\repos\\HomeWorks\\Task02_08_01\\images\\fridge.png",
                    Category = Category.Appliances
                },
                new Product {
                    Name = "Бананы",
                    Price = 199.49,
                    ImagePath = "C:\\Users\\ovsiannikovoa\\Desktop\\Курс C#\\repos\\HomeWorks\\Task02_08_01\\images\\bananas.png",
                    Category = Category.Food
                }
            };
            lstBox.ItemsSource = Products;
        }
    }
}