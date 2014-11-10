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
        /// <param name="UserId"></param>
        /// <returns>Последняя открытая сессия</returns>
        Session GetOpenSession(int UserId);

        /// <summary>Получает список всех сессий для указанного пользователя</summary>
        /// <param name="UserId">Идентификатор пользователя</param>
        IList<Session> GetSessions(int UserId);

        /// <summary>Сохраняет изменения, сделанные в сессии</summary>
        /// <param name="Session">Изменённая сессия</param>
        void SaveSessionChanged(Session Session);
    }
}
