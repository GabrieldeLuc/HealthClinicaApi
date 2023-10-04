using Microsoft.EntityFrameworkCore.Query.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinica.tarde.Domains
{
    [Table(nameof(ClinicaDomain))]
    public class ClinicaDomain
    {
        [Key]
        public Guid IdClinica { get; set; } = Guid.NewGuid();

   
        [Column(TypeName = ("Varchar(50)"))]
        [Required(ErrorMessage = "O nome da Clinica é obrigatório")]
       
        public string NomeClinica { get; set; }

        [Column(TypeName = ("Varchar(50)"))]
        [Required(ErrorMessage = "O Nome Fantasia é obrigatório")]
        public string?  NomeFantasia { get; set; }

        [Column(TypeName = ("Varchar(70)"))] 
        [Required(ErrorMessage = "O Endereço da Clinica é obrigatório")]
      
        public string EnderecoClinica { get; set; }


        [Column(TypeName = ("Varchar(14)"))]
        [Required(ErrorMessage = "O CNPJ da Clinica é obrigatório")]
      
        public int CNPJ { get; set; }


        [Column(TypeName = ("Varchar(100)"))]
        [Required(ErrorMessage = "A Razão Social da Clinica é obrigatória")]
      
        public string RazaoSocial { get; set; }

        [Column(TypeName = "Text")]
        [Required(ErrorMessage = "Obrigatorio horário de Abertura.")]
        public string  HorarioAbertura { get; set; }

        [Column(TypeName = "Text")]
        [Required(ErrorMessage = "Obrigatório horário de Fechamento.")]
        public string HorarioFechamento { get; set; }




    }
}
