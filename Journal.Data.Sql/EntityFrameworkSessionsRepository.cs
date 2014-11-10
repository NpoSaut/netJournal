using System;
using System.Data.Entity.Migrations;
using System.Linq;
using Journal.Shared.Data;

namespace Journal.Data.Sql
{
    /// <summary>Репозиторий сессий, работающий через EntityFramework</summary>
    public class EntityFrameworkSessionsRepository : ISessionRepository
    {
        /// <summary>Добавляет новую сессию в базу данных</summary>
        /// <param name="Session">Сессия для добавления</param>
        public void AddSession(Session Session)
        {
            using (var context = new JournalDataModel())
            {
                context.Sessions.AddOrUpdate(Session);
                context.SaveChanges();
            }
        }

        /// <summary>Получает последнюю открытую сессию</summary>
        /// <returns>Последняя открытая сессия</returns>
        public Session GetOpenSession()
        {
            using (var context = new JournalDataModel())
            {
                return context.Sessions.SingleOrDefault(s => s.EndTime == null);
            }
        }
    }
}
