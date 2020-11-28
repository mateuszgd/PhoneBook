using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneBook.Models
{
    public class Person
    {
        public string Name { get; set; }
        public string Office { get; set; }
        public string PhoneNumber { get; set; }
        public string ExtensionPhoneNumber { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public string Title { get; set; }
        public int DepartmentNumber { get; set; }
        public string Subdivision { get; set; }
        public string Manager { get; set; }
        public string Mobile { get; set; }
        public int EmployeeNumber { get; set; }
    }
}