namespace MedicalConsultation.Entity
{
    public abstract class Entity
    {        
        public int Id
        {
            get;
            private set;
        }
       
        public bool Ativo
        {
            get;
            private set;
        }
        public Entity()
        {
        }

        public Entity(int id, bool ativo = true)
        {
            Id = id;
            Ativo = ativo;
        }

        public void SetId(int id)
           => Id = id;

        public void SetAtivo(bool ativo)
            => Ativo = ativo;

        public abstract void Validate();
    }
}
