namespace Journal.Shared.Data
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
    }
}
