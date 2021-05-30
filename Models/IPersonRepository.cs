using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTaskMVC.Models
{
    public interface IPersonRepository
    {
        IList<Person> AllPeople { get; }

    }
}
