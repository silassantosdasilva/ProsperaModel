namespace ProsperaModel.Models
{
    public class UsuarioModel
    {
        public int UserID { get; set; }
        public string UserNome { get; set; }
        public string UserEmail { get; set; }
        public string UserSenha { get; set; }
        public DateTime UserDataCadastro { get; set; }

    }
}
