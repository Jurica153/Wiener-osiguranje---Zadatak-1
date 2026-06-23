using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace InsurePartner.Models
{
    public class Partner
    {
        public int Id { get; set; }

        [Required, StringLength(255, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required, StringLength(255, MinimumLength = 2)]
        public string LastName { get; set; }

        public string Address { get; set; }

        [Required, StringLength(20, MinimumLength = 20)]
        public string PartnerNumber { get; set; }

        [StringLength(11)]
        public string CroatianPIN { get; set; }

        [Required, Range(1, 2)]
        public int PartnerTypeId { get; set; }

        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;

        [Required, EmailAddress, StringLength(255)]
        public string CreatedByUser { get; set; }

        public bool IsForeign { get; set; }

        [Required, StringLength(20, MinimumLength = 10)]
        public string ExternalCode { get; set; }

        [Required]
        public char Gender { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}
