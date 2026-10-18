using System;
using System.Linq;
using UniversityLinqTemplate.Models;

namespace UniversityLinqTemplate.Data;

public static class DbInitializer
{
    public static void Initialize(UniversityContext context)
    {
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        if (context.Books.Any())
            return;

        var catProg = new Category { Name = "Программирование", Description = "Книги по разработке ПО" };
        var catSciFi = new Category { Name = "Фантастика", Description = "Научная фантастика" };
        var catClassic = new Category { Name = "Классика", Description = "Классическая литература" };
        var catDetective = new Category { Name = "Детективы", Description = "Детективные романы" };

        context.Categories.AddRange(catProg, catSciFi, catClassic, catDetective);

        var b1 = new Book { Title = "CLR via C#", Author = "Джеффри Рихтер", PublishYear = 2019, PagesCount = 896, Price = 3000, Category = catProg };
        var b2 = new Book { Title = "Чистый код", Author = "Роберт Мартин", PublishYear = 2018, PagesCount = 464, Price = 2000, Category = catProg };
        var b3 = new Book { Title = "Дюна", Author = "Фрэнк Герберт", PublishYear = 1965, PagesCount = 704, Price = 1200, Category = catSciFi };
        var b4 = new Book { Title = "Солярис", Author = "Станислав Лем", PublishYear = 1961, PagesCount = 288, Price = 700, Category = catSciFi };
        var b5 = new Book { Title = "Преступление и наказание", Author = "Федор Достоевский", PublishYear = 1866, PagesCount = 592, Price = 800, Category = catClassic };
        var b6 = new Book { Title = "Война и мир", Author = "Лев Толстой", PublishYear = 1869, PagesCount = 1300, Price = 2500, Category = catClassic };
        var b7 = new Book { Title = "Приключения Шерлока Холмса", Author = "Артур Конан Дойл", PublishYear = 1892, PagesCount = 320, Price = 750, Category = catDetective };

        context.Books.AddRange(b1, b2, b3, b4, b5, b6, b7);

        var r1 = new Reader { FullName = "Иван Иванов", PhoneNumber = "89991112233", Email = "ivan@mail.ru", RegistrationDate = DateTime.Now.AddMonths(-6) };
        var r2 = new Reader { FullName = "Петр Петров", PhoneNumber = "89992223344", Email = "petr@mail.ru", RegistrationDate = DateTime.Now.AddMonths(-4) };
        var r3 = new Reader { FullName = "Анна Сидорова", PhoneNumber = "89993334455", Email = "anna@mail.ru", RegistrationDate = DateTime.Now.AddMonths(-2) };

        context.Readers.AddRange(r1, r2, r3);

        context.BookLoans.AddRange(
            new BookLoan { Reader = r1, Book = b1, LoanDate = DateTime.Now.AddDays(-20), IsReturned = false },
            new BookLoan { Reader = r1, Book = b3, LoanDate = DateTime.Now.AddDays(-50), ReturnDate = DateTime.Now.AddDays(-30), IsReturned = true },
            new BookLoan { Reader = r2, Book = b2, LoanDate = DateTime.Now.AddDays(-15), IsReturned = false },
            new BookLoan { Reader = r2, Book = b5, LoanDate = DateTime.Now.AddDays(-40), ReturnDate = DateTime.Now.AddDays(-10), IsReturned = true },
            new BookLoan { Reader = r3, Book = b7, LoanDate = DateTime.Now.AddDays(-5), IsReturned = false }
        );

        context.SaveChanges();
    }
}
