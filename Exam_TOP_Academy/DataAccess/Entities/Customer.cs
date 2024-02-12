namespace Exam_TOP_Academy.DataAccess.Entities;
public partial class Customer
{
    public Customer()
    {
        Reservedbooks = new HashSet<Reservedbook>();
    }

    public int CustomerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public virtual ICollection<Reservedbook> Reservedbooks { get; set; }
}