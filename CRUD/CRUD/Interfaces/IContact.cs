using CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Interfaces
{
  public  interface IContact
    {
        List<Contact> GetAll();
        Task<Contact> GetOneById(int contactId);
        Task<Contact> Add(Contact contact);
        Task<Contact> Update(Contact contact);
        Task<Contact> Delete(int contactId);
        Task<bool> Exists(int contactId);
    }
}
