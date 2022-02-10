using DrinkApp.Models.Domains;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkApp.Models.Configurations
{
    public class DrinkConfiguration : EntityTypeConfiguration<Drink>
    {
        public DrinkConfiguration()
        {
            ToTable("dbo.Drinks");

            HasKey(x => x.Id);

            Property(x => x.Name).HasMaxLength(20).IsRequired();
        }
    }
}
