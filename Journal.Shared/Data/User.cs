using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Journal.Shared.Data
{
    public class User
    {
        public User() { Sessions = new HashSet<Session>(); }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Session> Sessions { get; set; }
    }
}
