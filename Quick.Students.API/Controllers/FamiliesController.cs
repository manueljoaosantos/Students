﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quick.Students.Application.Core.Services;
using Quick.Students.Domain.Entities;

namespace Quick.Students.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamiliesController : ControllerBase
    {
        private readonly IFamiliesService _familyService;

        public FamiliesController(IFamiliesService familyService)
        {
            _familyService = familyService;
        }

        [HttpGet("{id?}")]
        public async Task<IActionResult> Get(int? id)
        {
            if (id == null) return StatusCode(StatusCodes.Status422UnprocessableEntity);

            var student = await _familyService.GetFirst(id ?? 0);
            if (student == null) return NotFound();

            return Ok(student);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _familyService.GetAll();
            return Ok(students);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Family family)
        {
            if (!ModelState.IsValid) return StatusCode(StatusCodes.Status422UnprocessableEntity);

            if (await _familyService.IsAlreadyAddedCode(family.Code)) return StatusCode(StatusCodes.Status409Conflict);

            await _familyService.Add(family);
            if (family == null) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(family);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Family family)
        {
            if (family.Id == 0) return StatusCode(StatusCodes.Status422UnprocessableEntity);
            await _familyService.Update(family);
            if (family == null) return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok(family);
        }

        [HttpDelete("{id?}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return StatusCode(StatusCodes.Status422UnprocessableEntity);

            var family = await _familyService.GetFirst(id ?? 0);
            if (family == null) return NotFound();

            await _familyService.Delete(family.Id);
            return Ok(family);
        }
    }
}
