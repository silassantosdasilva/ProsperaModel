using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using SeuProjeto.Models;

namespace ProsperaModel.Models
{
    public class UsuarioModel
    {
        [Key]
        public int IdUsuario { get; set; }

        [Required]
        [StringLength(25)]
        public string NomeUsuario { get; set; }

        [StringLength(105)]
        public string SobrenomeUsuario { get; set; }

        [Required]
        [StringLength(120)]
        public string EmailUsuario { get; set; }

        [Required]
        [StringLength(20)]
        public string SenhaUsuario { get; set; }

        [StringLength(80)]
        public string CargoUsuario { get; set; }

        [DataType(DataType.Date)]
        public DateTime DatCadastroUsuario { get; set; }

        [DataType(DataType.Date)]
        public DateTime DatUltimoAcesUsuario { get; set; }

        [StringLength(20)]
        public string StatusUsuario { get; set; }

        [ForeignKey("IdTerceiros")]
        public int IdTerceiros { get; set; }
        public virtual TerceirosModel TerceirosModel { get; set; }

    }
}
