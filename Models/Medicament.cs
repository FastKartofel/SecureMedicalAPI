using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationAPI.Models;

public class Medicament
{
    [Key]
    [Required]
    public int IdMedicament { get; set; }

    [MaxLength(100)]
    public string Name { get; set; }

    [MaxLength(100)]
    public string Description { get; set; }

    [MaxLength(100)]
    public string Type { get; set; }

    public ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
}