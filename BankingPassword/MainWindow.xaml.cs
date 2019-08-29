using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace BankingPassword
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            passwordBox.Password = string.Empty;

            index1TextBox.Text = string.Empty;
            index2TextBox.Text = string.Empty;
            index3TextBox.Text = string.Empty;

            result1TextBox.Text = string.Empty;
            result2TextBox.Text = string.Empty;
            result3TextBox.Text = string.Empty;

            ValidationTextBlock.Visibility = Visibility.Hidden;

        }

        private void IndexTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            ValidationTextBlock.Visibility = Visibility.Hidden;

            string password = passwordBox.Password;
            string index1Text = index1TextBox.Text;
            string index2Text = index2TextBox.Text;
            string index3Text = index3TextBox.Text;

            int index1;            
            int index2;            
            int index3;

            int.TryParse(index1Text, out index1);
            int.TryParse(index2Text, out index2);
            int.TryParse(index3Text, out index3);

            if (string.IsNullOrEmpty(password))
            {
                ValidationTextBlock.Visibility = Visibility.Visible;
                ValidationTextBlock.Text = ValidationMessages.PasswordMissing;
            }
            else if (index1 < 1 | index2 < 1 | index3 < 1)
            {
                ValidationTextBlock.Visibility = Visibility.Visible;
                ValidationTextBlock.Text = ValidationMessages.IndexesMissing;
            }
            else if (index1 > password.Length | index2 > password.Length | index3 > password.Length)
            {
                ValidationTextBlock.Visibility = Visibility.Visible;
                ValidationTextBlock.Text = ValidationMessages.IndexesInvalid;
            }
            else
            {
                result1TextBox.Text = password.Substring(index1 - 1, 1);
                result2TextBox.Text = password.Substring(index2 - 1, 1);
                result3TextBox.Text = password.Substring(index3 - 1, 1);
            }         

        }
    }
}
