using System.Windows;

namespace Exam_TOP_Academy.View
{
    public partial class InputNumberDialog : Window
    {
        public int InputNumber { get; private set; }
        public InputNumberDialog()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(InputTextBox.Text, out int result))
            {
                InputNumber = result;
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Ошибка. Введите целое число.");
            }
        }
    }
}
