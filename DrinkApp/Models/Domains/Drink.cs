using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkApp.Models.Domains
{
    public class Drink
    {
        public Drink()
        {
            TypeDrink = new Collection<TypeDrink>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Weight { get; set; }

        public int Score { get; set; }

        public int Time { get; set; }

        public bool Sober { get; set; }

        public int GroupId { get; set; }


        public Group Group { get; set; }

        public ICollection<TypeDrink> TypeDrink { get; set; }
    }
}
