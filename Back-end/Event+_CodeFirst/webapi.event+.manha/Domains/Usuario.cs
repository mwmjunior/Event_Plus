using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.event_.manha.Domains
{
    [Table("Usuario")]
    [Index(nameof(Email), IsUnique = true)]
    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName ="VARCHAR(100)")]
        [Required(ErrorMessage = "O nome do usuário é obrigatório")]
        public string? Nome { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O E-mail usuário é obrigatório")]
        public string? Email{ get; set; }

        [Column(TypeName = "CHAR(60)")]
        [StringLength(60, MinimumLength =6, ErrorMessage ="A senha deve ter de 6 a 60 caracteres")]
        [Required(ErrorMessage = "A senha do usuário é obrigatório")]
        public string? Senha { get; set; }

        //ref. tabela tipos usuario
        [Required(ErrorMessage ="Informeo tipo do seu usuário ")]
        public Guid IdTipoUsuario { get; set; }

        [ForeignKey(nameof(IdTipoUsuario))]
        public TiposUsuario? TiposUsuario { get; set; }
    }
}
