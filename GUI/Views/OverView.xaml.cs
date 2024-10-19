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

namespace GUI.Views
{
    /// <summary>
    /// Interaction logic for OverView.xaml
    /// </summary>
    public partial class OverView : UserControl
    {
        public OverView()
        {
            InitializeComponent();
        }

        private void Button_MouseUp_1(object sender, MouseButtonEventArgs e)
        {
            if (sender is Button button)
            {
                MessageBox.Show("MouseUp Event Triggered");
                button.Background = new SolidColorBrush(Colors.Red);
            }
        }
        private void Button_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (sender is Button button)
            {
                MessageBox.Show("MouseDown Event Triggered");
            }
        }
    }
}
