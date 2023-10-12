using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace ProsperaModel.Models
{
    public class ExtratoModel
    {
        [Key]
        public int IdExtrato { get; set; }

        [Required]
        [StringLength(25)]
        public string NomeExtrat { get; set; }

        [Required]
        [StringLength(25)]
        public string TipoExtrat { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal ValorExtrat { get; set; }

        [Required]
        [StringLength(25)]
        public string NomBancoExtrat { get; set; }

        [Required]
        public int CodContaExtrat { get; set; }

        [Required]
        [StringLength(120)]
        public string DestinatarioExtrat { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataExtrat { get; set; }

        [StringLength(20)]
        public string StatusExtrat { get; set; }

        public int UsuarioExtrat { get; set; }

        [StringLength(50)]
        public string ObservacaoExtrat { get; set; }

        [ForeignKey("UsuarioExtrat")]
        public virtual UsuarioModel IdUsuario { get; set; }
    }
}
