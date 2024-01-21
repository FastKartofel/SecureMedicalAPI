using AuthenticationAPI.DTOs;
using AuthenticationAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

public class PrescriptionServiceImpl : IPrescriptionService
{
    private readonly MainDbContext _context;

    public PrescriptionServiceImpl(MainDbContext context)
    {
        _context = context;
    }

    public async Task<PrescriptionDetailsDTO> GetPrescriptionDetailsAsync(int id)
    {
        var prescription = await _context.Prescriptions
            .Include(p => p.Doctor)
            .Include(p => p.Patient)
            .Include(p => p.PrescriptionMedicaments)
                .ThenInclude(pm => pm.Medicament)
            .FirstOrDefaultAsync(p => p.IdPrescription == id);

        if (prescription == null)
            return null;

        // Mapping
        var prescriptionDetailsDto = new PrescriptionDetailsDTO
        {
            Id = prescription.IdPrescription,
            Date = prescription.Date,
            Doctor = new DoctorDTO
            {
                IdDoctor = prescription.Doctor.IdDoctor,
                FirstName = prescription.Doctor.FirstName,
                LastName = prescription.Doctor.LastName,
                Email = prescription.Doctor.Email
            },
            Patient = new PatientDTO
            {
                IdPatient = prescription.Patient.IdPatient,
                FirstName = prescription.Patient.FirstName,
                LastName = prescription.Patient.LastName,
                Birthdate = prescription.Patient.Birthdate
            },
            Medicaments = prescription.PrescriptionMedicaments.Select(pm => new MedicamentDTO
            {
                Id = pm.Medicament.IdMedicament,
                Name = pm.Medicament.Name,
                Description = pm.Medicament.Description,
                Type = pm.Medicament.Type
            }).ToList()
        };

        return prescriptionDetailsDto;
    }
}
