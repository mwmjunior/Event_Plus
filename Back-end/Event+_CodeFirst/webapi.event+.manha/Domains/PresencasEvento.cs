using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.event_.manha.Domains
{
    [Table(nameof(PresencasEvento))]
    public class PresencasEvento
    {
        [Key]
        public Guid IdPresencaEvento { get; set; } = Guid.NewGuid();

        [Column(TypeName ="BIT")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public bool Situacao { get; set; }

        //Ref. as tabelas eventos e usuario
        [Required(ErrorMessage = "O Usuario é obrigatório!")]
        public Guid IdUsuario { get; set; }
        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }
        //---------------------------------------------------------//
        [Required(ErrorMessage = "Campo obrigatório!")]
        public Guid IdEvento { get; set; }
        [ForeignKey(nameof(IdEvento))]
        public Evento? Evento { get; set; }
    }
}
