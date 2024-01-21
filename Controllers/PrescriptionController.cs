using AuthenticationAPI.DTOs;
using AuthenticationAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PrescriptionController : ControllerBase
{
    private readonly IPrescriptionService _prescriptionService;

    public PrescriptionController(IPrescriptionService prescriptionService)
    {
        _prescriptionService = prescriptionService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PrescriptionDetailsDTO>> GetPrescription(int id)
    {
        var prescriptionDetails = await _prescriptionService.GetPrescriptionDetailsAsync(id);
        if (prescriptionDetails == null)
            return NotFound();

        return Ok(prescriptionDetails);
    }
}