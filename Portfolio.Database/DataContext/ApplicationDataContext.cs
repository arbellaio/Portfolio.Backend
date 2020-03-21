using System;
using Microsoft.EntityFrameworkCore;
using Portfolio.Models.Content;
using Portfolio.Models.Image;

namespace Portfolio.Database.DataContext
{
    public class ApplicationDataContext : DbContext
    {
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : base(options)
        {
        }
       
        public DbSet<Content> Contents { get; set; }
        public DbSet<ImagePath> ImagePaths { get; set; }
    }
}
