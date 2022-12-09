using KPZ_Hospital.Dto;
using Model;

namespace KPZ_Hospital
{
    public static class Mapper
    {
        public static PatientDto ToDto(this Patient patient)
        {
            return new PatientDto
            {
               Id = patient.Id,
               FullName = patient.FullName,
               BirthDate = patient.BirthDate,
               MedicalHistory = patient.MedicalHistory?.Select(d => d.ToDto()).ToList(),
            };
        }
        public static DiseaseDto ToDto(this Disease disease)
        {
            return new DiseaseDto
            {
                Id = disease.Id,
                Content = disease.Content,
                BeginnigTime = disease.BeginnigTime,
            };
        }
    }
}
