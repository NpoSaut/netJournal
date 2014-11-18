using System;

namespace Journal.Data.Sql.Repositories
{
    public abstract class ContextRepository : IDisposable
    {
        protected readonly JournalDataContext Context = new JournalDataContext();

        /// <summary>Выполняет определяемые приложением задачи, связанные с высвобождением или сбросом неуправляемых ресурсов.</summary>
        public void Dispose() { Context.Dispose(); }
    }
}
