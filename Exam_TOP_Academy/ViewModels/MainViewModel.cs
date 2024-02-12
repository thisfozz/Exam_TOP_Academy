using Command_;
using Exam_TOP_Academy.DataAccess.Contexts;
using Exam_TOP_Academy.DataAccess.Entities;
using Exam_TOP_Academy.Model;
using Exam_TOP_Academy.View;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.ComponentModel;
using System.Data;
using System.Windows.Input;

namespace Exam_TOP_Academy.ViewModels;
public class MainViewModel : INotifyPropertyChanged
{
    private readonly IConfiguration configuration;
    public ICommand ApplyFilterCommand { get; }
    public ICommand SellBookCommand { get; }
    public ICommand EditBookCommand { get; }
    public ICommand DeleteBookCommand { get; }
    public ICommand SearchBookCommand { get; }
    public MainViewModel()
    {
        ApplyFilterCommand = new DelegateCommand(ApplyFilter, _ => true);
        SellBookCommand = new DelegateCommand(async (_) => await SellBookAsync(_), (_) => true);
        EditBookCommand = new DelegateCommand(EditBook, _ => true);
        DeleteBookCommand = new DelegateCommand(DeleteBook, _ => true);
        SearchBookCommand = new DelegateCommand(SearchBook, _ => true);

        configuration = BuildConfiguration();
        LoadData(configuration);
        LoadAllAuthors();
        LoadTopPublishers();
    }

    private void SearchBook(object obj)
    {
        if (SearchForTitleBook)
        {
            using var context = new BookStoreContext(configuration);

            var foundBooks = context.Books.Where(b => b.Title.Contains(SearchForm)).ToList();

            Books = foundBooks.Select(b => new BookModel
            {
                BookIdData = b.BookId,
                TitleData = b.Title,
                PublisherData = b.Publisher.PublisherName,
                PublicationDateData = Convert.ToInt32(b.YearPublished),
                DescriptionData = b.Description,
                PriceData = Convert.ToDecimal(b.SellingPrice)
            }).ToList();
        }
        if (SearchForGenreBook)
        {
            using var context = new BookStoreContext(configuration);

            var foundBooks = context.Books.Where(b => b.Title.Contains(SearchForm) || b.Genre.GenreName.Contains(SearchForm)).ToList();

            Books = foundBooks.Select(b => new BookModel
            {
                BookIdData = b.BookId,
                TitleData = b.Title,
                PublisherData = b.Publisher.PublisherName,
                PublicationDateData = Convert.ToInt32(b.YearPublished),
                DescriptionData = b.Description,
                PriceData = Convert.ToDecimal(b.SellingPrice)
            }).ToList();
        }
        if (SearchForAuthorBook)
        {
            using var context = new BookStoreContext(configuration);

            var foundBooks = context.Books.Where(b => b.Author.FirstName.Contains(SearchForm) || b.Author.LastName.Contains(SearchForm) || (b.Author.FirstName + " " + b.Author.LastName).Contains(SearchForm)).ToList();

            Books = foundBooks.Select(b => new BookModel
            {
                BookIdData = b.BookId,
                TitleData = b.Title,
                PublisherData = b.Publisher.PublisherName,
                PublicationDateData = Convert.ToInt32(b.YearPublished),
                DescriptionData = b.Description,
                PriceData = Convert.ToDecimal(b.SellingPrice)
            }).ToList();
        }
    }

    private async Task SellBookAsync(object obj)
    {
        if (obj is BookModel bookModel)
        {
            var bookId = bookModel.BookIdData;

            var inputDialog = new InputNumberDialog();
            var result = inputDialog.ShowDialog();

            if (result == true)
            {
                var quantity = inputDialog.InputNumber;

                using var context = new BookStoreContext(configuration);

                var sale = new Sale
                {
                    BookId = bookId,
                    QuantitySold = quantity,
                    SalesDate = DateTime.Now.ToUniversalTime(),
                };

                context.AddSale(sale);
                await context.SaveChangesAsync();
            }
        }
    }

    private void EditBook(object obj)
    {
        if (obj is BookModel bookModel)
        {
            var bookId = bookModel.BookIdData;

            var context = new BookStoreContext(configuration);

            var editableBook = context.Books.Find(bookId);

            EditBookViewModel editBookViewModel = new EditBookViewModel
            {
                Title = editableBook.Title,
                Description = editableBook.Description,
                AuthorName = editableBook.Author.FirstName,
                AuthorLastName = editableBook.Author.LastName,
                Publisher = editableBook.Publisher.PublisherName,
                Genre = editableBook.Genre.GenreName,
                Pages = editableBook.Pages,
                YearPublished = Convert.ToInt32(editableBook.YearPublished),
                SellingPrice = Convert.ToInt16(editableBook.SellingPrice)
            };

            EditBookDialog editBookDialog = new EditBookDialog
            {
                DataContext = editBookViewModel
            };

            editBookDialog.ShowDialog();

            editableBook.Title = editBookViewModel.Title;
            editableBook.Description = editBookViewModel.Description;
            editableBook.Author.FirstName = editBookViewModel.AuthorName;
            editableBook.Author.LastName = editBookViewModel.AuthorLastName;

            editableBook.Publisher.PublisherName = editBookViewModel.Publisher;
            editableBook.Genre.GenreName = editBookViewModel.Genre;
            editableBook.Pages = Convert.ToInt16(editBookViewModel.Pages);
            editableBook.YearPublished = Convert.ToInt16(editBookViewModel.YearPublished);
            editableBook.SellingPrice = editBookViewModel.SellingPrice;

            context.SaveChanges();
        }
        LoadData(configuration);
    }


    private void DeleteBook(object obj)
    {
        if (obj is BookModel bookModel)
        {
            var bookId = bookModel.BookIdData;

            using (var context = new BookStoreContext(configuration))
            {
                var deleteBook = context.Books.Find(bookId);

                if (deleteBook != null)
                {
                    context.Remove(deleteBook);
                    context.SaveChanges();

                    LoadData(configuration);
                }
            }
        }
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
                TitleData = book.Title,
                PublisherData = book.Publisher.PublisherName,
                PublicationDateData = Convert.ToInt32(book.YearPublished),
                DescriptionData = book.Description,
                PriceData = Convert.ToDecimal(book.SellingPrice)
            });
        }

        Books = items;
    }

    private void ApplyFilter(object obj)
    {
        var context = new BookStoreContext(configuration);
        var query = context.Books.Include(x => x.Publisher).Include(x => x.Sales).Include(x => x.Author).AsQueryable();

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

            query = query.Where(book => book.YearPublished >= beginPublisherYear && book.YearPublished <= endPublisherYear);
        }


        // Фильтр по новинкам
        if (IsStatusNewBookChecked)
        {
            DateTime oneMonthAgo = DateTime.Now.AddMonths(-1);
            DateTime utcDateTime = oneMonthAgo.ToUniversalTime();
            query = query.Where(book => book.DateAdded >= utcDateTime);
        }

        // Фильтр по бестселлерам
        if(IsStatusBestsellersChecked) 
        {
            int countSold = 1000;
            query = query.Where(book => book.Sales.Sum(sale => sale.QuantitySold) > countSold);
        }

        // Фильтр по предзаказам
        if (IsStatusPreOrderChecked)
        {
            DateTime oneMonthAhead = DateTime.Now.AddMonths(1);
            query = query.Where(book => book.DateAdded > DateTime.Now && book.DateAdded <= oneMonthAhead);
        }

        Books = query.Select(book => new BookModel
        {
            BookIdData = book.BookId,
            TitleData = book.Title,
            PublisherData = book.Publisher.PublisherName,
            PublicationDateData = Convert.ToInt32(book.YearPublished),
            DescriptionData = book.Description,
            PriceData = Convert.ToDecimal(book.SellingPrice)
        }).ToList();
    }

    private void LoadAllAuthors()
    {
        var context = new BookStoreContext(configuration);
        var query = context.Books.Include(x => x.Author).Include(x => x.Sales).AsQueryable();

        var authors = query.GroupBy(book => book.Author).OrderByDescending(group => group.Sum(book => book.Sales.Sum(sale => sale.QuantitySold))).Select(group => group.Key).ToList();

        List<string> authorsNames = authors.Select(author => $"{author.FirstName} {author.LastName}").ToList();

        string[] bestAuthorTexts = new string[5];

        for (int i = 0; i < bestAuthorTexts.Length; i++)
        {
            bestAuthorTexts[i] = (i < authorsNames.Count) ? authorsNames[i] : "Нет данных";
        }

        BestAuthorOneText = bestAuthorTexts[0];
        BestAuthorTwoText = bestAuthorTexts[1];
        BestAuthorThreeText = bestAuthorTexts[2];
        BestAuthorFourText = bestAuthorTexts[3];
        BestAuthorFiveText = bestAuthorTexts[4];
    }

    private void LoadTopPublishers()
    {
        var context = new BookStoreContext(configuration);
        var query = context.Books.Include(x => x.Publisher).Include(x => x.Sales).AsQueryable();

        var publishers = query.GroupBy(book => book.Publisher).OrderByDescending(group => group.Sum(book => book.Sales.Sum(sale => sale.QuantitySold))).Select(group => group.Key).ToList();

        List<string> publishersNames = publishers.Select(publisher => publisher.PublisherName).ToList();

        string[] bestPublisherTexts = new string[5];

        for (int i = 0; i < bestPublisherTexts.Length; i++)
        {
            bestPublisherTexts[i] = (i < publishersNames.Count) ? publishersNames[i] : "Нет данных";
        }

        BestPublisherOneText = bestPublisherTexts[0];
        BestPublisherTwoText = bestPublisherTexts[1];
        BestPublisherThreeText = bestPublisherTexts[2];
        BestPublisherFourText = bestPublisherTexts[3];
        BestPublisherFiveText = bestPublisherTexts[4];
    }

    private IConfiguration BuildConfiguration()
    {
        return new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json").Build();
    }

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


    // Главная строка поиска
    private string _searchForm;
    public string SearchForm
    {
        get { return _searchForm; }
        set
        {
            if (_searchForm != value)
            {
                _searchForm = value;
                OnPropertyChanged(nameof(SearchForm));
            }
        }
    }
    // Главный поиск по названию книги
    private bool _searchForTitleBook;
    public bool SearchForTitleBook
    {
        get { return _searchForTitleBook; }
        set
        {
            if (_searchForTitleBook != value)
            {
                _searchForTitleBook = value;
                OnPropertyChanged(nameof(SearchForTitleBook));
            }
        }
    }
    // Главный поиск по жанру книги
    private bool _searchForGenreBook;
    public bool SearchForGenreBook
    {
        get { return _searchForGenreBook; }
        set
        {
            if (_searchForGenreBook != value)
            {
                _searchForGenreBook = value;
                OnPropertyChanged(nameof(SearchForGenreBook));
            }
        }
    }
    // Главный поиск по автору книги
    private bool _searchForAuthorBook;
    public bool SearchForAuthorBook
    {
        get { return _searchForAuthorBook; }
        set
        {
            if (_searchForAuthorBook != value)
            {
                _searchForAuthorBook = value;
                OnPropertyChanged(nameof(SearchForAuthorBook));
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




    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
