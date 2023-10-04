using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinica.tarde.Domains
{
    [Table(nameof(Usuario))]
    public class Usuario
    {

        [Key]
        public Guid IdUsuario{ get; set; } = Guid.NewGuid();

        [Column(TypeName = "varchar(100)")]
        [Required(ErrorMessage = "Nome é obrigatório!")]
        public string? Nome { get; set; }


        [Column(TypeName = "Varchar(50)")]
        [Required(ErrorMessage = "Email é obrigatório!")]
        public string? Email { get; set; }


        [Column(TypeName = "char(50)")]
        [Required(ErrorMessage = "Senha é obrigatória!")]
        [StringLength(60, MinimumLength = 6, ErrorMessage = "Senha deve conter de 6 a 60 caracteres")]
        public string? Senha { get; set; }


        // referencia tabela tipo usuario = FK 
        [Required(ErrorMessage = "O tipo do Usuario é obrigatório.")]
        public Guid IdTipodeUsuario { get; set; }


        [ForeignKey(nameof(IdTipodeUsuario))]
        public TipoDeUsuario? TipodeUsuario { get; set; }
    }
}
