using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_Test.Models;

namespace WebAPI_Test.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly Models.ApplicationDbContext _context;

        public EmployeeRepository(Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> Create(Employee emp)
        {
            emp.CreatedDate = DateTime.Now;
            _context.Employee.Add(emp);
            await _context.SaveChangesAsync();
            return emp;
        }

        public async Task Delete(int id)
        {
            var empToDelete =await _context.Employee.FindAsync(id);
            _context.Employee.Remove(empToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Employee>> Get()
        {
            return await _context.Employee.ToListAsync();
        }

        public async Task<Employee> GetById(int id)
        {
            return await _context.Employee.FindAsync(id);
        }

        public async Task Update(Employee emp)
        {
            emp.ModifiedDate = DateTime.Now;
            _context.Entry(emp).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
