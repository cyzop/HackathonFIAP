using Bogus;
using Bogus.Extensions.Brazil;
using MedicalConsultation.Entity;
using MedicalConsultation.Shared;

namespace MedicalConsultation.Tests.Fixture
{
    public class UserTestFixture : TestFixture<UserDao, UserEntity>
    {
        private readonly Faker _faker;

        public UserTestFixture()
        {
            _faker = new Faker(); 
        }

        public UserDao GenerateDao()
        {
            var id = _faker.Random.Int(min:1);
            var nome = _faker.Person.FullName;
            var email = _faker.Person.Email;
            var ativo = _faker.Random.Bool();
            var cpf = _faker.Person.Cpf();
            var medico = _faker.Random.Bool();

            return new UserDao()
            {
                Id = id,
                Email = email,
                Name = nome,
                Ativo = ativo,
                cpf = cpf,
                EhMedico = medico
            };
        }

        public UserEntity GenerateEntity()
        {
            var id = _faker.Random.Int(min:1);
            var nome = _faker.Person.FullName;
            var email = _faker.Person.Email;
            var ativo = _faker.Random.Bool();
            var cpf = _faker.Person.Cpf();
            return new UserEntity(id, nome, cpf, email, ativo);
        }
    }
}
