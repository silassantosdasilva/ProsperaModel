namespace ProsperaModel.Models
{
    public class TransacaoModel
    {
        public int TranID { get; set; }
        public string TranNome { get; set; }
        public int TranIDUsuario { get; set; }
        public DateTime TranDataTransacao { get; set; }
        public decimal TranValor { get; set; }
        public string TranDescricao { get; set; }

    }
}
