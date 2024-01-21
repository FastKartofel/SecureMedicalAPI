using System;
using AuthenticationAPI.DTOs;

namespace AuthenticationAPI.Services.Interfaces
{
	public interface IPrescriptionService
	{
        Task<PrescriptionDetailsDTO> GetPrescriptionDetailsAsync(int id);
    }
}