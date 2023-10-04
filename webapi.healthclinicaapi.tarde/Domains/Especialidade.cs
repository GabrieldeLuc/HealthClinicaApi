using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinica.tarde.Domains
{
    [Table(nameof(Especialidade))]
    public class Especialidade
    {
        [Key]

        public Guid IdEspecialidade { get; set; } = Guid.NewGuid();


        [Column(TypeName = ("Varchar(50)"))]
        [Required(ErrorMessage = "A Especialidade é obrigatória")]
     
        public string? TipoEspecialidade { get; set; }
    }
}
