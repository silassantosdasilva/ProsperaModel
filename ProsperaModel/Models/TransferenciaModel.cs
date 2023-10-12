using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProsperaModel.Models
{
    public class TransferenciaModel
    {
        [Key]
        public int IdTransferencia { get; set; }

        [StringLength(120)]
        public string DestinatarioTransfe { get; set; }

        public int NumContBan { get; set; }

        public int AgenciaContBan { get; set; }

        [StringLength(80)]
        public string NomeBanTransfe { get; set; }

        [DataType(DataType.Currency)]
        public decimal ValorTransfe { get; set; }

        [StringLength(80)]
        public string DescricaoTransfe { get; set; }

        [DataType(DataType.Date)]
        public DateTime DatAgendaTransfere { get; set; }

        [StringLength(50)]
        public string TipoTransfe { get; set; }

        public int UsuarioTransfe { get; set; }

        [ForeignKey("UsuarioTransfe")]
        public virtual UsuarioModel IdUsuario { get; set; }
    }
}
