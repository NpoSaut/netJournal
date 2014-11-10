using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace Journal.Data
{
    public class SessionsRepository
    {
        public void Add(int st, int et)
        {
            DateTime startTime = DateTime.Today.AddHours(st);
            DateTime endTime = DateTime.Today.AddHours(et);

            using (var context = new JournalDataModelContainer())
            {
                context.Sessions.AddOrUpdate(new Session { StartTime = startTime, EndTime = endTime });
                context.SaveChanges();
            }
        }
    }
}