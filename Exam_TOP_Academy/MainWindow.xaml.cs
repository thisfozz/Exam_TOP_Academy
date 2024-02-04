using System.Windows;
using System.Windows.Input;

namespace Exam_TOP_Academy;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void MinButton_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        this.WindowState = WindowState.Minimized;
    }

    private void ExitButton_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        this.Close();
    }

    private void ToolBar_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        if(e.ChangedButton == MouseButton.Left)
        {
            this.DragMove();
        }
    }
}