using System.ComponentModel.DataAnnotations;

namespace Quick.Students.Domain.Entities
{
    public class Student:BaseEntity<int>
    {
        [Key]
        public override int Id { get; set; }

        public Family Family { get; set; } = new Family();
        public int FamilyId { get; set; }

        [StringLength(255,MinimumLength =3)]
        [Required]
        public string FName { get; set; } = string.Empty;
        [StringLength(255, MinimumLength = 3)]
        [Required]
        public string LName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
    }
}
