namespace KPZ_Hospital.Dto
{
    public class PatientDto: CreatePatientDto
    {
        public int Id { get; set; }

        public List<DiseaseDto> MedicalHistory { get; set; } 
    }
}
