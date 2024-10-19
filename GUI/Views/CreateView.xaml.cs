using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace GUI.Views
{
    /// <summary>
    /// Interaction logic for CreateView.xaml
    /// </summary>
    public partial class CreateView : UserControl
    {
        public CreateView()
        {
            InitializeComponent();
        }

        private void TextBox_Price_KeyUp(object sender, KeyEventArgs e)
        {
            var textBox = sender as TextBox;

            string input = textBox!.Text;

            if (decimal.TryParse(input, out decimal price))
            {
                TextBlock_Price.Text = "Product price";
                TextBlock_Price.Foreground = new SolidColorBrush(Colors.Green);
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

            string input = textBox!.Text;

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
