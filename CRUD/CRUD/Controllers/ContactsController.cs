using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRUD.Data;
using CRUD.Models;
using CRUD.Interfaces;

namespace CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private IContact _contact;
        public ContactsController(IContact contact)
        {
            _contact = contact;
        }

        // GET: api/Contacts

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> Getcontacts()
        {
            var list = _contact.GetAll();
            return Ok(list);
        }

        // GET: api/Contacts/5

        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContact(int id)
        {
            var contact =await _contact.GetOneById(id);

            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutContact(int id, Contact contact)
        {
            if (id != contact.Id)
            {
                return BadRequest();
            }
            await _contact.Update(contact);

            return Ok(contact);
        }


        [HttpPost]
        public async Task<ActionResult<Contact>> PostContact(Contact contact)
        {

            await _contact.Add(contact);

            return CreatedAtAction("GetContact", new { id = contact.Id }, contact);
        }

        // DELETE: api/Contacts/5

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var contact = await _contact.GetOneById(id);

            if (contact == null)
            {
                return NotFound();
            }

            await _contact.Delete(id);

            return Ok();
        }

        private async Task<bool> ContactExists(int id)
        {
          return  await _contact.Exists(id);
        }
    }
}