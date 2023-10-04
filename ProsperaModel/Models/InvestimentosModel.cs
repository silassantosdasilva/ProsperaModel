namespace ProsperaModel.Models
{
    public class InvestimentosModel
    {
        public int InvesID { get; set; }
        public int InvesIDUsuario { get; set; }
        public string InvesDescricao { get; set; }
        public string InvesTpDescricao { get; set; }
        public decimal InvesValor { get; set; }
        public DateTime InvesData { get; set; }
    }
}
