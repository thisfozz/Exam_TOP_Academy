namespace Exam_TOP_Academy.DataAccess.Entities;
public partial class Customer
{
    public int CustomerId { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public virtual ICollection<Reservedbook> Reservedbooks { get; set; } = new List<Reservedbook>();
}
