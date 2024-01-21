using AuthenticationAPI.DTOs;
using AuthenticationAPI.Models;
using AuthenticationAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationAPI.Services.Implementation;

public class DoctorServiceImpl : IDoctorService
{
    private readonly MainDbContext _context;

    public DoctorServiceImpl(MainDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<DoctorDTO>> GetAllDoctorsAsync()
    {
        return await _context.Doctors
            .Select(doctor => new DoctorDTO
            {
                IdDoctor = doctor.IdDoctor,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Email = doctor.Email
            }).ToListAsync();
    }

    public async Task<DoctorDTO> GetDoctorByIdAsync(int id)
    {
        var doctor = await _context.Doctors
            .Where(d => d.IdDoctor == id)
            .Select(d => new DoctorDTO
            {
                IdDoctor = d.IdDoctor,
                FirstName = d.FirstName,
                LastName = d.LastName,
                Email = d.Email
            }).FirstOrDefaultAsync();

        return doctor;
    }

    public async Task<DoctorDTO> CreateDoctorAsync(DoctorDTO doctorDTO)
    {
        var doctor = new Doctor
        {
            FirstName = doctorDTO.FirstName,
            LastName = doctorDTO.LastName,
            Email = doctorDTO.Email
        };

        _context.Doctors.Add(doctor);
        await _context.SaveChangesAsync();

        doctorDTO.IdDoctor = doctor.IdDoctor;
        return doctorDTO;
    }

    public async Task UpdateDoctorAsync(int id, DoctorDTO doctorDTO)
    {
        var doctor = await _context.Doctors.FindAsync(id);
        if (doctor != null)
        {
            doctor.FirstName = doctorDTO.FirstName;
            doctor.LastName = doctorDTO.LastName;
            doctor.Email = doctorDTO.Email;

            _context.Doctors.Update(doctor);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteDoctorAsync(int id)
    {
        var doctor = await _context.Doctors.FindAsync(id);
        if (doctor != null)
        {
            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
        }
    }
}