using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkApp.Models
{
    public class Drink
    {
        public Drink()
        {
            Group = new Group();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public int Weight { get; set; }

        public int Beer { get; set; }

        public int Wine { get; set; }

        public int Vodka { get; set; }

        public int Score { get; set; }
        
        public bool Sober { get; set; }

        public Group Group { get; set; }
    }
}
