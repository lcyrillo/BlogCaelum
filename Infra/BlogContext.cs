using System.IO;
using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Blog.Infra
{
    public class BlogContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                          .SetBasePath(Directory.GetCurrentDirectory())
                          .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                          .AddEnvironmentVariables();
            IConfiguration configuration = builder.Build();
            string stringConexao = configuration.GetConnectionString("Blog");
            optionsBuilder.UseSqlServer(stringConexao);
        }

        public DbSet<Post> Posts { get; set; }
    } 
}
