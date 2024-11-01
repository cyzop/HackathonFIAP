﻿using MedicalConsultation.Entity.Patient;
using MedicalConsultation.Interfaces.Repository;

namespace MedicalConsultation.Repository
{
    public class PatientRepository : EFRepository<PatientEntity>, IPatientRepository
    {
        public PatientRepository(ApplicationDbContext context) : base(context)
        {
        }

        public PatientEntity ConsultarPorEmail(string email)
        {
            try
            {
                var user = _context.Usuarios.Where(u => u.Email.ToLower() == email.ToLower()).FirstOrDefault();
                var patientEntity = user as PatientEntity;

                return (PatientEntity)user;
            }
            catch (Exception ex)
            {
                var err = ex.Message;
            }
            return null;

        }

    }
}
