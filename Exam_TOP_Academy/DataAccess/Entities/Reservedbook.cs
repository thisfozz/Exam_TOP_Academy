namespace Exam_TOP_Academy.DataAccess.Entities;
public partial class Reservedbook
{
    public int ReserveId { get; set; }

    public int BookId { get; set; }

    public int CustomerId { get; set; }

    public DateTime ReserveDate { get; set; }

    public bool IsActiveReserved { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;
}
