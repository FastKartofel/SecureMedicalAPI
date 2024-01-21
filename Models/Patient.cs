using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationAPI.Models;

public class Patient
{
    [Key]
    [Required]
    public int IdPatient { get; set; }

    [MaxLength(100)]
    public string FirstName { get; set; }

    [MaxLength(100)]
    public string LastName { get; set; }

    public DateTime Birthdate { get; set; }

    public ICollection<Prescription> Prescriptions { get; set; }
}