using ExecutiveDocumentation.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecutiveDocumentation
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("DefaultConnection")
        {

        }
       public DbSet<ConstructionObject> ConstructionObjects { get; set; }
        public DbSet<Kontragent> Kontragents { get; set; }
        // public DbSet<ProjectForObject> ProjectForObjects { get; set; }
        //  public DbSet<ResponsiblPerson> ResponsiblPersons { get; set; }
       
    }
}

