using BackendTaskMVC.Models;
using BackendTaskMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTaskMVC.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonRepository _personRepository;
        static Func<Person, string> _orderByFunc;
        static Func<Person, string> _tempOrderByFunc;
        static IList<Person> people;
        static IList<Person> _tempPeople;
        static bool ascending = true;
        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
            
        }
        
       public IActionResult PersonList()
        {
            if(people == null) people = _personRepository.AllPeople;
            
            return View(new PersonViewModel
            {
                People = people
            });
        }

        public IActionResult UpdatePersonList()
        {
            return View();
        }

        public RedirectToActionResult Sort(string sortBy)
        {
            
            switch (sortBy)
            {
                case "FirstName":
                    _orderByFunc = p => p.FirstName;
                    break;
                case "LastName":
                    _orderByFunc = p => p.LastName;
                    break;
                case "Phone":
                    _orderByFunc = p => p.PhoneNumber;
                    break;
                case "City":
                    _orderByFunc = p => p.City;
                    break;
                case "Gender":
                    _orderByFunc = p => p.Gender;
                    break;
                default:
                    _orderByFunc = p => p.FirstName;
                    break;
            }
            
            people = SortList(_orderByFunc);

            return RedirectToAction("PersonList");
        }

        public RedirectToActionResult AddPersonToList(Person personToAdd)
        {
            var highestId = people.Any() ? people.Max(x => x.PersonId) : 1;
            personToAdd.PersonId = highestId + 1;
            people.Add(personToAdd);
            
            foreach (var person in people) Debug.WriteLine(person.FirstName);
            
            return RedirectToAction("PersonList");
        }

        public RedirectToActionResult RemovePerson (int id)
        {
            var n = people.Where(x => x.PersonId == id).First();
            people.Remove(n);
            
            return RedirectToAction("PersonList");
        }

        public RedirectToActionResult FilterList(string filter, string filterBtn)
        {
            if (_tempPeople == null) _tempPeople = people;
            if (filterBtn == "Reset")
            {
                people =  _tempPeople;
               
                return RedirectToAction("PersonList");
            }

            var query = from person in people
                        where person.FirstName == filter || person.LastName == filter || person.City == filter
                        select person;
            people = query.ToList();

            return RedirectToAction("PersonList");
        }

        private IList<Person> SortList(Func<Person, string> orderByFunc)
        {
            IList<Person> _sortedPerson;
            IEnumerable<Person> sortedEnum;
            if (orderByFunc == null) orderByFunc = p => p.FirstName;
            if (_tempOrderByFunc != null && _tempOrderByFunc.Equals(orderByFunc) && ascending)
            {
                sortedEnum = people.OrderByDescending(orderByFunc);
                _sortedPerson = sortedEnum.ToList();
                ascending = false;
                return _sortedPerson;
            }

            sortedEnum = people.OrderBy(orderByFunc);
            _sortedPerson = sortedEnum.ToList();
            ascending = true;
            _tempOrderByFunc = orderByFunc;
            return _sortedPerson;
        }

    }
}
