using BackendTaskMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTaskMVC.ViewModels
{
    public class PersonViewModel
    {
        public IList<Person> People { get; set; }
        public string SortBy { get; set; }
    }
}
