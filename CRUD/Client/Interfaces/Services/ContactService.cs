using Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;

namespace Client.Interfaces.Services
{
    public class ContactService : IContact
    {
        private HttpClient _client;
        public ContactService()
        {
            _client = new HttpClient();
        }
        string apiUrl = "https://localhost:44311";
        public async Task<Contact> Add(Contact contact)
        {
            string json = JsonConvert.SerializeObject(contact);

            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            await _client.PostAsync(apiUrl + "/Api/Contacts", stringContent);

            return contact;
        }

        public void Delete(int contactId)
        {
            var res = _client.DeleteAsync(apiUrl + "/Api/Contacts" + "/" + contactId);
        }



        public List<Contact> GetAll()
        {
            var json = _client.GetStringAsync(apiUrl + "/Api/Contacts").Result;
            var contacts = JsonConvert.DeserializeObject<List<Contact>>(json);
            return contacts;
        }

        public async Task<Contact> GetOneById(int contactId)
        {
            var json = _client.GetStringAsync(apiUrl + "/Api/Contacts" + "/" + contactId).Result;
            var item = JsonConvert.DeserializeObject<Contact>(json);
            return item;
        }

        public async Task<Contact> Update(Contact contact)
        {
            var json = JsonConvert.SerializeObject(contact);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var result = _client.PutAsync(apiUrl + "/Api/Contacts" + "/" + contact.Id, stringContent).Result;
            return contact;
        }
    }
}
