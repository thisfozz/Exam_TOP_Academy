namespace Exam_TOP_Academy.Model;
public class BookModel
{
    public int BookIdData { get; set; }
    public string TitleData { get; set; }
    public string PublisherData { get; set; }
    public string DescriptionData { get; set; }
    public decimal PriceData { get; set; }
    public int PublicationDateData { get; set; }
    public bool IsNew { get; set; }
    public bool IsBestseller { get; set; } 
    public bool IsPreOrder { get; set; }
}
