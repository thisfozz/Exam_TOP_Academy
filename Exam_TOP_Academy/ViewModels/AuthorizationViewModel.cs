using Command_;
using Exam_TOP_Academy.View;
using System.Windows;
using System.Windows.Input;

namespace Exam_TOP_Academy.ViewModels;

public class AuthorizationViewModel
{
    public ICommand OpenSettingsButtonCommand { get; }
    public ICommand AuthorizationButtonCommand { get; }
    public ICommand CloseFormCommand { get; }
    public ICommand RollUpFormCommand { get; }
    public ICommand MovingFormCommand { get; }
    public AuthorizationViewModel()
    {
        OpenSettingsButtonCommand = new DelegateCommand(OpenSettings, _ => true);
        AuthorizationButtonCommand = new DelegateCommand(Authorization, _ => true);
        CloseFormCommand = new DelegateCommand(CloseForm, _ => true);
        RollUpFormCommand = new DelegateCommand(RollUpForm, _ => true);
        MovingFormCommand = new DelegateCommand(MovingForm, _ => true);
    }

    private void MovingForm(object obj)
    {
        MessageBox.Show("Перемещение");
    }

    private void RollUpForm(object obj)
    {
        MessageBox.Show("Окно свернуто");
    }

    private void CloseForm(object obj)
    {
        Application.Current.Shutdown();
    }

    private void Authorization(object obj)
    {
        MessageBox.Show("Успех авторизации");
    }

    private void OpenSettings(object obj)
    {
        MessageBox.Show("Настройки");
    }
}
