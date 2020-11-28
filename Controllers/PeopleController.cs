using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhoneBook.Models;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;

namespace PhoneBook.Controllers
{
    public class PeopleController : Controller
    {
        public ActionResult Home(string department)
        {
            IEnumerable<Person> persons = GetPeople()
                .Where(p => department == null || p.Department.ToLowerInvariant().Replace(' ', '-')
                .Replace('ą', 'a').Replace('ć', 'c').Replace('ę', 'e').Replace('ł', 'l').Replace('ń', 'n')
                .Replace('ó', 'o').Replace('ś', 's').Replace('ź', 'z').Replace('ż', 'z') == department)
                .OrderBy(m => m.DepartmentNumber).ThenBy(m => m.EmployeeNumber);

            return View(persons);
        }

        public static List<Person> GetPeople()
        {
            List<Person> people = new List<Person>();

            var path = new PrincipalContext(ContextType.Domain, "test", "DC=test, DC=local");

            UserPrincipal user = new UserPrincipal(path);
            user.Enabled = true;
            user.Name = "*";
            user.VoiceTelephoneNumber = "*";
            user.EmailAddress = "*";
            user.Description = "*";

            var search = new System.DirectoryServices.AccountManagement.PrincipalSearcher();
            search.QueryFilter = user;
            var results = search.FindAll();

            foreach (UserPrincipal item in results)
            {
                var directoryEntry = item.GetUnderlyingObject() as DirectoryEntry;

                people.Add(new Person
                {
                    Name = item.Name,
                    PhoneNumber = "45-29-" + item.VoiceTelephoneNumber,
                    ExtensionPhoneNumber = item.VoiceTelephoneNumber,
                    Email = item.EmailAddress,
                    Office = directoryEntry.Properties["physicalDeliveryOfficeName"].Value as string,
                    Department = item.Description,
                    Title = directoryEntry.Properties["title"].Value as string,
                    DepartmentNumber = Convert.ToInt32(directoryEntry.Properties["departmentNumber"].Value),
                    Subdivision = directoryEntry.Properties["department"].Value as string,
                    Manager = directoryEntry.Properties["manager"].Value as string,
                    Mobile = directoryEntry.Properties["mobile"].Value as string,
                    EmployeeNumber = Convert.ToInt32(directoryEntry.Properties["employeeNumber"].Value)
                });
            }
            return people;
        }

        public PartialViewResult Menu()
        {
            IEnumerable<string> departments = GetPeople()
                .Select(x => x.Department)
                .Distinct()
                .OrderBy(x => x);

            return PartialView(departments);
        }

        public PartialViewResult Details(string name)
        {
            Person person = GetPeople()
                .Find(x => x.Name == name);
            return PartialView(person);
        }
    }
}