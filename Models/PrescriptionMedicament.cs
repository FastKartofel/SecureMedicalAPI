using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationAPI.Models;

public class PrescriptionMedicament
{
    [Key]
    [ForeignKey("Medicament")]
    public int IdMedicament { get; set; }

    [Key]
    [ForeignKey("Prescription")]
    public int IdPrescription { get; set; }

    public int Dose { get; set; }

    public string Details { get; set; }

    public virtual Medicament Medicament { get; set; }
    public virtual Prescription Prescription { get; set; }
}
