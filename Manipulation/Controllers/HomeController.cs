using Manipulation.Models;
using Manipulation.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Manipulation.Controllers
{
    public class HomeController : Controller
    {

        private readonly ProjectService _projectService;

        public HomeController (ProjectService projectService)
        {
            _projectService = projectService;
        }
        public async Task<IActionResult> Index()
        {
            List<Project> l = _projectService.Get();
            var vm = new ViewModel
            {
                projects = l
            };
            return View(vm);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
   
        public async  Task<IActionResult> Create(Project model)
        {
            

                  Project projet = new Project
                {
                    content = model.content,
                    Description = model.Description,
                    title = model.title
                };

            _projectService.Create(projet);


            return RedirectToAction(nameof(Index));
        }
    }
}
