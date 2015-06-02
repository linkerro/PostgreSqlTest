using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbAccess
{
    [Table("public.Contacts")]
    public partial class Contact
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(200)]
        public string Address { get; set; }

        [Required]
        [StringLength(10)]
        public string Phone { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        [Required]
        public bool HasOptedOut { get; set; }

        public int CreatedBy { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public int ModifiedBy { get; set; }

        public DateTimeOffset ModifiedOn { get; set; }

        public virtual User CreatedByUser { get; set; }

        public virtual User ModifiedByUser { get; set; }
    }
}
