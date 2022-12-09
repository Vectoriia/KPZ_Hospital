using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Model.Migrations
{
    /// <inheritdoc />
    public partial class InitMigartion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Diseases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeginnigTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diseases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diseases_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "BirthDate", "FullName" },
                values: new object[,]
                {
                    { 1, new DateTime(2002, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zach Curtis" },
                    { 2, new DateTime(1996, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Max Thomson" },
                    { 3, new DateTime(2003, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eva Reyes" },
                    { 4, new DateTime(2000, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Farhan Greene" },
                    { 5, new DateTime(1978, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lorna Carpenter" }
                });

            migrationBuilder.InsertData(
                table: "Diseases",
                columns: new[] { "Id", "BeginnigTime", "Content", "PatientId" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Varicose veins", 1 },
                    { 2, new DateTime(2022, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Polyarteritis nodosa", 2 },
                    { 3, new DateTime(2022, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prevotella infection", 3 },
                    { 4, new DateTime(2022, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cytomegalovirus infection", 4 },
                    { 5, new DateTime(2022, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tungiasis", 5 },
                    { 6, new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hypotonia", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diseases_PatientId",
                table: "Diseases",
                column: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diseases");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
