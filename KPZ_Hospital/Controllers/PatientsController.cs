using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KPZ_Hospital.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Model;

namespace KPZ_Hospital.Controllers
{
    [ApiController]
    [Route("/patients")]
    public class PatientsController : ControllerBase
    {
        private readonly HospitalContext _context;

        public PatientsController(HospitalContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetPatients()
        {
            var patients = await _context.Patients.ToListAsync();
            var result = patients.Select(p => p.ToDto());

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details([FromRoute] int? id)
        {
            if (id == null || _context.Patients == null)
            {
                return NotFound();
            }

            var patient = await _context.Patients.Include(p => p.MedicalHistory).FirstOrDefaultAsync(p => p.Id == id);
            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient.ToDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePatientDto dto)
        {
            var newPatient = new Patient
            {
                FullName = dto.FullName,
                BirthDate = dto.BirthDate,
            };

            await _context.Patients.AddAsync(newPatient);
            await _context.SaveChangesAsync();

            return Ok(newPatient.ToDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int? id, CreatePatientDto dto)
        {
            if (id == null || _context.Patients == null)
            {
                return NotFound();
            }

            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            patient.FullName = dto.FullName;
            patient.BirthDate = dto.BirthDate;

            _context.Patients.Update(patient);
            await _context.SaveChangesAsync();

            return Ok(patient.ToDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int? id)
        {
            if (id == null || _context.Patients == null)
            {
                return NotFound();
            }

            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
