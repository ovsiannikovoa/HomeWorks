using System;
using System.Windows;
using Task03_08_01.ViewModels;

namespace Task03_08_01.Views
{
    public partial class Task03_08_01View : Window
    {
        public Task03_08_01View(Task03_08_01ViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
            vm.CloseRequested += (s, e) => this.Close();
        }
    }
}