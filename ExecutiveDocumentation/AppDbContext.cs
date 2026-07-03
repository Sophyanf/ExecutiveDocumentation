
using System.Data.Entity;
using ExecutiveDocumentation.Models;

namespace ExecutiveDocumentation
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("DefaultConnection") { }

        public DbSet<ConstructionObject> ConstructionObjects { get; set; }
        public DbSet<Kontragent> Kontragents { get; set; }
        public DbSet<ProjectForObject> ProjectForObjects { get; set; }
        public DbSet<ResponsiblPerson> ResponsiblPersons { get; set; }
        public DbSet<WorkType> WorkTypes { get; set; }
        public DbSet<WorksTypeObg> WorksTypeObgs { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProjectForObject>()
                .HasRequired(p => p.ConstructionObject)   // Проект ТРЕБУЕТ объект (не nullable в логике)
                .WithMany()                               // У объекта МОЖЕТ БЫТЬ много проектов (для EF6 это вынужденный компромисс)
                .HasForeignKey(p => p.ConstructionObjectId);
        }
    }
}