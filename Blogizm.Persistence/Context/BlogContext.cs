using Blogizm.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Persistence.Context
{
    public class BlogContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=BORAPC;initial Catalog=BlogizmDb;integrated Security=true;TrustServerCertificate=true;").EnableSensitiveDataLogging();
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<AboutBanner> AboutBanners {  get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<Category> Categories {  get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ContactAddress> ContactAddresses { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
