using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProsperaModel.Models
{
    public class ContasPagarModel
    {
        [Key]
        public int IdContasPagar { get; set; }

        public int CodCP { get; set; }

        [DataType(DataType.Date)]
        public DateTime DatEmissaoCP { get; set; }

        [DataType(DataType.Date)]
        public DateTime DatVencimentoCP { get; set; }

        [StringLength(120)]
        public string DevedorCP { get; set; }

        [StringLength(80)]
        public string DescricaoCP { get; set; }

        [DataType(DataType.Currency)]
        public decimal ValorCP { get; set; }

        [StringLength(20)]
        public string StatusCP { get; set; }

        [StringLength(20)]
        public string MetodoPgtoCP { get; set; }

        [StringLength(80)]
        public string ObservacaoCP { get; set; }

        public int ContaBanCP { get; set; }
        public int AgenciaContBanCP { get; set; }
        public int UsuarioCP { get; set; }

        [ForeignKey("UsuarioCP")]
        public virtual UsuarioModel IdUsuario { get; set; }
    }
}
