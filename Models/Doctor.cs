using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationAPI.Models;

public class Doctor
{
    [Required]
    [Key]
    public int IdDoctor { get; set; }

    [MaxLength(100)]
    public string FirstName { get; set; }

    [MaxLength(100)]
    public string LastName { get; set; }

    [MaxLength(100)]
    public string Email { get; set; }

    public ICollection<Prescription> Prescriptions { get; set; }
}