using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_Test.Models;

namespace WebAPI_Test.Repositories
{
    public interface IAddressRepository
    {
        Task<IEnumerable<Address>> Get();
        Task<Address> Get(int id);
        Task<Address> Create(Address a);
        Task Update(Address a);
        Task Delete(int id);
    }
}
