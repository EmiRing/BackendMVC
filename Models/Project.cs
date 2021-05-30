using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTaskMVC.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string controllerString { get; set; }
        public string actionString { get; set; }
        
        
    }
}
