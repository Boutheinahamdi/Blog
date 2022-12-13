using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using ProjectAPII.Models;
using System.Collections.Generic;

namespace ProjectAPII.Data
{
    public class ProjectContext
    {
        public ProjectContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["DataBaseSettings:ConnectionString"]);
            var database = client.GetDatabase(configuration["DataBaseSettings:DatabaseName"]);
            projects = database.GetCollection<Project>(configuration["DataBaseSettings:CollectionName"]);
            seedData(projects);
        }
        public IMongoCollection<Project> projects { get; }
    public static void seedData(IMongoCollection<Project> blogsCollection)
    {
        bool existBlog = blogsCollection.Find(b => true).Any();
        if (!existBlog)
        {
            blogsCollection.InsertMany(GetPreconfBlogs());
        }
    }
    private static IEnumerable<Project> GetPreconfBlogs()
    {
        return new List<Project>()
            {
                new Project() {

            title="Mobile Application",
            content="Mobile Application developped with React Native and hosted on Azure app center",
        
            Description="React Native is a JavaScript mobile framework developed by Facebook",
            urlImage="image"

                          }
            };
    }
}
           
    }
