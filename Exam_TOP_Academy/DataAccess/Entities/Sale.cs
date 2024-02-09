namespace Exam_TOP_Academy.DataAccess.Entities;
public partial class Sale
{
    public int SalesId { get; set; }

    public int? BookId { get; set; }

    public int? QuantitySold { get; set; }

    public DateTime SalesDate { get; set; }

    public virtual Book? Book { get; set; }
}
