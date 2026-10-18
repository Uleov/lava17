# Лабораторная работа: Изучение LINQ и Entity Framework Core
## Тема: Информационная система Библиотека

Данный проект представляет собой реализацию лабораторной работы по изучению технологии LINQ в связке с ORM Entity Framework Core и встраиваемой базой данных SQLite

Проект адаптирован под предметную область Библиотека на основе шаблона и методических указаний

---

## Архитектура проекта

```text
UniversityLinqTemplate/
  Models/
    Category.cs
    Book.cs
    Reader.cs
    BookLoan.cs
  Data/
    UniversityContext.cs
    DbInitializer.cs
  Queries/
    LinqDemos.cs
  Program.cs
UniversityLinqTemplate.sln
UniversityLinqTemplate.slnx
```

---

## Модели данных

Category (Жанр литературы):
Id, Name, Description, Books

Book (Книга фонда):
Id, Title, Author, PublishYear, PagesCount, Price, CategoryId, Category, BookLoans

Reader (Читатель библиотеки):
Id, FullName, PhoneNumber, Email, RegistrationDate, BookLoans

BookLoan (Выдача книги):
Id, LoanDate, ReturnDate, IsReturned, ReaderId, Reader, BookId, Book

---

## Реализованные запросы LINQ

### 1. Фильтрация и сортировка

Выборка книг после 1980 года с сортировкой по убыванию года:

```csharp
var result = db.Books
    .Where(b => b.PublishYear > 1980)
    .OrderByDescending(b => b.PublishYear)
    .ToList();
```

### 2. Проекция в анонимный тип

Выборка названия книги, автора и жанра:

```csharp
var result = db.Books
    .Select(b => new
    {
        b.Title,
        b.Author,
        CategoryName = b.Category != null ? b.Category.Name : "Нет жанра"
    })
    .ToList();
```

### 3. Агрегатные операции

Подсчет общего числа книг, среднего и максимального количества страниц, а также общей стоимости фонда:

```csharp
int totalBooks = db.Books.Count();
double avgPages = db.Books.Average(b => b.PagesCount);
int maxPages = db.Books.Max(b => b.PagesCount);
decimal totalCost = db.Books.Sum(b => b.Price);
```

### 4. Группировка

Группировка книг по жанрам с подсчетом количества книг:

```csharp
var result = db.Books
    .GroupBy(b => b.Category!.Name)
    .Select(g => new
    {
        Category = g.Key,
        Count = g.Count()
    })
    .ToList();
```

### 5. Жадная загрузка связей

Вывод читателей вместе с историей выданных книг:

```csharp
var readers = db.Readers
    .Include(r => r.BookLoans)
        .ThenInclude(bl => bl.Book)
    .ToList();
```

---

## Запуск проекта

Запуск в Visual Studio:
Открыть файл UniversityLinqTemplate.sln и нажать Ctrl + F5

Запуск через .NET CLI:
```bash
dotnet run --project UniversityLinqTemplate/UniversityLinqTemplate.csproj
```

---

## Стек технологий

Язык: C#
Платформа: .NET
ORM: Entity Framework Core
СУБД: SQLite
Технология запросов: LINQ