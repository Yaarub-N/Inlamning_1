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
    /// Interaction logic for EditeView.xaml
    /// </summary>
    public partial class EditView : UserControl
    {
        public EditView()
        {
            InitializeComponent();
        }

        private void TextBox_Price_KeyUp(object sender, KeyEventArgs e)
        {
            var textBox = sender as TextBox;

            string input = textBox.Text;

            if (decimal.TryParse(input, out decimal price))
            {

                if (price <= 0)
                {
                    TextBlock_Price.Text = "Invalid price";
                    TextBlock_Price.Foreground = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    TextBlock_Price.Text = "Product price";
                    TextBlock_Price.Foreground = new SolidColorBrush(Colors.Green);
                }
            }
            else
            {
                TextBlock_Price.Text = "Invalid price";
                TextBlock_Price.Foreground = new SolidColorBrush(Colors.Red);
            }
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            var textBox = sender as TextBox;

            string input = textBox.Text;

            if (!string.IsNullOrWhiteSpace(input))
            {

                TextBlock_Name.Text = "Product name";
                TextBlock_Name.Foreground = new SolidColorBrush(Colors.Green);

            }
            else
            {
                TextBlock_Name.Text = "Invalid name";
                TextBlock_Name.Foreground = new SolidColorBrush(Colors.Red);
            }
        }
    }
}
