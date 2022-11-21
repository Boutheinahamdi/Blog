
using Blog1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Blog1.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpclient;
        private readonly HttpClient _httpclientProject;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IHttpClientFactory httpClientFactory,ILogger<HomeController> logger)
        {
            
            _logger = logger;
            _httpclient = httpClientFactory.CreateClient("BlogAPI");
            _httpclientProject = httpClientFactory.CreateClient("Owner");
        }

        public async Task <IActionResult >Index()
        {
            var response = await _httpclient.GetAsync("/api/Blog");
            var content= await response.Content.ReadAsStringAsync();    
            var BlogList= JsonConvert.DeserializeObject<IEnumerable<Blog>>(content);
            return View(BlogList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> blog()
        {
            var response = await _httpclient.GetAsync("/api/Blog");
            var content = await response.Content.ReadAsStringAsync();
            var BlogList = JsonConvert.DeserializeObject<IEnumerable<Blog>>(content);
            var blog=BlogList.First();
            return View(blog);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public async Task<IActionResult> project()
        {
            var response = await _httpclientProject.GetAsync("/api/Project");
            var content = await response.Content.ReadAsStringAsync();
            var ProjectList = JsonConvert.DeserializeObject<IEnumerable<Project>>(content);
            var project = ProjectList.First();
            return View(project);
        }
    }
}
