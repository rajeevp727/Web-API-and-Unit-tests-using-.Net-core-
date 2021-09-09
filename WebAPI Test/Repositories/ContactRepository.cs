using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_Test.Models;

namespace WebAPI_Test.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly Models.ApplicationDbContext _context;
        public ContactRepository(Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Contact> Create(Contact c)
        {
            c.CreatedDate = DateTime.Now;
            _context.Contact.Add(c);
            await _context.SaveChangesAsync();
            return c;
        }

        public async Task Delete(int id)
        {
            var contactToDelete = await _context.Contact.FindAsync(id);
            _context.Contact.Remove(contactToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Contact>> Get()
        {
            return await _context.Contact.ToListAsync();
        }

        public Contact GetById(int id)
        {
            return /*await*/ _context.Contact.Where(x=>x.Id==id).FirstOrDefault(); /*FindAsync(id);*/
        }

        public async Task Update(Contact c)
        {
            c.ModifiedDate = DateTime.Now;
            _context.Entry(c).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
