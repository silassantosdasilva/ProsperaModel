using ProsperaModel.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class StatusContBancariaModel
{
    [Key]
    public int IdStatusContBan { get; set; }
    public string DescStatusContBan { get; set; }

    [ForeignKey("ContBancariaModel")]
    public int ContBancariaModel { get; set; }
    public virtual ContaBancariaModel ContaBancariaModel { get; set; }
}
