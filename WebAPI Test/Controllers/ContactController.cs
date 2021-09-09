using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;
        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Contact>> GetContacts()
        {
            return await _contactRepository.Get();
        }

        [HttpGet("{id}")]
        public object GetContact(int id)
        {
            var GetById = _contactRepository.GetById(id);
            var json = JsonConvert.SerializeObject(GetById, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }

        [HttpPost]
        public async Task<ActionResult<Contact>> PostContact([FromBody] Contact c)
        {
            var newContact = await _contactRepository.Create(c);
            return CreatedAtAction(nameof(GetContact), new { id = newContact.Id }, newContact);
        }

        [HttpPut]
        public object PutContact(int id, [FromBody] Contact c)
        {
            if (id != c.Id)
            {
                return BadRequest();
            }
           var getDataById = _contactRepository.Update(c);
            //return NoContent();

            var json = JsonConvert.SerializeObject(getDataById, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteContact(int id)
        {
            var contactToDelete = _contactRepository.GetById(id);
            if (contactToDelete == null)
            {
                return NotFound();
            }
            await _contactRepository.Delete(contactToDelete.Id);
            return NoContent();
        }
    }
}
