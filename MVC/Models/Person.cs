using System;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Address { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }
}
