namespace MedicalConsultation.WebApp.LocalStorage
{
    public class UserData
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public bool Ativo { get; private set; }

        public UserData(int id, string nome, string email, bool ativo)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Ativo = ativo;
        }
    }
}
