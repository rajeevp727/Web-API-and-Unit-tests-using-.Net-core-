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
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _addressRepository;
        public AddressController(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Address>> GetAddress()
        {
            return await _addressRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> GetAddress(int id)
        {
            return await _addressRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Address>> PostAddress([FromBody] Address a)
        {
            var newAddress = await _addressRepository.Create(a);
            return CreatedAtAction(nameof(GetAddress), new { id = newAddress.id }, newAddress);
        }

        [HttpPut]
        public async Task<ActionResult> PutAddress(int id, [FromBody] Address a)
        {
            if (id != a.id)
            {
                return BadRequest();
            }
            await _addressRepository.Update(a);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAddress(int id)
        {
            var addressToDelete = await _addressRepository.Get(id);
            if (addressToDelete == null)
            {
                return NotFound();
            }
            await _addressRepository.Delete(addressToDelete.id);
            return NoContent();
        }
    }
}
