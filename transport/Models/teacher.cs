using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace transport.Models
{
    public class teacher
    {
        [Key]
        [DisplayName("ID")]
        public int teacherid { get; set; }

        [DisplayName("اسم المعلم")]
        [Column(TypeName = "varchar(250)")]
        public string teacherName { get; set; } = string.Empty;

        [DisplayName("المدينة ")]
        public string city { get; set; } = string.Empty;

        [DisplayName("تاريخ الميلاد")] [DataType(DataType.Date)]
        public DateTime birth { get; set; }

        [DisplayName("اخر نقل")]
        [DataType(DataType.Date)]
        public DateTime last { get; set; }

        [DisplayName("تاريخ التعيين")]
        [DataType(DataType.Date)]
        public DateTime hire { get; set; }

        public int desireid { get; set; }

        [ForeignKey("desireid")]
        public desire? desire { get; set; }
    }
}
