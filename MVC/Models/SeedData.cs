using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MVC.Data;
using MVC.Models;
using System;

namespace MvcPerson.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DataContext(
                serviceProvider.GetRequiredService
                <DbContextOptions<DataContext>>()))
            {
                context.Person.AddRange(

                    new Person
                    {
                        Name = "Damjan",
                        Address = "Titov Trg 1",
                        PhoneNumber = "069 983 065"
                    },

                    new Person
                    {
                        Name = "Janez",
                        Address = "Kraljeva Ulica 20",
                        PhoneNumber = "232 466 012"
                    },

                    new Person
                    {
                        Name = "Nikita",
                        Address = "Avstrovska Ulica 3",
                        PhoneNumber = "072 983 202"
                    },

                    new Person
                    {
                        Name = "Angela",
                        Address = "Titov Trg 1",
                        PhoneNumber = "069 212 991"
                    },

                    new Person
                    {
                        Name = "Marko",
                        Address = "Ljubljanska 14",
                        PhoneNumber = "051 243 318"
                    },

                    new Person
                    {
                        Name = "Martin",
                        Address = "Wundergarten 152",
                        PhoneNumber = "910 123 654"
                    },

                    new Person
                    {
                        Name = "John",
                        Address = "North Street 115",
                        PhoneNumber = "091 712 842"
                    },

                    new Person
                    {
                        Name = "Anita",
                        Address = "Trubarjeva Ulica 19",
                        PhoneNumber = "091 712 842"
                    },

                    new Person
                    {
                        Name = "Gorjan",
                        Address = "Blagoj Nechev 46",
                        PhoneNumber = "070 342 007"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}