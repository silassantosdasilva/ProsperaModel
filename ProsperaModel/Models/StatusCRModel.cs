using ProsperaModel.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class StatusCRModel
{
    [Key]
    public int IdStatusCR { get; set; }
    public string DescStatusCR { get; set; }

    [ForeignKey("CRModel")]
    public int CRModel { get; set; }
    public virtual ContasReceberModel ContasReceberModel{ get; set; }
}
