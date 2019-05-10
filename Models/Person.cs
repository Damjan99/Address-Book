using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AddressBook.Models
{   

    public class MyContext : DbContext
    {
        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasIndex(p => new { p.First_Name})
                .IsUnique(true);
        }
    }

    public class Person
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "First Name is required.")]

        [Display(Name = "First Name")]
        public string First_Name { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [Display(Name = "Last Name")]
        public string Last_Name { get; set; }

        [Required(ErrorMessage ="Address is required.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Telephone Number is required.")]
        [Display(Name = "Telephone Number")]
        public string Telephone_Number { get; set; }




    }

   
}