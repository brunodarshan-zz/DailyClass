using System.ComponentModel.DataAnnotations;
using DailyClass.Domains.Shareds;
using DailyClass.Domains.CourseAggregate;

namespace DailyClass.Domains.ModuleAggregate
{
    public class Module : IEntity
    {
        [Key]
        public int id { get; set; }

        [Required]
        [MinLength(4, ErrorMessage="Este campo deve conter entre 10 e 120 caracteres")]
        [MaxLength(100, ErrorMessage="Este campo deve conter entre 10 e 120 caracteres")]
        public string Name  { get; set; }

        [Required(ErrorMessage="Campo obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Course is required")]
        public int CourseId { get; set; }
        public Course Course { get; set; }
        

    }
}