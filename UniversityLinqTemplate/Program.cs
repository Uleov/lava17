using System;
using UniversityLinqTemplate.Data;
using UniversityLinqTemplate.Queries;

using (var db = new UniversityContext())
{
    Console.WriteLine("Инициализация базы данных...");
    DbInitializer.Initialize(db);
    Console.WriteLine("База данных готова к работе.\n");

    LinqDemos.DemoFilteringAndSorting(db);
    LinqDemos.DemoProjection(db);
    LinqDemos.DemoAggregations(db);
    LinqDemos.DemoGrouping(db);
    LinqDemos.DemoJoinsAndIncludes(db);
}

Console.WriteLine("\nНажмите любую клавишу для завершения...");
if (!Console.IsInputRedirected)
{
    Console.ReadKey();
}