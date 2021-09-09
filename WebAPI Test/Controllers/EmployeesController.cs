using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_Test.Models;
using WebAPI_Test.Repositories;

namespace WebAPI_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Employee>> GetEmployee()
        {
            return await _employeeRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            var allEmps = await _employeeRepository.Get();
            var empById = await _employeeRepository.GetById(id);
            if (empById == null)
            {
                return NotFound();
            }
            if(allEmps.Contains(empById))
            {
                return empById;
            }
            return await _employeeRepository.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee([FromBody] Employee emp)
        {
            var newEmp = await _employeeRepository.Create(emp);
            return CreatedAtAction(nameof(GetEmployee), new { id = newEmp.id }, newEmp);
        }

        [HttpPut]
        public async Task<ActionResult> PutEmployees(int id, [FromBody] Employee emp)
            {
            if(id != emp.id)
            {
                return BadRequest();
            }
            await _employeeRepository.Update(emp);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployees(int id)
        {
            var empToDelete = await _employeeRepository.GetById(id);
            if (empToDelete == null)
            {
                return NotFound();
            } 
            await _employeeRepository.Delete(empToDelete.id);
            return Ok();
        }
    }
}
