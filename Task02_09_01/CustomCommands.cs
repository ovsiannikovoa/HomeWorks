using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Task02_09_01
{
    internal class CustomCommands
    {
        public static RoutedUICommand ChangeColor { get; set; }
        static CustomCommands()
        {
            InputGestureCollection inputGestureCollection = new InputGestureCollection();
            inputGestureCollection.Add(new KeyGesture(Key.C, ModifierKeys.Control, "Ctrl+C"));
            ChangeColor = new RoutedUICommand("Изменить цвет", "ChangeColor", typeof(CustomCommands), inputGestureCollection);
        }
    }
}
