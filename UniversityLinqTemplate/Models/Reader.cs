using System;
using System.Collections.Generic;

namespace UniversityLinqTemplate.Models;

public class Reader
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime RegistrationDate { get; set; }
    public List<BookLoan> BookLoans { get; set; } = new();
}
