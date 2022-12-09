using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class HospitalContext: DbContext
    {
        public DbSet<Patient> Patients { get; set; }

        public DbSet<Disease> Diseases { get; set; }

        private readonly string _connectionString;

        public HospitalContext()
        {
            _connectionString = "Data Source=localhost;Initial Catalog=Hospital;Integrated Security=true; TrustServerCertificate=True";
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Patient>().HasData(new List<Patient>
            {
                new Patient()
                {
                    Id = 1,
                    FullName = "Zach Curtis",
                    BirthDate = new DateTime(2002, 10, 1),
                },
                new Patient()
                {
                    Id = 2,
                    FullName = "Max Thomson",
                    BirthDate = new DateTime(1996, 5, 6),
                },
                new Patient()
                {
                    Id = 3,
                    FullName = "Eva Reyes",
                    BirthDate = new DateTime(2003, 1, 22),
                },
                new Patient()
                {
                    Id = 4,
                    FullName = "Farhan Greene",
                    BirthDate = new DateTime(2000, 12, 15),
                },
                new Patient()
                {
                    Id = 5,
                    FullName="Lorna Carpenter",
                    BirthDate = new DateTime(1978, 7, 20),
                },
            });
            modelBuilder.Entity<Disease>().HasData(new List<Disease>
            {
                new Disease()
                {
                    Id = 1,
                    Content = "Varicose veins",
                    BeginnigTime = new DateTime(2022, 11, 10),
                    PatientId = 1,
                },
                new Disease()
                {
                    Id = 2,
                    Content = "Polyarteritis nodosa",
                    BeginnigTime = new DateTime(2022, 11, 12),
                    PatientId = 2,
                },
                new Disease()
                {
                    Id = 3,
                    Content = "Prevotella infection",
                    BeginnigTime = new DateTime(2022, 12, 2),
                    PatientId = 3,
                },
                new Disease()
                {
                    Id = 4,
                    Content = "Cytomegalovirus infection",
                    BeginnigTime = new DateTime(2022, 12, 3),
                    PatientId = 4,
                },
                new Disease()
                {
                    Id = 5,
                    Content = "Tungiasis",
                    BeginnigTime = new DateTime(2022, 12, 4),
                    PatientId = 5,
                },
                new Disease()
                {
                    Id = 6,
                    Content = "Hypotonia",
                    BeginnigTime = new DateTime(2022, 12, 6),
                    PatientId = 1,
                },
            });
        }

    }
}
