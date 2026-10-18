using System;

namespace UniversityLinqTemplate.Models;

public class BookLoan
{
    public int Id { get; set; }
    public DateTime LoanDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public bool IsReturned { get; set; }
    public int ReaderId { get; set; }
    public Reader? Reader { get; set; }
    public int BookId { get; set; }
    public Book? Book { get; set; }
}
