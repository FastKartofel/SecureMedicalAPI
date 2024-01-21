using AuthenticationAPI.DTOs;
using AuthenticationAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationAPI.Controllers;


[Route("api/[controller]")]
public class DoctorController : Controller
{
    private readonly IDoctorService _doctors;

    public DoctorController(IDoctorService doctors)
    {
        _doctors = doctors;
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DoctorDTO>>> GetDoctors()
    {

        var allDoctors = await _doctors.GetAllDoctorsAsync();
        return Ok(allDoctors);
    }

    [HttpPost]
    public async Task<ActionResult<DoctorDTO>> CreateDoctor([FromBody] DoctorDTO doctorDTO)
    {
        var createdDoctor = await _doctors.CreateDoctorAsync(doctorDTO);
        return CreatedAtAction(nameof(GetDoctor), new { id = createdDoctor.IdDoctor }, createdDoctor);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDoctor(int id, [FromBody] DoctorDTO doctorDTO)
    {
        await _doctors.UpdateDoctorAsync(id, doctorDTO);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDoctor(int id)
    {
        await _doctors.DeleteDoctorAsync(id);
        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DoctorDTO>> GetDoctor(int id)
    {
        var doctor = await _doctors.GetDoctorByIdAsync(id);
        if (doctor == null)
        {
            return NotFound();
        }

        return Ok(doctor);
    }
}