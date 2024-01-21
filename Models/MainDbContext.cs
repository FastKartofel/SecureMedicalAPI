using AuthenticationAPI.Models;
using Microsoft.EntityFrameworkCore;

public class MainDbContext : DbContext
{
    public MainDbContext(DbContextOptions<MainDbContext> options) : base(options) { }

    public MainDbContext() { }

    public DbSet<Doctor> Doctors { get; set; }

    public DbSet<Patient> Patients { get; set; }

    public DbSet<Medicament> Medicaments { get; set; }

    public DbSet<Prescription> Prescriptions { get; set; }

    public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }

    public DbSet<User> Users { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<PrescriptionMedicament>()
            .HasKey(pm => new { pm.IdMedicament, pm.IdPrescription });  

        //we have already implemented thye annotations in the models, this is just to show that there are different ways to implement the connections betwen tables
        /*modelBuilder.Entity<PrescriptionMedicament>()
            .HasKey(pm => new { pm.IdMedicament, pm.IdPrescription });

        modelBuilder.Entity<PrescriptionMedicament>()
            .HasOne(pm => pm.Medicament)
            .WithMany(m => m.PrescriptionMedicaments)
            .HasForeignKey(pm => pm.IdMedicament);

        modelBuilder.Entity<PrescriptionMedicament>()
            .HasOne(pm => pm.Prescription)
            .WithMany(p => p.PrescriptionMedicaments)
            .HasForeignKey(pm => pm.IdPrescription);

        modelBuilder.Entity<Prescription>()
            .HasOne(p => p.Doctor)
            .WithMany(d => d.Prescriptions)
            .HasForeignKey(p => p.IdDoctor);

        modelBuilder.Entity<Prescription>()
            .HasOne(p => p.Patient)
            .WithMany(p => p.Prescriptions)
            .HasForeignKey(p => p.IdPatient);
            */


        modelBuilder.Entity<Doctor>().HasData(
            new Doctor { IdDoctor = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com" },
            new Doctor { IdDoctor = 2, FirstName = "Patryk", LastName = "Zaluska", Email = "paddy.z@example.com" },
            new Doctor { IdDoctor = 3, FirstName = "Arzu", LastName = "Kilic", Email = "kilic.a@example.com" }

        );

        modelBuilder.Entity<Patient>().HasData(
            new Patient { IdPatient = 1, FirstName = "Anastazja", LastName = "Belarus", Birthdate = new DateTime(1980, 1, 1) },
            new Patient { IdPatient = 2, FirstName = "Marcin", LastName = "Chęciński", Birthdate = new DateTime(1983, 12, 12) },
            new Patient { IdPatient = 3, FirstName = "Zuzanna", LastName = "Bielińska", Birthdate = new DateTime(1987, 6, 9) }
        );

        modelBuilder.Entity<Medicament>().HasData(
            new Medicament { IdMedicament = 1, Name = "Aspirin", Description = "For headache.", Type = "Normal" },
            new Medicament { IdMedicament = 2, Name = "Morphin", Description = "For pain.", Type = "Hard" }
        );

     
        modelBuilder.Entity<Prescription>().HasData(
            new Prescription { IdPrescription = 1, Date = new DateTime(2021, 1, 1), DueDate = new DateTime(2021, 1, 10), IdPatient = 1, IdDoctor = 1 },
            new Prescription { IdPrescription = 2, Date = new DateTime(2021, 2, 1), DueDate = new DateTime(2021, 2, 10), IdPatient = 2, IdDoctor = 2 }
        );

        
          modelBuilder.Entity<PrescriptionMedicament>().HasData(
            new PrescriptionMedicament { IdMedicament = 1, IdPrescription = 1, Dose = 1, Details = "The prescription for aspirin." },
            new PrescriptionMedicament { IdMedicament = 2, IdPrescription = 2, Dose = 2, Details = "The prescription for morphin." }
        );
        
    }
}