using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AddressBook.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace AddressBook.Pages.Persons
{
    public class IndexModel : PageModel
    {
        private readonly AddressBook.Models.PersonInfo _context;

        public IndexModel(AddressBook.Models.PersonInfo context)
        {
            _context = context;
        }

        public IList<Person> Person { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchFirstName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchLastName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchAddress { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTelNum { get; set; }



        public async Task OnGetAsync() 
        {

            var persons = from p in _context.Person
                         select p;

            if (!string.IsNullOrEmpty(SearchFirstName))
            {
                persons = persons.Where(s => s.First_Name.Contains(SearchFirstName));
            }

            if (!string.IsNullOrEmpty(SearchLastName))
            {
                persons = persons.Where(s => s.Last_Name.Contains(SearchLastName));
            }

            if (!string.IsNullOrEmpty(SearchAddress))
            {
                persons = persons.Where(s => s.Address.Contains(SearchAddress));
            }

            if (!string.IsNullOrEmpty(SearchTelNum))
            {
                persons = persons.Where(s => s.Telephone_Number.Contains(SearchTelNum));
            }

            Person = await persons.ToListAsync();
        }
    }
}
