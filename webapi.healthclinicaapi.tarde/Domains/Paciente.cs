using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinica.tarde.Domains
{
    [Table(nameof(Paciente))]
    public class Paciente
    {
        [Key]
        public Guid IdPaciente { get; set; } = Guid.NewGuid();



        [Column(TypeName = ("Varchar(15)"))]
        [Required(ErrorMessage = "O Telefone do Paciente é obrigatório")]
    
        public string? Telefone { get; set; }

        [Column(TypeName = ("Varchar(8)"))]
        [Required(ErrorMessage = "O RG do Paciente é obrigatório")]
 
        public string? RG { get; set; }

        [Column(TypeName = ("Varchar(11)"))]
        [Required(ErrorMessage = "O CPF do Paciente  é obrigatório")]
       
        public string? CPF { get; set; }

        [Column(TypeName = ("Varchar(8)"))]
        [Required(ErrorMessage = "O CEP do Paciente é obrigatório")]

        public string CEP { get; set; } 


       [Column(TypeName = ("Varchar(70)"))]
       [Required(ErrorMessage = "O Endereço do Paciente  é obrigatório")]
    
       public string? Endereco { get; set; }


    }
}
