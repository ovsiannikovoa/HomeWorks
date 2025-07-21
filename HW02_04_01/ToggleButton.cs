using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HW02_04_01
{
    public class ToggleButton : Button
    {
        public static readonly DependencyProperty IsToggledProperty =
            DependencyProperty.Register(
                nameof(IsToggled),
                typeof(bool),
                typeof(ToggleButton),
                new FrameworkPropertyMetadata(
                    false,
                    FrameworkPropertyMetadataOptions.None,
                    OnIsToggledChanged));

        public bool IsToggled
        {
            get => (bool)GetValue(IsToggledProperty);
            set => SetValue(IsToggledProperty, value);
        }

        private static void OnIsToggledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var button = (ToggleButton)d;
            button.UpdateAppearance();
        }

        private void UpdateAppearance()
        {
            Content = IsToggled ? "ON" : "OFF";
            Background = IsToggled
                ? Brushes.Green
                : Brushes.Red;
        }

        public ToggleButton()
        {
            // Инициализация внешнего вида
            UpdateAppearance();

            // Обработка клика
            Click += (sender, e) => IsToggled = !IsToggled;
        }
    }
}
