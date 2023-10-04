namespace ProsperaModel.Models
{
    public class TransacoesFixaModel
    {
        public int TranFixaID { get; set; }
        public string TranFixaNome { get; set; }
        public int TranCategoriaID { get; set; }
        public int TranFixaIDUsuario { get; set; }
        public DateTime TranDataFixaTransacao { get; set; }
        public decimal TranFixaValor { get; set; }
        public string TranFixaDescricao { get; set; }
    }
}
