using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbAccess
{
    [Table("public.Users")]
    public partial class User
    {
        public User()
        {
            Contacts = new HashSet<Contact>();
            Contacts1 = new HashSet<Contact>();
        }

        public int Id { get; set; }

        [StringLength(20)]
        public string FirstName { get; set; }

        [StringLength(20)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(250)]
        public string Email { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }

        public virtual ICollection<Contact> Contacts1 { get; set; }
    }
}
