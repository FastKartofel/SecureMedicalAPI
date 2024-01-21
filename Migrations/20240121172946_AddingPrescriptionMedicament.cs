using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AuthenticationAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddingPrescriptionMedicament : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrescriptionMedicaments_Medicaments_MedicamentIdMedicament",
                table: "PrescriptionMedicaments");

            migrationBuilder.DropForeignKey(
                name: "FK_PrescriptionMedicaments_Prescriptions_PrescriptionIdPrescription",
                table: "PrescriptionMedicaments");

            migrationBuilder.DropIndex(
                name: "IX_PrescriptionMedicaments_MedicamentIdMedicament",
                table: "PrescriptionMedicaments");

            migrationBuilder.DropIndex(
                name: "IX_PrescriptionMedicaments_PrescriptionIdPrescription",
                table: "PrescriptionMedicaments");

            migrationBuilder.DropColumn(
                name: "MedicamentIdMedicament",
                table: "PrescriptionMedicaments");

            migrationBuilder.DropColumn(
                name: "PrescriptionIdPrescription",
                table: "PrescriptionMedicaments");

            migrationBuilder.InsertData(
                table: "PrescriptionMedicaments",
                columns: new[] { "IdMedicament", "IdPrescription", "Details", "Dose" },
                values: new object[,]
                {
                    { 1, 1, "The prescription for aspirin.", 1 },
                    { 2, 2, "The prescription for morphin.", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionMedicaments_IdPrescription",
                table: "PrescriptionMedicaments",
                column: "IdPrescription");

            migrationBuilder.AddForeignKey(
                name: "FK_PrescriptionMedicaments_Medicaments_IdMedicament",
                table: "PrescriptionMedicaments",
                column: "IdMedicament",
                principalTable: "Medicaments",
                principalColumn: "IdMedicament",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PrescriptionMedicaments_Prescriptions_IdPrescription",
                table: "PrescriptionMedicaments",
                column: "IdPrescription",
                principalTable: "Prescriptions",
                principalColumn: "IdPrescription",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrescriptionMedicaments_Medicaments_IdMedicament",
                table: "PrescriptionMedicaments");

            migrationBuilder.DropForeignKey(
                name: "FK_PrescriptionMedicaments_Prescriptions_IdPrescription",
                table: "PrescriptionMedicaments");

            migrationBuilder.DropIndex(
                name: "IX_PrescriptionMedicaments_IdPrescription",
                table: "PrescriptionMedicaments");

            migrationBuilder.DeleteData(
                table: "PrescriptionMedicaments",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "PrescriptionMedicaments",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.AddColumn<int>(
                name: "MedicamentIdMedicament",
                table: "PrescriptionMedicaments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PrescriptionIdPrescription",
                table: "PrescriptionMedicaments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionMedicaments_MedicamentIdMedicament",
                table: "PrescriptionMedicaments",
                column: "MedicamentIdMedicament");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionMedicaments_PrescriptionIdPrescription",
                table: "PrescriptionMedicaments",
                column: "PrescriptionIdPrescription");

            migrationBuilder.AddForeignKey(
                name: "FK_PrescriptionMedicaments_Medicaments_MedicamentIdMedicament",
                table: "PrescriptionMedicaments",
                column: "MedicamentIdMedicament",
                principalTable: "Medicaments",
                principalColumn: "IdMedicament",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PrescriptionMedicaments_Prescriptions_PrescriptionIdPrescription",
                table: "PrescriptionMedicaments",
                column: "PrescriptionIdPrescription",
                principalTable: "Prescriptions",
                principalColumn: "IdPrescription",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
