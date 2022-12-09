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
    [Route("/diseases")]
    public class DiseasesController : ControllerBase
    {
        private readonly HospitalContext _context;

        public DiseasesController(HospitalContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetDisease()
        {
            var diseases = await _context.Diseases.ToListAsync();
            var result = diseases.Select(d => d.ToDto());

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details([FromRoute] int? id)
        {
            if (id == null || _context.Diseases == null)
            {
                return NotFound();
            }

            var disease = await _context.Diseases.FindAsync(id);
            if (disease == null)
            {
                return NotFound();
            }

            return Ok(disease.ToDto());
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Create([FromRoute] int id, CreateDiseaseDto dto)
        {
            var newDisease = new Disease
            {
                PatientId = id,
                Content = dto.Content,
                BeginnigTime = dto.BeginnigTime,
            };

            await _context.Diseases.AddAsync(newDisease);
            await _context.SaveChangesAsync();

            return Ok(newDisease.ToDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int? id, CreateDiseaseDto dto)
        {
            if (id == null || _context.Diseases == null)
            {
                return NotFound();
            }

            var disease = await _context.Diseases.FindAsync(id);
            if (disease == null)
            {
                return NotFound();
            }

            disease.Content = dto.Content;
            disease.BeginnigTime = dto.BeginnigTime;

            _context.Diseases.Update(disease);
            await _context.SaveChangesAsync();

            return Ok(disease.ToDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int? id)
        {
            if (id == null || _context.Diseases == null)
            {
                return NotFound();
            }

            var disease = await _context.Diseases.FindAsync(id);
            if (disease == null)
            {
                return NotFound();
            }

            _context.Diseases.Remove(disease);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
