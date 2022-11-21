using BlogAPI.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;

namespace BlogAPI.Data
{
    public class BlogContext
    {
        public BlogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["DataBaseSettings:ConnectionString"]);
            var database = client.GetDatabase(configuration["DataBaseSettings:DatabaseName"]);
            blogs = database.GetCollection<Blog>(configuration["DataBaseSettings:CollectionName"]);
            seedData(blogs);
        }
        public IMongoCollection<Blog> blogs { get; }
        public static void seedData(IMongoCollection<Blog> blogsCollection)
        {
            bool existBlog = blogsCollection.Find(b => true).Any();
            if (!existBlog)
            {
                blogsCollection.InsertMany(GetPreconfBlogs());
            }
        }
        private static IEnumerable<Blog> GetPreconfBlogs()
        {
            return new List<Blog>()
            {
                new Blog() {
           
            title="Middlware",
            Content="this is content",
            date="1/01/2022",
            Description="this is desc",
            urlImage="sdkfsl"

                          }
            };
        }
    }
}

            



