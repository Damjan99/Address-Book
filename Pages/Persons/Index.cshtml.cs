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

namespace AddressBook.Pages.Movies
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

        public SelectList LastNames { get; set; }
        [BindProperty(SupportsGet = true)]
        public string LastName { get; set; }



        public async Task OnGetAsync() 
        {
            IQueryable<string> lastnameQuery = from p in _context.Person
                                            orderby p.Last_Name
                                            select p.Last_Name;

            var persons = from p in _context.Person
                         select p;

            if (!string.IsNullOrEmpty(SearchFirstName))
            {
                persons = persons.Where(s => s.First_Name.Contains(SearchFirstName));
            }

            if (!string.IsNullOrEmpty(LastName))
            {
                persons = persons.Where(x => x.Last_Name == LastName);
            }

            LastNames = new SelectList(await lastnameQuery.Distinct().ToListAsync());
            Person = await persons.ToListAsync();
        }

       







    }
}
