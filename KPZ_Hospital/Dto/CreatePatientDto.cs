using Model;

namespace KPZ_Hospital.Dto
{
    public class CreatePatientDto
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
