using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsAndDevelopersMintaZH
{
    internal class ProjectDbContext : DbContext
    {
        //Készíts egy ProjectDbContext osztályt, valamint hozzá a szükséges MDF és LDF fájlokat.Hozz létre
        //    Projects és Developers táblákat! Állítsd be az idegen kulcsokat és a navigation propertyket!
        public DbSet<Project> Projects { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public ProjectDbContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\devs.mdf;Integrated Security=True;MultipleActiveResultSets=True");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Developer>()
                .HasOne(t => t.Project)
                .WithMany(t => t.Developers)
                .HasForeignKey(t => t.ProjectId);

            //Töltsd fel az adatbázist DB Seed-ben a mellékelt data.txt alapján!
            var projs = new Project[]
            {
                new Project(){ Id = 1, ProjectName = "Felhő alapú fizetési megoldás", Customer = "Mol Zrt.", Cost = 2000 },
                new Project(){ Id = 2, ProjectName = "Portfolio weboldal", Customer = "Tóth Csaba e.v.", Cost = 300 },
                new Project(){ Id = 3, ProjectName = "5G hálózathoz monitoring rendszer", Customer = "Magyar Telekom", Cost = 5000 },
                new Project(){ Id = 4, ProjectName = "Üzleti intelligencia projekt", Customer = "Mol Zrt.", Cost = 1500 },
                new Project(){ Id = 5, ProjectName = "Biometrikus beléptetőkapu", Customer = "Magyar Telekom", Cost = 1000 },
                new Project(){ Id = 6, ProjectName = "Mobil alkalmazás", Customer = "Rizmajer Sörfőzde", Cost = 1000 },
                new Project(){ Id = 7, ProjectName = "Elnökséget imitáló chatbot", Customer = "NIK HÖK", Cost = 1500 },
                new Project(){ Id = 8, ProjectName = "Okos benzinkút", Customer = "Mol Zrt.", Cost = 90000 },

            };


            var devs = new Developer[]{
                new Developer(){ Id = 1, Name = "Nagy Béla", IsStudent = false, ProjectId = 1 },
                new Developer(){ Id = 2, Name = "Kovács Géza", IsStudent = true, ProjectId = 1 },
                new Developer(){ Id = 3, Name = "Varga Emese", IsStudent = false, ProjectId = 1 },
                new Developer(){ Id = 4, Name = "Tóth Dániel", IsStudent = false, ProjectId = 1 },
                new Developer(){ Id = 5, Name = "Varga Emese", IsStudent = false, ProjectId = 2 },
                new Developer(){ Id = 6, Name = "Tóth Szabolcs", IsStudent = false, ProjectId = 2 },
                new Developer(){ Id = 7, Name = "Nagy Béla", IsStudent = false, ProjectId = 3 },
                new Developer(){ Id = 8, Name = "Kovács Géza", IsStudent = true, ProjectId = 3 },
                new Developer(){ Id = 9, Name = "Varga Eszter", IsStudent = true, ProjectId = 3 },
                new Developer(){ Id = 10, Name = "Sipos Miklós", IsStudent = true, ProjectId = 3 },
                new Developer(){ Id = 11, Name = "Kovács Géza", IsStudent = true, ProjectId = 4 },
                new Developer(){ Id = 12, Name = "Varga Emese", IsStudent = false, ProjectId = 4 },
                new Developer(){ Id = 13, Name = "Tóth Zsombor", IsStudent = false, ProjectId = 4 },
                new Developer(){ Id = 14, Name = "Nagy Béla", IsStudent = false, ProjectId = 5 },
                new Developer(){ Id = 15, Name = "Kovács Géza", IsStudent = true, ProjectId = 5 },
                new Developer(){ Id = 16, Name = "Varga Emese", IsStudent = false, ProjectId = 5 },
                new Developer(){ Id = 17, Name = "Tóth Dániel", IsStudent = false, ProjectId = 5 },
                new Developer(){ Id = 18, Name = "Nagy Béla", IsStudent = false, ProjectId = 6 },
                new Developer(){ Id = 19, Name = "Tóth Dániel", IsStudent = false, ProjectId = 6 },
                new Developer(){ Id = 20, Name = "Kovács András", IsStudent = false, ProjectId = 8 },
                new Developer(){ Id = 21, Name = "Szénási Sándor", IsStudent = true, ProjectId = 8 },
                new Developer(){ Id = 22, Name = "Varga Emese", IsStudent = false, ProjectId = 8 },
                new Developer(){ Id = 23, Name = "Tóth Dániel", IsStudent = false, ProjectId = 8 }
                        };

            modelBuilder.Entity<Project>().HasData(projs);
            modelBuilder.Entity<Developer>().HasData(devs);

            base.OnModelCreating(modelBuilder);
        }
    }
}
