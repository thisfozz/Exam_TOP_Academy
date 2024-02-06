using Command_;
using Exam_TOP_Academy.View;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Exam_TOP_Academy.ViewModels;
public class RegistrationViewModel : INotifyPropertyChanged
{
    public ICommand OpenAuthorizationCommand { get; }
    public ICommand RollUpFormCommand { get; }
    public ICommand MovingFormCommand { get; }
    public ICommand CloseFormCommand { get; }

    public RegistrationViewModel()
    {
        OpenAuthorizationCommand = new DelegateCommand(OpenAuthorization, _ => true);
        RollUpFormCommand = new DelegateCommand(RollUpForm, _ => true);
        MovingFormCommand = new DelegateCommand(MovingForm, _ => true);
        CloseFormCommand = new DelegateCommand(CloseForm, _ => true);
    }

    private void OpenAuthorization(object obj)
    {
        var authorizationWindow = new AuthorizationWindow();

        authorizationWindow.Left = Application.Current.MainWindow.Left;
        authorizationWindow.Top = Application.Current.MainWindow.Top;

        Application.Current.MainWindow.Close();
        Thread.Sleep(200);
        Application.Current.MainWindow = authorizationWindow;
        Application.Current.MainWindow.Show();
    }

    private void CloseForm(object obj)
    {
        Application.Current.MainWindow.Close();
    }
    private void RollUpForm(object obj)
    {
        Application.Current.MainWindow.WindowState = WindowState.Minimized;
    }

    private void MovingForm(object obj)
    {
        Application.Current.MainWindow.DragMove();
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
