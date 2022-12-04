using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Owner.Models;
using System.Collections.Generic;

namespace Owner.Data
{
    public class OwnerContext
    {
        public OwnerContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["DataBaseSettings:ConnectionString"]);
            var database = client.GetDatabase(configuration["DataBaseSettings:DatabaseName"]);
            owner = database.GetCollection<Owner1>(configuration["DataBaseSettings:CollectionName"]);
            seedData(owner);
        }
        public IMongoCollection<Owner1> owner { get; }
        public static void seedData(IMongoCollection<Owner1> blogsCollection)
        {
            bool existBlog = blogsCollection.Find(b => true).Any();
            if (!existBlog)
            {
                blogsCollection.InsertMany(GetPreconfBlogs());
            }
        }
        private static IEnumerable<Owner1> GetPreconfBlogs()
        {
            return new List<Owner1>()
            {
                new Owner1() {

           name="Ingenieur En Issat",
           age=22,
           description="kubernetes Developper",
           adress="sousse-Tunis",
           email="KubernetesOwner@outlook.com",
           phone=33256478,
           smalldesc="software engenner||cloud||DevOps",
           urlimage="this is an url"





                          }
            };
        }
    }
}

