using System;

namespace Journal.Model
{
    /// <summary>Сессия</summary>
    public interface ISessionModel
    {
        /// <summary>Время начала сессии</summary>
        DateTime StartTime { get; set; }

        /// <summary>Время конца сессии</summary>
        DateTime? EndTime { get; set; }
    }
}
