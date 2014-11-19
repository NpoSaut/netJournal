using System;
using System.Collections.Generic;
using System.Linq;
using Journal.Data;
using Journal.Data.Sql;

namespace DatabaseDemoPumper
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Вы действительно хотите заполнить базу данных данными по-умолчанию?");
            Console.ResetColor();
            Console.WriteLine("Введите \"y\", чтобы продолжить");
            if (Console.ReadLine() != "y") return;

            const int daysToInsert = 40;
            DateTime endDate = DateTime.Today;
            DateTime startDate = endDate.AddDays(-daysToInsert);
            var r = new Random();

            //var users = new[]
            //            {
            //                //new User("Плюснин Евгений Александрович"),
            //                //new User("Наземных Антон Дмитриевич"),
            //                //new User("Дятлов Дмитрий Карпович")
            //            };

            //using (var context = new JournalDataModel())
            //{
            //    foreach (User u in users)
            //    {
            //        User user = u;
            //        context.Users.Add(user);

            //        IEnumerable<Session> sessions = Enumerable.Range(0, daysToInsert)
            //                                                  .Select(i => new Session(startDate.AddDays(i).AddHours(9 + r.NextDouble()),
            //                                                                           startDate.AddDays(i).AddHours(17.5 + 1.3 * r.NextDouble()),
            //                                                                           user));
            //        context.Sessions.AddRange(sessions);
            //    }
            //    context.SaveChanges();
            //}
        }
    }
}
