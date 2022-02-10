using DrinkApp.Models.Domains;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkApp.Models.Configurations
{
    public class TypeDrinksConfiguration : EntityTypeConfiguration<TypeDrink>
    {
        public TypeDrinksConfiguration()
        {
            ToTable("dbo.TypeDrinks");

            HasKey(x => x.Id);
        }
    }
}
