using Exam_TOP_Academy.DataAccess.Entities;

namespace Exam_TOP_Academy.DataAccess.Entities
{
    public partial class Book
    {
        public Book()
        {
            Reservedbooks = new HashSet<Reservedbook>();
            Salebooks = new HashSet<Salebook>();
            Sales = new HashSet<Sale>();
        }

        public int BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
        public int GenreId { get; set; }
        public short Pages { get; set; }
        public short? YearPublished { get; set; }
        public bool IsDeleted { get; set; }
        public decimal? SellingPrice { get; set; }
        public DateTime? DateAdded { get; set; }

        public virtual Author Author { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual ICollection<Reservedbook> Reservedbooks { get; set; }
        public virtual ICollection<Salebook> Salebooks { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}