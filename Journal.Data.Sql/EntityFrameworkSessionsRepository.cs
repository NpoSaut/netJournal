using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

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
        /// <param name="UserId"></param>
        /// <returns>Последняя открытая сессия</returns>
        public Session GetOpenSession(int UserId)
        {
            using (var context = new JournalDataModel())
            {
                return context.Sessions.Where(s => s.UserId == UserId).SingleOrDefault(s => s.EndTime == null);
            }
        }

        /// <summary>Получает список всех сессий для указанного пользователя</summary>
        /// <param name="UserId">Идентификатор пользователя</param>
        public IList<Session> GetSessions(int UserId)
        {
            using (var context = new JournalDataModel())
            {
                return context.Sessions.Where(s => s.UserId == UserId).ToList();
            }
        }

        /// <summary>Сохраняет изменения, сделанные в сессии</summary>
        /// <param name="Session">Изменённая сессия</param>
        public void SaveSessionChanged(Session Session)
        {
            using (var context = new JournalDataModel())
            {
                context.Sessions.AddOrUpdate(Session);
                context.SaveChanges();
            }
        }
    }
}
