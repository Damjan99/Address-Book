using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace AddressBook.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PersonInfo(
                serviceProvider.GetRequiredService<
                    DbContextOptions<PersonInfo>>()))
            {
                if (context.Person.Any())
                {
                    return;   
                }

                context.Person.AddRange(

                    new Person
                    {
                        First_Name = "Damjan",
                         Last_Name = "Dimitrov",
                         Address = "Prisoje 9",
                         Telephone_Number = "069 983 065"
                    },

                    new Person
                    {
                        First_Name = "Janez",
                        Last_Name = "Novak",
                        Address = "Kraljeva Ulica 20",
                        Telephone_Number = "232 466 012"
                    },

                    new Person
                    {
                        First_Name = "Nikita",
                        Last_Name = "Khatskevich",
                        Address = "Avstrovska Ulica 3",
                        Telephone_Number = "072 983 202"
                    },
                  
                    new Person
                    {
                        First_Name = "Angela",
                        Last_Name = "Ignovska",
                        Address = "Titov Trg 20",
                        Telephone_Number = "069 212 991"
                    },

                    new Person
                    {
                        First_Name = "Marko",
                        Last_Name = "Vidmar",
                        Address = "Ljubljanska 14",
                        Telephone_Number = "051 243 318"
                    },

                    new Person
                    {
                         First_Name = "Martin",
                         Last_Name = "Gajdov",
                         Address = "Wundergarten 152",
                         Telephone_Number = "910 123 654"
                    },

                    new Person
                    {
                        First_Name = "John",
                        Last_Name = "Smith",
                        Address = "North Street 115",
                        Telephone_Number = "091 712 842"
                    },

                    new Person
                    {
                        First_Name = "Anita",
                        Last_Name = "Kavsek",
                        Address = "Trubarjeva Ulica 19",
                        Telephone_Number = "091 712 842"
                    },

                    new Person
                    {
                        First_Name = "Gorjan",
                        Last_Name = "Dimitrov",
                        Address = "Blagoj Nechev 46",
                        Telephone_Number = "070 342 007"
                    }


                );
                context.SaveChanges();
            }
        }
    }
}