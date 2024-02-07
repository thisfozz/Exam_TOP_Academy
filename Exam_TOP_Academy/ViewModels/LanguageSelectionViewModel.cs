using Command_;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Globalization;

namespace Exam_TOP_Academy.ViewModels;

public class LanguageSelectionViewModel : INotifyPropertyChanged
{
    public ICommand CloseFormCommand { get; }
    public ICommand DoneChangeLanguageCommand { get; }

    private bool _selectedLanguageRussian;
    private bool _selectedLanguageEnglish;

    public bool SelectedLanguageRussian
    {
        get { return _selectedLanguageRussian; }
        set
        {
            if (_selectedLanguageRussian != value)
            {
                _selectedLanguageRussian = value;
                OnPropertyChanged(nameof(SelectedLanguageRussian));
            }
        }
    }

    public bool SelectedLanguageEnglish
    {
        get { return _selectedLanguageEnglish; }
        set
        {
            if (_selectedLanguageEnglish != value)
            {
                _selectedLanguageEnglish = value;
                OnPropertyChanged(nameof(SelectedLanguageEnglish));
            }
        }
    }

    public LanguageSelectionViewModel()
    {
        CloseFormCommand = new DelegateCommand(CloseForm, _ => true);
        DoneChangeLanguageCommand = new DelegateCommand(ChangeLanguage, _ => true);
    }

    private void CloseForm(object obj)
    {
        Window currentWindow = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);

        if (currentWindow != null)
        {
            currentWindow.Close();
        }
    }

    private void ChangeLanguage(object obj)
    {
        if (SelectedLanguageRussian)
        {
            ChangeLanguage("ru-RU");
        }
        else if (SelectedLanguageEnglish)
        {
            ChangeLanguage("en-US");
        }
    }
    private void ChangeLanguage(string cultureCode)
    {
        try
        {
            CultureInfo newCulture = new CultureInfo(cultureCode);
            Thread.CurrentThread.CurrentCulture = newCulture;
            Thread.CurrentThread.CurrentUICulture = newCulture;
            // Обновить еще и родительский поток

            CloseForm(this);

        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error changing language: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
