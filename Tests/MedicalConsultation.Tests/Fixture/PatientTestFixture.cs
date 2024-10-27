using Bogus;
using Bogus.Extensions.Brazil;
using MedicalConsultation.Entity.Patient;
using MedicalConsultation.Shared;

namespace MedicalConsultation.Tests.Fixture
{
    public class PatientTestFixture : TestFixture<PatientDao, PatientEntity>
    {
        private readonly Faker _faker;

        public PatientTestFixture()
        {
            _faker = new Faker(); 
        }

        public PatientDao GenerateDao()
        {
            var id = _faker.Random.Int(min:1);
            var nome = _faker.Person.FullName;
            var email = _faker.Person.Email;
            var ativo = _faker.Random.Bool();
            var cpf = _faker.Person.Cpf();

            return new PatientDao()
            {
                Id = id,
                Email = email,
                Name = nome,
                Ativo = ativo,
                cpf =  cpf
            };
        }

        public PatientEntity GenerateEntity(string name = null, string mail = null, string cp = null)
        {
            var id = _faker.Random.Int(min:1);
            var nome = name?? _faker.Person.FullName;
            var email = mail?? _faker.Person.Email;
            var ativo = _faker.Random.Bool();
            var cpf = cp?? _faker.Person.Cpf();
            return new PatientEntity(id, nome, cpf, email, ativo);
        }

        public PatientEntity GenerateWithEmptyName()
        {
            return GenerateEntity(string.Empty);
        }
        public PatientEntity GenerateWithEmptyMail()
        {
            return GenerateEntity(null, string.Empty);
        }

        public PatientEntity GenerateWithNameGreatThen150()
        {
            var name = _faker.Lorem.Letter(200);
            return GenerateEntity(name);
        }

        public PatientEntity GenerateEntity()
        {
            return GenerateEntity(null, null, null);
        }
    }
}
