using BackendTaskMVC.Models;
using BackendTaskMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTaskMVC.Controllers
{
    
    public class ProjectsController : Controller
    {
        private readonly IProjectRepository _projectRepository;
        static IEnumerable<Project> project;

        public ProjectsController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public IActionResult Index()
        {
            if (project == null) project = _projectRepository.AllProjects;

            return View(new ProjectViewModel
            {
                Projects = project
            });
        }
        public RedirectToActionResult DisplayProject(int id)
        {
            
            var selectedProject = _projectRepository.AllProjects.FirstOrDefault(p => p.ProjectId == id);
            string controller = selectedProject.controllerString;
            string action = selectedProject.actionString;

            return RedirectToAction(action, controller);
        }



    }
}
