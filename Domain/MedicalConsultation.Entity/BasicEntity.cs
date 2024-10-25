namespace MedicalConsultation.Entity
{
    public abstract class BasicEntity : Entity
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

        public BasicEntity(int id, bool ativo = true) : base()
        {
            Id = id;
            Ativo = ativo;
        }

        protected BasicEntity()
        {
        }

        public void SetId(int id)
           => Id = id;

        public void SetAtivo(bool ativo)
            => Ativo = ativo;

        public abstract void Validate();
    }
}
