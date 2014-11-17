using System;

namespace Journal.Model
{
    /// <summary>������</summary>
    public interface ISessionModel
    {
        /// <summary>����� ������ ������</summary>
        DateTime StartTime { get; set; }

        /// <summary>����� ����� ������</summary>
        DateTime? EndTime { get; set; }
    }
}
