using CRUD.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Interfaces.Services
{
    public class ContactServices : IContact
    {
        ContactsAPIDbContext _db;
        public ContactServices(ContactsAPIDbContext db)
        {
            _db = db;
        }

        public async Task<Models.Contact> Add(Models.Contact contact)
        {
            await _db.contacts.AddAsync(contact);
            await _db.SaveChangesAsync();

            return contact;
        }

        public async Task<Models.Contact> Delete(int contactId)
        {
            var student = await _db.contacts.FirstOrDefaultAsync(t => t.Id == contactId);
            _db.contacts.Remove(student);
            await _db.SaveChangesAsync();

            return (student);
        }

        public async Task<bool> Exists(int contactId)
        {
            return await _db.contacts.AnyAsync(c => c.Id == contactId);
        }

        public List<Models.Contact> GetAll()
        {
            return _db.contacts.ToList();
        }

        public async Task<Models.Contact> GetOneById(int contactId)
        {
            var item = await _db.contacts.FirstOrDefaultAsync(t => t.Id == contactId);

            return item;
        }

        public async Task<Models.Contact> Update(Models.Contact contact)
        {
            _db.contacts.Update(contact);
            await _db.SaveChangesAsync();

            return contact;
        }
    }
}