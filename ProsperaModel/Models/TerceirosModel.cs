using ProsperaModel.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeuProjeto.Models
{
    public class TerceirosModel
    {
        [Key]
        public int IdTerceiros { get; set; }

        [Required]
        [StringLength(120)]
        public string NomeTerceiros { get; set; }

        [Required]
        [StringLength(20)]
        public string TelefoneTerceiros { get; set; }

        [StringLength(20)]
        public string Telefone2Terceiros { get; set; }

        [Required]
        [StringLength(120)]
        [EmailAddress]
        public string EmailTerceiros { get; set; }

        [Required]
        [StringLength(80)]
        public string EnderecoTerceiros { get; set; }

        [Required]
        [StringLength(80)]
        public string CidadeTerceiros { get; set; }

        [Required]
        [StringLength(80)]
        public string BairroTerceiros { get; set; }

        [Required]
        [StringLength(10)]
        public string UFTerceiros { get; set; }

        [Required]
        [StringLength(10)]
        public string CEPTerceiros { get; set; }

        [StringLength(80)]
        public string ObservacaoTerceiros { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataCadastroTerceiros { get; set; }

        [Required]
        [StringLength(20)]
        public string StatusTerceiros { get; set; }
        public decimal SaldoTerceiros { get; set; }

        [ForeignKey("IdContaBancariaModel")]
        public int IdContaBancariaModel { get; set; }
        
        public virtual ContaBancariaModel ContaBancariaModel { get; set; }


    }
}
