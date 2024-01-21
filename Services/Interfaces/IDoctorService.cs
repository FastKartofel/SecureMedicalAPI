using AuthenticationAPI.DTOs;

namespace AuthenticationAPI.Services.Interfaces;

public interface IDoctorService
{
    Task<IEnumerable<DoctorDTO>> GetAllDoctorsAsync();

    Task<DoctorDTO> GetDoctorByIdAsync(int id);

    Task<DoctorDTO> CreateDoctorAsync(DoctorDTO doctor);

    Task UpdateDoctorAsync(int id, DoctorDTO doctor);

    Task DeleteDoctorAsync(int id);
}