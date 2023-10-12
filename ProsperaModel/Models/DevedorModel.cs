using System.ComponentModel.DataAnnotations;

namespace ProsperaModel.Models
{
    public class DevedorModel
    {
        [Key]
        public int IdDevedor { get; set; }

        [StringLength(120)]
        public string NomDevedor { get; set; }

        [StringLength(120)]
        public string EmailDevedor { get; set; }

        [StringLength(20)]
        public string TeleDevedor { get; set; }

        [StringLength(20)]
        public string Tele2Devedor { get; set; }

        [StringLength(80)]
        public string EndereDevedor { get; set; }

        [StringLength(80)]
        public string CidadeDevedor { get; set; }

        [StringLength(80)]
        public string BairroDevedor { get; set; }

        [StringLength(10)]
        public string UFDevedor { get; set; }

        [StringLength(10)]
        public string CEPDevedor { get; set; }

        [StringLength(80)]
        public string ObservaDevedor { get; set; }

        [DataType(DataType.Date)]
        public DateTime DatCadasDevedor { get; set; }

        [StringLength(20)]
        public string StatusDevedor { get; set; }

        [DataType(DataType.Currency)]
        public decimal SaldoDevedor { get; set; }
    }
}
