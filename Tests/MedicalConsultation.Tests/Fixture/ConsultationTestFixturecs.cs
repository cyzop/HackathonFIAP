using Bogus;
using MedicalConsultation.Entity;
using MedicalConsultation.Entity.Consultation;
using MedicalConsultation.Entity.MedicalDoctor;
using MedicalConsultation.Entity.Patient;
using MedicalConsultation.Shared;

namespace MedicalConsultation.Tests.Fixture
{
    public class ConsultationTestFixture : TestFixture<ConsultationDao, ConsultationEntity>
    {
        private readonly Faker _faker;
        private readonly PatientTestFixture _patientTestFixture;
        private readonly MedicalDoctorTestFixture _medicalDoctorTestFixture;

        public ConsultationTestFixture(MedicalDoctorTestFixture medicalDoctorTestFixture, PatientTestFixture patientTestFixture)
        {
            _faker = new Faker(); 
            _medicalDoctorTestFixture = medicalDoctorTestFixture;
            _patientTestFixture = patientTestFixture;
        }

        public ConsultationDao GenerateDao()
        {
            var id = _faker.Random.Int(min:1);
            var data = _faker.Date.Future(1, DateTime.Now);
            var dataStatus = _faker.Date.Recent(1, DateTime.Today);
            var numStatus = _faker.Random.Number(2);
            ConsultationStatus enumStatus = (ConsultationStatus)numStatus;

            var medicoDao = _medicalDoctorTestFixture.GenerateDao();
            var pacienteDao = _patientTestFixture.GenerateDao();

            return new ConsultationDao
            {
                Id = id,
                Date = data,
                MedicalDoctor = medicoDao,
                MedicalId = medicoDao.Id,
                Patient = pacienteDao,
                PatientId = pacienteDao.Id,
                Status = enumStatus.ToString(),
                StatusDate = dataStatus
            };
        }

        public ConsultationEntity GenerateEntity(PatientEntity paciente, MedicalDoctorEntity medico, DateTime data)
        {
            var id = _faker.Random.Int(min:1);
            var dataStatus = _faker.Date.Recent(1, DateTime.Today);
            var numStatus = _faker.Random.Number(2);
            ConsultationStatus enumStatus = (ConsultationStatus)numStatus;
            
            return new ConsultationEntity(id, paciente, medico, data, enumStatus, dataStatus);
        }

        public ConsultationEntity GenerateEntity(PatientEntity paciente = null, MedicalDoctorEntity medico = null)
        {
            return GenerateEntity(
                paciente?? _patientTestFixture.GenerateEntity(),
                medico?? _medicalDoctorTestFixture.GenerateEntity(),
                _faker.Date.Future(1, DateTime.Now));
        }

        public ConsultationEntity GenerateEntity(DateTime date)
        {
            return GenerateEntity(
                _patientTestFixture.GenerateEntity(),
                _medicalDoctorTestFixture.GenerateEntity(),
                date);
        }
        public ConsultationEntity GenerateEntity()
        {
            var date = _faker.Date.Future(1, DateTime.Now);
            return GenerateEntity(date);
        }

        public ConsultationEntity GenerateEntityWithEmptyPatient()
        {
            return GenerateEntity(null, 
                                _medicalDoctorTestFixture.GenerateEntity(),
                                _faker.Date.Future(1, DateTime.Now));
        }

        public ConsultationEntity GenerateEntityWithEmptyMedicalDoctor()
        {
            return GenerateEntity(_patientTestFixture.GenerateEntity(),
                                    null, 
                                    _faker.Date.Future(1, DateTime.Now));
        }

        public ConsultationEntity GenerateEntityWithInvalidDate()
        {
            return GenerateEntity(_patientTestFixture.GenerateEntity(),
                                    _medicalDoctorTestFixture.GenerateEntity(),
                                    DateTime.MinValue);
        }
    }
}
