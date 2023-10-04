using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinica.tarde.Domains
{
    [Table(nameof(Medico))]
    public class Medico
    {

        [Key]
        public Guid IdMedico { get; set; } = Guid.NewGuid();


        [Column(TypeName = ("Varchar(13)"))]
        [Required(ErrorMessage = "O CRM do Médico é obrigatório")]
      
        public string? CRM { get; set; }

        [Required(ErrorMessage = "Usuario necessário")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }

        [Required(ErrorMessage = "Especialidade necessária. ")]
        public Guid IdEspecialidade { get; set; }

        [ForeignKey(nameof(IdEspecialidade))]
        public Especialidade? Especialidade { get; set; }

        [Required(ErrorMessage = "Clínica necessária.")]
        public Guid IdClinica { get; set; }

        [ForeignKey(nameof(IdClinica))]
        public ClinicaDomain? Clinica { get; set; }





    }
}
