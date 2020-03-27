using System.ComponentModel.DataAnnotations;
using DailyClass.Domains.Shareds;

namespace DailyClass.Domains.CourseAggregate
{
    public class Course : IEntity
    {
        [Key]
        public int id { get; set; }

        [Required]
        [MinLength(4, ErrorMessage="Este campo deve conter entre 10 e 120 caracteres")]
        [MaxLength(100, ErrorMessage="Este campo deve conter entre 10 e 120 caracteres")]
        public string Name  { get; set; }
        

    }
}