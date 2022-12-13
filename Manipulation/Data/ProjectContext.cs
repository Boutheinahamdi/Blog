using Manipulation.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System.Collections.Generic;

namespace Manipulation.Data
{
     public class ProjectContext
    {
        MongoClient _client;
        MongoServer _server;
        MongoDatabase _db;
        public ProjectContext(IConfiguration configuration)
        {
            _client = new MongoClient(configuration["DataBaseSettings:ConnectionString"]);
            var database = _client.GetDatabase(configuration["DataBaseSettings:DatabaseName"]);
            var collection = database.GetCollection<Project>(configuration["DataBaseSettings:CollectionName"]);
            List<Project> projectsList =  collection.Find(new BsonDocument()).ToList();

        }
       /* public IEnumerable<Project> GetProjects()
        {
            
            return;
        }

        public Project GetProjects(string id)
        {
            var res = Query<Project>.EQ(p => p.ID, id);
            return _db.GetCollection<Project>("project").FindOne(res);
        }
        public Project Create(Project p)
        {
            _db.GetCollection<Project>("project").Save(p);
            return p;
        }
        public void Update(string id, Project p)
        {
            p.ID = id;
            var res = Query<Project>.EQ(pd => pd.ID, id);
            var operation = Update<Project>.Replace(p);
            _db.GetCollection<Project>("project").Update(res, operation);
        }
        public void Remove(string id)
        {
            var res = Query<Project>.EQ(e => e.ID, id);
            var operation = _db.GetCollection<Project>("project").Remove(res);
        }*/
    }
}

