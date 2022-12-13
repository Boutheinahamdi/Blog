
using Blog1.Models;
using Blog1.ViewModel;
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
        private readonly HttpClient _httpclientOwner;
        private readonly ILogger<HomeController> _logger;
       

        public HomeController(IHttpClientFactory httpClientFactory,ILogger<HomeController> logger)
        {
           
            _logger = logger;
            _httpclient = httpClientFactory.CreateClient("BlogAPI");
            _httpclientProject = httpClientFactory.CreateClient("ProjectAPI");
            _httpclientOwner = httpClientFactory.CreateClient("OwnerAPI");
        }

        public async Task <IActionResult >Index()
        {   //blog list serialization
            var response = await _httpclient.GetAsync("/api/Blog");
            var content= await response.Content.ReadAsStringAsync();    
            var BlogList= JsonConvert.DeserializeObject<IEnumerable< Blog>>(content);
            //serialization of project
            var response1 = await _httpclientProject.GetAsync("/api/Project");
            var content1 = await response1.Content.ReadAsStringAsync();
            var ProjectList = JsonConvert.DeserializeObject<IEnumerable<Project>>(content1);
            //serialization of owner content
            var response2 = await _httpclientOwner.GetAsync("/api/Owner");
            var content2 = await response2.Content.ReadAsStringAsync();
            var OwnerList = JsonConvert.DeserializeObject<IEnumerable<Owner1>>(content2);
            var vm1 = new ProjetViewModel {
                blog = (List<Blog>)BlogList,
                project= (List<Project>)ProjectList,
                owner1= (List<Owner1>)OwnerList
            };
               
                
               
            
            return View(vm1);
        
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
            Blog blog = BlogList.First();
           
         
            return View(blog);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
       /* public async Task<IActionResult> project()
        {
            var response = await _httpclientProject.GetAsync("/api/Project");
            var content = await response.Content.ReadAsStringAsync();
            var ProjectList = JsonConvert.DeserializeObject<IEnumerable<Project>>(content);
            var project = ProjectList.First();
            return View(project);
        }*/
    }
}
