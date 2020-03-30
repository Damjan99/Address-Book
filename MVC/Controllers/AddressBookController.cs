using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC.Data;
using MVC.Models;
using Newtonsoft.Json;

namespace MVC.Controllers
{
    public class AddressBookController : Controller
    {
        private readonly DataContext _context;

        public AddressBookController(DataContext context)
        {
            _context = context;
        }

        // GET: AddressBook
        public async Task<IActionResult> Index(string name, string lastName, string address, string phone)
        {
            var person = from m in _context.Person
                         select m;

            if (!String.IsNullOrEmpty(name))
                person = person.Where(p => p.Name.Contains(name));

            if (!String.IsNullOrEmpty(lastName))
                person = person.Where(p => p.Name.Contains(lastName));

            if (!String.IsNullOrEmpty(address))
                person = person.Where(p => p.Address.Contains(address));

            if (!String.IsNullOrEmpty(phone))
                person = person.Where(p => p.PhoneNumber.Contains(phone));

            return View(await person.ToListAsync());
        }

        // GET: AddressBook/Details/5
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Person
                .FirstOrDefaultAsync(m => m.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // GET: AddressBook/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: AddressBook/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,LastName,Address,PhoneNumber")] Person person)
        {
            if (ModelState.IsValid)
            {
                _context.Add(person);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        // GET: AddressBook/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Person.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        // POST: AddressBook/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,LastName,Address,PhoneNumber")] Person person)
        {
            if (id != person.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(person);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonExists(person.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        // GET: AddressBook/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Person
                .FirstOrDefaultAsync(m => m.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // POST: AddressBook/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var person = await _context.Person.FindAsync(id);
            _context.Person.Remove(person);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> JSON()
        {
            ExportDataToJson();

            var person = from m in _context.Person select m;
            return View(await person.ToListAsync());
        }

        public void ExportDataToJson()
        {
            // Different OS have different paths to home directory
            string homePath = (
                Environment.OSVersion.Platform == PlatformID.Unix ||
                Environment.OSVersion.Platform == PlatformID.MacOSX)
    ? Environment.GetEnvironmentVariable("HOME")
    : Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");

            var json = JsonConvert.SerializeObject(_context.Person, Formatting.Indented);
            //Response.Write("<script>alert('Data inserted successfully')</script>");
            //Response.
            System.IO.File.WriteAllText(homePath + "/data.json", json);
        }

        private bool PersonExists(int id)
        {
            return _context.Person.Any(e => e.Id == id);
        }
    }
}
