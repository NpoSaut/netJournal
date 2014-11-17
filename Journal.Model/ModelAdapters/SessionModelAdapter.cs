using System;
using Journal.Data.Sql.Entities;

namespace Journal.Model.ModelAdapters
{
    internal class SessionModelAdapter : ISessionModel
    {
        private readonly Session _session;
        public SessionModelAdapter(Session Session) { _session = Session; }

        /// <summary>Время начала сессии</summary>
        public DateTime StartTime
        {
            get { return _session.StartTime; }
            set { _session.StartTime = value; }
        }

        /// <summary>Время конца сессии</summary>
        public DateTime? EndTime
        {
            get { return _session.EndTime; }
            set { _session.EndTime = value; }
        }
    }
}