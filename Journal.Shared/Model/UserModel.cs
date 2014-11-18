using System;

namespace Journal.Model
{
    public class UserModel
    {
        public UserModel(int Id, string Login, PersonName FullName)
        {
            this.Id = Id;
            this.Login = Login;
            this.FullName = FullName;
        }

        public int Id { get; private set; }
        public String Login { get; private set; }
        public PersonName FullName { get; private set; }
    }
}
