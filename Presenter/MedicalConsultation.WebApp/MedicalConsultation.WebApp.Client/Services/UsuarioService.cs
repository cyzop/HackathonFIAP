namespace MedicalConsultation.WebApp.Services
{
    public class UsuarioService
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public bool Ativo { get; private set; }

        public bool Medico { get; private set; }
        public void SetUsuario(int id, string name, string email, bool ativo)
        {
            Id = id;
            Nome = name;
            Email = email;
            Ativo = ativo;
        }

        public void SetNome(string nome)
        {
            this.Nome = nome;
        }

        public void SetUsuario(int id, string name, string email, bool ativo, bool medico)
        {
            Id =id;
            Nome = name;
            Email = email;
            Ativo = ativo;
            Medico = medico;
        }
        public UsuarioService() { }
        public UsuarioService(int id, string nome, string email, bool ativo, bool medico)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Ativo = ativo;
            Medico = medico;
        }
    }

}
