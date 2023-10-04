using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace To_Do_List_Web_Application.Models
{
    public class SysContext: DbContext
    {
        public DbSet<Users> Users { get; set; }
        public virtual DbSet<Tasks> Tasks   { get; set; }
        public SysContext() : base()
        {

        }
        //inject ask ioc container 
        public SysContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Tasks>().Property(m => m.IsCompleted).HasDefaultValue(false);

        }
    }
}
