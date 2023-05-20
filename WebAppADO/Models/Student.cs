using System.ComponentModel.DataAnnotations;

namespace WebAppADO.Models
{
    public class Student
    {
        public int Id { set; get; }
        [Required]
        public string Name { set; get; }
        [Required]
        public string Section { set; get; }
    }
}
