using System;
using System.Collections.Generic;

namespace Journal.Model
{
    /// <summary>Тип поиска в интервале времени</summary>
    public enum TimeIntervalSearchOption
    {
        /// <summary>Все события должны находиться внутри интервала поиска</summary>
        Inner,

        /// <summary>События должны полностью покрывать интервал поиска</summary>
        Outer
    }

    /// <summary>Провайдер сессий</summary>
    public interface ISessionModelProvider
    {
        /// <summary>Находит список сессий для пользователя в указанном интервале времени</summary>
        /// <param name="User">Пользователь</param>
        /// <param name="StartTime">Начало интервала для поиска</param>
        /// <param name="EndTime">Конец интервала для поиска</param>
        /// <param name="IntervalSearchOption">Опция поиска в интервале времени</param>
        IList<SessionModel> GetSessionsForUser(UserModel User, DateTime StartTime, DateTime EndTime,
                                               TimeIntervalSearchOption IntervalSearchOption = TimeIntervalSearchOption.Outer);

        /// <summary>Получает <paramref name="Count" /> последних сессий для указанного пользователя</summary>
        /// <param name="User">Пользователь</param>
        /// <param name="Count">Количество последних сессий</param>
        IList<SessionModel> GetLastSessions(UserModel User, int Count);
    }
}
