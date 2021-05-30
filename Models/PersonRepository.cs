using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTaskMVC.Models
{
    public class PersonRepository : IPersonRepository
    {
       
        public IList<Person> AllPeople =>
            new List<Person>
            {
                new Person{PersonId=1, FirstName="Emil", LastName="Ringwall", City="Kungsbacka", PhoneNumber="0124-752347", Gender="Male"},
                new Person{PersonId=2, FirstName="Anna", LastName="Persdotter", City="Gävle", PhoneNumber="0536-478953", Gender="Female"},
                new Person{PersonId=3, FirstName="Peter", LastName="Bengtsberg", City="Stockholm", PhoneNumber="0358-164872", Gender="Male"},
                new Person{PersonId=4, FirstName="Johanna", LastName="Karlsson", City="Bengtsfors", PhoneNumber="0248-784253", Gender="Female"}
            };

        public Person GetPersonById(int personId)
        {
            return AllPeople.FirstOrDefault(p => p.PersonId == personId);
        }

    }
}
