namespace MedicalConsultation.Tests.Fixture
{
    public interface TestFixture<D,E>
    {
        public D GenerateDao();
        public E GenerateEntity();
    }
}
