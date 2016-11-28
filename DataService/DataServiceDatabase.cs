using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
//using DataModels;

namespace DataService
{
    public class DataServiceDatabase : DbContext
    {
      /*  public DbSet<Script> Scripts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {   
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Script>().ToTable("writer");
        }*/
    }
}
