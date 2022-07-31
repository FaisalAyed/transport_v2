using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace transport.Models
{
    public class desire
    {
        [Key]
        public int desireid { get; set; }

        [Required]
        [DisplayName("نوع الرغبة")]
        [Column(TypeName="varchar(200)")]
        public string desirename { get; set; }=String.Empty;
    }
}
