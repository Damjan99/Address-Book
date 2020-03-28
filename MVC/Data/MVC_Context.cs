using System;
using Microsoft.EntityFrameworkCore;
using MVC.Models;

namespace MVC.Data
{
    public class MVC_Context : DbContext
    {
        public MVC_Context(DbContextOptions<MVC_Context> options)
            : base(options)
        {
        }

        public DbSet<Person> Person { get; set; }
    }
}
