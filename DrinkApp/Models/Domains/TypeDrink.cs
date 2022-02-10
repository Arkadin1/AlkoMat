using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkApp.Models.Domains
{
    public class TypeDrink
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public int DrinkId { get; set; }

        public int TypeDrinkId { get; set; }

        public Drink Drink { get; set; }
    }
}
