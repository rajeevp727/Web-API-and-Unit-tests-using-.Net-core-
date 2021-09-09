using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_Test.Models;

namespace WebAPI_Test.Repositories
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> Get();
        Contact GetById(int id);
        Task<Contact> Create(Contact c);
        Task Update(Contact c);
        Task Delete(int id);
    }
}