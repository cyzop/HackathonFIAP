using Bogus;
using Bogus.Extensions.Brazil;
using MedicalConsultation.Entity.MedicalDoctor;
using MedicalConsultation.Shared;

namespace MedicalConsultation.Tests.Fixture
{
    public class MedicalDoctorTestFixture : TestFixture<MedicalDoctorDao, MedicalDoctorEntity>
    {
        private readonly Faker _faker;

        public MedicalDoctorTestFixture()
        {
            _faker = new Faker(); ;
        }

        public MedicalDoctorDao GenerateDao()
        {
            var id = _faker.Random.Int(min:1);
            var nome = _faker.Person.FullName;
            var email = _faker.Person.Email;
            var ativo = _faker.Random.Bool();
            var cpf = _faker.Person.Cpf();
            var crm = _faker.Person.Cpf();
            var especialidade = _faker.Company.CompanyName();

            return new MedicalDoctorDao()
            {
                Id = id,
                CPF = cpf,
                Crm = crm,
                Name = nome,
                email = email,
                Especialidade = especialidade
            };
        }

        public MedicalDoctorEntity GenerateEntity(string name = null, string mail = null, string cr = null)
        {
            var id = _faker.Random.Int(min: 1);
            var nome = name?? _faker.Person.FullName;
            var email = mail?? _faker.Person.Email;
            var ativo = _faker.Random.Bool();
            var cpf = _faker.Person.Cpf();
            var crm = cr?? _faker.Person.Cpf();
            var especialidade = _faker.Company.CompanyName();

            return new MedicalDoctorEntity(id, nome, cpf, email, crm, especialidade, ativo);
        }

        public MedicalDoctorEntity GenerateWithEmptyName()
        {
            return GenerateEntity(string.Empty);
        }
        public MedicalDoctorEntity GenerateWithEmptyMail()
        {
            return GenerateEntity(null, string.Empty);
        }

        public MedicalDoctorEntity GenerateWithEmptyCRM()
        {
            return GenerateEntity(null, null, string.Empty);
        }

        public MedicalDoctorEntity GenerateEntity()
        {
            return GenerateEntity(null, null, null);
        }
    }
}
