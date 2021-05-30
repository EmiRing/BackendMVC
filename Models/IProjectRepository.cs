using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTaskMVC.Models
{
    public interface IProjectRepository
    {
        IEnumerable<Project> AllProjects { get; }
        Project GetProjectById(int projectId);
    }
}
