using System;
using System.Linq;

namespace Journal.Model
{
    /// <summary>������������</summary>
    public interface IUserModel
    {
        /// <summary>AD-�����</summary>
        string LoginName { get; set; }

        /// <summary>���</summary>
        String Name { get; set; }

        /// <summary>�������</summary>
        String Surname { get; set; }

        /// <summary>��������</summary>
        String Patronymic { get; set; }
    }
}
