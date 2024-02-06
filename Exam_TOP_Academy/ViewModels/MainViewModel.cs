using Exam_TOP_Academy.View;
using System.Windows;

namespace Exam_TOP_Academy.ViewModels;

public class MainViewModel
{
    public MainViewModel()
    {
        OpenAuthorizationWindow();
    }

    private void OpenAuthorizationWindow()
    {
        AuthorizationViewModel authorizationViewModel = new AuthorizationViewModel();
        var authorizationWindow = new AuthorizationWindow();

        Application.Current.MainWindow.Close();
        Application.Current.MainWindow = authorizationWindow;
        Application.Current.MainWindow.Show();
    }

}
