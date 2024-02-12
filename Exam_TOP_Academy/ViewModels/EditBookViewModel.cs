using Command_;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace Exam_TOP_Academy.ViewModels;
class EditBookViewModel : INotifyPropertyChanged
{
    public ICommand SaveChangesCommand { get; }

    public EditBookViewModel()
    {
        SaveChangesCommand = new DelegateCommand(SaveChanges, _ => true);
    }

    private void SaveChanges(object obj)
    {
        if (obj is Window window)
        {
            window.Close();
        }
    }


    private string _title;
    public string Title
    {
        get { return _title; }
        set { _title = value; OnPropertyChanged(); }
    }

    private string _description;
    public string Description
    {
        get { return _description; }
        set { _description = value; OnPropertyChanged(); }
    }

    private string _authorName;
    public string AuthorName
    {
        get { return _authorName; }
        set { _authorName = value; OnPropertyChanged(); }
    }


    private string _authorLastName;
    public string AuthorLastName
    {
        get { return _authorLastName; }
        set { _authorLastName = value; OnPropertyChanged(); }
    }

    private string _publisher;
    public string Publisher
    {
        get { return _publisher; }
        set { _publisher = value; OnPropertyChanged(); }
    }

    private string _genre;
    public string Genre
    {
        get { return _genre; }
        set { _genre = value; OnPropertyChanged(); }
    }

    private int _pages;
    public int Pages
    {
        get { return _pages; }
        set { _pages = value; OnPropertyChanged(); }
    }

    private int _yearPublished;
    public int YearPublished
    {
        get { return _yearPublished; }
        set { _yearPublished = value; OnPropertyChanged(); }
    }

    private decimal _sellingPrice;
    public decimal SellingPrice
    {
        get { return _sellingPrice; }
        set { _sellingPrice = value; OnPropertyChanged(); }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
