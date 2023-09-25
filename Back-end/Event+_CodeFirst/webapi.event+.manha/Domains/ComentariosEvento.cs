using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.event_.manha.Domains
{
    [Table(nameof(ComentariosEvento))]
    public class ComentariosEvento
    {
        [Key]
        public Guid IdComentarioEvento { get; set; } = Guid.NewGuid();

        [Column(TypeName ="TEXT")]
        [Required(ErrorMessage = "Comentário é Obrigatório!")]
        public string? Descricao { get; set; }

        [Column(TypeName ="BIT")]
        [Required(ErrorMessage = "A  informação de exibição é obrigatória")]
        public bool? Exibe { get; set; }



        //Referencia  as tabelas de eventos e usuario
        [Required(ErrorMessage = "Usuario é Obrigatório!")]
        public Guid IdUsuario { get; set; }
        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }
        //---------------------------------------------------------//





        [Required(ErrorMessage = "Evento é Obrigatório!")]
        public Guid IdEvento { get; set; }
        [ForeignKey(nameof(IdEvento))]
        public Evento? Evento { get; set; }


    }
}
