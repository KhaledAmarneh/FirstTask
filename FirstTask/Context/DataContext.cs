using FirstTask.Entities;
using Microsoft.EntityFrameworkCore;


public class DataContext : DbContext
{
    public DataContext(DbContextOptions
    <DataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasMany(b => b.Books)
            .WithMany(bm => bm.Authors);

            entity.HasMany(a => a.BooksAuthors)
            .WithOne(ba => ba.Author)
            .HasForeignKey(baf => baf.AuthorId);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasMany(b => b.BooksAuthors)
            .WithOne(ba => ba.Book)
            .HasForeignKey(baf => baf.BookId);

        });

        modelBuilder.Entity<BookAuthor>(entity =>
        {
            entity.HasKey(t => new { t.BookId, t.AuthorId });

        });

    }

    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }

    public DbSet<BookAuthor> BooksAuthors { get; set; }



}
