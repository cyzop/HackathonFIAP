using Bogus;
using MedicalConsultation.Entity.Consultation;
using MedicalConsultation.Entity.Notify;

namespace MedicalConsultation.Tests.Fixture
{
    public class NotificationTestFixture 
    {
        private readonly Faker _faker;
        private readonly ConsultationTestFixture _consultationFixture;

        public NotificationTestFixture(ConsultationTestFixture consultationFixture)
        {
            _faker = new Faker();
            _consultationFixture = consultationFixture;
        }

        public ConsultationNotificationEntity GenerateEntity(ConsultationEntity consulta)
        { 
            //var consulta = _consultationFixture.GenerateEntity();
            var dataNotificacao = _faker.Date.Recent(1, DateTime.Now);
            var id = _faker.Random.Int(min:1);
            var ativo = _faker.Random.Bool();

            return new ConsultationNotificationEntity(id, consulta, dataNotificacao, ativo);
        }

        public ConsultationNotificationEntity GenerateEntityWithEmptyConsultation()
        {
            return GenerateEntity(null);
        }

        public ConsultationNotificationEntity GenerateEntity()
        {
            var consulta = _consultationFixture.GenerateEntity();
            return GenerateEntity(consulta);
        }
    }
}
