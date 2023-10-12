using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProsperaModel.Models
{
    public class MetaModel
    {
        [Key]
        public int IdMeta { get; set; }

        [StringLength(25)]
        public string NomeMeta { get; set; }

        [StringLength(80)]
        public string DescMeta { get; set; }

        [DataType(DataType.Date)]
        public DateTime DatInicioMeta { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataTerminoMeta { get; set; }

        [DataType(DataType.Currency)]
        public decimal ValorMeta { get; set; }

        [StringLength(20)]
        public string StatusMeta { get; set; }

        [StringLength(80)]
        public string ObservacaoMeta { get; set; }

        [StringLength(50)]
        public string CatMeta { get; set; }

        public int UsuarioMeta { get; set; }

        [ForeignKey("UsuarioMeta")] // Define a chave estrangeira
        public virtual UsuarioModel IdUsuario { get; set; }
    }
}
