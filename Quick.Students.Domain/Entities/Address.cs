using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quick.Students.Domain.Entities
{
    public class Address:BaseEntity<int>
    {
        public Guardian Guardian { get; set; } = new Guardian();
        [Key, ForeignKey("Guardian")]
        public override int Id { get; set; }
        [Required]
        public string Adress { get; set; } = string.Empty;
        public string Adress2 { get; set; } = string.Empty;

        [StringLength(10)]
        public int PostCode { get; set; }

    }
}
