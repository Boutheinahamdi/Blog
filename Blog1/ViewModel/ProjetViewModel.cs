using Blog1.Models;
using System.Collections.Generic;

namespace Blog1.ViewModel
{
    public class ProjetViewModel
    {
        public List< Blog> blog { get; set; }
        public List<Project>  project { get; set; }
        public List<Owner1> owner1 { get; set; }
    }
}
