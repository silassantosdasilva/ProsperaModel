using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProsperaModel.Models
{
    public class ContasReceberModel
    {
        [Key]
        public int IdContasReceber { get; set; }

        public int CodCR { get; set; }

        [DataType(DataType.Date)]
        public DateTime DatEmissaoCR { get; set; }

        [DataType(DataType.Date)]
        public DateTime DatVencimentoCR { get; set; }

        [StringLength(120)]
        public string DevedorCR { get; set; }

        [StringLength(80)]
        public string DescricaoCR { get; set; }

        [DataType(DataType.Currency)]
        public decimal ValorCR { get; set; }

        [StringLength(20)]
        public string StatusCR { get; set; }

        [StringLength(20)]
        public string MetodoPgtoCR { get; set; }

        [StringLength(80)]
        public string ObservacaoCR { get; set; }

        public int ContaBanCR { get; set; }
        public int AgenciaContBanCR { get; set; }
        public int UsuarioCR { get; set; }

        [ForeignKey("UsuarioCR")]
        public virtual UsuarioModel IdUsuario { get; set; }
    }
}
