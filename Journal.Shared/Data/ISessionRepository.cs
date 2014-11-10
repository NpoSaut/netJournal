using System.Collections.Generic;

namespace Journal.Data
{
    /// <summary>Репозиторий сессий</summary>
    public interface ISessionRepository
    {
        /// <summary>Добавляет новую сессию в базу данных</summary>
        /// <param name="Session">Сессия для добавления</param>
        void AddSession(Session Session);

        /// <summary>Получает последнюю открытую сессию</summary>
        /// <returns>Последняя открытая сессия</returns>
        Session GetOpenSession();

        /// <summary>Получает список всех сессий для указанного пользователя</summary>
        /// <param name="UserId">Идентификатор пользователя</param>
        IList<Session> GetSessions(int UserId);
    }
}
