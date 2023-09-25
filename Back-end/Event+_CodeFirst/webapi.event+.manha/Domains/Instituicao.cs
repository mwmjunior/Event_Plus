using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.event_.manha.Domains
{
    [Table(nameof(Instituicao))]
    [Index(nameof(CNPJ), IsUnique = true)]
    public class Instituicao
    {
        [Key]
        public Guid IdInstituicao { get; set; } = Guid.NewGuid();

        [Column(TypeName ="CHAR(14)")]
        [Required(ErrorMessage = "O CNPJ da empresa é Obrigatório")]
        [StringLength(14)]
        public string? CNPJ { get; set; }

        [Column(TypeName = "VARCHAR(150)")]
        [Required(ErrorMessage = "O Endereço é Obrigatório")]
        public string? Endereco { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O Nome é Obrigatório")]
        public string? NomeFantasia { get; set; }
    }
}
