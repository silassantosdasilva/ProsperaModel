using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProsperaModel.Models
{
    public class ContaBancariaModel
    {
        [Key]
        public int IdContBancaria { get; set; }

        [StringLength(120)]
        public string NomeTitulaContBan { get; set; }

        public int NumContBan { get; set; }

        public int AgenciaContBan { get; set; }

        [DataType(DataType.Currency)]
        public decimal SaldoContBan { get; set; }

        [StringLength(50)]
        public string TipoContBan { get; set; }

        [StringLength(80)]
        public string ObsContBan { get; set; }

        [ForeignKey("UsuarioContBan")]
        public int UsuarioContBan { get; set; }
        public virtual UsuarioModel UsuarioModel { get; set; }
    }
}