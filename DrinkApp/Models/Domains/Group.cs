using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkApp.Models.Domains
{
    public class Group
    {
        public Group()
        {
            Drinks = new Collection<Drink>();
        }

        public int Id { get; set; }

        public string Name { get; set; }


        public ICollection<Drink> Drinks { get; set; }
    }
}
