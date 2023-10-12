using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProsperaModel.Models
{
    public class OrcamentoModel
    {
        [Key]
        public int IdOrcamento { get; set; }

        [StringLength(25)]
        public string NomeOrca { get; set; }

        [DataType(DataType.Date)]
        public DateTime DatEmissaoOrca { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataValidadeOrca { get; set; }

        [StringLength(80)]
        public string DescricaoOrca { get; set; }

        [DataType(DataType.Currency)]
        public decimal ValorOrca { get; set; }

        [StringLength(80)]
        public string ObservacaoOrca { get; set; }

        [StringLength(20)]
        public string StatusOrca { get; set; }

        [StringLength(120)]
        public string NomeContatoOrca { get; set; }

        [StringLength(20)]
        public string TeleOrca { get; set; }

        [StringLength(20)]
        public string Tele2Orca { get; set; }

        [StringLength(120)]
        public string EmailOrca { get; set; }

        [StringLength(80)]
        public string EnderecoOrca { get; set; }

        [StringLength(80)]
        public string EstadoOrca { get; set; }

        [StringLength(80)]
        public string BairroOrca { get; set; }

        public int UsuarioOrca { get; set; }

        [ForeignKey("UsuarioOrca")]
        public virtual UsuarioModel IdUsuario { get; set; }
    }
}
