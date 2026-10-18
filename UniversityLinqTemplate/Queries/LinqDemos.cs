using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using UniversityLinqTemplate.Data;

namespace UniversityLinqTemplate.Queries;

public static class LinqDemos
{
    public static void DemoFilteringAndSorting(UniversityContext db)
    {
        Console.WriteLine("1. Фильтрация и сортировка (книги после 1980 года):");

        var result = db.Books
            .Where(b => b.PublishYear > 1980)
            .OrderByDescending(b => b.PublishYear)
            .ToList();

        foreach (var b in result)
        {
            Console.WriteLine($"{b.Title} - {b.Author} ({b.PublishYear} год)");
        }
    }

    public static void DemoProjection(UniversityContext db)
    {
        Console.WriteLine("\n2. Проекция (название книги и жанр):");

        var result = db.Books
            .Select(b => new
            {
                b.Title,
                b.Author,
                CategoryName = b.Category != null ? b.Category.Name : "Нет жанра"
            })
            .ToList();

        foreach (var item in result)
        {
            Console.WriteLine($"{item.Title} ({item.Author}) - Жанр: {item.CategoryName}");
        }
    }

    public static void DemoAggregations(UniversityContext db)
    {
        Console.WriteLine("\n3. Агрегатные операции:");

        int totalBooks = db.Books.Count();
        double avgPages = db.Books.Average(b => b.PagesCount);
        int maxPages = db.Books.Max(b => b.PagesCount);
        decimal totalCost = db.Books.Sum(b => b.Price);

        Console.WriteLine($"Всего книг: {totalBooks}");
        Console.WriteLine($"Среднее количество страниц: {avgPages:F1}");
        Console.WriteLine($"Максимальное количество страниц: {maxPages}");
        Console.WriteLine($"Общая стоимость книг: {totalCost}");
    }

    public static void DemoGrouping(UniversityContext db)
    {
        Console.WriteLine("\n4. Группировка (количество книг по жанрам):");

        var result = db.Books
            .GroupBy(b => b.Category!.Name)
            .Select(g => new
            {
                Category = g.Key,
                Count = g.Count()
            })
            .ToList();

        foreach (var item in result)
        {
            Console.WriteLine($"Жанр: {item.Category}, книг: {item.Count}");
        }
    }

    public static void DemoJoinsAndIncludes(UniversityContext db)
    {
        Console.WriteLine("\n5. Связи (читатели и взятые ими книги):");

        var readers = db.Readers
            .Include(r => r.BookLoans)
                .ThenInclude(bl => bl.Book)
            .ToList();

        foreach (var r in readers)
        {
            Console.WriteLine($"Читатель: {r.FullName}");
            foreach (var loan in r.BookLoans)
            {
                string status = loan.IsReturned ? "возвращена" : "на руках";
                Console.WriteLine($"  Книга: {loan.Book?.Title} ({status})");
            }
        }
    }
}
