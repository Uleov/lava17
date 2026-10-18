using System.Collections.Generic;

namespace UniversityLinqTemplate.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public int PublishYear { get; set; }
    public int PagesCount { get; set; }
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    public List<BookLoan> BookLoans { get; set; } = new();
}
