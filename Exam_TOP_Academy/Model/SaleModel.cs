using Exam_TOP_Academy.DataAccess.Entities;

namespace Exam_TOP_Academy.Model;
public class SaleModel
{
    public int SalesId { get; set; }
    public int BookId { get; set; }
    public int QuantitySold { get; set; }
    public DateTime SalesDate { get; set; }
    public virtual Book Book { get; set; }
}