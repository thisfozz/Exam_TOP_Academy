using Exam_TOP_Academy.DataAccess.Configurations;
using Exam_TOP_Academy.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;

namespace Exam_TOP_Academy.DataAccess.Contexts;

public partial class BookStoreContext : DbContext
{
    private readonly IConfiguration configuration;

    public BookStoreContext()
    {
    }

    public BookStoreContext(IConfiguration configuration)
    {
        this.configuration = configuration;
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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(configuration.GetConnectionString("BooksConnectionString"));
        optionsBuilder.LogTo(s => Debug.WriteLine(s));
        optionsBuilder.EnableSensitiveDataLogging();
        optionsBuilder.UseLazyLoadingProxies();
    }

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

        OnModelCreatingPartial(modelBuilder);
    }

    public void AddUser(Registereduser newUser)
    {
        Registeredusers.Add(newUser);
        SaveChanges();
    }

    public void AddSale(Sale newSale)
    {
        Sales.Add(newSale);
        SaveChanges();
    }


    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
