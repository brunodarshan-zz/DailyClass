using System.ComponentModel.DataAnnotations;
using DailyClass.UserAggregate.Attributes;

namespace DailyClass.UserAggregate {
   public  class User {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage="Nome campo é obrigatório")]
        public string Name { get; set; }

        [Required(ErrorMessage="Documento(CPF) campo é obrigatório")]
        public string Document { get; set; }

        [Required(ErrorMessage="E-mail é obrigatório")]
        [EmailAttribute(ErrorMessage="E-mail inválido")]
        public string Email { get; set; }

    }
}