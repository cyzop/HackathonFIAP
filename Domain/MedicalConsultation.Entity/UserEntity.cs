using System.ComponentModel.DataAnnotations;

namespace MedicalConsultation.Entity
{
    public class UserEntity : BasicEntity
    {
        public string CPF { get; 
            private set; }

        public string Name { get; 
            set; }
        
        [EmailAddress]
        public string Email { get; 
            set; }

        public void SetName(string name) 
            => Name = name;    

        public void SetEmail(string email)
            => Email = email;
        public void SetCpf(string cpf)
          => CPF = cpf;
        public override void Validate()
        {
            throw new NotImplementedException();
        }

        public UserEntity():base()
        {
        }

        public UserEntity(string email)
        {
            Email = email;
            SetAtivo(true);
        }

        public UserEntity(string name, string email, string cpf, bool ativo)
        {
            Name = name;
            Email = email;
            CPF = cpf;
            SetAtivo(true);
        }

        public UserEntity(int id, string name, string cpf, string email,  bool ativo) : base(id, ativo)
        {
            Name = name;
            CPF = cpf;
            Email = email;
        }

        public UserEntity(int id, string name, string cpf, string email) : base(id)
        {
            CPF = cpf;
            Name = name;
            Email = email;
        }
    }
}
