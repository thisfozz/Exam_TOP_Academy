namespace Exam_TOP_Academy.DataAccess.Entities;
public partial class Salebook
{
    public int SaleId { get; set; }

    public int BookId { get; set; }

    public int PromotionId { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual Promotion Promotion { get; set; } = null!;
}
