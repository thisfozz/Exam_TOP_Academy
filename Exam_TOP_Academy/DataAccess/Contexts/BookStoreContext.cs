using Exam_TOP_Academy.DataAccess.Configurations;
using Exam_TOP_Academy.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Exam_TOP_Academy.DataAccess.Contexts;

public partial class BookStoreContext : DbContext
{
    public BookStoreContext()
    {
    }

    public BookStoreContext(DbContextOptions<BookStoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Promotion> Promotions { get; set; }

    public virtual DbSet<Publisher> Publishers { get; set; }

    public virtual DbSet<Registereduser> Registeredusers { get; set; }

    public virtual DbSet<Reservedbook> Reservedbooks { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<Salebook> Salebooks { get; set; }

    public virtual DbSet<Sequel> Sequels { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=this;Password=this;Database=BookStore;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AuthorConfiguration());
        modelBuilder.ApplyConfiguration(new BookConfiguration());
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        modelBuilder.ApplyConfiguration(new GenreConfiguration());
        modelBuilder.ApplyConfiguration(new PromotionConfiguration());
        modelBuilder.ApplyConfiguration(new PublisherConfiguration());
        modelBuilder.ApplyConfiguration(new RegistereduserConfiguration());
        modelBuilder.ApplyConfiguration(new ReservedbookConfiguration());
        modelBuilder.ApplyConfiguration(new SaleConfiguration());
        modelBuilder.ApplyConfiguration(new SalebookConfiguration());
        modelBuilder.ApplyConfiguration(new SequelConfiguration());

        OnModelCreatingPartial(modelBuilder);
    }

    public void AddUser(Registereduser newUser)
    {
        Registeredusers.Add(newUser);
        SaveChanges();
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
