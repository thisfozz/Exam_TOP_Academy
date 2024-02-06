using Command_;
using Exam_TOP_Academy.Helpers;
using System.ComponentModel;
using System.Security;
using System.Windows;
using System.Windows.Input;

namespace Exam_TOP_Academy.ViewModels;

public class AuthorizationViewModel : INotifyPropertyChanged
{
    public ICommand ToggleSettingsCommand { get; }
    public AuthorizationViewModel()
    {
        SettingsGridVisibility = Visibility.Hidden;
        ToggleSettingsCommand = new DelegateCommand(ToggleSettings, _ => true);
    }


    private Visibility _settingsGridVisibility;
    public Visibility SettingsGridVisibility
    {
        get { return _settingsGridVisibility; }
        set
        {
            if (_settingsGridVisibility != value)
            {
                _settingsGridVisibility = value;
                OnPropertyChanged(nameof(SettingsGridVisibility));
            }
        }
    }
    private void ToggleSettings(object parameter)
    {
        SettingsGridVisibility = SettingsGridVisibility == Visibility.Hidden ? Visibility.Visible : Visibility.Hidden;
    }

    private ICommand _dragMoveCommand;
    public ICommand DragMoveCommand
    {
        get
        {
            if (_dragMoveCommand == null)
            {
                _dragMoveCommand = new DelegateCommand(DragMoveaApp, _ => true);
            }
            return _dragMoveCommand;
        }
    }
    private void DragMoveaApp(object parameter)
    {

    }


    private SecureString _password;
    public SecureString Password
    {
        get { return _password; }
        set
        {
            if (_password != value)
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
                UpdatePasswordWatermarkVisibility();
            }
        }
    }
    private Visibility _passwordWatermarkVisibility;
    public Visibility PasswordWatermarkVisibility
    {
        get { return _passwordWatermarkVisibility; }
        set
        {
            if (_passwordWatermarkVisibility != value)
            {
                _passwordWatermarkVisibility = value;
                OnPropertyChanged(nameof(PasswordWatermarkVisibility));
            }
        }
    }
    private ICommand _passwordChangedCommand;
    public ICommand PasswordChangedCommand
    {
        get
        {
            if (_passwordChangedCommand == null)
            {
                _passwordChangedCommand = new DelegateCommand(PasswordChanged, _ => true);
            }
            return _passwordChangedCommand;
        }
    }
    private void UpdatePasswordWatermarkVisibility()
    {
        PasswordWatermarkVisibility = SecureStringHelper.IsStringNullOrEmpty(Password) ? Visibility.Visible : Visibility.Collapsed;
    }
    private void PasswordChanged(object parameter)
    {
        UpdatePasswordWatermarkVisibility();
    }

    private ICommand _minimizeCommand;
    public ICommand MinimizeCommand
    {
        get
        {
            if (_minimizeCommand == null)
            {
                _minimizeCommand = new DelegateCommand(Minimize, _ => true);
            }
            return _minimizeCommand;
        }
    }
    private void Minimize(object parameter)
    {
        Application.Current.Windows[0].WindowState = WindowState.Minimized;
    }

    private ICommand _exitCommand;

    public ICommand ExitCommand
    {
        get
        {
            if (_exitCommand == null)
            {
                _exitCommand = new DelegateCommand(Exit, _ => true);
            }
            return _exitCommand;
        }
    }

    private void Exit(object parameter)
    {
        Application.Current.Shutdown();
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
