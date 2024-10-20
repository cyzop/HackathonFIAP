using System.ComponentModel.DataAnnotations;

namespace MedicalConsultation.Entity
{
    public abstract class PersonEntity : Entity
    {
      
        public string Name { get; 
            private set; }
        
        [EmailAddress]
        public string Email { get; 
            private set; }

        public void SetName(string name) 
            => Name = name;    

        public void SetEmail(string email)
            => Email = email;

        public PersonEntity():base()
        {
        }

        public PersonEntity(int id, string name, string email, bool ativo) : base(id, ativo)
        {
            Name = name;
            Email = email;
        }

        public PersonEntity(int id, string name, string email) : base(id)
        {
            Name = name;
            Email = email;
        }
    }
}
