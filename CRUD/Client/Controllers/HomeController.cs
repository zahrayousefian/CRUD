using Client.Interfaces;
using Client.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class HomeController : Controller
    {
        private IContact _contact;

        public HomeController(IContact contact)
        {
            _contact = contact;
        }


        public IActionResult Index()
        {
            var data = _contact.GetAll();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return View(contact);
            }
            else
            {
                _contact.Add(contact);

                return RedirectToAction("Index");
            }

        }

        public async Task<IActionResult> Edit(int id)
        {
            var contacts = await _contact.GetOneById(id);
            return View(contacts);
        }

        public IActionResult Delete(int id)
        {
            _contact.Delete(id);
            return RedirectToAction("Index");
        }



        [HttpPost]
        public IActionResult Edit(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return View(contact);
            }
            _contact.Update(contact);
            return RedirectToAction("Index");
        }
    }
}
