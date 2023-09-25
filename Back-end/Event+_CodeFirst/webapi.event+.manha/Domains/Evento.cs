using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace webapi.event_.manha.Domains
{
    [Table(nameof(Evento))]
    public class Evento
    {
        [Key]
        public Guid IdEvento { get; set; } = Guid.NewGuid();

        [Column(TypeName ="DATE")]
        [Required(ErrorMessage = "A Data do evento é Obrigatória")]
        public DateTime DataEvento { get; set; }

        [Column(TypeName ="VARCHAR(100)")]
        [Required(ErrorMessage = "O Nome do evento é Obrigatório")]
        public string? NomeEvento { get; set; }

        [Column(TypeName ="TEXT")]
        [Required(ErrorMessage = "A descrição do Evento é obrigatória")]
        public string? Descricao { get; set; }

        //Referencia  as tabelas dos tipos eventos e instituicao
        [Required]
        public Guid IdTipoEvento { get; set; }
        [ForeignKey(nameof(IdTipoEvento))]
        public TiposEvento? TiposEvento { get; set; }

        //---------------------------------------------------------//


        [Required]
        public Guid IdInstituicao { get; set; }
        [ForeignKey(nameof(IdInstituicao))]
        public Instituicao? Instituicao { get; set; }
    }
}
