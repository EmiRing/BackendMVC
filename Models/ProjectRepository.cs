using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTaskMVC.Models
{
    public class ProjectRepository: IProjectRepository
    {
        

        public IEnumerable<Project> AllProjects =>
            new List<Project>
            {
                new Project{ProjectId=1, Name="Fever", ShortDescription="Check if you have a fever", controllerString="Fever", actionString="Evaluate" },
                new Project{ProjectId=2, Name="Guessing Game", ShortDescription="Guess the random number generated", controllerString="GuessingGame", actionString="Index" },
                new Project{ProjectId=3, Name="List of people", ShortDescription="Handle a list of people", controllerString="Person", actionString="PersonList" }
            };

        public Project GetProjectById(int projectId)
        {
            return AllProjects.FirstOrDefault(p => p.ProjectId == projectId);
        }
    }
}
