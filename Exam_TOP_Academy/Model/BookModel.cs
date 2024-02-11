namespace Exam_TOP_Academy.Model;
public class BookModel
{
    public int BookIdData { get; set; }
    public string TitleBook { get; set; }
    public string PublisherName { get; set; }
    public string DescriptionBook { get; set; }
    public decimal PriceData { get; set; }
    public int YearOfPublication { get; set; } // Поле для диапазона выпуска книги
    public bool IsNew { get; set; } // Поле для статуса новых книг
    public bool IsBestseller { get; set; } // Поле для статуса бестселлеров
    public bool IsPreOrder { get; set; } // Поле для статуса предзаказа
    public string AuthorName { get; set; } // Поле для имени автора
}
