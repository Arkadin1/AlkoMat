using DrinkApp.Models.Configurations;
using DrinkApp.Models.Domains;
using System;
using System.Data.Entity;
using System.Linq;

namespace DrinkApp
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext()
            : base("name=ApplicationDbContext")
        {

        }

        public DbSet<Drink> Drinks { get; set; }
        public DbSet<TypeDrink> TypeDrinks { get; set; }
        public DbSet<Group> Groups { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DrinkConfiguration());
            modelBuilder.Configurations.Add(new GroupConfiguration());
            modelBuilder.Configurations.Add(new TypeDrinksConfiguration());
        }
    }

}