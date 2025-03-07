using Microsoft.EntityFrameworkCore;
using System;

namespace EF_Task.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=HITSS22\\SQLEXPRESS;Database=EFAssignmentDB;Trusted_Connection=True;");
        //}
    }
}
