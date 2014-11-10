using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Journal.Data
{
    public class User
    {
        public User() { Sessions = new HashSet<Session>(); }

        public User(string Name) : this() { this.Name = Name; }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Session> Sessions { get; set; }
    }
}
