using ProsperaModel.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class StatusMetaModel
{
    [Key]
    public int IdStatusMeta { get; set; }
    public string DescStatusMeta { get; set; }

    [ForeignKey("MetaModelId")]
    public int MetaModelId { get; set; }
    public virtual MetaModel MetaModel { get; set; }
}
