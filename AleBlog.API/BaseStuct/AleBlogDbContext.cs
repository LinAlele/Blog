using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AleBlog.API.Model.Entity.Blog;
using Microsoft.EntityFrameworkCore;

namespace AleBlog.API.BaseStuct
{
    public class AleBlogDbContext:DbContext
    {
        public DbSet<Page> Page { get; set; }
        public DbSet<stu> Stu { get; set; }
    
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"DataSource={AppDomain.CurrentDomain.BaseDirectory + "db" +"\\"+"AleNet.db"}");
        }
    }
    
}
