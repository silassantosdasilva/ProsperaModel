using ProsperaModel.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class StatusOrcamentoModel
{
    [Key]
    public int IdStatusOrca { get; set; }
    public string DescStatusOrca { get; set; }

    [ForeignKey("OrcamentoModelId")]
    public int OrcamentoModelId { get; set; }
    public virtual OrcamentoModel OrcamentoModel { get; set; }
}
