using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quick.Students.Domain.Entities
{
    public class Guardian:BaseEntity<int>
    {
        [Key]
        public override int Id { get; set; }

        public Family Family { get; set; } = new Family();
        public int FamilyId { get; set; }

        public Address Address { get; set; } = new Address();

        public GuardianType GuardianType { get; set; } = new GuardianType();
        public int GuardianTypeId { get; set; }
        [Required]
        [StringLength(255,MinimumLength =3)]
        public string FName { get; set; } = string.Empty;
        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string LName { get; set; } = string.Empty;
        [Required]
        [StringLength(254,MinimumLength =3)]
        public string Email { get; set; } = string.Empty;
        [Required]
        [MaxLength(15)]
        public string PhoneNumber { get; set; } = string.Empty;

    }
}
