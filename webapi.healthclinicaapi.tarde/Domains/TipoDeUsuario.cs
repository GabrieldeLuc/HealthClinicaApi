using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace webapi.healthclinica.tarde.Domains
{
    [Table(nameof(TipoDeUsuario))]
    public class TipoDeUsuario
    {
        [Key]
        public Guid IdTipodeUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "varchar(100)")]
        [Required(ErrorMessage = "Titulo do Tipo do usuário obrigatório!")]
        public string? TituloTipoUsuario { get; set; }
    }
}
