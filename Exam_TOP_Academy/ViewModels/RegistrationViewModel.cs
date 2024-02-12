using AesEncryptionNamespace;
using Command_;
using Exam_TOP_Academy.DataAccess.Contexts;
using Exam_TOP_Academy.DataAccess.Entities;
using Exam_TOP_Academy.View;
using Microsoft.Extensions.Configuration;
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
    public ICommand RegistrationUserCommand { get; }

    private string _email;

    public string Email
    {
        get { return _email; }
        set
        {
            if (_email != value)
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
    }

    private string _login;

    public string Login
    {
        get { return _login; }
        set
        {
            if (_login != value)
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
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

    private readonly IConfiguration configuration;
    public RegistrationViewModel()
    {
        configuration = BuildConfiguration();

        OpenAuthorizationCommand = new DelegateCommand(OpenAuthorization, _ => true);
        RollUpFormCommand = new DelegateCommand(RollUpForm, _ => true);
        MovingFormCommand = new DelegateCommand(MovingForm, _ => true);
        CloseFormCommand = new DelegateCommand(CloseForm, _ => true);
        RegistrationUserCommand = new DelegateCommand(RegistrationUser, _ => true);
    }

    private IConfiguration BuildConfiguration()
    {
        return new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json").Build();
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
    private void RegistrationUser(object obj)
    {
        var aesEncryption = new AesEncryption();
        string encryptedPassword = aesEncryption.Encrypt(Password);
        var newUser = new Registereduser
        {
            Email = Email,
            Login = Login,
            Password = encryptedPassword
        };

        using var context = new BookStoreContext(configuration);
        context.AddUser(newUser);

        var mainWindow = new MainWindow();

        mainWindow.Left = Application.Current.MainWindow.Left;
        mainWindow.Top = Application.Current.MainWindow.Top;

        Application.Current.MainWindow.Close();
        Thread.Sleep(200);
        Application.Current.MainWindow = mainWindow;
        Application.Current.MainWindow.Show();

    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
