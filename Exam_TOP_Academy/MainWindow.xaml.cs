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
        if (e.ChangedButton == MouseButton.Left)
        {
            this.DragMove();
        }
    }

    private void LogoContainer_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ChangedButton == MouseButton.Left)
        {
            this.DragMove();
        }
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if(SettingsGrid.Visibility == Visibility.Hidden)
        {
            SettingsGrid.Visibility = Visibility.Visible;
        }
        else
        {
            SettingsGrid.Visibility = Visibility.Hidden;
        }
    }

    private void MainGrid_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        Point point = e.GetPosition(MainGrid);
        Point relativePoint = SettingsGrid.TranslatePoint(new Point(0, 0), MainGrid);

        bool isClickInsideGrid = point.X >= relativePoint.X &&
                                 point.X < relativePoint.X + SettingsGrid.ActualWidth &&
                                 point.Y >= relativePoint.Y &&
                                 point.Y < relativePoint.Y + SettingsGrid.ActualHeight;

        if (!isClickInsideGrid)
        {
            SettingsGrid.Visibility = Visibility.Hidden;
        }
    }

    private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
    {
        if(PasswordForm.Password.Length > 0)
        {
            PasswordWaterMark.Visibility = Visibility.Collapsed;
        }
        else
        {
            PasswordWaterMark.Visibility = Visibility.Visible;
        }
    }
}