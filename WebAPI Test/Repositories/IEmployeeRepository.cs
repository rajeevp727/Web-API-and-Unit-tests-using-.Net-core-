using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_Test.Models;

namespace WebAPI_Test.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> Get();
        Task<Employee> GetById(int id);
        Task<Employee> Create(Employee emp);
        Task Update(Employee emp);
        Task Delete(int id);
    }
}
