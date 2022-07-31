using System.ComponentModel;

namespace transport.Models
{
    public class student
    {
        public int Id { get; set; }

        [DisplayName("اسم الطالب")]
        public string Name { get; set; }= String.Empty;
    }
}
