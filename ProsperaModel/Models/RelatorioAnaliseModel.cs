namespace ProsperaModel.Models
{
    public class RelatorioAnaliseModel
    {
        public int RelAnaliseID { get; set; }
        public int RelAnaliseUserID { get; set; }
        public string RelAnaliseNome { get; set; }
        public DateTime RelAnaliseDataGeracao { get; set; }
        public string RelAnaliseConteudo { get; set; }
    }
}
