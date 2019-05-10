using Microsoft.EntityFrameworkCore;
using System;

namespace AddressBook.Models
{
    public class PersonInfo : DbContext
    {
        public PersonInfo(DbContextOptions<PersonInfo> options)
            : base(options)
        {
        }

        public DbSet<AddressBook.Models.Person> Person { get; set; }
    }
}