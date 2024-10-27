using LibraryPlatform.Models;
namespace LibraryPlatform.Database;
using Microsoft.EntityFrameworkCore;

public class LibraryContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<Loan> Loans { get; set; }
    public DbSet<LibraryStaff> LibraryStaffs { get; set; }
    public DbSet<Category> Categories { get; set; }

    // Constructor that accepts DbContextOptions
    public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Optional: This ensures the method is only used if no configuration is passed via DI.
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=libdb;Username=libuser;Password=1234");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Optional: configure entity relationships and other EF configurations here
    }
    public override int SaveChanges()
    {
        foreach (var entry in ChangeTracker.Entries<Book>())
        {
            if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
            {
                // Convert PublishedDate to UTC if it's not already in UTC
                if (entry.Entity.PublishedDate.Kind != DateTimeKind.Utc)
                {
                    entry.Entity.PublishedDate = DateTime.SpecifyKind(entry.Entity.PublishedDate, DateTimeKind.Utc);
                }
            }
        }

        return base.SaveChanges();
    }
    

}
