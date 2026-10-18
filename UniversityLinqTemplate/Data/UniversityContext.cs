using Microsoft.EntityFrameworkCore;
using UniversityLinqTemplate.Models;

namespace UniversityLinqTemplate.Data;

public class UniversityContext : DbContext
{
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Book> Books => Set<Book>();
    public DbSet<Reader> Readers => Set<Reader>();
    public DbSet<BookLoan> BookLoans => Set<BookLoan>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=library.db");
    }
}
