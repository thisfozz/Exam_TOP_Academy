using Command_;
using Exam_TOP_Academy.View;
using System.Windows;
using System.Windows.Input;

namespace Exam_TOP_Academy.ViewModels;

public class AuthorizationViewModel
{
    public ICommand OpenSettingsButtonCommand { get; }
    public ICommand AuthorizationButtonCommand { get; }
    public AuthorizationViewModel()
    {
        OpenSettingsButtonCommand = new DelegateCommand(OpenSettings, _ => true);
        AuthorizationButtonCommand = new DelegateCommand(Authorization, _ => true);
    }

    private void Authorization(object obj)
    {
        throw new NotImplementedException();
    }

    private void OpenSettings(object obj)
    {
        throw new NotImplementedException();
    }
}
