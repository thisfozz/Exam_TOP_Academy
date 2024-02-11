using Command_;
using Exam_TOP_Academy.DataAccess.Contexts;
using Exam_TOP_Academy.DataAccess.Entities;
using Exam_TOP_Academy.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Windows.Input;

namespace Exam_TOP_Academy.ViewModels;
public class MainViewModel : INotifyPropertyChanged
{
    // Стартовый дипазон цен
    private string _beginRangePrice;
    public string BeginRangePrice
    {
        get { return _beginRangePrice; }
        set
        {
            if (_beginRangePrice != value)
            {
                _beginRangePrice = value;
                OnPropertyChanged(nameof(BeginRangePrice));
            }
        }
    }

    // Конечный дипазон цен
    private string _endRangePrice;
    public string EndRangePrice
    {
        get { return _endRangePrice; }
        set
        {
            if (_endRangePrice != value)
            {
                _endRangePrice = value;
                OnPropertyChanged(nameof(EndRangePrice));
            }
        }
    }


    // Стартовый дипазон выпуска книги
    private string _searchFormPublisherBeginYear;
    public string SearchFormPublisherBeginYear
    {
        get { return _searchFormPublisherBeginYear; }
        set
        {
            if (_searchFormPublisherBeginYear != value)
            {
                _searchFormPublisherBeginYear = value;
                OnPropertyChanged(nameof(SearchFormPublisherBeginYear));
            }
        }
    }

    // Конечный дипазон выпуска книги
    private string _searchFormPublisheEndYear;
    public string SearchFormPublisheEndYear
    {
        get { return _searchFormPublisheEndYear; }
        set
        {
            if (_searchFormPublisheEndYear != value)
            {
                _searchFormPublisheEndYear = value;
                OnPropertyChanged(nameof(SearchFormPublisheEndYear));
            }
        }
    }


    // Чекбокс новых книг
    private bool _isStatusNewBookChecked;
    public bool IsStatusNewBookChecked
    {
        get { return _isStatusNewBookChecked; }
        set
        {
            if (_isStatusNewBookChecked != value)
            {
                _isStatusNewBookChecked = value;
                OnPropertyChanged(nameof(IsStatusNewBookChecked));
            }
        }
    }


    // Чекбокс бестселлеров
    private bool _isStatusBestsellersChecked;
    public bool IsStatusBestsellersChecked
    {
        get { return _isStatusBestsellersChecked; }
        set
        {
            if (_isStatusBestsellersChecked != value)
            {
                _isStatusBestsellersChecked = value;
                OnPropertyChanged(nameof(IsStatusBestsellersChecked));
            }
        }
    }

    // Чекбокс предзаказа
    private bool _isStatusPreOrderChecked;
    public bool IsStatusPreOrderChecked
    {
        get { return _isStatusPreOrderChecked; }
        set
        {
            if (_isStatusPreOrderChecked != value)
            {
                _isStatusPreOrderChecked = value;
                OnPropertyChanged(nameof(IsStatusPreOrderChecked));
            }
        }
    }


    // Найти издательство
    private string _searchFormPublisher;
    public string SearchFormPublisher
    {
        get { return _searchFormPublisher; }
        set
        {
            if (_searchFormPublisher != value)
            {
                _searchFormPublisher = value;
                OnPropertyChanged(nameof(SearchFormPublisher));
            }
        }
    }

    // Свойство для состояния выбора (IsChecked) первого из топа Издательств
    private bool _isPublisherOneChecked;
    public bool IsPublisherOneChecked
    {
        get { return _isPublisherOneChecked; }
        set
        {
            if (_isPublisherOneChecked != value)
            {
                _isPublisherOneChecked = value;
                OnPropertyChanged(nameof(IsPublisherOneChecked));
            }
        }
    }

    // Свойство для состояния выбора (IsChecked) второго из топа Издательств
    private bool _isPublisherTwoChecked;
    public bool IsPublisherTwoChecked
    {
        get { return _isPublisherTwoChecked; }
        set
        {
            if (_isPublisherTwoChecked != value)
            {
                _isPublisherTwoChecked = value;
                OnPropertyChanged(nameof(IsPublisherTwoChecked));
            }
        }
    }

    // Свойство для состояния выбора (IsChecked) третьего из топа Издательств
    private bool _isPublisherThreeChecked;
    public bool IsPublisherThreeChecked
    {
        get { return _isPublisherThreeChecked; }
        set
        {
            if (_isPublisherThreeChecked != value)
            {
                _isPublisherThreeChecked = value;
                OnPropertyChanged(nameof(IsPublisherThreeChecked));
            }
        }
    }

    // Свойство для состояния выбора (IsChecked) четвертого из топа Издательств
    private bool _isPublisherFourChecked;
    public bool IsPublisherFourChecked
    {
        get { return _isPublisherFourChecked; }
        set
        {
            if (_isPublisherFourChecked != value)
            {
                _isPublisherFourChecked = value;
                OnPropertyChanged(nameof(IsPublisherFourChecked));
            }
        }
    }

    // Свойство для состояния выбора (IsChecked) пятого из топа Издательств
    private bool _isPublisherFiveChecked;
    public bool IsPublisherFiveChecked
    {
        get { return _isPublisherFiveChecked; }
        set
        {
            if (_isPublisherFiveChecked != value)
            {
                _isPublisherFiveChecked = value;
                OnPropertyChanged(nameof(IsPublisherFiveChecked));
            }
        }
    }


    // Топ издание 1
    private string _bestPublisherOneText;
    public string BestPublisherOneText
    {
        get { return _bestPublisherOneText; }
        set
        {
            if (_bestPublisherOneText != value)
            {
                _bestPublisherOneText = value;
                OnPropertyChanged(nameof(BestPublisherOneText));
            }
        }
    }
    // Топ издание 2
    private string _bestPublisherTwoText;
    public string BestPublisherTwoText
    {
        get { return _bestPublisherTwoText; }
        set
        {
            if (_bestPublisherTwoText != value)
            {
                _bestPublisherTwoText = value;
                OnPropertyChanged(nameof(BestPublisherTwoText));
            }
        }
    }
    // Топ издание 3
    private string _bestPublisherThreeText;
    public string BestPublisherThreeText
    {
        get { return _bestPublisherThreeText; }
        set
        {
            if (_bestPublisherThreeText != value)
            {
                _bestPublisherThreeText = value;
                OnPropertyChanged(nameof(BestPublisherThreeText));
            }
        }
    }
    // Топ издание 4
    private string _bestPublisherFourText;
    public string BestPublisherFourText
    {
        get { return _bestPublisherFourText; }
        set
        {
            if (_bestPublisherFourText != value)
            {
                _bestPublisherFourText = value;
                OnPropertyChanged(nameof(BestPublisherFourText));
            }
        }
    }
    // Топ издание 5
    private string _bestPublisherFiveText;
    public string BestPublisherFiveText
    {
        get { return _bestPublisherFiveText; }
        set
        {
            if (_bestPublisherFiveText != value)
            {
                _bestPublisherFiveText = value;
                OnPropertyChanged(nameof(BestPublisherFiveText));
            }
        }
    }


    // Найти автора
    private string _searchFormAuthor;
    public string SearchFormAuthor
    {
        get { return _searchFormAuthor; }
        set
        {
            if (_searchFormAuthor != value)
            {
                _searchFormAuthor = value;
                OnPropertyChanged(nameof(SearchFormAuthor));
            }
        }
    }

    // Свойство для состояния выбора (IsChecked) первого из топа Авторов
    private bool _isAuthorOneChecked;
    public bool IsAuthorOneChecked
    {
        get { return _isAuthorOneChecked; }
        set
        {
            if (_isAuthorOneChecked != value)
            {
                _isAuthorOneChecked = value;
                OnPropertyChanged(nameof(IsAuthorOneChecked));
            }
        }
    }

    // Свойство для состояния выбора (IsChecked) второго из топа Авторов
    private bool _isAuthorTwoChecked;
    public bool IsAuthorTwoChecked
    {
        get { return _isAuthorTwoChecked; }
        set
        {
            if (_isAuthorTwoChecked != value)
            {
                _isAuthorTwoChecked = value;
                OnPropertyChanged(nameof(IsAuthorTwoChecked));
            }
        }
    }

    // Свойство для состояния выбора (IsChecked) третьего из топа Авторов
    private bool _isAuthorThreeChecked;
    public bool IsAuthorThreeChecked
    {
        get { return _isAuthorThreeChecked; }
        set
        {
            if (_isAuthorThreeChecked != value)
            {
                _isAuthorThreeChecked = value;
                OnPropertyChanged(nameof(IsAuthorThreeChecked));
            }
        }
    }

    // Свойство для состояния выбора (IsChecked) четвертого из топа Авторов
    private bool _isAuthorFourChecked;
    public bool IsAuthorFourChecked
    {
        get { return _isAuthorFourChecked; }
        set
        {
            if (_isAuthorFourChecked != value)
            {
                _isAuthorFourChecked = value;
                OnPropertyChanged(nameof(IsAuthorFourChecked));
            }
        }
    }

    // Свойство для состояния выбора (IsChecked) пятого из топа Авторов
    private bool _isAuthorFiveChecked;
    public bool IsAuthorFiveChecked
    {
        get { return _isAuthorFiveChecked; }
        set
        {
            if (_isAuthorFiveChecked != value)
            {
                _isAuthorFiveChecked = value;
                OnPropertyChanged(nameof(IsAuthorFiveChecked));
            }
        }
    }


    // Топ автор 1
    private string _bestAuthorOneText;
    public string BestAuthorOneText
    {
        get { return _bestAuthorOneText; }
        set
        {
            if (_bestAuthorOneText != value)
            {
                _bestAuthorOneText = value;
                OnPropertyChanged(nameof(BestAuthorOneText));
            }
        }
    }

    // Топ автор 2
    private string _bestAuthorTwoText;
    public string BestAuthorTwoText
    {
        get { return _bestAuthorTwoText; }
        set
        {
            if (_bestAuthorTwoText != value)
            {
                _bestAuthorTwoText = value;
                OnPropertyChanged(nameof(BestAuthorTwoText));
            }
        }
    }

    // Топ автор 3
    private string _bestAuthorThreeText;
    public string BestAuthorThreeText
    {
        get { return _bestAuthorThreeText; }
        set
        {
            if (_bestAuthorThreeText != value)
            {
                _bestAuthorThreeText = value;
                OnPropertyChanged(nameof(BestAuthorThreeText));
            }
        }
    }

    // Топ автор 4
    private string _bestAuthorFourText;
    public string BestAuthorFourText
    {
        get { return _bestAuthorFourText; }
        set
        {
            if (_bestAuthorFourText != value)
            {
                _bestAuthorFourText = value;
                OnPropertyChanged(nameof(BestAuthorFourText));
            }
        }
    }

    // Топ автор 5
    private string _bestAuthorFiveText;
    public string BestAuthorFiveText
    {
        get { return _bestAuthorFiveText; }
        set
        {
            if (_bestAuthorFiveText != value)
            {
                _bestAuthorFiveText = value;
                OnPropertyChanged(nameof(BestAuthorFiveText));
            }
        }
    }


    // Таблица книг
    private List<BookModel> _books;

    public List<BookModel> Books
    {
        get { return _books; }
        set
        {
            if (_books != value)
            {
                _books = value;
                OnPropertyChanged(nameof(Books));
            }
        }
    }

    public ICommand ApplyFilterCommand { get; }

    private readonly IConfiguration configuration;
    public MainViewModel()
    {
        ApplyFilterCommand = new DelegateCommand(ApplyFilter, _ => true);
        configuration = BuildConfiguration();
        //LoadData(configuration);
        LoadAllAuthors();
        LoadTopPublishers();
    }

    private void LoadData(IConfiguration configuration)
    {
        var context = new BookStoreContext(configuration);
        var items = new List<BookModel>();

        foreach (var book in context.Books.Include(x => x.Publisher))
        {
            items.Add(new BookModel
            {
                BookIdData = book.BookId,
                TitleBook = book.Title,
                PublisherName = book.Publisher.PublisherName,
                DescriptionBook = book.Description,
                PriceData = Convert.ToDecimal(book.SellingPrice)
            }) ;

            Books = items;
        }
    }

    private void ApplyFilter(object obj)
    {
        var context = new BookStoreContext(configuration);
        var query = context.Books
            .Include(x => x.Publisher)
            .Include(x => x.Sales)
            .Include(x => x.Author)
            .AsQueryable();

        // Фильтр по цене
        if (!string.IsNullOrEmpty(BeginRangePrice) && !string.IsNullOrEmpty(EndRangePrice))
        {
            decimal beginRangePrice = Convert.ToDecimal(BeginRangePrice);
            decimal endRangePrice = Convert.ToDecimal(EndRangePrice);

            query = query.Where(book => book.SellingPrice >= beginRangePrice && book.SellingPrice <= endRangePrice);
        }

        // Фильтр по дате выпуска
        if (!string.IsNullOrEmpty(SearchFormPublisherBeginYear) && !string.IsNullOrEmpty(SearchFormPublisheEndYear))
        {
            short beginPublisherYear = Convert.ToInt16(SearchFormPublisherBeginYear);
            short endPublisherYear = Convert.ToInt16(SearchFormPublisheEndYear);

            query = query.Where(book => EF.Functions.Like(book.YearPublished.ToString(), $"{beginPublisherYear}%")
                                        && EF.Functions.Like(book.YearPublished.ToString(), $"{endPublisherYear}%"));
        }

        if (IsStatusNewBookChecked)
        {
            DateTime oneMonthAgo = DateTime.Now.AddMonths(-1);
            query = query.Where(book => book.DateAdded >= oneMonthAgo);
        }

        if(IsStatusBestsellersChecked) 
        {
            int countSold = 1000;
            query = query.Where(book => book.Sales.Sum(sale => sale.QuantitySold) > countSold);
        }

        if (IsStatusPreOrderChecked)
        {
            DateTime oneMonthAhead = DateTime.Now.AddMonths(1);
            query = query.Where(book => book.DateAdded > DateTime.Now && book.DateAdded <= oneMonthAhead);
        }

        // Дописать для выбранных издателей и авторов
    }

    private void LoadAllAuthors()
    {
        var context = new BookStoreContext(configuration);
        var query = context.Books
            .Include(x => x.Author)
            .Include(x => x.Sales)
            .AsQueryable();

        var authors = query
            .GroupBy(book => book.Author)
            .OrderByDescending(group => group.Sum(book => book.Sales.Sum(sale => sale.QuantitySold)))
            .Select(group => group.Key)
            .ToList();

        List<string> authorsNames = authors.Select(author => $"{author.FirstName} {author.LastName}").ToList();

        BestAuthorOneText = authorsNames[0];
        BestAuthorTwoText = authorsNames[1];
        BestAuthorThreeText = authorsNames[2];
        BestAuthorFourText = authorsNames[3];
        BestAuthorFiveText = authorsNames[4];
    }

    private void LoadTopPublishers()
    {
        var context = new BookStoreContext(configuration);
        var query = context.Books
            .Include(x => x.Publisher)
            .Include(x => x.Sales)
            .AsQueryable();

        var publishers = query
            .GroupBy(book => book.Publisher)
            .OrderByDescending(group => group.Sum(book => book.Sales.Sum(sale => sale.QuantitySold)))
            .Select(group => group.Key)
            .ToList();

        List<string> publishersNames = publishers.Select(publisher => publisher.PublisherName).ToList();

        BestPublisherOneText = publishersNames[0];
        BestPublisherTwoText = publishersNames[1];
        BestPublisherThreeText = publishersNames[2];
        BestPublisherFourText = publishersNames[3];
        BestPublisherFiveText = publishersNames[4];
    }

    private IConfiguration BuildConfiguration()
    {
        return new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
    }


    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
