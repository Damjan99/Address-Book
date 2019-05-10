using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AddressBook.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace AddressBook.Pages.Persons
{
    public class CreateModel : PageModel
    {
        private readonly AddressBook.Models.PersonInfo _context;

        public CreateModel(AddressBook.Models.PersonInfo context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();

        }
        [BindProperty]
        public Person Person { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Person.Add(Person);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

       
    }
}