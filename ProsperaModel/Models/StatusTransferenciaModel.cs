using ProsperaModel.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class StatusTransferenciaModel
{
    [Key]
    public int IdStatusTransfe { get; set; }
    public string DescStatusTransfe { get; set; }

    [ForeignKey("TransferenciaModelId")]
    public int TransferenciaModelId { get; set; }
    public virtual TransferenciaModel TransferenciaModel { get; set; }
}
