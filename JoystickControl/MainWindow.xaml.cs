using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace JoystickControl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var XAxis = this.joystick.XAxis;
            var YAxis = this.joystick.YAxis;
        }
        
        
    }
}
