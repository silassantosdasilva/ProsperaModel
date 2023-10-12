using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProsperaModel.Models
{
    public class ConfiguracaoUsuarioModel
    {
        [Key]
        public int IdConfiguracaoUsuario { get; set; }

        public int UsuarioConfiguracaoUsuario { get; set; }

        public bool NotificacoesAtivadas { get; set; }

        [ForeignKey("UsuarioConfiguracaoUsuario")]
        public UsuarioModel IdUsuario { get; set; }
    }

}

