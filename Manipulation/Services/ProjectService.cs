using Manipulation.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Manipulation.Services
{
    public class ProjectService
    {
        private readonly IMongoCollection<Project> _projects;

        public ProjectService(IProjecttoreDatabaseSettings settings, IConfiguration configuration)
        {
            /*var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);*/
            var client = new MongoClient(configuration["DataBaseSettings:ConnectionString"]);
            var database = client.GetDatabase(configuration["DataBaseSettings:DatabaseName"]);

            /*_projects = database.GetCollection<Project>(settings.CollectionName);*/
            _projects = database.GetCollection<Project>(configuration["DataBaseSettings:CollectionName"]);
        }

        public List<Project> Get() =>
            _projects.Find(project => true).ToList();

        public Project Get(string id) =>
            _projects.Find<Project>(project => project.ID == id).FirstOrDefault();

        public Project Create(Project project)
        {
            _projects.InsertOne(project);
            return project;
        }

        public void Update(string id, Project bookIn) =>
            _projects.ReplaceOne(project => project.ID == id, bookIn);

        public void Remove(Project projectn) =>
            _projects.DeleteOne(project => project.ID == projectn.ID);

        public void Remove(string id) =>
            _projects.DeleteOne(project => project.ID == id);
    }
}
