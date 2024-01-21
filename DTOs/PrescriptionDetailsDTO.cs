using System;
namespace AuthenticationAPI.DTOs
{
    public class PrescriptionDetailsDTO
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public DoctorDTO Doctor { get; set; }

        public PatientDTO Patient { get; set; }

        public List<MedicamentDTO> Medicaments { get; set; }
    }
}