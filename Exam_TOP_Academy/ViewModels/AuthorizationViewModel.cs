using AesEncryptionNamespace;
using Command_;
using Exam_TOP_Academy.DataAccess.Contexts;
using Exam_TOP_Academy.View;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Exam_TOP_Academy.ViewModels;

public class AuthorizationViewModel : INotifyPropertyChanged
{
    public ICommand OpenSettingsGridCommand { get; }
    public ICommand AuthorizationButtonCommand { get; }
    public ICommand CloseFormCommand { get; }
    public ICommand RollUpFormCommand { get; }
    public ICommand MovingFormCommand { get; }
    public ICommand OpenRegistrationFormCommand { get; }
    public ICommand OpenSettingsFormCommand { get; }

    private string _loginOrEmail;

    public string LoginOrEmail
    {
        get { return _loginOrEmail; }
        set
        {
            if (_loginOrEmail != value)
            {
                _loginOrEmail = value;
                OnPropertyChanged(nameof(LoginOrEmail));
            }
        }
    }

    private string _password;

    public string Password
    {
        get { return _password; }
        set
        {
            if (_password != value)
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
    }

    public AuthorizationViewModel()
    {
        SettingsGridVisibility = Visibility.Collapsed;
        OpenSettingsGridCommand = new DelegateCommand(OpenSettingsGrid, _ => true);
        AuthorizationButtonCommand = new DelegateCommand(Authorization, _ => true);
        CloseFormCommand = new DelegateCommand(CloseForm, _ => true);
        RollUpFormCommand = new DelegateCommand(RollUpForm, _ => true);
        MovingFormCommand = new DelegateCommand(MovingForm, _ => true);
        OpenRegistrationFormCommand = new DelegateCommand(OpenRegistration, _ => true);
        OpenSettingsFormCommand = new DelegateCommand(OpenSettingsForm, _ => true);
    }

    private Visibility settingsGridVisibility;

    public Visibility SettingsGridVisibility
    {
        get { return settingsGridVisibility; }
        set
        {
            if (value != settingsGridVisibility)
            {
                settingsGridVisibility = value;
                OnPropertyChanged(nameof(SettingsGridVisibility));
            }
        }
    }

    private void OpenSettingsGrid(object obj)
    {
        SettingsGridVisibility = (SettingsGridVisibility == Visibility.Visible)? Visibility.Collapsed : Visibility.Visible;
    }

    private void Authorization(object obj)
    {
        using var context = new BookStoreContext();
        var user = context.Registeredusers.FirstOrDefault(u => u.Login == LoginOrEmail || u.Email == LoginOrEmail);

        if (user != null)
        {
            var aesEncryption = new AesEncryption();
            string decryptedPassword = aesEncryption.Decrypt(user.Password);

            if (decryptedPassword == Password)
            {
                var mainWindow = new MainWindow();

                mainWindow.Left = Application.Current.MainWindow.Left;
                mainWindow.Top = Application.Current.MainWindow.Top;
                
                Application.Current.MainWindow.Close();
                Thread.Sleep(200);
                Application.Current.MainWindow = mainWindow;
                Application.Current.MainWindow.Show();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }
        else
        {
            MessageBox.Show("Указанный пользователь не найден");
        }
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

    private void OpenRegistration(object obj)
    {
        var registrationWindow = new RegistrationWindow();

        registrationWindow.Left = Application.Current.MainWindow.Left;
        registrationWindow.Top = Application.Current.MainWindow.Top;

        Application.Current.MainWindow.Close();
        Thread.Sleep(200);
        Application.Current.MainWindow = registrationWindow;
        Application.Current.MainWindow.Show();
    }

    private void OpenSettingsForm(object parameter)
    {
        LanguageSelectionDialog languageDialog = new LanguageSelectionDialog();

        languageDialog.Left = Application.Current.MainWindow.Left + (Application.Current.MainWindow.Width - languageDialog.Width) / 2;
        languageDialog.Top = Application.Current.MainWindow.Top + (Application.Current.MainWindow.Height - languageDialog.Height) / 2;

        bool? result = languageDialog.ShowDialog();
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
