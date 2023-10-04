namespace ProsperaModel.Models
{
    public class MetaFinanceiraModel
    {
        public Guid MetaID { get; set; }
        public int MetaIDUsuario { get; set; }
        public decimal MetaValorAlvo { get; set; }
        public DateTime MetaDataVencimento { get; set; }
        public  string MetaDescricao { get; set; }
    }
}
