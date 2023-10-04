namespace ProsperaModel.Models
{
    public class NotificacoesModel
    {
        public int NotificaID { get; set; }
        public int NotificaUserID { get; set; }
        public string NotificaMensagem { get; set; }
        public DateTime NotificaDataEnvio { get; set; }
    }
}
