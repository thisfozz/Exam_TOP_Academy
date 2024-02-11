using Command_;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.IO;
using Newtonsoft.Json;
using Exam_TOP_Academy.Settings;

namespace Exam_TOP_Academy.ViewModels;
public class LanguageSelectionViewModel : INotifyPropertyChanged
{
    private string filePath = @"appsettingslang.json";

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
        try
        {
            if (File.Exists(filePath))
            {
                string langCode = SelectedLanguageRussian ? "ru-RU" : "en-US";
                MainSettings mainSettings = new MainSettings
                {
                    languageSettings = new LanguageSettings
                    {
                        LangCode = langCode
                    }
                };

                string jsonData = JsonConvert.SerializeObject(mainSettings, Formatting.Indented);
                File.WriteAllText(filePath, jsonData);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
