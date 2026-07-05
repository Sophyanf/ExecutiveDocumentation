
using System.Data.Entity;
using ExecutiveDocumentation.Models;

namespace ExecutiveDocumentation
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("DefaultConnection") { }
        public DbSet<Adress> Adresses { get; set; }
        public DbSet<Kontragent> Kontragents { get; set; }
        public DbSet<KadastrID> KadastrIDs { get; set; }
        public DbSet<TypeOfObject> TypeOfObjects { get; set; }
        public DbSet<ResponsiblPerson> ResponsiblPersons { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<ConstructionObject> ConstructionObjects { get; set; }
    }
}