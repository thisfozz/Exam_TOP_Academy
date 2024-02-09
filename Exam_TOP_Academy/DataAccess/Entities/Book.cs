namespace Exam_TOP_Academy.DataAccess.Entities;
public partial class Book
{
    public int BookId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public int AuthorId { get; set; }

    public int PublisherId { get; set; }

    public int GenreId { get; set; }

    public int? SequelId { get; set; }

    public short Pages { get; set; }

    public short? YearPublished { get; set; }

    public decimal? SellingPrice { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Author Author { get; set; } = null!;

    public virtual Genre Genre { get; set; } = null!;

    public virtual ICollection<Book> InverseSequel { get; set; } = new List<Book>();

    public virtual Publisher Publisher { get; set; } = null!;

    public virtual ICollection<Reservedbook> Reservedbooks { get; set; } = new List<Reservedbook>();

    public virtual ICollection<Salebook> Salebooks { get; set; } = new List<Salebook>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

    public virtual Book? Sequel { get; set; }

    public virtual ICollection<Sequel> Sequels { get; set; } = new List<Sequel>();
}
