using BackendTaskMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTaskMVC.ViewModels
{
    public class ProjectViewModel
    {
        public IEnumerable<Project> Projects { get; set; }
    }
}
