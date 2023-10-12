using ProsperaModel.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class StatusUsuarioModel
{
    [Key]
    public int IdStatusUsuario { get; set; }
    public string DescStatusUsuario { get; set; }

    [ForeignKey("UsuarioModelId")]
    public int UsuarioModelId { get; set; }
    public virtual UsuarioModel UsuarioModel { get; set; }
}
